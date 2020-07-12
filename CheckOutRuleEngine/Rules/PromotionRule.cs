using CheckOutRuleEngine.Shared;
using CheckOutRuleEngine.Shared.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace CheckOutRuleEngine.Rules
{
    public class PromotionRule : CheckOutProcessRule
    {
        public override long ComputeTotalAsync(List<CartItems> cartItems, RuleEntity ruleParams)
        {
            long totalCost = 0;
            var tmpCart = cartItems;
            foreach (var ruleTree in ruleParams.RuleTree)
            {
                if (ruleTree.RuleType == CheckOutProcessRuleType.PromotionRule.ToString())
                {
                    foreach (var rule in ruleTree.Rules)
                    {
                        if (rule.RuleName == "SingleProduct")
                        {
                            List<CartItems> itemsToRemove = new List<CartItems>();
                            foreach (var item in cartItems)
                            {
                                var query = rule.Item.Where(r => r.ItemName == item.Item && Convert.ToInt32(r.Quantity) >= item.Quantity).FirstOrDefault();
                                if (query != null)
                                {
                                    var cost = Convert.ToInt32(query.Quantity) == item.Quantity ? Convert.ToInt32(query.Price) : CalculateItemPrice(query, item);
                                    totalCost += cost;
                                    itemsToRemove.Add(item);
                                }
                            }
                            itemsToRemove.ForEach(i => tmpCart.Remove(i));
                        }
                        if (rule.RuleName == "Combined")
                        {
                            foreach (var item in rule.Combo)
                            {
                                var itemOne = item.ComboItem.OrderByDescending(o => o.ItemName).FirstOrDefault();
                                var itemTwo = item.ComboItem.OrderByDescending(o => o.ItemName).LastOrDefault();
                                var cartItemOne = tmpCart.Where(t => t.Item == itemOne.ItemName && t.Quantity >= Convert.ToInt32(itemOne.Quantity)).FirstOrDefault();
                                var cartItemTwo = tmpCart.Where(t => t.Item == itemTwo.ItemName && t.Quantity >= Convert.ToInt32(itemTwo.Quantity)).FirstOrDefault();
                                if (cartItemOne != null && cartItemTwo != null)
                                {
                                    var cost = CalculateComboItemPrice(itemOne, itemTwo, Convert.ToInt32(item.Price), cartItemOne, cartItemTwo);
                                    totalCost += cost;
                                    tmpCart.Remove(cartItemOne);
                                    tmpCart.Remove(cartItemTwo);
                                }
                            }
                        }
                    }
                    if (tmpCart.Count > 0)
                    {
                        foreach (var item in tmpCart)
                        {
                            totalCost += (item.Quantity * item.Price);
                        }
                    }
                }
            }
            return totalCost;
        }

        private int CalculateComboItemPrice(ComboItem itemOne, ComboItem itemTwo, int price, CartItems cartItemOne, CartItems cartItemTwo)
        {
            if (cartItemOne.Quantity == Convert.ToInt32(itemOne.Quantity) && cartItemTwo.Quantity == Convert.ToInt32(itemTwo.Quantity))
            {
                return price;
            }
            else
            {
                //Scenario for more quantity for combo offer
                return 0;
            }
        }

        private int CalculateItemPrice(Item query, CartItems item)
        {
            if (item.Quantity % Convert.ToInt32(query.Quantity) == 0)
            {
                return item.Quantity * Convert.ToInt32(query.Price);
            }
            else
            {
                var rem = item.Quantity % Convert.ToInt32(query.Quantity);
                var price = (item.Quantity - rem) - Convert.ToInt32(query.Price);
                price = price + (rem * item.Price);
                return price;
            }
        }
    }
}
