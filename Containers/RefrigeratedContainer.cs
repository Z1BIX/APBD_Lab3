namespace Lab3;

public class RefrigeratedContainer : Container
{
    private String[] types {get; set;}
    public double temperature { get; set; }
    
    
    public RefrigeratedContainer(double mass, double height, double tareWeight, double cargoWeight, double depth, double maxPayload) : base(mass, height, tareWeight, cargoWeight, depth, maxPayload)
    {
    }

    public override string generateSerialNumber()
    {
        String firstPart = "KON";
        String secondPart = "G";
        Random rnd = new Random();
        int thirdPart  = rnd.Next(0, 101);
        return firstPart + secondPart + thirdPart;
    }
    
    public void notify()
    {
        Console.WriteLine($"Hazard situation occured, problem with container num: {serialNumber}");
    }
}