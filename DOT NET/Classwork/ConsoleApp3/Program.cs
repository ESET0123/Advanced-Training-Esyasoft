//Create an interface IDevice with properties DeviceName and IsOn, and methods TurnOn() and TurnOff().
//Create another interface ISmartDevice that inherits IDevice and adds void ConnectToWiFi(string networkName) and void ShowStatus().
//Implement classes Light, Fan, and Thermostat that implement ISmartDevice with device-specific properties (Brightness, Speed, Temperature).
//Create a list of ISmartDevice in Main() and perform the following:
//Turn on all devices
//Connect all to WiFi
//Display their status
namespace ConsoleApp3
{
    internal class Program
    {
        static void Main(string[] args)
        {
            
        }
    }
    public interface IDevice
    {
        string DeviceName { get; set; }
        bool IsOn { get; set; }
        public void TurnOn();
        public void TurnOff();
    }
    public interface ISmartDevice: IDevice
    {
        public void ConnectToWiFi(string networkName);
        public void ShowStatus();
    }
    public class Light : ISmartDevice
    {
        public string DeviceName { get; set; }
        public bool IsOn { get; set; }
        public int Brightness { get; set; }
        private string _connectedNetwork;
        public Light(string deviceName)
        {
            DeviceName = deviceName;
            IsOn = false;
            Brightness = 0;
        }

        public void TurnOn()
        {
            IsOn = true;
            Brightness = 100;
            Console.WriteLine($"{DeviceName} is now ON.");
        }

        public void TurnOff()
        {
            IsOn = false;
            Brightness = 0;
            Console.WriteLine($"{DeviceName} is now OFF.");
        }

        public void ConnectToWiFi(string networkName)
        {
            _connectedNetwork = networkName;
            Console.WriteLine($"{DeviceName} connected to {networkName}.");
        }

        public void ShowStatus()
        {
            string status = IsOn ? "ON" : "OFF";
            Console.WriteLine($"\n--- {DeviceName} Status ---");
            Console.WriteLine($"Power: {status}");
            Console.WriteLine($"Brightness: {Brightness}%");
            Console.WriteLine($"WiFi Network: {_connectedNetwork ?? "Not connected"}");
        }
    }
    public class Fan : ISmartDevice
    {
        public string DeviceName { get; set; }
        public bool IsOn { get; set; }
        public int Speed { get; set; }
        private string _connectedNetwork;

        public Fan(string deviceName)
        {
            DeviceName = deviceName;
            IsOn = false;
            Speed = 0;
        }

        public void TurnOn()
        {
            IsOn = true;
            Speed = 2;
            Console.WriteLine($"{DeviceName} is now ON.");
        }

        public void TurnOff()
        {
            IsOn = false;
            Speed = 0;
            Console.WriteLine($"{DeviceName} is now OFF.");
        }

        public void ConnectToWiFi(string networkName)
        {
            _connectedNetwork = networkName;
            Console.WriteLine($"{DeviceName} connected to {networkName}.");
        }

        public void ShowStatus()
        {
            string status = IsOn ? "ON" : "OFF";
            Console.WriteLine($"\n--- {DeviceName} Status ---");
            Console.WriteLine($"Power: {status}");
            Console.WriteLine($"Speed: {Speed}");
            Console.WriteLine($"WiFi Network: {_connectedNetwork ?? "Not connected"}");
        }
    }

    public class Thermostat : ISmartDevice
    {
        public string DeviceName { get; set; }
        public bool IsOn { get; set; }
        public double Temperature { get; set; }
        private string _connectedNetwork;

        public Thermostat(string deviceName)
        {
            DeviceName = deviceName;
            IsOn = false;
            Temperature = 20.0;
        }

        public void TurnOn()
        {
            IsOn = true;
            Console.WriteLine($"{DeviceName} is now ON.");
        }

        public void TurnOff()
        {
            IsOn = false;
            Console.WriteLine($"{DeviceName} is now OFF.");
        }

        public void ConnectToWiFi(string networkName)
        {
            _connectedNetwork = networkName;
            Console.WriteLine($"{DeviceName} connected to {networkName}.");
        }

        public void ShowStatus()
        {
            string status = IsOn ? "ON" : "OFF";
            Console.WriteLine($"\n--- {DeviceName} Status ---");
            Console.WriteLine($"Power: {status}");
            Console.WriteLine($"Temperature: {Temperature}°C");
            Console.WriteLine($"WiFi Network: {_connectedNetwork ?? "Not connected"}");
        }
    }

}
