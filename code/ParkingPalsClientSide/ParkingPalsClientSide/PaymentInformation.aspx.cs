using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace ParkingPalsClientSide
{
    public partial class PaymentInformation : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void Paypal_Click(object sender, EventArgs e)
        {
            Response.Redirect("https://www.paypal.com");
        }

        protected void Apple_Click(object sender, EventArgs e)
        {
           
            Response.Redirect("https://www.apple.com/apple-pay/");
        }

        protected void Google_Click(object sender, EventArgs e)
        {
            Response.Redirect("https://pay.google.com/");
        }

        protected void Back_Click(object sender, EventArgs e)
        {
            if (Request.QueryString["ticketid"] == null)
            {
                string username = Request.QueryString["username"];
                Response.Redirect("https://localhost:44373/HomePage.aspx?username=" + username);

            }
            else
            {
                string ticketid = Request.QueryString["ticketid"];
                Response.Redirect("https://localhost:44373/HomePage.aspx?ticketid=" + ticketid);

            }
        }


    }
}