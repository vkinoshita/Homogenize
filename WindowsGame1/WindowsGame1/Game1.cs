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
using Homogenize.GLL;
using Common.Random;

namespace WindowsGame1
{
    /// <summary>
    /// This is the main type for your game
    /// </summary>
    public class Game1 : Microsoft.Xna.Framework.Game
    {
        GraphicsDeviceManager graphics;
        SpriteBatch spriteBatch;

        readonly int size = 3;
        Board board;

        ClickWatcher click;

        List<Panel> panels;

        MersenneTwister mt;

        Texture2D dummyTexture;

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
            mt = new MersenneTwister();
            board = new Board(size);
            click = new ClickWatcher(onClick);

            panels = new List<Panel>();
            InitializePanels();

            this.IsMouseVisible = true;
            base.Initialize();
        }

        private void InitializePanels()
        {
            Rectangle screenSize = Window.ClientBounds;
            int margin = 10;

            int boardSize;
            int panelSize;
            int firstX;
            int firstY;

            if (screenSize.Width > screenSize.Height)
            {
                boardSize = screenSize.Height;
                panelSize = boardSize / size;

                firstX = (screenSize.Width / 2) - (boardSize / 2);
                firstY = 0;
            }
            else
            {
                boardSize = screenSize.Width;
                panelSize = boardSize / size;

                firstX = 0;
                firstY = (screenSize.Height / 2) - (boardSize / 2);
            }

            int panelWidth = panelSize - (margin * 2);

            for (int y = 0; y < size; y++)
            {
                for (int x = 0; x < size; x++)
                {
                    Rectangle r = new Rectangle(firstX + (x * panelSize) + margin,
                                                firstY + (y * panelSize) + margin,
                                                panelWidth, panelWidth);

                    panels.Add(new Panel(board)
                    {
                        Rect = r,
                        X = x,
                        Y = y
                    });
                }
            }

            
        }

        /// <summary>
        /// LoadContent will be called once per game and is the place to load
        /// all of your content.
        /// </summary>
        protected override void LoadContent()
        {
            // Create a new SpriteBatch, which can be used to draw textures.
            spriteBatch = new SpriteBatch(GraphicsDevice);

            // TODO: use this.Content to load your game content here
            dummyTexture = new Texture2D(GraphicsDevice, 1, 1);
            dummyTexture.SetData(new Color[] { Color.White });

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

            if (Keyboard.GetState().IsKeyDown(Keys.F5))
            {
                Shuffle();
            }

            // TODO: Add your update logic here
            click.Check(Mouse.GetState());

            base.Update(gameTime);
        }

        private void Shuffle()
        {
            int x = mt.Next(size);
            int y = mt.Next(size);

            board.Click(x, y);
        }

        private void onClick(int X, int Y)
        {
            var panel = panels.FirstOrDefault(p => p.HitTest(X, Y));

            if (panel != null)
            {
                panel.Click();
            }
        }

        /// <summary>
        /// This is called when the game should draw itself.
        /// </summary>
        /// <param name="gameTime">Provides a snapshot of timing values.</param>
        protected override void Draw(GameTime gameTime)
        {
            GraphicsDevice.Clear(new Color(0.4f, 0.4f, 0.4f));

            spriteBatch.Begin(SpriteSortMode.BackToFront, BlendState.Opaque);

            // TODO: Add your drawing code here
            foreach (var panel in panels)
            {
                spriteBatch.Draw(dummyTexture, panel.Rect, GetColor(panel.GetState()));
                
            }

            spriteBatch.End();

            base.Draw(gameTime);
        }

        private Color GetColor(bool state)
        {
            if (state)
            {
                return Color.White;
            }

            return Color.Black;
        }
    }
}
