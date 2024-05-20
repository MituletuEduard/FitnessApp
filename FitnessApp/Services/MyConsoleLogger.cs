namespace FitnessApp.Services
{

    public class MyConsoleLogger : ILog
    {
        public void LogInformation(string message)
        {
            Console.WriteLine($"Info: {message}");
        }

        public void LogWarning(string message)
        {
            Console.WriteLine($"Warning: {message}");
        }

        public void LogError(string message)
        {
            Console.WriteLine($"Error: {message}");
        }
    }

}
