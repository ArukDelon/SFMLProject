using SFML.Graphics;
using SFML.System;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SFMLProject
{
    static class Game   
    {
        private static SceneManager sceneManager = new SceneManager();
        
        public static void Init()
        {
            Scene MENU = new Scene();
            RectangleShape rec = new RectangleShape(new Vector2f(60,50));
            rec.FillColor = Color.White;
            MENU.AddDrawableObj(rec);
            sceneManager.AddScene(MENU);
            sceneManager.SwitchScene(0);
        }

        private static Scene MainMenu(){
            Scene MENU = new Scene();
            RectangleShape rec = new RectangleShape(new Vector2f(60, 50));
            rec.FillColor = Color.White;
            MENU.AddDrawableObj(rec);
        }

        

        public static void Run()
        {
            sceneManager.ProcessInput();
            sceneManager.Update();
            sceneManager.Draw();
        }
    }
}
