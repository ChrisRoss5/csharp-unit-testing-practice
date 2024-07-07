// See https://aka.ms/new-console-template for more information
using LearningOutcome8.Models;
using LearningOutcome8.Services;

Console.WriteLine("== Terminal for transporting vehicles by train ==");

string[] vehicles = new string[] {
    "Gasoline Car",
    "Electric Car",
    "Gasoline Van",
    "Electric Van",
    "Gasoline Bus",
    "Electric Bus",
    "Gasoline Truck",
    "Electric Truck"
};

do
{
    Terminal terminal = Terminal.TerminalInstance;

    Console.WriteLine("\nAvailable vehicles:");
    for (int i = 0; i < vehicles.Length; i++)
        Console.WriteLine($"{i + 1}. {vehicles[i]}");
    Console.WriteLine("\nPick vehicles to transport (e.g. 1,2,2,3,3,3): ");

    string[] inputStrings = Console.ReadLine()?.Split(',') ?? Array.Empty<string>();

    List<ITransportableVehicle> vehiclesToTransport = new();
    foreach (string s in inputStrings)
    {
        if (!int.TryParse(s, out int i) || i < 1 || i > vehicles.Length) continue;
        Type? t = Type.GetType($"LearningOutcome8.Models.{vehicles[i - 1].Replace(" ", "")}");
        if (t == null) continue;
        vehiclesToTransport.Add((ITransportableVehicle)Activator.CreateInstance(t)!);
    }

    Console.WriteLine($"Successfully created {vehiclesToTransport.Count} vehicle(s)!\n");

    Employee employee1 = new("Kristijan", 10);
    Console.WriteLine($"Running simulation for employee {employee1.Name}:");
    terminal.ParkVehicles(vehiclesToTransport, employee1);
    Console.WriteLine($"Employee {employee1.Name} earned {employee1.TotalEarnings} kn.\n");
    terminal.Reset();

    Employee employee2 = new("Ivan", 11);
    Console.WriteLine($"Running simulation for employee {employee2.Name}:");
    terminal.ParkVehicles(vehiclesToTransport, employee2);
    Console.WriteLine($"Employee {employee2.Name} earned {employee2.TotalEarnings} kn.\n");
    terminal.Reset();

    Console.WriteLine("\nRun again? (y/n)");
    if (Console.ReadLine()?.ToLower() != "y") break;
}
while (true);
