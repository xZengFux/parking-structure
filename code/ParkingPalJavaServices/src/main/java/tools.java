public class tools {
    public long generatePaymentId(){
        return (long)(Math.random()*9*Math.pow(10,7)) + (long)Math.pow(10,7);
    }
}
