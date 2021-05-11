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

            [Action]
            public void UpdateBillingAddress(string BillingAddressText)
            {
                this.BillingAddressText = BillingAddressText;
                if (_parent.CurrentShippingAddress.SameAsBillingAddress)
                {
                    _parent.CurrentShippingAddress.ShippingAddressText = BillingAddressText;
                }
            }
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
            public string ShippingAddressText { get; set; }
            public bool SameAsBillingAddress { get; set; }

            [Action]
            public void UpdateSameAsBillingAddress(bool Value)
            {
                this.SameAsBillingAddress = Value;
                if (this.SameAsBillingAddress)
                {
                    this.ShippingAddressText = _parent.CurrentBillingAddrees.BillingAddressText;
                }
            }
        }
    }
}
