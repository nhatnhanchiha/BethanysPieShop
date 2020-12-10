using System.Collections.Generic;

namespace BethanysPieShop.Models
{
    public class MockPieRepository : IPieRepository
    {
        public IEnumerable<Pie> AllPies { get; }
        public IEnumerable<Pie> PiesOfTheWeek { get; }
        public Pie GetById(int pieId)
        {
            throw new System.NotImplementedException();
        }
    }
}