using InspectionAPI.DataModels;
using Microsoft.AspNetCore.Mvc;
using System.Linq;
namespace InspectionAPI.Controllers
{
    public class InscpectionController : Controller
    {
        private readonly Inspection inspection;
        public InscpectionController(Inspection inspection)
        {
            this.inspection = inspection;
        }
        public IActionResult Inspection { get; private set; }

        [HttpGet]
        [Route("[controller]")]
        public async Task<IActionResult> GetInspection()
        {
            return Ok(await );
        }
    }
}
