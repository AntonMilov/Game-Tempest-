using System;
using System.Collections.Generic;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Audio;

using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

using Microsoft.Xna.Framework.Content;

namespace Tempest
{
    public class ComponentClass : Microsoft.Xna.Framework.DrawableGameComponent
    {
        public Texture2D sprTexture;
        public Rectangle sprRectangle; //размер
        public Vector2 sprPosition; // позиция
        public Game Game; // позиция
        public ComponentClass(Game game, ref Texture2D newTexture,
        Rectangle newRectangle, Vector2 newPosition)
        : base(game)
        {
            Game = game;
            sprTexture = newTexture;
            sprRectangle = newRectangle;
            sprPosition = newPosition*100;
          
        }

        public override void Initialize()
        {
            
            base.Initialize();
        }
       
        public override void Update(GameTime gameTime)
        {
            // TODO: Add your update code here
            base.Update(gameTime);
        }
        public override void Draw(GameTime gameTime)
        {
            SpriteBatch sprBatch =
            (SpriteBatch)Game.Services.GetService(typeof(SpriteBatch));
            sprBatch.Draw(sprTexture, sprPosition, Color.White);
            base.Draw(gameTime);
        }
        public virtual void Action()
        {
           
        }

    }
}
