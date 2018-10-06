using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Urban_Hra.Model
{
    class Pohyb
    {
        // řady souřadnic pro pohyb po žebřících/hadech
        private int[] Had1Row = { 6, 7, 8, 8, 9};
        private int[] Had1Col = { 8, 8, 7, 6, 6};
        private int[] Had2Row = { 2, 2, 3, 4, 5, 6, 6, 6, 6, 7};
        private int[] Had2Col = { 6, 5, 5, 6, 6, 6, 5, 4, 3, 2};
        private int[] Had3Row = { 1, 2, 3, 4};
        private int[] Had3Col = { 7, 8, 9, 10};
        private int[] Had4Row = { 1, 2, 2, 2, 3, 4, 5, 6};
        private int[] Had4Col = { 3, 3, 2, 1, 1, 1, 2, 2};
        private int[] Zebrik1Row = { 8, 7, 6};
        private int[] Zebrik1Col = { 9, 10, 10};
        private int[] Zebrik2Row = { 7, 6, 5};
        private int[] Zebrik2Col = { 5, 5, 5};
        private int[] Zebrik3Row = { 7, 6, 5, 4, 3};
        private int[] Zebrik3Col = { 3, 3, 4, 4, 4};
        private int[] Zebrik4Row = { 4, 3};
        private int[] Zebrik4Col = { 7, 6};
        private int[] Zebrik5Row = { 4, 3, 2, 1, 0};
        private int[] Zebrik5Col = { 10, 9, 9, 8, 8};
        private int[] Zebrik6Row = { 2, 1};
        private int[] Zebrik6Col = { 2, 1};
        // aktuální pozice každé postavičky
        public int RedRow = 9;
        public int RedCol = 1;
        public int GreenRow = 9;
        public int GreenCol = 1;
        public int BlueRow = 9;
        public int BlueCol = 1;
        public int YellowRow = 9;
        public int YellowCol = 1;
        public int OrangeRow = 9;
        public int OrangeCol = 1;
        // řada souřadnicí pro pohyb postavičky
        public List<int> FinalCol;
        public List<int> FinalRow;

        public int[] HraciVeHre = { 1, 2, 3, 4, 5 };
        public int next = 0;
        public string[] Poradi = { "", "", "", "", "", };
        public int IndexPoradi = 0;
        public bool Konec = false;

        public Pohyb()
        {

        }

        /// <summary>
        /// vrací barvu postavičky je nařadě
        /// </summary>
        /// <returns></returns>
        public string KdoHraje()
        {
            next++;
            if (next == 6)
            { next = 1; }
            while (next != HraciVeHre[next - 1])
            {
                next++;
                if (next == 6)
                {
                    next = 1;
                }
            }
            switch (next)
            {
                case 1: return "Red";
                case 2: return "Green";
                case 3: return "Blue";
                case 4: return "Yellow";
                case 5: return "Orange";
                default: return "Gray";
            }
        }

        /// <summary>
        /// vrací barvu postavičky která bude hrát jako další
        /// </summary>
        /// <returns></returns>
        public string KdoHrajeBarva()
        {
            int dalsi = next;
            dalsi++;
            if (dalsi == 6)
            { dalsi = 1; }
            while (dalsi != HraciVeHre[dalsi - 1])
            {
                dalsi++;
                if (dalsi == 6)
                {
                    dalsi = 1;
                }
            }
            switch (dalsi)
            {
                case 1: return "Red";
                case 2: return "Green";
                case 3: return "Blue";
                case 4: return "Yellow";
                case 5: return "Orange";
                default: return "Gray";
            }
        }

        /// <summary>
        /// sestavuje finální řadu souřadnic podle které se bude pohybovat postavička
        /// </summary>
        /// <param name="Barva">jméno postavičky</param>
        /// <param name="HozeneCislo">hozené číslo</param>
        /// <returns>délka finální řady</returns>
        public int GetPocet(string Barva, int HozeneCislo)
        {
            FinalCol = new List<int>();
            FinalRow = new List<int>();
            int CurrentCol = 0;
            int CurrentRow = 0;
            switch(Barva) // zjistí aktuální pozici postavičky
            {
                case "Red": CurrentCol = RedCol; CurrentRow = RedRow; break;
                case "Green": CurrentCol = GreenCol; CurrentRow = GreenRow; break;
                case "Blue": CurrentCol = BlueCol; CurrentRow = BlueRow; break;
                case "Yellow": CurrentCol = YellowCol; CurrentRow = YellowRow; break;
                case "Orange": CurrentCol = OrangeCol; CurrentRow = OrangeRow; break;
            }
            for(int i = 0; i < HozeneCislo; i++)
            {
                // podmínky pro stoupání do vyšší řady
                if(CurrentCol == 10 && (CurrentRow == 1 || CurrentRow == 3 || CurrentRow == 5 || CurrentRow == 7 || CurrentRow == 9))
                {CurrentRow--;}
                else
                {
                    if(CurrentCol == 1 && (CurrentRow == 2 || CurrentRow == 4 || CurrentRow == 6 || CurrentRow == 8))
                    {CurrentRow--;}
                    else
                    {
                        // podmínka pro posouvání do dalšího/předchozího sloupce
                        if (CurrentRow == 9 || CurrentRow == 7 || CurrentRow == 5 || CurrentRow == 3 || CurrentRow == 1)
                        {CurrentCol++;}
                        else {CurrentCol--;}
                    }
                }
                // přidání každého kroku do finální řady souřadnic
                FinalCol.Add(CurrentCol);
                FinalRow.Add(CurrentRow);
                // kontrola posledního políčka
                if (CurrentRow.ToString() + CurrentCol.ToString() == "01")
                { HraciVeHre[next - 1] = 0; Pokracovat(Barva);break; }
        }
            // přidání řady souřadnic hadů/žebříků do finální řady souřadnic
            switch (CurrentRow.ToString() + CurrentCol.ToString())
            {
                case "69": for (int i = 0; i < Had1Col.Length; i++) { FinalCol.Add(Had1Col[i]); FinalRow.Add(Had1Row[i]); } break;
                case "27": for (int i = 0; i < Had2Col.Length; i++) { FinalCol.Add(Had2Col[i]); FinalRow.Add(Had2Row[i]); } break;
                case "16": for (int i = 0; i < Had3Col.Length; i++) { FinalCol.Add(Had3Col[i]); FinalRow.Add(Had3Row[i]); } break;
                case "02": for (int i = 0; i < Had4Col.Length; i++) { FinalCol.Add(Had4Col[i]); FinalRow.Add(Had4Row[i]); } break;
                case "99": for (int i = 0; i < Zebrik1Col.Length; i++) { FinalCol.Add(Zebrik1Col[i]); FinalRow.Add(Zebrik1Row[i]); } break;
                case "85": for (int i = 0; i < Zebrik2Col.Length; i++) { FinalCol.Add(Zebrik2Col[i]); FinalRow.Add(Zebrik2Row[i]); } break;
                case "83": for (int i = 0; i < Zebrik3Col.Length; i++) { FinalCol.Add(Zebrik3Col[i]); FinalRow.Add(Zebrik3Row[i]); } break;
                case "58": for (int i = 0; i < Zebrik4Col.Length; i++) { FinalCol.Add(Zebrik4Col[i]); FinalRow.Add(Zebrik4Row[i]); } break;
                case "510": for (int i = 0; i < Zebrik5Col.Length; i++) { FinalCol.Add(Zebrik5Col[i]); FinalRow.Add(Zebrik5Row[i]); } break;
                case "33": for (int i = 0; i < Zebrik6Col.Length; i++) { FinalCol.Add(Zebrik6Col[i]); FinalRow.Add(Zebrik6Row[i]); } break;
            }
            switch (Barva) // aktualizování souřadnic postaviček
            {
                case "Red": RedCol = FinalCol.Last(); RedRow = FinalRow.Last(); break;
                case "Green": GreenCol = FinalCol.Last(); GreenRow = FinalRow.Last(); break;
                case "Blue": BlueCol = FinalCol.Last(); BlueRow = FinalRow.Last(); break;
                case "Yellow": YellowCol = FinalCol.Last(); YellowRow = FinalRow.Last(); break;
                case "Orange": OrangeCol = FinalCol.Last(); OrangeRow = FinalRow.Last(); break;
            }
            return FinalCol.Count;
        }

        /// <summary>
        /// zapisuje pořadí postaviček, ukončuje hru
        /// </summary>
        /// <param name="Barva">jméno postavičky</param>
        public void Pokracovat(string Barva)
        {
            int[] Check = { 0, 1, 2, 3, 4 };
            int max;
            Poradi[IndexPoradi] = Barva;
            IndexPoradi++;
            foreach(int a in Check) { Check[a] = HraciVeHre[a]; }
            max = Check.Max();
            Check[Check.ToList().IndexOf(max)] = 0;
            if(Check.Max() * max == 0)
            {
                switch (HraciVeHre.Max())
                {
                    case 1: Poradi[IndexPoradi] = "Red";break;
                    case 2: Poradi[IndexPoradi] = "Green"; break;
                    case 3: Poradi[IndexPoradi] = "Blue"; break;
                    case 4: Poradi[IndexPoradi] = "Yellow"; break;
                    case 5: Poradi[IndexPoradi] = "Orange"; break;
                }
                Konec = true;
            }
        }

        /// <summary>
        /// resetuje pořadí, souřadnice
        /// </summary>
        public void Clear()
        {
            Pohyb PH = new Pohyb();
            RedCol = GreenCol = BlueCol = YellowCol = OrangeCol = 1;
            RedRow = GreenRow = BlueRow = YellowRow = OrangeRow = 9;
            next = 0;
            IndexPoradi = 0;
            Konec = false;

        }
    }
}
