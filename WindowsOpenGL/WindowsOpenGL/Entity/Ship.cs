using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace WindowsOpenGL.Entity
{
    class Ship
    {
        public Texture2D MainTexture;

        public Vector2 Position;

        public bool Active;

        public int Health;

        public int Width
        {
            get { return MainTexture.Width; }
        }

        public int Height
        {
            get { return MainTexture.Height; }
        }

        public void Initialize(Texture2D texture, Vector2 position)
        {
            MainTexture = texture;

            //Set the starting position of the player around the middle of the screen and to the back
            Position = position;

            //Set the player to be active
            Active = true;

            //Set the player health
            Health = 100;
        }

        public void Draw(SpriteBatch spriteBatch)
        {
            spriteBatch.Draw(MainTexture, Position, null, Color.White, 0f, Vector2.Zero, 1f, SpriteEffects.None, 0f);
        }
    }
}
