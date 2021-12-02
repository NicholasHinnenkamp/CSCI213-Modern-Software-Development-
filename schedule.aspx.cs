using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Assignment5
{
    public partial class schedule : System.Web.UI.Page
    {
        KarateDataContext dbcon = new KarateDataContext();
        protected void Page_Load(object sender, EventArgs e)
        {
            ShowAll();
        }
        public void ShowAll()
        {
            var result = from x in dbcon.Schedules
                         select x;
            GridView1.DataSource = result;
            GridView1.DataBind();
        }
        protected void Button1_Click(object sender, EventArgs e)
        {
            Schedule abc = new Schedule();
            abc.Instructor_Id = int.Parse(DropDownList5.SelectedItem.Value);
            abc.Day = short.Parse(DropDownList1.SelectedItem.Value);
            abc.Time = Convert.ToDateTime(TextBox1.Text);
            dbcon.Schedules.InsertOnSubmit(abc);
            dbcon.SubmitChanges();
            ShowAll();
        }
    }
}