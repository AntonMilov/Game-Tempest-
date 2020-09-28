using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

namespace Tempest
{
    /// <summary>
    /// This is the main type for your game.
    /// </summary>
    public class Game1 : Game
    {
        GraphicsDeviceManager graphics;
        SpriteBatch spriteBatch;

        spriteClass spriteOBJ;
        private Texture2D MySprite; // переменная для хранения спрайта
        private Vector2 position = new Vector2(150, 200); // позиция на экране


        spriteComp gameObject;// компонент
        private Texture2D texture;
        public Game1()
        {
            graphics = new GraphicsDeviceManager(this);
            Content.RootDirectory = "Content";
        }

    
        protected override void Initialize()
        {
          

            base.Initialize();
        }

     
        protected override void LoadContent()
        {
           
            spriteBatch = new SpriteBatch(GraphicsDevice);
            MySprite = Content.Load<Texture2D>("HeroSprite"); //загузка спрайта
             spriteOBJ = new spriteClass(Content.Load<Texture2D>("tree"), new Vector2(350, 50));//загрузка спрайта объекта


            Services.AddService(typeof(SpriteBatch), spriteBatch);
            texture = Content.Load<Texture2D>("HeroSprite");
            CreateNewObject();
        }
        protected void CreateNewObject() // ля создания объекта gameObject.
        {
            gameObject = new spriteComp(this, ref texture,
                new Rectangle(18, 9, 17, 30), new Vector2(300, 150));
            Components.Add(gameObject);
        }
        protected override void UnloadContent()
        {

        }

      
        protected override void Update(GameTime gameTime)
        {
            if (GamePad.GetState(PlayerIndex.One).Buttons.Back == ButtonState.Pressed || Keyboard.GetState().IsKeyDown(Keys.Escape))
                Exit();


            base.Update(gameTime);
        }

      
        protected override void Draw(GameTime gameTime)
        {
            GraphicsDevice.Clear(Color.CornflowerBlue);

            spriteBatch.Begin();
            spriteBatch.Draw(MySprite, position, Color.White); //отрисовка спрайта
            spriteBatch.Draw(spriteOBJ.spTexture, spriteOBJ.spPosition, Color.White); //отрисовка спрайта объекта
            base.Draw(gameTime); //отрисовка компонента 
            spriteBatch.End();

          
        }
    }
}
