namespace Lab3;

public class OverfillException : Exception
{
    public double mass { get; }
    public double maxPayload { get; }
    public OverfillException (double mass, double maxPayload) : base ($"Impossible to load {mass} to your container, because max payload is {maxPayload}")
    {
        this.mass = mass;
        this.maxPayload = maxPayload;
    }
}