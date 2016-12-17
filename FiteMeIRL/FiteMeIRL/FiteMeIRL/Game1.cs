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

namespace FiteMeIRL
{
    public class Game1 : Microsoft.Xna.Framework.Game
    {
        GraphicsDeviceManager graphics;
        SpriteBatch spriteBatch;

        Sprite spriteSheet;
        List<Rectangle> walkingFrames;
        List<Rectangle> jumpingFrames;

        Fighter falcon;

        public Game1()
        {
            graphics = new GraphicsDeviceManager(this);
            Content.RootDirectory = "Content";
        }
        
        protected override void Initialize()
        {
            // TODO: Add your initialization logic here
            graphics.PreferredBackBufferHeight = 800;
            graphics.PreferredBackBufferWidth = 1600;
            graphics.ApplyChanges();
            IsMouseVisible = true;
            base.Initialize();
        }
        

        protected override void LoadContent()
        {
            // Create a new SpriteBatch, which can be used to draw textures.
            spriteBatch = new SpriteBatch(GraphicsDevice);

            // TODO: use this.Content to load your game content here
            walkingFrames = new List<Rectangle>();
            jumpingFrames = new List<Rectangle>();
            spriteSheet = new Sprite(Content.Load<Texture2D>("CaptFalc1stHalf"), new Vector2(100, 200), Color.White);

            walkingFrames.Add(new Rectangle(128, 208, 92, 112));
            walkingFrames.Add(new Rectangle(260, 212, 72, 116));
            walkingFrames.Add(new Rectangle(372, 216, 60, 112));
            walkingFrames.Add(new Rectangle(12, 328, 56, 116));
            walkingFrames.Add(new Rectangle(120, 336, 56, 116));
            walkingFrames.Add(new Rectangle(224, 332, 56, 116));
            walkingFrames.Add(new Rectangle(320, 336, 56, 112));
            walkingFrames.Add(new Rectangle(404, 336, 64, 116));

            AnimatedSprite falconWalking = new AnimatedSprite(Content.Load<Texture2D>("CaptFalc1stHalf"), new Vector2(100, 200), Color.White, walkingFrames);
            falconWalking.AnimationTime = new TimeSpan(0, 0, 0, 0, 125);

            jumpingFrames.Add(new Rectangle(8, 452, 60, 124));
            jumpingFrames.Add(new Rectangle(111, 456, 73, 108));
            jumpingFrames.Add(new Rectangle(212, 460, 73, 80));
            jumpingFrames.Add(new Rectangle(316, 460, 84, 97));

            AnimatedSprite falconJumping = new AnimatedSprite(Content.Load<Texture2D>("CaptFalc1stHalf"), new Vector2(100, 200), Color.White, jumpingFrames);
            falconJumping.AnimationTime = new TimeSpan(0, 0, 0, 0, 250);

            Dictionary<FighterState, AnimatedSprite> falconAnimations = new Dictionary<FighterState, AnimatedSprite>();
            falconAnimations.Add(FighterState.Walking, falconWalking);
            falconAnimations.Add(FighterState.Jumping, falconJumping);

            falcon = new Fighter(new Vector2(100, 200), Color.White, falconAnimations);
            falcon.WalkingSpeed = 1.5f;            
        }

        protected override void UnloadContent()
        {
            // TODO: Unload any non ContentManager content here
        }
        
        protected override void Update(GameTime gameTime)
        {
            // Allows the game to exit
            if (GamePad.GetState(PlayerIndex.One).Buttons.Back == ButtonState.Pressed)
                this.Exit();

            // TODO: Add your update logic here
            KeyboardState ks = Keyboard.GetState();
            falcon.Update(gameTime, ks);

            base.Update(gameTime);
        }
        
        protected override void Draw(GameTime gameTime)
        {
            GraphicsDevice.Clear(Color.CornflowerBlue);

            // TODO: Add your drawing code here
            spriteBatch.Begin();

            falcon.Draw(spriteBatch);

            spriteBatch.End();
            base.Draw(gameTime);
        }
    }
}
