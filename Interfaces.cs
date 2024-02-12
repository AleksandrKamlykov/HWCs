using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HWCs
{
    public interface IPaymentProcessor
    {
        public void ProcessPayment(Order order);
    }
}
