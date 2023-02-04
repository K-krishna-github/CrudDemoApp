namespace CrudDemoApp.Dto
{
    public class LoginDto
    {
        public string email { get; set; }
        public string password { get; set; }
    }



    public class Responce
    {


        public Responce()
        {
            ErrorMessage = string.Empty;
        }
        public bool IsSuccess => string.IsNullOrEmpty(ErrorMessage) && string.IsNullOrWhiteSpace(ErrorMessage);
        public string ErrorMessage { get; set; }
    }
    public class LoginResponse
    {
        public LoginResponse()
        {
            ErrorMessage = string.Empty;
        }
        public bool IsSuccess => string.IsNullOrEmpty(ErrorMessage) && string.IsNullOrWhiteSpace(ErrorMessage);
        public string ErrorMessage { get; set; }
        public TokenModel TokenModel { get; set; }
    }

    public class TokenModel
    {
        public string token { get; set; }
    }
}
