using CheckOutRuleEngine.Rules;
using CheckOutRuleEngine.Shared;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace CheckOutRuleEngineTest
{
    [TestClass]
    public class RuleFactoryTest
    {
        /// <summary>
        /// Create Rule Factory Instance Test
        /// </summary>
        [TestMethod]
        public void CreateRuleFactoryInstanceTest()
        {
            var ruleInstance = RuleFactory.GetInstance(CheckOutProcessRuleType.PromotionRule);
            Assert.IsInstanceOfType(ruleInstance, typeof(PromotionRule));
        }
    }
}
