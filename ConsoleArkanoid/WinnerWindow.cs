using SFML.Graphics;
using SFML.System;
using SFML.Window;
using System;
using System.Threading;

class WinnerWindow
{
    public WinnerWindow()
    {
        RenderWindow window = new RenderWindow(new VideoMode(400, 200), "Game");

        Font font = new Font("Pixellettersfull-BnJ5.ttf");
        Text title = new Text("Congrats!", font);
        title.Position = new Vector2f(180, 40);
        title.FillColor = Color.Yellow;

        Text startText = new Text("Wanna try again?", font);
        startText.Position = new Vector2f(150, 70);

        Text exitText = new Text("Exit", font);
        exitText.Position = new Vector2f(180, 100);

        while (window.IsOpen)
        {
            window.DispatchEvents();
            window.Clear(Color.Black);
            window.Draw(title);
            window.Draw(startText);
            window.Draw(exitText);
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
                    window.Close();

                    if (Mouse.IsButtonPressed(Mouse.Button.Left) == true)
                    {
                        window.Close();
                        Program.SetStartPosition();
                    }
                }
            }
        }
    }
}

