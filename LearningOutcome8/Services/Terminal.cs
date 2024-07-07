using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using LearningOutcome8.Models;

namespace LearningOutcome8.Services
{
    public sealed class Terminal
    {
        private readonly List<ITrain> Trains = new();

        private Terminal() { }

        private static Terminal? instance = null;
        public static Terminal TerminalInstance => instance ??= new Terminal();

        private void AddTrain(ITrain train) => Trains.Add(train);

        public void ParkVehicles(List<ITransportableVehicle> vehicles, IEmployee employee)
        {
            vehicles.ForEach(vehicle =>
            {
                var train = Trains.FirstOrDefault(t =>
                    t.VehicleSize == vehicle.VehicleSize && 
                    t.BoardedVehicles.Count < t.MaxCapacity);

                if (train == null)
                {
                    train = vehicle.VehicleSize == VehicleSize.Small ? new SmallTrain() : new LargeTrain();
                    AddTrain(train);
                    Console.WriteLine($"New {vehicle.VehicleSize} Train created.");
                }
                employee.ParkVehicle(vehicle, train);
            });
        }

        public void Reset() => Trains.Clear();
    }
}
