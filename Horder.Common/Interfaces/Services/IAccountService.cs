using Horder.Common.Models;

namespace Horder.Common.Interfaces.Services;

public interface IAccountService
{
    List<Account> Get();

    Account GetSingle(Guid accountId);

    ServiceResult<Account> Insert(Account account);
    
    ServiceResult<Account> Update(Account account);
    
    bool Delete(Guid accountId);
}