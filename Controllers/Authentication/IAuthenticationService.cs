namespace doan.Controllers.Authentication

{
    public interface IAuthenticationService
    {
        (bool Success, bool RequiresTwoFactor) Authenticate(string phone, string password);
        void SendVerificationCode(string phone);
        bool VerifyCode(string phone, string code);
    }
}
