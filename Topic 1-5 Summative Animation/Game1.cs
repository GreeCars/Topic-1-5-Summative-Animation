using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Audio;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

namespace Topic_1_5_Summative_Animation
{
    enum screen
    {
        Intro,
        Road,
        End
    }
    public class Game1 : Game
    {
        private GraphicsDeviceManager _graphics;
        private SpriteBatch _spriteBatch;

        Rectangle window;

        Texture2D blackCarTexture;
        Rectangle blackCarRect;
        Vector2 blackCarSpeed;

        Texture2D redCarTexture;
        Rectangle redCarRect;
        Vector2 redCarSpeed;

        Texture2D highwayTexture;

        Texture2D trafficTexture;

        SpriteFont introFont;

        screen screen;

        MouseState mouseState;

        SoundEffect introMusic;
        SoundEffectInstance introInstance;

        public Game1()
        {
            _graphics = new GraphicsDeviceManager(this);
            Content.RootDirectory = "Content";
            IsMouseVisible = true;
        }

        protected override void Initialize()
        {
            // TODO: Add your initialization logic here
            blackCarRect = new Rectangle(410, 500, 100, 150);
            blackCarSpeed = new Vector2(-2, -2);

            redCarRect = new Rectangle(540, 450, 90, 150);
            redCarSpeed = new Vector2(-3, -3);

            window = new Rectangle(0, 0, 800, 600);
            _graphics.PreferredBackBufferWidth = window.Width;
            _graphics.PreferredBackBufferHeight = window.Height;
            _graphics.ApplyChanges();

            screen = screen.Intro;
            base.Initialize();
        }

        protected override void LoadContent()
        {
            _spriteBatch = new SpriteBatch(GraphicsDevice);

            // TODO: use this.Content to load your game content here
            highwayTexture = Content.Load<Texture2D>("highway");
            trafficTexture = Content.Load<Texture2D>("traffic");
            blackCarTexture = Content.Load<Texture2D>("blackCar");
            redCarTexture = Content.Load<Texture2D>("redCar");
            introFont = Content.Load<SpriteFont>("IntroFont");
            introMusic = Content.Load<SoundEffect>("IntroMusic");
            introInstance = introMusic.CreateInstance();
        }

        protected override void Update(GameTime gameTime)
        {
            mouseState = Mouse.GetState();
            if (GamePad.GetState(PlayerIndex.One).Buttons.Back == ButtonState.Pressed || Keyboard.GetState().IsKeyDown(Keys.Escape))
                Exit();
            if (screen == screen.Intro)
            {
                if (mouseState.LeftButton == ButtonState.Pressed || introInstance.State == SoundState.Stopped)
                    screen = screen.Road;
            }
            else if (screen == screen.Road)
            {
                // TODO: Add your update logic here
                blackCarRect.Y += (int)blackCarSpeed.Y;
                redCarRect.Y += (int)redCarSpeed.Y;
            }
                base.Update(gameTime);
        }

        protected override void Draw(GameTime gameTime)
        {
            GraphicsDevice.Clear(Color.CornflowerBlue);

            // TODO: Add your drawing code here
            _spriteBatch.Begin();

            if (screen == screen.Intro)
            {
                _spriteBatch.Draw(trafficTexture, window, Color.Gray);
                _spriteBatch.DrawString(introFont, "TRAFFIC JAM", new Vector2(265, 285), Color.Red);
                _spriteBatch.DrawString(introFont, "CLICK   TO   PROCEED", new Vector2(195, 535), Color.Blue);
                introInstance.Play();
            }
            else if (screen == screen.Road)
            {
                _spriteBatch.Draw(highwayTexture, window, Color.White);
                _spriteBatch.Draw(blackCarTexture, blackCarRect, Color.White);
                _spriteBatch.Draw(redCarTexture, redCarRect, Color.White);
            }

            _spriteBatch.End();
            base.Draw(gameTime);
        }
    }
}
