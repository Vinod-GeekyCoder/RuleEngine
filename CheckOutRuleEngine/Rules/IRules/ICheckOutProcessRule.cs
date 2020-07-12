using CheckOutRuleEngine.Shared.Entities;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace CheckOutRuleEngine.Rules.IRules
{
    public interface ICheckOutProcessRule
    {
        /// <summary>
        /// Executes the rule.
        /// </summary>
        /// <returns> The task</returns>
        RuleEntity ExecuteRuleAsync();

        long ComputeTotalAsync(List<CartItems> input,RuleEntity ruleEntity);
    }
}
