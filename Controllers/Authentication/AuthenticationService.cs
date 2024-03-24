using doan.Models;
using Microsoft.IdentityModel.Clients.ActiveDirectory;
using System.Data;

namespace doan.Controllers.Authentication
{
    public class AuthenticationService : IAuthenticationService
    {
        private readonly StoreContext _context;

        public AuthenticationService(StoreContext context)
        {
            _context = context;
        }

        public (bool Success, bool RequiresTwoFactor) Authenticate(string phone, string password)
        {
            var acc = _context.GetTaikhoan(phone, password);

            if (acc.MaTk != 0)
            {
                // Check if two-factor authentication is required (based on custom logic)
                bool requiresTwoFactor = false;

                // Check if the user belongs to a specific role that requires 2FA
                if (acc.RoleId == 2)
                {
                    requiresTwoFactor = true;
                }

                // Check if the user has opted-in to 2FA in their account settings
                if (!requiresTwoFactor )//&& acc.IsTwoFactorEnabled)
                {
                    requiresTwoFactor = true;
                }

                return (true, requiresTwoFactor);
            }
            else
            {
                return (false, false);
            }
        }

        public void SendVerificationCode(string phone)
        {
            throw new System.NotImplementedException();
        }

        public bool VerifyCode(string phone, string code)
        {
            throw new System.NotImplementedException();
        }

        //bool IAuthenticationService Authenticate(string phone, string password)
        //{
        //    throw new System.NotImplementedException();
        //}
    }

}
