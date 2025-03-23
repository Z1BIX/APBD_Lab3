namespace Lab3;

public abstract class Container
{
    public int containerID;
    public double mass { get; set; }
    public double height { get; set; }
    public double tareWeight { get; set; }
    public double cargoWeight { get; set; }
    public double depth { get; set; }
    public String serialNumber { get; set; }
    public double maxPayload { get; set; }

    private static int id;

    public Container(double mass, double height, double tareWeight, double cargoWeight, double depth, double maxPayload)
    {
        containerID = ++id;
        this.mass = mass;
        this.height = height;
        this.tareWeight = tareWeight;
        this.cargoWeight = cargoWeight;
        this.depth = depth;
        serialNumber = generateSerialNumber();
        this.maxPayload = maxPayload;
    }
    
    public void emptyCargo()
    {
        this.mass = 0;
    }

    public void loadContainer(double mass)
    {
        if (this.mass + mass > this.maxPayload)
        {
            throw new OverfillException(mass, this.maxPayload);
        }
        else
        {
            this.mass += mass;
        }
    }

    public override string ToString()
    {
        return $"Container: {this.serialNumber}; Max Payload: {this.maxPayload}; Cargo Weight: {this.cargoWeight};";
    }

    public abstract String generateSerialNumber();
}