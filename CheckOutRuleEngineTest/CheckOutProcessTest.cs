using CheckOutRuleEngine.Rules;
using CheckOutRuleEngine.Service;
using CheckOutRuleEngine.Shared;
using CheckOutRuleEngine.Shared.Entities;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Collections.Generic;
using System.IO;
using System.Text.Json;

namespace CheckOutRuleEngineTest
{
    [TestClass]
    public class CheckOutProcessTest
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

        [TestMethod]
        public void ScenarioATest()
        {
            //Mock data
            List<CartItems> cartItems = new List<CartItems>();
            cartItems.Add(new CartItems() { Item = "A", Quantity = 1, Price = 50 });
            cartItems.Add(new CartItems() { Item = "B", Quantity = 1, Price = 30 });
            cartItems.Add(new CartItems() { Item = "C", Quantity = 1, Price = 20 });
            var jsonString = File.ReadAllText(@"..\..\..\MockData\RuleConfig.json");
            var rules = JsonSerializer.Deserialize<RuleEntity>(jsonString);

            var ruleInstance = RuleFactory.GetInstance(CheckOutProcessRuleType.PromotionRule);
            var totalCost = ruleInstance.ComputeTotalAsync(cartItems,rules);
            Assert.AreEqual(100, totalCost);
        }

        [TestMethod]
        public void ScenarioBTest()
        {
            //Mock data
            List<CartItems> cartItems = new List<CartItems>();
            cartItems.Add(new CartItems() { Item = "A", Quantity = 5, Price = 50 });
            cartItems.Add(new CartItems() { Item = "B", Quantity = 5, Price = 30 });
            cartItems.Add(new CartItems() { Item = "C", Quantity = 1, Price = 20 });
            var jsonString = File.ReadAllText(@"..\..\..\MockData\RuleConfig.json");
            var rules = JsonSerializer.Deserialize<RuleEntity>(jsonString);

            var ruleInstance = RuleFactory.GetInstance(CheckOutProcessRuleType.PromotionRule);
            var totalCost = ruleInstance.ComputeTotalAsync(cartItems, rules);
            Assert.AreEqual(370, totalCost);
        }

        [TestMethod]
        public void ScenarioCTest()
        {
            //Mock data
            List<CartItems> cartItems = new List<CartItems>();
            cartItems.Add(new CartItems() { Item = "A", Quantity = 3, Price = 50 });
            cartItems.Add(new CartItems() { Item = "B", Quantity = 5, Price = 30 });
            cartItems.Add(new CartItems() { Item = "C", Quantity = 1, Price = 20 });
            cartItems.Add(new CartItems() { Item = "D", Quantity = 1, Price = 20 });
            var jsonString = File.ReadAllText(@"..\..\..\MockData\RuleConfig.json");
            var rules = JsonSerializer.Deserialize<RuleEntity>(jsonString);

            var ruleInstance = RuleFactory.GetInstance(CheckOutProcessRuleType.PromotionRule);
            var totalCost = ruleInstance.ComputeTotalAsync(cartItems, rules);
            Assert.AreEqual(280, totalCost);
        }
    }
}
