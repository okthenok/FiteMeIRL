using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace FiteMeIRL
{    
    public class Fighter
    {        
        private Vector2 _position;
        private Color _color;

        private float _walkingSpeed;

        private AnimatedSprite _currentAnimation;
        Dictionary<FighterState, AnimatedSprite> _animations;

        public float WalkingSpeed
        {
            get { return _walkingSpeed; }
            set { _walkingSpeed = value; }
        }

        //TODO Implement Dictionary into the class
        public Fighter(Vector2 position, Color color, Dictionary<FighterState, AnimatedSprite> animations)
        {
            _position = position;
            _color = color;
            _walkingSpeed = 1;
            _animations = animations;         
        }

        public void Update(GameTime gameTime, KeyboardState ks)
        {
            if (ks.IsKeyDown(Keys.D))
            {
                _animations[FighterState.Walking].Update(gameTime);
                _position.X += _walkingSpeed;

                _currentAnimation = _animations[FighterState.Walking];
            }
            else if (ks.IsKeyDown(Keys.A))
            {
                _animations[FighterState.Walking].Reverse();
                _animations[FighterState.Walking].Update(gameTime);
                _position.X -= _walkingSpeed;

                _currentAnimation = _animations[FighterState.Walking];
            }
            else if (ks.IsKeyDown(Keys.W))
            {
                _animations[FighterState.Jumping].Update(gameTime);

                
                _currentAnimation = _animations[FighterState.Jumping];
            }
            else if (ks.IsKeyDown(Keys.W) && ks.IsKeyDown(Keys.D))
            {

            }
            else
            {
                _animations[FighterState.Walking].ResetAnimation();
                _currentAnimation = _animations[FighterState.Walking];
            }

            if (_currentAnimation != null)
            {
                _currentAnimation.Position = _position;
                _currentAnimation.Color = _color;
            }            
        }

        public void Draw(SpriteBatch spriteBatch)
        {
            if (_currentAnimation != null)
            {
                _currentAnimation.Draw(spriteBatch);
            }
        }
    }
}
