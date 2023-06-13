using SFML.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SFMLProject
{
    class ResourceManager
    {
        private Dictionary<string, Font> fonts;
        private Dictionary<string, Texture> textures;

        public ResourceManager()
        {
            fonts = new Dictionary<string, Font>();
            textures = new Dictionary<string, Texture>();
        }

        public void LoadFont(string key, string filePath)
        {
            Font font = new Font(filePath);
            fonts.Add(key, font);
        }

        public Font GetFont(string key)
        {
            if (fonts.ContainsKey(key))
            {
                return fonts[key];
            }
            else
            {
                // Обробка помилки: шрифт не знайдено
                return null;
            }
        }

        public void LoadTexture(string key, string filePath)
        {
            Texture texture = new Texture(filePath);
            textures.Add(key, texture);
        }

        public Texture GetTexture(string key)
        {
            if (textures.ContainsKey(key))
            {
                return textures[key];
            }
            else
            {
                // Обробка помилки: текстура не знайдена
                return null;
            }
        }

        public void UnloadAll()
        {
            fonts.Clear();
            textures.Clear();
        }

        public void LoadResources()
        {
            //Fonts
            LoadFont("Default", "Fonts/catorze27style1-semibold.ttf");

            //Textures

        }
    }
}
