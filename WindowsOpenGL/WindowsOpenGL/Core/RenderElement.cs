// // --------------------------------
// // -- File Created 	: 22:01 24/06/2016
// // -- File Part of the Monogame Solution, project WindowsOpenGL
// // -- Edited By : Steve Cross
// // --------------------------------

using System;
using WindowsOpenGL.Core.Interfaces;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace WindowsOpenGL.Core
{
    public abstract class RenderElement : IRenderElement
    {
        public Boolean IsRenderEnabled { get; set; }
        public Boolean IsUpdateEnabled { get; set; }
        public Int32 RenderPriority { get; set; }

        public abstract void Draw(SpriteBatch spriteBatch);
        public abstract void Update(GameTime gameTime);

        protected RenderElement( Int32 renderPriority, Boolean updateEnabled = true, Boolean renderEnabled = true )
        {
            IsUpdateEnabled = updateEnabled;
            IsRenderEnabled = renderEnabled;
            RenderPriority = renderPriority;
        }

     
    }
}