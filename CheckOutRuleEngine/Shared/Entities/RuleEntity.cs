using System;
using System.Collections.Generic;
using System.Text;

namespace CheckOutRuleEngine.Shared.Entities
{
    // Root myDeserializedClass = JsonConvert.DeserializeObject<Root>(myJsonResponse); 
    public class Item
    {
        public string ItemName { get; set; }
        public string Quantity { get; set; }
        public string Price { get; set; }

    }

    public class ComboItem
    {
        public string ItemName { get; set; }
        public string Quantity { get; set; }

    }

    public class Combo
    {
        public List<ComboItem> ComboItem { get; set; }
        public string Price { get; set; }

    }

    public class Rule
    {
        public string RuleName { get; set; }
        public List<Item> Item { get; set; }
        public List<Combo> Combo { get; set; }

    }

    public class RuleTree
    {
        public string RuleType { get; set; }
        public List<Rule> Rules { get; set; }

    }

    public class RuleEntity
    {
        public List<RuleTree> RuleTree { get; set; }

    }
}
