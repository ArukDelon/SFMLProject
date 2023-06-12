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

        public void AddDrawableObj(Drawable obj)
        {
            drawableObj.Add(obj);
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
        }

        public void ProcessInput()
        {
            // Обробка введення гравця
        }

    }
}
