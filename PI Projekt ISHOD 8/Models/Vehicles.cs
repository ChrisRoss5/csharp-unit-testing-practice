using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PI_Projekt_ISHOD_8.Models
{
    public enum VehicleSize
    {
        Small,
        Large
    }

    public interface IElectricVehicle
    {
        int BatteryPercentage { get; }
        void ChargeBattery();
    }

    public interface IGasolineVehicle
    {
        int FuelPercentage { get; }
        void Refuel();
    }

    public abstract class ElectricVehicle : IElectricVehicle
    {
        public int BatteryPercentage { get; protected set; }
        protected ElectricVehicle() => BatteryPercentage = new Random().Next(0, 100);
        public void ChargeBattery() => BatteryPercentage = 100;
    }

    public abstract class GasolineVehicle : IGasolineVehicle
    {
        public int FuelPercentage { get; protected set; }
        protected GasolineVehicle() => FuelPercentage = new Random().Next(0, 100);
        public void Refuel() => FuelPercentage = 100;
    }

    public interface ITransportableVehicle
    {
        int TransportFare { get; }
        VehicleSize VehicleSize { get; }
    }

    public class GasolineCar : GasolineVehicle, ITransportableVehicle
    {
        public int TransportFare => 50;
        public VehicleSize VehicleSize => VehicleSize.Small;
        override public string ToString() => $"Gasoline Car (fuel: {FuelPercentage}%)";
    }

    public class ElectricCar : ElectricVehicle, ITransportableVehicle
    {
        public int TransportFare => 50;
        public VehicleSize VehicleSize => VehicleSize.Small;
        override public string ToString() => $"Electric Car (battery: {BatteryPercentage}%)";
    }

    public class GasolineVan : GasolineVehicle, ITransportableVehicle
    {
        public int TransportFare => 80;
        public VehicleSize VehicleSize => VehicleSize.Small;
        override public string ToString() => $"Gasoline Van (fuel: {FuelPercentage}%)";
    }

    public class ElectricVan : ElectricVehicle, ITransportableVehicle
    {
        public int TransportFare => 80;
        public VehicleSize VehicleSize => VehicleSize.Small;
        override public string ToString() => $"Electric Van (battery: {BatteryPercentage}%)";
    }

    public class GasolineBus : GasolineVehicle, ITransportableVehicle
    {
        public int TransportFare => 70;
        public VehicleSize VehicleSize => VehicleSize.Large;
        override public string ToString() => $"Gasoline Bus (fuel: {FuelPercentage}%)";
    }

    public class ElectricBus : ElectricVehicle, ITransportableVehicle
    {
        public int TransportFare => 70;
        public VehicleSize VehicleSize => VehicleSize.Large;
        override public string ToString() => $"Electric Bus (battery: {BatteryPercentage}%)";
    }

    public class GasolineTruck : GasolineVehicle, ITransportableVehicle
    {
        public int TransportFare => 90;
        public VehicleSize VehicleSize => VehicleSize.Large;
        override public string ToString() => $"Gasoline Truck (fuel: {FuelPercentage}%)";
    }

    public class ElectricTruck : ElectricVehicle, ITransportableVehicle
    {
        public int TransportFare => 90;
        public VehicleSize VehicleSize => VehicleSize.Large;
        override public string ToString() => $"Electric Truck (battery: {BatteryPercentage}%)";
    }
}
