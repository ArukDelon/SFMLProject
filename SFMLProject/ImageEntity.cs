using SFML.Graphics;
using SFML.System;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SFMLProject
{
    public class ImageEntity : Drawable
    {
        private Texture texture;
        private Sprite sprite;
        private RectangleShape rectangleShape;

        public ImageEntity(Color color)
        {
            rectangleShape = new RectangleShape();
            rectangleShape.FillColor = color;
        }
        public ImageEntity(string filename)
        {
            texture = new Texture(filename);
            sprite = new Sprite(texture);
        }
        public ImageEntity(Texture texture)
        {
            this.texture = texture;
            sprite = new Sprite(texture);
        }
        public void SetSize(Vector2f size)
        {
            if(rectangleShape != null){
                rectangleShape.Size = size;
                return;
            }
            sprite.Scale = new Vector2f(size.X / sprite.Texture.Size.X, size.Y / sprite.Texture.Size.Y);
        }

        public void SetSize(float width, float height)
        {
            SetSize(new Vector2f(width, height));
        }

        public void Draw(RenderTarget target, RenderStates states)
        {
            if (rectangleShape != null) {
                target.Draw(rectangleShape);
                return;
            }

            target.Draw(sprite);
        }
    }
}
