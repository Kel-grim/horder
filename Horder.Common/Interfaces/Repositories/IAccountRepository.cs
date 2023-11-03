using Horder.Common.Models;

namespace Horder.Common.Interfaces.Repositories;

public interface IAccountRepository
{
    List<Account> Get();

    Account GetSingle(Guid accountId);

    bool Insert(Account account);
    
    bool Update(Account account);
    
    bool Delete(Guid accountId);
}