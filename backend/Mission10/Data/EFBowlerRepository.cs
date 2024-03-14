namespace Mission10.Data
{
    public class EFBowlerRepository : IBowlerRepository
    {
        private BowlingContext _context;
        public EFBowlerRepository(BowlingContext temp)
        {
            _context = temp;
        }

        public IEnumerable<Bowler> Bowlers => _context.Bowlers;
        public IEnumerable<Team> Teams => _context.Teams;
    }
}
