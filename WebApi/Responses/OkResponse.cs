using WebApi.Responses.Abstract;

namespace WebApi.Responses
{
    public class OkResponse : IInformationResponse
    {
        public string Status { get; set; }
        public string Description { get; set; }

        public OkResponse(string status, string description)
        {
            Status = status;
            Description = description;
        }

        public OkResponse(string description): this("ok", description)
        {
        }   
    }
}