using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WindowsOpenGL.Core;
using WindowsOpenGL.Core.Interfaces;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace WindowsOpenGL.Entity
{
    public class Ship : RenderElement
    {
        public Texture2D MainTexture;

        public Vector2 Position;

        public Boolean Active;

        public Int32 Health;

        public Ship(Int32 renderPriority, Boolean updateEnabled = true, Boolean renderEnabled = true) : base(renderPriority, updateEnabled, renderEnabled)
        {
        }

        public Int32 Width => MainTexture.Width;

        public Int32 Height => MainTexture.Height;

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

        public override void Draw(SpriteBatch spriteBatch)
        {
            spriteBatch.Draw(MainTexture, Position, null, Color.White, 0f, Vector2.Zero, 1f, SpriteEffects.None, 0f);
        }

        public override void Update(GameTime gameTime)
        {
          //  throw new NotImplementedException();
        }
    }
}
