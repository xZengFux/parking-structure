using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace ParkingPalsClientSide
{
    public partial class UpdateInformation : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            parkingDB.ParkingDBWSSoapClient obj = new parkingDB.ParkingDBWSSoapClient();
            userLabel.Text = obj.GetUsername(Request.QueryString["username"]) + ", Update User Information:";
        }

        protected void updateButton_Click(object sender, EventArgs e)
        {
            /*
           
            string user = obj1.GetUsername(Request.QueryString["username"]);
            string email = newEmailLabel.Text;
            string pass = newPasswordLabel.Text;
            string phone = newPhoneLabel.Text;
            if (!string.Equals(email, "")){
                Uri link = new Uri("https://localhost:44348/update/" + user + "/1/" + email);
                HttpWebRequest serviceRequest = (HttpWebRequest)WebRequest.Create(link) ;
                serviceRequest.Method = "PUT";
                serviceRequest.ContentType = "text/html";
                serviceRequest.ContentLength = 0;
                HttpWebResponse serviceResponse = (HttpWebResponse)serviceRequest.GetResponse();
            }
            if (!string.Equals(pass, "")){
                HttpWebRequest serviceRequest = (HttpWebRequest)WebRequest.Create("https://localhost:44348/update/" + user + "/2/" + pass);
                serviceRequest.Method = "PUT";
                serviceRequest.ContentType = "text/html";
                serviceRequest.ContentLength = 0;
                HttpWebResponse serviceResponse = (HttpWebResponse)serviceRequest.GetResponse();
            }

            if (!string.Equals(phone, "")){
                HttpWebRequest serviceRequest = (HttpWebRequest)WebRequest.Create("https://localhost:44348/update/" + user + "/3/" + phone);
                serviceRequest.Method = "PUT";
                serviceRequest.ContentType = "text/html";
                serviceRequest.ContentLength = 0;
                HttpWebResponse serviceResponse = (HttpWebResponse)serviceRequest.GetResponse();
            }
            */
            
            
            parkingDB.ParkingDBWSSoapClient obj1 = new parkingDB.ParkingDBWSSoapClient();
            obj1.PutUser(obj1.GetUsername(Request.QueryString["username"]), newEmailLabel.Text, newPasswordLabel.Text, newPhoneLabel.Text);
            
            Response.Redirect("https://localhost:44373/ParkingPalsPage.aspx");

        }
    }
}