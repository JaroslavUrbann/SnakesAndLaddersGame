using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Urban_Hra.Model
{
    class NovaHra
    {
        public string RedV = "Visible";
        public string GreenV;
        public string BlueV;
        public string YellowV;
        public string OrangeV;
        public int[] HraciVeHre = { 1, 2, 3, 4, 5 };
        Pohyb PH = new Pohyb();

        public NovaHra()
        {

        }

        /// <summary>
        /// nastaví visibilitu a počet hráčů ve hře
        /// </summary>
        /// <param name="pocet">počet hráčů (2-5)</param>
        public void Visible(int pocet)
        {
            
            for (int i = 0; i < 5; i++) { HraciVeHre[i] = 0; }
            switch (pocet)
            {
                case 2: RedV = GreenV = "Visible"; BlueV = YellowV = OrangeV = "Hidden"; for (int i = 0; i < 2; i++) { HraciVeHre[i] = i + 1; }  break;
                case 3: RedV = GreenV = BlueV = "Visible"; YellowV = OrangeV = "Hidden"; for (int i = 0; i < 3; i++) { HraciVeHre[i] = i + 1; } break;
                case 4: RedV = GreenV = BlueV = YellowV = "Visible"; OrangeV = "Hidden"; for (int i = 0; i < 4; i++) { HraciVeHre[i] = i + 1; } break;
                case 5: RedV = GreenV = BlueV = YellowV = OrangeV = "Visible"; for (int i = 0; i < 5; i++) { HraciVeHre[i] = i + 1; } break;
                default: break;
            }
        }
    }
}
