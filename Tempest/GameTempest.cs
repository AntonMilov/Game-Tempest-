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
        int [,] Layer = new int[9, 10] { 
            { 0, 0, 0, 0, 4, 0, 0, 0, 0, 0 },
            { 2, 0, 0, 0, 0, 0, 0, 0, 0, 0 },
            { 1, 0, 0, 0, 1, 0, 0, 0, 0, 0 },
            { 2, 0, 0, 0, 5, 2, 0, 0, 0, 2 },
            { 1, 1, 0, 1, 1, 1, 0, 1, 1, 1 },
            { 0, 1, 0, 0, 0, 0, 0, 1, 0, 0 },
            { 0, 0, 0, 1, 1, 1, 1, 0, 1, 0 },
            { 2, 0, 0, 0,0, 0, 0, 0, 1, 0 },
            { 1, 1, 0, 0, 0, 0, 0, 1,1 , 0 },
            };
        int score = 0;
        int WIDTH = 1000;
        int HEIGHT = 900;
        Hero newHero;
     
        bool permission = true;
        Rectangle scrBounds; // прямоугольник для хранения размеров экрана
        Texture2D floarMetal;
        Texture2D bonus;
        Texture2D enemy;
        Texture2D shoot;        Rectangle RectangleSprite = new Rectangle(0, 0, 100, 100);        public GameTempest()
        {
            graphics = new GraphicsDeviceManager(this);
            Content.RootDirectory = "Content";
        }
        protected override void Initialize()
        {
            this.IsMouseVisible = true; // отображение указателя
            //установка полного экрана
            graphics.PreferredBackBufferWidth = WIDTH;
            graphics.PreferredBackBufferHeight = HEIGHT;
            this.graphics.ApplyChanges();
            scrBounds = new Rectangle(0, 0,
            Window.ClientBounds.Width,
            Window.ClientBounds.Height);
            base.Initialize();
        }
        protected override void LoadContent()
        {
            spriteBatch = new SpriteBatch(GraphicsDevice);
            floarMetal = Content.Load<Texture2D>("Metal");
            bonus = Content.Load<Texture2D>("Bonus");
            enemy = Content.Load<Texture2D>("Enemy");
          shoot = Content.Load<Texture2D>("shoot");
            Services.AddService(typeof(SpriteBatch), spriteBatch);//запускаем сервис
            AddSprites();    
        }
        void AddSprites()
        {
            //Переменные для временного хранения адреса
            //героя
            int a = 0, b = 0;
            for (int i = 0; i < 9; i++)
            {
                for (int j = 0; j < 10; j++)
                {
                 
                    if (Layer[i, j] == 1)
                        Components.Add(new Metal(this, ref floarMetal, RectangleSprite, new Vector2(j, i)));
                   
                    if (Layer[i, j] == 2)
                        Components.Add(new Bonus(this, ref bonus, RectangleSprite, new Vector2(j, i)));
                    if (Layer[i, j] == 4)
                        Components.Add(new Enemy(this, ref enemy, RectangleSprite, new Vector2(j, i),scrBounds,ref shoot));
                    if (Layer[i, j] == 5)
                    {
                        a = i;
                        b = j;
                    }
                }
            }
            newHero = new Hero(this, Content.Load<Texture2D>("HeroSprite"), new Vector2(100 * b, ((100 * a)+20)));//добовление героя
        }
        protected override void UnloadContent()
        {
        }

        protected override void Update(GameTime gameTime)
        {
            if (GamePad.GetState(PlayerIndex.One).Buttons.Back == ButtonState.Pressed || Keyboard.GetState().IsKeyDown(Keys.Escape))
                Exit();
            newHero.Control(scrBounds); // перемещенеи
            newHero.CollideShoot();
            if (newHero.CollideBonus())
            {
                score += 1;
                Window.Title = "Счет:" + score.ToString();
            }
            Window.Title = "Счет:" + score.ToString()+"Здоровье:"+newHero.Health.ToString();
            if (newHero.Health ==0)
            {
                Exit();
            }
            base.Update(gameTime);
        }

        protected override void Draw(GameTime gameTime)
        {
            GraphicsDevice.Clear(Color.White);

            spriteBatch.Begin();
            spriteBatch.Draw(newHero.sprite, newHero.position, Color.White); //отрисовка спрайта
  
            base.Draw(gameTime); //отрисовка компонента 
            spriteBatch.End();


          
        }
    }
}
