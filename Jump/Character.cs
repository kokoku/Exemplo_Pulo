using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Jump
{
    class Character
    {
        Texture2D texture;

        Vector2 position;
        Vector2 velocity;

        bool hasjumped;

        public Character(Texture2D newTexture, Vector2 newPosition)
        {
            texture = newTexture;
            position = newPosition;
            hasjumped = true;
        }

        public void Update(GameTime gameTime)
        {
            position += velocity;

            if (Keyboard.GetState().IsKeyDown(Keys.Right))
                velocity.X = 3f;
            else if (Keyboard.GetState().IsKeyDown(Keys.Left))
                velocity.X = -3f;
            else
                velocity.X = 0f;

            if (Keyboard.GetState().IsKeyDown(Keys.Up) && hasjumped == false)
            {
                position.Y -= 10f;
                velocity.Y = -5f;
                hasjumped = true;
            }

            if (hasjumped == true)
            {
                float i = 1;
                velocity.Y += 0.15f * i;
            }

            if (position.Y + texture.Height >= 450)
                hasjumped = false;

            if (hasjumped == false)
                velocity.Y = 0f;

        }

        public void Draw(SpriteBatch spriteBatch)
        {
            spriteBatch.Draw(texture, position, Color.White);
        }

    }
}
