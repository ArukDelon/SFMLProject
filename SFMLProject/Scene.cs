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
        List<Drawable> drawableObj = new List<Drawable>();

        List<Button> buttons = new List<Button>();

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
            foreach(var ob in drawableObj)
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
