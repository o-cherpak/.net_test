using hello_1;

Bank bank = new Bank();

bank.AddCustomer("Bobik");

var customer = bank.GetCustomers().First();

customer.CreateAccount(type: Customer.Account.Saving, 100);
customer.CreateAccount(type: Customer.Account.Checking, 400);
customer.CreateAccount(type: Customer.Account.Checking, 120);

bank.Transfer(customer.Accounts[1], customer.Accounts[2], 100);

var lastTransaction = bank.GetLastTransactions()[0];

lastTransaction.AccountFrom.GetInfo();
lastTransaction.AccountFrom.GetInfo();
Console.WriteLine(lastTransaction.Amount);
Console.WriteLine(lastTransaction.SendTime);