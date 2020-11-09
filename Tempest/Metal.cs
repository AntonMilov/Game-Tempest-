using System;
using System.Collections.Generic;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Audio;

using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

using Microsoft.Xna.Framework.Content;
namespace Tempest
{
    public class Metal:ComponentClass
    {
        public Metal(Game game, ref Texture2D newTexture,
        Rectangle newRectangle, Vector2 newPosition) : base(game, ref newTexture, newRectangle, newPosition)
        {

        }
        public override void Initialize()
        {
            base.Initialize();
        }
        public override void Update(GameTime gameTime)
        {
            base.Update(gameTime);
        }
    }
}
