using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Input;

namespace MonoGameRunner.Input
{
    static class InputStates
    {
        private static string _input = "";

        public static string TextInput
        {
            get
            {
                var curr = _input;
                _input = "";
                return curr;
            }
        }

        public static MouseState PrevMouseState { get; private set; }
        public static MouseState CurrMouseState { get; private set; }

        public static KeyboardState PrevKeyboardState { get; private set; }
        public static KeyboardState CurrKeyboardState { get; private set; }

        public static GamePadState PrevGamePadState { get; private set; }
        public static GamePadState CurrGamePadState { get; private set; }

        public static void Update()
        {
            PrevMouseState = CurrMouseState;
            CurrMouseState = Mouse.GetState();

            PrevKeyboardState = CurrKeyboardState;
            CurrKeyboardState = Keyboard.GetState();

            PrevGamePadState = CurrGamePadState;
            CurrGamePadState = GamePad.GetState(PlayerIndex.One);
        }

        public static void InputStates_TextInput(object sender, TextInputEventArgs e)
        {
            _input += e.Character;
        }
    }
}
