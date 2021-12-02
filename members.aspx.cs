using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Assignment5
{
    public partial class members : System.Web.UI.Page
    {
        KarateDataContext dbcon = new KarateDataContext(); 
        protected void Page_Load(object sender, EventArgs e)
        {
            var results = from x in dbcon.Members
                          select new { x.First_Name, x.Last_Name, x.Phone, x.Date_Joined };
            GridView1.DataSource = results;
            GridView1.DataBind();
        }
    }
}