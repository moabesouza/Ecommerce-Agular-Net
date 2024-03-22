namespace Ecom.API.Errors
{
    public class BaseCommonResponse
    {
        public BaseCommonResponse(int statusCode, string menssage = null)
        {
            StatusCode = statusCode;
            Menssage = menssage ?? MenssageStatusCode(statusCode);

        }

        private string MenssageStatusCode(int statusCode)
            => statusCode switch
            {
                400 => "Bad Request",
                401 => "Not Authorize",
                404 => "Not Found",
                500 => "Server Error",
                _ => null
            };

        public int StatusCode { get; set;}
        public string Menssage { get; set;}
    }
}
