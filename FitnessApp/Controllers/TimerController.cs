using FitnessApp.Models;
using FitnessApp.Services.Timer;
using Microsoft.AspNetCore.Mvc;

public class TimerController : Controller
{
    private readonly ITimerService _timerService;

    public TimerController(ITimerService timerService)
    {
        _timerService = timerService;
    }

    public IActionResult Index()
    {
        var timer = new FitnessApp.Models.Timer(); // Creăm un nou model de Timer
        return View(timer); // Trimitem modelul către view
    }

    [HttpPost]
    public IActionResult Start()
    {
        var timer = new FitnessApp.Models.Timer();
        _timerService.StartTimer(timer);
        return RedirectToAction("Index");
    }

    [HttpPost]
    public IActionResult Stop(int id)
    {
        var timer = _timerService.GetTimer(id);
        if (timer != null && timer.IsRunning)
        {
            _timerService.StopTimer(timer);
        }
        return RedirectToAction("Index");
    }
}
