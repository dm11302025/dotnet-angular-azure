namespace HandsOnAPIUsingStatusCodes
{
    public class ApiResponse<T>
    {
        public int StatusCode { get; set; }
        public string Message { get; set; }
        public T Data { get; set; }
        public List<string> Errors { get; set; }

        public static ApiResponse<T> Success(T data, string message = "Success", int statusCode = 200)
            => new ApiResponse<T>
            {
                StatusCode = statusCode,
                Message = message,
                Data = data,
                Errors = null
            };

        public static ApiResponse<T> Fail(List<string> errors, string message = "Failed", int statusCode = 400)
            => new ApiResponse<T>
            {
                StatusCode = statusCode,
                Message = message,
                Data = default,
                Errors = errors
            };
    }

}
