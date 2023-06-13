using SFML.Window;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SFMLProject
{
    public class InputSystem
    {
        private Dictionary<Keyboard.Key, bool> keyStates;

        public InputSystem()
        {
            keyStates = new Dictionary<Keyboard.Key, bool>();

            // Ініціалізуємо всі клавіші в початковому стані "не натиснуто"
            foreach (Keyboard.Key key in System.Enum.GetValues(typeof(Keyboard.Key)))
            {
                keyStates[key] = false;
            }
        }

        public void Update()
        {
            foreach (Keyboard.Key key in System.Enum.GetValues(typeof(Keyboard.Key)))
            {
                keyStates[key] = Keyboard.IsKeyPressed(key);
            }
        }

        public bool IsKeyPressed(Keyboard.Key key)
        {
            if (keyStates.TryGetValue(key, out bool isPressed))
            {
                return isPressed;
            }
            return false;
        }
    }
}
