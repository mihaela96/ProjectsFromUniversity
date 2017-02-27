using CreateXmlFile;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Net.Sockets;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Timers;
using System.Windows.Forms;
using XmlReader;

namespace Client
{
    public partial class FormClient : Form
    {
        private string nameOfStudent;              
        private List<Question> questionInQuiz;     
        private int time;   
        private int count;
        private bool flag = true;
                                
        private int points;                        
        private int currentQuestion;
        private Dictionary<int,string> userAnswer;
                      
        private TimeSpan timeSpan;                 
        private TimeSpan oneSecond;

        private string resultForSurvey;   //send to server

        System.Timers.Timer timer;

        XmlReaderFile quizFile;

        #region Name of Student
    
        public string NameOfStudent
        {
            get
            {
                return this.nameOfStudent;
            }
            set
            {
                if(value != null)
                {
                    this.nameOfStudent = value;
                }
                else
                {
                    throw new InvalidOperationException("You must enter name!");
                }
            }
        }

        #endregion
        public FormClient()
        {
            InitializeComponent();
            oneSecond = new TimeSpan(0, 0, 1);
            timer = new System.Timers.Timer(1000);
            userAnswer = new Dictionary<int,string>();
        }

        private NetworkStream output;
        private BinaryWriter writer;
        private BinaryReader reader;
        private Thread readThread;
        private TcpClient client;
        private string message = "";

        private void FormClient_Load(object sender, EventArgs e)
        {
            readThread = new Thread(new ThreadStart(RunClient));
            readThread.Start();
            this.btnBack.Enabled = false;
            this.btnNext.Enabled = false;
        }

        private void FormClient_FormClosing(object sender, FormClosingEventArgs e)
        {
            System.Environment.Exit(System.Environment.ExitCode);
        }

        private delegate void DisplayDelegate(string message);

        #region Display Message
        private void DisplayMessage(string message)
        {
            if (txtDisplayMsg.InvokeRequired)
            {                          
                Invoke(new DisplayDelegate(DisplayMessage),
                   new object[] { message });
            } 
            else 
                txtDisplayMsg.Text += message;
        }
        #endregion
        public void RunClient()
        {
            

            // instantiate TcpClient for sending data to server
            try
            {
                DisplayMessage("Attempting connection\r\n");

                // Step 1: create TcpClient and connect to server
                client = new TcpClient();
                client.Connect("127.0.0.1", 50000);

                // Step 2: get NetworkStream associated with TcpClient
                output = client.GetStream();

                // create objects for writing and reading across stream
                writer = new BinaryWriter(output);
                reader = new BinaryReader(output);

                DisplayMessage("\r\nGot I/O streams\r\n");

                // loop until server signals termination
                do
                {
                    // Step 3: processing phase
                    try
                    {
                        // read message from server        
                        message = reader.ReadString();

                    } // end try
                    catch (Exception)
                    {
                        // handle exception if error in reading server data
                        System.Environment.Exit(System.Environment.ExitCode);
                    } // end catch
                } while (flag);

                // Step 4: close connection
                writer.Close();
                reader.Close();
                output.Close();
                client.Close();

                Application.Exit();
            } // end try
            catch (Exception error)
            {
                MessageBox.Show(error.ToString(), "Connection Error",
                   MessageBoxButtons.OK, MessageBoxIcon.Error);
                System.Environment.Exit(System.Environment.ExitCode);
            } 
        } 

        #region Read and Fill Quiz using Xml file C#test 
        private void ReadAndFillQuiz()
        {
            string[] array = message.Split(' ');

            this.time = int.Parse(array[0]);
            this.count = int.Parse(array[1]);

            questionInQuiz = new List<Question>();
            quizFile = new XmlReaderFile();
            quizFile.Shuffle();
        
            for(int i = 0; i < this.count; i++)
            {
                questionInQuiz.Add(quizFile.Quiz[i]);
            }
            
            
        }

        #endregion
        private void txtName_TextChanged(object sender, EventArgs e)
        {
            this.nameOfStudent = txtName.Text;
        }

