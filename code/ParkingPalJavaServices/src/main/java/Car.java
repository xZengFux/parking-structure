import org.w3c.dom.*;

//import org.json.*;

import javax.json.*;
import javax.json.Json;
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

@Path("/CarPrice")
public class Car {
    /**
     * get car price depend on the car type
     * we can use CV tool to auto-detect cart type, then report car price to user
     * @param car
     * @return
     */
    @POST
    @Path("/{car}")
    @Produces("application/json")
    public static JsonObject getCarPrice(String car){
        String city = City.getCity();
        String state = State.getState();

        String price ="";

        if(city.equals("Seattle")&&state.equals("WA"))
            price = "36000";
        else
            price = "0";

        JsonObject json = Json.createObjectBuilder()
                .add("price", price)
                .build();

        return json;
    }
}
