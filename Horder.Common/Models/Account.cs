namespace Horder.Common.Models;

public class Account
{
    #region Constructors

    public Account()
    {
        
    }

    #endregion

    #region Public Properties

    public Guid AccountId { get; set; }

    public string AccountFirstName { get; set; }

    public string AccountLastName { get; set; }

    public string AccountEmail { get; set; }

    #endregion
}