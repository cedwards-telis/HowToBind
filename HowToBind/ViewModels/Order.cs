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
        public string BillingAddressText { get; set; }
        public string ShippingAddressText { get; set; }
        public bool SameAsBillingAddress { get; set; }
        [Computed]
        public string ComputedShippingAddressText => SameAsBillingAddress ?
            BillingAddressText : ShippingAddressText;
    }
}
