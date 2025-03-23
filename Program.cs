using Lab3;
using Lab3.Transport;

//Create a container
Container liquidContainer = new LiquidContainer(12.2d, 7, 5, 7.2, 6.5, 15, false);
Container gasContainer = new GasContainer(5.7, 3, 3.5, 2.2, 2.6, 7, 1.3);
Container refrigeratedContainer = new RefrigeratedContainer(33, 2.5, 8, 25, 2.3, 35, "Bananas", 10);

//Load cargo on a given containers
liquidContainer.loadContainer(2);

//Load container on a ship
var ship = new Ship(5, 100, 2);
ship.loadContainer(liquidContainer);

//Load a list of containers onto a ship
var containers = new List<Container> { gasContainer, refrigeratedContainer };
foreach (var cont in containers)
{
    ship.loadContainer(cont);
}

//Remove a container from the ship
ship.removeContainer(gasContainer);

//Unload container
var container = ship.getContainer(refrigeratedContainer.serialNumber);

//Replace container
ship.replaceContainer(liquidContainer.serialNumber, gasContainer);

//Transfer a container between ships
var ship2 = new Ship(10, 20, 0.5);
ship.moveContainer(gasContainer.serialNumber, ship2);

//Print information about a container
Console.WriteLine(liquidContainer);

//Print information about a ship
Console.WriteLine(ship);
ship.listLoadedContainers();