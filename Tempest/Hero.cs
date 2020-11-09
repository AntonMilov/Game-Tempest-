using System;
using System.Collections.Generic;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Audio;

using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

using Microsoft.Xna.Framework.Content;
namespace Tempest
{
    class Hero
    {
        public int Health=3;
        Game game;
        bool fly = false;
        public Texture2D sprite; // переменная для хранения спрайта
        public Vector2 position;
        public Vector2 speed = new Vector2(5, 5); // скорость перемещения 
        int Gravity = 1;// кратное число(иначе баг)
        bool Stop;
        Vector2 new_position = new Vector2(); // новая позиция указателя
        Rectangle sprRectangle = new Rectangle(0, 0, 80, 80);//размер героя

        public Hero(Game game, Texture2D sprite, Vector2 position)
        {
            this.game = game;
            this.sprite = sprite;
            this.position = position;
        }
        public void Control(Rectangle scrBounds)
        {
            KeyboardState kbState = Keyboard.GetState();
            if (kbState.IsKeyDown(Keys.Space)&&!fly)
            {
                Gravity *= -1;
                position.Y = position.Y + Gravity;
                fly = true;
            }
            if (kbState.IsKeyUp(Keys.Space)&&fly)
            {
                Gravity *= -1;
                fly = false;
            }


            if (CollideMettal())
                move(scrBounds);
            else// управление во время падаения
            {
                KeyboardState l = Keyboard.GetState();
                position.Y = position.Y + Gravity;
                if (l.IsKeyDown(Keys.Right))
                    {
                        position.X += (float)0.6;
                    }
                    if (l.IsKeyDown(Keys.Left))
                    {
                        position.X -= (float)0.6;
                    }
                CollideMettalSides();
            }
        }
        public void move(Rectangle scrBounds)//движение
        {
            KeyboardState kbState = Keyboard.GetState();
            if (kbState.IsKeyDown(Keys.Right))
            {
                position.X += speed.X;
            }
            if (kbState.IsKeyDown(Keys.Left))
            {
                position.X -= speed.X;
            }
            if (kbState.IsKeyDown(Keys.Up))
            {
                position.Y -= speed.Y;
            }
            // проверка на пересечение границ экрана
            if (position.X < scrBounds.Left)
            {
                position.X = scrBounds.Left;
               
            }
            if (position.X > scrBounds.Width - sprRectangle.Width)
            {
                position.X = scrBounds.Width - sprRectangle.Width;


            }
            if (position.Y < scrBounds.Top)
            {
                position.Y = scrBounds.Top;

            }
            if (position.Y > scrBounds.Height - sprRectangle.Height)
            {
                position.Y = scrBounds.Height - sprRectangle.Height;

            }
        }

        public bool CollideMettal()
        {
            foreach (ComponentClass spr in game.Components)
            {
                if (spr.GetType() == typeof(Metal))
                {
                    if (position.X + this.sprRectangle.Width >
                         spr.sprPosition.X &&
                         position.X < spr.sprPosition.X +
                         spr.sprRectangle.Width &&
                         position.Y + this.sprRectangle.Height >=
                         spr.sprPosition.Y &&
                         position.Y < spr.sprPosition.Y +
                         spr.sprRectangle.Height)
                    {
                        if (position.Y > spr.sprPosition.Y)
                        {
                            // обработка столкновения с левой стенкой
                            if (position.X + sprRectangle.Width > spr.sprPosition.X && position.X + sprRectangle.Width < spr.sprPosition.X + spr.sprRectangle.Width)
                            {
                                position.X = spr.sprPosition.X - sprRectangle.Width;

                            }
                            // обработка столкновения с правой стенкой
                            if (position.X < spr.sprPosition.X + spr.sprRectangle.Width && position.X + sprRectangle.Width > spr.sprPosition.X + spr.sprRectangle.Width)
                            {
                                position.X = spr.sprPosition.X + spr.sprRectangle.Width;

                            }
                        }
                        return true;
                    }
                }
            }
            return false;
        }
        public void CollideMettalSides()
        {
            foreach (ComponentClass spr in game.Components)
            {
                if (spr.GetType() == typeof(Metal))
                {
                    if ((position.X + this.sprRectangle.Width >
                     spr.sprPosition.X && position.X < spr.sprPosition.X + spr.sprRectangle.Width) &&
                      position.Y + this.sprRectangle.Height >= spr.sprPosition.Y &&
                      position.Y <= spr.sprPosition.Y + spr.sprRectangle.Height)
                    {
                        
                       
                            // обработка столкновения с левой стенкой
                                   if (position.X + sprRectangle.Width > spr.sprPosition.X && position.X + sprRectangle.Width < spr.sprPosition.X + spr.sprRectangle.Width && position.Y + this.sprRectangle.Height > spr.sprPosition.Y &&
                      position.Y< spr.sprPosition.Y + spr.sprRectangle.Height)
                            {
                                position.X = spr.sprPosition.X - sprRectangle.Width ;

                            }
                            // обработка столкновения с правой стенкой
                            if (position.X < spr.sprPosition.X + spr.sprRectangle.Width && position.X + sprRectangle.Width > spr.sprPosition.X + spr.sprRectangle.Width
                            && position.Y + this.sprRectangle.Height > spr.sprPosition.Y &&
                      position.Y < spr.sprPosition.Y + spr.sprRectangle.Height)
                            {
                                position.X = spr.sprPosition.X + spr.sprRectangle.Width;

                            }
                            // обработка на столкновение с "потолком" (без ==, не работает)
                        if (position.Y == spr.sprPosition.Y + spr.sprRectangle.Height && position.X + this.sprRectangle.Width >
                  spr.sprPosition.X && position.X < spr.sprPosition.X + spr.sprRectangle.Width && fly)
                        {
                            position.Y = spr.sprPosition.Y + spr.sprRectangle.Height + 1;

                        }


                    }
                }
            }
        }//пересечение в полете
        public bool CollideBonus()// пересечение бонуса
        {
            foreach (ComponentClass spr in game.Components)
            {
                if (spr.GetType() == typeof(Bonus))
                {
                    if (position.X + this.sprRectangle.Width >
                          spr.sprPosition.X &&
                          position.X < spr.sprPosition.X +
                          spr.sprRectangle.Width &&
                          position.Y + this.sprRectangle.Height >=
                          spr.sprPosition.Y &&
                          position.Y < spr.sprPosition.Y +
                          spr.sprRectangle.Height)
                    {
                        
                        spr.Action();
                        return true;
                    }
                }
            }
            return false;
        }
        public bool CollideShoot()
        {
            foreach (ComponentClass spr in game.Components)
            {
                if (spr.GetType() == typeof(Shoot))
                {
                    if (position.X + this.sprRectangle.Width >
                          spr.sprPosition.X &&
                          position.X < spr.sprPosition.X +
                          spr.sprRectangle.Width &&
                          position.Y + this.sprRectangle.Height >=
                          spr.sprPosition.Y &&
                          position.Y < spr.sprPosition.Y +
                          spr.sprRectangle.Height)
                    {

                        game.Components.Remove(spr);
                        Health--;
                        return true;
                    }
                }
            }
            return false;
        } 





    }
}
