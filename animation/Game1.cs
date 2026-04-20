using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Audio;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using System;

namespace animation
{
    public class Game1 : Game
    {
        private GraphicsDeviceManager _graphics;
        private SpriteBatch _spriteBatch;

        Texture2D tribbleBTexture, tribbleCTexture, tribbleGTexture, tribbleOTexture;

        Rectangle window, tribbleBRect, tribbleCRect, tribbleGRect;

        Vector2 tribbleBSpeed, tribbleCSpeed, tribbleGSpeed;

        SoundEffect tribbleSound;

        Random random;
        

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

            tribbleBRect = new Rectangle(0, 0, 100, 100);
            tribbleBSpeed = new Vector2(6, 8);
            tribbleCRect = new Rectangle(5,0, 100, 100);
            tribbleCSpeed = new Vector2(4, 1);
            tribbleGRect = new Rectangle(0, 0, 100, 100);
            tribbleGSpeed = new Vector2(4, 1);



            // TODO: Add your initialization logic here

            base.Initialize();
        }

        protected override void LoadContent()
        {
            _spriteBatch = new SpriteBatch(GraphicsDevice);

            tribbleBTexture = Content.Load<Texture2D>("tribbleBrown");
            tribbleCTexture = Content.Load<Texture2D>("tribbleCream");
            tribbleGTexture = Content.Load<Texture2D>("tribbleGrey");
            tribbleSound = Content.Load<SoundEffect>("tribble_coo");
            
            // TODO: use this.Content to load your game content here
        }

        protected override void Update(GameTime gameTime)
        {
            if (GamePad.GetState(PlayerIndex.One).Buttons.Back == ButtonState.Pressed || Keyboard.GetState().IsKeyDown(Keys.Escape))
                Exit();
            
            random = new Random();

            // TODO: Add your update logic here
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

            tribbleCRect.X += (int)tribbleCSpeed.X;
            if (tribbleCRect.Right > window.Width || tribbleCRect.Left <= 0)
            {
                tribbleCRect.X = random.Next(0,700);
            }

            tribbleCRect.Y += (int)tribbleCSpeed.Y;
            if (tribbleCRect.Bottom > window.Height || tribbleCRect.Top <= 0)
            {
                tribbleCRect.Y = random.Next(0,500);
            }



            tribbleGRect.X += (int)tribbleGSpeed.X;
            if (tribbleGRect.Right > window.Width || tribbleGRect.Left <= 0)
            {
                tribbleGSpeed.X = 1;
                tribbleGSpeed.X *= random.Next(-10, -1);
            }

            tribbleGRect.Y += (int)tribbleGSpeed.Y;
            if (tribbleGRect.Bottom > window.Height || tribbleGRect.Top <= 0)
            {
                tribbleGSpeed.X = 1;
                tribbleGSpeed.Y *= random.Next(-10, -1);
            }

           

            base.Update(gameTime);
        }

        protected override void Draw(GameTime gameTime)
        {
            GraphicsDevice.Clear(Color.Black);

            _spriteBatch.Begin();

            _spriteBatch.Draw(tribbleBTexture, tribbleBRect, Color.White);
            _spriteBatch.Draw(tribbleCTexture, tribbleCRect, Color.White);
            _spriteBatch.Draw(tribbleGTexture, tribbleGRect, Color.White);

            _spriteBatch.End();
            // TODO: Add your drawing code here

            base.Draw(gameTime);
        }
    }
}
