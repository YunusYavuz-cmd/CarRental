using System.Xml.Serialization;

namespace CarRental.Services.Services
{
    public interface IOperationResult<T>
    {
        bool Success { get; set; }
        string Message { get; set; }
        int Code { get; set; }
        T Data { get; set; }
    }

    public interface IOperationResult
    {
        bool Success { get; set; }
        string Message { get; set; }
        int Code { get; set; }
    }
}