using BauruEmpregosBack.Models.Enum;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace BauruEmpregosBack.Services
{
    public static class HashService
    {

        public static string GenerationPasswordHash(string email, Role role, string pass)
            => CriptSha256(email, role, pass);



        private static string CriptSha256(string email, Role role, string password)
        {
            string valor = $"{email}:{role}:{password}";

            byte[] HashValue, MessageBytes = Encoding.ASCII.GetBytes(valor);
            SHA256Managed SHhash = new SHA256Managed();
            string strHex = "";

            HashValue = SHhash.ComputeHash(MessageBytes);

            foreach (byte b in HashValue)
            {
                strHex += String.Format("{0:x2}", b);
            }
            return strHex;
        }
    }
}
