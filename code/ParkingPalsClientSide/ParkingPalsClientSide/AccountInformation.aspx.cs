using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace ParkingPalsClientSide
{
    public partial class AccountInformation : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            parkingDB.ParkingDBWSSoapClient obj = new parkingDB.ParkingDBWSSoapClient();
            userLabel.Text = obj.GetUsername(Request.QueryString["username"]);
            emailLabel.Text = obj.GetEmail(Request.QueryString["username"]);
            phoneLabel.Text = obj.GetPhonenumber(Request.QueryString["username"]);
            statusLabel.Text = obj.GetAccountType(Request.QueryString["username"]);

        }

        protected void UpdateButton_Click(object sender, EventArgs e)
        {
            Response.Redirect("https://localhost:44373/UpdateInformation.aspx?username="+ Request.QueryString["username"]) ;
        }

        protected void BackButton_Click(object sender, EventArgs e)
        {
            Response.Redirect("https://localhost:44373/HomePage.aspx?username=" + Request.QueryString["username"]); 
        }
        protected void DeleteButton_Click(object sender, EventArgs e)
        {
            if (deleteBox.Checked)
            {
                /*
                parkingDB.ParkingDBWSSoapClient obj = new parkingDB.ParkingDBWSSoapClient();
                string username = userLabel.Text;
                obj.DeleteAccount(obj.GetUserID(username));
                Response.Redirect("https://localhost:44373/ParkingPalsPage.aspx");
                */
                parkingDB.ParkingDBWSSoapClient obj = new parkingDB.ParkingDBWSSoapClient();
                string username = userLabel.Text;
                string id = obj.GetUserID(username);
                HttpWebRequest serviceRequest = (HttpWebRequest)WebRequest.Create("https://localhost:44382/delete/" + id );
                serviceRequest.Method = "DELETE";
                serviceRequest.ContentType = "text/html";


                HttpWebResponse serviceResponse = (HttpWebResponse)serviceRequest.GetResponse();
                String status = serviceResponse.StatusCode.ToString();
                Response.Redirect("https://localhost:44373/ParkingPalsPage.aspx");


            }
            else
            {
                deleteMessage.Text = "If you really want to delete this account, please check the box above.";
            }
            

        }

    }
}