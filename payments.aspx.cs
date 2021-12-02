using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Assignment5
{
    public partial class payments : System.Web.UI.Page
    {
        KarateDataContext dbcon = new KarateDataContext();
        protected void Page_Load(object sender, EventArgs e)
        {
            var results = from x in dbcon.Payments
                          from y in dbcon.Members
                          where x.Member_Id == y.ID
                          orderby y.Last_Name
                          let Payment_Date = Convert.ToDateTime(x.Payment_Date).ToShortDateString()
                          let myAmount = String.Format("{0:C2}", x.Amount)
                          select new { y.First_Name, y.Last_Name, Payment_Date, Amount = myAmount };
            GridView1.DataSource = results;
            GridView1.DataBind();
        }
    }
}