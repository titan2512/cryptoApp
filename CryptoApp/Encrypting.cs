using System;
using System.Collections.Generic;
using System.Diagnostics.Contracts;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CryptoApp
{
    public class Encrypting
    {
        private byte p; //destroy
        private byte q; //destroy
        private ushort phi; //destroy
        private ushort n;
        private ushort e;
        private Int32 d;

        public Encrypting()
        {

        }

        public Key OpenKey { get; set; }

        public Key CloseKey { get; set; }

        public string Encrypt(string message)
        {
            Contract.Requires(message != null);
            Contract.Requires(message != string.Empty);
            Contract.Requires(OpenKey != null);

            //InitKeyData();

            string outStr = "";
            System.Text.UTF8Encoding enc = new System.Text.UTF8Encoding();
            byte[] strBytes = enc.GetBytes(message);
            foreach (byte value in strBytes)
            {
                int encryptedValue = ModuloPow(value, OpenKey.FirstPart, OpenKey.SecondPart);
                outStr += encryptedValue + "  ";
            }

            return outStr;
        }

        static int ModuloPow(int value, int pow, int modulo)
        {
            int result = value;
            for (int i = 0; i < pow - 1; i++)
            {
                result = (result * value) % modulo;
            }
            return result;
        }

        public void InitKeyData()
        {
            OpenKey = new Key(0,0);
            CloseKey = new Key(0,0);
            Random random = new Random();

            byte[] simple = GetNotDivideable();
            this.p = simple[random.Next(0, simple.Length)];
            this.q = simple[random.Next(0, simple.Length)];
            OpenKey.SecondPart = (ushort)(this.p * this.q);
            CloseKey.SecondPart = OpenKey.SecondPart;
            this.phi = (ushort)((p - 1) * (q - 1));
            List<ushort> possibleE = GetAllPossibleE(this.phi);

            do
            {
                OpenKey.FirstPart = possibleE[random.Next(0, possibleE.Count)];
                CloseKey.FirstPart = ExtendedEuclide(OpenKey.FirstPart % this.phi, this.phi).u1;
            } while (CloseKey.FirstPart < 0);
        }

        /// Получить все варианты для e
        static List<ushort> GetAllPossibleE(ushort phi)
        {
            List<ushort> result = new List<ushort>();

            for (ushort i = 2; i < phi; i++)
            {
                if (ExtendedEuclide(i, phi).gcd == 1)
                {
                    result.Add(i);
                }
            }

            return result;
        }

        /// <summary>
        /// u1 * a + u2 * b = u3
        /// </summary>
        /// <param name="a">Число a</param>
        /// <param name="b">Модуль числа</param>
        private static ExtendedEuclideanResult ExtendedEuclide(int a, int b)
        {
            int u1 = 1;
            int u3 = a;
            int v1 = 0;
            int v3 = b;

            while (v3 > 0)
            {
                int q0 = u3 / v3;
                int q1 = u3 % v3;

                int tmp = v1 * q0;
                int tn = u1 - tmp;
                u1 = v1;
                v1 = tn;

                u3 = v3;
                v3 = q1;
            }

            int tmp2 = u1 * (a);
            tmp2 = u3 - (tmp2);
            int res = tmp2 / (b);

            ExtendedEuclideanResult result = new ExtendedEuclideanResult()
            {
                u1 = u1,
                u2 = res,
                gcd = u3
            };

            return result;
        }

        static private byte[] GetNotDivideable()
        {
            List<byte> notDivideable = new List<byte>();

            for (int x = 2; x < 256; x++)
            {
                int n = 0;
                for (int y = 1; y <= x; y++)
                {
                    if (x % y == 0)
                        n++;
                }

                if (n <= 2)
                    notDivideable.Add((byte)x);
            }
            return notDivideable.ToArray();
        }

        private struct ExtendedEuclideanResult
        {
            public int u1;
            public int u2;
            public int gcd;
        }

    }
}
