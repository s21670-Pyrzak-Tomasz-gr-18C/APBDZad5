using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using warehouses.Models.DTO;
using warehouses.Services;

namespace warehouses.Controllers
{
	[Route("[controller]")]
	[ApiController]
	public class Magazyny2Controller : ControllerBase
	{
		private readonly IDatabaseService _databaseService;

		public Magazyny2Controller(IDatabaseService databaseService)
		{
			_databaseService = databaseService;
		}

		[HttpPost]
		public async Task<IActionResult> RegisterWarehouseProductAsync([FromBody] ProduktDto productDto)
		{
			if (!await _databaseService.ProductExistsAsync(productDto.IdProduct))
				return NotFound($"Couldn't find product of ID '{productDto.IdProduct}'");

			var order = await _databaseService
				.GetOrderAsync(productDto.IdProduct, productDto.Amount, productDto.CreatedAt);

			if (order == null)
				return NotFound($"Couldn't find order for product of ID '{productDto.IdProduct}'");

			if (await _databaseService.IsOrderCompletedAsync(order))
				return UnprocessableEntity($"Order of ID {order.IdOrder} has been completed");

			int id = await _databaseService.RegisterWarehouseProductAsync(order.IdOrder, productDto);

			return id > 0
				? Ok(id)
				: BadRequest(id);
		}
	}
}
