using FitnessApp.Models;

namespace FitnessApp.Services.Timer
{
    public class TimerService : ITimerService
    {
        private readonly ITimerRepository _timerRepository;

        public TimerService(ITimerRepository timerRepository)
        {
            _timerRepository = timerRepository;
        }

        public Models.Timer GetTimer(int id)
        {
            return _timerRepository.GetTimer(id);
        }

        public void StartTimer(Models.Timer timer)
        {
            _timerRepository.StartTimer(timer);
            _timerRepository.Save();
        }

        public void StopTimer(Models.Timer timer)
        {
            _timerRepository.StopTimer(timer);
            _timerRepository.Save();
        }
    }
}