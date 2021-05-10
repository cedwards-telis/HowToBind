using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HowToBind.ViewModels
{
    public class Order
    {
        string billingAddressText;
        public string BillingAddressText
        {
            get => billingAddressText;
            set
            {
                billingAddressText = value;
                if (sameAsBillingAddress)
                    shippingAddressText = billingAddressText;
                NotifyOrderChanged();
            }
        }
        string shippingAddressText;
        public string ShippingAddressText
        {
            get => shippingAddressText;
            set
            {
                shippingAddressText = value;
                NotifyOrderChanged();
            }
        }
        bool sameAsBillingAddress;
        public bool SameAsBillingAddress
        {
            get => sameAsBillingAddress;
            set
            {
                sameAsBillingAddress = value;
                if (sameAsBillingAddress)
                    shippingAddressText = billingAddressText;
                NotifyOrderChanged();
            }
        }

        public event EventHandler OrderChanged;
        public void NotifyOrderChanged()
            => OrderChanged?.Invoke(this, EventArgs.Empty);
    }
}
