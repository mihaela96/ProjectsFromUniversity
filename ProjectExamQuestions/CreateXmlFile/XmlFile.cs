using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;

namespace CreateXmlFile
{
    public class XmlFile
    {
        private XmlDocument doc;
        private string pathOfFile;
        private XmlTextWriter writer;

        public XmlFile(string path)
        {
            this.doc = new XmlDocument();
            this.pathOfFile = path;
            this.writer = new XmlTextWriter(pathOfFile, System.Text.Encoding.UTF8);
        }

        public XmlFile() : this("defaulXMLfile")
        {
        }

        //function for writing questions in XML;
        public void FillXml(List<Question> quizes)
        {
            writer.WriteStartDocument(true);
            writer.Formatting = Formatting.Indented;
            writer.Indentation = 2;
            writer.WriteStartElement("Test");

            for(int i = 0; i < quizes.Count; i++)
            {
                createNode(quizes[i]);
            }
            writer.WriteEndElement();
            writer.WriteEndDocument();
            writer.Close();

            doc.Save(writer);
          
        }

        public void createNode(Question quiz)
        {
            writer.WriteStartElement("Question");
            writer.WriteStartElement("Text");
            writer.WriteString(quiz.TextQuestion);
            writer.WriteEndElement();

            for(int i = 0; i < quiz.Answers.Count; i++)
            {
                string answerString = string.Format("{0}. {1}", i + 1, quiz.Answers[i]);
                if (quiz.NumberOfRightAnswer == (i + 1))
                {
                    writer.WriteStartElement("answer-Right");
                    writer.WriteString(answerString);
                    writer.WriteEndElement();
                }
                else
                {
                    writer.WriteStartElement("answer");
                    writer.WriteString(answerString);
                    writer.WriteEndElement();
                }
            }
            writer.WriteEndElement();
        }

      
    }
}
