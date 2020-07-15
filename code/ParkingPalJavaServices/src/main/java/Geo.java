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

@Path("/Geo")
public class Geo {

    // api key defined here
    String key_collectapi = "apikey 1zorWuv54N5q9OTrwuOpsc:4q5KRx9FzotEGEnpBJJyUh";
    String key_mygasfeedapi = "3a9afokhzz";
    String key_tomtom =  "iuL58osMVRnaKp0BQFKgGqXovClzzY0x";
    String key_LPR =  "sk_ae28c4b6e230e1f0adeb6b18";

    String key_zipcodeapi = "1orHeXcX56LalxxjpYMSoqjB7prnVKCW0FI2JBk8ky7KEcDwQU10niUJ3kSOKrl4";


    /**
     * get user geolocation with XML sharing data
     * @return lat,long
     */
    @GET
    @Path("/xml")
    @Produces("application/xml")
    public static Document getGeolocationXML(){
        String ip = IP.getIP();

        Client client = ClientBuilder.newClient();
        WebTarget myResource = client.target("http://ip-api.com/xml/"+ip);
        Response res = myResource.request().get();
        Document doc =  res.readEntity(Document.class);

        return doc;

    }

    /**
     * get location information from zipcode
     * @return res a xml which contains location information
     */
    @Path("/Location_xml")
    @GET
    @Produces("application/xml")
    public Response getLocation_xml(){
        String myzip = Zip.getZip();
        Client client = ClientBuilder.newClient();
        WebTarget myResource = client.target("https://www.zipcodeapi.com/rest/"+key_zipcodeapi+"/info.xml/"+myzip+"/degrees/");
        Response res = myResource.request().get();

        return res;
    }

    /**
     * get user geolocation
     * @return lat,long
     */
    @GET
    public static String getGeolocation(){
        String ip = IP.getIP();

        Client client = ClientBuilder.newClient();
        WebTarget myResource = client.target("http://ip-api.com/xml/"+ip);
        Response res = myResource.request().get();
        Document doc =  res.readEntity(Document.class);

        Element root = doc.getDocumentElement();

        String lat =  root.getElementsByTagName("lat").item(0).getTextContent();
        String lon =  root.getElementsByTagName("lon").item(0).getTextContent();


        return lat+" "+lon;

    }


}
