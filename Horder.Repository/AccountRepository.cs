using Horder.Common.Interfaces.Repositories;
using Horder.Common.Models;
using Npgsql;

namespace Horder.Repository;

public class AccountRepository : RepositoryBase, IAccountRepository
{
    #region Constructors

    public AccountRepository()
    {
        
    }

    #endregion
    
    #region Public Methods

    public List<Account> Get()
    {
        var accounts = new List<Account>();

        var sql = "select accountId, accountFirstName, accountLastName, accountEmail from account";

        using (var connection = new NpgsqlConnection(this._connectionString))
        {
            using (var command = new NpgsqlCommand(sql, connection))
            {
                connection.Open();

                using (var dataReader = command.ExecuteReader())
                {
                    while (dataReader.Read())
                    {
                        accounts.Add(this.ExtractAccount(dataReader));
                    }
                }
                
                connection.Close();
            }
        }

        return accounts;
    }

    public Account GetSingle(Guid accountId)
    {
        if (accountId == Guid.Empty)
        {
            throw new ArgumentException(nameof(accountId));
        }
        
        Account account = null;

        var sql = "select accountId, accountFirstName, accountLastName, accountEmail from account where accountId = @AccountId";

        using (var connection = new NpgsqlConnection(this._connectionString))
        {
            using (var command = new NpgsqlCommand(sql, connection))
            {
                command.Parameters.AddWithValue("@AccountId", accountId);
                connection.Open();

                using (var dataReader = command.ExecuteReader())
                {
                    if (dataReader.Read())
                    {
                        account = this.ExtractAccount(dataReader);
                    }
                }
                
                connection.Close();
            }
        }

        return account;
    }

    public bool Insert(Account account)
    {
        if (account == null)
        {
            throw new ArgumentNullException(nameof(account));
        }
        
        int rowsEffected = 0;
        
        var sql = "insert into account (accountId, accountFirstName, accountLastName, accountEmail) values (@AccountId, @AccountFirstName, @AccountLastName, @AccountEmail)";

        using (var connection = new NpgsqlConnection(this._connectionString))
        {
            using (var command = new NpgsqlCommand(sql, connection))
            {
                this.GetParameters(account, command);
                connection.Open();

                rowsEffected = command.ExecuteNonQuery();
                
                connection.Close();
            }
        }

        if (rowsEffected == 0)
        {
            return false;
        }

        return true;
    }

    public bool Update(Account account)
    {
        if (account == null)
        {
            throw new ArgumentNullException(nameof(account));
        }
        
        int rowsEffected = 0;
        
        var sql = "update account set accountFirstName = @AccountFirstName, accountLastName = @AccountLastName, accountEmail = @AccountEmail where accountId = @AccountId";

        using (var connection = new NpgsqlConnection(this._connectionString))
        {
            using (var command = new NpgsqlCommand(sql, connection))
            {
                this.GetParameters(account, command);
                connection.Open();

                rowsEffected = command.ExecuteNonQuery();
                
                connection.Close();
            }
        }

        if (rowsEffected == 0)
        {
            return false;
        }

        return true;
    }

    public bool Delete(Guid accountId)
    {
        if (accountId == Guid.Empty)
        {
            throw new ArgumentException(nameof(accountId));
        }
        
        int rowsEffected = 0;
        
        var sql = "delete from account where accountId = @AccountId";

        using (var connection = new NpgsqlConnection(this._connectionString))
        {
            using (var command = new NpgsqlCommand(sql, connection))
            {
                command.Parameters.AddWithValue("@AccountId", accountId);
                connection.Open();

                rowsEffected = command.ExecuteNonQuery();
                
                connection.Close();
            }
        }

        if (rowsEffected == 0)
        {
            return false;
        }

        return true;
    }

    #endregion

    #region Private Methods

    private void GetParameters(Account account, NpgsqlCommand command)
    {
        command.Parameters.AddWithValue("@AccountId", account.AccountId);
        command.Parameters.AddWithValue("@AccountFirstName", account.AccountFirstName);
        command.Parameters.AddWithValue("@AccountLastName", account.AccountLastName);
        command.Parameters.AddWithValue("@AccountEmail", account.AccountEmail);
    }

    private Account ExtractAccount(NpgsqlDataReader dataReader)
    {
        var account = new Account();

        account.AccountId = (Guid)dataReader["accountId"];
        account.AccountFirstName = (string)dataReader["accountFirstName"];
        account.AccountLastName = (string)dataReader["accountLastName"];
        account.AccountEmail = (string)dataReader["accountEmail"];
        
        return account;
    }

    #endregion
}