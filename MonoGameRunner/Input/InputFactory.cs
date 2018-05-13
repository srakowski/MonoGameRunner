using MonoGameRunner.Data;
using MonoGameRunner.Input;
using PixelVisionRunner;
using PixelVisionSDK;
using PixelVisionSDK.Chips;
using System.Collections.Generic;
using Keys = Microsoft.Xna.Framework.Input.Keys;

namespace MonoGameRunner.Input
{
    class InputFactory : IInputFactory
    {
        private Dictionary<Buttons, Keys>[] keyBindings = new Dictionary<Buttons, Keys>[]
        {
            new Dictionary<Buttons, Keys>
            {
                { Buttons.Up, Keys.Up },
                { Buttons.Down, Keys.Down },
                { Buttons.Left, Keys.Left },
                { Buttons.Right, Keys.Right },
                { Buttons.A, Keys.X },
                { Buttons.B, Keys.C },
                { Buttons.Start, Keys.A },
                { Buttons.Select, Keys.S },
            },
            new Dictionary<Buttons, Keys>
            {
                { Buttons.Up, Keys.I },
                { Buttons.Down, Keys.K },
                { Buttons.Left, Keys.J },
                { Buttons.Right, Keys.L },
                { Buttons.A, Keys.OemQuotes },
                { Buttons.B, Keys.Enter },
                { Buttons.Start, Keys.Y },
                { Buttons.Select, Keys.U },
            },
        };

        private DisplayTarget displayTarget;

        public InputFactory(DisplayTarget displayTarget)
        {
            this.displayTarget = displayTarget;
        }

        public ButtonState CreateButtonBinding(int playerIdx, Buttons button)
        {
            // I think this would be enough to switch over?
            return new GamePadButtonInput(button);
            //return new KeyboardButtonInput(button, (int)keyBindings[playerIdx][button]);
        }

        public IKeyInput CreateKeyInput()
        {
            return new KeyInput();
        }

        public IMouseInput CreateMouseInput()
        {
            return new MouseInput(displayTarget);
        }
    }
}
