namespace GamePlayer.Game
{
    public class Region
    {
        public int Id { get; private set; }
        public SuperRegion SuperRegion { get; private set; }
        
        public Player Owner { get; set; }

        public Region(int id, SuperRegion superRegion)
        {
            Id = id;
            SuperRegion = superRegion;
        }
    }
}
