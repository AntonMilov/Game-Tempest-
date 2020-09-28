using System;
using System.Collections.Generic;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Audio;

using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

using Microsoft.Xna.Framework.Content;
namespace Tempest
{
    /// <summary>
    /// This is a game component that implements IUpdateable.
    /// </summary>
    public class spriteComp : Microsoft.Xna.Framework.DrawableGameComponent
    {
        private Texture2D sprTexture;
        private Rectangle sprRectangle;
        private Vector2 sprPosition;
        public spriteComp(Game game, ref Texture2D newTexture,
        Rectangle newRectangle, Vector2 newPosition)
        : base(game)
        {
            sprTexture = newTexture;
            sprRectangle = newRectangle;
            sprPosition = newPosition;
            // TODO: Construct any child components here
        }
       
 public override void Initialize()
        {
            // TODO: Add your initialization code here
            base.Initialize();
        }
        /// <summary>
        /// Allows the game component to update itself.
        /// </summary>
        /// <param name="gameTime">Provides a snapshot of timing values</param>
        public override void Update(GameTime gameTime)
        {
            // TODO: Add your update code here
            base.Update(gameTime);
        }
        public override void Draw(GameTime gameTime)
        {
            SpriteBatch sprBatch =
                (SpriteBatch)Game.Services.GetService(typeof(SpriteBatch));

            sprBatch.Draw(sprTexture, sprPosition, sprRectangle, Color.White);
            base.Draw(gameTime);
        }
    }
}