namespace collage_app.Mylogger
{
    public class LogtoFile : IMylogger
    {
        public void Log(string message)
        {
            Console.WriteLine(message);
            Console.WriteLine("LogtoFile");
        }
    }
}