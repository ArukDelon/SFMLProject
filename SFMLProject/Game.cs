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
        public static InputSystem inputSystem = new InputSystem();
        private static ResourceManager resourceManager = new ResourceManager();
        private static string buttonKeysPressed = "";
        private static TextLabel keyPressedLabel;
        public static void Init()
        {
            resourceManager.LoadResources();
            keyPressedLabel = new TextLabel(new Vector2f(10, 10), "", resourceManager.GetFont("Default"), 19);
            sceneManager.AddScene(GetMainMenu());
            sceneManager.SwitchScene(0);
        }

        private static Scene GetMainMenu(){
            Scene MENU = new Scene();
            Button main = new Button(new Vector2f(60,60),new Vector2f(100,40), 
                buttonKeysPressed, resourceManager.GetFont("Default"),16);
            main.Clicked += Main_Clicked;



            MENU.AddButton(main);

            return MENU;
        }

        private static void Main_Clicked(Button sender, EventArgs e)
        {

        }

        

        public static void Run()
        {
            inputSystem.Update();
            sceneManager.ProcessInput();
            sceneManager.Update();
            sceneManager.Draw();

            //
            if(!keyPressedLabel.GetText().Equals(inputSystem.GetAllPressedKeys()))
            {
                keyPressedLabel.SetText(inputSystem.GetAllPressedKeys());
            }
            Program.win.Draw(keyPressedLabel);
        }


    }
}
