using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Media;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.AxHost;
using static System.Windows.Forms.LinkLabel;

/// Savannah Gropp
/// June 19/2023
/// A recreation of crossy road with a twist (just kidding theres no twist its just 2d)

namespace pedestriansParkway
{
    public partial class pedestriansParkway : Form
    {
        string state = "waiting";

        int randValue = 0;
        Random randGen = new Random();

        int carSizeX = 60;
        int carSizeY = 20;

        //timers and score
        int score = 0;
        int displayScore = 0;
        int stopwatch = 0;
        int timer = 1000;

        //speeds
        int playerSpeed = 30;
        int carXSpeed = 9;
        int logXSpeed = 5;
        int gameSpeed = 1;

        //directions
        bool upDown = false;
        bool downDown = false;
        bool leftDown = false;
        bool rightDown = false;
        bool wDown = false;
        bool sDown = false;
        bool aDown = false;
        bool dDown = false;

        //brushes
        SolidBrush whiteBrush = new SolidBrush(Color.White);
        SolidBrush grayBrush = new SolidBrush(Color.Gray);
        SolidBrush yellowBrush = new SolidBrush(Color.Yellow);
        SolidBrush greenBrush = new SolidBrush(Color.DarkGreen);
        SolidBrush blueBrush = new SolidBrush(Color.CadetBlue);
        SolidBrush brownBrush = new SolidBrush(Color.SaddleBrown);

        //create player
        Rectangle player = new Rectangle(475, 485, 20, 20);

        //direction of the frog
        int frogDirection = 0;

        bool canMove = true;
        int counter = 0;

        //create road and obstacles
        List<Rectangle> carList = new List<Rectangle>();
        List<Rectangle> carLList = new List<Rectangle>();
        List<Rectangle> logList = new List<Rectangle>();
        List<Rectangle> logLList = new List<Rectangle>();
        List<Rectangle> invisList = new List<Rectangle>();
        List<Rectangle> invisLList = new List<Rectangle>();

        //clouds
        Rectangle clouds = new Rectangle(0, 0, 100, 600);
        Rectangle clouds2 = new Rectangle(860, 0, 200, 600);

        //road 1 (smallest road)
        Rectangle road1 = new Rectangle(0, 360, 960, 30);

        //road 2 (med road)
        Rectangle road2 = new Rectangle(0, 30, 960, 60);
        Rectangle line2 = new Rectangle(0, 58, 960, 4);

        //road 3 (biggest road)
        Rectangle road3 = new Rectangle(0, 180, 960, 120);
        Rectangle line3 = new Rectangle(0, 184, 960, 4);
        Rectangle line32 = new Rectangle(0, 236, 960, 4);
        Rectangle line33 = new Rectangle(0, 292, 960, 4);

        //road 4 (med road)
        Rectangle road4 = new Rectangle(0, -210, 960, 60);
        Rectangle line4 = new Rectangle(0, -182, 960, 4);

        //road 5 (biggest road)
        Rectangle road5 = new Rectangle(0, -540, 960, 120);
        Rectangle line5 = new Rectangle(0, -536, 960, 4);
        Rectangle line52 = new Rectangle(0, -484, 960, 4);
        Rectangle line53 = new Rectangle(0, -428, 960, 4);

        //river 1 (only one type of river)
        Rectangle river1 = new Rectangle(0, -90, 960, 60);

        //river 2 (river 1 but higher up on the map)
        Rectangle river2 = new Rectangle(0, -360, 960, 60);

        //images
        Image crossyCar = new Bitmap(Properties.Resources.crossyCar, 60, 60);
        Image crossyCar2 = new Bitmap(Properties.Resources.crossyCar2, 60, 60);
        Image frog = new Bitmap(Properties.Resources.frog, 40, 40);
        Image frogRight = new Bitmap(Properties.Resources.frogRIGHT, 40, 40);
        Image frogLeft = new Bitmap(Properties.Resources.frogLEFT, 40, 40);
        Image frogDown = new Bitmap(Properties.Resources.frogDOWN, 40, 40);
        Image log = new Bitmap(Properties.Resources.logPNG, 60, 20);

        //sounds
        SoundPlayer frogSound = new SoundPlayer(Properties.Resources.jumpSoundWAV);
        SoundPlayer deathSound = new SoundPlayer(Properties.Resources.deathSound);

