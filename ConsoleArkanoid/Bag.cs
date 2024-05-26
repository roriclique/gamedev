using SFML.Audio;
using SFML.Graphics;
using SFML.System;


class Bag
{
    public Sprite sprite;
    private float speed;
    private Vector2f direction;

    int attemptsCounter = 5;

    public Bag(Texture texture)
    {
        sprite = new Sprite(texture);
    }

    public void Start(float speed, Vector2f direction)
    {
        if (this.speed != 0) return; this.speed = speed; this.direction = direction;
    }

    public void Move(Vector2i boundsPos, Vector2i boundsSize)
    {
        sprite.Position += direction * (speed / 2);

        if (sprite.Position.X > boundsSize.X - sprite.Texture.Size.X || sprite.Position.X < boundsPos.X)
        {
            direction.X *= -1;
        }

        bool attempts = sprite.Position.Y > boundsSize.Y;
        if (attempts == true)
        {
            attemptsCounter--;

            if(attemptsCounter != 0)
            {
                NextTryWindow window = new NextTryWindow(); 
                Program.SetStartPosition();
            }

            else
            {
                LooserWindow window = new LooserWindow();
            }

        }

        if (sprite.Position.Y < boundsPos.Y)
        {
            direction.Y *= -1;
        }
    }

    static SoundBuffer hitSoundBuffer = new SoundBuffer("cartoon-jump-6462.wav");
    static Sound hitSound = new Sound(hitSoundBuffer);

    public bool CheckColision(Sprite sprite, string tag)
    {
        if (this.sprite.GetGlobalBounds().Intersects(sprite.GetGlobalBounds()) == true)
        {
            if (tag == "Frogie")
            {
                direction.Y = -1;
                float f = ((this.sprite.Position.X + this.sprite.Position.X * 0.5f) - (sprite.Position.X + sprite.Texture.Size.X * 0.5f)) / sprite.Texture.Size.X * 0.5f;
                direction.X = f * 2;
                float volume = 40.0f;
                hitSound.Volume = volume;
                hitSound.Play();
            }

            if (tag == "Coins")
            {
                direction.Y *= -1;
    
            }

            return true;
        }
        return false;
    }
}
