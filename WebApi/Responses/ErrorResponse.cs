using WebApi.Responses.Abstract;

namespace WebApi.Responses
{
    public class ErrorResponse: IInformationResponse
    {
        public string Status { get; set; }
        public string Description { get; set; }

        public ErrorResponse(string status, string description)
        {
            Status = status;
            Description = description;
        }

        public ErrorResponse(string description): this("error", description)
        {
        }   
    }
}