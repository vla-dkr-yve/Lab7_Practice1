using ReflectionTutorial;
using System.Reflection;
/* To Do on your own 2
var car = new Car("Toyota","Corola", 50, 6.0);

Console.WriteLine($"Cars made so far {Car.CarsMade}");

car.AddFuel(20);
car.AddFuel(70);

car.Drive(100);
car.Drive(200);

var car2 = new Car("Toyota", "Corola", 50, 6.0);
var car3 = new Car("Toyota", "Corola", 50, 6.0);

Console.WriteLine($"Cars made so far {Car.CarsMade}");
var zero = 0;
var carMadeType = typeof(Car).GetProperty("CarsMade", BindingFlags.Static | BindingFlags.Public);
carMadeType.SetValue(car, 0);
Console.WriteLine($"Cars made so far {Car.CarsMade}");
*/
/* To do on your own 1
var carType = typeof(Car);
var fuelLevelField = carType.GetField("_fuelLevel", BindingFlags.NonPublic | BindingFlags.Instance);
var odometerField = carType.GetField("_odometer", BindingFlags.NonPublic | BindingFlags.Instance);

Console.WriteLine($"{car.Brand} {car.Model} drove {car.Odometer} kilometers and remaining fuel is {fuelLevelField.GetValue}");

File.WriteAllText("car.txt", $"{car.Brand};{car.Model};{car.TankCapacity};{car.FuelConsumption};{fuelLevelField.GetValue};{odometerField.GetValue}");
*/
using ReflectionTutorial;
using System.Reflection;

var data = File.ReadAllText("car.txt").Split(";");
var brand = data[0];
var model = data[1];
var tankCapacity = int.Parse(data[2]);
var fuelConsumption = double.Parse(data[3]);
var fuelLevel = int.Parse(data[4]);
var odometer = int.Parse(data[5]);

//To do on your own 4
var carType = typeof(Car);
var carobj = Activator.CreateInstance(carType, brand, model, tankCapacity, fuelConsumption);

var fuelLevelField = carType.GetField("_fuelLevel", BindingFlags.NonPublic | BindingFlags.Instance);
var odometerField = carType.GetField("_odometer", BindingFlags.NonPublic | BindingFlags.Instance);

fuelLevelField.SetValue(carobj, fuelLevel);
odometerField.SetValue(carobj, odometer);

Car car = (Car)carobj;

Console.WriteLine($"{car.Brand} {car.Model} drove {car.Odometer} kilometers and remaining fuel is {car.FuelLevel}");