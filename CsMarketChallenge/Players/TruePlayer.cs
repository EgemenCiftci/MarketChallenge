namespace CsMarketChallenge.Players
{
    public class TruePlayer : IPlayer
    {
        public override string Author => "Egemen Ciftci";

        public override string Title => "True Strategy";

        public override bool NextDecision(State state)
        {
            return true;
        }
    }
}
