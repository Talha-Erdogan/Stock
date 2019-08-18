using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Web;

namespace Stock.UI.Helper
{
    public static class CryptoHelper
    {
        public static string Conversion(string password)
        {
            byte[] ByteData = Encoding.ASCII.GetBytes(password);
            MD5 crypto = MD5.Create();
            byte[] HashData = crypto.ComputeHash(ByteData);
            StringBuilder sb = new StringBuilder();
            for (int x = 0; x < HashData.Length; x++)
            {
                sb.Append(HashData[x].ToString("x2"));
            }
            return sb.ToString();
        }
    }
}