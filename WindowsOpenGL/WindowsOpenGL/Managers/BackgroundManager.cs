using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WindowsOpenGL.Core;
using WindowsOpenGL.Core.Interfaces;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace WindowsOpenGL.Managers
{
    public class BackgroundManager : RenderElement
    {
        public int NumberOfLayers = 1;

        private Texture2D[] _backgroundTextures;
        private Vector2[] _backgroundTexturePosition;

        public BackgroundManager(Int32 zPosition) : base(zPosition)
        {
            IsUpdateEnabled = false;
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

            for(Int32 i=0;i<NumberOfLayers;i++)
            {
                _backgroundTextures[i] = backgroundTextures[i];
                _backgroundTexturePosition[i] = origin[i];
            }
        }

        public override void Draw(SpriteBatch spriteBatch)
        {
            for (Int32 i = 0; i < NumberOfLayers; i++)
            {
                spriteBatch.Draw(_backgroundTextures[i], _backgroundTexturePosition[i], null, Color.White, 0f, Vector2.Zero, 1.0f, SpriteEffects.None, 0f);
            }
        }

        public override void Update(GameTime gameTime)
        {
            throw new NotImplementedException();
        }
    }
}
