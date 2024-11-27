using Microsoft.Xna.Framework;
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

        Texture2D redCarTexture;
        Rectangle redCarRect;

        Texture2D highwayTexture;

        Texture2D trafficTexture;

        screen screen;

        public Game1()
        {
            _graphics = new GraphicsDeviceManager(this);
            Content.RootDirectory = "Content";
            IsMouseVisible = true;
        }

        protected override void Initialize()
        {
            // TODO: Add your initialization logic here
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
            highwayTexture = Content.Load<Texture2D>("highway");
            blackCarTexture = Content.Load<Texture2D>("black-car");
            redCarTexture = Content.Load<Texture2D>("red-car");
        }

        protected override void Update(GameTime gameTime)
        {
            if (GamePad.GetState(PlayerIndex.One).Buttons.Back == ButtonState.Pressed || Keyboard.GetState().IsKeyDown(Keys.Escape))
                Exit();

            // TODO: Add your update logic here

            base.Update(gameTime);
        }

        protected override void Draw(GameTime gameTime)
        {
            GraphicsDevice.Clear(Color.CornflowerBlue);

            // TODO: Add your drawing code here
            _spriteBatch.Begin();

            if (screen == screen.Intro)
            {
                _spriteBatch.Draw(highwayTexture, window, Color.White);
            }

            _spriteBatch.End();
            base.Draw(gameTime);
        }
    }
}
