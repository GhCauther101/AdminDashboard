namespace AdminDashboard.Entity.Event.Querying;

public class CurrencyWebReply<T>
{
    public CurrencyWebReply()
    { }

    public CurrencyWebReply(bool isSuccess, T data)
    {
        IsSuccess = isSuccess;
        Data = data;
    }

    public CurrencyWebReply(bool isSuccess, Exception exception)
    {
        IsSuccess = isSuccess;
        ErrorMessage = exception.Message;
    }

    public bool IsSuccess { get; set; }

    public T Data { get; set; }

    public string? ErrorMessage { get; set; }
}