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

@Path("/State")
public class State {

    // api key defined here
    String key_collectapi = "apikey 1zorWuv54N5q9OTrwuOpsc:4q5KRx9FzotEGEnpBJJyUh";
    String key_mygasfeedapi = "3a9afokhzz";
    String key_tomtom =  "iuL58osMVRnaKp0BQFKgGqXovClzzY0x";
    String key_LPR =  "sk_ae28c4b6e230e1f0adeb6b18";

    static String key_zipcodeapi = "1orHeXcX56LalxxjpYMSoqjB7prnVKCW0FI2JBk8ky7KEcDwQU10niUJ3kSOKrl4";


    /**
     * get state name from zipcode
     * @return state
     */
    @GET
    public static String getState(){
        String myzip = Zip.getZip();
        Client client = ClientBuilder.newClient();
        WebTarget myResource = client.target("https://www.zipcodeapi.com/rest/"+key_zipcodeapi+"/info.json/"+myzip+"/degrees/");
        Response res = myResource.request().get();
        JsonObject value = res.readEntity(JsonObject.class);
        // get city
        String state = value.getString("state");

        return state;
    }

    @GET
    @Path("/Response")
    public static Response getStateResponse(){
        String state = getState();
        return Response.status(Response.Status.OK)
                .header("status", "Successful")
                .header("state", state)
                .build();

    }


}
