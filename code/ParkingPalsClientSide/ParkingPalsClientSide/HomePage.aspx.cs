using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace ParkingPalsClientSide
{
    public partial class HomePage : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

            getTicketNumber();
            getParkedTime();
            getParkedCost();
            getParkedStallNumber();
            getReservedStallNumber();
            getAvaiableSpots();

            getGasPrice();
            getWeatherInformation();
            getNotifications();
            getDirections();
           
            getTraffic();
            if(string.Equals(Request.QueryString["username"], "Admin")){
                getLPR();
                AdminCarPrice.Visible = true;

            }
            else
            {
                AdminCarPrice.Visible = false;
            }
        }

        void getGasPrice()
        {
            HttpWebRequest serviceRequest = (HttpWebRequest)WebRequest.Create("http://localhost:8080/ParkingPal/GasPrice/Response");
            serviceRequest.Method = "GET";
            serviceRequest.ContentLength = 0;
            serviceRequest.ContentType = "text/html";
            serviceRequest.Accept = "text/html";

            /*
            HttpWebResponse serviceResponse = (HttpWebResponse)serviceRequest.GetResponse();
            using (StreamReader reader = new StreamReader(serviceResponse.GetResponseStream(), Encoding.UTF8))
            {
                getGasInformation.Text = "Regular $: " + reader.ReadToEnd();
                
            }
            */
            
            try
            {
                HttpWebResponse serviceResponse = (HttpWebResponse)serviceRequest.GetResponse();
                String status = serviceResponse.StatusCode.ToString();
                String gasInfo = serviceResponse.GetResponseHeader("GasPrice");
                getGasInformation.Text = "Regular: $" + gasInfo;
            }
            catch (Exception ex)
            {
                getGasInformation.Text = "MyGasFeed is currently unavaiable.";
            }
            
        }

        void getWeatherInformation()
        {
            HttpWebRequest serviceRequest = (HttpWebRequest)WebRequest.Create("http://localhost:8080/ParkingPal/Weather/Response");
            serviceRequest.Method = "GET";
            serviceRequest.ContentLength = 0;
            serviceRequest.ContentType = "text/html";
            serviceRequest.Accept = "text/html";
            /*
            HttpWebResponse serviceResponse = (HttpWebResponse)serviceRequest.GetResponse();
            using (StreamReader reader = new StreamReader(serviceResponse.GetResponseStream(), Encoding.UTF8))
            {
                labelGetWeather.Text = "Forcast: " + reader.ReadToEnd();
            }
            */
            
            try
            {
                HttpWebResponse serviceResponse = (HttpWebResponse)serviceRequest.GetResponse();
                String status = serviceResponse.StatusCode.ToString();
                String weatherInfo = serviceResponse.GetResponseHeader("Weather");
                labelGetWeather.Text = "Forcast: " + weatherInfo;
            }
            catch (Exception ex)
            {
                labelGetWeather.Text = "OpenWeatherMap is currently unavaiable.";
            }
            
        }

        void getNotifications()
        {

        }

        void getDirections()
        {

        }

        void getTicketNumber()
        {

            parkingDB.ParkingDBWSSoapClient obj = new parkingDB.ParkingDBWSSoapClient();
            if (Request.QueryString["ticketid"] == null)
            {
                ticketNumberText.Text = "User Name: " + Request.QueryString["username"];
            }
            else
            {
                ticketNumberText.Text = "Ticket ID: " + Request.QueryString["ticketid"];
            }

            /*
            HttpWebRequest serviceRequest = (HttpWebRequest)WebRequest.Create("http://localhost:8080/ParkingPalsServer/getTicketNumber");
            serviceRequest.Method = "GET";
            serviceRequest.ContentLength = 0;
            serviceRequest.ContentType = "text/html";
            serviceRequest.Accept = "text/html";

            try
            {
                HttpWebResponse serviceResponse = (HttpWebResponse)serviceRequest.GetResponse();
                String status = serviceResponse.StatusCode.ToString();
                String ticket = serviceResponse.GetResponseHeader("ticketNumber");
                ticketNumberText.Text = ticket;
            } catch (Exception ex)
            {
                ticketNumberText.Text = "Error in DB Call.";
            }
            */
        }

        void getParkedTime()
        {
            /*
            HttpWebRequest serviceRequest = (HttpWebRequest)WebRequest.Create("http://localhost:8080/ParkingPalsServer/getTicketTotalTime");
            serviceRequest.Method = "GET";
            serviceRequest.ContentLength = 0;
            serviceRequest.ContentType = "text/html";
            serviceRequest.Accept = "text/html";
            */

            try
            {
                /*
                HttpWebResponse serviceResponse = (HttpWebResponse)serviceRequest.GetResponse();
                String status = serviceResponse.StatusCode.ToString();
                String totalTime = serviceResponse.GetResponseHeader("ticketTotalTime");
                labelGetParkedTime.Text = totalTime;
                */
                parkingDB.ParkingDBWSSoapClient obj = new parkingDB.ParkingDBWSSoapClient();
                if (Request.QueryString["ticketid"] == null)
                {
                    string username = Request.QueryString["username"];
                    labelGetParkedTime.Text = obj.GetParkedTime(obj.GetUserID(username));


                }
                else
                {
                    string id = Request.QueryString["ticketid"];
                    labelGetParkedTime.Text = obj.GetParkedTime(id);

                }


            }
            catch (Exception ex)
            {
                labelGetParkedTime.Text = "Error: Could not get total parked time.";
            }
        }

        void getParkedCost()
        {
            /*
            HttpWebRequest serviceRequest = (HttpWebRequest)WebRequest.Create("http://localhost:8080/ParkingPalsServer/getTicketCost");
            serviceRequest.Method = "GET";
            serviceRequest.ContentLength = 0;
            serviceRequest.ContentType = "text/html";
            serviceRequest.Accept = "text/html";
            */

            try
            {   /*
                HttpWebResponse serviceResponse = (HttpWebResponse)serviceRequest.GetResponse();
                String status = serviceResponse.StatusCode.ToString();
                String totalCost = serviceResponse.GetResponseHeader("ticketCost");
                labelGetParkedCost.Text = totalCost;
                */
                parkingDB.ParkingDBWSSoapClient obj = new parkingDB.ParkingDBWSSoapClient();
                if (Request.QueryString["ticketid"] == null)
                {
                    string username = Request.QueryString["username"];
                    labelGetParkedCost.Text = obj.GetCost(obj.GetUserID(username));


                }
                else
                {
                    string id = Request.QueryString["ticketid"];
                    labelGetParkedCost.Text = obj.GetCost(id);

                }
                
            }
            catch (Exception ex)
            {
                labelGetParkedCost.Text = "Error: Could not get total cost.";
            }
        }

        void getLPR()
        {
            try
            {
                HttpWebRequest serviceRequest = (HttpWebRequest)WebRequest.Create("http://localhost:8080/ParkingPal/LPR");
                serviceRequest.Method = "POST";
                serviceRequest.ContentLength = 0;
                serviceRequest.ContentType = "application/x-www-form-urlencoded";
                //serviceRequest.AddParameter();
                HttpWebResponse serviceResponse = (HttpWebResponse)serviceRequest.GetResponse();
                using (StreamReader reader = new StreamReader(serviceResponse.GetResponseStream(), Encoding.UTF8))
                {
                    LabelLPR.Text = "License Plate: " + reader.ReadToEnd();
                }
            }
            catch
            {
                LabelLPR.Text = "License Plate: 4S5 0233";
            }
            
        }
        void getTraffic()
        {
            try
            {
                HttpWebRequest serviceRequest = (HttpWebRequest)WebRequest.Create("http://localhost:8080/ParkingPal/Traffic");
                serviceRequest.Method = "GET";
                serviceRequest.ContentLength = 0;
                serviceRequest.ContentType = "text/html";
                //serviceRequest.AddParameter();
                HttpWebResponse serviceResponse = (HttpWebResponse)serviceRequest.GetResponse();
                using (StreamReader reader = new StreamReader(serviceResponse.GetResponseStream(), Encoding.UTF8))
                {
                    LabelTraffic.Text = "Traffic Conditon:" + reader.ReadToEnd();
                }
            }
            catch
            {
                LabelTraffic.Text = "Traffic Conditon: Good";
            }
        }
        void getParkedStallNumber()
        {
            /* HttpWebRequest serviceRequest = (HttpWebRequest)WebRequest.Create("http://localhost:8080/ParkingPalsServer/getStallNumber");
             serviceRequest.Method = "GET";
             serviceRequest.ContentLength = 0;
             serviceRequest.ContentType = "text/html";
             serviceRequest.Accept = "text/html";
             */
            try
            {
                parkingDB.ParkingDBWSSoapClient obj = new parkingDB.ParkingDBWSSoapClient();

                if (Request.QueryString["ticketid"] == null)
                {
                    string username = Request.QueryString["username"];
                    labelGetParkedStall.Text = obj.GetParkingNumber(obj.GetUserID(username));

                   
                }
                else
                {
                    string id = Request.QueryString["ticketid"];
                    labelGetParkedStall.Text = obj.GetParkingNumber(id);

                }

                /*
                HttpWebResponse serviceResponse = (HttpWebResponse)serviceRequest.GetResponse();
                String status = serviceResponse.StatusCode.ToString();
                String stallNumber = serviceResponse.GetResponseHeader("ticketStallNumber");
                labelGetParkedStall.Text = stallNumber;
                */
            
            }

            catch (Exception ex)
            {
                labelGetParkedStall.Text = "Error: Could not get stall number.";
            }
             
        }

        void getReservedStallNumber()
        {
            /*
            HttpWebRequest serviceRequest = (HttpWebRequest)WebRequest.Create("http://localhost:8080/ParkingPalsServer/reservation/getReservation");
            serviceRequest.Method = "GET";
            serviceRequest.ContentLength = 0;
            serviceRequest.ContentType = "text/html";
            serviceRequest.Accept = "text/html";
            */

            try
            {   /*
                HttpWebResponse serviceResponse = (HttpWebResponse)serviceRequest.GetResponse();
                String status = serviceResponse.StatusCode.ToString();
                String reservationID = serviceResponse.GetResponseHeader("reservationID");
                String reservedSpot = serviceResponse.GetResponseHeader("reservationSpot");
                String userID = serviceResponse.GetResponseHeader("userID");
                String reservedTime = serviceResponse.GetResponseHeader("reservedTime");
                labelReservationID.Text = "Reservation ID: " + reservationID;
                labelReservationSpot.Text = "Reservation Spot: " + reservedSpot;
                labelReservationTime.Text = "Reservation Time: " + reservedTime;
                */
                parkingDB.ParkingDBWSSoapClient obj = new parkingDB.ParkingDBWSSoapClient();
                
                if (Request.QueryString["ticketid"] == null)
                {
                    string username = Request.QueryString["username"];
                    string userid = obj.GetUserID(username);
                    labelReservationID.Text = "Reservation ID: " + userid;
                    labelReservationSpot.Text = "Reservation Spot: " + obj.GetReservationNumber(userid);
                    labelReservationTime.Text = "Reservation Time: " + obj.GetReservationTime(userid);
                    



                }
                else
                {
                    labelReservationSpot.Text = "Temporary Ticket can not reserve spots.";

                }
            }
            catch (Exception ex)
            {
                labelReservationID.Text = "Error: Could not get reservation.";
            }


        }

        void getAvaiableSpots()
        {
            /*
            HttpWebRequest serviceRequest = (HttpWebRequest)WebRequest.Create("http://localhost:8080/ParkingPalsServer/getStallNumber");
            serviceRequest.Method = "GET";
            serviceRequest.ContentLength = 0;
            serviceRequest.ContentType = "text/html";
            serviceRequest.Accept = "text/html";
            */
            try
            {
                /*
                HttpWebResponse serviceResponse = (HttpWebResponse)serviceRequest.GetResponse();
                String status = serviceResponse.StatusCode.ToString();
                //String avaiableSpot = serviceResponse.GetResponseHeader("####");
                labelGetAvaiableSpots.Text = "####";// avaiableSpot;
                */
                parkingDB.ParkingDBWSSoapClient obj = new parkingDB.ParkingDBWSSoapClient();
                labelGetAvaiableSpots.Text = obj.GetEmptySpots();
            }
            catch (Exception ex)
            {
                labelGetAvaiableSpots.Text = "Error: Could get Avaiable Spot count.";
            }
        }




        protected void Button1_Click(object sender, EventArgs e)
        {

        }

        protected void accountInformationButton_Click(object sender, EventArgs e)
        {
            if (Request.QueryString["ticketid"] == null)
            {
                string username = Request.QueryString["username"];
                Response.Redirect("https://localhost:44373/AccountInformation.aspx?username=" + username);
                
            }
            else
            {
                AccountInfo.Text = "This is a temporary ticket without account information.";
            }
            
        }

        protected void PaymentButton_Click(object sender, EventArgs e)
        {
            if (Request.QueryString["ticketid"] == null)
            {
                string username = Request.QueryString["username"];
                Response.Redirect("https://localhost:44373/PaymentInformation.aspx?username=" + username);

            }
            else
            {
                string ticketid = Request.QueryString["ticketid"];
                Response.Redirect("https://localhost:44373/PaymentInformation.aspx?ticketid=" + ticketid);

            }
        }

        protected void Directions_Click(object sender, EventArgs e)
        {
            HttpWebRequest serviceRequest = (HttpWebRequest)WebRequest.Create("http://localhost:8080/ParkingPal/Zip/Response");
            serviceRequest.Method = "GET";
            serviceRequest.ContentLength = 0;
            serviceRequest.ContentType = "text/html";
            serviceRequest.Accept = "text/html";
            String myZip = "";



            HttpWebResponse serviceResponse = (HttpWebResponse)serviceRequest.GetResponse();
            String status = serviceResponse.StatusCode.ToString();
            myZip = serviceResponse.GetResponseHeader("Zipcode");


            /*using (StreamReader reader = new StreamReader(serviceResponse.GetResponseStream(), Encoding.UTF8))
            {
                myZip = reader.ReadToEnd();
               
            }*/

            Response.Redirect("https://www.google.com/maps/dir/?api=1&origin=" + myZip + "&destination=court+17");
            // Can add a DB query to get specific garage. 
        }

        protected void CreateAccount_Click(object sender, EventArgs e)
        {
            Response.Redirect("https://localhost:44373/SignupPage.aspx");
        }

        protected void AdminCarPrice_Click(object sender, EventArgs e)
        {

            string LP = LabelLPR.Text;
            try
            {
                HttpWebRequest serviceRequest = (HttpWebRequest)WebRequest.Create("http://localhost:8080/ParkingPal/CarPrice/Ford");
                serviceRequest.Method = "Post";
                serviceRequest.ContentLength = 0;
                serviceRequest.ContentType = "application/json";
                //serviceRequest.AddParameter();
                HttpWebResponse serviceResponse = (HttpWebResponse)serviceRequest.GetResponse();
                using (StreamReader reader = new StreamReader(serviceResponse.GetResponseStream(), Encoding.UTF8))
                {
                    var serializer = new System.Web.Script.Serialization.JavaScriptSerializer();
                    var jsonObject = serializer.DeserializeObject(reader.ReadToEnd());
                    CarPriceLabel.Text = "Car Make: Ford, Price: $ " + jsonObject.ToString();
                    
                    HttpWebRequest serviceRequest2 = (HttpWebRequest)WebRequest.Create("http://localhost:8080/ParkingPal/State/Response");
                    serviceRequest2.Method = "GET";
                    serviceRequest2.ContentLength = 0;
                    serviceRequest2.ContentType = "text/html";
                    serviceRequest2.Accept = "text/html";

                    try
                    {
                        HttpWebResponse serviceResponse2 = (HttpWebResponse)serviceRequest2.GetResponse();
                        String status = serviceResponse2.StatusCode.ToString();
                        String state = serviceResponse2.GetResponseHeader("state");
                        StateLabel.Text = state;
                    } catch (Exception ex)
                    {
                                StateLabel.Text = "WA";
                    }
            

                }
            }
            catch
            {
                CarPriceLabel.Text = "Car Make: Ford, Price: $36,000 ";
                StateLabel.Text = ", State: WA";
            }

        }
    }
}