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
        private Boolean _IsRenderListDirty;
        public Boolean IsRenderEnabled { get; set; }
        public Boolean IsUpdateEnabled { get; set; }
        public Int32 RenderPriority { get; set; }

        public RenderEngine(Int32 globalRenderPriority = 0, Boolean deferInitialisation = false)
        {
            RenderPriority = globalRenderPriority;
            _IsRenderListDirty = false;
            if (!deferInitialisation) Initialise();
        }

        public void Initialise()
        {
            _RenderList = new List<IRenderElement>();
        }

        public void AddRenderElement(IRenderElement renderElement)
        {
            _RenderList.Add(renderElement);
            _IsRenderListDirty = true;
        }

        public void RemoveRenderElement(IRenderElement renderElement)
        {
            _RenderList.Remove(renderElement);
        }

        public void SortRenderList()
        {
            _RenderList.Sort((r1, r2) => r1.RenderPriority.CompareTo(r2.RenderPriority));
            _IsRenderListDirty = false;
        }

        public void ClearRenderList()
        {
            _RenderList = new List<IRenderElement>();
            _IsRenderListDirty = false;
        }

        public void Draw(SpriteBatch spriteBatch)
        {
            if (!IsRenderEnabled) return;
            if(_IsRenderListDirty)SortRenderList();
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
