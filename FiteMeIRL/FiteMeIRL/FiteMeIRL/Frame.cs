using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace FiteMeIRL
{
    public class Frame
    {
        Vector2 origin;
        Rectangle hitbox;

        public Frame(int x, int y, int width, int height)
        {
            hitbox = new Rectangle(x, y, width, height);
            origin = new Vector2(0, 0);
        }

        public Rectangle Hitbox
        {
            get
            {
                return hitbox;
            }
            set
            {
                hitbox = value;
            }
        }
        public Vector2 Origin
        {
            get
            {
                return origin;
            }
            set
            {
                origin = value;
            }
        }

    }
}
