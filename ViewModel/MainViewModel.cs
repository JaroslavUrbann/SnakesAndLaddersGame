using System;
using Base.ViewModel;
using Base.Command;
using System.Threading.Tasks;
using System.Windows;
using System.IO;

namespace Urban_Hra.ViewModel
{
    class MainViewModel : BaseViewModel
    {
        #region Globální proměnné ViewModelu
        private string _pocetH;
        // proměnné pro souřadnice postaviček 
        private int _redRow;
        private int _redCol;
        private int _greenRow;
        private int _greenCol;
        private int _blueRow;
        private int _blueCol;
        private int _yellowRow;
        private int _yellowCol;
        private int _orangeRow;
        private int _orangeCol;
        private int _hozeneCislo;
        // proměnné pro komunikaci s uživatelem
        private string _status;
        private string _statusBackground;
        // povolování házení kostkou
        private string _enabled;
        private string _enableUlozit;
        // objekty tříd v modelu
        private Model.NovaHra NH;
        private Model.Pohyb PH;
        private Model.RNG RN;
        #endregion

        #region Deklarace bindovatelných vlastností
        public string PocetH { get { return _pocetH; } set { _pocetH = value; ChangeProperty("PocetH"); } }
        public string RedVis { get { return NH.RedV; } set { NH.RedV = value; ChangeProperty("RedVis"); } }
        public string GreenVis { get { return NH.GreenV; } set { NH.GreenV = value; ChangeProperty("GreenVis"); } }
        public string BlueVis { get { return NH.BlueV; } set { NH.BlueV = value; ChangeProperty("BlueVis"); } }
        public string YellowVis { get { return NH.YellowV; } set { NH.YellowV = value; ChangeProperty("YellowVis"); } }
        public string OrangeVis { get { return NH.OrangeV; } set { NH.OrangeV = value; ChangeProperty("OrangeVis"); } }
        public int HozeneCislo { get { return _hozeneCislo; } set { _hozeneCislo = value; ChangeProperty("HozeneCislo"); } }
        public int RedRow { get { return _redRow; } set { _redRow = value; ChangeProperty("RedRow"); } }
        public int RedCol { get { return _redCol; } set { _redCol = value; ChangeProperty("RedCol"); } }
        public int GreenRow { get { return _greenRow; } set { _greenRow = value; ChangeProperty("GreenRow"); } }
        public int GreenCol { get { return _greenCol; } set { _greenCol = value; ChangeProperty("GreenCol"); } }
        public int BlueRow { get { return _blueRow; } set { _blueRow = value; ChangeProperty("BlueRow"); } }
        public int BlueCol { get { return _blueCol; } set { _blueCol = value; ChangeProperty("BlueCol"); } }
        public int YellowRow { get { return _yellowRow; } set { _yellowRow = value; ChangeProperty("YellowRow"); } }
        public int YellowCol { get { return _yellowCol; } set { _yellowCol = value; ChangeProperty("YellowCol"); } }
        public int OrangeRow { get { return _orangeRow; } set { _orangeRow = value; ChangeProperty("OrangeRow"); } }
        public int OrangeCol { get { return _orangeCol; } set { _orangeCol = value; ChangeProperty("OrangeCol"); } }
        public string Status { get { return _status; } set { _status = value; ChangeProperty("Status"); } }
        public string StatusBackground { get { return _statusBackground; } set { _statusBackground = value; ChangeProperty("StatusBackground"); } }
        public string Poradi1 { get { return PH.Poradi[0]; } set { PH.Poradi[0] = value; ChangeProperty("Poradi1"); } }
        public string Poradi2 { get { return PH.Poradi[1]; } set { PH.Poradi[1] = value; ChangeProperty("Poradi2"); } }
        public string Poradi3 { get { return PH.Poradi[2]; } set { PH.Poradi[2] = value; ChangeProperty("Poradi3"); } }
        public string Poradi4 { get { return PH.Poradi[3]; } set { PH.Poradi[3] = value; ChangeProperty("Poradi4"); } }
        public string Poradi5 { get { return PH.Poradi[4]; } set { PH.Poradi[4] = value; ChangeProperty("Poradi5"); } }
        public string Enabled { get { return _enabled; } set { _enabled = value; ChangeProperty("Enabled"); } }
        public string EnableUlozit { get { return _enableUlozit; } set { _enableUlozit = value; ChangeProperty("EnableUlozit"); } }
        #endregion

