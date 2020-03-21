namespace WebApi.Responses
{
    public class HttpResponse
    {
        public string Status { get; set; }
        public string Description { get; set; }

        public HttpResponse(ResponseStatus status, string description)
        {
            Status = status == ResponseStatus.Success ? "ok" : "error";
            Description = description;
        }

        public HttpResponse(string description) : this(ResponseStatus.Success, description)
        {
        }
        
    }

    public enum ResponseStatus
    {
        Success = 1,
        Error = 2
    };
}