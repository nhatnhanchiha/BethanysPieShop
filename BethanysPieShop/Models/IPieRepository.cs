using System.Collections.Generic;

namespace BethanysPieShop.Models
{
    public interface IPieRepository
    {
        IEnumerable<Pie> AllPies();

        IEnumerable<Pie> PiesOfTheWeek();

        Pie GetById(int pieId);
    }
}