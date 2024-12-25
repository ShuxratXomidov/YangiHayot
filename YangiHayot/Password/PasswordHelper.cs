using System.Security.Cryptography;
using System.Text;

namespace YangiHayot.Password
{
    public static class PasswordHelper
    {
        public static void HashPassword(string password, out byte[] passwordSalt, out byte[] passwordHash)
        {
            using (HMACSHA512 hmac = new HMACSHA512())
            {
                passwordSalt = hmac.Key;
                passwordHash = hmac.ComputeHash(Encoding.UTF8.GetBytes(password));
            }
        }

        public static bool CkeckPassword(string password, byte[] passwordHash, byte[] passwordSalt)
        {
            return false;
        }
    }
}
