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
        List<Frame> walkingFrames;
        List<Frame> jumpingFrames;
        List<Frame> uppercutFrames;

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
            walkingFrames = new List<Frame>();
            jumpingFrames = new List<Frame>();
            uppercutFrames = new List<Frame>();
            spriteSheet = new Sprite(Content.Load<Texture2D>("CaptFalc1stHalf"), new Vector2(100, 200), Color.White);

            walkingFrames.Add(new Frame(128, 208, 92, 112));
            walkingFrames.Add(new Frame(260, 212, 72, 116));
            walkingFrames.Add(new Frame(372, 216, 60, 112));
            walkingFrames.Add(new Frame(12, 328, 56, 116));
            walkingFrames.Add(new Frame(120, 336, 56, 116));
            walkingFrames.Add(new Frame(224, 332, 56, 116));
            walkingFrames.Add(new Frame(320, 336, 56, 112));
            walkingFrames.Add(new Frame(404, 336, 64, 116));

            AnimatedSprite falconWalking = new AnimatedSprite(Content.Load<Texture2D>("CaptFalc1stHalf"), new Vector2(100, 200), Color.White, walkingFrames, 1.0f);
            falconWalking.AnimationTime = new TimeSpan(0, 0, 0, 0, 125);

            jumpingFrames.Add(new Frame(157, 1454, 54, 71));
            jumpingFrames.Add(new Frame(216, 1474, 71, 54));
            jumpingFrames.Add(new Frame(293, 1474, 79, 52));

            AnimatedSprite falconJumping = new AnimatedSprite(Content.Load<Texture2D>("CaptFalc2ndHalf"), new Vector2(100, 200), Color.White, jumpingFrames, 1.0f);
            falconJumping.AnimationTime = new TimeSpan(0, 0, 0, 0, 100);

            uppercutFrames.Add(new Frame(248, 12, 88, 80));
            uppercutFrames.Add(new Frame(364, 16, 88, 88));
            uppercutFrames.Add(new Frame(4, 104, 96, 84));
            uppercutFrames.Add(new Frame(127, 108, 93, 100));
            uppercutFrames.Add(new Frame(252, 108, 88, 108));
            uppercutFrames.Add(new Frame(380, 104, 65, 152));
            uppercutFrames[uppercutFrames.Count - 1].Origin = new Vector2(
                uppercutFrames[uppercutFrames.Count - 1].Origin.X, 
                uppercutFrames[uppercutFrames.Count - 1].Hitbox.Y - uppercutFrames[uppercutFrames.Count-1].Hitbox.Height/ 2);

            AnimatedSprite falconUppercut = new AnimatedSprite(Content.Load<Texture2D>("CaptFalc3rdHalf"), new Vector2(100, 200), Color.White, uppercutFrames, 1.0f);

            falconUppercut.AnimationTime = new TimeSpan(0, 0, 0, 0, 200);

            Dictionary<FighterState, AnimatedSprite> falconAnimations = new Dictionary<FighterState, AnimatedSprite>();
            falconAnimations.Add(FighterState.Walking, falconWalking);
            falconAnimations.Add(FighterState.Jumping, falconJumping);
            falconAnimations.Add(FighterState.Uppercut, falconUppercut);

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