        #region Set Group Box Question
        private void setGroupBoxQuestion(int position)
        {
            this.lblQuestion.Text = questionInQuiz[position].TextQuestion;
            this.radioBtnAns1.Text = questionInQuiz[position].Answers[0];
            this.radioBtnAns2.Text = questionInQuiz[position].Answers[1];
            this.radioBtnAns3.Text = questionInQuiz[position].Answers[2];
            this.radioBtnAns4.Text = questionInQuiz[position].Answers[3];
        }

        #endregion

        private void ClearRadioButtons()
        {
            this.radioBtnAns1.Checked = false;
            this.radioBtnAns2.Checked = false;
            this.radioBtnAns3.Checked = false;
            this.radioBtnAns4.Checked = false;
        }

        #region Button Start
        private void btnStart_Click(object sender, EventArgs e)
        {
            ClearRadioButtons();
            ReadAndFillQuiz();

            currentQuestion = 0;
            setGroupBoxQuestion(currentQuestion);
            ClearRadioButtons();

            timeSpan = new TimeSpan(0, 0, this.time);
            this.lblTime.Text += " " + timeSpan.ToString();

            timer.Elapsed += new ElapsedEventHandler(timer_Elapsed);
            timer.Start();
            this.btnStart.Enabled = false;
            this.btnBack.Enabled = true;
            this.btnNext.Enabled = true;
            ClearRadioButtons();
        }
        #endregion

        #region Calculate Mark
        private int CalculateMark()
        {
            double countOfQ = (double)this.count;
            double percentOfRansw =  ((this.points) / countOfQ) * 100;

            
            if (percentOfRansw >= 0 && percentOfRansw <= 54)
            {
                return 2;
            }

            else if (percentOfRansw >= 55 && percentOfRansw <= 64)
            {
                return 3;
            }

            else if (percentOfRansw >= 65 && percentOfRansw <= 74)
            {
                return 4;
            }

            else if (percentOfRansw >= 75 && percentOfRansw <= 84)
            {
                return 5;
            }

            else
            {
                return 6;
            }
            
        }

        #endregion

        #region Time Past
        private void timer_Elapsed(object sender, EventArgs e)
        {
            if (timeSpan != TimeSpan.Zero)
            {
                string tempLabel = "Time Left:  ";
                string modifyTime = timeSpan.ToString();
                this.lblTimeLeft.Text = tempLabel + modifyTime;
                timeSpan -= oneSecond;
            }
            else
            {
                timer.Stop();
                MakePoints();
                int mark = CalculateMark();
                string result = string.Format("Your mark for the test is : {0}", mark);

                this.resultForSurvey = string.Format("Name: {0}, Mark: {1}, Points: {2}" , this.NameOfStudent, mark, this.points);
                DialogResult dialog = MessageBox.Show(result, "Result!", MessageBoxButtons.OK);


                try
                {
                    writer.Write(this.resultForSurvey);
                    txtDisplayMsg.Text += resultForSurvey;

                }
                catch (SocketException)
                {
                    txtDisplayMsg.Text += "\nError writing object";
                }

                
                if (dialog == DialogResult.OK)
                {
                    this.flag = false;
                    writer.Close();
                    reader.Close();
                    output.Close();
                    client.Close();
                } 
                
            }
        }

        #endregion

        #region Button Back
        private void btnBack_Click(object sender, EventArgs e)
        {
            
            if(currentQuestion == 0)
            {
                MessageBox.Show("There is no previous question!","Error!",MessageBoxButtons.OK);
            }

            else 
            {
                CheckForRightAnswer();
                currentQuestion--;
                setGroupBoxQuestion(currentQuestion);

                if(this.btnNext.Text != "Next")
                {
                    this.btnNext.Text = "Next";
                }

                switch (userAnswer[currentQuestion])
                {
                    case "1": { radioBtnAns1.Checked = true; break; }
                    case "2": { radioBtnAns2.Checked = true; break; }
                    case "3": { radioBtnAns3.Checked = true; break; }
                    case "4": { radioBtnAns4.Checked = true; break; }
                    default: { ClearRadioButtons(); break; }

                }
            }
        }

        #endregion

