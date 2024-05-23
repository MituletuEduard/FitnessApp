using FitnessApp.Models;
using System.Linq;

namespace FitnessApp.Services.Timer
{
    public class TimerRepository : ITimerRepository
    {
        private readonly ApplicationContext _context;

        public TimerRepository(ApplicationContext context)
        {
            _context = context;
        }

        public Models.Timer GetTimer(int id)
        {
            return _context.Timers.Find(id);
        }

        public void StartTimer(Models.Timer timer)
        {
            timer.StartTime = DateTime.Now;
            timer.IsRunning = true;
            _context.Timers.Add(timer);
        }

        public void StopTimer(Models.Timer timer)
        {
            timer.StopTime = DateTime.Now;
            timer.IsRunning = false;
            _context.Timers.Update(timer);
        }

        public void Save()
        {
            _context.SaveChanges();
        }
    }
}