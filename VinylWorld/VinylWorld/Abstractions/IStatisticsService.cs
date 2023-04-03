using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace VinylWorld.Abstractions
{
    public interface IStatisticsService
    {
        int CountAlbums();

        int CountClients();

        int CountOrders();

        decimal SumOrders();
    }
}
