using System;

namespace SOLID.SRP.MoreExamples
{
    class Violation1
    {
        //example with business logic and formatting
        public string GetReport()
        {
            int clientsNumber = GetNumberOfClients();
            decimal totalIncome = GetTotalIncome();
            int satisfiedClients = GetSatisfiedClients();
            int unsatisfiedClients = GetUnsatisfiedClients();

            string clientsStr = $"Total number of Clients = {clientsNumber}";
            string incomeStr = $"Total Income = {totalIncome}";
            string satisfiedClientsStr = $"Number of satisfied Clients = {satisfiedClients}";
            string unsatisfiedClientsStr = $"Number of sad Clients = {unsatisfiedClients}";

            return clientsStr + Environment.NewLine +
                   incomeStr + Environment.NewLine +
                   satisfiedClientsStr + Environment.NewLine +
                   unsatisfiedClientsStr + Environment.NewLine;
        }

        #region Irrelevant

        private int GetUnsatisfiedClients()
        {
            throw new NotImplementedException();
        }

        private int GetSatisfiedClients()
        {
            throw new NotImplementedException();
        }

        private decimal GetTotalIncome()
        {
            throw new NotImplementedException();
        }

        private int GetNumberOfClients()
        {
            throw new NotImplementedException();
        }

        #endregion
    }

    class Violation2
    {
        //example with business logic and changing the state - mechanics and policy
        public void FindAlarmDevice()
        {
            var driver = new AlarmDriver();
            string port = driver.Find();
            if (!string.IsNullOrWhiteSpace(port))
            {
                SystemState.AlarmCanBeUsed = false;
            }
            SystemState.AlarmCanBeUsed = true;
        }
    }

    class Violation3
    {
        //example with drawing - calculation coordinated, setting color and filling the rectangle
        //violation depends on actors
        public void DrawRectangle()
        {
            Rectangle rect = GetRectangle();
            Color color = Colors.Red;
            rect.Fill(color);
        }

        private static Rectangle GetRectangle()
        {
            throw new NotImplementedException();
        }
    }

    #region Irrelevant
    internal class Log
    {
        public static void Write(string startProcessing)
        {
            throw new NotImplementedException();
        }
    }

    internal class SystemState
    {
        public static bool AlarmCanBeUsed { get; set; }
    }

    public class Rectangle
    {
        public void Fill(Color color)
        {
            throw new NotImplementedException();
        }
    }

    public class Color
    {
    }

    public class AlarmDriver
    {
        public string Find()
        {
            return "";
        }
    }

    public class Colors
    {
        public static Color Red => new Color();
    }

    class Violation4
    {
        public void PaymentProcessing()
        {
            Log.Write("Start processing.");

            PaymentProcessor p = new PaymentProcessor();
            p.Charge(100);

            Log.Write("End of processing.");
        }

        //business and logging
        //inheritance and residing in the same source file - ranting about level of separation - do we need to separate them into different source files?
    }

    #endregion
}