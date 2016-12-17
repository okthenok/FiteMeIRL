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
            : this(image, position, color, new Rectangle(0, 0, image.Width, image.Height))
        {

        }

        public Sprite(Texture2D image, Vector2 position, Color color, Rectangle sourceRectangle)
        {
            _image = image;
            _position = position;
            _color = color;
            _sourceRectangle = sourceRectangle;      
        }

        public virtual void Draw(SpriteBatch spriteBatch)
        {
            spriteBatch.Draw(_image, _position, _sourceRectangle, _color);
        }
    }
}
