using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace ParkingPalsClientSide
{
    public partial class PopLogin : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void getUsernameText_TextChanged(object sender, EventArgs e)
        {

        }

        protected void getPasswordText_TextChanged(object sender, EventArgs e)
        {

        }

        protected void checkCredentialsButton_Click(object sender, EventArgs e)
        {
            String connStr = "Data Source=(LocalDB)\\MSSQLLocalDB;AttachDbFilename= C:\\Users\\Gavin\\Downloads\\559A_Final_Submission\\ParkingPalDBWS\\ParkingPalDBWS\\App_Data\\ParkingPalConnection.mdf ;Integrated Security = True";
            SqlConnection conn = new SqlConnection(connStr);
            conn.Open();
            SqlCommand command = new SqlCommand("SELECT * FROM userProfile WHERE username=@user;", conn);
            command.Parameters.AddWithValue("@user", getUsernameText.Text);

            using (SqlDataReader reader = command.ExecuteReader())
            {
                if (reader.HasRows)
                {
                    string userPassword = "";
                    while (reader.Read())
                    {
                        userPassword = reader.GetString(2);
                    }
                    if (string.Equals(getPasswordText.Text, userPassword))
                    {
                        conn.Close();
                        Response.Redirect("https://localhost:44373/HomePage.aspx?username="+getUsernameText.Text);
                    } 
                    else
                    {
                        conn.Close();
                        labelError.Text = "You have entered an incorrect password.";
                        
                    }
                }
                else
                {
                    conn.Close();
                    labelError.Text = "You have entered an incorrect username.";
                }
            }

         
        }
    }
}