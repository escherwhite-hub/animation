using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Audio;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using System;

namespace animation
{
    enum Screen
    {
        Intro,
        tribbleYard,
        End
    }

    public class Game1 : Game
    {
        private GraphicsDeviceManager _graphics;
        private SpriteBatch _spriteBatch;

        Texture2D tribbleBTexture, tribbleCTexture, tribbleGTexture, tribbleOTexture, introTexture, endTexture;

        Rectangle window, tribbleBRect, tribbleCRect, tribbleGRect, tribbleORect;

        Vector2 tribbleBSpeed, tribbleCSpeed, tribbleGSpeed, tribbleOSpeed;

        SoundEffect tribbleSound;

        MouseState mouseState;

        Screen screen;

        float seconds;

        Random random = new Random();


        Color backgroundColour = Color.SeaGreen;
        

        public Game1()
        {
            _graphics = new GraphicsDeviceManager(this);
            Content.RootDirectory = "Content";
            IsMouseVisible = true;
        }

        protected override void Initialize()
        {
            window = new Rectangle(0,0,800,600);
            _graphics.PreferredBackBufferHeight = 600;
            _graphics.PreferredBackBufferWidth = 800;
            _graphics.ApplyChanges();

            random = new Random();

            tribbleBRect = new Rectangle(random.Next(0, 700), random.Next(0, 500), 100, 100);
            tribbleBSpeed = new Vector2(6, 8);
            tribbleCRect = new Rectangle(random.Next(0, 700), random.Next(0, 500), 100, 100);
            tribbleCSpeed = new Vector2(4, 0);
            tribbleGRect = new Rectangle(random.Next(0, 700), random.Next(0,500), 100, 100);
            tribbleGSpeed = new Vector2(0, 4);
            tribbleORect = new Rectangle(random.Next(0, 700), random.Next(0, 500), 100, 100);
            tribbleOSpeed = new Vector2(2,6);

            screen = Screen.Intro;


            base.Initialize();
        }

        protected override void LoadContent()
        {
            _spriteBatch = new SpriteBatch(GraphicsDevice);

            tribbleBTexture = Content.Load<Texture2D>("tribbleBrown");
            tribbleCTexture = Content.Load<Texture2D>("tribbleCream");
            tribbleGTexture = Content.Load<Texture2D>("tribbleGrey");
            tribbleOTexture = Content.Load<Texture2D>("tribbleOrange");
            tribbleSound = Content.Load<SoundEffect>("tribble_coo");
            introTexture = Content.Load<Texture2D>("tribble_intro");
            endTexture = Content.Load<Texture2D>("theEnd");

            
            // TODO: use this.Content to load your game content here
        }

        protected override void Update(GameTime gameTime)
        {
            mouseState = Mouse.GetState();


            if (GamePad.GetState(PlayerIndex.One).Buttons.Back == ButtonState.Pressed || Keyboard.GetState().IsKeyDown(Keys.Escape))
                Exit();
            
           

            // TODO: Add your update logic here
           
            if (screen == Screen.Intro)
            {
                if (mouseState.LeftButton == ButtonState.Pressed)
                {
                    screen = Screen.tribbleYard;
                }
            }

            else if (screen == Screen.tribbleYard)
            {
                seconds += (float)gameTime.ElapsedGameTime.TotalSeconds;

                // tribble brown
                tribbleBRect.X += (int)tribbleBSpeed.X;
                if (tribbleBRect.Right > window.Width || tribbleBRect.Left <= 0)
                {
                    tribbleBSpeed.X *= -1;
                    tribbleSound.Play();

                }
                tribbleBRect.Y += (int)tribbleBSpeed.Y;
                if (tribbleBRect.Top <= 0 || tribbleBRect.Bottom > window.Height)
                {
                    tribbleBSpeed.Y *= -1;
                    tribbleSound.Play();

                }

                // tribble cream

                tribbleCRect.X += (int)tribbleCSpeed.X;
                if (tribbleCRect.Left > window.Width || tribbleCRect.Right <= 0)
                {

                    tribbleCRect.X = random.Next(0, 700);
                    tribbleCRect.Y = random.Next(0, 500);
                    tribbleCSpeed.X *= -1;
                }

                // tribble grey
                tribbleGRect.Y += (int)tribbleGSpeed.Y;
                if (tribbleGRect.Bottom > window.Height || tribbleGRect.Top <= 0)
                {
                    tribbleGSpeed.Y *= -1;

                    backgroundColour = new Color(
                        random.Next(256),
                        random.Next(256),
                        random.Next(256)
                        );

                }

                // tribble orange
                tribbleORect.Y += (int)tribbleOSpeed.Y;
                if (tribbleORect.Top <= 0 || tribbleORect.Bottom > window.Height)
                {
                    tribbleOSpeed.Y *= -1;
                    tribbleORect.Height = random.Next(20, 200);
                }

                tribbleORect.X += (int)tribbleOSpeed.X;
                if (tribbleORect.Right > window.Width || tribbleORect.Left <= 0)
                {
                    tribbleOSpeed.X *= -1;
                    tribbleORect.Width = random.Next(20, 200);
                }

                if (seconds >= 10)
                {
                    screen = Screen.End;
                }
            }


            




                base.Update(gameTime);
        }

        protected override void Draw(GameTime gameTime)
        {
            GraphicsDevice.Clear(backgroundColour);

            _spriteBatch.Begin();

            if (screen == screen.Intro)
            {
                _spriteBatch.Draw(introTexture, window,Color.White);
            }

            else if (screen == screen.tribbleYard)
            {
                _spriteBatch.Draw(tribbleBTexture, tribbleBRect, Color.White);
                _spriteBatch.Draw(tribbleCTexture, tribbleCRect, Color.White);
                _spriteBatch.Draw(tribbleGTexture, tribbleGRect, Color.White);
                _spriteBatch.Draw(tribbleOTexture, tribbleORect, Color.White);
            }

            else if (screen == screen.End)
            {
                _spriteBatch.Draw(endTexture, window, Color.White);
            }

                _spriteBatch.End();
            // TODO: Add your drawing code here

            base.Draw(gameTime);
        }
    }
}
