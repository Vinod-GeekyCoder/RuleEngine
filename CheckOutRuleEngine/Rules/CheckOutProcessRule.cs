using CheckOutRuleEngine.Rules.IRules;
using CheckOutRuleEngine.Shared.Entities;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace CheckOutRuleEngine.Rules
{
    public class CheckOutProcessRule : ICheckOutProcessRule
    {
        public RuleEntity ExecuteRuleAsync()
        {
            return GetRules();
        }

        public virtual long ComputeTotalAsync(List<CartItems> cartItems, RuleEntity ruleParams)
        {
            return 0;
        }

        private RuleEntity GetRules()
        {
            try
            {
                var jsonString = File.ReadAllText(@"..\..\..\Config\RuleConfig.json");
                return JsonSerializer.Deserialize<RuleEntity>(jsonString);
            }
            catch(Exception ex)
            {
                Console.WriteLine(ex.Message);
                throw;
            }
        }
    }
}
