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
   
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            // verlaat de applicatie als er op de exit knop wordt gedrukt
            Application.Exit();
        }

        private void btnStart_Click(object sender, EventArgs e)
        {
            string difficulty = "0";
            
            if(rbEasy.Checked)
            {
                difficulty = "Easy";

            }
            if(rbMedium.Checked)
            {
                difficulty = "Medium";
            }
            if(rbHard.Checked)
            {
                difficulty = "Hard";
            }

            // Open de andere form als er op de start knop wordt gedrukt

            this.Hide();
            var form2 = new Form2(difficulty);
            form2.Closed += (s, args) => this.Close();
            form2.Show();
        }
    }
}
