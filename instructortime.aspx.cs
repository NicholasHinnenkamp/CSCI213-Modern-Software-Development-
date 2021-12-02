using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Assignment5
{
    public partial class instructortime : System.Web.UI.Page
    {
        KarateDataContext dbcon = new KarateDataContext();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack) 
            {
                var results = from y in dbcon.Instructors
                              select new { 
                                            y.Last_Name,
                                            y.ID
                              };

                DropDownList1.DataSource = results;
                DropDownList1.DataTextField = "Last_Name";
                DropDownList1.DataValueField = "ID";
                DropDownList1.DataBind();
            }


        }

        protected void DropDownList1_SelectedIndexChanged(object sender, EventArgs e)
        {
            int id = int.Parse(DropDownList1.SelectedItem.Value);
            var results = from x in dbcon.Schedules
                          join y in dbcon.Instructors
                          on x.Instructor_Id equals (int)y.ID
                          join z in dbcon.Days
                          on x.Day equals z.num
                          where (int)y.ID  == id
                          let Date = Convert.ToDateTime(x.Time).ToShortDateString()
                          let Time = Convert.ToDateTime(x.Time).ToShortTimeString()
                          select new { y.Last_Name, Day = z.name, Date, Time };

            GridView1.DataSource = results;
            GridView1.DataBind();
        }
    }
}