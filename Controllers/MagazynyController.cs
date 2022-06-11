using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using warehouses.Models.DTO;
using warehouses.Services;

namespace warehouses.Controllers
{
	[Route("[controller]")]
	[ApiController]
	public class MagazynyController : ControllerBase
	{
		private readonly IDatabaseService _databaseService;

		public MagazynyController(IDatabaseService databaseService)
		{
			_databaseService = databaseService;
		}

		[HttpPost]
		public async Task<IActionResult> RegisterWarehouseProductAsync([FromBody] ProduktDto productDto)
		{
			int id = await _databaseService.RegisterWarehouseProductAsync(productDto);

			return id > 0
				? Ok(id)
				: BadRequest(id);
		}
	}
}
