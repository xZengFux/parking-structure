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

@Path("/Traffic")
public class Traffic {

    // api key defined here
    String key_collectapi = "apikey 1zorWuv54N5q9OTrwuOpsc:4q5KRx9FzotEGEnpBJJyUh";
    static String key_mygasfeedapi = "3a9afokhzz";
    static String key_tomtom =  "iuL58osMVRnaKp0BQFKgGqXovClzzY0x";
    String key_LPR =  "sk_ae28c4b6e230e1f0adeb6b18";

    static String key_zipcodeapi = "1orHeXcX56LalxxjpYMSoqjB7prnVKCW0FI2JBk8ky7KEcDwQU10niUJ3kSOKrl4";


    /**
     *
     * return traffic condiction to user
     * when current Travel Time is higher than free flow travel time, traffic condiction is considered bad
     * @return condiction
     */

    @GET
    @Produces("text/html")
    public String getTrafficCondiction() {
        String condiction = "";

        // get geolocation
        String lat_lon = Geo.getGeolocation();
        String lat = lat_lon.split(" ")[0];
        String lon = lat_lon.split(" ")[1];

        // get client
        Client client = ClientBuilder.newClient();


        try {
            // get resource

            WebTarget myResource = client.target("https://api.tomtom.com/traffic/services/4/flowSegmentData/absolute/10/json?point=" + lat + "%2C" + lon + "&unit=KMPH&key=" + key_tomtom);
            Response response = myResource.request().get();


            // return json
            JsonObject value = response.readEntity(JsonObject.class);
            // get flow data
            JsonObject flowSegmentData = value.getJsonObject("flowSegmentData");
            // get time
            int currentTravelTime = flowSegmentData.getInt("currentTravelTime");
            int freeFlowTravelTime = flowSegmentData.getInt("freeFlowTravelTime");

            if (currentTravelTime > freeFlowTravelTime) {
                condiction = "Bad!";
            } else condiction = "Good!";


        } catch (Exception e) {
            e.printStackTrace();
            return "Good";
        }

        return "Good";
    }

}
