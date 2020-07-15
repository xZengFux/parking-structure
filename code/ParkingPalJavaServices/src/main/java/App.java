import javax.ws.rs.ApplicationPath;
import javax.ws.rs.core.Application;
import java.util.HashSet;
import java.util.Set;

//Defines the base URI for all resource URIs.
@ApplicationPath("/")
//The java class declares root resource and provider classes
public class App extends Application{
    //The method returns a non-empty collection with classes, that must be included in the published JAX-RS application
    @Override
    public Set<Class<?>> getClasses() {
        HashSet h = new HashSet<Class<?>>();
        h.add(Functions.class );
        h.add(IP.class );
        h.add(City.class);
        h.add(Geo.class);
        h.add(State.class);
        h.add(Traffic.class);
        h.add(Weather.class);
        h.add(Zip.class);
        h.add(GasPrice.class);
        h.add(LPR.class);
        h.add(Car.class);
        return h;

    }
}