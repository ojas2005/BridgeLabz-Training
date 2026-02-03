using System;

class Program
{
    static void Main(string[] args)
    {
        try
        {
            Console.WriteLine("enter arm precision");
            double armPrecision = Convert.ToDouble(Console.ReadLine());

            Console.WriteLine("enter worker density");
            int workerDensity = Convert.ToInt32(Console.ReadLine());

            Console.WriteLine("enter machinery state(Worn/Faulty/Critical)");
            string state = Console.ReadLine();
            Machinery machinery = new Machinery(armPrecision, workerDensity, state);
            RobotHazardCalculator auditor = new RobotHazardCalculator();
            double risk = auditor.CalculateHazardRisk(machinery.armPrecision,machinery.workerDensity,machinery.state);
            Console.WriteLine($"robot hazard risk score is {risk}");
        }
        catch (RobotSafetyException)
        {
        }
    }
}
