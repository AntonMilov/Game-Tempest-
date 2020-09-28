using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

namespace Tempest
{
    class spriteClass
    {
        public Texture2D spTexture; //переменая для хранения спрайта
        public Vector2 spPosition;//позиция на экране 
        public spriteClass(Texture2D newSpTexture, Vector2 newSpPosition)//конструктор класса
        {
            spTexture = newSpTexture;
            spPosition = newSpPosition;
        }
    }
}
