using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;



namespace AppsProjectMinesweeper
{
    public partial class Form2 : Form
    {
       int[] allHighScores = new int[3];
        string name = "Default";
        int counter = 10;
        bool newField = false;
        // de bool die bijhoudt of je game over bent gegaan
        bool gameOver = false;
        bool revealBombs = false;
        int[] locaties = { 0, 0, 0, 0, 0, 0, 0, 0 };
        int bombAmount = 10;
        // het aantal highscores
        int aantal = 0;
        //counter
        int xi;
        
        
        string diff = "Easy";
        
        // // het getal dat de rijen bijhoudt. \ elke rij heeft nu als button name 1,2,3,4,5,6,7,8,9
        int newGetal = 1;
       
        // de basis lengte voor het veld 
        int fieldLength = 80;

        // Nu kunnen andere functies ook gebruik maken van de difficulty meegegeven uit form 1
        string setDifficulty;
        // Declare Timer value
        int mineTimer;

        
        Methods methods = new Methods();

        // krijg een string mee van form1 en noem die string difficulty (deze string geeft de difficulty die is geselecteerd door)
        public Form2(string difficulty)
        {
            diff = difficulty;
            int count = methods.getCount(difficulty);
            InitializeComponent();
            setDifficulty = difficulty;


          

            //Als hard difficulty is geselecteerd tel af vanaf 200.
            if (easyToolStripMenuItem.Text == setDifficulty)
            {
                easyToolStripMenuItem.Checked = true;
            }
            else if (mediumToolStripMenuItem.Text == setDifficulty)
            {
                mediumToolStripMenuItem.Checked = true;
            }
            else
            {
                hardToolStripMenuItem.Checked = true;
                mineTimer = 300;
            }
           
            
            counter = methods.getCount(difficulty);
            CreateField();


        }








        private void btnField_MouseDown(object sender, EventArgs e)

        {
            MouseEventArgs me = (MouseEventArgs)e;
            Control ctrl = ((Control)sender);
            
            // slaat de basis naam op 
          
           
           
            
            // deze boolean is true als er een nieuw veld wordt gegenereerd kijk naar de functie CreateField() en dan moet hij de counter weer resetten
            // naar de value die bij de difficulty hoort 
            if (newField)

            {
                // als je een new field aanmaakt is het niet de bedoeling dat je game over bent gelijk
                gameOver = false;
                // de label moet niet meer game over displayen

                newField = false;
                counter = methods.getCount(diff);

            }



            // als je de linkermuisknop indrukt en niet game over bent

            if (me.Button == MouseButtons.Left && !gameOver)
            {



                // de tag is true als de button een bomb is 
                
                // als je niet game over bent kun je op buttons drukken en dan de value revealen
                if (!gameOver)
                {
                    // als het een bom is wil je hem revealen als bomb
                    if (ctrl.Tag.ToString() == "True")
                    {
                        ctrl.Text = "BOMb";
                        ctrl.BackColor = Color.Red;




                    }
                    else
                    {


                        if (ctrl.BackColor == Color.Blue)
                        {
                            ctrl.ForeColor = Color.Black;

                            counter++;
                            lblCounter.Text = "Vlaggetjes over: " + counter.ToString();
                            ctrl.BackColor = Color.White;


                        }




                    }




                    // deze boolean is true als er een nieuw veld wordt gegenereerd kijk naar de functie CreateField() en dan moet hij de counter weer resetten
                    // naar de value die bij de difficulty hoort 



                    // als de button waar op gedrukt wordt een bom is doe dan:
                    if (ctrl.Tag.ToString() == "True")
                    {
                        // Als je een bom opgraaft dan ben je game over en kun je verder niets meer doen
                        gameOver = true;
                        // stop de timer als je game over bent 
                        timeTimer.Stop();


                        lblGameOver.Text = "Game Over";
                        // laat bommen zien als je af bent
                        showBombs();






                    }
                    else if (ctrl.Text == "0")
                        {
                            int y = int.Parse(ctrl.Name);
                            xi = 0;
                            Control[] controlList = new Control[fieldLength];
                            foreach (Control control in flowLayoutPanel1.Controls)
                            {
                                if (control.Name == "btnField")
                                {
                                    continue;
                                }
                                controlList[xi] = control;
                                xi++;
                            }
                            List<int> flipTheseButtons = methods.flippingButtons(y, controlList);
                            foreach (Control control in flowLayoutPanel1.Controls)
                            {
                                if (control.Name == "btnField")
                                {
                                    continue;
                                }

                                if (control.Name == "Bomb")
                                {
                                    continue;
                                }
                                else if (flipTheseButtons.Contains(int.Parse(control.Name)))
                                {
                                    control.ForeColor = Color.Black;
                                }
                            }
                        }
                    else
                    {
                        ctrl.ForeColor = Color.Black;
                    }

                    if (allButtonsPressed())
                    {
                        int[] scoreOrder;
                        // stop de timer als je gewonnen hebt 
                        timeTimer.Stop();
                        // om de score bij te houden

                        string leaderbordString = name + " " + lblTimerCijfer.Text;



                        lbHighScores.Items.Add(leaderbordString);
                        if(diff.Equals("Hard"))
                        {

                            
                        }
                        
                        lblGameOver.Text = "GEWONNEN";
                        gameOver = true;
                        
                    }
                    // return zodat je niet de linker en de rechtermuisknop tegelijk kan indrukken, want dan gebeurt er een bug 
                    return;
                }
            }
            else if (me.Button == MouseButtons.Right && !gameOver)
            {

                // als de button al getagd is doe dan er weer een optellen bij de counter verander de naam en maak de kleur weer wit 
                if (ctrl.BackColor == Color.Blue)
                {

                    counter++;
                    lblCounter.Text = "Vlaggetjes over: " + counter.ToString();
                    ctrl.BackColor = Color.White;
                    ctrl.ForeColor = Color.White;
                    

                }

                // als het nog niet getagd is dan moet counter groter zijn dan 0 om het wel te kunnen taggen 
                else if (counter > 0 && ctrl.ForeColor != Color.Black)
                {

                    ctrl.BackColor = Color.Blue;
                    ctrl.ForeColor = Color.Blue;
                    counter--;
                    lblCounter.Text = "Vlaggetjes over: " + counter.ToString();
                    
                }
                // als er een nieuw veld wordt aangemaakt moet de counter opnieuw op 10 gezet worden 

                // als je alle bommen hebt gemarkt heb je gewonnen
                if (allBombsMarked())
                {
                    string leaderbordString = name + " " + lblTimerCijfer.Text;

                    // sorteer de high scores
                    lbHighScores.Items.Add(leaderbordString);
                    
                    if (diff.Equals("Hard"))
                    {


                    }
                    lblGameOver.Text = "GEWONNEN";
                    gameOver = true;
                    timeTimer.Stop();
                }
                // zodat je niet linker en rechtermuisknop tegelijk kunt indrukken en een rare bug kunt laten gebeuren
                return;
            }
            
        }
       
            

        
        
        

