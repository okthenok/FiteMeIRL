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
        //private List<Rectangle> _frames;
        private List<Frame> _frames;
        int currentFrame = 0;
        TimeSpan elapsedGameTime;
        public TimeSpan AnimationTime;

        public List<Frame> frames
        {
            get { return _frames; }
            set { _frames = value; }
        }

        public AnimatedSprite(Texture2D texture, Vector2 position, Color color, List<Frame> frames, float scale)
            :base(texture, position, color, new Rectangle(), new Vector2(0, 0), scale)
        {
            _frames = frames;
            _sourceRectangle = frames[0].Hitbox;
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

                _sourceRectangle = _frames[currentFrame].Hitbox;
            }
        }

        public void ResetAnimation()
        {
            currentFrame = 0;
            _sourceRectangle = _frames[currentFrame].Hitbox;
        }
        public void Reverse()
        {
            _frames.Reverse();
        }


        public /*override*/ void Draw(SpriteBatch spriteBatch, bool drawFromBottom = false)
        {
            if(drawFromBottom)
            {
                //spriteBatch.Draw(_image, _position - new Vector2(0, _frames.Min(x => x.Hitbox.Height) + _frames[currentFrame].Hitbox.Height), _sourceRectangle, _color, 0, Vector2.Zero, _scale, SpriteEffects.None, 1.0f);
            }
            else
            {
                spriteBatch.Draw(_image, _position, _sourceRectangle, _color, 0, _frames[currentFrame].Origin, _scale, SpriteEffects.None, 1.0f);
            }
        }
    }
}
