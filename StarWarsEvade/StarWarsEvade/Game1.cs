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

namespace StarWarsEvade
{
    /// <summary>
    /// This is the main type for your game
    /// </summary>
    public class Game1 : Microsoft.Xna.Framework.Game
    {

        enum GameStates { TitleScreen, Intermission, Playing, GameOver };
        GameStates gameState = GameStates.TitleScreen ;
        Texture2D titleScreen;
        Texture2D spriteSheet;
        Texture2D Intermission;
        Sprite ship;
        bool spacePressed = false;
        Random rand;
        
            
        GraphicsDeviceManager graphics;
        SpriteBatch spriteBatch;

        public Game1()
        {
            graphics = new GraphicsDeviceManager(this);
            Content.RootDirectory = "Content";
            rand = new Random(System.Environment.TickCount);
        }

        /// <summary>
        /// Allows the game to perform any initialization it needs to before starting to run.
        /// This is where it can query for any required services and load any non-graphic
        /// related content.  Calling base.Initialize will enumerate through any components
        /// and initialize them as well.
        /// </summary>
        protected override void Initialize()
        {
            // TODO: Add your initialization logic here
            
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

            titleScreen = Content.Load<Texture2D>(@"Textures\TitleScreen");
            spriteSheet = Content.Load<Texture2D>(@"Textures\spriteSheet");
            Intermission = Content.Load<Texture2D>(@"Textures\Intermission");
            ship = new Sprite(new Vector2(200, 30f), spriteSheet, new Rectangle(-1, 1648, 418, 2043), new Vector2(0, 100));
            // TODO: use this.Content to load your game content here
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

            switch (gameState)
            {
                case GameStates.TitleScreen:
                    KeyboardState kb = Keyboard.GetState();
                   
                    if (!spacePressed && kb.IsKeyDown(Keys.Space))
                    {
                        spacePressed = true;
                        gameState = GameStates.Intermission;
                    }

                    if (kb.IsKeyUp(Keys.Space)) spacePressed = false;

                    break;

                case GameStates.Intermission:
                    KeyboardState key = Keyboard.GetState();
                 
                    if (!spacePressed && key.IsKeyDown(Keys.Space))
                    {
                        spacePressed = true;
                        gameState = GameStates.Playing;
                    }

                    if (key.IsKeyUp(Keys.Space)) spacePressed = false;

                    break;
            }

            

            // TODO: Add your update logic here

            base.Update(gameTime);
        }

        /// <summary>
        /// This is called when the game should draw itself.
        /// </summary>
        /// <param name="gameTime">Provides a snapshot of timing values.</param>
        protected override void Draw(GameTime gameTime)
        {
            GraphicsDevice.Clear(Color.Gray);

            spriteBatch.Begin();

            if (gameState == GameStates.TitleScreen)
            {
                spriteBatch.Draw(titleScreen, new Rectangle(0, 0, this.Window.ClientBounds.Width, this.Window.ClientBounds.Height), Color.White);
            }
            if (gameState == GameStates.Intermission)
            {
                spriteBatch.Draw(Intermission, new Rectangle(0, 0, this.Window.ClientBounds.Width, this.Window.ClientBounds.Height), Color.White);
            }
            if (gameState == GameStates.Playing)
            {
                for (int i = 0; i < 10000; i++)
                {
                    spriteBatch.Draw(Intermission, new Rectangle(rand.Next(0, this.Window.ClientBounds.Width), rand.Next(0,this.Window.ClientBounds.Height) , 5, 5), new Rectangle(rand.Next(0,500), rand.Next(0,200), 5, 5), Color.White);
                }
            }
            // TODO: Add your drawing code here
            spriteBatch.End();
            base.Draw(gameTime);
        }
    }
}
