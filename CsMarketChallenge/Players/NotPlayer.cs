namespace CsMarketChallenge.Players
{
    public class NotPlayer : IPlayer
    {
        public override string Author => "Egemen Ciftci";

        public override string Title => "Not Strategy";

        public override bool NextDecision(State state)
        {
            return !state.OpponentDecisions.LastOrDefault();
        }
    }
}
