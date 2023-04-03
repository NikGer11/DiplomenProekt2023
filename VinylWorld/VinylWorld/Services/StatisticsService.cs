using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using VinylWorld.Abstractions;
using VinylWorld.Data;

namespace VinylWorld.Services
{
    public class StatisticsService : IStatisticsService
    {
        private readonly ApplicationDbContext _context;
        public StatisticsService(ApplicationDbContext context)
        {
            _context = context;
        }
        public int CountOrders()
        {
            return _context.Orders.Count();
        }

        public int CountClients()

        {
            return _context.Users.Count() - 1;
        }
           
        public int CountAlbums()
        {
            return _context.Albums.Count();
        }

        public decimal SumOrders()
        {
            return _context.Orders.Sum(x => x.Quantity * x.Price - x.Quantity * x.Price * x.Discount / 100);
        }       
    }
}
