﻿using System;

namespace warehouses.Models
{
	public class Zamowienie
	{
		public int IdOrder { get; set; }
		public int IdProduct { get; set; }
		public int Amount { get; set; }
		public DateTime CreatedAt { get; set; }
		public DateTime? FulfilledAt { get; set; }
	}
}
