using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Configuration;
using System.Data;
using MySql.Data.MySqlClient;

public partial class MasterPage : System.Web.UI.MasterPage
{
   
    protected void Page_Load(object sender, EventArgs e)
    {
        
    }

    protected void LinkButton1_Click(object sender, EventArgs e)
    {
        Response.Redirect("PatientLoginPage.aspx");
    }

    protected void LinkButton2_Click(object sender, EventArgs e)
    {
        Response.Redirect("PatientAccountPage.aspx");
    }

    protected void LinkButton3_Click(object sender, EventArgs e)
    {
        Response.Redirect("Default.aspx");
    }



    protected void LinkButton4_Click(object sender, EventArgs e)
    {
        Response.Redirect("ConditionsPage.aspx");
    }

    protected void LinkButton5_Click(object sender, EventArgs e)
    {
        Response.Redirect("LabResultsPage.aspx");
    }

    protected void LinkButton6_Click(object sender, EventArgs e)
    {
        Response.Redirect("MedicationsPage.aspx");
    }

    protected void LinkButton7_Click(object sender, EventArgs e)
    {
        Response.Redirect("VisitSummaryPage.aspx");
    }

    protected void LinkButton8_Click(object sender, EventArgs e)
    {
        Response.Redirect("CarePlanPage.aspx");
    }

    protected void LinkButton9_Click(object sender, EventArgs e)
    {
        Response.Redirect("MyProfilePage.aspx");
    }
}
