namespace Lab3;

public class RefrigeratedContainer : Container
{
    private static Dictionary<string, double> types = new Dictionary<string, double>
    {
        ["Bananas"] = 13.3,
        ["Chocolate"] = 18,
        ["Fish"] = 2,
        ["Meat"] = -15,
        ["Ice Cream"] = -18,
        ["Frozen Pizza"] = -30,
        ["Cheese"] = 7.2,
        ["Sausages"] = 5,
        ["Butter"] = 20.5,
        ["Eggs"] = 19,
    };

    private String type { get; set; }
    public double temperature { get; set; }

    public RefrigeratedContainer(double mass, double height, double tareWeight, double cargoWeight, double depth,
        double maxPayload, String type, double temperature) : base(mass, height, tareWeight, cargoWeight, depth,
        maxPayload)
    {
        checkArguments(type, temperature);
        this.type = type;
        this.temperature = temperature;
    }

    private void checkArguments(String type, double temperature)
    {
        if (!types.ContainsKey(type))
        {
            throw new InvalidOperationException("Type not found");
        }

        double requiredTempreture = types.GetValueOrDefault(type, -1);


        if (temperature > requiredTempreture)
        {
            throw new InvalidOperationException("Not appropriate temperature");
        }
    }

    public override string generateSerialNumber()
    {
        String firstPart = "KON";
        String secondPart = "G";
        return $"{firstPart}-{secondPart}-{containerID}";
    }

    public void notify()
    {
        Console.WriteLine($"Hazard situation occured, problem with container num: {serialNumber}");
    }
}