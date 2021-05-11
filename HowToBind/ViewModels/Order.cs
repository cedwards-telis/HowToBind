using Cortex.Net.Api;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HowToBind.ViewModels
{
    [Observable]
    public class Order
    {
        public Order()
        {
            CurrentBillingAddrees = new(this);
            CurrentShippingAddress = new(this);
        }
        public BillingAddress CurrentBillingAddrees { get; set; }
        [Observable]
        public class BillingAddress
        {
            Order _parent;
            public BillingAddress(Order parent)
            {
                _parent = parent;
            }
            public string BillingAddressText { get; set; }
        }
        public ShippingAddress CurrentShippingAddress { get; set; }
        [Observable]
        public class ShippingAddress
        {
            Order _parent;
            public ShippingAddress(Order parent)
            {
                _parent = parent;
            }

            private string shippingAddressText;
            [Computed]
            public string ShippingAddressText
            {
                get => SameAsBillingAddress ? _parent.CurrentBillingAddrees.BillingAddressText : shippingAddressText;
                set => shippingAddressText = value;
            }
            public bool SameAsBillingAddress { get; set; }
        }
    }
}
