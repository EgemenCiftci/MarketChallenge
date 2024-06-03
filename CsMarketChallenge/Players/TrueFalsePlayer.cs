namespace CsMarketChallenge.Players
{
    public class TrueFalsePlayer : IPlayer
    {
        public override string Author => "Egemen Ciftci";

        public override string Title => "True False Strategy";

        public override bool NextDecision(State state)
        {
            return state.Turn % 2 == 0;
        }
    }
}
