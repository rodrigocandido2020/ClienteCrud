using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClienteCrud
{
    public class CriptografarSenha
    {
        public string Criptografar(string plainText)
        {
            var plainTextteste = System.Text.Encoding.UTF8.GetBytes(plainText);
            return System.Convert.ToBase64String(plainTextteste);
        }
    }
}
