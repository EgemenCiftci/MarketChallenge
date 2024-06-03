namespace CsMarketChallenge.Players
{
    public class RandomBusterPlayer : IPlayer
    {
        public override string Author => "Egemen Ciftci";

        public override string Title => "Random Buster Strategy";

        public override bool NextDecision(State state)
        {
            int trueCount = state.OpponentDecisions.Count(x => x);
            int falseCount = state.OpponentDecisions.Count - trueCount;
            double ratio = trueCount / (double)falseCount;

            return trueCount >= falseCount;
        }
    }
}
