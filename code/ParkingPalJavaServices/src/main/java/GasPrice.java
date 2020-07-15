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

@Path("/GasPrice")
public class GasPrice {

    // api key defined here
    String key_collectapi = "apikey 1zorWuv54N5q9OTrwuOpsc:4q5KRx9FzotEGEnpBJJyUh";
    static String key_mygasfeedapi = "3a9afokhzz";
    String key_tomtom =  "iuL58osMVRnaKp0BQFKgGqXovClzzY0x";
    String key_LPR =  "sk_ae28c4b6e230e1f0adeb6b18";

    static String key_zipcodeapi = "1orHeXcX56LalxxjpYMSoqjB7prnVKCW0FI2JBk8ky7KEcDwQU10niUJ3kSOKrl4";


    /**
     *
     * return lowest gas price to user
     * @return GasPrice local gas price
     */
    @GET
    @Produces("text/html")
    public static String getGasPrice(){
        String Price = "";

        // get geolocation
        String lat_lon = Geo.getGeolocation();
        String lat = lat_lon.split(" ")[0];
        String lon = lat_lon.split(" ")[1];

        // get client
        Client client = ClientBuilder.newClient();

        try {
            // get resource
            WebTarget myResource = client.target("http://api.mygasfeed.com/stations/radius/"+lat+"/"+lon+"/10/reg/Price/"+key_mygasfeedapi+".json");
            Response response = myResource.request().get();

            // return json
            JsonObject value = response.readEntity(JsonObject.class);
            // get stations
            JsonArray stations = value.getJsonArray("stations");

            // avoid the situation when Price is "N/A"
            for(int i=0;i<=stations.size();i++){
                Price = stations.getJsonObject(i).getString("reg_price");
                if (Price.equals("N/A")) continue;
                break;
            }
        } catch (Exception e) {
            e.printStackTrace();
        }
        // if no stations found
        if(Price.equals("")) return "There are no stations nearby!";

        return Price;
    }

    @GET
    @Path("/Response")
    public static Response getGasPriceResponse(){
        String price = getGasPrice();
        return Response.status(Response.Status.OK)
                .header("status", "Successful")
                .header("GasPrice", price)
                .build();

    }


}
