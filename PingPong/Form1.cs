using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PingPong
{
    public partial class Form1 : Form
    {
        private int speed_ver = 2;
        private int speed_hor = 2;
        private int score = 0;
                    
        public Form1()
        {
            InitializeComponent();

            timer.Enabled = true; // Если значение true,то мы можем отслеживать различные передвиженеия 

            Cursor.Hide(); // скрытие курсора во время игры
            this.FormBorderStyle = FormBorderStyle.None;  //  убираем обводку окна
            this.TopMost = true; // позволяет программе быть всегда поверх других программ

            this.Bounds = Screen.PrimaryScreen.Bounds; // когда запуститься программа, то размеры прлограммы будут одинаковы по ширине и по высоте

            gamePanel.Top = background.Bottom - (background.Bottom / 10); // gamepanel будет находиться снизу

            loselabel.Visible = false;
            loselabel.Left = (background.Width/2) - (loselabel.Width/2);
            loselabel.Top = (background.Height / 2) - (loselabel.Height / 2);
        }
                     
        private void Form1_KeyDown(object sender, KeyEventArgs e) //если нажали escape,то закрыть окно с программой
        {
            if (e.KeyCode == Keys.Escape)
                this.Close();
            if (e.KeyCode == Keys.Enter)
            {
                gameBol.Top = 50;
                gameBol.Left = 70;
                speed_hor = 2;
                speed_ver = 2;
                score = 0;
                loselabel.Visible = false;
                timer.Enabled = true;
                result.Text = "Результат: 0";

            }
        }

        private void timer_Tick(object sender, EventArgs e)
        {
            gamePanel.Left = Cursor.Position.X - (gamePanel.Width / 2);

            gameBol.Left += speed_hor;
            gameBol.Top += speed_ver;

            if (gameBol.Left <= background.Left)
                speed_hor *= -1;

            if (gameBol.Right >= background.Right)
                speed_hor *= -1;

            if (gameBol.Top <= background.Top)
                speed_ver *= -1;

            if (gameBol.Bottom >= background.Bottom)
            {
                loselabel.Visible = true;
                timer.Enabled = false;
            }

            if (gameBol.Bottom >= gamePanel.Top && gameBol.Bottom <= gamePanel.Bottom
                                              && gameBol.Left >= gamePanel.Left
                                              && gameBol.Right <= gamePanel.Right)
            {
                speed_hor += 2;
                speed_ver += 2;
                speed_ver *= -1;
                score += 1;
                result.Text = "Резульатат: " + score.ToString();

                Random randColor = new Random();
                background.BackColor = Color.FromArgb(randColor.Next(150,255), randColor.Next(150, 255), randColor.Next(150, 255));
            }

        }

        
    }
}

