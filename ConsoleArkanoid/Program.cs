using SFML.Graphics;
using SFML.Window;
using SFML.System;
using System;
using System.Threading;


class Program
{
    static RenderWindow window;

    static Texture bagtexture;
    static Texture frogietexture;
    static Texture cointexture;

    static Sprite frogie;
    static Sprite[] coins;

    static Bag bag;


    public static void SetStartPosition()
    {
        int index = 0;
        for (int y = 0; y < 5; y++)
        {
            for (int x = 0; x < 10; x++)
            {
                coins[index].Position = new Vector2f(x * (coins[index].TextureRect.Width + 15) + 175,
                    y * (coins[index].TextureRect.Height + 15) + 50);
                index++;

            }
        }

        frogie.Position = new Vector2f(700, 750);
        bag.sprite.Position = new Vector2f(500, 550);

    }

    public static void SetStartPositionNextLvl()
    {
        Random random = new Random();

        int indexLvl = 0;
        coins = new Sprite[50];
        int coinsCount = 0;

        for (int i = 0; i < coins.Length; i++)
        {
            int randomX = random.Next(200, 800);
            int randomY = random.Next(15, 500);

            coins[indexLvl] = new Sprite(cointexture);

            coins[indexLvl].Position = new Vector2f(randomX,randomY);
            indexLvl++;
        }


        frogie.Position = new Vector2f(700, 750);
        bag.sprite.Position = new Vector2f(500, 550);

        while (window.IsOpen == true)
        {
            window.Clear();

            window.DispatchEvents();

            bag.Start(7, new Vector2f(0, 1));

            bag.Move(new Vector2i(0, 0), new Vector2i(998, 898));

            bag.CheckColision(frogie, "Frogie");

            for (int i = 0; i < coins.Length; i++)
            {
                if (bag.CheckColision(coins[i], "Coins") == true)
                {
                    coins[i].Position = new Vector2f(1010, 1000);
                    coinsCount++;
                    if (coinsCount == 50)
                    {
                        bool levelComplete = true;

                        if (levelComplete == true)
                        {
                            int lvlCounter = 0;
                            NextLvlWindow windowLvl2 = new NextLvlWindow();
                            SetStartPositionNextLvl();
                            lvlCounter++;

                            if(lvlCounter == 5)
                            {
                                WinnerWindow windowWinner = new WinnerWindow();
                                break;
                            }

                        }

                    }

                }
            }

            frogie.Position = new Vector2f(Mouse.GetPosition(window).X - frogie.TextureRect.Width * 0.5f, frogie.Position.Y);

            window.Draw(bag.sprite);
            window.Draw(frogie);
            for (int i = 0; i < coins.Length; i++)
            {
                window.Draw(coins[i]);
            }

            window.Display();
        }
    }

    public static void Main(string[] args)
    {
        GameLauncher launcher = new GameLauncher();

        window = new RenderWindow(new VideoMode(1000, 900), "Game: Frogie Coins");
        window.SetFramerateLimit(60);
        window.Closed += Window_Closed;

        bagtexture = new Texture("Bag.png");
        frogietexture = new Texture("Frogie.png");
        cointexture = new Texture("Coin.png");

        bag = new Bag(bagtexture);
        frogie = new Sprite(frogietexture);
        coins = new Sprite[50];
        int coinsCount = 0;
        for(int i = 0; i < coins.Length; i++) coins[i] = new Sprite(cointexture);

        SetStartPosition();

        while (window.IsOpen == true)
        {
            window.Clear();

            window.DispatchEvents();

            bag.Start(7, new Vector2f(0, 1));

            bag.Move(new Vector2i(0, 0), new Vector2i(998, 898));

            bag.CheckColision(frogie,"Frogie");

            for(int i = 0; i < coins.Length; i++)
            {
                if (bag.CheckColision(coins[i], "Coins") == true)
                {
                    coins[i].Position = new Vector2f(1010, 1000);
                    coinsCount++;

                    if (coinsCount == 50)
                    {
                        NextLvlWindow window = new NextLvlWindow();
                        Thread.Sleep(2000);
                        SetStartPositionNextLvl();

                    }

                }
            }

            frogie.Position = new Vector2f(Mouse.GetPosition(window).X - frogie.TextureRect.Width * 0.5f, frogie.Position.Y);

            window.Draw(bag.sprite);
            window.Draw(frogie);
            for(int i = 0;i < coins.Length; i++)
            {
                window.Draw(coins[i]);
            }

            window.Display();
        }
    }

    private static void Window_Closed(object sender, EventArgs e)
    {
        throw new NotImplementedException();
    }
}
