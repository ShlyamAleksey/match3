using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Content;

namespace Lizzard.ComponentPattern
{
    class TextureManager
    {
        private List<Texture> textures= new List<Texture>();
        private ContentManager content;
        static private TextureManager instance;

        public TextureManager(ContentManager content)
        {
            instance = this;
            this.content = content;
        }

        static public Texture2D textureByName(String name)
        {
            foreach (Texture texture in instance.textures)
            {
                if (texture.name == name) return texture.texture;
            }
            return null;
        }

        public void addTexture(String name)
        {
            foreach (Texture t in textures)
            {
                if (t.name == name) throw new Exception("Texture exist with name " + name);
            }

            Texture texture = new Texture();
            texture.name = name;
            texture.texture = this.content.Load<Texture2D>(name);
            textures.Add(texture);
        }
    }

    struct Texture
    {
        public Texture2D texture;
        public String name;
    }
}
