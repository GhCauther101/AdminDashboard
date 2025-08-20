namespace AdminDashboard.Entity.Event.Querying;

public class ClientWebReply<T>
{
    public ClientWebReply()
    {}

    public ClientWebReply(bool isSuccess, T data)
    {
        IsSuccess = isSuccess;
        Data = data;
    }

    public ClientWebReply(bool isSuccess, Exception exception)
    {
        IsSuccess = isSuccess;
        ErrorMessage = exception.Message;
    }

    public bool IsSuccess { get; set; }
    
    public T Data { get; set; }

    public string? ErrorMessage { get; set; }
}