using SFML.Graphics;
using System;

namespace SFMLProject
{
    class Program
    {
        public static RenderWindow win = new RenderWindow(new SFML.Window.VideoMode(600, 400), "Project");
        static void Main(string[] args)
        {
            win.SetVerticalSyncEnabled(true);
            win.Closed += Win_Closed;
            Game.Init();

            while (win.IsOpen)
            {
                win.DispatchEvents();

                win.Clear(Color.Black);

                Game.Run();

                win.Display();
            }
        }

        private static void Win_Closed(object sender, EventArgs e)
        {
            win.Close();
        }
    }
}
