using HandsOnAPIUsingStatusCodes.DTOs;

namespace HandsOnAPIUsingStatusCodes.Models
{
    public interface IAccountRepository
    {
        Account GetById(int id);
        IEnumerable<Account> GetAll();
        Account Create(CreateAccountDto dto);
        Account Update(int id, UpdateAccountDto dto);
        void Delete(int id);
        bool AccountNumberExists(string accountNumber);
    }

}
