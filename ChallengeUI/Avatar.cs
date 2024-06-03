using CsMarketChallenge;
using SkiaSharp;
using Svg.Skia;

namespace ChallengeUI
{
    public class Avatar : IDisposable
    {
        private static readonly string Template = File.ReadAllText("Assets/avataaars.txt");
        private static readonly string[] Tops = File.ReadAllText("Assets/top.txt").Split("\n\n\n", StringSplitOptions.RemoveEmptyEntries);
        private static readonly string[] Clothes = File.ReadAllText("Assets/clothes.txt").Split("\n\n\n", StringSplitOptions.RemoveEmptyEntries);
        private static readonly string[] Eyebrows = File.ReadAllText("Assets/eyebrows.txt").Split("\n\n\n", StringSplitOptions.RemoveEmptyEntries);
        private static readonly string[] EyesHappy = File.ReadAllText("Assets/eyes-happy.txt").Split("\n\n\n", StringSplitOptions.RemoveEmptyEntries);
        private static readonly string[] EyesSad = File.ReadAllText("Assets/eyes-sad.txt").Split("\n\n\n", StringSplitOptions.RemoveEmptyEntries);
        private static readonly string[] MouthHappy = File.ReadAllText("Assets/mouth-happy.txt").Split("\n\n\n", StringSplitOptions.RemoveEmptyEntries);
        private static readonly string[] MouthSad = File.ReadAllText("Assets/mouth-sad.txt").Split("\n\n\n", StringSplitOptions.RemoveEmptyEntries);

        private const string ClothesColor = "#3C4F5C";
        private const string SkinColor = "#EDB98A";
        private const string HairColor = "#4A312C";

        private readonly Image happy;
        private readonly Image sad;

        public Avatar(IPlayer player)
        {
            int hash = player.GetHashCode();
            happy = CreateImage(hash, true);
            sad = CreateImage(hash, false);
        }

        public void Dispose()
        {
            happy.Dispose();
            sad.Dispose();
        }

        public Image GetImage(bool isHappy)
        {
            return isHappy ? happy : sad;
        }

        private static Image CreateImage(int seed, bool isHappy)
        {
            seed = seed < 0 ? -seed : seed;

            string[] Eyes = isHappy ? EyesHappy : EyesSad;
            string[] Mouth = isHappy ? MouthHappy : MouthSad;

            int t = Tops.Length;
            int c = Clothes.Length;
            int b = Eyebrows.Length;
            int e = Eyes.Length;
            int m = Mouth.Length;

            string top = Tops[seed % t];
            string clothes = Clothes[seed / t % c];
            string eyebrows = Eyebrows[seed / t / c % b];
            string eyes = Eyes[seed / t / c / b % e];
            string mouth = Mouth[seed / t / c / b / e % m];

            string data = Template
                .Replace("<!-- TOP -->", top)
                .Replace("<!-- CLOTHES -->", clothes)
                .Replace("<!-- EYEBROW -->", eyebrows)
                .Replace("<!-- EYES -->", eyes)
                .Replace("<!-- MOUTH -->", mouth)
                .Replace("var(--avataaar-skin-color)", SkinColor)
                .Replace("var(--avataaar-hair-color)", HairColor)
                .Replace("var(--avataaar-shirt-color)", ClothesColor);

            using SKSvg svg = SKSvg.CreateFromSvg(data);
            using MemoryStream memory = new();

            _ = svg.Save(memory, SKColors.Empty);
            memory.Position = 0;
            return Image.FromStream(memory);
        }
    }
}
