using System;
using System.Threading.Tasks;
using warehouses.Models;
using warehouses.Models.DTO;

namespace warehouses.Services
{
	public interface IDatabaseService
	{
		Task<bool> ProductExistsAsync(int idProduct);
		Task<Zamowienie> GetOrderAsync(int idProduct, int amount, DateTime createdAt);
		Task<bool> IsOrderCompletedAsync(Zamowienie order);
		Task<int> RegisterWarehouseProductAsync(int idOrder, ProduktDto productDto);
		Task<int> RegisterWarehouseProductAsync(ProduktDto productDto);
	}
}