        private void CreateField()
        {
           
            // de bool houdt bij of er een nieuwe field is 
            newField = true;
            int[] closeCounter = methods.generateNumberLocations(locaties, fieldLength);
            locaties = methods.generateBombLocations(10, 80);
            
            
            if (setDifficulty.Equals("Easy"))
            {
                
                // 10 bommen 
                
                fieldLength = 80;
                bombAmount = 10;
                lblCounter.Text = "Vlaggetjes over: " +  bombAmount.ToString();
                flowLayoutPanel1.Size = new System.Drawing.Size(316, 350);
                // als je game over bent gegaan
               
                    
                locaties = methods.generateBombLocations(10, 80);
                closeCounter = methods.generateNumberLocations(locaties, fieldLength);

            }
            else if (setDifficulty.Equals("Medium"))
            {
                // 40 bommen 
                fieldLength = 252;
                bombAmount = 40;
                lblCounter.Text = "Vlaggetjes over: " + bombAmount.ToString();
                flowLayoutPanel1.Size = new System.Drawing.Size(680, 660);
               
                locaties = methods.generateBombLocations(40, 252);
                closeCounter = methods.generateNumberLocations(locaties, fieldLength);

            }
            else
            {
                // 99 bommen 
                fieldLength = 480;
                bombAmount = 99;
                lblCounter.Text = "Vlaggetjes over: " + bombAmount.ToString();
                flowLayoutPanel1.Size = new System.Drawing.Size(940, 660);
                
                locaties = methods.generateBombLocations(99, 480);
                closeCounter = methods.generateNumberLocations(locaties, fieldLength);


            }

            // dit is de for loop die elke keer een nieuw button object aanmaakt(zorgt ervoor dat het veld gemaakt wordt)

          
           


               

            
            for (int i = 0; i <= fieldLength - 1; i++)
            {




               
                    Button btnField = new Button();














                
                    btnField.Name = i.ToString();

                    btnField.Size = new System.Drawing.Size(25, 25);


                    btnField.Tag = "False";


                    btnField.BackColor = Color.White;
                    btnField.ForeColor = Color.White;
                    btnField.UseVisualStyleBackColor = false;

                    // Voegt de funtie btnField_Click toe aan de button mousedown event.
                    btnField.MouseDown += btnField_MouseDown;
                    flowLayoutPanel1.Controls.Add(btnField);


                    flowLayoutPanel1.Controls.Add(btnField);
                    if (locaties.Contains(i))
                    {


                        // zet de tag naar true als de button een bom is
                        btnField.Tag = "True";
                        btnField.Name = "Bomb";
                        btnField.Text = "bomb";
                        btnField.ForeColor = Color.White;

                    




                    
                }
                else
                {
                    btnField.Text = closeCounter[i].ToString();
                }

            }
               

            
        }
        private void showBombs()
        {
            // loop door de hele flowlayoutpanel waar alle velden in zitten 
            foreach (Control c in flowLayoutPanel1.Controls)
            {


                // als de forecolor gelijk is aan rood(kon niet checken met de tag)(dan is het een bom uiteraard)
                if (c.Tag == null)
                {



                }
                else if (c.Tag.ToString() == "True")
                {
                    // zet gelijk weer de ForeColor naar zwart(wat de basis is)(omdat de ForeColor werkt als een check voor of het een bom is)
                    c.ForeColor = Color.Black;
                    c.Text = "Bomb";
                    c.BackColor = Color.Red;
                }
               
            }
        }
        private bool allBombsMarked()
        {
            int bombCount = 0;
            foreach(Control c in flowLayoutPanel1.Controls)
            {
                // als het een bom is 
                if (c.Tag == null)
                {

                }
                else if(c.Tag.ToString() == "True")
                {
                    // als er een vlaggetje geplaatst is op de bom
                    if(c.BackColor == Color.Blue)
                        bombCount++;

                }
            }
            // als het aantal bommen dat getagd is gelijk aan het totaal aantal bommen
            if(bombCount == bombAmount)
            {

                // dan return true
                return true;

            }
            // anders return false
            return false;
        }
        private bool allButtonsPressed()
        {
            int countAmountButton = 0;
            foreach(Control c in flowLayoutPanel1.Controls)
            {
                /* als de text null is dan betekent het dat je nog niet op het veld gedrukt hebt om het cijfer te tonen 
                 * Ik reken de bommen niet mee  
                 * if statement zegt als er op het vakje is gedrukt en als het geen bom is doe dan countAmount++
                 * */
                
                if(c.ForeColor == Color.Black)
                {
                    countAmountButton++;
                }
            }
            
            // als het aantal vakjes min het aantal bommen gelijk is aan de count dan return true anders return false
            if(countAmountButton == (fieldLength - bombAmount))
            {
                return true;
            }
            return false;
        }



     
       
