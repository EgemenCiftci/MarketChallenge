using CsMarketChallenge;
using CsMarketChallenge.Players;
using Timer = System.Windows.Forms.Timer;

namespace ChallengeUI
{
    public static class Program
    {
        [STAThread]
        public static void Main()
        {
            ApplicationConfiguration.Initialize();

            RandomPlayer player1 = new();
            RandomPlayer player2 = new();

            GameUI ui = new();
            GameLoop game = new(player1, player2);
            IEnumerator<int> intervals = Intervals();
            _ = intervals.MoveNext();

            ui.Render(game);

            Timer timer = new()
            {
                Interval = 1000
            };
            timer.Tick += (s, e) =>
            {
                if (!game.Step(ui))
                {
                    timer.Stop();
                }
                _ = intervals.MoveNext();
                timer.Interval = intervals.Current;
            };
            timer.Start();

            Application.Run(new Form
            {
                Text = "C# Market Competition",
                AutoSize = true,
                AutoSizeMode = AutoSizeMode.GrowAndShrink,
                StartPosition = FormStartPosition.CenterScreen,
                MaximizeBox = false,
                Controls = { ui }
            });
        }

        private static IEnumerator<int> Intervals()
        {
            int source = 1000;
            int target = 100;
            int count = 20;

            for (int i = 0; i < count; i++)
            {
                yield return (source * (count - i) / count) + (target * i / count);
            }
            while (true)
            {
                yield return target;
            }
        }
    }
}