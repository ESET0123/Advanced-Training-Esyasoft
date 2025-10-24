namespace Basicstask
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Meter m1 = new Meter
            {
                meterSerial = "AP-000123",
                prevReading = 12500,
                currReading = 12620
            };
            m1.computeSummary();

            Meter2 m2 = new Meter2() ;
            m2.Summary();

            Meter3 m3 = new Meter3();
            m3.Summary();

        }
    }
}
