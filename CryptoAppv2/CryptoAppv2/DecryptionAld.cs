using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CryptoAppv2
{
    class DecryptionAld
    {
        private static long secretKey;

        public static  long SecretKey
        {
            get { return secretKey; }
            set { secretKey = value; }
        }
    }
}
