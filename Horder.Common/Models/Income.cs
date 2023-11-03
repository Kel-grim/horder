namespace Horder.Common.Models;

public class Income
{
    #region Constructors

    public Income()
    {
        
    }

    #endregion

    #region Public Properties

    public Guid IncomeId { get; set; }

    public string IncomeName { get; set; }
    
    public Guid IncomeTypeId { get; set; }

    public decimal IncomeAmount { get; set; }

    public DateTime IncomeDate { get; set; }

    public Guid AccountId { get; set; }

    #endregion
}