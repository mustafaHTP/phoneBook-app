using System.Text.Json.Serialization;

namespace PhoneBook.Core.DTOs
{
    public class CustomResponseViewModel<T>
    {
        public T Data { get; set; }
        public List<string> Errors { get; set; }

        [JsonIgnore]
        public int StatusCode { get; set; }

        public static CustomResponseViewModel<T> Success(int statusCode, T data)
        {
            return new CustomResponseViewModel<T> { StatusCode = statusCode, Data = data, Errors = null }; ;
        }

        public static CustomResponseViewModel<T> Success(int statusCode)
        {
            return new CustomResponseViewModel<T> { StatusCode = statusCode };
        }

        public static CustomResponseViewModel<T> Fail(int statusCode, List<string> errors)
        {
            return new CustomResponseViewModel<T> { StatusCode = statusCode, Errors = errors };
        }

        public static CustomResponseViewModel<T> Fail(int statusCode, string error)
        {
            return new CustomResponseViewModel<T> { StatusCode = statusCode, Errors = new List<string> { error } };
        }


    }
}
