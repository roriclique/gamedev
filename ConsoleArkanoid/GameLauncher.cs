using SFML.Audio;
using SFML.Graphics;
using SFML.System;
using SFML.Window;
using System;
using System.Threading;

class GameLauncher
{
    public RenderWindow window;

    static SoundBuffer pressButton = new SoundBuffer("coins-135571.wav");
    static Sound pressPlayButton = new Sound(pressButton);
    static SoundBuffer gameLaunchWaiting = new SoundBuffer("Toothless Dancing .wav");
    static Sound gameLaunch = new Sound(gameLaunchWaiting);

    public Font font;
    public Text title;
    public Text hint;
    public Text startText;
    public Text exitText;
    public Sprite bigFrogie;

    public Texture bigFrogieTexture;

    public GameLauncher()
    {
        window = new RenderWindow(new VideoMode(400, 300), "Game");

        font = new Font("Pixellettersfull-BnJ5.ttf");
        title = new Text("Frogie Coins", font,42);
        title.Position = new Vector2f(110, 40);
        title.FillColor = Color.Magenta;

        startText = new Text("Yoink!", font);
        startText.Position = new Vector2f(170, 100);

        exitText = new Text("Exit", font);
        exitText.Position = new Vector2f(180, 130);

        bigFrogieTexture = new Texture("BigFrogie.png");
        bigFrogie = new Sprite(bigFrogieTexture);
        bigFrogie.Position = new Vector2f(80,210);

        float volume_ = 13.0f;
        gameLaunch.Volume = volume_;

        gameLaunch.Play();

        while (window.IsOpen)
        {
            
            window.DispatchEvents();
            window.Clear(Color.Black);
            window.Draw(title);
            window.Draw(startText);
            window.Draw(exitText);
            window.Draw(bigFrogie);
            window.Display();

            if (Keyboard.IsKeyPressed(Keyboard.Key.Escape))
            {
                window.Close();
            }
            else if (Mouse.IsButtonPressed(Mouse.Button.Left))
            {
                Vector2i mousePosition = Mouse.GetPosition(window);

                if (exitText.GetGlobalBounds().Contains(mousePosition.X, mousePosition.Y))
                {
                    Environment.Exit(0);
                }

                else if (startText.GetGlobalBounds().Contains(mousePosition.X, mousePosition.Y))
                {
                    gameLaunch.Stop();
                    float volume = 5.0f;
                    pressPlayButton.Volume = volume;
                    pressPlayButton.Play();
                    window.Close();
                }
                
                
            }
        }
    }
}

