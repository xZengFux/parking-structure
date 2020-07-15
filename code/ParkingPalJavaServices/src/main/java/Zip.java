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

@Path("/Zip")
public class Zip {

    // api key defined here
    String key_collectapi = "apikey 1zorWuv54N5q9OTrwuOpsc:4q5KRx9FzotEGEnpBJJyUh";
    String key_mygasfeedapi = "3a9afokhzz";
    String key_tomtom =  "iuL58osMVRnaKp0BQFKgGqXovClzzY0x";
    String key_LPR =  "sk_ae28c4b6e230e1f0adeb6b18";

    String key_zipcodeapi = "1orHeXcX56LalxxjpYMSoqjB7prnVKCW0FI2JBk8ky7KEcDwQU10niUJ3kSOKrl4";


    /**
     * get local zipcode
     * @return zipcode
     */
    @GET
    @Produces("text/html")
    public static String getZip(){
        String myip = IP.getIP();
        Client client = ClientBuilder.newClient();
        WebTarget myResource = client.target("http://ip-api.com/json/"+myip);
        Response res = myResource.request().get();
        JsonObject value = res.readEntity(JsonObject.class);

        String zipcode = value.getString("zip");
        Response.status(200)
                .header("zipcode", zipcode)
                .build();

        return zipcode;
    }

    @GET
    @Path("/Response")
    public static Response getGasPriceResponse(){
        String zipcode = getZip();
        return Response.status(Response.Status.OK)
                .header("status", "Successful")
                .header("Zipcode", zipcode)
                .build();

    }

}
