namespace CsMarketChallenge.Players
{
    public class FalseTruePlayer : IPlayer
    {
        public override string Author => "Egemen Ciftci";

        public override string Title => "False True Strategy";

        public override bool NextDecision(State state)
        {
            return state.Turn % 2 != 0;
        }
    }
}
