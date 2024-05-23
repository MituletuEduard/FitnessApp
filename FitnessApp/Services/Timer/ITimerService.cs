using FitnessApp.Models;

namespace FitnessApp.Services.Timer
{
    public interface ITimerService
    {
        Models.Timer GetTimer(int id);
        void StartTimer(Models.Timer timer);
        void StopTimer(Models.Timer timer);
    }
}