using HandsOnAPIUsingStatusCodes.DTOs;

namespace HandsOnAPIUsingStatusCodes.Models
{
    public class AccountRepository : IAccountRepository
    {
        private readonly List<Account> _accounts;
        private int _nextId = 1;

        public AccountRepository()
        {
            // Seed sample data for demo
            _accounts = new List<Account>
        {
            new Account { Id = 1, AccountNumber = "ACC1001", HolderName = "John Doe", Balance = 5000 },
            new Account { Id = 2, AccountNumber = "ACC1002", HolderName = "Ravi Kumar", Balance = 7500 }
        };

            _nextId = 3;
        }

        // -----------------------
        // GET / Find Account
        // -----------------------
        public Account GetById(int id)
        {
            return _accounts.FirstOrDefault(a => a.Id == id);
        }

        // -----------------------
        // GET ALL
        // -----------------------
        public IEnumerable<Account> GetAll()
        {
            return _accounts;
        }

        // -----------------------
        // CREATE ACCOUNT
        // -----------------------
        public Account Create(CreateAccountDto dto)
        {
            var newAccount = new Account
            {
                Id = _nextId++,
                AccountNumber = dto.AccountNumber,
                HolderName = dto.HolderName,
                Balance = dto.InitialBalance
            };

            _accounts.Add(newAccount);
            return newAccount;
        }

        // -----------------------
        // UPDATE ACCOUNT
        // -----------------------
        public Account Update(int id, UpdateAccountDto dto)
        {
            var account = _accounts.FirstOrDefault(a => a.Id == id);

            if (account == null)
                return null;

            if (!string.IsNullOrEmpty(dto.HolderName))
                account.HolderName = dto.HolderName;

            account.Balance = dto.Balance;

            return account;
        }

        // -----------------------
        // DELETE ACCOUNT
        // -----------------------
        public void Delete(int id)
        {
            var account = _accounts.FirstOrDefault(a => a.Id == id);
            if (account != null)
            {
                _accounts.Remove(account);
            }
        }

        // -----------------------
        // CHECK DUPLICATE ACCOUNT NUMBER
        // -----------------------
        public bool AccountNumberExists(string accountNumber)
        {
            return _accounts.Any(a => a.AccountNumber.Equals(accountNumber, StringComparison.OrdinalIgnoreCase));
        }
    }

}
