using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace AppsProjectMinesweeper
{

    public class Methods : Form
    {


        // deze functie returnt ook de nummers van alle random bom locaties die in een array gestopt zijn
        int fieldLengthPublic;
         public int[] generateBombLocations(int amount, int fieldLength)
        {
            fieldLengthPublic = fieldLength;
            int[] locaties = new int[amount];
            Random random = new Random();
            for (int i = 0; i < amount; i++)
            {


                int randomGetal = random.Next(0, fieldLength);

                // als het getal nog niet in de array zit voeg dan het getal toe
                if (!locaties.Contains(randomGetal))
                    locaties[i] = randomGetal;
                // als het getal al in de array zit genereer dan een nieuw getal
                else
                {
                    // genereer een nieuw getal als het getal zelf al in de array zit 
                    int nieuwRandomGetal = random.Next(0, fieldLength);
                    // blijf het net zo lang herhalen totdat het nieuwe gegenereerde getal niet in de array zit 
                    while (locaties.Contains(nieuwRandomGetal))
                    {
                        nieuwRandomGetal = random.Next(0, fieldLength);
                    }
                    locaties[i] = nieuwRandomGetal;


                }



            }
            return locaties;


        }

        // de methode die de int zet voor de count int van de Form2.cs zet
        public int getCount(string difficulty)

        {

            // count is standaard 10(10 is easy difficulty) (VOOR HET AANTAL VLAGGETJES DAT JE KUNT ZETTEN)
            int count = 10;
            // als de difficulty op easy staat dan mag de speler 10 vlaggetjes zetten, enzovoort 
            if (difficulty.Equals("Easy"))
            {
                count = 10;
                return count;

            }
            else if (difficulty.Equals("Medium"))
            {
                count = 40;
                return count;
            }
            else
            {
                count = 99;
                return count;
            }
        }

        public int[] generateNumberLocations(int[] locaties, int fieldlength)
        {
            int[] numbersInField = new int[fieldlength];
            int No;
            int NoEa;
            int Ea = 1;
            int SoEa;
            int So;
            int SoWe;
            int We = -1;
            int NoWe;
            if (fieldlength == 80)
            {
                No = -10;
                NoEa = -9;
                NoWe = -11;
                So = 10;
                SoEa = 11;
                SoWe = 9;
                foreach (int n in locaties)
                {
                    // Top row minus corners
                    if (n <= 8 && n != 0)
                    {
                        numbersInField[n + Ea] += 1;
                        numbersInField[n + We] += 1;
                        numbersInField[n + SoEa] += 1;
                        numbersInField[n + SoWe] += 1;
                        numbersInField[n + So] += 1;
                    }
                    // Corner left top
                    else if (n == 0)
                    {
                        numbersInField[n + Ea] += 1;
                        numbersInField[n + SoEa] += 1;
                        numbersInField[n + So] += 1;
                    }
                    // Corner right top
                    else if (n == 9)
                    {
                        numbersInField[n + We] += 1;
                        numbersInField[n + SoWe] += 1;
                        numbersInField[n + So] += 1;
                    }
                    // Not touching border (middel)
                    else if (n >= 11 && n <= 18 || n >= 21 && n <= 28 || n >= 31 && n <= 38 || n >= 41 && n <= 48 || n >= 51 && n <= 58 || n >= 61 && n <= 68)
                    {
                        numbersInField[n + No] += 1;
                        numbersInField[n + NoEa] += 1;
                        numbersInField[n + NoWe] += 1;
                        numbersInField[n + We] += 1;
                        numbersInField[n + Ea] += 1;
                        numbersInField[n + SoEa] += 1;
                        numbersInField[n + SoWe] += 1;
                        numbersInField[n + So] += 1;
                    }
                    // Bottom minus corners
                    else if (n >= 71 && n != 79)
                    {
                        numbersInField[n + No] += 1;
                        numbersInField[n + NoEa] += 1;
                        numbersInField[n + NoWe] += 1;
                        numbersInField[n + We] += 1;
                        numbersInField[n + Ea] += 1;
                    }
                    // Corner right bottom
                    else if (n == 79)
                    {
                        numbersInField[n + No] += 1;
                        numbersInField[n + NoWe] += 1;
                        numbersInField[n + We] += 1;
                    }
                    // Corner left bottom
                    else if (n == 70)
                    {
                        numbersInField[n + No] += 1;
                        numbersInField[n + NoEa] += 1;
                        numbersInField[n + Ea] += 1;
                    }
                    // Left row minus corners
                    else if (n == 10 || n == 20 || n == 30 || n == 40 || n == 50 || n == 60)
                    {
                        numbersInField[n + No] += 1;
                        numbersInField[n + NoEa] += 1;
                        numbersInField[n + Ea] += 1;
                        numbersInField[n + SoEa] += 1;
                        numbersInField[n + So] += 1;
                    }
                    // Right row minus corners
                    else
                    {
                        numbersInField[n + No] += 1;
                        numbersInField[n + NoWe] += 1;
                        numbersInField[n + We] += 1;
                        numbersInField[n + SoWe] += 1;
                        numbersInField[n + So] += 1;
                    }
                }
                return numbersInField;
            }
            else if (fieldlength == 252)
            {
                No = -21;
                NoEa = -20;
                NoWe = -22;
                So = 21;
                SoEa = 22;
                SoWe = 20;
                foreach (int n in locaties)
                {
                    // Top row minus corners
                    if (n <= 19 && n != 0)
                    {
                        numbersInField[n + Ea] += 1;
                        numbersInField[n + We] += 1;
                        numbersInField[n + SoEa] += 1;
                        numbersInField[n + SoWe] += 1;
                        numbersInField[n + So] += 1;
                    }
                    // Corner left top
                    else if (n == 0)
                    {
                        numbersInField[n + Ea] += 1;
                        numbersInField[n + SoEa] += 1;
                        numbersInField[n + So] += 1;
                    }
                    // Corner right top
                    else if (n == 20)
                    {
                        numbersInField[n + We] += 1;
                        numbersInField[n + SoWe] += 1;
                        numbersInField[n + So] += 1;
                    }
                    // Not touching border (middel)
                    else if (n >= 22 && n <= 40 || n >= 43 && n <= 61 || n >= 64 && n <= 82 || n >= 85 && n <= 103 || n >= 106 && n <= 124 || n >= 127 && n <= 145 || n >= 148 && n <= 166 || n >= 169 && n <= 187 || n >= 190 && n <= 208 || n >= 211 && n <= 229)
                    {
                        numbersInField[n + No] += 1;
                        numbersInField[n + NoEa] += 1;
                        numbersInField[n + NoWe] += 1;
                        numbersInField[n + We] += 1;
                        numbersInField[n + Ea] += 1;
                        numbersInField[n + SoEa] += 1;
                        numbersInField[n + SoWe] += 1;
                        numbersInField[n + So] += 1;
                    }
                    // Bottom minus corners
                    else if (n >= 232 && n != 251)
                    {
                        numbersInField[n + No] += 1;
                        numbersInField[n + NoEa] += 1;
                        numbersInField[n + NoWe] += 1;
                        numbersInField[n + We] += 1;
                        numbersInField[n + Ea] += 1;
                    }
                    // Corner right bottom
                    else if (n == 251)
                    {
                        numbersInField[n + No] += 1;
                        numbersInField[n + NoWe] += 1;
                        numbersInField[n + We] += 1;
                    }
                    // Corner left bottom
                    else if (n == 231)
                    {
                        numbersInField[n + No] += 1;
                        numbersInField[n + NoEa] += 1;
                        numbersInField[n + Ea] += 1;
                    }
                    // Left row minus corners
                    else if (n == 21 || n == 42 || n == 63 || n == 84 || n == 105 || n == 126 || n == 147 || n == 168 || n == 189 || n == 210)
                    {
                        numbersInField[n + No] += 1;
                        numbersInField[n + NoEa] += 1;
                        numbersInField[n + Ea] += 1;
                        numbersInField[n + SoEa] += 1;
                        numbersInField[n + So] += 1;
                    }
                    // Right row minus corners
                    else
                    {
                        numbersInField[n + No] += 1;
                        numbersInField[n + NoWe] += 1;
                        numbersInField[n + We] += 1;
                        numbersInField[n + SoWe] += 1;
                        numbersInField[n + So] += 1;
                    }
                }
                return numbersInField;
            }
            else
            {
                No = -30;
                NoEa = -29;
                NoWe = -31;
                So = 30;
                SoEa = 31;
                SoWe = 29;
                foreach (int n in locaties)
                {
                    // Top row minus corners
                    if (n <= 28 && n != 0)
                    {
                        numbersInField[n + Ea] += 1;
                        numbersInField[n + We] += 1;
                        numbersInField[n + SoEa] += 1;
                        numbersInField[n + SoWe] += 1;
                        numbersInField[n + So] += 1;
                    }
                    // Corner left top
                    else if (n == 0)
                    {
                        numbersInField[n + Ea] += 1;
                        numbersInField[n + SoEa] += 1;
                        numbersInField[n + So] += 1;
                    }
                    // Corner right top
                    else if (n == 29)
                    {
                        numbersInField[n + We] += 1;
                        numbersInField[n + SoWe] += 1;
                        numbersInField[n + So] += 1;
                    }
                    // Not touching border (middel)
                    else if (n >= 31 && n <= 58 || n >= 61 && n <= 88 || n >= 91 && n <= 118 || n >= 121 && n <= 148 || n >= 151 && n <= 178 || n >= 181 && n <= 208 || n >= 211 && n <= 238 || n >= 241 && n <= 268 || n >= 271 && n <= 298 || n >= 301 && n <= 328 || n >= 331 && n <= 358 || n >= 361 && n <= 388 || n >= 391 && n <= 418 || n >= 421 && n <= 448)
                    {
                        numbersInField[n + No] += 1;
                        numbersInField[n + NoEa] += 1;
                        numbersInField[n + NoWe] += 1;
                        numbersInField[n + We] += 1;
                        numbersInField[n + Ea] += 1;
                        numbersInField[n + SoEa] += 1;
                        numbersInField[n + SoWe] += 1;
                        numbersInField[n + So] += 1;
                    }
                    // Bottom minus corners
                    else if (n >= 451 && n != 479)
                    {
                        numbersInField[n + No] += 1;
                        numbersInField[n + NoEa] += 1;
                        numbersInField[n + NoWe] += 1;
                        numbersInField[n + We] += 1;
                        numbersInField[n + Ea] += 1;
                    }
                    // Corner right bottom
                    else if (n == 479)
                    {
                        numbersInField[n + No] += 1;
                        numbersInField[n + NoWe] += 1;
                        numbersInField[n + We] += 1;
                    }
                    // Corner left bottom
                    else if (n == 450)
                    {
                        numbersInField[n + No] += 1;
                        numbersInField[n + NoEa] += 1;
                        numbersInField[n + Ea] += 1;
                    }
                    // Left row minus corners
                    else if (n == 30 || n == 60 || n == 90 || n == 120 || n == 150 || n == 180 || n == 210 || n == 240 || n == 270 || n == 300 || n == 330 || n == 360 || n == 390 || n == 420)
                    {
                        numbersInField[n + No] += 1;
                        numbersInField[n + NoEa] += 1;
                        numbersInField[n + Ea] += 1;
                        numbersInField[n + SoEa] += 1;
                        numbersInField[n + So] += 1;
                    }
                    // Right row minus corners
                    else
                    {
                        numbersInField[n + No] += 1;
                        numbersInField[n + NoWe] += 1;
                        numbersInField[n + We] += 1;
                        numbersInField[n + SoWe] += 1;
                        numbersInField[n + So] += 1;
                    }
                }
                return numbersInField;
            }
        }
        public List<int> flippingButtons(int y, Control[] control)
        {
            //Control control in flowLayoutPanel1.Controls
            int left = -1;
            int right = 1;
            int up;
            int down;

            if (fieldLengthPublic == 80)
            {
                up = -10;
                down = 10;
            }
            else if (fieldLengthPublic == 252)
            {
                up = -21;
                down = 21;
            }
            else
            {
                up = -30;
                down = 30;
            }


            List<int> flippingButtonsList = new List<int>();
            List<int> checkFlippingButtonsList = new List<int>();
            flippingButtonsList.Add(y);
            checkFlippingButtonsList.Add(y);
            int teller = 0;
            while (teller < 100)
            {
                if (flippingButtonsList.Count > teller)
                { 
                    int check = flippingButtonsList[teller];
                    foreach (Control ctrl in control)
                    {
                        if (ctrl.Name == "Bomb")
                        {

                        }
                        else if (check + left == int.Parse(ctrl.Name))
                        {
                            if (fieldLengthPublic == 80)
                            {
                                if (check == 10 || check == 20 || check == 30 || check == 40 || check == 50 || check == 60)
                                {

                                }
                                else if (ctrl.Text == "0")
                                {
                                    if (!flippingButtonsList.Contains(check + left))
                                    {
                                        flippingButtonsList.Add(check + left);
                                    }
                                }
                            }
                            else if (fieldLengthPublic == 252)
                            {
                                if (check == 21 || check == 42 || check == 63 || check == 84 || check == 105 || check == 126 || check == 147 || check == 168 || check == 189 || check == 210)
                                {

                                }
                                else if (ctrl.Text == "0")
                                {
                                    if (!flippingButtonsList.Contains(check + left))
                                    {
                                        flippingButtonsList.Add(check + left);
                                    }
                                }
                            }
                            else
                            {
                                if (check == 30 || check == 60 || check == 90 || check == 120 || check == 150 || check == 180 || check == 210 || check == 240 || check == 270 || check == 300 || check == 330 || check == 360 || check == 390 || check == 420)
                                {

                                }
                                else if (ctrl.Text == "0")
                                {
                                    if (!flippingButtonsList.Contains(check + left))
                                    {
                                        flippingButtonsList.Add(check + left);
                                    }
                                }
                            }
                        }

                        if (ctrl.Name == "Bomb")
                        {

                        }
                        else if (check + right == int.Parse(ctrl.Name))
                        {
                            if (fieldLengthPublic == 80)
                            {
                                if (check == 9 || check == 19 || check == 29 || check == 39 || check == 49 || check == 59 || check == 69)
                                {

                                }
                                else if (ctrl.Text == "0")
                                {
                                    if (!flippingButtonsList.Contains(check + right))
                                    {
                                        flippingButtonsList.Add(check + right);
                                    }
                                }
                            }
                            else if (fieldLengthPublic == 252)
                            {
                                if (check == 20 || check == 41 || check == 62 || check == 83 || check == 104 || check == 125 || check == 146 || check == 167 || check == 188 || check == 209 || check == 230)
                                {

                                }
                                else if (ctrl.Text == "0")
                                {
                                    if (!flippingButtonsList.Contains(check + right))
                                    {
                                        flippingButtonsList.Add(check + right);
                                    }
                                }
                            }
                            else
                            {
                                if (check == 29 || check == 59 || check == 89 || check == 119 || check == 149 || check == 179 || check == 209 || check == 239 || check == 269 || check == 299 || check == 329 || check == 359 || check == 389 || check == 419 || check == 459)
                                {

                                }
                                else if (ctrl.Text == "0")
                                {
                                    if (!flippingButtonsList.Contains(check + right))
                                    {
                                        flippingButtonsList.Add(check + right);
                                    }
                                }
                            }
                        }

                        if (ctrl.Name == "Bomb")
                        {

                        }
                        else if (check + up == int.Parse(ctrl.Name))
                        {
                            if (ctrl.Text == "0")
                            {
                                if (!flippingButtonsList.Contains(check + up))
                                {
                                    flippingButtonsList.Add(check + up);
                                }
                            }
                        }

                        if (ctrl.Name == "Bomb")
                        {

                        }
                        else if (check + down == int.Parse(ctrl.Name))
                        {
                            if (ctrl.Text == "0")
                            {
                                if (!flippingButtonsList.Contains(check + down))
                                {
                                    flippingButtonsList.Add(check + down);
                                }
                            }
                        }
                    }
                    teller++;
                }
                else
                {
                    teller++;
                }
                //flippingButtonsList.Contains(int.Parse(control.Name))
            }


            return flippingButtonsList;
        }




    }

        }

    


   


    

       

        
       // hier komen de methods in.
        
    
            

