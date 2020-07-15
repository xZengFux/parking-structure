using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace UpdateService.Controllers
{
    public class UpdateController : ApiController
    {
        public string GetGreeting()
        {
            return "Hello World Update";
        }


        [HttpPut]
        [Route("update/{username}/1/{email}")]
        public bool UpdateAccountEmail([FromUri]string username, [FromUri]string email)
        {

            String connStr = "Data Source=(LocalDB)\\MSSQLLocalDB;AttachDbFilename= C:\\Users\\Gavin\\Downloads\\559A_Final_Submission\\ParkingPalDBWS\\ParkingPalDBWS\\App_Data\\ParkingPalConnection.mdf ;Integrated Security = True";
            SqlConnection conn = new SqlConnection(connStr);
            conn.Open();

            SqlCommand updatecommand = new SqlCommand("UPDATE userProfile SET email = @email WHERE username = @username;", conn);
            updatecommand.Parameters.AddWithValue("@email", email);
            updatecommand.Parameters.AddWithValue("@username", username);

            try
            {
                updatecommand.ExecuteNonQuery();
                return true;
            }
            catch (Exception ex)
            {
                return false;
            }

        }

        [HttpPut]
        [Route("update/{username}/2/{password}")]
        public bool UpdateAccountPassword([FromUri]string username, [FromUri]string password)
        {

            String connStr = "Data Source=(LocalDB)\\MSSQLLocalDB;AttachDbFilename= C:\\Users\\Gavin\\Downloads\\559A_Final_Submission\\ParkingPalDBWS\\ParkingPalDBWS\\App_Data\\ParkingPalConnection.mdf ;Integrated Security = True";
            SqlConnection conn = new SqlConnection(connStr);
            conn.Open();
            SqlCommand updatecommand = new SqlCommand("UPDATE userProfile SET password = @password WHERE username = @username;", conn);
            updatecommand.Parameters.AddWithValue("@password", password);
            updatecommand.Parameters.AddWithValue("@username", username);

            try
            {
                updatecommand.ExecuteNonQuery();
                return true;
            }
            catch (Exception ex)
            {
                return false;
            }

        }

        [HttpPut]
        [Route("update/{username}/3/{phonenumber}")]
        public bool UpdateAccountPhonenumber([FromUri]string username, [FromUri]string phonenumber)
        {

            String connStr = "Data Source=(LocalDB)\\MSSQLLocalDB;AttachDbFilename= C:\\Users\\Gavin\\Downloads\\559A_Final_Submission\\ParkingPalDBWS\\ParkingPalDBWS\\App_Data\\ParkingPalConnection.mdf ;Integrated Security = True";
            SqlConnection conn = new SqlConnection(connStr);
            conn.Open();

            SqlCommand updatecommand = new SqlCommand("UPDATE userProfile SET phonenumber = @phonenumber WHERE username = @username;", conn);
            updatecommand.Parameters.AddWithValue("@phonenumber", phonenumber);
            updatecommand.Parameters.AddWithValue("@username", username);

            try
            {
                updatecommand.ExecuteNonQuery();
                return true;
            }
            catch (Exception ex)
            {
                return false;
            }
        }
    }
}
