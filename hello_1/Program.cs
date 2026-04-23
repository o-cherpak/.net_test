using hello_1;
using hello_1.accounts;

Bank bank = new Bank();
await bank.LoadTransactions();

var customer = bank.GetCustomers().First();

bank.AddCustomer("Bobik");

customer.CreateAccount(type: Account.Saving, 100);
customer.CreateAccount(type: Account.Checking, 400);
customer.CreateAccount(type: Account.Checking, 120);

await bank.SaveTransactions();