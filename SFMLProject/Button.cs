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
            shape = new RectangleShape(size);
            shape.Position = position;
            shape.FillColor = Color.Blue;

            label = new Text(text, font, (uint)fontSize);
            label.Position = new Vector2f(position.X + 10, position.Y + 10);
            label.FillColor = Color.White;

            isPressed = false;
            isHower = false;
        }

        public bool IsHower(Vector2i mousePosition)
        {
            if (shape.GetGlobalBounds().Contains(mousePosition.X, mousePosition.Y))
            {
                isHower = true;
                SetFillColor(Color.Red);
                return true;
            }
            else
            {
                SetFillColor(Color.Blue);
                isHower = false;
            }
            SetFillColor(Color.Blue);
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
            label.Position = new Vector2f(position.X + 10, position.Y + 10);
        }

        public void SetSize(Vector2f size)
        {
            shape.Size = size;
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
