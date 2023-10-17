using RobotService.Models.Contracts;
using System;
using System.Collections.Generic;

namespace RobotService.Models
{
    public class Robot : IRobot
    {
        private string model;
        private int batteryCapacity;
        private int convertionCapacityIndex;
        private int batteryLevel;
        private List<int> interfaceStandatrs;

        public Robot(string model, int batteryCapacity, int convertionCapacityIndex)
        {
            Model = model;
            BatteryCapacity = batteryCapacity;
            this.batteryLevel = batteryCapacity;
            this.convertionCapacityIndex = convertionCapacityIndex;
            this.interfaceStandatrs = new List<int>();
        }

        public string Model
        {
            get => this.model;
            private set
            {
                if (string.IsNullOrWhiteSpace(value))
                {
                    throw new ArgumentNullException("Model cannot be null or empty.");
                }
                this.model = value;
            }
        }

        public int BatteryCapacity
        {
            get => this.batteryCapacity;
            private set
            {
                if (value < 0)
                {
                    throw new ArgumentException("Battery capacity cannot drop below zero.");
                }
                this.batteryCapacity = value;
            }
        }

        public int BatteryLevel => this.batteryLevel;


        public int ConvertionCapacityIndex => this.convertionCapacityIndex;

        public IReadOnlyCollection<int> InterfaceStandards => this.interfaceStandatrs;

        public virtual void Eating(int minutes)
        {
            int cap = convertionCapacityIndex * minutes;
            if (cap > BatteryCapacity - BatteryLevel)
            {
                this.batteryLevel = BatteryCapacity;
            }
            else
            {
                this.batteryLevel += cap;
            }
        }

        public bool ExecuteService(int consumedEnergy)
        {
            if (BatteryLevel >= consumedEnergy)
            {
                this.batteryLevel -= consumedEnergy;
                return true;
            }
            else { return false; }
        }

        public void InstallSupplement(ISupplement supplement)
        {
            this.interfaceStandatrs.Add(supplement.InterfaceStandard);
            BatteryCapacity -= supplement.BatteryUsage;
            this.batteryLevel -= supplement.BatteryUsage;
        }

        public override string ToString()
        {
            return $"--Maximum battery capacity: {this.BatteryCapacity}\n--Current battery level: {this.BatteryLevel}\n--Supplements installed: {string.Join(" ", this.interfaceStandatrs)}";
        }
    }
}
