using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Audio;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.GamerServices;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using Microsoft.Xna.Framework.Media;

namespace WarioWareClone
{
    /// <summary>
    /// This is the main type for your game
    /// </summary>
    public class Game1 : Microsoft.Xna.Framework.Game
    {
        GraphicsDeviceManager graphics;
        SpriteBatch spriteBatch;

        KeyboardState key;

        Texture2D sprite;
        Rectangle spriteRec;

        Texture2D plat;
        Rectangle platRec;

        int startY;
        int jumpspeed = 0;
        bool jumping;
        

        public Game1()
        {
            graphics = new GraphicsDeviceManager(this);
            Content.RootDirectory = "Content";
        }

        /// <summary>
        /// Allows the game to perform any initialization it needs to before starting to run.
        /// This is where it can query for any required services and load any non-graphic
        /// related content.  Calling base.Initialize will enumerate through any components
        /// and initialize them as well.
        /// </summary>
        protected override void Initialize()
        {
            spriteRec = new Rectangle(400, 300, 50, 50);
            startY = spriteRec.Y;
            platRec = new Rectangle(200, 200, 100, 10);

            base.Initialize();
        }

        /// <summary>
        /// LoadContent will be called once per game and is the place to load
        /// all of your content.
        /// </summary>
        protected override void LoadContent()
        {
            // Create a new SpriteBatch, which can be used to draw textures.
            spriteBatch = new SpriteBatch(GraphicsDevice);
            sprite = Content.Load<Texture2D>("michaelsprite1");
            plat = Content.Load<Texture2D>("health");
        }

        /// <summary>
        /// UnloadContent will be called once per game and is the place to unload
        /// all content.
        /// </summary>
        protected override void UnloadContent()
        {
            // TODO: Unload any non ContentManager content here
        }

        /// <summary>
        /// Allows the game to run logic such as updating the world,
        /// checking for collisions, gathering input, and playing audio.
        /// </summary>
        /// <param name="gameTime">Provides a snapshot of timing values.</param>
        protected override void Update(GameTime gameTime)
        {
            // Allows the game to exit
            if (GamePad.GetState(PlayerIndex.One).Buttons.Back == ButtonState.Pressed)
                this.Exit();

            key = Keyboard.GetState();

            if (key.IsKeyDown(Keys.Up) && !jumping)
            {
                jumpspeed = -15;
                jumping = true;
            }

            if (jumping)
            {
                spriteRec.Y += jumpspeed;
                jumpspeed++;
                if (spriteRec.Y == startY)
                {
                    jumping = false;
                    jumpspeed = 0;
                }
            }

            spriteRec = new Rectangle(spriteRec.X, spriteRec.Y, sprite.Width, sprite.Height);

            base.Update(gameTime);
        }

        /// <summary>
        /// This is called when the game should draw itself.
        /// </summary>
        /// <param name="gameTime">Provides a snapshot of timing values.</param>
        protected override void Draw(GameTime gameTime)
        {
            GraphicsDevice.Clear(Color.CornflowerBlue);

            spriteBatch.Begin();
            spriteBatch.Draw(sprite, spriteRec, Color.White);
            spriteBatch.Draw(plat, platRec, Color.White);
            spriteBatch.End();

            base.Draw(gameTime);
        }
    }
}
