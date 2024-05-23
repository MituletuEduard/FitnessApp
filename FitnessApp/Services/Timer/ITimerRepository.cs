using FitnessApp.Models;

namespace FitnessApp.Services.Timer
{
    public interface ITimerRepository
    {
        Models.Timer GetTimer(int id);
        void StartTimer(Models.Timer timer);
        void StopTimer(Models.Timer timer);
        void Save();
    }
}