using System;

namespace TrainingTasks2.DIP
{
    public class Today : IToday
    {
        public DateTime GetNowDate()
        {
            return DateTime.Now.Date;
        }
    }
}