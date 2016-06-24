// // --------------------------------
// // -- File Created 	: 19:43 24/06/2016
// // -- File Part of the WindowsOpenGL Solution, project WindowsOpenGL
// // -- Edited By : Steve Cross
// // --------------------------------

using System;
using System.Security.Cryptography.X509Certificates;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace WindowsOpenGL.Core.Interfaces
{
    public interface IRenderElement
    {
        Boolean IsRenderEnabled { get; set; }

        Boolean IsUpdateEnabled { get; set; }

        Int32 ZPosition { get; set; }

        void Draw(SpriteBatch spriteBatch);

        void Update(GameTime gameTime);

    }
}