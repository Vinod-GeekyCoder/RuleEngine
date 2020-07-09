using CheckOutRuleEngine.Rules.IRules;
using CheckOutRuleEngine.Shared;
using System;
using System.Collections.Generic;
using System.Text;

namespace CheckOutRuleEngine.Rules
{
    /// <summary>
    /// Rule Factory
    /// </summary>
    public static class RuleFactory
    {
        /// <summary>
        /// Get Instance
        /// </summary>
        /// <param name="checkOutProcessRuleType">Check Out Process Rule Type</param>
        /// <returns>Instance of rule</returns>
        public static ICheckOutProcessRule GetInstance(CheckOutProcessRuleType checkOutProcessRuleType)
        {
            ICheckOutProcessRule checkOutProcessRule;
            switch (checkOutProcessRuleType)
            {
                case CheckOutProcessRuleType.PromotionRule:
                    checkOutProcessRule = new PromotionRule();
                    break;
                default:
                    checkOutProcessRule = new CheckOutProcessRule();
                    break;
            }
            return checkOutProcessRule;
        }
    }
}
