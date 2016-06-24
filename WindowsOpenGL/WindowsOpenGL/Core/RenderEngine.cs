using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WindowsOpenGL.Core.Interfaces;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace WindowsOpenGL.Core
{
    public class RenderEngine :  IRenderElement
    {
        private List<IRenderElement> _RenderList;
        public Boolean IsRenderEnabled { get; set; }
        public Boolean IsUpdateEnabled { get; set; }
        public Int32 ZPosition { get; set; }

        public RenderEngine(Boolean deferInitialisation = false)
        {
            ZPosition = 0;
            if(!deferInitialisation) Initialise();
        }

        public void Initialise()
        {
            _RenderList = new List<IRenderElement>();
        }

        public void AddRenderElement(IRenderElement renderElement)
        {
            _RenderList.Insert(renderElement.ZPosition, renderElement);
        }

        public void RemoveRenderElement(IRenderElement renderElement)
        {
            _RenderList.Remove(renderElement);
        }

        public void SortRenderList()
        {
            _RenderList.Sort((r1, r2) => r1.ZPosition.CompareTo(r2.ZPosition));
        }

        public void ClearRenderList()
        {
            _RenderList = new List<IRenderElement>();
        }

        public void Draw(SpriteBatch spriteBatch)
        {
            if (!IsRenderEnabled) return;
            foreach (IRenderElement renderable in _RenderList)
            {
                if (renderable.IsRenderEnabled) renderable.Draw(spriteBatch);
            }
        }

        public void Update(GameTime gameTime)
        {
            if (!IsUpdateEnabled) return;
            foreach (IRenderElement renderable in _RenderList)
            {
                if (renderable.IsUpdateEnabled) renderable.Update(gameTime);
            }
        }
    }
}
