using SFML.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SFMLProject
{
    public class Scene
    {
        ImageEntity background;
        private string Name;

        List<Button> buttons = new List<Button>();
        List<Drawable> drawableObj = new List<Drawable>();

        public Scene(string sceneName)
        {
            Name = sceneName;
        }

        public string GetName()
        {
            return Name;
        }

        public void AddBackgroundImage(ImageEntity image)
        {
            background = image;
            background.SetSize(Program.win.Size.X,Program.win.Size.Y);
        }

        public void AddDrawableObj(Drawable obj)
        {
            drawableObj.Add(obj);
        }
        public void AddButton(Button obj)
        {
            buttons.Add(obj);
        }

        public void Update()
        {
            // Оновлення логіки сцени
        }

        public void Draw()
        {
            if(background != null)
                Program.win.Draw(background);

            foreach (var ob in drawableObj)
            {
                Program.win.Draw(ob);
            }

            foreach (var ob in buttons)
            {
                Program.win.Draw(ob);
            }
        }

        public void ProcessInput()
        {
            for (int i = 0; i < buttons.Count; i++)
            {
                buttons[i].IsHower(SFML.Window.Mouse.GetPosition(Program.win));
            }
            for (int i = 0; i < buttons.Count; i++)
            {
                buttons[i].IsClicked(SFML.Window.Mouse.GetPosition(Program.win));
            }
        }

    }
}
