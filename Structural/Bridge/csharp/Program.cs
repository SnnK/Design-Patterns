using System;

namespace DesignPatterns
{
    public class Program
    {
        static void Main()
        {
            Report report = new PerformanceReport(new SalesFormat());
            report.Display();

            Console.Read();
        }
    }

    public abstract class Report
    {
        protected readonly IReportFormat _reportFormat;

        public Report(IReportFormat reportFormat)
        {
            _reportFormat = reportFormat;
        }

        public abstract void Display();
    }

    public class SalesReport : Report
    {
        public SalesReport(IReportFormat reportFormat) : base(reportFormat)
        {

        }

        public override void Display()
        {
            _reportFormat.Display("test");
        }
    }

    public class PerformanceReport : Report
    {
        public PerformanceReport(IReportFormat reportFormat) : base(reportFormat)
        {

        }

        public override void Display()
        {
            _reportFormat.Display("test");
        }
    }

    public class SalesFormat : IReportFormat
    {
        public void Display(string text)
        {
            Console.WriteLine("Satış rapor metni.");
        }
    }

    public class PerformanceFormat : IReportFormat
    {
        public void Display(string text)
        {
            Console.WriteLine("Performans rapor metni.");
        }
    }

    public interface IReportFormat
    {
        void Display(string text);
    }
}