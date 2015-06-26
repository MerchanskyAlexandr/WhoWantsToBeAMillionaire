using System;
using System.Net;
using System.Net.Mail;
using System.Text;
using System.Web;
using System.Web.UI;
using Millionaire.WebUi.Code;
using Millionaire.WebUi.Code.Pattern.Repository;
using Millionaire.WebUi.Code.Keys;

namespace Millionaire.WebUi
{
    public partial class Game : Page
    {
        private Random _random;
        private string _path = HttpContext.Current.Server.MapPath("~/App_Data/QuestionsAndAnswers.xml");

        #region Properties

        private Question QuestionContext
        {
            get
            {
                Question question = (Question)HttpContext.Current.Session[SessionKeys.NAME_SESSION_KEY];
                if (question == null)
                {
                    question = new Question();
                    HttpContext.Current.Session[SessionKeys.NAME_SESSION_KEY] = question;
                }
                return question;
            }
            set
            {
                HttpContext.Current.Session[SessionKeys.NAME_SESSION_KEY] = value;
            }
        }
        private XmlQuestionRepository RepositoryContext
        {
            get
            {
                XmlQuestionRepository xmlQuestion = (XmlQuestionRepository)HttpContext.Current.Session[SessionKeys.REPOSITORY_SESSION_KEY];
                if (xmlQuestion == null)
                {
                    xmlQuestion = new XmlQuestionRepository(_path);
                    HttpContext.Current.Session[SessionKeys.REPOSITORY_SESSION_KEY] = xmlQuestion;
                }
                return xmlQuestion;
            }
            set
            {
                HttpContext.Current.Session[SessionKeys.REPOSITORY_SESSION_KEY] = value;
            }
        }
        public Cash CurrentCashContext
        {
            get
            {
                Cash currentCash = (Cash)HttpContext.Current.Session[SessionKeys.CASH_SESSION_KEY];
                if (currentCash == null)
                {
                    currentCash = new Cash();
                    HttpContext.Current.Session[SessionKeys.CASH_SESSION_KEY] = currentCash;
                }
                return currentCash;
            }
            set
            {
                HttpContext.Current.Session[SessionKeys.CASH_SESSION_KEY] = value;
            }
        }

        #endregion
        protected void Page_Load(object sender, EventArgs e)
        {
            RepositoryContext.GetAllQuestions();
            FillQuestAndAnswr();
            TableCash.FirstSum(RepositoryContext.QuestionCount);
        }

        protected void btnA_Click(object sender, EventArgs e)
        {
            CheckAnswer(0);
        }
        protected void btnB_Click(object sender, EventArgs e)
        {
            CheckAnswer(1);
        }

        protected void btnC_Click(object sender, EventArgs e)
        {
            CheckAnswer(2);
        }

        protected void btnD_Click(object sender, EventArgs e)
        {
            CheckAnswer(3);
        }
        protected void btnFifty_Click(object sender, EventArgs e)
        {
            int first;
            int second;
            FiftyFifty(out first, out second);
            btnFifty.Enabled = false;
            btnFifty.CssClass = "button-50-50-used";
        }


        protected void btnCall_Click(object sender, EventArgs e)
        {
            MailMessage message = new MailMessage();
            message.Subject = "Millionaire";
            message.Body = "Hi, help me with correct answer " + RepositoryContext.Questions[RepositoryContext.QuestionCount].Title +
                           " A: " + RepositoryContext.Questions[RepositoryContext.QuestionCount].Answers[0] +
                           " B: " + RepositoryContext.Questions[RepositoryContext.QuestionCount].Answers[1] +
                           " C: " + RepositoryContext.Questions[RepositoryContext.QuestionCount].Answers[2] +
                           " D: " + RepositoryContext.Questions[RepositoryContext.QuestionCount].Answers[3];
            message.BodyEncoding = Encoding.GetEncoding("Utf-8");
            message.From = new MailAddress("wwtbamillionaire@gmail.com ");
            message.To.Add(new MailAddress("alexandrmerchansky@gmail.com"));
            SmtpClient smtp = new SmtpClient
            {
                Port = 587,
                EnableSsl = true,
                Credentials = new NetworkCredential("wwtbamillionaire@gmail.com ", "wwtbamillionaire2015"),
                Host = "smtp.gmail.com"
            };
            smtp.Send(message);
            btnCall.CssClass = "button-call-used";
            btnCall.Enabled = false;
        }

