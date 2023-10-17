using RobotService.Core.Contracts;
using System;
using RobotService.Models;
using RobotService.Utilities.Messages;
using RobotService.Models.Contracts;
using RobotService.Repositories.Contracts;
using RobotService.Repositories;
using System.Linq;
using System.Collections.Generic;
using System.Text;

namespace RobotService.Core
{
    public class Controller : IController
    {
        IRepository<IRobot> robotRepositoryInC;
        IRepository<ISupplement> supplementRepositoryInC;
        public Controller() 
        {
            robotRepositoryInC = new RobotRepository();
            supplementRepositoryInC = new SupplementRepository();
        }
        public string CreateRobot(string model, string typeName)
        {
            IRobot temp = null;
            switch (typeName)
            {
                case "DomesticAssistant":
                    temp = new DomesticAssistant(model);
                    robotRepositoryInC.AddNew(temp);
                    return string.Format(OutputMessages.RobotCreatedSuccessfully, typeName, model);
                case "IndustrialAssistant":
                    temp = new IndustrialAssistant(model);
                    robotRepositoryInC.AddNew(temp);
                    return string.Format(OutputMessages.RobotCreatedSuccessfully, typeName, model);
                default:
                    return string.Format(OutputMessages.RobotCannotBeCreated, typeName);
            }
        }

        public string CreateSupplement(string typeName)
        {
            ISupplement temp = null;
            switch (typeName)
            {
                case "SpecializedArm":
                    temp = new SpecializedArm();
                    supplementRepositoryInC.AddNew(temp);
                    return string.Format(OutputMessages.SupplementCreatedSuccessfully, typeName);
                case "LaserRadar":
                    temp = new LaserRadar();
                    supplementRepositoryInC.AddNew(temp);
                    return string.Format(OutputMessages.SupplementCreatedSuccessfully, typeName);
                default:
                    return string.Format(OutputMessages.SupplementCannotBeCreated, typeName);
            }
        }

        public string PerformService(string serviceName, int interfaceStandard, int totalPowerNeeded)
        {
            IEnumerable<IRobot> tempRobots = robotRepositoryInC.Models()
                .Where(r => r.InterfaceStandards.Contains(interfaceStandard))
                .OrderByDescending(r => r.BatteryLevel);

            if (!tempRobots.Any())
            {
                return string.Format(OutputMessages.UnableToPerform, interfaceStandard);
            }

            int availableBattery = tempRobots.Sum(r => r.BatteryLevel);
            if (availableBattery < totalPowerNeeded)
            {
                return string.Format(OutputMessages.MorePowerNeeded, serviceName, totalPowerNeeded - availableBattery);
            }

            int count = 0;

            foreach (var robot in tempRobots)
            {
                count++;
                if (robot.BatteryLevel >= totalPowerNeeded)
                {
                    robot.ExecuteService(totalPowerNeeded);
                    break;
                }

                totalPowerNeeded -= robot.BatteryLevel;
                robot.ExecuteService(robot.BatteryLevel);
            }

            return string.Format(OutputMessages.PerformedSuccessfully, serviceName, count);
        }


        public string Report()
        {
            IEnumerable<IRobot> tempRobots = robotRepositoryInC.Models().OrderByDescending(r => r.BatteryLevel).ThenBy(r => r.BatteryCapacity);
            StringBuilder output = new StringBuilder();
            foreach (var robot in tempRobots)
            {
                output.AppendLine(robot.ToString());
            }

            return output.ToString().TrimEnd();
        }

        public string RobotRecovery(string model, int minutes)
        {
            IEnumerable<IRobot> tempRobots = robotRepositoryInC.Models().Where(r => r.BatteryLevel < r.BatteryCapacity / 2);
            int count = 0;
            foreach (IRobot robot in tempRobots)
            {
                count++;
                robot.Eating(minutes);
            }

            return string.Format(OutputMessages.RobotsFed, count);
        }

        public string UpgradeRobot(string model, string supplementTypeName)
        {
            ISupplement tempSupplement = this.supplementRepositoryInC.Models().FirstOrDefault(s => s.GetType().Name == supplementTypeName);
            IRobot tempRobot = this.robotRepositoryInC.Models().FirstOrDefault(r => r.Model == model && !r.InterfaceStandards.Contains(tempSupplement.InterfaceStandard));
            if (tempRobot == null)
            {
                return string.Format(OutputMessages.AllModelsUpgraded);
            }

            tempRobot.InstallSupplement(tempSupplement);
            supplementRepositoryInC.RemoveByName(supplementTypeName);
            return string.Format(OutputMessages.UpgradeSuccessful, model, supplementTypeName);
        }
    }
}
