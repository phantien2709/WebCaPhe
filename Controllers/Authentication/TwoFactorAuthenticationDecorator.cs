using Microsoft.IdentityModel.Clients.ActiveDirectory;

namespace doan.Controllers.Authentication
{
    public class TwoFactorAuthenticationDecorator : IAuthenticationService
    {
        private readonly IAuthenticationService _authenticationService;

        public TwoFactorAuthenticationDecorator(IAuthenticationService authenticationService)
        {
            _authenticationService = authenticationService;
        }

        public (bool Success, bool RequiresTwoFactor) Authenticate(string phone, string password)
        {
            // Perform regular authentication
            var (success, requiresTwoFactor) = _authenticationService.Authenticate(phone, password);

            // Check if two-factor authentication is required
            if (success && requiresTwoFactor)
            {
                // Additional logic for two-factor authentication can be implemented here
            }

            return (success, requiresTwoFactor);
        }

        public void SendVerificationCode(string phone)
        {
            throw new System.NotImplementedException();
        }

        public bool VerifyCode(string phone, string code)
        {
            throw new System.NotImplementedException();
        }
    }

}
