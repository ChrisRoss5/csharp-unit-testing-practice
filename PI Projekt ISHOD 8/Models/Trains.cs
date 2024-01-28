using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PI_Projekt_ISHOD_8.Models
{

    public interface ITrain
    {
        int MaxCapacity { get; }
        VehicleSize VehicleSize { get; }
        List<ITransportableVehicle> BoardedVehicles { get; }
        void AddVehicle(ITransportableVehicle vehicle);
    }

    public class SmallTrain : ITrain
    {
        public int MaxCapacity => 8;
        public VehicleSize VehicleSize => VehicleSize.Small;
        public List<ITransportableVehicle> BoardedVehicles { get; } = new();
        public void AddVehicle(ITransportableVehicle vehicle)
        {
            if (vehicle.VehicleSize != VehicleSize)
                throw new Exception("Wrong train");
            if (BoardedVehicles.Count >= MaxCapacity)
                throw new Exception("Train is full");
            BoardedVehicles.Add(vehicle);
        }
    }

    public class LargeTrain : ITrain
    {
        public int MaxCapacity => 6;
        public VehicleSize VehicleSize => VehicleSize.Large;
        public List<ITransportableVehicle> BoardedVehicles { get; } = new();
        public void AddVehicle(ITransportableVehicle vehicle)
        {
            if (vehicle.VehicleSize != VehicleSize)
                throw new Exception("Wrong train");
            if (BoardedVehicles.Count >= MaxCapacity)
                throw new Exception("Train is full");
            BoardedVehicles.Add(vehicle);
        }
    }
}
