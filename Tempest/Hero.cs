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
        public Texture2D sprite; // переменная для хранения спрайта
        public Vector2 position = new Vector2(150, 200); // позиция на экране
        public Vector2 speed = new Vector2(1, 1); // скорость перемещения 

        bool is_MouseLB_Pressed = false; // устанавливается в TRUE при нажатии на левую кнопку мыши
        Vector2 new_position = new Vector2(); // новая позиция указателя
      
        Rectangle sprRectangle = new Rectangle(0, 0, 61, 78);//размер героя
        
        public void move(Rectangle scrBounds)
        {
            MouseState mState = Mouse.GetState();
            KeyboardState kbState = Keyboard.GetState();            if (kbState.IsKeyDown(Keys.LeftShift)) //увеличение скорости перемещения 
            {
                
                speed = new Vector2(2, 2);
            }
            else
            {
                speed = new Vector2(1, 1);
            }
            if (mState.LeftButton == ButtonState.Pressed)
            {
                is_MouseLB_Pressed = true;
                new_position.X = mState.X;
                new_position.Y = mState.Y;
            }
           
            if (is_MouseLB_Pressed)
            {
                if (new_position.X - position.X > 0|| position.X > scrBounds.Width)
                {
                    position.X += speed.X;
                }
                else if (new_position.X - position.X < 0)
                {
                    position.X -= speed.X;
                }
                if (new_position.Y - position.Y > 0)
                {
                    position.Y += speed.Y;
                }
                else if (new_position.Y - position.Y < 0)
                {
                    position.Y -= speed.Y;
                }
                if (position == new_position)
                {
                    is_MouseLB_Pressed = false;
                }

                // проверка на пересечение границ экрана
                if (position.X < scrBounds.Left)
                {
                    position.X = scrBounds.Left;
                    is_MouseLB_Pressed = false;
                }
                if (position.X > scrBounds.Width - sprRectangle.Width)
                {
                    position.X = scrBounds.Width - sprRectangle.Width;
                    is_MouseLB_Pressed = false;
                }
                if (position.Y < scrBounds.Top)
                {
                    position.Y = scrBounds.Top;
                    is_MouseLB_Pressed = false;
                }
                if (position.Y > scrBounds.Height - sprRectangle.Height)
                {
                    position.Y = scrBounds.Height - sprRectangle.Height;
                    is_MouseLB_Pressed = false;
                }

            }

        }
      
    }
}
