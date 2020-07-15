using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.Services;

namespace ParkingPalDBWS
{
    /// <summary>
    /// ParkingDBWS 的摘要说明
    /// </summary>
    [WebService(Namespace = "http://tempuri.org/")]
    [WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
    [System.ComponentModel.ToolboxItem(false)]
    // 若要允许使用 ASP.NET AJAX 从脚本中调用此 Web 服务，请取消注释以下行。 
    // [System.Web.Script.Services.ScriptService]
    public class ParkingDBWS : System.Web.Services.WebService
    {

        [WebMethod]
        public string HelloWorld()
        {
            return "Hello World";
        }

        [WebMethod]
        public bool PostUser(string username, string firstname, string lastname, string email, string phonenumber, string password, string accounttype)
        {
            // connect with database
            String connStr = "Data Source=(LocalDB)\\MSSQLLocalDB;AttachDbFilename=|DataDirectory|ParkingPalConnection.mdf;Integrated Security = True";
            SqlConnection conn = new SqlConnection(connStr);
            SqlCommand numberCommand = new SqlCommand("Select * from managementDB where parkingStructureID=1", conn);
            SqlCommand insertcommand = new SqlCommand("INSERT INTO userProfile (userID, username, password, firstname, lastname, email, phoneNumber, accountType) " +
                "VALUES(@id, @username, @password, @firstname, @lastname, @email, @phonenumber, @accountType); ", conn);
            SqlCommand insertTicket = new SqlCommand("INSERT INTO ticketDB (ticketID) " +
                "VALUES(@ticketid); ", conn);
            conn.Open();
            int number = 0;
            int premium = 0;
            int standard = 0;
            int free = 0;
            using (SqlDataReader reader = numberCommand.ExecuteReader())
            {
                while (reader.Read())
                {
                    // add information to int
                    premium = reader.GetInt32(2);
                    standard = reader.GetInt32(3);
                    free = reader.GetInt32(4);
                    number = premium + standard + free;
                }
            }
            insertcommand.Parameters.AddWithValue("@id", number + 1);
            insertcommand.Parameters.AddWithValue("@username", username);
            insertcommand.Parameters.AddWithValue("@password", password);
            insertcommand.Parameters.AddWithValue("@firstname", firstname);
            insertcommand.Parameters.AddWithValue("@lastname", lastname);
            insertcommand.Parameters.AddWithValue("@email", email);
            insertcommand.Parameters.AddWithValue("@phonenumber", phonenumber);
            insertcommand.Parameters.AddWithValue("@accountType", accounttype);
            insertTicket.Parameters.AddWithValue("@ticketID", number + 1);
            insertTicket.ExecuteNonQuery();
            insertcommand.ExecuteNonQuery();


            if (string.Equals(accounttype, "Premium"))
            {
                SqlCommand updatetotal = new SqlCommand("UPDATE managementDB SET numPremium = @number WHERE parkingStructureID = 1;", conn);
                updatetotal.Parameters.AddWithValue("@number", premium + 1);
                updatetotal.ExecuteNonQuery();
            }
            else if (string.Equals(accounttype, "Standard"))
            {
                SqlCommand updatetotal = new SqlCommand("UPDATE managementDB SET numStandard = @number WHERE parkingStructureID = 1;", conn);
                updatetotal.Parameters.AddWithValue("@number", standard + 1);
                updatetotal.ExecuteNonQuery();
            }
            else
            {
                SqlCommand updatetotal = new SqlCommand("UPDATE managementDB SET numFree = @number WHERE parkingStructureID = 1;", conn);
                updatetotal.Parameters.AddWithValue("@number", free + 1);
                updatetotal.ExecuteNonQuery();
            }
            conn.Close();
            return true;


        }
        [WebMethod]
        public bool PutUser(string username, string email, string password, string phonenumber)
        {
            // connect with the database
            String connStr = "Data Source=(LocalDB)\\MSSQLLocalDB;AttachDbFilename=|DataDirectory|ParkingPalConnection.mdf;Integrated Security = True";
            SqlConnection conn = new SqlConnection(connStr);

            conn.Open();
            if (!string.Equals(email, ""))
            {
                SqlCommand updatecommand = new SqlCommand("UPDATE userProfile SET email = @email WHERE username = @username;", conn);
                updatecommand.Parameters.AddWithValue("@email", email);
                updatecommand.Parameters.AddWithValue("@username", username);

                updatecommand.ExecuteNonQuery();
            }
            if (!string.Equals(phonenumber, ""))
            {
                SqlCommand updatecommand = new SqlCommand("UPDATE userProfile SET phonenumber = @phonenumber WHERE username = @username;", conn);
                updatecommand.Parameters.AddWithValue("@phonenumber", phonenumber);
                updatecommand.Parameters.AddWithValue("@username", username);

                updatecommand.ExecuteNonQuery();
            }
            if (!string.Equals(password, ""))
            {
                SqlCommand updatecommand = new SqlCommand("UPDATE userProfile SET password = @password WHERE username = @username;", conn);
                updatecommand.Parameters.AddWithValue("@password", password);
                updatecommand.Parameters.AddWithValue("@username", username);

                updatecommand.ExecuteNonQuery();
            }
            conn.Close();


            return true;

        }
        [WebMethod]
        public string GetUsername(string username)
        {
            String connStr = "Data Source=(LocalDB)\\MSSQLLocalDB;AttachDbFilename=|DataDirectory|ParkingPalConnection.mdf;Integrated Security = True";
            SqlConnection conn = new SqlConnection(connStr);
            SqlCommand command = new SqlCommand("Select * from userProfile where username=@id", conn);
            command.Parameters.AddWithValue("@id", username);
            conn.Open();
            using (SqlDataReader reader = command.ExecuteReader())
            {
                if (reader.HasRows)
                {
                    if (reader.Read())
                    {
                        // add information to string and return
                        string res = reader.GetString(1);
                        conn.Close();
                        return res;
                    }
                }
            }
            return "Error";
        }

        [WebMethod]
        public string GetUserID(string username)
        {
            String connStr = "Data Source=(LocalDB)\\MSSQLLocalDB;AttachDbFilename=|DataDirectory|ParkingPalConnection.mdf;Integrated Security = True";
            SqlConnection conn = new SqlConnection(connStr);
            SqlCommand command = new SqlCommand("Select * from userProfile where username=@id", conn);
            command.Parameters.AddWithValue("@id", username);
            conn.Open();
            using (SqlDataReader reader = command.ExecuteReader())
            {
                if (reader.HasRows)
                {
                    if (reader.Read())
                    {
                        // add information to string and return
                        string res = reader.GetInt32(0).ToString();
                        reader.GetString(1);
                        return res;
                    }
                }
            }
            return "Error";
        }

        [WebMethod]
        public string GetEmail(string username)
        {
            String connStr = "Data Source=(LocalDB)\\MSSQLLocalDB;AttachDbFilename=|DataDirectory|ParkingPalConnection.mdf;Integrated Security = True";
            SqlConnection conn = new SqlConnection(connStr);
            SqlCommand command = new SqlCommand("Select * from userProfile where username=@id", conn);
            command.Parameters.AddWithValue("@id", username);
            conn.Open();
            using (SqlDataReader reader = command.ExecuteReader())
            {
                if (reader.HasRows)
                {
                    if (reader.Read())
                    {
                        // add information to string and return
                        string res = reader.GetString(5);
                        return res;
                    }
                }
            }
            return "Error";
        }

        [WebMethod]
        public string GetPhonenumber(string username)
        {
            String connStr = "Data Source=(LocalDB)\\MSSQLLocalDB;AttachDbFilename=|DataDirectory|ParkingPalConnection.mdf;Integrated Security = True";
            SqlConnection conn = new SqlConnection(connStr);
            SqlCommand command = new SqlCommand("Select * from userProfile where username=@id", conn);
            command.Parameters.AddWithValue("@id", username);
            conn.Open();
            using (SqlDataReader reader = command.ExecuteReader())
            {
                if (reader.Read())
                {
                    // add information to string and return

                    return reader.GetString(6);
                }
            }
            return "Error";
        }

        [WebMethod]
        public string GetAccountType(string username)
        {
            String connStr = "Data Source=(LocalDB)\\MSSQLLocalDB;AttachDbFilename=|DataDirectory|ParkingPalConnection.mdf;Integrated Security = True";
            SqlConnection conn = new SqlConnection(connStr);
            SqlCommand command = new SqlCommand("Select * from userProfile where username=@id", conn);
            command.Parameters.AddWithValue("@id", username);
            conn.Open();
            using (SqlDataReader reader = command.ExecuteReader())
            {
                if (reader.Read())
                {
                    // add information to string and return

                    return reader.GetString(7);
                }
            }
            return "Error";
        }

        [WebMethod]
        public bool checkTicket(string ticketid)
        {
            String connStr = "Data Source=(LocalDB)\\MSSQLLocalDB;AttachDbFilename=|DataDirectory|ParkingPalConnection.mdf;Integrated Security = True";
            SqlConnection conn = new SqlConnection(connStr);
            SqlCommand command = new SqlCommand("Select * from ticketDB where ticketID=@id", conn);
            command.Parameters.AddWithValue("@id", ticketid);
            conn.Open();
            using (SqlDataReader reader = command.ExecuteReader())
            {
                if (reader.Read())
                {


                    return true;
                }
            }
            return false;
        }

        [WebMethod]
        public string GetParkingNumber(string id)
        {
            String connStr = "Data Source=(LocalDB)\\MSSQLLocalDB;AttachDbFilename=|DataDirectory|ParkingPalConnection.mdf;Integrated Security = True";
            SqlConnection conn = new SqlConnection(connStr);
            SqlCommand command = new SqlCommand("Select * from ticketDB where ticketID=@id", conn);
            command.Parameters.AddWithValue("@id", id);
            conn.Open();
            string parkingNumber = "Not parking";
            using (SqlDataReader reader = command.ExecuteReader())
            {
                if (reader.HasRows)
                {
                    if (reader.Read())
                    {
                        if (!reader.IsDBNull(1))
                            parkingNumber = reader.GetInt32(1).ToString();
                        return parkingNumber;
                    }
                }
            }
            return "Error";
        }

        [WebMethod]
        public string GetReservationNumber(string id)
        {
            String connStr = "Data Source=(LocalDB)\\MSSQLLocalDB;AttachDbFilename=|DataDirectory|ParkingPalConnection.mdf;Integrated Security = True";
            SqlConnection conn = new SqlConnection(connStr);
            SqlCommand command = new SqlCommand("Select * from reservationDB where userid=@id", conn);
            command.Parameters.AddWithValue("@id", id);
            conn.Open();
            string reseravationNumber = "Not Reservation";
            using (SqlDataReader reader = command.ExecuteReader())
            {
                if (reader.HasRows)
                {
                    if (reader.Read())
                    {
                        reseravationNumber = reader.GetInt32(1).ToString();
                        return reseravationNumber;
                    }
                }
                else
                {
                    return reseravationNumber;
                }
            }
            return "Error";
        }

        [WebMethod]
        public string GetReservationTime(string id)
        {
            String connStr = "Data Source=(LocalDB)\\MSSQLLocalDB;AttachDbFilename=|DataDirectory|ParkingPalConnection.mdf;Integrated Security = True";
            SqlConnection conn = new SqlConnection(connStr);
            SqlCommand command = new SqlCommand("Select * from reservationDB where userid=@id", conn);
            command.Parameters.AddWithValue("@id", id);
            conn.Open();
            /*
            string reservationTime = ((DateTime)command.ExecuteScalar()).ToString("hh: mm:ss.fff");
            if (reservationTime == null)
              return "Not Reservation";
            
            else
            {
                return reservationTime;
            }
            */

            string reservationTime = "Not Parking";
            using (SqlDataReader reader = command.ExecuteReader())
            {
                if (reader.HasRows)
                {
                    if (reader.Read())
                    {
                        reservationTime = reader.GetDateTime(3).ToString("yyyy-MM-dd HH:mm:ss.FF"); ;
                        return reservationTime;
                    }
                }
                else
                {
                    return reservationTime;
                }
            }
            return "Error";

        }

        [WebMethod]
        public string GetParkedTime(string id)
        {
            String connStr = "Data Source=(LocalDB)\\MSSQLLocalDB;AttachDbFilename=|DataDirectory|ParkingPalConnection.mdf;Integrated Security = True";
            SqlConnection conn = new SqlConnection(connStr);
            SqlCommand command = new SqlCommand("Select * from ticketDB where ticketID=@id", conn);
            command.Parameters.AddWithValue("@id", id);
            conn.Open();
            using (SqlDataReader reader = command.ExecuteReader())
            {
                if (reader.HasRows)
                {
                    if (reader.Read())
                    {
                        if (reader.IsDBNull(3))
                        {
                            return "Not Parking";
                        }
                        DateTime startTime = reader.GetDateTime(3);
                        //DateTime endTime = reader.GetDateTime(4);
                        if (reader.IsDBNull(4))
                        {

                            return DateTime.Now.Subtract(startTime).ToString(@"dd\.hh\:mm\:ss");
                        }
                        else
                        {
                            return reader.GetDateTime(4).Subtract(startTime).ToString(@"dd\.hh\:mm\:ss");
                        }

                    }
                }
                else
                {
                    return "Not Parking";
                }
            }
            return "Error";

        }
        [WebMethod]
        public bool checkUser(string userid)
        {
            String connStr = "Data Source=(LocalDB)\\MSSQLLocalDB;AttachDbFilename=|DataDirectory|ParkingPalConnection.mdf;Integrated Security = True";
            SqlConnection conn = new SqlConnection(connStr);
            SqlCommand command = new SqlCommand("Select * from userProfile where userID=@id", conn);
            command.Parameters.AddWithValue("@id", userid);
            conn.Open();
            using (SqlDataReader reader = command.ExecuteReader())
            {
                if (reader.HasRows)
                {
                    if (reader.Read())
                    {
                        return true;
                    }
                }
            }
            return false;
        }

        [WebMethod]
        public bool checkSpotEmpty(string spotNumber)
        {
            String connStr = "Data Source=(LocalDB)\\MSSQLLocalDB;AttachDbFilename=|DataDirectory|ParkingPalConnection.mdf;Integrated Security = True";
            SqlConnection conn = new SqlConnection(connStr);
            SqlCommand command = new SqlCommand("Select * from reservation where spotNumber=@spot", conn);
            command.Parameters.AddWithValue("@spot", spotNumber);
            conn.Open();
            using (SqlDataReader reader = command.ExecuteReader())
            {
                if (reader.HasRows)
                {
                    return false;
                }
                else return true;
            }
        }

        [WebMethod]
        public bool PutReservation(string username, string spotNumber)
        {
            bool empty = checkSpotEmpty(spotNumber);
            if (!empty)
                return false;
            String connStr = "Data Source=(LocalDB)\\MSSQLLocalDB;AttachDbFilename=|DataDirectory|ParkingPalConnection.mdf;Integrated Security = True";
            SqlConnection conn = new SqlConnection(connStr);
            SqlCommand command = new SqlCommand("Select * from userProfile where username=@username", conn);
            command.Parameters.AddWithValue("@username", username);
            conn.Open();
            string reservationInformation = null;
            using (SqlDataReader reader = command.ExecuteReader())
            {
                if (reader.HasRows)
                {
                    if (reader.Read())
                    {
                        reservationInformation = reader.GetString(9);

                    }
                }
            }
            if (reservationInformation == null)
            {
                SqlCommand insertcommand = new SqlCommand("INSERT INTO reservationDB (reservationID, spotNumber, userID) " +
                "VALUES(@reservationid, @spotNumber, @userId); ", conn);
                insertcommand.Parameters.AddWithValue("@reservationid", GetUserID(username));
                insertcommand.Parameters.AddWithValue("@spotNumber", spotNumber);
                insertcommand.Parameters.AddWithValue("@username", GetUserID(username));
                insertcommand.ExecuteNonQuery();
            }
            else
            {
                SqlCommand updatecommand = new SqlCommand("UPDATE reservationDB SET spotNumber = @spot WHERE reservationID = @reservationinfo;", conn);
                updatecommand.Parameters.AddWithValue("@spot", spotNumber);
                updatecommand.Parameters.AddWithValue("@reservationinfo", reservationInformation);
                updatecommand.ExecuteNonQuery();

            }

            return true;
        }

        [WebMethod]
        public bool PutDecreaseSpot()
        {
            String connStr = "Data Source=(LocalDB)\\MSSQLLocalDB;AttachDbFilename=|DataDirectory|ParkingPalConnection.mdf;Integrated Security = True";
            SqlConnection conn = new SqlConnection(connStr);
            SqlCommand numberCommand = new SqlCommand("Select * from garageDB WHERE garageID=1", conn);
            conn.Open();
            int number = 0;
            using (SqlDataReader reader = numberCommand.ExecuteReader())
            {
                while (reader.Read())
                {
                    // add information to int
                    number = reader.GetInt32(1);
                }
            }
            SqlCommand updatecommand = new SqlCommand("UPDATE garageDB SET numEmptySpot = @spot WHERE garageID=1;", conn);
            updatecommand.Parameters.AddWithValue("@spot", number - 1);
            return true;
        }

        [WebMethod]
        public bool PutIncreaseSpot()
        {
            String connStr = "Data Source=(LocalDB)\\MSSQLLocalDB;AttachDbFilename=|DataDirectory|ParkingPalConnection.mdf;Integrated Security = True";
            SqlConnection conn = new SqlConnection(connStr);
            SqlCommand numberCommand = new SqlCommand("Select * from garageDB WHERE garageID=1", conn);
            conn.Open();
            int number = 0;
            using (SqlDataReader reader = numberCommand.ExecuteReader())
            {
                while (reader.Read())
                {
                    // add information to int
                    number = reader.GetInt32(1);
                }
            }
            SqlCommand updatecommand = new SqlCommand("UPDATE garageDB SET numEmptySpot = @spot WHERE garageID=1;", conn);
            updatecommand.Parameters.AddWithValue("@spot", number + 1);
            return true;
        }

        [WebMethod]
        public void DeleteAccount(string id)
        {
            String connStr = "Data Source=(LocalDB)\\MSSQLLocalDB;AttachDbFilename=|DataDirectory|ParkingPalConnection.mdf;Integrated Security = True";
            SqlConnection conn = new SqlConnection(connStr);
            conn.Open();
            /*
            SqlCommand typeCommand = new SqlCommand("Select * from userProfile WHERE userid=@id", conn);
            string accounttype = "";
            using (SqlDataReader reader = typeCommand.ExecuteReader())
            {
                if (reader.Read())
                {
                    // add information to int
                    accounttype = reader.GetString(7);
                 
                }
                else
                {
                    return;
                }
            }

            SqlCommand numberCommand = new SqlCommand("Select * from managementDB where parkingStructureID=1", conn);
            int premium = 0;
            int standard = 0;
            int free = 0;
            using (SqlDataReader reader = numberCommand.ExecuteReader())
            {
                while (reader.Read())
                {
                    // add information to int
                    premium = reader.GetInt32(2);
                    standard = reader.GetInt32(3);
                    free = reader.GetInt32(4);
                }
            }
            if (string.Equals(accounttype, "Premium"))
            {
                SqlCommand updatetotal = new SqlCommand("UPDATE managementDB SET numPremium = @number WHERE parkingStructureID = 1;", conn);
                updatetotal.Parameters.AddWithValue("@number", premium - 1);
                updatetotal.ExecuteNonQuery();
            }
            else if (string.Equals(accounttype, "Standard"))
            {
                SqlCommand updatetotal = new SqlCommand("UPDATE managementDB SET numStandard = @number WHERE parkingStructureID = 1;", conn);
                updatetotal.Parameters.AddWithValue("@number", standard - 1);
                updatetotal.ExecuteNonQuery();
            }
            else
            {
                SqlCommand updatetotal = new SqlCommand("UPDATE managementDB SET numFree = @number WHERE parkingStructureID = 1;", conn);
                updatetotal.Parameters.AddWithValue("@number", free - 1);
                updatetotal.ExecuteNonQuery();
            }
            */

            SqlCommand useridCommand = new SqlCommand("Delete from userProfile WHERE userid=@id", conn);
            SqlCommand ticketidCommand = new SqlCommand("Delete from ticketDB WHERE ticketID=@id", conn);

            useridCommand.Parameters.AddWithValue("@id", id);
            ticketidCommand.Parameters.AddWithValue("@id", id);

            useridCommand.ExecuteNonQuery();
            ticketidCommand.ExecuteNonQuery();

        }
        [WebMethod]
        public string GetCost(string id)
        {

            String connStr = "Data Source=(LocalDB)\\MSSQLLocalDB;AttachDbFilename=|DataDirectory|ParkingPalConnection.mdf;Integrated Security = True";
            SqlConnection conn = new SqlConnection(connStr);
            SqlCommand numberCommand = new SqlCommand("Select * from garageDB WHERE garageID=1", conn);
            conn.Open();
            string parkedtime = GetParkedTime(id);
            if (string.Equals(parkedtime, "Not Parking"))
            {
                return "0";
            }
            int dot = parkedtime.IndexOf(".");
            string parkeddays = parkedtime.Substring(0, dot);
            int day = 0;
            if (parkeddays[0] == '0')
                day = Int32.Parse(parkeddays[1].ToString());
            else
                day = Int32.Parse(parkeddays);
            string parkedhours = parkedtime.Substring(dot + 1, dot + 3);
            int hour = 0;
            if (parkedhours[0] == '0')
                hour = Int32.Parse(parkedhours[1].ToString()) + 1 + day * 24;
            
            else
                hour = Int32.Parse(parkedhours) + 1 + day * 24;


            using (SqlDataReader reader = numberCommand.ExecuteReader())
            {
                if (reader.Read())
                {
                    // add information to int
                    int price = reader.GetInt32(2);
                    return (price * hour).ToString();
                }
                else
                {
                    return "No fee.";
                }
            }
        }
        [WebMethod]
        public string GetEmptySpots()
        {
            String connStr = "Data Source=(LocalDB)\\MSSQLLocalDB;AttachDbFilename=|DataDirectory|ParkingPalConnection.mdf;Integrated Security = True";
            SqlConnection conn = new SqlConnection(connStr);
            SqlCommand numberCommand = new SqlCommand("Select * from garageDB WHERE garageID=1", conn);
            conn.Open();


            using (SqlDataReader reader = numberCommand.ExecuteReader())
            {
                if (reader.Read())
                {
                    // add information to int
                    int number = reader.GetInt32(1);
                    return number.ToString();
                }
                else
                {
                    return "Not on Service";
                }
            }
        }





    }
}

