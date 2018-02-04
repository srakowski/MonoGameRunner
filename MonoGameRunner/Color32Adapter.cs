using Microsoft.Xna.Framework;
using PixelVisionRunner;
using System;

namespace MonoGameRunner
{
    struct ColorAdapter32 : IColor32
    {
        private Color color;

        public byte a { get { return color.A; } }
        public byte r { get { return color.R; } }
        public byte g { get { return color.G; } }
        public byte b { get { return color.B; } }

        public ColorAdapter32(Color color)
        {
            this.color = color;
        }
    }
}
