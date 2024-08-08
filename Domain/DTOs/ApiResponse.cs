using System.Net;

namespace Domain.DTOs
{
    public class ApiResponse<T>
    {
        // Propiedades
        public bool Success { get; set; }
        public T Data { get; set; }
        public string Message { get; set; }
        public HttpStatusCode StatusCode { get; set; }

        // Constructor por defecto
        public ApiResponse() { }

        // Constructor 
        public ApiResponse(bool success, T data, string message, HttpStatusCode statusCode)
        {
            Success = success;
            Data = data;
            Message = message;
            StatusCode = statusCode;
        }

        // Respuesta exitosa T
        public static ApiResponse<T> SuccessResponse(T data, string message = "Éxito")
        {
            return new ApiResponse<T>(true, data, message, HttpStatusCode.OK);
        }

        // Respuesta exitosa T enumerable o lista
        public static ApiResponse<IEnumerable<T>> SuccessResponse(IEnumerable<T> data, string message = "Éxito")
        {
            return new ApiResponse<IEnumerable<T>>(true, data, message, HttpStatusCode.OK);
        }

        // Respuesta de error
        public static ApiResponse<T> ErrorResponse(string message, HttpStatusCode statusCode = HttpStatusCode.BadRequest)
        {
            return new ApiResponse<T>(false, default(T), message, statusCode);
        }

    }
}
