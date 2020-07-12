using System;
using System.Collections.Generic;
using System.Text;

namespace CheckOutRuleEngine.Shared.Entities
{
    public class CartItems
    {
        /// <summary>
        /// Gets or sets the Item.
        /// </summary>
        /// <value>
        /// The Item.
        /// </value>
        public string Item { get; set; }

        /// <summary>
        /// Gets or sets the Quantity.
        /// </summary>
        /// <value>
        /// The Quantity.
        /// </value>
        public int Quantity { get; set; }

        /// <summary>
        /// Gets or sets the Price.
        /// </summary>
        /// <value>
        /// The Price.
        /// </value>
        public int Price { get; set; }
    }
}
