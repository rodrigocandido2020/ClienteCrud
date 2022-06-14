using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace Crud.Dominio
{
    public class CriptografarSenha
    {
        public static string Criptografar(string senhaParaCriptografar)
        {
            byte[] senhaCriptografada;
            using(var rsa = new RSACryptoServiceProvider(2848))
            {
                rsa.PersistKeyInCsp = false;
                //var CriarChave = rsa.ToXmlString(true);
                rsa.FromXmlString("<RSAKeyValue><Modulus>0bkUMxjU1vn5OT0IHb+zwZ7dubHbcPvTL/Icre432HcLyQFkbQuvpEMk+29tBv4JDLFOpVPlHY42i73tvXnb/K68vEPWPKgjK1Uryf22u7EDsbIgJk97DH9WaPLJlgC+k0tXKwp8EBGq9mekCUexcH4qmXYx/SdYgepiejSG0KsGyMbAQ9a5RItB2E5A63XdnZrdPxDGjOieH1VT4i8NMlgzFYpybYBxhHyDDC/OB9cYi1bL9MzGRPeLoZTylDbB+eSZMtxaW/wcVouemtKRzOh6atUiMZ+dN1MhpNVBBh5XruZKqryvjDyxAjp4r2CgiNooe9W81MfeLi98W6+gHDSz2cfbkuN0hi/snyXAEv17TkU+/Q9C88KQ8E9686sbIxhukqGfD5vpdI1P4M9vIO68cSyGfxB2bC4HLEDN/YpMQZEQ+KamYf/wIjVCntrGfm41jtF18WYdt9lfD5zLTc4b9nU=</Modulus><Exponent>AQAB</Exponent><P>9N64D4ESGBRSXhFb3SV6ImcisG9p1IPxaFJ4JflWwjhKSwCg0z6SMKL0sJlknPDuZYdGbd+VkdvU6QAixKY/Q1oXZzgKvDkyWAT2eCZLjC6KWBZclgOnpH8wBtzAj++7lnmfCn6j9ZI5aLm3j3SKG7DxSFfyz8O+/vf+RYcAVPInQup7lQANuvuagQRHvoN2pXodTPLICdw6sTZMoUkn8CJ5scMTATJVK/A9REUFd4jiZw==</P><Q>20FkkGB/ACM10FZACbF1eFeaHLBSP5kkP5imvQHdMNnSjIwjBOzL/6VBVzJqnQQORo4GDmPI2EL4xrdwGPu+G+l6P/TVlZZxjvAFYpi9BVNlXI+PjnFJtOs9G7sa7hB0wDb2gsLGrdNmX3I3fl71s9CT58br6ir/5eXPsjK4Z3NfnDgw9FEWGbPSvNrGDmv5gG1tNUwzih3k904vha/6ozblMTSWe3+GzBms3vMZpu8uww==</Q><DP>rdlmMlO/xeq/o9uNLhAKi1xP65XePCxE+3z5onRI3XFbha53gCL/ZZp8QNlW7nm7t8d4AE/p//lkStx20sj5R1cyIG1Qadvt20ICvsDpiCgOvoV5zGPh5M8MCQM3j7lzpFzKxoes3o+nRKv+H9Jsr0ZLt8IBOPLPqnPlSfWUDbsylralcN7t4J/7TLf+O8tYNBnjrZr83MtHvENB2ox2122SmttVpdbXU2+n/81FGV3M5w==</DP><DQ>yu7Bl2fY5FWyjzvlVZNseJAMUhVYawjhJgOyACpjgb16RR/Hod1SCzH3Qi+lweJpHCCDtnnhAVkrTTGnjVgj4028GsoPjb6LKJM7SMC54t4HaR5u7pYodE1uZ+ZLzKBqjyXQD8MbhPOvQxRCDLLzkxSwcMwKuthFtZF5JSQQzZ9ZlQvlM5yBahSoLqgGvH5vldCyTaxT37g/ni49ie0RfFNo2pwj0/Z62xnAiTJUQdALZQ==</DQ><InverseQ>rKPVNsiT/zDomKFrIjEPw9GRxMywZoclKPPYzDyzb//mDksCMtVFMEQkJOYmILXFZ9dlBUrsskPNJm3oM2fiORTLNu4xtl6oXjNED1TWRrGmPGeiq3xAkTVVNuHC0+UHMYadN8fXtk0gInDnfOiu6nO4Re+7704P7aFPFiBMgJeTED8ypCkXgL6XhYuJMRYYqXXFVIffEMSJBEpHM1/870Zy6BCBZ2JeUCGgzHgDWQCHhQ==</InverseQ><D>wSf8+rK8FONWLumPOBb/sCxpekXdHkpRT69lyqvEs5GxQQgPPn+s3VUaEpmliPMf0pjbHloOgxIgGsRq2kAJ5Mfq/FpeTq9s9NQU6IzMaEG4bUjpY1+ArRn6s94o3AcDfxW8yt91NDeRhjAeXI2zVzBce8rob4h1c/IzkOof4MAkF3c2TUTOjdrUYixwjmyYGDgx3YvN0qnMOH+WKpO7S8sAAa7phQDvjF5BNFAzKfVpnAB09T0jxqbCBkLza4/voiIzGtkb3XsHFPSislsQEQC1eF896UXwDVSTfgGtG0ltvUjvLkeXWvy9u7av9VqQplYhz63i1/yDl8kFJbYjNrrvle7rUxBGxQZsEzPlLngzJHY6ogqS73/NnPWCSXWyLSlVazRGJL988SKbLc+OPNFgS5vLfHMMW34t2rcQ6a02d4qDNfZBZYu5oM+PrtZ7JUaF1X+KvyC1PmZizYkTjcQm52E=</D></RSAKeyValue>");
                var rsaServer = new RSACryptoServiceProvider(1824);
                senhaCriptografada = rsa.Encrypt(Encoding.UTF8.GetBytes(senhaParaCriptografar), true);
            }
            return Convert.ToBase64String(senhaCriptografada);
        }
        public string DESCriptografarSenha(string senhaParaCriptografar)
        {
            byte[] senhaCriptografada;
            using (var rsa = new RSACryptoServiceProvider(2848))
            {
                var senhaUnica = rsa.ToXmlString(true);
                rsa.FromXmlString("<RSAKeyValue><Modulus>0bkUMxjU1vn5OT0IHb+zwZ7dubHbcPvTL/Icre432HcLyQFkbQuvpEMk+29tBv4JDLFOpVPlHY42i73tvXnb/K68vEPWPKgjK1Uryf22u7EDsbIgJk97DH9WaPLJlgC+k0tXKwp8EBGq9mekCUexcH4qmXYx/SdYgepiejSG0KsGyMbAQ9a5RItB2E5A63XdnZrdPxDGjOieH1VT4i8NMlgzFYpybYBxhHyDDC/OB9cYi1bL9MzGRPeLoZTylDbB+eSZMtxaW/wcVouemtKRzOh6atUiMZ+dN1MhpNVBBh5XruZKqryvjDyxAjp4r2CgiNooe9W81MfeLi98W6+gHDSz2cfbkuN0hi/snyXAEv17TkU+/Q9C88KQ8E9686sbIxhukqGfD5vpdI1P4M9vIO68cSyGfxB2bC4HLEDN/YpMQZEQ+KamYf/wIjVCntrGfm41jtF18WYdt9lfD5zLTc4b9nU=</Modulus><Exponent>AQAB</Exponent><P>9N64D4ESGBRSXhFb3SV6ImcisG9p1IPxaFJ4JflWwjhKSwCg0z6SMKL0sJlknPDuZYdGbd+VkdvU6QAixKY/Q1oXZzgKvDkyWAT2eCZLjC6KWBZclgOnpH8wBtzAj++7lnmfCn6j9ZI5aLm3j3SKG7DxSFfyz8O+/vf+RYcAVPInQup7lQANuvuagQRHvoN2pXodTPLICdw6sTZMoUkn8CJ5scMTATJVK/A9REUFd4jiZw==</P><Q>20FkkGB/ACM10FZACbF1eFeaHLBSP5kkP5imvQHdMNnSjIwjBOzL/6VBVzJqnQQORo4GDmPI2EL4xrdwGPu+G+l6P/TVlZZxjvAFYpi9BVNlXI+PjnFJtOs9G7sa7hB0wDb2gsLGrdNmX3I3fl71s9CT58br6ir/5eXPsjK4Z3NfnDgw9FEWGbPSvNrGDmv5gG1tNUwzih3k904vha/6ozblMTSWe3+GzBms3vMZpu8uww==</Q><DP>rdlmMlO/xeq/o9uNLhAKi1xP65XePCxE+3z5onRI3XFbha53gCL/ZZp8QNlW7nm7t8d4AE/p//lkStx20sj5R1cyIG1Qadvt20ICvsDpiCgOvoV5zGPh5M8MCQM3j7lzpFzKxoes3o+nRKv+H9Jsr0ZLt8IBOPLPqnPlSfWUDbsylralcN7t4J/7TLf+O8tYNBnjrZr83MtHvENB2ox2122SmttVpdbXU2+n/81FGV3M5w==</DP><DQ>yu7Bl2fY5FWyjzvlVZNseJAMUhVYawjhJgOyACpjgb16RR/Hod1SCzH3Qi+lweJpHCCDtnnhAVkrTTGnjVgj4028GsoPjb6LKJM7SMC54t4HaR5u7pYodE1uZ+ZLzKBqjyXQD8MbhPOvQxRCDLLzkxSwcMwKuthFtZF5JSQQzZ9ZlQvlM5yBahSoLqgGvH5vldCyTaxT37g/ni49ie0RfFNo2pwj0/Z62xnAiTJUQdALZQ==</DQ><InverseQ>rKPVNsiT/zDomKFrIjEPw9GRxMywZoclKPPYzDyzb//mDksCMtVFMEQkJOYmILXFZ9dlBUrsskPNJm3oM2fiORTLNu4xtl6oXjNED1TWRrGmPGeiq3xAkTVVNuHC0+UHMYadN8fXtk0gInDnfOiu6nO4Re+7704P7aFPFiBMgJeTED8ypCkXgL6XhYuJMRYYqXXFVIffEMSJBEpHM1/870Zy6BCBZ2JeUCGgzHgDWQCHhQ==</InverseQ><D>wSf8+rK8FONWLumPOBb/sCxpekXdHkpRT69lyqvEs5GxQQgPPn+s3VUaEpmliPMf0pjbHloOgxIgGsRq2kAJ5Mfq/FpeTq9s9NQU6IzMaEG4bUjpY1+ArRn6s94o3AcDfxW8yt91NDeRhjAeXI2zVzBce8rob4h1c/IzkOof4MAkF3c2TUTOjdrUYixwjmyYGDgx3YvN0qnMOH+WKpO7S8sAAa7phQDvjF5BNFAzKfVpnAB09T0jxqbCBkLza4/voiIzGtkb3XsHFPSislsQEQC1eF896UXwDVSTfgGtG0ltvUjvLkeXWvy9u7av9VqQplYhz63i1/yDl8kFJbYjNrrvle7rUxBGxQZsEzPlLngzJHY6ogqS73/NnPWCSXWyLSlVazRGJL988SKbLc+OPNFgS5vLfHMMW34t2rcQ6a02d4qDNfZBZYu5oM+PrtZ7JUaF1X+KvyC1PmZizYkTjcQm52E=</D></RSAKeyValue>");
                senhaCriptografada = rsa.Decrypt(Encoding.UTF8.GetBytes(senhaParaCriptografar), true);
            }
            return Convert.ToBase64String(senhaCriptografada);

        }
    }
}
