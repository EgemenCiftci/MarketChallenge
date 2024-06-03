namespace CsMarketChallenge.Players
{
    public class FalsePlayer : IPlayer
    {
        public override string Author => "Egemen Ciftci";

        public override string Title => "False Strategy";

        public override bool NextDecision(State state)
        {
            return false;
        }
    }
}
