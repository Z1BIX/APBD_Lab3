namespace Lab3.Transport;

public class Ship
{
    public int id { get; set; }
    public List<Container> containers { get; set; }
    public double speed { get; set; }
    public int maxNumberOfContainers { get; set; }
    public double maxWeight { get; set; }
    
    public double totalWeight { get; set; }
    
    public int numberOfContainers { get; set; }

    public Ship(double speed, int maxNumberOfContainers, double maxWeight)
    {
        Random random = new Random();
        this.id = random.Next(1, 101);
        containers = new List<Container>();
        this.speed = speed;
        this.maxNumberOfContainers = maxNumberOfContainers;
        this.maxWeight = maxWeight;
        numberOfContainers = 0;
        totalWeight = 0;
    }

    public override string ToString()
    {
        return $"Ship with id {id} has {containers.Count} containers onboard, maximal speed is: {this.speed}; maximal weight is: {this.maxWeight}";
    }

    public void loadContainer(Container container)
    {
        if (numberOfContainers == maxNumberOfContainers)
        {
            throw new InvalidOperationException("Cannot load container more than " + maxNumberOfContainers + " containers");
        }

        if (totalWeight + container.mass > maxWeight * 1000)
        {
           throw new InvalidOperationException("Maximal wight cannot exceed" + maxWeight); 
        }
        
        containers.Add(container);
        totalWeight += container.mass;
        numberOfContainers++;
    }

    public void removeContainer(Container container)
    {
        containers.Remove(container);
        totalWeight -= container.mass;
        numberOfContainers--;
    }

    public void listLoadedContainers()
    {
        Console.WriteLine("Loaded containers:");
        foreach (Container container in containers)
        {
            Console.WriteLine($"{container.serialNumber}");
        }
    }

    public Container getContainer(string serialNumber)
    {
        return containers.FirstOrDefault(x => x.serialNumber == serialNumber);
    }

    public void replaceContainer(String serialNumberExisting, Container containerToAdd)
    {
        if (getContainer(serialNumberExisting) != null)
        {
            removeContainer(getContainer(serialNumberExisting));
            containers.Add(containerToAdd);
        }
        else
        {
            throw new InvalidOperationException("Cannot replace a container with that serial number existing");
        }
    }

    public void moveContainer(String containerToMove, Ship shipToMove)
    {
        var cont = getContainer(containerToMove);
        removeContainer(cont);
        shipToMove.loadContainer(cont);
    }
}