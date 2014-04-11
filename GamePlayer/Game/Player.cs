namespace GamePlayer.Game
{
    public class Player
    {
        public readonly string Id;

        public int DeployableArmies { get; set; }
        public string PlayerName { get { return Id; } }
        public bool Friendly { get; set; }

        public Player(string id, bool friendly = false)
        {
            Id = id;
            Friendly = friendly;
        }
    }
}
