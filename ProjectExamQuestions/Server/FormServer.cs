using CreateXmlFile;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Net;
using System.Net.Sockets;
using XmlReader;
using System.Threading;
using System.IO;

namespace Server
{
    public partial class FormServer : Form
    {
        private int secondsForTheTest;
        private int countOfQuestion;
        private string result;   //send to server like "SS CC" where SS is second , CC is count of question
        XmlReaderFile XmlFileWithTest;   //read the Xml file 

        public FormServer()
        {
            InitializeComponent();
            XmlFileWithTest = new XmlReaderFile();
            writers = new Dictionary<Thread, BinaryWriter>();
            readers = new Dictionary<Thread, Socket>();

        }

        private Thread readThread;  //for procesing incoming message
        private Dictionary<Thread, BinaryWriter> writers;
        private Dictionary<Thread, Socket> readers;

        //initialize Thread
        private void FormServer_Load(object sender, EventArgs e)
        {
            readThread = new Thread(new ThreadStart(RunServer));
            readThread.Start();
        }

        private void FormServer_FormClosing(object sender, FormClosingEventArgs e)
        {
            System.Environment.Exit(System.Environment.ExitCode);
        }

        private delegate void DisplayDelegate(string message);

        #region Button Add Question

        private void btnAddQuestion_Click(object sender, EventArgs e)
        {
            string textOfQuestion = string.Empty;
            List<string> answ = new List<string>();
            int correctAnsw;

            if (txtTextQuestionS.Text == null || txtAnsw1S.Text == null ||
               txtAnsw2S.Text == null || txtAnsw3S.Text == null ||
               txtAnsw4S.Text == null || txtRightAnsw.Text == null)
            {
                MessageBox.Show("You must fill all of the fields to add question!", "Error!", MessageBoxButtons.OK);
            }

            textOfQuestion = this.txtTextQuestionS.Text;
            answ.Add(this.txtAnsw1S.Text);
            answ.Add(this.txtAnsw2S.Text);
            answ.Add(this.txtAnsw3S.Text);
            answ.Add(this.txtAnsw4S.Text);
            correctAnsw = int.Parse(this.txtRightAnsw.Text);

            Question newQuestion = new Question(textOfQuestion, answ, correctAnsw);

            XmlFileWithTest.InsertInXml(newQuestion);

            this.txtTextQuestionS.Clear();
            this.txtAnsw1S.Clear();
            this.txtAnsw2S.Clear();
            this.txtAnsw3S.Clear();
            this.txtAnsw4S.Clear();
            this.txtRightAnsw.Clear();

        }

        #endregion

        #region Button Define
        private void btnDefine_Click(object sender, EventArgs e)
        {
            int seconds;
            int count;

            //if text field isnt empty and is a number
            if (int.TryParse(this.txtCount.Text, out count) && int.TryParse(this.txtTime.Text, out seconds) && 
                count > 0 && seconds > 0)
            {

                this.secondsForTheTest = seconds;

                if (XmlFileWithTest.CountInQuestionInQuiz < count)
                {
                    string message = string.Format("There isn't enough question in the File : You should add new question or you should require fewer questions!  Question in Bank: {0}, Question required: {1}."
                                     , XmlFileWithTest.CountInQuestionInQuiz, count);

                    MessageBox.Show(message, "Error!", MessageBoxButtons.OK);
                }
                else
                {
                    this.countOfQuestion = count;

                    this.result = this.secondsForTheTest + " " + this.countOfQuestion;
                    this.txtTime.Clear();
                    this.txtCount.Clear();

                    // send the text to the client
                    try
                    {
                        var keys = writers.Keys;
                        foreach (var key in keys)
                        {
                            writers[key].Write(this.result);
                        }

                    }
                    catch (SocketException)
                    {
                        this.txtInfoServer.Text += "\nError writing object";
                    }
                }
            }
            else
            {
                MessageBox.Show("You must fill the two field with positive integer numbers", "Error!", MessageBoxButtons.OK);
                this.txtCount.Text = "";
                this.txtTime.Text = "";
            }
        }

        #endregion

        #region Display message for server connection
        private void DisplayMessage(string message)
        {
            if (this.txtBoxSurvey.InvokeRequired)
            {
                Invoke(new DisplayDelegate(DisplayMessage), new object[] { message });
            }
            else
            {
                this.txtInfoServer.Text += message;
            }
        }

