using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Web;
using System.Web.Script.Serialization;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace ParkingPalsClientSide
{
    public partial class ParkingPals : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            //popLogin.Visible = true;
        }

        protected void Button1_Click1(object sender, EventArgs e)
        {   /*
            // getTicketNumber
            // http://localhost:8080/ParkingPalsServer/
            //ticketNumber.Text = "http://localhost:8080/ParkingPalsServer/ticketNumber/" + TextBox1.Text;
            
            HttpWebRequest serviceRequest = (HttpWebRequest)WebRequest.Create("http://localhost:8080/ParkingPalsServer/ticketNumber/" + TextBox1.Text);
            serviceRequest.Method = "GET";
            serviceRequest.ContentLength = 0;
            serviceRequest.ContentType = "text/html";
            serviceRequest.Accept = "text/html";
            try
            {
                HttpWebResponse serviceResponse = (HttpWebResponse)serviceRequest.GetResponse();
                //ticketNumber.Text = "A valid ticket number has been added.";
                //Response.Redirect("http://localhost:8080/ParkingPalServer/ticketNumber/");//
                String temp = serviceResponse.StatusCode.ToString();
                String location = serviceResponse.GetResponseHeader("Locaiton");
            }
            catch (Exception ex)
            {
                //ticketNumber.Text = "An invalid ticket number has been added. Please try again.";
                Response.Redirect("https://localhost:44373/ErrorPage.aspx");

            }
            */
            // check ticket
            parkingDB.ParkingDBWSSoapClient obj = new parkingDB.ParkingDBWSSoapClient();
            string ticketid = TextBox1.Text;
            bool check = obj.checkTicket(ticketid);
            if (check)
            {
                bool userCheck = obj.checkUser(ticketid);
                if (userCheck)
                {
                    ticketNumber.Text = "This is a user ticket ID, please Log in";
                }
                else
                    Response.Redirect("https://localhost:44373/HomePage.aspx?ticketid=" + ticketid);
            }
            else
            {
                ticketNumber.Text = "An invalid ticket number has been added. Please try again.";
            }


        }

        protected void homeLoginButton_Click(object sender, EventArgs e)
        {
            Response.Redirect("https://localhost:44373/PopLogin.aspx");
        }

        protected void homeSignupButton_Click(object sender, EventArgs e)
        {
            Response.Redirect("https://localhost:44373/SignupPage.aspx");
        }

        /*
        protected void userLogin_Authenticate(object sender, AuthenticateEventArgs e)
        {
            if (checkCredentials(userLogin.UserName, userLogin.Password))
            {
                Response.Redirect("https://localhost:44373/HomePage.aspx");
            } 
            else
            {
                Response.Redirect("https://localhost:44373/ErrorPage.aspx");
            }
        }
        */
        private bool checkCredentials(String username, String password)
        {
            
            HttpWebRequest credentials = (HttpWebRequest)WebRequest.Create("http://localhost:8080/ParkingPalsServer/getUserInofrmation/checkCredentials/" + username + "," + password);
            credentials.Method = "GET";
            credentials.ContentLength = 0;
            credentials.ContentType = "text/html";
            credentials.Accept = "text/html";

            credentials.Headers.Add("username", username);
            credentials.Headers.Add("password", password);



            
            bool temp =  bool.Parse(credentials.GetResponse().Headers["valid"]);

            //String ticket = serviceResponse.GetResponseHeader("ticketNumber");
            return temp;
            
            /*
            String cCheck = credentials.GetResponse().Headers["valid"];
            if(string.Equals(cCheck, "true"))
            {
                return true;
            } 
            else
            {
                return false;
            }
            */
        }
    }
}