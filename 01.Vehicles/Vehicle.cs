using System;
using System.Collections.Generic;
using System.Text;

namespace _01.Vehicles
{
    public abstract class Vehicle
    {
        protected Vehicle(double fuelQuantity, double fuelConsumption)
        {
            this.FuelQuantity = fuelQuantity;
            this.FuelConsumption = fuelConsumption;
        }

        public double FuelQuantity { get; private set; }
        public virtual double FuelConsumption { get; }

        public virtual void Refuel(double amount)
        {
            this.FuelQuantity += amount;
        }

        public bool CanDrive(double distance)
        {
            bool canDrive = FuelQuantity - FuelConsumption * distance >= 0;

            if (!canDrive)
            {
                return false;
            }
            FuelQuantity -= FuelConsumption * distance;
            return true;
        }
    }
}
