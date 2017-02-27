using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CreateXmlFile
{
    public class Question
    {
        private string textQuestion;   
        private List<string> answers;     // list of answers
        private int numberOfRightAnswer;  // the number of right answer, starts from 1 to N

        public Question(string txtQ, List<string> ans, int rightA)
        {
            this.TextQuestion = txtQ;
            this.Answers = ans;
            this.NumberOfRightAnswer = rightA;
        }

        public Question(Question copy) : this (copy.TextQuestion, copy.Answers,copy.NumberOfRightAnswer)
        {
        }

        public string TextQuestion
        {
            get
            {
                return this.textQuestion;
            }
            set
            {
                if (value != null && value.Length > 1)
                {
                    this.textQuestion = value;
                }
            }
        }

        public List<string> Answers
        {
            get
            {
                return this.answers;
            }

            set
            {
                if (value != null)
                {
                    this.answers = new List<string>(value);
                }
            }
        }
        public int NumberOfRightAnswer
        {
            get
            {
                return this.numberOfRightAnswer;
            }
            private set
            {
                if(value > Answers.Count || value < 1)
                {
                    int answ = Answers.Count;
                    string exceptionText = string.Format("There is only {0} questions, you should pick some of them to be true!", answ);
                    throw new InvalidOperationException(exceptionText);
                }
                else
                {
                    this.numberOfRightAnswer = value;
                }
            }
        }
     
        public void PrintQuestion()
        {
            Console.WriteLine(this.textQuestion + " ?");
            for(int i = 0; i < answers.Count; i++)
            {
                Console.WriteLine("   {0} {1}", i, this.answers[i]);
            }
        }
    }
}
