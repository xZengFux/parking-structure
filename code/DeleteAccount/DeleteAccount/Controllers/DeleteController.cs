using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace DeleteAccount.Controllers
{
    public class DeleteController : ApiController
    {
        public string GetGreeting()
        {
            return "Hello World";
        }

        [HttpDelete]
        [Route("delete/{id}")]
        public string DeleteAccount(string id)
        {

            String connStr = "Data Source=(LocalDB)\\MSSQLLocalDB;AttachDbFilename= C:\\Users\\Gavin\\Downloads\\559A_Final_Submission\\ParkingPalDBWS\\ParkingPalDBWS\\App_Data\\ParkingPalConnection.mdf ;Integrated Security = True";
            SqlConnection conn = new SqlConnection(connStr);
            conn.Open();
            SqlCommand useridCommand = new SqlCommand("Delete from userProfile WHERE userid=@id", conn);
            SqlCommand ticketidCommand = new SqlCommand("Delete from ticketDB WHERE ticketID=@id", conn);

            useridCommand.Parameters.AddWithValue("@id", id);
            ticketidCommand.Parameters.AddWithValue("@id", id);

            useridCommand.ExecuteNonQuery();
            ticketidCommand.ExecuteNonQuery();
            conn.Close();
            return id;
        }
    }
}
