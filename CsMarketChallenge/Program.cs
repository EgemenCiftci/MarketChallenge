
using CsMarketChallenge.Players;

namespace CsMarketChallenge
{
    public static class Program
    {
        public static void Main()
        {
            Random random = new();
            Competitor[] competitors = new IPlayer[]
            {
                // Here will be all the strategies of all participants
                new RandomPlayer(),
                new RandomPlayer(),
                new RandomPlayer(),
                new RandomPlayer(),
                new RandomPlayer(),
                new RandomPlayer(),
                new RandomPlayer(),
                new RandomPlayer(),
                new RandomPlayer(),
                new RandomPlayer(),

                // My 5 bots
                new TruePlayer(),
                new TruePlayer(),
                new TruePlayer(),
                new TruePlayer(),
                new TruePlayer(),
            }
            .OrderBy(x => random.NextDouble())
            .Select(x => new Competitor(x))
            .ToArray();

            for (int i = 0; i < competitors.Length; i++)
            {
                for (int j = i; j < competitors.Length; j++)
                {
                    GameLoop game = new(competitors[i].Player, competitors[j].Player);

                    while (game.Step()) { }

                    competitors[i].Score += game.score1;
                    competitors[j].Score += game.score2;
                }
            }

            foreach (Competitor? competitor in competitors.OrderByDescending(x => x.Score))
            {
                Console.WriteLine($"{competitor.Score} - {competitor.Player.Title} - {competitor.Player.Author}");
            }
        }

        private class Competitor
        {
            public readonly IPlayer Player;
            public int Score;

            public Competitor(IPlayer player)
            {
                Player = player;
            }
        }
    }
}
