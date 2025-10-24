using System.Text.RegularExpressions;

namespace Day2Tasks
{
    internal class Program
    {
        static void Main(string[] args)
        {
            // CS.1.011: Class & Object Fundamentals
            Console.WriteLine("--- CS.1.011 ---");
            var meter1 = new Meter { MeterSerial = "AP-0001", Location = "Feeder-12", InstalledOn = DateTime.Now, LastReadingKwh = 15000 };
            var meter2 = new Meter { MeterSerial = "AP-0002", Location = "DTR-9", InstalledOn = DateTime.Now, LastReadingKwh = 9500 };

            meter1.AddReading(230);
            meter1.AddReading(-50);
            meter2.AddReading(300);

            Console.WriteLine(meter1.Summary());
            Console.WriteLine(meter2.Summary());
            Console.WriteLine();

            // CS.1.012: Constructors & Overloads
            Console.WriteLine("--- CS.1.012 ---");
            var domestic = new Tariff("DOMESTIC");
            var commercial = new Tariff("COMMERCIAL", 8.5);
            var agriculture = new Tariff("AGRI", 3.0, 0);

            int units = 120;
            Console.WriteLine($"DOMESTIC: Rs.{domestic.ComputeBill(units):F2}");
            Console.WriteLine($"COMMERCIAL: Rs.{commercial.ComputeBill(units):F2}");
            Console.WriteLine($"AGRI: Rs.{agriculture.ComputeBill(units):F2}");
            Console.WriteLine();

            // CS.2.013: Inheritance Basics
            Console.WriteLine("--- CS.2.013 ---");
            var devices = new Device[]
            {
            new MeterDevice { Id = "AP-0001", InstalledOn = new DateTime(2024, 7, 1), PhaseCount = 3 },
            new GatewayDevice { Id = "GW-11", InstalledOn = new DateTime(2025, 1, 10), IpAddress = "10.0.5.21" }
            };

            foreach (var device in devices)
            {
                Console.WriteLine(device.Describe());
            }
            Console.WriteLine();

            // CS.2.014: Interface for Reading
            Console.WriteLine("--- CS.2.014 ---");
            var readables = new List<IReadable>
            {
            new DlmsMeter("AP-0001"),
            new ModemGateway("GW-21")
            };

            for (int i = 0; i < 5; i++)
            {
                foreach (var readable in readables)
                {
                    Console.WriteLine($"{readable.SourceId} -> {readable.ReadKwh()}");
                }
            }
            Console.WriteLine();

            // CS.2.015: Polymorphism with Strategy
            Console.WriteLine("--- CS.2.015 ---");
            var billingEngine = new BillingEngine();

            billingEngine.Rule = new DomesticRule();
            Console.WriteLine($"DOMESTIC -> Rs.{billingEngine.GenerateBill(120):F2}");

            billingEngine.Rule = new CommercialRule();
            Console.WriteLine($"COMMERCIAL -> Rs.{billingEngine.GenerateBill(120):F2}");

            billingEngine.Rule = new AgricultureRule();
            Console.WriteLine($"AGRICULTURE -> Rs.{billingEngine.GenerateBill(120):F2}");

            // CS.2.016: Constructors, Encapsulation & Computed Props
            Console.WriteLine("--- CS.2.016 ---");
            var hourlyData = new int[] { 0, 0, 0, 0, 1, 2, 5, 8, 10, 8, 5, 3, 2, 1, 3, 5, 7, 9, 12, 15, 12, 9, 6, 4 };
            var day = new LoadProfileDay(new DateTime(2025, 10, 1), hourlyData);
            Console.WriteLine($"{day.Date:yyyy-MM-dd} | Total: {day.Total} kWh | PeakHour: {day.PeakHour}");
            Console.WriteLine();


            // CS.3.017: Abstract Base + Overrides
            Console.WriteLine("--- CS.3.017 ---");
            var dayWithHighs = new LoadProfileDay(new DateTime(2025, 10, 1), new int[] { 5, 5, 5, 5, 5, 5, 5, 5, 5, 5, 5, 5, 5, 5, 5, 5, 5, 5, 5, 5, 5, 5, 5, 5 });
            var dayWithOutage = new LoadProfileDay(new DateTime(2025, 10, 2), new int[] { 1, 2, 3, 0, 0, 0, 0, 5, 6, 7, 8, 9, 10, 11, 12, 13, 14, 15, 16, 17, 18, 19, 20, 21 });

            var overuseRule = new PeakOveruseRule(100);
            var outageRule = new SustainedOutageRule(4);

            if (overuseRule.IsTriggered(dayWithHighs))
            {
                Console.WriteLine(overuseRule.Message(dayWithHighs));
            }

            if (outageRule.IsTriggered(dayWithOutage))
            {
                Console.WriteLine(outageRule.Message(dayWithOutage));
            }
            Console.WriteLine();


            // CS.3.018: Interface Segregation + Multiple Implementations
            Console.WriteLine("--- CS.3.018 ---");
            var ingestor = new RandomOutageDecorator(new DlmsIngestor());
            foreach (var item in ingestor.ReadBatch(10))
            {
                Console.WriteLine($"[{ingestor.Name}] {item.ts:yyyy-MM-dd HH:mm} -> {item.kwh}");
            }
            Console.WriteLine();


            // CS.3.019: Polymorphic Billing with Add-on Interfaces
            Console.WriteLine("--- CS.3.019 ---");
            var billingContext = new BillingContext(new CommercialRule());
            billingContext.Rebates.Add(new NoOutageRebate());
            billingContext.Rebates.Add(new HighUsageRebate());

            units = 620;
            int outageDays = 0;
            double subtotal = billingContext.Rule.Compute(units);
            double finalTotal = billingContext.Finalize(units, outageDays);
            Console.WriteLine($"Subtotal: ₹ {subtotal:N2}");
            Console.WriteLine($"Rebates: {string.Join(" | ", billingContext.Rebates.Select(r => r.Code))}");
            Console.WriteLine($"Final: ₹ {finalTotal:N2}");
            Console.WriteLine();


            // CS.3.020: Domain Model with Inheritance & Polymorphic Processing
            Console.WriteLine("--- CS.3.020 ---");
            var events = new List<Event>
            {
            new VoltageEvent(new DateTime(2025, 10, 5, 18, 0, 0), "AP-0001", 184.5),
            new OutageEvent(new DateTime(2025, 10, 5, 22, 10, 0), "AP-0003", 95),
            new VoltageEvent(new DateTime(2025, 10, 6, 8, 30, 0), "AP-0001", 240.2),
            new TamperEvent(new DateTime(2025, 10, 6, 9, 20, 0), "AP-0007", "MISMATCH"),
            new VoltageEvent(new DateTime(2025, 10, 5, 19, 0, 0), "AP-0001", 192.1),
            new OutageEvent(new DateTime(2025, 10, 6, 5, 0, 0), "AP-0003", 120),
            new TamperEvent(new DateTime(2025, 10, 6, 9, 10, 0), "AP-0007", "COVER_OPEN"),
            new OutageEvent(new DateTime(2025, 10, 5, 22, 10, 0), "AP-0004", 45)
            };

            EventProcessor.PrintTopSevere(events, 3);
        }
    }
}
