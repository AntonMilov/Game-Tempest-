using System;
using System.Collections.Generic;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Audio;

using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

using Microsoft.Xna.Framework.Content;
namespace Tempest
{
    public class Bonus: ComponentClass
    {
        public bool hide=false;
         public double time=0;
        public Bonus(Game game, ref Texture2D newTexture,
        Rectangle newRectangle, Vector2 newPosition) : base(game, ref newTexture, newRectangle, newPosition)
        {

        }
        public override void Initialize()
        {
            base.Initialize();
        }
        public override void Update(GameTime gameTime)
        {
            if (hide==true) // таймер на новое появление
            {
               time += gameTime.ElapsedGameTime.Milliseconds;
                if (time > 2000)
                {
                    sprRectangle = new Rectangle(0, 0, 100, 100);
                    hide = false;
                    time = 0;
                }
              
            }
            base.Update(gameTime);
        }
        public override void Draw(GameTime gameTime)
        {
            if (!hide)
            {
                SpriteBatch sprBatch =
                (SpriteBatch)Game.Services.GetService(typeof(SpriteBatch));
                sprBatch.Draw(sprTexture, sprPosition, Color.White);
                base.Draw(gameTime);
            }
        }
        public override  void Action()
        {
           
            sprRectangle = new Rectangle(0, 0, 0, 0);
            hide = true;
        }

    }
}
