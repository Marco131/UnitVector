using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using System;
using UnitVector;

namespace ScreenSaverDemo
{
    public class ScreenSaver : Game
    {
        // Constants
        private int WINDOW_WIDTH = 1200;
        private int WINDOW_HEIGHT = 675;

        private float SPEED = 0.5f;
        private float SCALE = 0.3f;
        private float VECTOR_SCALE = 0.2f;


        // Fields
        private GraphicsDeviceManager _graphics;
        private SpriteBatch _spriteBatch;

        private Vector2 _position;
        private UnitVector2 _direction;
        private Texture2D _logoTexture;
        private Texture2D _vectorTexture;


        // Ctor
        public ScreenSaver()
        {
            _graphics = new GraphicsDeviceManager(this);
            Content.RootDirectory = "Content";
            IsMouseVisible = true;

            this._position = new Vector2(
                WINDOW_WIDTH / 2,
                WINDOW_HEIGHT / 2
            );
            this._direction = UnitVector2.LEFT_DOWN;
        }


        // Methods
        protected override void Initialize()
        {
            this._graphics.PreferredBackBufferWidth = WINDOW_WIDTH;
            this._graphics.PreferredBackBufferHeight = WINDOW_HEIGHT;
            this._graphics.ApplyChanges();

            base.Initialize();
        }

        protected override void LoadContent()
        {
            _spriteBatch = new SpriteBatch(GraphicsDevice);

            this._logoTexture = Content.Load<Texture2D>("Logo");
            this._vectorTexture = Content.Load<Texture2D>("Vector");
        }

        protected override void Update(GameTime gameTime)
        {
            if (GamePad.GetState(PlayerIndex.One).Buttons.Back == ButtonState.Pressed || Keyboard.GetState().IsKeyDown(Keys.Escape))
                Exit();


            // update pos
            this._position += SPEED * this._direction *  (float)gameTime.ElapsedGameTime.TotalMilliseconds;


            Vector2 imageSize = this._logoTexture.Bounds.Size.ToVector2() * SCALE;
            // test collisions
            //x
            if (this._position.X - imageSize.X / 2 < 0)
            {
                this._position.X = imageSize.X / 2;
                this._direction.ReverseX();
            }
            else if (this._position.X + imageSize.X / 2 > WINDOW_WIDTH)
            {
                this._position.X = WINDOW_WIDTH - imageSize.X / 2;
                this._direction.ReverseX();
            }

            // y
            if (this._position.Y - imageSize.Y / 2 < 0)
            {
                this._position.Y = imageSize.Y / 2;
                this._direction.ReverseY();
            }
            else if (this._position.Y + imageSize.Y / 2 > WINDOW_HEIGHT)
            {
                this._position.Y = WINDOW_HEIGHT - imageSize.Y / 2;
                this._direction.ReverseY();
            }

            base.Update(gameTime);
        }

        protected override void Draw(GameTime gameTime)
        {
            GraphicsDevice.Clear(Color.WhiteSmoke);

            
            this._spriteBatch.Begin(samplerState: SamplerState.PointClamp);
            
            // draw logo
            this._spriteBatch.Draw(this._logoTexture , this._position, null, Color.White, 0f, this._logoTexture.Bounds.Center.ToVector2(), SCALE, 0, 0);

            // draw vector
            float angle = this._direction.ConvertToAngle();
            this._spriteBatch.Draw(this._vectorTexture, this._position, null, Color.White, 
                this._direction.ConvertToAngle(), 
                new Vector2(0, this._vectorTexture.Height / 2),
                VECTOR_SCALE, 0, 0);

            this._spriteBatch.End();


            base.Draw(gameTime);
        }
    }
}