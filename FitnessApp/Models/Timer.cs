namespace FitnessApp.Models
{
    public class Timer
    {
        public int TimerId { get; set; }
        public DateTime StartTime { get; set; }
        public DateTime StopTime { get; set; }
        public bool IsRunning { get; set; }
    }
}
