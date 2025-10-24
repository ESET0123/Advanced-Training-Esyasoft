using collage_app.Mylogger;

namespace CollegeApp.Mylogger
{
    public class logme
    {
        private readonly IMylogger _mylogger;
        public logme(IMylogger mylogger)
        {
            _mylogger = mylogger;
        }
    }
}
