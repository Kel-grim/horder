namespace Horder.Common.Models;

public class ServiceResult<T> where T : new()
{
    #region Constructors

    public ServiceResult()
    {
        this.Messages = new List<Message>();
        this.ValidationSuccess = false;
        this.Success = false;
    }

    #endregion

    #region Public Properties

    public bool Success { get; set; }
    
    public bool ValidationSuccess { get; set; }

    public T Object { get; set; }

    public List<Message> Messages { get; set; }

    #endregion
}