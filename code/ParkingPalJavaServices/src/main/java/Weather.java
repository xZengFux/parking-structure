import org.w3c.dom.*;

import javax.json.JsonArray;
import javax.json.JsonObject;
import javax.ws.rs.*;
import javax.ws.rs.Path;
import javax.ws.rs.client.Client;
import javax.ws.rs.client.ClientBuilder;
import javax.ws.rs.client.WebTarget;
import javax.ws.rs.core.MediaType;
import javax.ws.rs.core.Response;

import java.net.*;
import java.io.*;
import java.nio.file.*;
import java.util.Base64;

@Path("/Weather")
public class Weather {

    // api key defined here
    String key_collectapi = "apikey 1zorWuv54N5q9OTrwuOpsc:4q5KRx9FzotEGEnpBJJyUh";
    String key_mygasfeedapi = "3a9afokhzz";
    String key_tomtom =  "iuL58osMVRnaKp0BQFKgGqXovClzzY0x";
    String key_LPR =  "sk_ae28c4b6e230e1f0adeb6b18";

    static String key_zipcodeapi = "1orHeXcX56LalxxjpYMSoqjB7prnVKCW0FI2JBk8ky7KEcDwQU10niUJ3kSOKrl4";


    /**
     * get weather type
     * @return weather the weather type of local city, e.g. Fog
     */
    @GET
    @Produces("text/html")
    public String getWeather(){
        String weather = "";
        String myzip = Zip.getZip();

        Client client = ClientBuilder.newClient();

        try {
            WebTarget myResource = client.target("http://api.openweathermap.org/data/2.5/weather?zip=" + myzip + "&appid=3f5f6a2b55dd80bcb9cc9de668aab415&units=metric");
            Response res = myResource.request().get();
            JsonObject value = res.readEntity(JsonObject.class);
            // get weather
            JsonArray weatherInfo = value.getJsonArray("weather");
            // get weather type, e.g. Fog
            weather = weatherInfo.getJsonObject(0).get("main").toString();
        } catch (Exception e) {
            e.printStackTrace();
        }
        if (weather.equals("")) return "Cannot find weather in your location!";

        return weather.replace("\"","");
    }

    /**
     * return local weather type and reminder of road condiction
     * @return string reminder of road condiction
     */
    @Path("/Reminder")
    @GET
    @Produces("text/html")
    public String getWeatherReminder(){
        String weather = getWeather();
        if(weather.equals("Rain")||weather.equals("Fog")||weather.equals("Snow")) {
            return "It is " +weather+ ", please take care when you drive!";
        }else{
            return "It is " +weather+ ", enjoy your driving!";
        }
    }

    @GET
    @Path("/Response")
    public Response getGasPriceResponse(){
        String weather = getWeather();
        return Response.status(Response.Status.OK)
                .header("status", "Successful")
                .header("Weather", weather)
                .build();

    }

}