        #endregion

        #region Display message for Exam survey
        private void DisplayMessageInExamSurvey(string message)
        {
            if (this.txtBoxSurvey.InvokeRequired)
            {
                Invoke(new DisplayDelegate(DisplayMessageInExamSurvey), new object[] { message });
            }
            else
            {
                this.txtBoxSurvey.Text += message;
            }
        }
        #endregion

        #region Run Server 
        public void RunServer()
        {
            Socket connection;  //socket for accepting connection
            TcpListener listener;
            int counter = 1;

            try
            {
                //Step 1: create TcpListener
                IPAddress local = IPAddress.Parse("127.0.0.1");
                listener = new TcpListener(local, 50000);

                // Step 2: TcpListener waits for connection request
                listener.Start();

                // Step 3: establish connection upon client request
                while (true)
                {
                    DisplayMessage("Waiting for connection\r\n");

                    //accept an incoming connection
                    connection = listener.AcceptSocket();
                    DisplayMessage("Connection " + counter + " received.\r\n");
                    counter++;
                    Thread clientThread = new Thread(new ThreadStart(DoWorkInClient));
                    clientThread.Start();
                    readers[clientThread] = connection;
                }
            }
            catch (Exception error)
            {
                MessageBox.Show(error.ToString());
            }
        }

        #endregion

        #region Do work in Client with socket
        public void DoWorkInClient(object socket)
        {
            NetworkStream socketStream;
            BinaryWriter writer;
            BinaryReader reader;

            Socket connection = (Socket)socket;

            // create NetworkStream object associated with socket
            socketStream = new NetworkStream(connection);

            // create objects for transferring data across stream
            writer = new BinaryWriter(socketStream);
            reader = new BinaryReader(socketStream);
            writers[Thread.CurrentThread] = writer;

            // inform client that connection was successfull  
            writer.Write("SERVER>>> Connection successful");


            string theReply = "";

            // Step 4: read string data sent from client
            do
            {
                try
                {
                    // read the string sent to the server
                    theReply = reader.ReadString();

                    // display the message
                    DisplayMessageInExamSurvey("\r\n" + theReply);
                }

                catch (Exception)
                {
                    break;
                }
            } while (connection.Connected);

            // Step 5: close connection  
            writer.Close();
            reader.Close();
            socketStream.Close();
            connection.Close();
            writers.Remove(Thread.CurrentThread);
            readers.Remove(Thread.CurrentThread);

        }

        #endregion

        #region Do work in Client
        public void DoWorkInClient()
        {
            NetworkStream socketStream; // network data stream           
            BinaryWriter writer; // facilitates writing to the stream    
            BinaryReader reader; // facilitates reading from the stream  

            Socket connection = readers[Thread.CurrentThread];

            // create NetworkStream object associated with socket
            socketStream = new NetworkStream(connection);

            // create objects for transferring data across stream
            writer = new BinaryWriter(socketStream);
            reader = new BinaryReader(socketStream);
            writers[Thread.CurrentThread] = writer;

            // inform client that connection was successfull  
            writer.Write("SERVER>>> Connection successful");

            string theReply = "";

            // Step 4: read string data sent from client
            do
            {
                try
                {
                    // read the string sent to the server
                    theReply = reader.ReadString();

                    // display the message
                    DisplayMessageInExamSurvey("\r\n" + theReply);
                }

                catch (Exception)
                {
                    break;
                }
            } while (connection.Connected);

            DisplayMessage("\r\nUser terminated connection\r\n");

            // Step 5: close connection  
            writer.Close();
            reader.Close();
            socketStream.Close();
            connection.Close();
            writers.Remove(Thread.CurrentThread);
            readers.Remove(Thread.CurrentThread);

        }
        #endregion

        private void btnResizeForm_Click(object sender, EventArgs e)
        {
            string show = "Add  a   quest ion!";
            string hide = "Hide  quest ion  opt ion!";

            if ((this.btnResizeForm.Text).Equals(show))
            {
                this.Size = new Size(1004, 454);
                this.btnResizeForm.Text = hide;
            }
            else
            {
                this.Size = new Size(646, 454);
                this.btnResizeForm.Text = show;
            }
        }
    }
}
