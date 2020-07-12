using CheckOutRuleEngine.Shared.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace CheckOutRuleEngine.Service.IService
{
    public interface ICheckOutProcessService
    {
        long ComputeTotal(List<CartItems> cartItems);
    }
}
