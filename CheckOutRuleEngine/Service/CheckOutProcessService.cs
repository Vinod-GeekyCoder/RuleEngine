using CheckOutRuleEngine.Rules;
using CheckOutRuleEngine.Service.IService;
using CheckOutRuleEngine.Shared;
using System;
using System.Collections.Generic;
using System.Text;

namespace CheckOutRuleEngine.Service
{
    public class CheckOutProcessService : ICheckOutProcessService
    {
        public long ComputeTotal(List<Shared.Entities.CartItems> cartItems)
        {
            var ruleInstance = RuleFactory.GetInstance(CheckOutProcessRuleType.PromotionRule);
            var rules = ruleInstance.ExecuteRuleAsync();
            var totalCost = ruleInstance.ComputeTotalAsync(cartItems, rules);
            return totalCost;
        }
    }
}
