using SFML.Graphics;
using SFML.System;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SFMLProject
{
    public class TextLabel: Drawable
    {

        private Text label;


        public TextLabel(Vector2f position, string text, Font font, int fontSize)
        {
            label = new Text(text, font, (uint)fontSize);
            label.Position = position;
        
            label.FillColor = Color.White;
        }

 

        public void SetPosition(Vector2f position)
        {
            label.Position = position;
        }

        public void SetText(string text)
        {
            label.DisplayedString = text;
        }

        public string GetText()
        {
            return label.DisplayedString;
        }

    

        public void Draw(RenderTarget target, RenderStates states)
        {
            target.Draw(label);
        }
    }
}
