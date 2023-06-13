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
        private Dictionary<Mouse.Button, bool> mouseButtonStates;

        public InputSystem()
        {
            keyStates = new Dictionary<Keyboard.Key, bool>();
            mouseButtonStates = new Dictionary<Mouse.Button, bool>();
            // Ініціалізуємо всі клавіші в початковому стані "не натиснуто"
            foreach (Keyboard.Key key in System.Enum.GetValues(typeof(Keyboard.Key)))
            {
                keyStates[key] = false;
            }

            // Ініціалізуємо всі кнопки миші в початковому стані "не натиснуто"
            foreach (Mouse.Button button in System.Enum.GetValues(typeof(Mouse.Button)))
            {
                mouseButtonStates[button] = false;
            }
        }

        public void Update()
        {
            foreach (Keyboard.Key key in System.Enum.GetValues(typeof(Keyboard.Key)))
            {
                keyStates[key] = Keyboard.IsKeyPressed(key);
            }

            foreach (Mouse.Button button in System.Enum.GetValues(typeof(Mouse.Button)))
            {
                mouseButtonStates[button] = Mouse.IsButtonPressed(button);
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

        public string GetAllPressedKeys()
        {
            List<Keyboard.Key> pressedKeys = keyStates.Where(kv => kv.Value).Select(kv => kv.Key).ToList();
            string val = "Зажато: ";
            foreach(var temp in pressedKeys)
            {
                val += temp.ToString() + " ";
            }
            return val;
        }

        public bool IsMouseButtonPressed(Mouse.Button button)
        {
            if (mouseButtonStates.TryGetValue(button, out bool isPressed))
            {
                return isPressed;
            }
            return false;
        }
    }
}
