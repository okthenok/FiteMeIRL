using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace FiteMeIRL
{
    public class AnimatedSprite : Sprite
    {
        private List<Rectangle> _frames;
        int currentFrame = 0;
        TimeSpan elapsedGameTime;
        public TimeSpan AnimationTime;

        public List<Rectangle> frames
        {
            get { return _frames; }
            set { _frames = value; }
        }

        public AnimatedSprite(Texture2D texture, Vector2 position, Color color, List<Rectangle> frames)
            :base(texture, position, color)
        {
            _frames = frames;
            _sourceRectangle = frames[0];
            AnimationTime = new TimeSpan(0, 0, 0, 0, 150);          
        }

        public void Update(GameTime gameTime)
        {
            elapsedGameTime += gameTime.ElapsedGameTime;
            
            if (elapsedGameTime >= AnimationTime)
            {
                elapsedGameTime = TimeSpan.Zero;

                if (currentFrame < _frames.Count - 1)
                {
                    currentFrame++;
                }
                else
                {
                    currentFrame = 0;
                }

                _sourceRectangle = _frames[currentFrame];
            }
        }

        public void ResetAnimation()
        {
            currentFrame = 0;
            _sourceRectangle = _frames[currentFrame];
        }
        public void Reverse()
        {
            _frames.Reverse();
        }

        public override void Draw(SpriteBatch spriteBatch)
        {
            base.Draw(spriteBatch);
        }
    }
}
