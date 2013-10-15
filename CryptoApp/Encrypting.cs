using System;
using System.Collections.Generic;
using System.Diagnostics.Contracts;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace CryptoApp
{
    public class Encrypting
    {



        public Encrypting()
        {
            RsaProvider = new RSACryptoServiceProvider(512);

        }

        public string cryptingData(string data)
        {


            string result = "";
            UnicodeEncoding ByteConverter = new UnicodeEncoding();
            byte[] dataToEncrypt = ByteConverter.GetBytes(data);// символы переводим в байты 
            try
            {
                byte[] txtEnCrypt = RsaProvider.Encrypt(dataToEncrypt, false);
                result = Convert.ToBase64String(txtEnCrypt);
            }
            catch (CryptographicException ex)
            {

            }
            return result;
        }

        public string deCryptingData(string data)
        {
            string result = "";
            byte[] dataToDecrypt = Convert.FromBase64String(data);
            try
            {
                byte[] byteToDecrypt = RsaProvider.Decrypt(dataToDecrypt, false);

                int len = byteToDecrypt.Length;

                char[] val = new char[len];

                val = Encoding.Unicode.GetChars(byteToDecrypt);

                result = string.Join("", val);

            }
            catch
            {

            }
            return result;
        }



        public Key OpenKey { get; set; }

        public Key CloseKey { get; set; }

        public RSACryptoServiceProvider RsaProvider { get; set; }

        public string Encrypt(string message)
        {
            Contract.Requires(message != null);
            Contract.Requires(message != string.Empty);
            Contract.Requires(OpenKey != null);
            string outStr = "";
            outStr = cryptingData(message);
            return outStr;
        }

    }
}
