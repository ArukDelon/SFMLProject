﻿using SFML.Graphics;
using SFML.System;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SFMLProject
{
    public class Button
    {
        private RectangleShape shape;
        private Text label;

        public Button(Vector2f position, Vector2f size, string text, Font font, int fontSize)
        {
            shape = new RectangleShape(size);
            shape.Position = position;
            shape.FillColor = Color.Blue;

            label = new Text(text, font, (uint)fontSize);
            label.Position = new Vector2f(position.X + 10, position.Y + 10);
            label.FillColor = Color.White;
        }

        public void Draw(RenderWindow window)
        {
            window.Draw(shape);
            window.Draw(label);
        }

        public bool IsClicked(Vector2i mousePosition)
        {
            return shape.GetGlobalBounds().Contains(mousePosition.X, mousePosition.Y);
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
    }
}