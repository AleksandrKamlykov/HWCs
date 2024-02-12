using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HWCs
{

    public class PaymentManager : IPaymentProcessor
    {

        private List<PaymentResult> AllPayments = new List<PaymentResult>();
        private Dictionary<PaymentMthods, Action<Order>> payDict = new Dictionary<PaymentMthods, Action<Order>>();

        public PaymentManager()
        {
            this.initDict();
        }

        private void initDict()
        {
            this.payDict.Add(PaymentMthods.Card, this.ProccessCard);
            this.payDict.Add(PaymentMthods.PayPal, this.ProccessPayPal);
            this.payDict.Add(PaymentMthods.Crypto, this.ProccessCrypto);
        }

        private void ProccessCard(Order order)
        {

            //Просто для разных вариантов
            if (new Random().Next(0,10) > 7)
            {

                PaymentResult res = new PaymentResult(order.Summ, order.Client.Name, order.method, PaymentStatus.Success);
                 this.AllPayments.Add(res);
            }
            else
            {
                PaymentResult res = new PaymentResult(order.Summ, order.Client.Name, order.method, PaymentStatus.Denie);

                this.AllPayments.Add(res);
            }
        }
        private void ProccessCrypto(Order order)
        {

            //Просто для разных вариантов
            if (new Random().Next(0, 10) > 7)
            {
                this.AllPayments.Add(new PaymentResult(order.Summ, order.Client.Name, order.method, PaymentStatus.Success));
            }
            else
            {
                this.AllPayments.Add(new PaymentResult(order.Summ, order.Client.Name, order.method, PaymentStatus.Denie));
            }
        }
        private void ProccessPayPal(Order order)
        {

            //Просто для разных вариантов
            if (new Random().Next(0, 10) > 7)
            {
                this.AllPayments.Add(new PaymentResult(order.Summ, order.Client.Name, order.method, PaymentStatus.Success));
            }
            else
            {
                this.AllPayments.Add(new PaymentResult(order.Summ, order.Client.Name, order.method, PaymentStatus.Denie));
            }
        }

        public void ProcessPayment(Order order)
        {

             payDict[order.method](order);
        }

        public void showAllPayments()
        {
            foreach(var item in this.AllPayments)
            {
                Console.WriteLine($"Client: {item.ClientName} | Summ: {item.Summ} | type: {item.Method} | status: {item.Status}");
            }
        }
    }

   public class Order
    {
        public Order(User client, float summ)
        {
            Client = client;
            Summ = summ;
            this.prepareMethod(summ);

        }

        void prepareMethod(float summ)
        {
            if (summ > 100) this.method = PaymentMthods.PayPal;
            else if (summ >1000) this.method= PaymentMthods.Crypto;
            else this.method= PaymentMthods.Card;

        }

        public PaymentMthods method;
        public float Summ;
        public User Client;
    }
    public class User
    {
        public User(string name)
        {
            Name = name;
        }
        public string Name { get; set; }
    }

    public class PaymentResult
    {

        public PaymentResult(float summ,string clientName, PaymentMthods paymentMethod, PaymentStatus paymentStatus)
        {
            Status = paymentStatus;
            Summ = summ;
            ClientName = clientName;
            Method = paymentMethod;
        }

        public PaymentStatus Status { get; set; }
        public PaymentMthods Method { get; set; }
        public float Summ { get; set; }
        public string ClientName { get; set; }
    }
}