        #region Deklarace Command
        public Command _novaHra { get; set; }
        public Command _hod { get; set; }
        #endregion

        #region Metody pro obsluhu Command

        /// <summary>
        /// nastaví počet hráčů, zavolá Clear() metodu
        /// </summary>
        public void NovaHra()
        {
            int P;
            if(Int32.TryParse(PocetH, out P) == true && P < 6 && P > 1)
            {
                Clear();
                Enabled = "True";
                NH.Visible(P);
                for(int i = 0; i < 5; i++) { PH.HraciVeHre[i] = NH.HraciVeHre[i]; }
                RedVis = NH.RedV; GreenVis = NH.GreenV; BlueVis = NH.BlueV; YellowVis = NH.YellowV; OrangeVis = NH.OrangeV;
                StatusBackground = "Red";
                Status = "Hází červený!";
            }
            else Status = "Zadejte číslo od 2 do 5 pro novou hru!";
        }

        /// <summary>
        /// hodí kostkou, pohybuje postavičkami, zapisuje pořadí, končí hru
        /// </summary>
        public async void Hod()
        {
            Enabled = "False";
            string Barva = PH.KdoHraje();
            Status = "Házím...";
            StatusBackground = Barva;
            // animace hodu kostkou
            for(int i = 10; i < 800; i = i + 100)
            {
                await Task.Delay(i);
                HozeneCislo = RN.VyberRNG();
            }
            await Task.Delay(500);
            Status = "Hodil jste " + HozeneCislo.ToString() + "!";
            // pohybování postavičkami
            int Delka = PH.GetPocet(Barva, HozeneCislo);
            for(int i = 0; i < Delka; i++)
            {
                await Task.Delay(500);
                switch(Barva)
                {
                    case "Red": RedCol = PH.FinalCol[i]; RedRow = PH.FinalRow[i]; break;
                    case "Green": GreenCol = PH.FinalCol[i]; GreenRow = PH.FinalRow[i]; break;
                    case "Blue": BlueCol = PH.FinalCol[i]; BlueRow = PH.FinalRow[i]; break;
                    case "Yellow": YellowCol = PH.FinalCol[i]; YellowRow = PH.FinalRow[i]; break;
                    case "Orange": OrangeCol = PH.FinalCol[i]; OrangeRow = PH.FinalRow[i]; break;
                }
            }
            await Task.Delay(500);
            // zápis pořadí
            Poradi1 = PH.Poradi[0]; Poradi2 = PH.Poradi[1]; Poradi3 = PH.Poradi[2]; Poradi4 = PH.Poradi[3]; Poradi5 = PH.Poradi[4];
            // kontrola konce hry
            if (PH.Konec == true) { MessageBox.Show("Konec"); Enabled = "False"; EnableUlozit = "True"; Status = "Hra skončila! Čekám na začátek hry!"; StatusBackground = "Gray"; }
            else
            {
                Enabled = "True";
                Status = "Hází další!";
                StatusBackground = PH.KdoHrajeBarva();
            }
        }

        /// <summary>
        /// resetuje pořadí, souřadnice postav...
        /// </summary>
        public void Clear()
        {
            Poradi1 = Poradi2 = Poradi3 = Poradi4 = Poradi5 = "_____";
            RedCol = GreenCol = BlueCol = YellowCol = OrangeCol = 1;
            RedRow = GreenRow = BlueRow = YellowRow = OrangeRow = 9;
            NH.RedV = NH.GreenV = NH.BlueV = NH.YellowV = NH.OrangeV = "Hidden";
            PH.Clear();
            PocetH = "";
            Enabled = "False";
            EnableUlozit = "False";
            HozeneCislo = 6;
        }

        #endregion

        public MainViewModel()
        {
            PH = new Model.Pohyb();
            NH = new Model.NovaHra();
            RN = new Model.RNG();
            _novaHra = new Command(NovaHra);
            _hod = new Command(Hod);
            Clear();
            Poradi1 = Poradi2 = Poradi3 = Poradi4 = Poradi5 = "_____";
            Status = "Čekám na začátek hry";
            StatusBackground = "Gray";
        }

        public new void ChangeProperty(string propertyName) { base.ChangeProperty(propertyName); }
    }
}
