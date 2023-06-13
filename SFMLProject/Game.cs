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
        private static InputSystem inputSystem = new InputSystem();
        private static string buttonKeysPressed = "";
        
        public static void Init()
        {
            sceneManager.AddScene(GetMainMenu());
            sceneManager.SwitchScene(0);
        }

        private static Scene GetMainMenu(){
            Scene MENU = new Scene();
            Button main = new Button(new Vector2f(10,10),new Vector2f(100,40), 
                buttonKeysPressed,);
            rec.FillColor = Color.White;
            MENU.AddDrawableObj(rec);

            return MENU;
        }

        

        public static void Run()
        {
            inputSystem.Update();
            sceneManager.ProcessInput();
            sceneManager.Update();
            sceneManager.Draw();
        }
    }
}