        public pedestriansParkway()
        {
            InitializeComponent();
        }
        public void initializeGame()
        {
            clearScreen();

            BackColor = Color.DarkGreen;

            //timers and score
            score = 0;
            displayScore = 0;
            scoreLabel.Text = $"{displayScore}";
            stopwatch = 0;
            timer = 1000;

            gameTimer.Enabled = true;

            player = new Rectangle(475, 485, 20, 20);

            //road type 1 (small road)
            road1 = new Rectangle(0, 360, 960, 30);

            //road type 2 (med road)
            road2 = new Rectangle(0, 30, 960, 60);
            line2 = new Rectangle(0, 58, 960, 4);

            //road type 3 (biggest road)
            road3 = new Rectangle(0, 180, 960, 120);
            line3 = new Rectangle(0, 184, 960, 4);
            line32 = new Rectangle(0, 236, 960, 4);
            line33 = new Rectangle(0, 292, 960, 4);

            //river type 1 (only one type of river)
            river1 = new Rectangle(0, -90, 960, 60);

            //road type 4 (med road)
            road4 = new Rectangle(0, -210, 960, 60);
            line4 = new Rectangle(0, -182, 960, 4);

            //river type 2 (river 1 but higher up on the map)
            river2 = new Rectangle(0, -360, 960, 60);

            //road type 5 (biggest road)
            road5 = new Rectangle(0, -540, 960, 120);
            line5 = new Rectangle(0, -536, 960, 4);
            line52 = new Rectangle(0, -484, 960, 4);
            line53 = new Rectangle(0, -428, 960, 4);
        }
        private void pedestriansParkway_KeyDown(object sender, KeyEventArgs e)
        {
            switch (e.KeyCode)
            {
                case Keys.Up:
                    upDown = true;
                    break;
                case Keys.Down:
                    downDown = true;
                    break;
                case Keys.Left:
                    leftDown = true;
                    break;
                case Keys.Right:
                    rightDown = true;
                    break;
                case Keys.W:
                    wDown = true;
                    break;
                case Keys.S:
                    sDown = true;
                    break;
                case Keys.A:
                    aDown = true;
                    break;
                case Keys.D:
                    dDown = true;
                    break;
                case Keys.Escape:
                    Application.Exit();
                    break;
            }
        }
        private void pedestriansParkway_KeyUp(object sender, KeyEventArgs e)
        {
            switch (e.KeyCode)
            {
                case Keys.Up:
                    upDown = false;
                    break;
                case Keys.Down:
                    downDown = false;
                    break;
                case Keys.Left:
                    leftDown = false;
                    break;
                case Keys.Right:
                    rightDown = false;
                    break;
                case Keys.W:
                    wDown = false;
                    break;
                case Keys.S:
                    sDown = false;
                    break;
                case Keys.A:
                    aDown = false;
                    break;
                case Keys.D:
                    dDown = false;
                    break;
            }
        }
        private void timedButton_Click(object sender, EventArgs e)
        {
            initializeGame();
            state = "timed";
        }
        private void endlessButton_Click(object sender, EventArgs e)
        {
            initializeGame();
            state = "endless";
        }
        private void exitButton_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }
        public void gameTimer_Tick(object sender, EventArgs e)
        {
            if (state == "endless")
            {
                stopwatch++;
                timerLabel.Text = $"{stopwatch}";
            }
            if (state == "timed")
            {
                timer--;
                timerLabel.Text = $"{timer}";

                if (timer == 0)
                {
                    state = "over";
                }
            }

            //map moves automatically
            if (score >= 7)
            {
                player.Y += gameSpeed;

                road1.Y += gameSpeed;

                road2.Y += gameSpeed;
                line2.Y += gameSpeed;

                road3.Y += gameSpeed;
                line3.Y += gameSpeed;
                line32.Y += gameSpeed;
                line33.Y += gameSpeed;

                river1.Y += gameSpeed;

                road4.Y += gameSpeed;
                line4.Y += gameSpeed;

                river2.Y += gameSpeed;

                road5.Y += gameSpeed;
                line5.Y += gameSpeed;
                line52.Y += gameSpeed;
                line53.Y += gameSpeed;

                for (int i = 0; i < carList.Count; i++)
                {
                    int y = carList[i].Y + gameSpeed;
                    carList[i] = new Rectangle(carList[i].X, y, carSizeX, carSizeY);
                }
                for (int i = 0; i < carLList.Count; i++)
                {
                    int y = carLList[i].Y + gameSpeed;
                    carLList[i] = new Rectangle(carLList[i].X, y, carSizeX, carSizeY);
                }
                for (int i = 0; i < logList.Count; i++)
                {
                    int y = logList[i].Y + gameSpeed;
                    logList[i] = new Rectangle(logList[i].X, y, 60, 40);
                }
                for (int i = 0; i < logLList.Count; i++)
                {
                    int y = logLList[i].Y + gameSpeed;
                    logLList[i] = new Rectangle(logLList[i].X, y, 60, 40);
                }
                for (int i = 0; i < invisList.Count; i++)
                {
                    int y = invisList[i].Y + gameSpeed;
                    invisList[i] = new Rectangle(invisList[i].X, y, 80, 40);
                }
                for (int i = 0; i < invisLList.Count; i++)
                {
                    int y = invisLList[i].Y + gameSpeed;
                    invisLList[i] = new Rectangle(invisLList[i].X, y, 80, 40);
                }
            }

            //player moves
            if (upDown == true && canMove == true || wDown == true && canMove == true)
            {
                frogDirection = 1;
                canMove = false;

                upDown = false;
                wDown = false;

                frogSound.Play();

                // adds points to score
                score++;
                displayScore++;
                if (score >= displayScore)
                {
                    scoreLabel.Text = $"{displayScore}";
                }

                if (player.Y <= 300)
                {
                    // moves everything on screen down
                    // player looks like its moving forward
                    road1.Y += playerSpeed;

                    road2.Y += playerSpeed;
                    line2.Y += playerSpeed;

                    road3.Y += playerSpeed;
                    line3.Y += playerSpeed;
                    line32.Y += playerSpeed;
                    line33.Y += playerSpeed;

                    river1.Y += playerSpeed;

                    road4.Y += playerSpeed;
                    line4.Y += playerSpeed;

                    river2.Y += playerSpeed;

                    road5.Y += playerSpeed;
                    line5.Y += playerSpeed;
                    line52.Y += playerSpeed;
                    line53.Y += playerSpeed;

                    for (int i = 0; i < carList.Count; i++)
                    {
                        int y = carList[i].Y + playerSpeed;
                        carList[i] = new Rectangle(carList[i].X, y, carSizeX, carSizeY);
                    }
                    for (int i = 0; i < carLList.Count; i++)
                    {
                        int y = carLList[i].Y + playerSpeed;
                        carLList[i] = new Rectangle(carLList[i].X, y, carSizeX, carSizeY);
                    }
                    for (int i = 0; i < logList.Count; i++)
                    {
                        int y = logList[i].Y + playerSpeed;
                        logList[i] = new Rectangle(logList[i].X, y, 60, 40);
                    }
                    for (int i = 0; i < logLList.Count; i++)
                    {
                        int y = logLList[i].Y + playerSpeed;
                        logLList[i] = new Rectangle(logLList[i].X, y, 60, 40);
                    }
                    for (int i = 0; i < invisList.Count; i++)
                    {
                        int y = invisList[i].Y + playerSpeed;
                        invisList[i] = new Rectangle(invisList[i].X, y, 80, 40);
                    }
                    for (int i = 0; i < invisLList.Count; i++)
                    {
                        int y = invisLList[i].Y + playerSpeed;
                        invisLList[i] = new Rectangle(invisLList[i].X, y, 80, 40);
                    }
                }
                else
                {
                    player.Y -= playerSpeed;
                }
            }
            if (player.Y < 550 && downDown == true && canMove == true || player.Y < 550 && sDown == true && canMove == true)
            {
                // player moves down
                frogDirection = 2;
                canMove = false;

                displayScore--;

                downDown = false;
                sDown = false;

                player.Y += playerSpeed;
            }
            if (leftDown == true && canMove == true || aDown == true && canMove == true )
            {
                // player moves left
                frogDirection = 3;
                canMove = false;

                leftDown = false;
                aDown = false;

                player.X -= playerSpeed;
            }
            if (rightDown == true && canMove == true || dDown == true && canMove == true)                                                                                         
            {
                // player moves right
                frogDirection = 4;
                canMove = false;

                rightDown = false;
                dDown = false;

                player.X += playerSpeed;
            }

            //create cars (moving right)
            randValue = randGen.Next(0, 101);
            if (randValue <= 20)
            {
                randValue = randGen.Next(0, 400);
                if (randValue <= 100)
                {
                    //car on road 2
                    Rectangle car2 = new Rectangle(0, road2.Y + 35, carSizeX, carSizeY);
                    carList.Add(car2);
                }
                randValue = randGen.Next(0, 400);
                if (randValue <= 100)
                {
                    //car on road 3
                    Rectangle car3 = new Rectangle(0, road3.Y + 65, carSizeX, carSizeY);
                    carList.Add(car3);
                }
                randValue = randGen.Next(0, 400);
                if (randValue <= 100)
                {
                    //car on road 4
                    Rectangle car4 = new Rectangle(0, road4.Y + 35, carSizeX, carSizeY);
                    carList.Add(car4);
                }
                randValue = randGen.Next(0, 400);
                if (randValue <= 100)
                {
                    //car on road 5
                    Rectangle car5 = new Rectangle(0, road5.Y + 65, carSizeX, carSizeY);
                    carList.Add(car5);
                }
            }

            //create cars (moving left)
            randValue = randGen.Next(0, 101);
            if (randValue <= 10)
            {
                randValue = randGen.Next(0, 400);
                if (randValue <= 100)
                {
                    //car on road 1
                    Rectangle car1 = new Rectangle(this.Width, road1.Y + 5, carSizeX, carSizeY);
                    carLList.Add(car1);
                }
                randValue = randGen.Next(0, 400);
                if (randValue <= 100)
                {
                    //car on road 2
                    Rectangle car2 = new Rectangle(this.Width, road2.Y + 5, carSizeX, carSizeY);
                    carLList.Add(car2);
                }
                randValue = randGen.Next(0, 400);
                if (randValue <= 100)
                {
                    //car on road 3
                    Rectangle car3 = new Rectangle(this.Width, road3.Y + 30, carSizeX, carSizeY);
                    carLList.Add(car3);
                }
                randValue = randGen.Next(0, 400);
                if (randValue <= 100)
                {
                    //car on road 4
                    Rectangle car4 = new Rectangle(this.Width, road4.Y + 5, carSizeX, carSizeY);
                    carLList.Add(car4);
                }
                randValue = randGen.Next(0, 400);
                if (randValue <= 100)
                {
                    //car on road 5
                    Rectangle car5 = new Rectangle(this.Width, road5.Y + 30, carSizeX, carSizeY);
                    carLList.Add(car5);
                }
            }

            //remove cars if they are overlapping
            try
            {
                for (int i = 0; i < carList.Count; i++)
                {
                    for (int c = 0; c < carList.Count; c++)
                    {
                        if (carList[i].IntersectsWith(carList[c]) && c != i)
                        {
                            carList.RemoveAt(i);
                        }
                    }
                }
                for (int i = 0; i < carLList.Count; i++)
                {
                    for (int c = 0; c < carLList.Count; c++)
                    {
                        if (carLList[i].IntersectsWith(carLList[c]) && c != i)
                        {
                            carLList.RemoveAt(i);
                        }
                    }
                }
            }
            catch
            {

            }

            //create logs (moving right)
            randValue = randGen.Next(0, 101);
            if (randValue <= 10)
            {
                randValue = randGen.Next(0, 400);
                if (randValue <= 200)
                {
                    //log on river 1
                    Rectangle log1 = new Rectangle(this.Width, river1.Y + 5, 60, 20);
                    logList.Add(log1);

                    Rectangle invis1 = new Rectangle(this.Width, river1.Y - 1, 60, 32);
                    invisList.Add(invis1);
                }
                randValue = randGen.Next(0, 400);
                if (randValue <= 200)
                {
                    //log on river 2
                    Rectangle log2 = new Rectangle(this.Width, river2.Y + 5, 60, 20);
                    logList.Add(log2);

                    Rectangle invis2 = new Rectangle(this.Width, river2.Y - 1, 60, 32);
                    invisList.Add(invis2);
                }
            }

            //create logs (moving left)
            randValue = randGen.Next(0, 101);
            if (randValue <= 10)
            {
                randValue = randGen.Next(0, 400);
                if (randValue <= 200)
                {
                    //log on river 1
                    Rectangle log1 = new Rectangle(0, river1.Y + 35, 60, 20);
                    logLList.Add(log1);

                    Rectangle invis1 = new Rectangle(0, river1.Y + 34, 60, 32);
                    invisLList.Add(invis1);
                }
                randValue = randGen.Next(0, 400);
                if (randValue <= 200)
                {
                    //log on river 2
                    Rectangle log2 = new Rectangle(0, river2.Y + 35, 60, 20);
                    logLList.Add(log2);

                    Rectangle invis2 = new Rectangle(0, river2.Y + 34, 60, 32);
                    invisLList.Add(invis2);
                }
            }

            // remove logs if they are overlapping
            try
            {
                for (int i = 0; i < logList.Count; i++)
                {
                    for (int c = 0; c < logList.Count; c++)
                    {
                        if (logList[i].IntersectsWith(logList[c]) && c != i)
                        {
                            logList.RemoveAt(i);
                            invisList.RemoveAt(i);
                        }
                    }
                }
                for (int i = 0; i < logLList.Count; i++)
                {
                    for (int c = 0; c < logLList.Count; c++)
                    {
                        if (logLList[i].IntersectsWith(logLList[c]) && c != i)
                        {
                            logLList.RemoveAt(i);
                            invisLList.RemoveAt(i);
                        }
                    }
                }
            }
            catch
            {

            }

            //make cars move
            for (int i = 0; i < carList.Count; i++)
            {
                int x = carList[i].X + carXSpeed;
                carList[i] = new Rectangle(x, carList[i].Y, carSizeX, carSizeY);
            }
            for (int i = 0; i < carLList.Count; i++)
            {
                int x = carLList[i].X - carXSpeed;
                carLList[i] = new Rectangle(x, carLList[i].Y, carSizeX, carSizeY);
            }

            //make logs move
            for (int i = 0; i < logList.Count; i++)
            {
                int x = logList[i].X - logXSpeed;
                logList[i] = new Rectangle(x, logList[i].Y, 60, 20);
            }
            for (int i = 0; i < logLList.Count; i++)
            {
                int x = logLList[i].X + logXSpeed;
                logLList[i] = new Rectangle(x, logLList[i].Y, 60, 20);
            }

            //collisions
            for (int i = 0; i < carList.Count; i++)
            {
                if (player.IntersectsWith(carList[i]))
                {
                    state = "over";
                }
            }
            for (int i = 0; i < carLList.Count; i++)
            {
                if (player.IntersectsWith(carLList[i]))
                {
                    state = "over";
                }
            }

            //make invisible rectangles stay where they need to around the logs
            for (int i = 0; i < invisList.Count; i++)
            {
                invisList[i] = new Rectangle(logList[i].X, logList[i].Y - 10, logList[i].Width, logList[i].Height + 20); ;
            }
            for (int i = 0; i < invisLList.Count; i++)
            {
                invisLList[i] = new Rectangle(logLList[i].X, logLList[i].Y - 10, logLList[i].Width, logLList[i].Height + 20); ;
            }
            bool safe = false;
            for (int i = 0; i < invisList.Count; i++)
            {
                if (player.IntersectsWith(invisList[i]))
                {
                    safe = true;

                    player.X -= logXSpeed;
                }
            }
            for (int i = 0; i < invisLList.Count; i++)
            {
                if (player.IntersectsWith(invisLList[i]))
                {
                    safe = true;

                    player.X += logXSpeed;
                }
            }
            if (!safe)
            {
                if (player.IntersectsWith(river2) || player.IntersectsWith(river1))
                {
                    state = "over";
                }
            }

            //make cars dissapear at the edge of the screen
            for (int i = 0; i < carList.Count; i++)
            {
                if (carList[i].X >= this.Width)
                {
                    carList.RemoveAt(i);
                }
            }
            for (int i = 0; i < carLList.Count; i++)
            {
                if (carLList[i].X <= 0)
                {
                    carLList.RemoveAt(i);
                }
            }

            //make logs dissapear at the edge of the screen
            for (int i = 0; i < logList.Count; i++)
            {
                if (logList[i].X <= 0)
                {
                    logList.RemoveAt(i);
                    invisList.RemoveAt(i);
                }
            }
            for (int i = 0; i < logLList.Count; i++)
            {
                if (logLList[i].X >= this.Width)
                {
                    logLList.RemoveAt(i);
                    invisLList.RemoveAt(i);
                }
            }

            //out of bounds
            if (player.X <= 0 || player.X >= this.Width)
            {
                state = "over";
            }
            if (player.Y >= this.Height + 10)
            {
                state = "over";
            }

            //make roads reset
            if (road1.Y >= 600)
            {
                road1.Y -= 1020;
            }
            if (road2.Y >= 600)
            {
                road2.Y -= 1020;
                line2.Y -= 1020;
            }
            if (road3.Y >= 600)
            {
                road3.Y -= 1020;
                line3.Y -= 1020;
                line32.Y -= 1020;
                line33.Y -= 1020;
            }
            if (road4.Y >= 600)
            {
                road4.Y -= 1020;
            }
            if (road5.Y >= 600)
            {
                road5.Y -= 1020;
                line5.Y -= 1020;
                line52.Y -= 1020;
                line53.Y -= 1020;
            }

            //make rivers reset
            if (river1.Y >= 600)
            {
                river1.Y -= 1020;
            }
            if (river2.Y >= 600)
            {
                river2.Y -= 1020;
            }

            if (state == "over")
            {
                endScreen();

                carList.Clear();
                carLList.Clear();
                logList.Clear();
                logLList.Clear();
                invisList.Clear();
                invisLList.Clear();
            }

            // so you can't glitch the player down the map
            counter++;
            if (counter % 10 == 0)
            {
                counter = 0;
                canMove = true;
            }

            Refresh();
        }

