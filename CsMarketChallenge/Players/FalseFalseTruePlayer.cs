namespace CsMarketChallenge.Players
{
    public class FalseFalseTruePlayer : IPlayer
    {
        public override string Author => "Egemen Ciftci";

        public override string Title => "False False True Strategy";

        public override bool NextDecision(State state)
        {
            return (state.Turn % 3) switch
            {
                0 => false,
                1 => false,
                _ => true,
            };
        }
    }
}
