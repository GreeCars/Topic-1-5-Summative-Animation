using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Audio;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

namespace Topic_1_5_Summative_Animation
{
    enum Screen
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
        Rectangle blackCarRect1;
        Rectangle blackCarRect2;
        Rectangle blackCarRect3;
        Rectangle blackCarRect4;
        Vector2 blackCarSpeed;

        Texture2D redCarTexture;
        Rectangle redCarRect1;
        Rectangle redCarRect2;
        Rectangle redCarRect3;
        Rectangle redCarRect4;
        Vector2 redCarSpeed;

        Texture2D blueCarTexture;
        Rectangle blueCarRect1;
        Rectangle blueCarRect2;
        Vector2 blueCarSpeed;

        Texture2D highwayTexture;

        Texture2D trafficTexture;

        Texture2D wreckTexture;

        SpriteFont introFont;

        Screen screen;

        MouseState mouseState;

        SoundEffect introMusic;
        SoundEffectInstance introInstance;

        SoundEffect roadSound;
        SoundEffectInstance roadInstance;

        SoundEffect crashSound;
        SoundEffectInstance crashInstance;

        public Game1()
        {
            _graphics = new GraphicsDeviceManager(this);
            Content.RootDirectory = "Content";
            IsMouseVisible = true;
        }

        protected override void Initialize()
        {
            // TODO: Add your initialization logic here
            blackCarRect1 = new Rectangle(410, 500, 100, 150);
            blackCarRect2 = new Rectangle(410, 800, 100, 150);
            blackCarRect3 = new Rectangle(410, 1200, 100, 150);
            blackCarRect4 = new Rectangle(540, 1450, 90, 150);
            blackCarSpeed = new Vector2(-2, -2);

            redCarRect1 = new Rectangle(540, 450, 90, 150);
            redCarRect2 = new Rectangle(540, 950, 90, 150);
            redCarRect3 = new Rectangle(540, 1450, 90, 150);
            redCarRect4 = new Rectangle(410, 2000, 100, 150);
            redCarSpeed = new Vector2(-3, -3);

            blueCarRect1 = new Rectangle(260, -500, 160, 240);
            blueCarRect2 = new Rectangle(140, -50, 160, 240);
            blueCarSpeed = new Vector2(1, 1);

            window = new Rectangle(0, 0, 800, 600);
            _graphics.PreferredBackBufferWidth = window.Width;
            _graphics.PreferredBackBufferHeight = window.Height;
            _graphics.ApplyChanges();

            screen = Screen.Intro;
            base.Initialize();
            introInstance.Play();
        }

        protected override void LoadContent()
        {
            _spriteBatch = new SpriteBatch(GraphicsDevice);

            // TODO: use this.Content to load your game content here
            highwayTexture = Content.Load<Texture2D>("highway");
            trafficTexture = Content.Load<Texture2D>("traffic");
            wreckTexture = Content.Load<Texture2D>("wreck");
            blackCarTexture = Content.Load<Texture2D>("blackCar");
            redCarTexture = Content.Load<Texture2D>("redCar");
            blueCarTexture = Content.Load<Texture2D>("blueCar");
            introFont = Content.Load<SpriteFont>("IntroFont");
            introMusic = Content.Load<SoundEffect>("IntroMusic");
            roadSound = Content.Load<SoundEffect>("RoadSound");
            crashSound = Content.Load<SoundEffect>("CrashSound");
            introInstance = introMusic.CreateInstance();
            roadInstance = roadSound.CreateInstance();
            crashInstance = crashSound.CreateInstance();
        }

        protected override void Update(GameTime gameTime)
        {
            mouseState = Mouse.GetState();
            if (GamePad.GetState(PlayerIndex.One).Buttons.Back == ButtonState.Pressed || Keyboard.GetState().IsKeyDown(Keys.Escape))
                Exit();
            if (screen == Screen.Intro)
            {
                if (mouseState.LeftButton == ButtonState.Pressed || introInstance.State == SoundState.Stopped)
                {
                    screen = Screen.Road;
                    introInstance.Stop();
                    roadInstance.Play();
                }
            }
            else if (screen == Screen.Road)
            {
                // TODO: Add your update logic here
                blackCarRect1.Y += (int)blackCarSpeed.Y;
                blackCarRect2.Y += (int)blackCarSpeed.Y;
                blackCarRect3.Y += (int)blackCarSpeed.Y;
                blackCarRect4.Y += (int)blackCarSpeed.Y;
                redCarRect1.Y += (int)redCarSpeed.Y;
                redCarRect2.Y += (int)redCarSpeed.Y;
                redCarRect3.Y += (int)redCarSpeed.Y;
                redCarRect4.Y += (int)redCarSpeed.Y;
                blueCarRect1.Y += (int)blueCarSpeed.Y;
                blueCarRect2.Y += (int)blueCarSpeed.Y;
                if (redCarRect4.Intersects(blackCarRect3))
                {
                    screen = Screen.End;
                    roadInstance.Stop();
                    crashInstance.Play();
                }
            }
            else if (crashInstance.State == SoundState.Stopped)
                Exit();
            base.Update(gameTime);
        }

        protected override void Draw(GameTime gameTime)
        {
            GraphicsDevice.Clear(Color.CornflowerBlue);

            // TODO: Add your drawing code here
            _spriteBatch.Begin();

            if (screen == Screen.Intro)
            {
                _spriteBatch.Draw(trafficTexture, window, Color.Gray);
                _spriteBatch.DrawString(introFont, "TRAFFIC JAM", new Vector2(265, 285), Color.Red);
                _spriteBatch.DrawString(introFont, "CLICK   TO   PROCEED", new Vector2(195, 535), Color.Blue);
                introInstance.Play();
            }
            else if (screen == Screen.Road)
            {
                _spriteBatch.Draw(highwayTexture, window, Color.White);
                _spriteBatch.Draw(blackCarTexture, blackCarRect1, Color.White);
                _spriteBatch.Draw(blackCarTexture, blackCarRect2, Color.White);
                _spriteBatch.Draw(blackCarTexture, blackCarRect3, Color.White);
                _spriteBatch.Draw(blackCarTexture, blackCarRect4, Color.White);
                _spriteBatch.Draw(redCarTexture, redCarRect1, Color.White);
                _spriteBatch.Draw(redCarTexture, redCarRect2, Color.White);
                _spriteBatch.Draw(redCarTexture, redCarRect3, Color.White);
                _spriteBatch.Draw(redCarTexture, redCarRect4, Color.White);
                _spriteBatch.Draw(blueCarTexture, blueCarRect1, Color.White);
                _spriteBatch.Draw(blueCarTexture, blueCarRect2, Color.White);
            }
            else if (screen == Screen.End)
            {
                _spriteBatch.Draw(wreckTexture, window, Color.White);
                _spriteBatch.DrawString(introFont, "CAR WRECK", new Vector2(265, 285), Color.WhiteSmoke);
            }

            _spriteBatch.End();
            base.Draw(gameTime);
        }
    }
}