        public void pedestriansParkway_Paint(object sender, PaintEventArgs e)
        {
            if (state == "timed" || state == "endless")
            {
                // paint background
                e.Graphics.FillRectangle(grayBrush, road1);

                e.Graphics.FillRectangle(grayBrush, road2);
                e.Graphics.FillRectangle(yellowBrush, line2);

                e.Graphics.FillRectangle(grayBrush, road3);
                e.Graphics.FillRectangle(whiteBrush, line3);
                e.Graphics.FillRectangle(yellowBrush, line32);
                e.Graphics.FillRectangle(whiteBrush, line33);

                e.Graphics.FillRectangle(blueBrush, river1);

                e.Graphics.FillRectangle(grayBrush, road4);
                e.Graphics.FillRectangle(yellowBrush, line4);

                e.Graphics.FillRectangle(blueBrush, river2);

                e.Graphics.FillRectangle(grayBrush, road5);
                e.Graphics.FillRectangle(whiteBrush, line5);
                e.Graphics.FillRectangle(yellowBrush, line52);
                e.Graphics.FillRectangle(whiteBrush, line53);

                // paint cars
                for (int i = 0; i < carList.Count; i++)
                {
                    e.Graphics.DrawImage(crossyCar2, carList[i].X, carList[i].Y - 20);
                }
                for (int i = 0; i < carLList.Count; i++)
                {
                    e.Graphics.DrawImage(crossyCar, carLList[i].X, carLList[i].Y - 20);
                }

                // paint logs
                for (int i = 0; i < logList.Count; i++)
                { 
                    e.Graphics.DrawImage(log, logList[i].X, logList[i].Y);
                }
                for (int i = 0; i < logLList.Count; i++)
                {
                    e.Graphics.DrawImage(log, logLList[i].X, logLList[i].Y);
                }

                //turn the frog (change its image) when the direction turns
                if (frogDirection == 1 || frogDirection == 0)
                {
                    e.Graphics.DrawImage(frog, player.X - 10, player.Y - 10);
                }
                if (frogDirection == 2)
                {
                    e.Graphics.DrawImage(frogDown, player.X - 10, player.Y - 10);
                }
                if (frogDirection == 4)
                {
                    e.Graphics.DrawImage(frogRight, player.X - 10, player.Y - 10);
                }
                if (frogDirection == 3)
                {
                    e.Graphics.DrawImage(frogLeft, player.X - 10, player.Y - 10);
                }

                //cloud images
                e.Graphics.FillRectangle(whiteBrush, clouds);
                e.Graphics.FillRectangle(whiteBrush, clouds2);
            }

        }
        public void clearScreen()
        {
            //hide titles and buttons
            timedButton.Enabled = false;
            timedButton.Visible = false;
            endlessButton.Enabled = false;
            endlessButton.Visible = false;
            titleLabel.Visible = false;
            subtitleLabel.Visible = false;
            exitButton.Visible = false;
            exitButton.Enabled = false;

            timerLabel.Visible = true;
            scoreLabel.Visible = true;
        }
        public void endScreen()
        {
            //stop the game
            gameTimer.Stop();
            deathSound.Play();

            //background colours
            BackColor = Color.DimGray;
            
            //show titles and buttons
            timedButton.Enabled = true;
            timedButton.Visible = true;
            endlessButton.Enabled = true;
            endlessButton.Visible = true;
            titleLabel.Visible = true;
            titleLabel.Text = $"Game over. Your score was {score}";
            subtitleLabel.Visible = true;
            subtitleLabel.Text = "To play again press TIMED or ENDLESS. To exit press EXIT.";
            exitButton.Visible = true;
            exitButton.Enabled = true;

            timerLabel.Visible = false;
            scoreLabel.Visible = false;
        }
    }
}