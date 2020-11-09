using System;
using System.Collections.Generic;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Audio;

using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

using Microsoft.Xna.Framework.Content;
namespace Tempest
{
    public class Enemy: ComponentClass
    {
        public Rectangle Screen;// размер экрана
        public Vector2 speed = new Vector2(2, 2); // скорость перемещения 
        public Texture2D ShootTexture;
        public double time = 0;
        public Enemy(Game game, ref Texture2D newTexture,
        Rectangle newRectangle, Vector2 newPosition, Rectangle Screen, ref Texture2D shootTexture) : base(game, ref newTexture, newRectangle, newPosition)
        {
            this.Screen = Screen;
            ShootTexture = shootTexture;
        }
        public override void Initialize()
        {
            base.Initialize();
        }
        public override void Update(GameTime gameTime)
        {
            Shoot(gameTime);
            move();
            base.Update(gameTime);
        }
        public override void Draw(GameTime gameTime)
        {
           
                SpriteBatch sprBatch =
                (SpriteBatch)Game.Services.GetService(typeof(SpriteBatch));
                sprBatch.Draw(sprTexture, sprPosition, Color.White);
                base.Draw(gameTime);
         
        }
        public void move() // движение
        {
            sprPosition.X -= speed.X;
            // проверка на пересечение границ экрана
            if (sprPosition.X < Screen.Left)
            {
                sprPosition.X = Screen.Left;
                speed *= -1;

            }
            if (sprPosition.X > Screen.Width - sprRectangle.Width)
            {
                sprPosition.X = Screen.Width - sprRectangle.Width;
                speed *= -1;

            }
        }
            public void Shoot(GameTime gameTime) //стрельба
        {
            time += gameTime.ElapsedGameTime.Milliseconds;
            if (time > 2000)
            {
                Game.Components.Add(new Shoot(Game, ref ShootTexture, new Rectangle(0, 0, 40, 60),new Vector2(sprPosition.X+sprRectangle.Width/2,sprPosition.Y+sprRectangle.Height / 2),Screen));

                time = 0;
            }
        }

    }
}
