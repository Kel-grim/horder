using Horder.Common.Interfaces.Repositories;
using Horder.Common.Interfaces.Services;
using Horder.Common.Models;

namespace Horder.Service;

public class AccountService : ServiceBase, IAccountService
{
    #region Constructors

    public AccountService(IAccountRepository accountRepository)
    {
        this._accountRepository = accountRepository;
    }

    #endregion

    #region Private Properties

    private IAccountRepository _accountRepository { get; }

    #endregion
    
    #region Public Methods

    public List<Account> Get()
    {
        var accounts = new List<Account>();

        accounts = this._accountRepository.Get();

        return accounts;
    }

    public Account GetSingle(Guid accountId)
    {
        if (accountId == Guid.Empty)
        {
            throw new ArgumentException(nameof(accountId));
        }
        
        Account account = null;

        account = this._accountRepository.GetSingle(accountId);

        return account;
    }

    public ServiceResult<Account> Insert(Account account)
    {
        if (account == null)
        {
            throw new ArgumentNullException(nameof(account));
        }

        var serviceResult = new ServiceResult<Account>();
        
        // Validate Account Info
        serviceResult.ValidationSuccess = true;

        if (serviceResult.ValidationSuccess)
        {
            serviceResult.Success = this._accountRepository.Insert(account);
        }
        else
        {
            // Add Messages
        }

        return serviceResult;
    }

    public ServiceResult<Account> Update(Account account)
    {
        if (account == null)
        {
            throw new ArgumentNullException(nameof(account));
        }

        var serviceResult = new ServiceResult<Account>();
        
        // Validate Account Info
        serviceResult.ValidationSuccess = true;

        if (serviceResult.ValidationSuccess)
        {
            serviceResult.Success = this._accountRepository.Update(account);
        }
        else
        {
            // Add Messages
        }

        return serviceResult;
    }

    public bool Delete(Guid accountId)
    {
        if (accountId == Guid.Empty)
        {
            throw new ArgumentException(nameof(accountId));
        }
        
        return this._accountRepository.Delete(accountId);
    }

    #endregion
}