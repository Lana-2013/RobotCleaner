using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using RobotCleaner.WebAPI.Models;

namespace RobotVacuum.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class RobotController : ControllerBase
    {
        private readonly ILogger<RobotController> _logger;
        private IRobotTracker _tracker;

        public RobotController(ILogger<RobotController> logger, IRobotTracker tracker)
        {
            _logger = logger;
            _tracker = tracker;

        }        
    }
}
