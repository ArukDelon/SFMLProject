using SFML.Graphics;
using SFML.System;
using SFML.Window;
using System;

namespace SFMLProject
{
    class Program
    {
        static VideoMode desktopMode = VideoMode.DesktopMode;
        public static RenderWindow win = new RenderWindow(desktopMode, "Project", Styles.None);
        static void Main(string[] args)
        {
            View view = new View(new FloatRect(0, 0, desktopMode.Width, desktopMode.Height));
            win.SetView(view);
            win.SetVerticalSyncEnabled(true);
            win.Closed += Win_Closed;
            win.Resized += Win_Resized;
            Game.Init();

            while (win.IsOpen)
            {
                win.DispatchEvents();

                win.Clear(Color.Black);

                Game.Run();

                win.Display();
            }
        }

        private static void Win_Resized(object sender, SFML.Window.SizeEventArgs e)
        {
            RenderWindow window = (RenderWindow)sender;

            // Отримання нового розміру вікна
            Vector2u newSize =  new Vector2u(e.Width,e.Height);

            // Оновлення розмірів видової області вікна та видових портів
            View view = window.GetView();
            view.Size = new Vector2f(newSize.X, newSize.Y);
            win.SetView(view);
        }

        private static void Win_Closed(object sender, EventArgs e)
        {
            win.Close();
        }
    }
}
