using System;
using System.Collections.Generic;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Audio;

using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

using Microsoft.Xna.Framework.Content;
namespace Tempest
{
    public class Shoot : ComponentClass
    {
        public Rectangle Screen;// размер экрана
        public Vector2 speed = new Vector2(2, 2); // скорость перемещения 
        public double time = 0;
        public Shoot(Game game, ref Texture2D newTexture,
        Rectangle newRectangle, Vector2 newPosition, Rectangle Screen) : base(game, ref newTexture, newRectangle, newPosition)
        {
            this.Screen = Screen;
            sprPosition = newPosition;
        }
        public override void Initialize()
        {
            base.Initialize();
        }
        public override void Update(GameTime gameTime)
        {
            move();
            Collide();
            base.Update(gameTime);
        }
        public override void Draw(GameTime gameTime)
        {
            SpriteBatch sprBatch =
            (SpriteBatch)Game.Services.GetService(typeof(SpriteBatch));
            sprBatch.Draw(sprTexture, sprPosition, Color.White);
            base.Draw(gameTime);

        }
        public override void Action()
        {

        }
        public void move() // движение
        {
            sprPosition.Y += speed.Y;
            if (sprPosition.Y > Screen.Height - sprRectangle.Height)
            {//проверка на столкновение экрана
                Game.Components.Remove(this);
                
            }

        }
        public void Collide()
        {
            foreach (ComponentClass spr in Game.Components)
            {
                if (spr.GetType() == typeof(Metal))
                {
                    if (sprPosition.X + this.sprRectangle.Width >
                         spr.sprPosition.X &&
                       sprPosition.X < spr.sprPosition.X +
                         spr.sprRectangle.Width &&
                       sprPosition.Y + this.sprRectangle.Height >=
                         spr.sprPosition.Y &&
                        sprPosition.Y < spr.sprPosition.Y +
                         spr.sprRectangle.Height)
                    {
                        Game.Components.Remove(this);
                        break; //прерываем , иначе баг об ошибки изменной колекции
                    }
                }
            }

        }
    }
}
