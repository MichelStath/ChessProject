using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SQLite;

namespace ChessProject
{
    public partial class Form1 : Form
    {
        #region VAR INITIALIZATION
        private Point point;
        public int p1time = 1200;
        public int p2time = 1200;
        public String rbuattonnum = "2";
        public bool ready1 = false;
        public bool ready2 = false;
        public bool IsMouseDown;
        public String startTime;
        public String conn = @"Data Source=chessDB.db; Version=3";
        public String player1 = "";
        public String player2 = "";
        #endregion


        public Form1(String p1, String p2)
        {
            InitializeComponent();
            label17.Text = p1.ToString();
            label19.Text = p2.ToString();
            timer3.Enabled = true;
            player1 = p1;
            player2 = p2;

        }
        #region FUNCTIONS
        /// <summary>
        /// FUNCTION TO START THE GAME
        /// </summary>
        private void startgame()
        {
            MessageBox.Show("WHITE PLAYER STARTS THE GAME", "CHESS GAME WARNING");
            timer1.Enabled = true;
            timer2.Enabled = false;
            radioButton1.Enabled = false;
            radioButton2.Enabled = false;
            radioButton3.Enabled = false;
            radioButton4.Enabled = false;
            button1.Enabled = false;
            button2.Enabled = false;
            
            switch (rbuattonnum)    
            {
                case "1":
                    p1time = 600;
                    p2time = 600;
                    break;
                case "2":
                    p1time = 1200;
                    p2time = 1200;
                    break;
                case "3":
                    p1time = 1800;
                    p2time = 1800;
                    break;
                case "4":
                    p1time = 3000;
                    p2time = 3000;
                    break;
            } //INITIALIZATION OF TIME FOR EVRY RE/START

            startTime = DateTime.Now.ToString();
            putPicBoxes();
            putImages();            
        }
        /// <summary>
        /// FUNCTION TO PUT IMAGES INTO CORRECT PICTUREBOX
        /// </summary>
        private void putImages()
        {
            
            pictureBox1.BackgroundImage = Properties.Resources.RookW;
            pictureBox2.BackgroundImage = Properties.Resources.KnightW;
            pictureBox3.BackgroundImage = Properties.Resources.BishopW;
            pictureBox4.BackgroundImage = Properties.Resources.QueenW;
            pictureBox5.BackgroundImage = Properties.Resources.KingW; 
            pictureBox6.BackgroundImage = Properties.Resources.BishopW;
            pictureBox7.BackgroundImage = Properties.Resources.KnightW;
            pictureBox8.BackgroundImage = Properties.Resources.RookW;
            pictureBox9.BackgroundImage = Properties.Resources.PawnW;
            pictureBox10.BackgroundImage = Properties.Resources.PawnW;
            pictureBox11.BackgroundImage = Properties.Resources.PawnW;
            pictureBox12.BackgroundImage = Properties.Resources.PawnW;
            pictureBox13.BackgroundImage = Properties.Resources.PawnW;
            pictureBox14.BackgroundImage = Properties.Resources.PawnW;
            pictureBox15.BackgroundImage = Properties.Resources.PawnW;
            pictureBox16.BackgroundImage = Properties.Resources.PawnW;
            pictureBox17.BackgroundImage = Properties.Resources.RookB;
            pictureBox18.BackgroundImage = Properties.Resources.KnightB;
            pictureBox19.BackgroundImage = Properties.Resources.BishopB;
            pictureBox20.BackgroundImage = Properties.Resources.KingB;
            pictureBox21.BackgroundImage = Properties.Resources.QueenB;
            pictureBox22.BackgroundImage = Properties.Resources.BishopB;
            pictureBox23.BackgroundImage = Properties.Resources.KnightB;
            pictureBox24.BackgroundImage = Properties.Resources.RookB;
            pictureBox25.BackgroundImage = Properties.Resources.PawnB;
            pictureBox26.BackgroundImage = Properties.Resources.PawnB;
            pictureBox27.BackgroundImage = Properties.Resources.PawnB;
            pictureBox28.BackgroundImage = Properties.Resources.PawnB;
            pictureBox29.BackgroundImage = Properties.Resources.PawnB;
            pictureBox30.BackgroundImage = Properties.Resources.PawnB;
            pictureBox31.BackgroundImage = Properties.Resources.PawnB;
            pictureBox32.BackgroundImage = Properties.Resources.PawnB;
        }
        /// <summary>
        /// FUNCTION TO PUT PICTURBOXES INTO RIGHT STARTING POSSITION
        /// </summary>
        private void putPicBoxes()
        {
            pictureBox1.Location = new Point(0,700);
            pictureBox2.Location = new Point(100,700);
            pictureBox3.Location = new Point(200,700);
            pictureBox4.Location = new Point(300,700);
            pictureBox5.Location = new Point(400,700);
            pictureBox6.Location = new Point(500,700);
            pictureBox7.Location = new Point(600,700);
            pictureBox8.Location = new Point(700,700);
            pictureBox9.Location = new Point(700,600);
            pictureBox10.Location = new Point(600,600);
            pictureBox11.Location = new Point(500,600);
            pictureBox12.Location = new Point(400,600);
            pictureBox13.Location = new Point(300,600);
            pictureBox14.Location = new Point(200,600);
            pictureBox15.Location = new Point(100,600);
            pictureBox16.Location = new Point(0,600);
            pictureBox17.Location = new Point(700,0);
            pictureBox18.Location = new Point(600,0);
            pictureBox19.Location = new Point(500,0);
            pictureBox20.Location = new Point(400,0);
            pictureBox21.Location = new Point(300,0);
            pictureBox22.Location = new Point(200,0);
            pictureBox23.Location = new Point(100,0);
            pictureBox24.Location = new Point(0,0);
            pictureBox25.Location = new Point(700,100);
            pictureBox26.Location = new Point(600,100);
            pictureBox27.Location = new Point(500,100);
            pictureBox28.Location = new Point(400,100);
            pictureBox29.Location = new Point(300,100);
            pictureBox30.Location = new Point(200,100);
            pictureBox31.Location = new Point(100,100);
            pictureBox32.Location = new Point(0,100);
        }
        /// <summary>
        /// FUNCTION TO PUT IMAGE IN CENTER
        /// </summary>
        private void CenterPiece(PictureBox p)
        {
            Point center = new Point(1000, 1000);
            int newX;
            int oldX = Math.Abs(center.X - p.Location.X) + Math.Abs(center.Y - p.Location.Y);

            for (int x = 0; x <= 700; x += 100)
            {
                for (int y = 0; y <= 700; y += 100)
                {
                    newX = Math.Abs(p.Location.X - x) + Math.Abs(p.Location.Y - y);

                    if (newX < oldX)
                    {
                        center.X = x;
                        center.Y = y;

                        oldX = newX;
                    }
                }
            }

            p.Location = center;
        }
        #endregion