        #region Check for right answer
        private void CheckForRightAnswer()
        {
            RadioButton checkeButton = null;

            if (this.radioBtnAns1.Checked == true)
            {
                checkeButton = radioBtnAns1;
                if (!userAnswer.ContainsKey(currentQuestion))
                {
                    userAnswer.Add(currentQuestion, "1");
                }
                else
                {
                    userAnswer[currentQuestion] = "1";
                }

            }
            else if (this.radioBtnAns2.Checked == true)
            {
                checkeButton = radioBtnAns2;
                if (!userAnswer.ContainsKey(currentQuestion))
                {
                    userAnswer.Add(currentQuestion, "2");
                }
                else
                {
                    userAnswer[currentQuestion] = "2";
                }
            }
            else if (this.radioBtnAns3.Checked == true)
            {
                checkeButton = radioBtnAns3;
                if (!userAnswer.ContainsKey(currentQuestion))
                {
                    userAnswer.Add(currentQuestion, "3");
                }
                else
                {
                    userAnswer[currentQuestion] = "3";
                }
            }
            else if (this.radioBtnAns4.Checked == true)
            {
                checkeButton = radioBtnAns4;
                if (!userAnswer.ContainsKey(currentQuestion))
                {
                    userAnswer.Add(currentQuestion, "4");
                }
                else
                {
                    userAnswer[currentQuestion] = "4";
                }
            }
            else
            {
                checkeButton = null;
                if (!userAnswer.ContainsKey(currentQuestion))
                {
                    userAnswer.Add(currentQuestion, "0");
                }
                else
                {
                    userAnswer[currentQuestion] = "0";
                }
            }
            
        }
        #endregion

        private void MakePoints()
        {

            this.points = 0;

            for(int i = 0; i < this.currentQuestion; i++)
            {
                int numOfrightAnsw = (this.questionInQuiz[i]).NumberOfRightAnswer;

                if (numOfrightAnsw == int.Parse(this.userAnswer[i]))
                {
                    points++;
                }

            }

        }
        #region Button Next
        private void btnNext_Click(object sender, EventArgs e)
        {

            CheckForRightAnswer();

            if (currentQuestion == (this.questionInQuiz.Count - 2))
            {

                currentQuestion++;
                setGroupBoxQuestion(currentQuestion);

                if (!userAnswer.ContainsKey(currentQuestion))
                {
                    ClearRadioButtons();
                }
                else
                {
                    switch (userAnswer[currentQuestion])
                    {
                        case "1": { radioBtnAns1.Checked = true; break; }
                        case "2": { radioBtnAns2.Checked = true; break; }
                        case "3": { radioBtnAns3.Checked = true; break; }
                        case "4": { radioBtnAns4.Checked = true; break; }
                        default: { ClearRadioButtons(); break; }

                    }
                }
                this.btnNext.Text = "Submit";

            }

            else if (this.btnNext.Text.Equals("Submit"))
            {
                CheckForRightAnswer();
                timer.Stop();
                MakePoints();

                int mark = CalculateMark();
                string result = string.Format("Your mark for the test is : {0}", mark);
                this.resultForSurvey = string.Format("Name: {0}, Mark: {1}, Points: {2}", this.NameOfStudent, mark, this.points);

                try
                {
                        writer.Write(this.resultForSurvey);
                        txtDisplayMsg.Text += resultForSurvey;
                }
                catch (SocketException)
                {
                    txtDisplayMsg.Text += "\nError writing object";
                }

                DialogResult dialog = MessageBox.Show(result, "Result!", MessageBoxButtons.OK);

                if (dialog == DialogResult.OK)
                {
                    this.flag = false;
                    writer.Close();
                    reader.Close();
                    output.Close();
                    client.Close();
                    
                }
            }

            else
            {
                currentQuestion++;
                setGroupBoxQuestion(currentQuestion);

                if (!userAnswer.ContainsKey(currentQuestion))
                {
                    ClearRadioButtons();
                }
                else
                {
                    switch (userAnswer[currentQuestion])
                    {
                        case "1": { radioBtnAns1.Checked = true; break; }
                        case "2": { radioBtnAns2.Checked = true; break; }
                        case "3": { radioBtnAns3.Checked = true; break; }
                        case "4": { radioBtnAns4.Checked = true; break; }
                        default: { ClearRadioButtons(); break; }

                    }
                }

            }

        }
        #endregion

    }
}

