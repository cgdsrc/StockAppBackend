using System;
namespace StockApp.Model
{
    public class ValidateOrderRequest
    {
        public int Balance { get; set; }
        public int Order { get; set; }
        public int StockId { get; set; }

    }
}