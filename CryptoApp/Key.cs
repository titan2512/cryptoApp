using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CryptoApp
{
    public class Key
    {
        public Key(int firstPart, int secondPart)
        {
            FirstPart = firstPart;
            SecondPart = secondPart;
        }

        public int FirstPart { get; set; }

        public int SecondPart { get; set; }
    }
}
