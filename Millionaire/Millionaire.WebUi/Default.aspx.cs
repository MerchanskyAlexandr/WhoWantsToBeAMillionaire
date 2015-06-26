using Millionaire.WebUi.Code;
using Millionaire.WebUi.Code.Keys;
using System;
using System.Web;
using System.Web.UI;


namespace Millionaire.WebUi
{
    public partial class Default : Page
    {
        public UserName NameContext
        {
            get
            {
                UserName userName = (UserName)HttpContext.Current.Session[SessionKeys.NAME_SESSION_KEY];
                if (userName == null)
                {
                    userName = new UserName();
                    HttpContext.Current.Session[SessionKeys.NAME_SESSION_KEY] = userName;
                }
                return userName;
            }
            set
            {
                HttpContext.Current.Session[SessionKeys.NAME_SESSION_KEY] = value;
            }
        }

        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void btnStartGame_Click(object sender, EventArgs e)
        {
            NameContext.Name = txtUserName.Text;
            Response.Redirect("~/Game.aspx");
        }
    }
}