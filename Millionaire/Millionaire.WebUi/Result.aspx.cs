using Millionaire.WebUi.Code.Keys;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Millionaire.WebUi
{
    public partial class Result : Page
    {
        
        protected void Page_Load(object sender, EventArgs e)
        {
            Default defaultPage = new Default();
            Game gamePage = new Game();

            lblResult.Text = defaultPage.NameContext.Name + " " + gamePage.CurrentCashContext.CurrentCash;
        }

    }
}