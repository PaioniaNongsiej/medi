﻿using Microsoft.AspNet.FriendlyUrls;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace MediRecipe
{
    public partial class AdminLogin : System.Web.UI.Page
    {
        protected void btnlogin_Click(object sender, EventArgs e)
        {
            string strcon = "Data Source=DESKTOP-693JKF9;database=ProjectDB;integrated security = true;";
            SqlConnection con = new SqlConnection(strcon);
            SqlCommand com = new SqlCommand("Adlogin", con);
            com.CommandType = System.Data.CommandType.StoredProcedure;
            SqlParameter sp1 = new SqlParameter("EmailID", emailid.Text);
            SqlParameter sp2 = new SqlParameter("Password", password.Text);

            com.Parameters.Add(sp1);
            com.Parameters.Add(sp2);

            con.Open();
            SqlDataReader dr = com.ExecuteReader();
            if (dr.HasRows)
            {
                dr.Read();
                Response.Redirect("adminHome.aspx");

            }
            else
            {
                lblmsg.Text = "Invalid username or password.";
                lblmsg.Visible = true;
            }
        }

        protected void Page_Load(object sender, EventArgs e)
        {

        }
    }
}