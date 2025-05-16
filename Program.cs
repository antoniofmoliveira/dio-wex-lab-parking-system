
using parking.Model;


/// <summary>
/// Press any key to continue
/// </summary>
static void PressAnyKeyToContinue()
{
    Console.WriteLine("Press any key to continue");
    Console.ReadKey();
    Console.Clear();
}

/// <summary>
/// Add vehicle
/// </summary>
static void AddVehicle(List<Vehicle> vehicles)
{
    Console.Write("Enter license plate: ");
    var licensePlate = Console.ReadLine();
    if (licensePlate != null)
    {
        Vehicle vehicle = new(licensePlate.ToUpper());
        vehicles.Add(vehicle);
        Console.WriteLine("Vehicle added");
    }

    PressAnyKeyToContinue();
}

/// <summary>
/// List vehicles
/// </summary>
static void ListVehicles(List<Vehicle> vehicles)
{
    Console.WriteLine("Vehicles list");
    vehicles.ForEach(v => Console.WriteLine(v.LicensePlate));
    PressAnyKeyToContinue();
}

/// <summary>
/// Remove vehicle by license plate
/// </summary>
static void RemoveVehicleByLicensePlate(List<Vehicle> vehicles, int initialFee, int hourFee)
{
    Console.Write("Enter license plate: ");
    var licensePlate = Console.ReadLine();
    if (licensePlate != null)
    {
        licensePlate = licensePlate.ToUpper();
        var vehicle = vehicles.FirstOrDefault(v => v.LicensePlate == licensePlate);
        if (vehicle != null)
        {
            Console.WriteLine("Enter quantity of parking hours: ");
            var hours = Convert.ToInt32(Console.ReadLine());
            int totalFee = initialFee + hours * hourFee;
            vehicles.Remove(vehicle);
            Console.WriteLine($"Vehicle removed. Total fee: {totalFee}");
        }
        else
        {
            Console.WriteLine("Vehicle not found");
        }
    }
    PressAnyKeyToContinue();
}

/// <summary>
/// Exit
/// </summary>
static void Exit()
{
    Console.WriteLine("Good bye");
    Environment.Exit(0);
}

/// <summary>
/// Show Menu
/// </summary>
static void Menu(List<Vehicle> vehicles, int initialFee, int hourFee)
{
    while (true)
    {
        Console.WriteLine("1 - Add vehicle");
        Console.WriteLine("2 - Remove vehicle");
        Console.WriteLine("3 - List vehicles");
        Console.WriteLine("4 - Exit");
        Console.Write("Enter option: ");
        var option = Console.ReadLine();
        switch (option)
        {
            case "1": AddVehicle(vehicles); break;
            case "2": RemoveVehicleByLicensePlate(vehicles, initialFee, hourFee); break;
            case "3": ListVehicles(vehicles); break;
            case "4": Exit(); break;
            default: Console.WriteLine("Invalid option"); break;
        }
    }
}


List<Vehicle> vehicles = [];

Console.WriteLine("Welcome to Parking System.\nInitial fee: ");
var initialFee = Convert.ToInt32(Console.ReadLine());
Console.WriteLine("Fee per hour: ");
var hourFee = Convert.ToInt32(Console.ReadLine());

Menu(vehicles, initialFee, hourFee);