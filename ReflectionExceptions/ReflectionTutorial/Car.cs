namespace ReflectionTutorial;

public class FuelOverflowException : Exception
{
    public FuelOverflowException(string message) : base(message) { }
}

public class DriveDistanceException : Exception
{
    public DriveDistanceException(string message) : base(message) { }
}

public class Car
{
    public static int CarsMade { get; set; }

    public string Brand { get; set; }
    public string Model { get; set; }
    public int TankCapacity { get; set; }
    public double FuelConsumption { get; set; }
    public int FuelLevel => (int)_fuelLevel;
    public int Odometer => (int)_odometer;

    private double _fuelLevel;
    private double _odometer;

    public Car(string brand, string model, int tankCapacity, double fuelConsumption)
    {
        ArgumentException.ThrowIfNullOrWhiteSpace(brand, nameof(brand));
        ArgumentException.ThrowIfNullOrWhiteSpace(model, nameof(model));
        ArgumentOutOfRangeException.ThrowIfLessThanOrEqual(tankCapacity, 0, nameof(tankCapacity));
        ArgumentOutOfRangeException.ThrowIfLessThanOrEqual(fuelConsumption, 0, nameof(fuelConsumption));


        Brand = brand;
        Model = model;
        TankCapacity = tankCapacity;
        FuelConsumption = fuelConsumption;

        CarsMade++;
    }

    public void AddFuel(double amount)
    {
        ArgumentOutOfRangeException.ThrowIfLessThanOrEqual(amount, 0, nameof(amount));
        ArgumentOutOfRangeException.ThrowIfLessThanOrEqual(amount, TankCapacity, nameof(amount));
        if (amount + _fuelLevel > TankCapacity)
            throw new FuelOverflowException($"Adding {amount} liter of fuel with {_fuelLevel} in tank would exceed the {TankCapacity}");

        _fuelLevel += amount;
    }

    public void Drive(double distance)
    {
        if (distance < 0)
        {
            throw new ArgumentOutOfRangeException("You can't drive negarive distance");
        }

        var fuelNeeded = distance / 100.0 * FuelConsumption;

        if (fuelNeeded > _fuelLevel)
        {
            throw new DriveDistanceException("You can't drive that much with the ammount of fuel you have");
        }
        else
        {
            _fuelLevel -= fuelNeeded;
            _odometer += distance;
        }
    }
}