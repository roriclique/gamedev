using SFML.Graphics;
using SFML.System;
using SFML.Window;
using System.Threading;

class NextLvlWindow
{
    public NextLvlWindow()
    {
        RenderWindow window = new RenderWindow(new VideoMode(400, 200), "Game");

        Font font = new Font("Pixellettersfull-BnJ5.ttf");
        Text title = new Text("Mysterious silence and...", font);
        title.Position = new Vector2f(85, 40);
        title.FillColor = Color.Magenta;

        Text nextText = new Text(">>>", font);
        nextText.Position = new Vector2f(180, 100);

        while (window.IsOpen)
        {
            window.DispatchEvents();
            window.Clear(Color.Black);
            window.Draw(title);
            window.Draw(nextText);
            window.Display();

            if (Keyboard.IsKeyPressed(Keyboard.Key.Escape))
            {
                window.Close();
            }
            else if (Keyboard.IsKeyPressed(Keyboard.Key.Return))
            {
                if (Keyboard.IsKeyPressed(Keyboard.Key.Return) == true)
                {
                    title = new Text("...loud sneeze!", font,42);
                    title.Position = new Vector2f(100, 50);
                    title.FillColor = Color.Magenta;

                    while (window.IsOpen)
                    {
                        window.DispatchEvents();
                        window.Clear(Color.Black);
                        window.Draw(title);
                        window.Display();

                        if (Keyboard.IsKeyPressed(Keyboard.Key.Return))
                        {
                            Thread.Sleep(3000);
                            window.Close();
                            break;

                        }
                    }
                }
            }
        }
    }
}
