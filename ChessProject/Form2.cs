using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ChessProject
{
    public partial class Form2 : Form
    {
        public Form2()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            string p1 = textBox1.Text.ToString();
            string p2 = textBox2.Text.ToString();
            Form1 f = new Form1(p1,p2); 
            f.Show();           
        }

        private void eXITToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void Form2_Load(object sender, EventArgs e)
        {

        }

        private void iINFOToolStripMenuItem_Click(object sender, EventArgs e)
        {
            MessageBox.Show("1) TO EAT ENEMY YOU HAVE TO DOUBLE-CLICK FIRST AND THEN MOVE."+Environment.NewLine+
                            "2) YOU CAN CHOOSE YOUR PLAYING TIME."                         +Environment.NewLine+
                            "3) YOU CAN RESTART/SAVE YOUR GAME ANY TIME"                   +Environment.NewLine+
                            "4) GAME ENDS ONLY AFTER TIME IS UP"                           +Environment.NewLine+
                            "5) BOTH PLAYERS MUST BE READY TO START THE GAME","CHESS HELP");
        }
    }
}