        private void Form1_Load(object sender, EventArgs e)
        {
            
        }

        #region PLAYER READY BUTTONS
        /// <summary>
        /// PLAYER 1 READY BUTTON
        /// </summary>
        private void button1_Click(object sender, EventArgs e)
        {
            button1.BackColor = Color.Green;
            ready1 = true;
            if (ready1 && ready2)
            {
                startgame();
            }

        }
        /// <summary>
        /// PLAYER 2 READY BUTTON
        /// </summary>
        private void button2_Click(object sender, EventArgs e)
        {
            button2.BackColor = Color.Green;
            ready2 = true;
            if (ready1 && ready2)
            {
                startgame();
            }
        }
        #endregion

        #region TIMERS
        /// <summary>
        /// TIMER FOR P1 CLOCK
        /// </summary>
        private void timer1_Tick(object sender, EventArgs e)
        {
            label18.Text = p1time.ToString();
            p1time -= 1;           
            if (p1time == 0)
            {
                timer1.Enabled = false;
                timer2.Enabled = false;
                MessageBox.Show(player1 +" YOU RAN OUT OF TIME" + Environment.NewLine +
                               "GONGRATULATION !!!"             + Environment.NewLine +
                                player2 + " WON THE GAME", "CHESS GAME");
                MessageBox.Show(player1 + " REVENGE TIME" + Environment.NewLine +
                               "PRESS RESTART TO PLAY AGAIN","CHESS GAME");
            }
        }
        /// <summary>
        /// TIMER FOR P2 CLOCK
        /// </summary>
        private void timer2_Tick(object sender, EventArgs e)
        {
            label20.Text = p2time.ToString();
            p2time -= 1;
            if (p2time == 0)
            {
                timer2.Enabled = false;
                timer1.Enabled = false;
                MessageBox.Show(player2 + " YOU RAN OUT OF TIME" + Environment.NewLine +
                               "GONGRATULATION !!!"              + Environment.NewLine +
                                player1 + " YOU WON THE GAME", "CHESS GAME");
                MessageBox.Show(player2 + " REVENGE TIME"   + Environment.NewLine +
                               "PRESS RESTART TO PLAY AGAIN", "CHESS GAME");
            }
        }
        /// <summary>
        /// TIMER FOR DATE/TIME
        /// </summary>
        private void timer3_Tick(object sender, EventArgs e)
        {
            label23.Text = DateTime.Now.ToString();
        }
        #endregion

