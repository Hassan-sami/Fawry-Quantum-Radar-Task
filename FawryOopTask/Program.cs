using FawryOopTask.Rules;
using System;
namespace FawryOopTask;

class Program
{
    static void Main(string[] args)
    {
        // Initialize Radar
        var radar = new Radar();

        // Load rules 
        radar.AddRule(new SeatbeltRule());
        radar.AddRule(new SpeedRule(CarType.Private, 80, 300m));
        radar.AddRule(new SpeedRule(CarType.Truck, 60, 400m)); 

        // Create Mock Observations
        var obs1 = new Observation
        {
            PlateNumber = "ABC1234",
            Date = DateTime.Now,
            Type = CarType.Private,
            Speed = 83,
            IsSeatbeltFastened = false
        };

        var obs2 = new Observation
        {
            PlateNumber = "DEF5678",
            Date = DateTime.Now,
            Type = CarType.Truck,
            Speed = 66,
            IsSeatbeltFastened = true
        };

        var obs3 = new Observation
        {
            PlateNumber = "XYZ000",
            Date = DateTime.Now,
            Type = CarType.Private,
            Speed = 70,
            IsSeatbeltFastened = true
        };

        // Process Observations
        radar.ProcessObservation(obs1); // Should trigger 2 violations
        radar.ProcessObservation(obs2); // Should trigger 1 violation
        radar.ProcessObservation(obs3); // Should trigger 0 violations

        // Get Reports
        radar.PrintAllFinesSummary();
        radar.PrintViolatedRulesCount();
    }
}

