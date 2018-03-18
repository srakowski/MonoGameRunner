using PixelVisionSDK;

namespace MonoGameRunner.Runners
{
    public class EngineReference
    {
        public bool HasEngine { get { return Engine != null; } }

        public IEngine Engine { get; set; }
    }
}
