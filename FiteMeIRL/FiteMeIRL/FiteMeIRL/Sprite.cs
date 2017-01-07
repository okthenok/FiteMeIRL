using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace FiteMeIRL
{
    public class Sprite
    {
        protected Texture2D _image;
        protected Vector2 _position;
        protected Color _color;
        protected Rectangle _sourceRectangle;
        protected Vector2 _origin;
        protected float _scale;
        public Texture2D Image
        {
            get { return _image; }
            set { _image = value; }
        }
        public Vector2 Position
        {
            get { return _position; }
            set { _position = value; }
        }
        public Color Color
        {
            get { return _color; }
            set { _color = value; }
        }
        public Rectangle SourceRectangle
        {
            get { return _sourceRectangle; }
            set { _sourceRectangle = value; }
        }



        public Sprite(Texture2D image, Vector2 position, Color color)
            : this(image, position, color, new Rectangle(0, 0, image.Width, image.Height), new Vector2(0, 0), 1.0f)
        {

        }

        public Sprite(Texture2D image, Vector2 position, Color color, Rectangle sourceRectangle, Vector2 origin, float scale)
        {
            _image = image;
            _position = position;
            _color = color;
            _sourceRectangle = sourceRectangle;
            _scale = scale;
            _origin = origin;
        }

        public virtual void Draw(SpriteBatch spriteBatch)
        {
            //spriteBatch.Draw(_image, _position, _sourceRectangle, _color);
            spriteBatch.Draw(_image, _position, _sourceRectangle, _color, 0, _origin, _scale, SpriteEffects.None, 1);
        }
    }
}