        // elke tick van de timer (1000 miliseconden (1 seconden))
        
        private void timeTimer_Tick(object sender, EventArgs e)
        {
            // als de difficulty hard is timer count down
            if (setDifficulty == "Hard")
            {
                // als timer 0 is
                if (mineTimer == 0)
                {
                    // zet timer uit
                    timeTimer.Stop();
                    showBombs();
                    gameOver = true;
                    lblGameOver.Text = "Game Over";
                    newField = false;
                }
                else
                {
                    // anders timer - 1 is timer, zet label naar cijfer.
                    mineTimer--;
                    lblTimerCijfer.Text = mineTimer.ToString();
                }
            }
            // anders timer telt op
            else
            {
                mineTimer++;
                lblTimerCijfer.Text = mineTimer.ToString();
            }
        }

        //Click op restart knop
        private void btnRestart_Click(object sender, EventArgs e)
        {
            // zet de game over tekst weer leeg(wat de basis tekst is)
            lblGameOver.Text = "";

            
           
            // Disabled timer als hij nog loopt
            if (timeTimer.Enabled)
            {
                timeTimer.Stop();
            }
            CheckCheckedMenu();
            //clears the flowLayoutPanel1
            flowLayoutPanel1.Controls.Clear(); 
            CreateField();
            // reset timer
            if (setDifficulty == "Hard")
            {
                mineTimer = 300;
                lblTimerCijfer.Text = "300";
            }
            else
            {
                mineTimer = 0;
                lblTimerCijfer.Text = "0";
            }
            // start timer
            timeTimer.Start();
        }
        // Check het menu op welke knop is gechecked
        private void CheckCheckedMenu()
        {
            if (easyToolStripMenuItem.Checked)
            {
                setDifficulty = "Easy";
            }
            else if (mediumToolStripMenuItem.Checked)
            {
                setDifficulty = "Medium";
            }
            else
            {
                setDifficulty = "Hard";
            }
        }

        // Veranderd het menu als er een diffeculty wordt geselecteerd
        private void ChangeCheckedMenu(string d)
        {
            if (d == "Easy")
            {
                easyToolStripMenuItem.Checked = true;
                mediumToolStripMenuItem.Checked = false;
                hardToolStripMenuItem.Checked = false;
            }
            else if (d == "Medium") 
            { 
                easyToolStripMenuItem.Checked = false;
                mediumToolStripMenuItem.Checked = true;
                hardToolStripMenuItem.Checked = false;
            }
            else
            {
                easyToolStripMenuItem.Checked = false;
                mediumToolStripMenuItem.Checked = false;
                hardToolStripMenuItem.Checked = true;
            }
        }
        //Als er op een van de menu diffeculties wordt geklikt.
        private void easyToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ChangeCheckedMenu("Easy");
            // zet de string diff naar easy, zodat ik via de functie btnField_Click de difficulty ook hier goed kan verstellen
            diff = "Easy";
        }

        private void mediumToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ChangeCheckedMenu("Medium");
            // zet de string diff naar medium, zodat ik via de functie btnField_Click de difficulty ook hier goed kan verstellen
            diff = "Medium";
        }

        private void hardToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ChangeCheckedMenu("Hard");
            // zet de string diff naar hard, zodat ik via de functie btnField_Click de difficulty ook hier goed kan verstellen
            diff = "Hard";
        }

        private void eXITToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void btnEnterName_Click(object sender, EventArgs e)
        {
            name = txtName.Text;
            txtName.Clear();
            lblYourName.Text = "Your Name: " + name;
            
            
        }
    }
}
