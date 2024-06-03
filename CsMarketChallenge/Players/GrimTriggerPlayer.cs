namespace CsMarketChallenge.Players
{
    public class GrimTriggerPlayer : IPlayer
    {
        public override string Author => "Egemen Ciftci";

        public override string Title => "Grim Trigger Strategy";

        public override bool NextDecision(State state)
        {
            return state.Turn == 0 || !state.OpponentDecisions.Contains(true);
        }
    }
}