        #region RADIOBUTTONS
        /// <summary>
        /// CHANGE TIME RADIOBUTTONS
        /// </summary>
        private void radioButton1_CheckedChanged(object sender, EventArgs e)
        {
            p1time = 600;
            p2time = 600;
            label18.Text = p1time.ToString();
            label20.Text = p2time.ToString();
            rbuattonnum = "1";
        }
        private void radioButton2_CheckedChanged(object sender, EventArgs e)
        {
            p1time = 1200;
            p2time = 1200;
            label18.Text = p1time.ToString();
            label20.Text = p2time.ToString();
            rbuattonnum = "2";
        }
        private void radioButton3_CheckedChanged(object sender, EventArgs e)
        {
            p1time = 1800;
            p2time = 1800;
            label18.Text = p1time.ToString();
            label20.Text = p2time.ToString();
            rbuattonnum = "3";
        }
        private void radioButton4_CheckedChanged(object sender, EventArgs e)
        {
            p1time = 3000;
            p2time = 3000;
            label18.Text = p1time.ToString();
            label20.Text = p2time.ToString();
            rbuattonnum = "4";
        }
        #endregion

        #region MENU STRIP
        /// <summary>
        /// EXIT MENU BUTTON
        /// </summary>
        private void eXITToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Close();
        }
        /// <summary>
        /// RESTART MENU BUTTON
        /// </summary>
        private void rESTARTToolStripMenuItem_Click(object sender, EventArgs e)
        {
            button1.BackColor = Color.Red;
            button2.BackColor = Color.Red;
            button1.Enabled = true;
            button2.Enabled = true;
            ready1 = false;
            ready2 = false;
            timer1.Enabled = false;
            timer2.Enabled = false;
            radioButton1.Enabled = true;
            radioButton2.Enabled = true;
            radioButton3.Enabled = true;
            radioButton4.Enabled = true;
            radioButton2.Checked = true;
            rbuattonnum = "2";
        }
        /// <summary>
        /// SAVE MENU BUTTON
        /// </summary>
        private void sAVEToolStripMenuItem_Click(object sender, EventArgs e)
        {
            using (SQLiteConnection connection = new SQLiteConnection(conn))
            {
                connection.Open();
                SQLiteCommand command = new SQLiteCommand();
                String myQuery = @"INSERT INTO chess (playerA,playerB,dateTime) VALUES (@playerA,@playerB,@dateTime)";
                command.CommandText = myQuery;
                command.Connection = connection;
                command.Parameters.Add(new SQLiteParameter("@playerA", player1));
                command.Parameters.Add(new SQLiteParameter("@playerB", player2));
                command.Parameters.Add(new SQLiteParameter("@dateTime", startTime));
                command.ExecuteNonQuery();
                connection.Close();
                MessageBox.Show("GAME SAVED SUCCESFULLY" + Environment.NewLine +
                                 player1 + " VS " + player2 + " AT " + startTime);
            }
        }
        #endregion
      
        #region PICTUREBOX EVENTS
        /// <summary>
        /// MOUSE DOWN
        /// </summary>               
        private void pictureBoxW_MouseDown(object sender, MouseEventArgs e)
        {
            point = e.Location;
            timer2.Enabled = false;
            timer1.Enabled = true;
            IsMouseDown = true;
        }
        private void pictureBoxB_MouseDown(object sender, MouseEventArgs e)
        {
            point = e.Location;
            IsMouseDown = true;
            timer2.Enabled = true;
            timer1.Enabled = false;
        }
        /// <summary>
        /// MOUSE UP
        /// </summary>
        private void pictureBoxW_MouseUp(object sender, MouseEventArgs e)
        {
            timer1.Enabled = false;
            timer2.Enabled = true;
            IsMouseDown = false;
            var p = sender as PictureBox;
            CenterPiece(p);
        }      
        private void pictureBoxB_MouseUp(object sender, MouseEventArgs e)
        {
            timer2.Enabled = false;
            timer1.Enabled = true;
            IsMouseDown = false;
            var p = sender as PictureBox;
            CenterPiece(p);
        }       
        /// <summary>
        /// MOUSE MOVE
        /// </summary>       
        private void pictureBox_MouseMove(object sender, MouseEventArgs e)
        {
            if (!IsMouseDown)
                return;

            var pictureBox = sender as PictureBox;
            Point z = new Point(pictureBox.Location.X + e.Location.X - 50, pictureBox.Location.Y + e.Location.Y);
            pictureBox.Location = z;
        }
        /// <summary>
        /// MOUSE DOUBLECLICK //EAT PICTUREBOX
        /// </summary>
        private void pictureBox_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            var pictureBox = sender as PictureBox;
            Point z = new Point(1000,1000);
            pictureBox.Location = z;
        }
        #endregion
    }
}

