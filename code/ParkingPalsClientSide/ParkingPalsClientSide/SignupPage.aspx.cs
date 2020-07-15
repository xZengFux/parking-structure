using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace ParkingPalsClientSide
{
    public partial class SignupPage : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            for (int i = 0; i < AccountList.Items.Count; i++)
            {
                parkingDB.ParkingDBWSSoapClient obj = new parkingDB.ParkingDBWSSoapClient();
                AccountList.Items[i].Attributes.Add("onclick", "MutExChkList(this)");
            }
        }

        protected void signupButton_Click(object sender, EventArgs e)
        {
            parkingDB.ParkingDBWSSoapClient obj = new parkingDB.ParkingDBWSSoapClient();
            obj.PostUser(UserLabel.Text, FirstnameLabel.Text, LastnameLabel.Text, EmailLabel.Text, PhoneLabel.Text, PasswordLabel.Text, AccountList.SelectedValue);
            Response.Redirect("https://localhost:44373/PopLogin.aspx");
        }
    }
}