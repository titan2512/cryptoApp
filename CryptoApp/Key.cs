using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CryptoApp
{
    public class Key
    {
        public Key(byte[] firstPart, byte[] secondPart)
        {
            FirstPart = firstPart;
            SecondPart = secondPart;
        }

        public byte[] FirstPart { get; set; }

        public byte[] SecondPart { get; set; }
    }
}
