using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Millionaire.WebUi
{
    public partial class TableCash : System.Web.UI.UserControl
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }
        public void FirstSum(int currentQuestion)
        {
            if (currentQuestion == 0)
            {
                tblMoney.Rows[14].Attributes.Add("class", "current-sum");
            }
        }
        public void CurrentSum(int currentQuestion)
        {
            tblMoney.Rows[15 - currentQuestion - 1].Attributes.Add("class", "current-sum");
            tblMoney.Rows[15 - currentQuestion].Attributes.Add("class", "before-sum");
        }
    }
}