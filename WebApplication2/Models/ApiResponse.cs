using System.Net;

namespace WebApplication2.Models
{
    public class ApiResponse
    {
        public HttpStatusCode statusCode { get; set; } = HttpStatusCode.OK;
        public bool IsSuccess { get; set; } = true;

        public List<string> Errors { get; set; }

        public object Result { get; set; }
        public ApiResponse() 
        {
            Errors = new List<string>();
        }

    }
}
