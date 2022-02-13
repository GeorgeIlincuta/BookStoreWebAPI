using BookStore.Data.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace BookStore.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class LogsController : ControllerBase
    {
        private LogsService _logsService;
        public LogsController(LogsService logsService)
        {
            _logsService = logsService;
        }

        [HttpGet("get-all-logs-from-db")]
        public IActionResult GetAllLogsFromDB()
        {
            try
            {
                var allLogs = _logsService.GetAllLogsFromDB();
                return Ok(allLogs);
            }
            catch (System.Exception)
            {

                return BadRequest("Could not load logs from the database");
            }
        }
    }
}
