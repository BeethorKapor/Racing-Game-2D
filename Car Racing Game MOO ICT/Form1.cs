using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Car_Racing_Game_MOO_ICT
{
    public partial class Form1 : Form
    {

        int roadSpeed;
        int trafficSpeed;
        int playerSpeed = 12;
        int score;
        int highScore;
        int carImage;

        Random rand = new Random();
        Random carPosition = new Random();

        bool goleft, goright;

        private bool paused = true;

        public Form1()
        {
            InitializeComponent();
            ResetGame();
            this.KeyPreview = true;
        }

        private void keyisdown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.A)
            {
                goleft = true;
            }
            if (e.KeyCode == Keys.D)
            {
                goright = true;
            }
        }

        private void keyisup(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.A)
            {
                goleft = false;
            }
            if (e.KeyCode == Keys.D)
            {
                goright = false;
            }
        }

        private void gameTimerEvent(object sender, EventArgs e)
        {
            //ການນັບຄະແນນ
            if (AI1.Top > 520)
            {
                score += 1;
            }
            if (AI2.Top > 520)
            {
                score += 1;
            }
            txtScore.Text = "ຄະແນນ:" + score;

            //ກຳນົດທິດການການເຄື່ອນທີ່
            if (goleft == true && player.Left > 10)
            {
                player.Left -= playerSpeed;
            }
            if (goright == true && player.Left < 415)
            {
                player.Left += playerSpeed;
            }
            //ກໍານົດທາງ
            roadTrack1.Top += roadSpeed;
            roadTrack2.Top += roadSpeed;

            if (roadTrack2.Top > 519)
            {
                roadTrack2.Top = -519;
            }
            if (roadTrack1.Top > 519)
            {
                roadTrack1.Top = -519;
            }
            //ກໍານົດລົດ
            AI1.Top += trafficSpeed;
            AI2.Top += trafficSpeed;


            if (AI1.Top > 530)
            {
                changeAIcars(AI1); //ເອີ້ນໃຊ້ຟັງເຊີນ
            }

            if (AI2.Top > 530)
            {
                changeAIcars(AI2);//ເອີ້ນໃຊ້ຟັງເຊີນ
            }
            //ເກມຈົບ(Over Game)
            if (player.Bounds.IntersectsWith(AI1.Bounds) || player.Bounds.IntersectsWith(AI2.Bounds))
            {
                gameOver();//ເອື້ນໃຊ້ຟັງເຊີນ
            }
            //ກໍານົດຄວາມໄວຂອງທາງໂດຍທຽບກັບຄະແນນ
            if (score >= 20 && score < 50)
            {
                //award.Image = Properties.Resources.silver;
                roadSpeed = 20;
                trafficSpeed = 22;
            }

            if (score >= 50)
            {
                //award.Image = Properties.Resources.gold;
                trafficSpeed = 27;
                roadSpeed = 25;
            }
        }
        //ຟັງເຊີນ ການປ່ຽນ ຫຼື random ລົດ
        private void changeAIcars(PictureBox tempCar)
        {
            carImage = rand.Next(1, 8);

            switch (carImage)
            {
                case 1:
                    tempCar.Image = Properties.Resources.carGreen;
                    break;
                case 2:
                    tempCar.Image = Properties.Resources.carGrey;
                    break;
                case 3:
                    tempCar.Image = Properties.Resources.carOrange;
                    break;
                case 4:
                    tempCar.Image = Properties.Resources.carPink;
                    break;
                case 5:
                    tempCar.Image = Properties.Resources.CarRed;
                    break;
                case 6:
                    tempCar.Image = Properties.Resources.carYellow;
                    break;
                case 7:
                    tempCar.Image = Properties.Resources.TruckBlue;
                    break;
                case 8:
                    tempCar.Image = Properties.Resources.TruckWhite;
                    break;
            }

            tempCar.Top = carPosition.Next(100, 400) * -1;

            if ((string)tempCar.Tag == "carLeft")
            {
                tempCar.Left = carPosition.Next(5, 200);
            }
            if ((string)tempCar.Tag == "carRight")
            {
                tempCar.Left = carPosition.Next(245, 422);
            }
        }
        //ຟັງເຊີນເກມ Over Game
        private void gameOver()
        {
            System.Media.SoundPlayer playCrash = new System.Media.SoundPlayer(Properties.Resources.Ambulance_Sound);
            playCrash.Stop();
            playSound();
            gameTimer.Stop();
            explosion.Visible = true;
            btnPause.Enabled = false;
            btnMenu.Enabled = true;
            player.Controls.Add(explosion);
            explosion.Location = new Point(-8, 5);
            explosion.BackColor = Color.Transparent;

            award.Image = Properties.Resources.gameOver;
            award.Visible = true;
            award.BringToFront();

            btnStart.Enabled = true;
            //ກໍານົດຄະແນນສູງສຸດ
            if (highScore < score)
            {
                highScore = score;
                txtHighScore.Text = "ຄະແນນສູງສຸດ:" + highScore;
            }
        }
        //ຟັງເຊີນເລີ່ມເກມ
        private void ResetGame()
        {
            System.Media.SoundPlayer playCrash = new System.Media.SoundPlayer(Properties.Resources.Ambulance_Sound);
            playCrash.PlayLooping();

            btnStart.Enabled = false;
            btnPause.Enabled = true;
            btnMenu.Enabled = false;
            explosion.Visible = false;
            award.Visible = false;
            goleft = false;
            goright = false;
            score = 0;
            award.Image = Properties.Resources.bronze;

            roadSpeed = 12;
            trafficSpeed = 15;

            AI1.Top = carPosition.Next(200, 500) *-1;
            AI1.Left = carPosition.Next(5, 200);

            AI2.Top = carPosition.Next(200, 500) * -1;
            AI2.Left = carPosition.Next(245, 422);

            gameTimer.Start();
        }
        //ປຸ່ມ Play
        private void restartGame(object sender, EventArgs e)
        {
            ResetGame();//ເອີ້ນໃຊ້ຟັງຊັນ ResetGame()
        }

        private void stopGame(object sender, EventArgs e)
        {
            
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }
        //ປຸ່ມຢຸດ ແລະ ປຸ່ມສຶບຕໍ່ເກມ
        private void btnPause_Click(object sender, EventArgs e)
        {
            paused = !paused;

            if (paused)
            {
                btnPause.Text = "Pause";
                gameTimer.Start();
                btnMenu.Enabled = false;
                System.Media.SoundPlayer playCrash = new System.Media.SoundPlayer(Properties.Resources.Ambulance_Sound);
                playCrash.PlayLooping();
            }
            else
            {
                btnPause.Text = "Resume";
                gameTimer.Stop();
                btnMenu.Enabled = true;
                System.Media.SoundPlayer playCrash = new System.Media.SoundPlayer(Properties.Resources.Ambulance_Sound);
                playCrash.Stop();
            }
            
        }
        //ປຸ່ມກັບຄືນ
        private void btnMenu_Click(object sender, EventArgs e)
        {
            System.Media.SoundPlayer playCrash = new System.Media.SoundPlayer(Properties.Resources.playground);
            playCrash.Play();
            this.Close();
            FormMain frmM = new FormMain();
            frmM.Show();
        }
        //ກໍານົດForm ເມື່ອມີການປັບຂະໜາດ
        private void Form1_SizeChanged(object sender, EventArgs e)
        {
            this.panel1.Left = ((this.Width - this.panel1.Width) - 15) / 2;
            this.btnMenu.Left = ((this.Width - this.btnMenu.Width) / 2) - 190;
            this.btnStart.Left = ((this.Width - this.btnStart.Width) - 15) / 2;
            this.btnPause.Left = ((this.Width - this.btnPause.Width) / 2) + 160;
        }
        //ຟັງເຊີນຫູີ້ນສຽງເມືອລົດຕໍາກັນ(Game Over)
        private void playSound()
        {
            System.Media.SoundPlayer playCrash = new System.Media.SoundPlayer(Properties.Resources.hit);
            playCrash.Play();
            
        }
    }
}
