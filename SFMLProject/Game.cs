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
 
        private static TextLabel keyPressedLabel;
        public static void Init()
        {
            resourceManager.LoadResources();
            keyPressedLabel = new TextLabel(new Vector2f(10, 10), "", resourceManager.GetFont("Default"), 19);
            sceneManager.AddScene(GetMainMenu());
            sceneManager.AddScene(Editor());
            sceneManager.SwitchScene(0);
        }

        private static Scene GetMainMenu(){
            Scene MENU = new Scene("MainMenu");
            Button main = new Button(new Vector2f(60, Program.win.Size.Y - 220),new Vector2f(100,40), 
                "Start Game", resourceManager.GetFont("Default"),28);
            main.Clicked += Main_Clicked;
            Button edit = new Button(new Vector2f(60, Program.win.Size.Y - 160), new Vector2f(100, 40),
                "Editor", resourceManager.GetFont("Default"), 28);
            edit.Clicked += Edit_Clicked;
            Button exit = new Button(new Vector2f(60, Program.win.Size.Y - 100), new Vector2f(100, 40),
                "Exit", resourceManager.GetFont("Default"), 28);
            exit.Clicked += Exit_Clicked;


            MENU.AddButton(main);
            MENU.AddButton(edit);
            MENU.AddButton(exit);
            return MENU;
        }

        private static void Exit_Clicked(Button arg1, EventArgs arg2)
        {
            Program.win.Close();
        }

        private static void Edit_Clicked(Button arg1, EventArgs arg2)
        {
            sceneManager.SwitchScene(1);
        }

        private static Scene Editor()
        {
            Scene MENU = new Scene("Editor");
            Button main = new Button(new Vector2f(60, 60), new Vector2f(100, 40),
                "привіт", resourceManager.GetFont("Default"), 20);
            main.Clicked += Main_Clicked;
            MENU.AddBackgroundImage(new ImageEntity(Color.Blue));
            MENU.AddButton(main);
            return MENU;
        }

        private static void Main_Clicked(Button sender, EventArgs e)
        {
            sceneManager.SwitchScene("Hello");
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