        protected void btnHall_Click(object sender, EventArgs e)
        {
            ClientScript.RegisterStartupScript(this.GetType(), "window.open", "window.open('https://www.google.com.ua/search?q=" + RepositoryContext.Questions[RepositoryContext.QuestionCount].Title + "')", true);
            btnHall.Enabled = false;
            btnHall.CssClass = "button-hall-used";
        }

        private void FillQuestAndAnswr()
        {
            lblQuestions.Text = RepositoryContext.Questions[RepositoryContext.QuestionCount].Title;
            btnA.Text = RepositoryContext.Questions[RepositoryContext.QuestionCount].Answers[0];
            btnB.Text = RepositoryContext.Questions[RepositoryContext.QuestionCount].Answers[1];
            btnC.Text = RepositoryContext.Questions[RepositoryContext.QuestionCount].Answers[2];
            btnD.Text = RepositoryContext.Questions[RepositoryContext.QuestionCount].Answers[3];
            if (btnFifty.Enabled == false)
            {
                btnA.Enabled = true;
                btnB.Enabled = true;
                btnC.Enabled = true;
                btnD.Enabled = true;
            }
        }

        public void CheckAnswer(int buttonIndex)
        {

            if ((RepositoryContext.Questions[RepositoryContext.QuestionCount].Correct == buttonIndex) && (RepositoryContext.QuestionCount != 14))
            {
                RepositoryContext.QuestionCount += 1;
                FillQuestAndAnswr();
                TableCash.CurrentSum(RepositoryContext.QuestionCount);
            }
            else if ((RepositoryContext.Questions[RepositoryContext.QuestionCount].Correct == buttonIndex) && (RepositoryContext.QuestionCount == 14))
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
            CurrentCashContext.CurrentCash = "congratulation. You win 1 000 000 $.";
            Response.Redirect("~/Result.aspx");
        }

        private void GameOver()
        {
           
            if ((RepositoryContext.QuestionCount >= 4) && (RepositoryContext.QuestionCount < 9))
            {
                CurrentCashContext.CurrentCash = "you lose, but u got 1 000 $";
                Response.Redirect("~/Result.aspx");
            }
            else if ((RepositoryContext.QuestionCount < 14) && (RepositoryContext.QuestionCount >= 9))
            {
                CurrentCashContext.CurrentCash = "you lose, but u got 32 000 $";
                Response.Redirect("~/Result.aspx");
            }
            else
            {
                CurrentCashContext.CurrentCash = "you lose";
                Response.Redirect("~/Result.aspx");
            }
        }

        private void FiftyFifty(out int firstIncorrectAnswer, out int secondIncorrectAnswer)
        {
            firstIncorrectAnswer = _random.Next(0, 4);
            secondIncorrectAnswer = _random.Next(0, 4);

            if ((firstIncorrectAnswer != RepositoryContext.Questions[RepositoryContext.QuestionCount].Correct)
                && (secondIncorrectAnswer != RepositoryContext.Questions[RepositoryContext.QuestionCount].Correct)
                && (firstIncorrectAnswer != secondIncorrectAnswer))
            {
                switch (firstIncorrectAnswer)
                {
                    case 0:
                        btnA.Text = "";
                        btnA.Attributes.Remove("class");
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

        protected void btnMoney_Click(object sender, EventArgs e)
        {
            Response.Redirect("~/Result.aspx");
        }
    }
}