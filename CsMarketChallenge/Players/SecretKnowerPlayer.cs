namespace CsMarketChallenge.Players
{
    public class SecretKnowerPlayer : IPlayer
    {
        private static readonly Random random = new();
        private static readonly bool[] secret = [true, false, true, true, false];

        public override string Author => "Egemen Ciftci";

        public override string Title => "Secret Knower Strategy";

        public override bool NextDecision(State state)
        {
            return state.Turn < secret.Length ? secret[state.Turn] : random.Next() > (int.MaxValue / 2);
        }
    }
}
