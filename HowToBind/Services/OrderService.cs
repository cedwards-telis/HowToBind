using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HowToBind.Services
{
    public class OrderService
    {
        public string ShippingAddress
        {
            get => _ShippingAddress;
            set
            {
                if (!_ShippingAddress.Equals(value))
                {
                    NotifyOrderChanged();
                    _ShippingAddress = value;
                }
            }
        }
        private string _ShippingAddress = string.Empty;


        public string BillingAddress
        {
            get => _BillingAddress;
            set
            {
                if (!_BillingAddress.Equals(value))
                {
                    NotifyOrderChanged();
                    _BillingAddress = value;
                    if (_sameAsBillingAddress)
                        ShippingAddress = BillingAddress;
                }
            }
        }
        private string _BillingAddress = string.Empty;

        public bool SameAsBillingAddress
        {
            get => _sameAsBillingAddress;
            set
            {
                if (value != _sameAsBillingAddress)
                {
                    if (value)
                        ShippingAddress = BillingAddress;
                    NotifyOrderChanged();
                    _sameAsBillingAddress = value;
                }
            }
        }

        private bool _sameAsBillingAddress;

        public event EventHandler OrderChanged;

        public void NotifyOrderChanged()
            => OrderChanged.Invoke(this, EventArgs.Empty);
    }
}
