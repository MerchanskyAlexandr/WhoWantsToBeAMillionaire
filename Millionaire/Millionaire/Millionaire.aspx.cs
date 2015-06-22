using System;
using System.Collections.Generic;
using System.Data.SqlTypes;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Mail;
using System.Text;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Xml.Serialization;


namespace Millionaire
{
    public partial class Millionaire : System.Web.UI.Page
    {
        private static Question[] _questions;
        private static int _questionCount;
        private static Random _random;

        static Millionaire()
        {
            XmlSerializer formatter = new XmlSerializer(typeof(Question[]));
            using (
                FileStream fs =
                    new FileStream(
                        @"F:\Programming\Millionaire11\Millionaire\Millionaire\App_Data\QuestionsAndAnswers.xml",
                        FileMode.OpenOrCreate))
            {
                _questions = (Question[])formatter.Deserialize(fs);
            }
            _questionCount = 0;
            _random = new Random();
        }

        protected void Page_Load(object sender, EventArgs e)
        {
            FillQuestAndAnswr(_questions[_questionCount]);
            if (_questionCount == 0)
            {
                tblMoney.Rows[14].Attributes.Add("class", "current-sum");
            }
        }

        protected void btnA_Click(object sender, EventArgs e)
        {
            CheckAnswer(_questions[_questionCount], 0);
        }
        protected void btnB_Click(object sender, EventArgs e)
        {
            CheckAnswer(_questions[_questionCount], 1);
        }

        protected void btnC_Click(object sender, EventArgs e)
        {
            CheckAnswer(_questions[_questionCount], 2);
        }

        protected void btnD_Click(object sender, EventArgs e)
        {
            CheckAnswer(_questions[_questionCount], 3);
        }
        protected void btnFifty_Click(object sender, EventArgs e)
        {
            int first;
            int second;
            FiftyFifty(out first, out second);
            btnFifty.CssClass = "button-50-50-used";
            btnFifty.Enabled = false;
        }
     

        protected void btnCall_Click(object sender, EventArgs e)
        {
            MailMessage message = new MailMessage();
            message.Subject = "Millionaire";
            message.Body = "Hi, help me with correct answer " + _questions[_questionCount].Title +
                           " A: " + _questions[_questionCount].Answers[0] +
                           " B: " + _questions[_questionCount].Answers[1] +
                           " C: " + _questions[_questionCount].Answers[2] +
                           " D: " + _questions[_questionCount].Answers[3];
            message.BodyEncoding = Encoding.GetEncoding("Utf-8");
            message.From = new MailAddress("alexandrmerchansky@gmail.com");
            message.To.Add(new MailAddress("a.merchaskyj@gmail.com"));
            SmtpClient smtp = new SmtpClient
            {
                Port = 587,
                EnableSsl = true,
                Credentials = new NetworkCredential("alexandrmerchansky@gmail.com", "vthxsr1993"),
                Host = "smtp.gmail.com"
            };
            smtp.Send(message);
            btnCall.CssClass = "button-50-50-used";
            btnCall.Enabled = false;
        }

        protected void btnHall_Click(object sender, EventArgs e)
        {
            ClientScript.RegisterStartupScript(this.GetType(), "window.open", "window.open('https://www.google.com.ua/search?q="+ _questions[_questionCount].Title +"')", true);
            btnHall.Enabled = false;
            btnHall.CssClass = "button-50-50-used";
        }

        private void FillQuestAndAnswr(Question questions)
        {
            lblQuestions.Text = questions.Title;
            btnA.Text = questions.Answers[0];
            btnB.Text = questions.Answers[1];
            btnC.Text = questions.Answers[2];
            btnD.Text = questions.Answers[3];
            if (btnFifty.Enabled == false)
            {
                btnA.Enabled = true;
                btnB.Enabled = true;
                btnC.Enabled = true;
                btnD.Enabled = true;
            }    
        }

        public void CheckAnswer(Question question, int buttonIndex)
        {

            if ((question.Correct == buttonIndex) && (_questionCount != 14))
            {
                _questionCount += 1;
                FillQuestAndAnswr(_questions[_questionCount]);
                CurrentSum(_questionCount);
            }
            else if ((question.Correct == buttonIndex) && (_questionCount == 14))
            {
                GameWin();
            }
            else
            {
                GameOver();
            }

        }


        private void GameWin()
        {
            lblQuestions.Text = "Congratulation. You win 1 000 000 $.";
            btnA.Visible = false;
            btnB.Visible = false;
            btnC.Visible = false;
            btnD.Visible = false;
        }

        private void GameOver()
        {
            btnA.Visible = false;
            btnB.Visible = false;
            btnC.Visible = false;
            btnD.Visible = false;
            if ((_questionCount >= 4) && (_questionCount < 9))
            {
                lblQuestions.Text = "You lose, but u got 1 000 $";
            }
            else if ((_questionCount < 14) && (_questionCount >= 9))
            {
                lblQuestions.Text = "You lose, but u got 32 000 $";
            }
            else
            {
                lblQuestions.Text = "You lose.";
            }
        }

        private void CurrentSum(int currentQuestion)
        {
            tblMoney.Rows[15-currentQuestion-1].Attributes.Add("class","current-sum");
            tblMoney.Rows[15 - currentQuestion].Attributes.Add("class", "before-sum");
        }
        private void FiftyFifty(out int firstIncorrectAnswer, out int secondIncorrectAnswer)
        {
            firstIncorrectAnswer = _random.Next(0, 4);
            secondIncorrectAnswer = _random.Next(0, 4);

            if ((firstIncorrectAnswer != _questions[_questionCount].Correct)
                && (secondIncorrectAnswer != _questions[_questionCount].Correct)
                && (firstIncorrectAnswer != secondIncorrectAnswer))
            {
                switch (firstIncorrectAnswer)
                {
                    case 0:
                        btnA.Text = "";
                        btnA.Enabled = false;
                        break;
                    case 1:
                        btnB.Text = "";
                        btnB.Enabled = false;
                        break;
                    case 2:
                        btnC.Text = "";
                        btnC.Enabled = false;
                        break;
                    case 3:
                        btnD.Text = "";
                        btnD.Enabled = false;
                        break;
                }
                switch (secondIncorrectAnswer)
                {
                    case 0:
                        btnA.Text = "";
                        btnA.Enabled = false;
                        break;
                    case 1:
                        btnB.Text = "";
                        btnB.Enabled = false;
                        break;
                    case 2:
                        btnC.Text = "";
                        btnC.Enabled = false;
                        break;
                    case 3:
                        btnD.Text = "";
                        btnD.Enabled = false;
                        break;
                }

            }
            else
            {
                FiftyFifty(out firstIncorrectAnswer, out secondIncorrectAnswer);
            }
        }
    }
}