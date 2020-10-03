using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

namespace Tempest
{
    /// <summary>
    /// This is the main type for your game.
    /// </summary>
    public class GameTempest : Game
    {
        GraphicsDeviceManager graphics;
        SpriteBatch spriteBatch;



        Hero newHero=new Hero();

        Rectangle scrBounds; // прямоугольник для хранения размеров экрана
        public GameTempest()
        {
            graphics = new GraphicsDeviceManager(this);
            Content.RootDirectory = "Content";
            scrBounds = new Rectangle(0, 0,
             Window.ClientBounds.Width,
             Window.ClientBounds.Height);
         
        }

    
        protected override void Initialize()
        {

            this.IsMouseVisible = true; // отображение указателя            
            base.Initialize();
        }

     
        protected override void LoadContent()
        {
           
            spriteBatch = new SpriteBatch(GraphicsDevice);
         
        
            newHero.sprite= Content.Load<Texture2D>("HeroSprite");

   
           
        

        }
     
        protected override void UnloadContent()
        {

        }

      
        protected override void Update(GameTime gameTime)
        {
            if (GamePad.GetState(PlayerIndex.One).Buttons.Back == ButtonState.Pressed || Keyboard.GetState().IsKeyDown(Keys.Escape))
                Exit();
            newHero.move(scrBounds); // перемещенеи
       
           
            base.Update(gameTime);
        }

      
        protected override void Draw(GameTime gameTime)
        {
            GraphicsDevice.Clear(Color.CornflowerBlue);

            spriteBatch.Begin();
            spriteBatch.Draw(newHero.sprite, newHero.position, Color.White); //отрисовка спрайта
  
            base.Draw(gameTime); //отрисовка компонента 
            spriteBatch.End();


          
        }
    }
}
