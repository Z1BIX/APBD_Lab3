using Lab3.Interfaces;

namespace Lab3;

public class GasContainer : Container, IHazardNotifier
{
    public double pressure { get; set; }
    
    public GasContainer(double mass, double height, double tareWeight, double cargoWeight, double depth, double maxPayload, double pressure) : base(mass, height, tareWeight, cargoWeight, depth, maxPayload)
    {
        this.pressure = pressure;
    }
    
    public void emptyCargo()
    {
        this.mass = this.mass * 0.05;
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