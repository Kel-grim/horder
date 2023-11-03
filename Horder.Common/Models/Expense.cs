namespace Horder.Common.Models;

public class Expense
{
    #region Constructors
    
    public Expense()
    {
        
    }

    #endregion

    #region Public Properties

    public Guid ExpenseId { get; set; }
    
    public string ExpenseName { get; set; }

    public Guid ExpenseTypeId { get; set; }

    public decimal ExpenseAmount { get; set; }

    public DateTime ExpenseDate { get; set; }

    public Guid AccountId { get; set; }

    #endregion
}