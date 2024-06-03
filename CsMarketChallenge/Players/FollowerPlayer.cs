namespace CsMarketChallenge.Players
{
    public class FollowerPlayer : IPlayer
    {
        private static readonly Random random = new();
        private static bool isHandshaked = false;
        private static readonly bool[] secret = [false, true, false, false, true];

        public override string Author => "Egemen Ciftci";

        public override string Title => "Follower Strategy";

        public override bool NextDecision(State state)
        {
            if (state.Turn == secret.Length)
            {
                isHandshaked = state.OpponentDecisions.SequenceEqual(secret.Select(x => !x));
            }
            else if (state.Turn < secret.Length)
            {
                return secret[state.Turn];
            }

            return !isHandshaked && random.Next() > (int.MaxValue / 2);
        }
    }
}
