using AtolOnline.V5.Entities;
using System.Net;
using System.Runtime.Serialization;

namespace AtolOnline.V5.Client
{
    [Serializable]
    public class AtolClientException : Exception
    {
        public HttpStatusCode? StatusCode { get; }
        public ResponseBase? Response { get; }

        public AtolClientException(string message, HttpStatusCode statusCode)
            : base(message)
        {
            StatusCode = statusCode;
        }

        public AtolClientException(string message, HttpStatusCode statusCode, Exception innerException) : base(message, innerException)
        {
            StatusCode = statusCode;
        }

        protected AtolClientException(SerializationInfo info, StreamingContext context) : base(info, context)
        {
        }

        public AtolClientException(ResponseBase response, HttpStatusCode statusCode)
            : this(response.Error!.Text, statusCode) 
        {
            Response = response;
            StatusCode = statusCode;
        }
    }
}