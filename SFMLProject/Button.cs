using SFML.Graphics;
using SFML.System;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SFMLProject
{
    public class Button: Drawable
    {
        public event Action<Button,EventArgs> Clicked;

        private RectangleShape shape;
        private Text label;
        private bool isPressed;
        private bool isHower;


        public Button(Vector2f position, Vector2f size, string text, Font font, int fontSize)
        {
            label = new Text(text, font, (uint)fontSize);
            label.Position = new Vector2f(position.X, position.Y);
            label.FillColor = Color.White;

            Vector2f buttonSize = new Vector2f(label.GetLocalBounds().Width + 20, label.GetLocalBounds().Height + 10);
            
            shape = new RectangleShape(buttonSize);
            shape.Position = position;
            shape.FillColor = Color.Transparent;

          
            Vector2f buttonsize = shape.Size; // отримання розміру кнопки
            Vector2f textSize = new Vector2f(label.GetLocalBounds().Width, label.GetLocalBounds().Height); // отримання розміру тексту

            float textX = (shape.Position.X + (buttonsize.X - textSize.X) / 2); // обчислення положення тексту по осі X
            float textY = (shape.Position.Y + (buttonsize.Y - textSize.Y) / 2); // обчислення положення тексту по осі Y

            label.Position = new Vector2f(textX, textY);
            


            isPressed = false;
            isHower = false;
        }

        public bool IsHower(Vector2i mousePosition)
        {
            if (shape.GetGlobalBounds().Contains(mousePosition.X, mousePosition.Y))
            {
                isHower = true;
                label.Scale = new Vector2f(1.1f, 1.1f);
                Vector2f buttonsize = shape.Size; // отримання розміру кнопки
                Vector2f textSize = new Vector2f(label.GetLocalBounds().Width * 1.1f, label.GetLocalBounds().Height * 1.1f); // отримання розміру тексту

                float textX = (shape.Position.X + (buttonsize.X - textSize.X) / 2); // обчислення положення тексту по осі X
                float textY = (shape.Position.Y + (buttonsize.Y - textSize.Y) / 2); // обчислення положення тексту по осі Y
               
                label.Position = new Vector2f(textX, textY - 1);

                return true;
            }
            else
            {
                label.Scale = new Vector2f(1f, 1f);
                Vector2f buttonsize = shape.Size; // отримання розміру кнопки
                Vector2f textSize = new Vector2f(label.GetLocalBounds().Width, label.GetLocalBounds().Height); // отримання розміру тексту

                float textX = (shape.Position.X + (buttonsize.X - textSize.X) / 2); // обчислення положення тексту по осі X
                float textY = (shape.Position.Y + (buttonsize.Y - textSize.Y) / 2); // обчислення положення тексту по осі Y
        
                label.Position = new Vector2f(textX, textY);
                isHower = false;
            }
        
            return false;
        }

        public bool IsClicked(Vector2i mousePosition)
        {

            if (shape.GetGlobalBounds().Contains(mousePosition.X, mousePosition.Y))
            {
                if (!isPressed && Game.inputSystem.IsMouseButtonPressed(SFML.Window.Mouse.Button.Left))
                {
                    isPressed = true;
                    Clicked?.Invoke(this,EventArgs.Empty);
                }
                if (isPressed && !Game.inputSystem.IsMouseButtonPressed(SFML.Window.Mouse.Button.Left))
                    isPressed = false;
                return true;
            }
            else
            {
                isPressed = false;
            }

            return false;
        }

        public void SetPosition(Vector2f position)
        {
            shape.Position = position;
            Vector2f buttonsize = shape.Size; // отримання розміру кнопки
            Vector2f textSize = new Vector2f(label.GetLocalBounds().Width, label.GetLocalBounds().Height); // отримання розміру тексту

            float textX = (shape.Position.X + (buttonsize.X - textSize.X) / 2); // обчислення положення тексту по осі X
            float textY = (shape.Position.Y + (buttonsize.Y - textSize.Y) / 2); // обчислення положення тексту по осі Y

            label.Position = new Vector2f(textX, textY);
        }

        public void SetSize(Vector2f size)
        {
            shape.Size = size;
        }
        public void SetFontSize(uint size)
        {
            label.CharacterSize = size;
        }

        public void SetText(string text)
        {
            label.DisplayedString = text;
        }

        public void SetFillColor(Color color)
        {
            shape.FillColor = color;
        }

        public void Draw(RenderTarget target, RenderStates states)
        {
            target.Draw(shape);
            target.Draw(label);
        }
    }
}
