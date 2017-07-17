using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using System.Diagnostics;
using Lizzard.ComponentPattern;
using Lizzard.str;
using System.Windows;
using System.Windows.Media.Animation;

using System;

namespace Lizzard
{
    public class MainApp : Game
    {
       
        static public SpriteBatch spriteBatch;

        GraphicsDeviceManager graphics;
        TextureManager textureManager;
		XmlAssetsParser xmlManager;

        Stage stage;
        GameScreen gameScreen;
        GameTime time = new GameTime();

        public MainApp()
        {
            graphics = new GraphicsDeviceManager(this);
            Content.RootDirectory = "Content";
            graphics.PreferredBackBufferHeight = Configuration.WINDOWS_HEIGHT;
            graphics.PreferredBackBufferWidth = Configuration.WINDOWS_WIDTH;
        }

        protected override void Initialize()
        {
            base.Initialize();

            stage = new Stage();
            gameScreen = new GameScreen();

            stage.addChild(gameScreen);
            gameScreen.init();

            this.IsMouseVisible = true;
        }

        protected override void LoadContent()
        {
            spriteBatch = new SpriteBatch(GraphicsDevice);
            textureManager = new TextureManager(Content);
			xmlManager = new XmlAssetsParser();

            textureManager.addTexture("lizzard");
            textureManager.addTexture("monsters");
            xmlManager.load("Content/assets.xml");

            scoreFont = Content.Load<SpriteFont>("calibri");
        }

        protected override void UnloadContent()
        {
            
        }

        protected override void Update(GameTime gameTime)
        {
            if (GamePad.GetState(PlayerIndex.One).Buttons.Back == ButtonState.Pressed || Keyboard.GetState().IsKeyDown(Keys.Escape))
                Exit();

            stage.update(gameTime);
            base.Update(gameTime);
        }

        SpriteFont scoreFont;

        protected override void Draw(GameTime gameTime)
        {
			GraphicsDevice.Clear(Color.AntiqueWhite);

            spriteBatch.Begin();
            //spriteBatch.DrawString(scoreFont, "54654", new Vector2(10, 10), Color.Black);
            stage.draw();
            spriteBatch.End();

            base.Draw(gameTime);
           
        }
    }
}
