namespace Application.BLL.Models.Auth
{
    public class AuthResult
    {
        public bool IsSuccess { get; set; }
        public string AccessToken { get; set; }
        public string SuccessMassage { get; set; }
    }
}
