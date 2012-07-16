using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace TrainingTasks2.DIP
{
    public class BirthdayCalculator
    {
        private readonly List<Birthday> _birthdays;
        private readonly IToday _today;

        public BirthdayCalculator(List<Birthday> birthdays, IToday today)
        {
            _birthdays = birthdays;
            _today = today;
        }

        public List<Birthday> Birthdays
        {
            get { return _birthdays; }
        }

        public List<Birthday> GetTodaysBirthdays()
        {
            return _birthdays
                .Where(bd => bd.Date == _today.GetNowDate())
                .ToList();
        }
    }
}
