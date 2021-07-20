using System;
using System.Collections.Generic;
using System.Text;

namespace _02.VehiclesExtension
{
    public abstract class Vehicle
    {
        private double fuelQuantity;
        protected Vehicle(double fuelQuantity, double fuelConsumption, double tankCapacity)
        {
            this.FuelQuantity = fuelQuantity;
            this.FuelConsumption = fuelConsumption;
            this.TankCapacity = tankCapacity;
        }

        public double FuelQuantity
        {
            get => this.fuelQuantity;
            private set
            {
                if (value>TankCapacity)
                {
                    this.fuelQuantity = 0;
                }
                else
                {
                    this.fuelQuantity = value;
                }
            }
        }
        public virtual double FuelConsumption { get; }
        public double TankCapacity { get; }

        public virtual void Refuel(double amount)
        {
            if (amount<=0)
            {
                throw new InvalidOperationException("Fuel must be a positive number");
            }

            if (amount>this.TankCapacity)
            {
                throw new InvalidOperationException($"Cannot fit {amount} fuel in the tank");
            }

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
