using System.Net;
using System.Xml.Serialization;

namespace CarRental.Services.Services
{
    public class OperationResult<T> : IOperationResult<T>
    {
        public bool Success { get; set; }
        public string Message { get; set; }
        public int Code { get; set; }
        public T Data { get; set; }
        public OperationResult(T data)
        {
            Success = true;
            Code = (int) HttpStatusCode.OK;
            Data = data;
        }
        public OperationResult(bool success, string message = "", int code = (int) HttpStatusCode.NotFound, T data = default(T))
        {
            Success = success;
            Message = message;
            Code = code;
            Data = data;
        }
    }
    public class OperationResult : IOperationResult
    {
        public bool Success { get; set; }
        public string Message { get; set; }
        public int Code { get; set; }
        public OperationResult(bool success)
        {
            Success = success;
            Code = success ? (int) HttpStatusCode.OK : (int) HttpStatusCode.NotFound;
        }
        public OperationResult(bool success, string message, int code = (int) HttpStatusCode.NotFound)
        {
            Success = success;
            Message = message;
            Code = code;
        }
    }
}