using hello_1;

Bank bank = new Bank();
// await bank.LoadTransactions();


bank.AddCustomer("Bobik");

var customer = bank.GetCustomers().First();

customer.CreateAccount(type: Customer.Account.Saving, 100);
customer.CreateAccount(type: Customer.Account.Checking, 400);
customer.CreateAccount(type: Customer.Account.Checking, 120);

// await bank.SaveTransactions();