using SFML.Graphics;
using SFML.System;
using SFML.Window;
using System;
using System.Threading;


class LooserWindow
{
    public LooserWindow()
    {
        RenderWindow window = new RenderWindow(new VideoMode(400, 200), "Game");

        Font font = new Font("Pixellettersfull-BnJ5.ttf");
        Text title = new Text("*coins clinking*...", font,42);
        title.Position = new Vector2f(90, 50);
        title.FillColor = Color.Magenta;

        Text text = new Text("Game over:(",font,26);
        text.Position = new Vector2f(150, 90);

        while (window.IsOpen)
        {
            window.DispatchEvents();
            window.Clear(Color.Black);
            window.Draw(title);
            window.Draw(text);
            window.Display();

            Thread.Sleep(5000);
            Environment.Exit(0);


        }
    }
}

