using EFMigration.Data.Entities;
using EFMigration.Data.UnitOfWork;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Threading.Tasks;

namespace EFMigration.Auto.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ValuesController : ControllerBase
    {
        private readonly IUnitOfWorkIntegrationLog _unitOfWork;

        public ValuesController(IUnitOfWorkIntegrationLog unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        [HttpGet]
        public async Task<IActionResult> Get()
        {
            var result = await _unitOfWork.GetRepository<DynamicContent>().Table.ToListAsync();

            return Ok(result);
        }
    }
}