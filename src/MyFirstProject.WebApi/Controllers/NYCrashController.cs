using Microsoft.AspNetCore.Mvc;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using MyFirstProject.Shared.Models;
using MyFirstProject.WebApi.Context;

namespace MyFirstProject.WebApi.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class NYCrashController : ControllerBase
    {
        private readonly ILogger<NYCrashController> _logger;
        private readonly NYCrashItemContext _context;

        public NYCrashController(ILogger<NYCrashController> logger, NYCrashItemContext context)
        {
            //testes
            _logger = logger;
            _context = context;
        }
        //Get all Records from NYCrashItems with Page parameter
        //Implementar uma paginacao via COPILOT
        [HttpGet]
        public async Task<ActionResult<IEnumerable<NYCrashItem>>> GetNYCrashItems(int page = 1)
        {
            _logger.LogInformation("Method - GetNYCrashItems");
            var nyCrashItems = await _context.NYCrashItems.Skip((page - 1) * 10).Take(100).ToListAsync();

            if (nyCrashItems == null)
            {
                return NotFound();
            }

            return nyCrashItems;
        }
        
    
        //Get item by YEAR
        [HttpGet("{year}")]
        public async Task<ActionResult<IEnumerable<NYCrashItem>>> GetNYCrashItemByYear(string year)
        {
            _logger.LogInformation("Method - GetNYCrashItemByYear");
            var nyCrashItem = await _context.NYCrashItems.Where(x => x.CRASH_DATE.EndsWith(year)).ToListAsync();

            if (nyCrashItem == null)
            {
                return NotFound();
            }

            return nyCrashItem;
        }

        /*
           Descriptive Statistics:
             Desenvolver uma API que retorne o numero de pedestretres mortas por ano
             remover os campos nulos
         */
        [HttpGet("descriptive-statistics")]
        public async Task<ActionResult<IEnumerable<NYCrashItem>>> GetNYCrashItemDescriptiveStatistics()
        {
            _logger.LogInformation("Method - GetNYCrashItemDescriptiveStatistics");
            var nyCrashItem = await _context.NYCrashItems.GroupBy(x => x.CRASH_DATE.Substring(6, 4))
                .Select(x => new NYCrashItem
                {
                    CRASH_DATE = x.Key,
                    NUMBER_OF_CYCLIST_INJURED = x.Sum(y => y.NUMBER_OF_CYCLIST_INJURED)
                }).ToListAsync();

            if (nyCrashItem == null)
            {
                return NotFound();
            }

            return nyCrashItem;
        }

       
       

    }
}
