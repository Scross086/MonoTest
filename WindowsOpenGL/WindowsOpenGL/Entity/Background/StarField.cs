using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WindowsOpenGL.Core;
using WindowsOpenGL.Core.Interfaces;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace WindowsOpenGL.Entity.Background
{
    public class StarField : RenderElement
    {
        private readonly List<Star> _Stars = new List<Star>();
        private Int32 ScreenWidth { get; set; }
        private Int32 ScreenHeight { get; set; }
        private readonly Random _Rand = new Random();

        public StarField(Int32 zPosition, Int32 screenWidth, Int32 screenHeight, Int32 starCount, Vector2 starVelocity, Texture2D texture, Rectangle initialFrame ) : base(zPosition)
        {
            ScreenWidth = screenWidth;
            ScreenHeight = screenHeight;

            for (Int32 x = 0; x < starCount; x++)
            {
                _Stars.Add(
                    new Star(
                        new Vector2(_Rand.Next(0, screenWidth),
                            _Rand.Next(0, screenHeight)),
                        texture,
                        initialFrame,
                        starVelocity)
                );
            }
            foreach (Star star in _Stars)
            {
                star.TintColor = Color.White; // colors[rand.Next(0, colors.Length)];
                star.TintColor *= _Rand.Next(30, 80)/100f;
            }
        }

        public override void Update(GameTime gameTime)
        {
            foreach (Star star in _Stars)
            {
                star.Update(gameTime);
                if (star.Location.X < 0)
                {
                    star.Location = new Vector2(ScreenWidth + 1, _Rand.Next(0, ScreenHeight));
                }
            }
        }

        public override void Draw(SpriteBatch spriteBatch)
        {
            foreach (Star star in _Stars)
            {
                star.Draw(spriteBatch);
            }
        }
    }
}
