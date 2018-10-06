using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Urban_Hra.Model
{
    class RNG
    {
        private int PredchoziC;
        private int TotoC;

        public RNG()
        {

        }

        /// <summary>
        /// vybere náhodné číslo
        /// </summary>
        /// <returns>číslo (1-6)</returns>
        public int VyberRNG()
        {
            int[] cislo = { 1, 2, 3, 4, 5, 6 };
            Random rnd = new Random();
            TotoC = cislo[rnd.Next(0, 6)];
            while (PredchoziC == TotoC)
            {
                TotoC = cislo[rnd.Next(0, 6)];
            }
            PredchoziC = TotoC;
            return TotoC;
        }
    }
}
