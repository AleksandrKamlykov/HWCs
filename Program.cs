

using HWCs;

User oleksandr = new User("Oleksandr");
User tom = new User("Tom");
User grisha = new User("Grisha");

Order order1 = new Order(oleksandr, 90);
Order order2 = new Order(oleksandr, 120);
Order order3 = new Order(tom, 50);
Order order4 = new Order(tom, 1290);
Order order5 = new Order(grisha, 10);

PaymentManager paymentManager = new PaymentManager();

paymentManager.ProcessPayment(order1);
paymentManager.ProcessPayment(order2);
paymentManager.ProcessPayment(order3);
paymentManager.ProcessPayment(order4);
paymentManager.ProcessPayment(order5);

paymentManager.showAllPayments();