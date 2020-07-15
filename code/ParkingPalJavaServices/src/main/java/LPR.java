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

@Path("/LPR")
public class LPR {

    // api key defined here
    String key_collectapi = "apikey 1zorWuv54N5q9OTrwuOpsc:4q5KRx9FzotEGEnpBJJyUh";
    static String key_mygasfeedapi = "3a9afokhzz";
    static String key_tomtom =  "iuL58osMVRnaKp0BQFKgGqXovClzzY0x";
    static String key_LPR =  "sk_ae28c4b6e230e1f0adeb6b18";

    static String key_zipcodeapi = "1orHeXcX56LalxxjpYMSoqjB7prnVKCW0FI2JBk8ky7KEcDwQU10niUJ3kSOKrl4";

    /**
     *
     * return license plate recognition result to user
     * http request content-type: "application/x-www-form-urlencoded"
     * @param image_path the path of image file "/Users/ianren/IdeaProjects/ParkingPal/test.jpg"
     * @return json_content result of license plate recognition
     */
    @POST
    @Produces("application/x-www-form-urlencoded")
    public String postLPR(@FormParam("image_path") String image_path){
        String json_content = "";

        try
        {
            String secret_key = key_LPR;

            // Read image file to byte array
            java.nio.file.Path path = Paths.get(image_path);
            byte[] data = Files.readAllBytes(path);

            // Encode file bytes to base64
            byte[] encoded = Base64.getEncoder().encode(data);

            // Setup the HTTPS connection to api.openalpr.com
            URL url = new URL("https://api.openalpr.com/v2/recognize_bytes?recognize_vehicle=1&country=us&secret_key=" + secret_key);
            URLConnection con = url.openConnection();
            HttpURLConnection http = (HttpURLConnection)con;
            http.setRequestMethod("POST"); // PUT is another valid option
            http.setFixedLengthStreamingMode(encoded.length);
            http.setDoOutput(true);

            // Send our Base64 content over the stream
            try(OutputStream os = http.getOutputStream()) {
                os.write(encoded);
            }

            int status_code = http.getResponseCode();
            if (status_code == 200)
            {
                // Read the response
                BufferedReader in = new BufferedReader(new InputStreamReader(
                        http.getInputStream()));
                //String json_content = "";
                String inputLine;
                while ((inputLine = in.readLine()) != null)
                    json_content += inputLine;
                in.close();

                // return result
                return json_content;
            }
            else
            {
                return "Got non-200 response: " + status_code;
            }

        }
        catch (MalformedURLException e)
        {
            return "Bad URL";
        }
        catch (IOException e)
        {
            return "Failed to open connection";
        }

    }


}
