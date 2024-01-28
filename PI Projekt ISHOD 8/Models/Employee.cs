using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PI_Projekt_ISHOD_8.Models
{
    public interface IEmployee
    {
        string Name { get; }
        int PercPerTicket { get; }
        decimal TotalEarnings { get; }
        void ParkVehicle(ITransportableVehicle vehicle, ITrain train);
        void ChargeVehicle(IElectricVehicle electricVehicle);
        void RefuelVehicle(IGasolineVehicle gasolineVehicle);
    }

    public class Employee : IEmployee
    {
        public string Name { get; }
        public int PercPerTicket { get; }
        public decimal TotalEarnings { get; private set; }
        public Employee(string name, int percPerTicket)
        {
            Name = name;
            PercPerTicket = percPerTicket;
        }
        public void ParkVehicle(ITransportableVehicle vehicle, ITrain train)
        {
            if (vehicle is GasolineVehicle gasolineVehicle)
                RefuelVehicle(gasolineVehicle);
            else if (vehicle is ElectricVehicle electricVehicle)
                ChargeVehicle(electricVehicle);
            TotalEarnings += vehicle.TransportFare * (decimal)PercPerTicket / 100;
            train.AddVehicle(vehicle);
            Console.WriteLine($"{vehicle} parked by {Name}.");
        }
        public void ChargeVehicle(IElectricVehicle electricVehicle)
        {
            if (electricVehicle.BatteryPercentage >= 10) return;
            electricVehicle.ChargeBattery();
            Console.WriteLine($"{electricVehicle} is charging to 100% by {Name}.");
        }
        public void RefuelVehicle(IGasolineVehicle gasolineVehicle)
        {
            if (gasolineVehicle.FuelPercentage >= 10) return;
            Console.WriteLine($"{gasolineVehicle} is refueling to 100% by {Name}.");
            gasolineVehicle.Refuel();
        }
    }
}
