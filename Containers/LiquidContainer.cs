using Lab3.Interfaces;

namespace Lab3;

public class LiquidContainer : Container, IHazardNotifier
{
    public Boolean isHazardous { get; set; }
    
    public LiquidContainer(double mass, double height, double tareWeight, double cargoWeight, double depth, double maxPayload, Boolean isHazardous) : base(mass, height, tareWeight, cargoWeight, depth, maxPayload)
    {
        this.isHazardous = isHazardous;
    }

    public void loadContainer(double mass)
    {
        if (isHazardous)
        {
            if (this.mass + mass > this.maxPayload/2)
            {
                notify();
            }
            else
            {
                this.mass += mass;
            }
        }
        else
        {
            if (this.mass + mass > this.maxPayload*0.9)
            {
                notify();
            }
            else
            {
                this.mass += mass;
            }
        }
    }


    public override string generateSerialNumber()
    {
        String firstPart = "KON";
        String secondPart = "L";
        return firstPart + secondPart + Container.id;
    }
    
    public void notify()
    {
        Console.WriteLine($"Hazard situation occured, problem with container num: {serialNumber}");
    }
}