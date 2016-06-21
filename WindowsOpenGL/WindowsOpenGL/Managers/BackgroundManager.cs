using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace WindowsOpenGL.Managers
{
    class BackgroundManager
    {
        public int NumberOfLayers = 1;

        private Texture2D[] _backgroundTextures;
        private Vector2[] _backgroundTexturePosition;

        public BackgroundManager( )
        {
            
        }

        public void Initialise(Texture2D[] backgroundTextures, Vector2[] origin)
        {
            SetTextures(backgroundTextures, origin);
        }

        public void SetTextures( Texture2D [] backgroundTextures, Vector2[] origin )
        {
            NumberOfLayers = backgroundTextures.Count();
            _backgroundTextures = new Texture2D[NumberOfLayers];
            _backgroundTexturePosition = new Vector2[NumberOfLayers];

            for(int i=0;i<NumberOfLayers;i++)
            {
                _backgroundTextures[i] = backgroundTextures[i];
                _backgroundTexturePosition[i] = origin[i];
            }
        }

        public void Draw(SpriteBatch spriteBatch)
        {
            for (int i = 0; i < NumberOfLayers; i++)
            {
                spriteBatch.Draw(_backgroundTextures[i], _backgroundTexturePosition[i], null, Color.White, 0f, Vector2.Zero, 1.0f, SpriteEffects.None, 0f);
            }
        }

    }
}
