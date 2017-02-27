using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CreateXmlFile;
using System.Xml;
using System.Xml.Linq;

namespace XmlReader
{
    public class XmlReaderFile
    {
        private List<Question> quiz;
        private static Random rng = new Random();
        public List<Question> Quiz
        {
            get
            {
               return this.quiz;
            }
        }

        public int CountInQuestionInQuiz
        {
            get
            {
                return (this.quiz).Count;
            }
        }
        public XmlReaderFile()
        {
            FillQuiz();
        }

        private void FillQuiz()
        {
            XmlDocument doc = new XmlDocument();
            doc.Load("../../../testC#.xml");
            quiz = new List<Question>();

            XmlNodeList testNodes = doc.DocumentElement.SelectNodes("/Test/Question");

            foreach(XmlNode testNode in testNodes)
            {
                string textQ = testNode["Text"].InnerText;
                List<string> answers = new List<string>();
                int rightAns = 0;

                XmlNodeList questionNodes = testNode.ChildNodes;

                for(int i = 1; i < questionNodes.Count; i++)
                {
                    if (questionNodes[i].Name.Equals("answer-Right"))
                    {
                        rightAns = i;
                    }
                    answers.Add(questionNodes[i].InnerText);
                }

                Question cSharpQuestion = new Question(textQ, answers, rightAns);
                quiz.Add(cSharpQuestion);
             }

        }

        public void InsertInXml(Question userQuestion)
        {
            XmlDocument doc = new XmlDocument();
            doc.Load("../../../testC#.xml");

            XmlNode node = doc.CreateNode(XmlNodeType.Element, "Question", null);

            XmlNode nodeText = doc.CreateElement("Text");
            nodeText.InnerText = userQuestion.TextQuestion;

            int rightAnsw = userQuestion.NumberOfRightAnswer;

            XmlNode[] nodeAnswers = new XmlNode[4];

            for(int i = 0; i < 4; i++)
            {
                if(rightAnsw == i + 1)
                {
                    nodeAnswers[i] = doc.CreateElement("answer-Right");
                    nodeAnswers[i].InnerText = userQuestion.Answers[i];
                }
                else
                {
                    nodeAnswers[i] = doc.CreateElement("answer");
                    nodeAnswers[i].InnerText = userQuestion.Answers[i];
                }
            }

            node.AppendChild(nodeText);

            for(int j = 0; j < 4; j++)
            {
                node.AppendChild(nodeAnswers[j]);
            }

            doc.DocumentElement.AppendChild(node);

            doc.Save("../../../testC#.xml");
        }

        public void Shuffle()
        {
            int n = quiz.Count;
            while (n > 1)
            {
                n--;
                int k = rng.Next(n + 1);
                Question value = new Question(quiz[k]);
                quiz[k] = new Question(quiz[n]);
                quiz[n] = new Question(value);
            }
        }

    }
}

