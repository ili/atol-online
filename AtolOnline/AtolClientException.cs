using System.Net;
using System.Runtime.Serialization;

namespace AtolOnline.Unofficial
{
    /// <summary>
    /// Исключение при работе с сервисом Атол Онлайн
    /// </summary>
    [Serializable]
    public class AtolClientException : Exception
    {
        /// <summary>
        /// Статус ответа
        /// </summary>
        public HttpStatusCode? StatusCode { get; }

        /// <summary>
        /// Ответ
        /// </summary>
        public ResponseBase? Response { get; }

        /// <summary>
        /// Специальный флаг, указывающий на то что для данных логина и пароля не поддерживается V5 версия
        /// </summary>
        public bool? V5IsNotSupported =>
            Response?.Error?.Code == 21;

        /// <summary>
        /// Конструктор
        /// </summary>
        /// <param name="message"> <inheritdoc cref="Exception.Message" path="/summary" /></param>
        public AtolClientException(string message) : base(message) { }

        /// <summary>
        /// Конструктор
        /// </summary>
        /// <param name="message"><inheritdoc cref="Exception.Message" path="/summary" /></param>
        /// <param name="statusCode"><inheritdoc cref="StatusCode" path="/summary" /></param>
        public AtolClientException(string message, HttpStatusCode statusCode)
            : base(message)
        {
            StatusCode = statusCode;
        }

        /// <summary>
        /// Конструктор
        /// </summary>
        /// <param name="message"><inheritdoc cref="Exception.Message" path="/summary" /></param>
        /// <param name="statusCode"><inheritdoc cref="StatusCode" path="/summary" /></param>
        /// <param name="innerException"><inheritdoc cref="Exception.InnerException" path="/summary" /></param>
        public AtolClientException(string message, HttpStatusCode statusCode, Exception innerException) : base(message, innerException)
        {
            StatusCode = statusCode;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="info"></param>
        /// <param name="context"></param>
        protected AtolClientException(SerializationInfo info, StreamingContext context) : base(info, context)
        {
        }

        /// <summary>
        /// Конструктор
        /// </summary>
        /// <param name="response"><inheritdoc cref="Response" path="/summary" /></param>
        /// <param name="statusCode"><inheritdoc cref="StatusCode" path="/summary" /></param>
        public AtolClientException(ResponseBase response, HttpStatusCode statusCode)
            : this(response.Error!.Text, statusCode)
        {
            Response = response;
            StatusCode = statusCode;
        }
    }
}