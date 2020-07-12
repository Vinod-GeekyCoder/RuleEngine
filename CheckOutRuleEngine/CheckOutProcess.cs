using CheckOutRuleEngine.Rules;
using CheckOutRuleEngine.Service;
using CheckOutRuleEngine.Service.IService;
using CheckOutRuleEngine.Shared;
using CheckOutRuleEngine.Shared.Entities;
using System;
using System.Collections.Generic;

namespace CheckOutRuleEngine
{
    public class CheckOutProcess
    {
        public static void Main(string[] args)
        {
            ICheckOutProcessService checkOutProcessService = new CheckOutProcessService();

            //Static input 
            List<CartItems> cartItems = new List<CartItems>();
            cartItems.Add(new CartItems() { Item = "A", Quantity = 3, Price = 150 });
            cartItems.Add(new CartItems() { Item = "C", Quantity = 1, Price = 20 });
            cartItems.Add(new CartItems() { Item = "D", Quantity = 1, Price = 15 });

            var total = checkOutProcessService.ComputeTotal(cartItems);
            Console.WriteLine(total);
        }
    }
}
