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
        public BillingAddress CurrentBillingAddress { get; set; } = new();
        [Observable]
        public class BillingAddress
        {
            public string BillingAddressText { get; set; }
        }

        public ShippingAddress CurrentShippingAddress { get; set; } = new();
        [Observable]
        public class ShippingAddress
        {
            public string ShippingAddressText { get; set; }
            public bool SameAsBillingAddress { get; set; }
        }

        [Computed]
        public string ComputedShippingAddressText => CurrentShippingAddress.SameAsBillingAddress ? 
            CurrentBillingAddress.BillingAddressText : CurrentShippingAddress.ShippingAddressText;
    }
}
