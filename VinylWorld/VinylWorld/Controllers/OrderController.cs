using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using VinylWorld.Data;
using VinylWorld.Domain;
using VinylWorld.Models.Order;

namespace VinylWorld.Controllers
{
    public class OrderController : Controller
    {
        private readonly ApplicationDbContext context;

        public OrderController(ApplicationDbContext context)
        {
            this.context = context;
        }
        public IActionResult Index()
        {
            string userId = this.User.FindFirstValue(ClaimTypes.NameIdentifier);
            var user = context.Users.SingleOrDefault(u => u.Id == userId);

            List<OrderIndexVM> orders = context.Orders
               .Select(x => new OrderIndexVM
               {
                    Id = x.Id,
                    OrderDate = x.OrderDate.ToString("dd-MMM,yyyy hh:mm", CultureInfo.InvariantCulture),
                    UserId = x.UserId,
                    User = x.User.UserName,
                    AlbumId = x.AlbumId,
                    Album = x.Album.AlbumName,
                    Picture = x.Album.Picture,
                    Quantity = x.Quantity,
                    Price = x.Price,
                    Discount = x.Discount,
                    TotalPrice = x.TotalPrice,
               }).ToList();
            return View(orders);
        }
        public IActionResult MyOrders(string searchString)
        {
            string currentUserId = this.User.FindFirstValue(ClaimTypes.NameIdentifier);
            var user = this.context.Users.SingleOrDefault(u => u.Id == currentUserId);
            if (user == null)
            {
                return null;
            }
            List<OrderIndexVM> orders = context
                .Orders
                .Where(x => x.UserId == user.Id)
                .Select(x => new OrderIndexVM
                {
                    Id = x.Id,
                    OrderDate = x.OrderDate.ToString("dd-MMM,yyyy hh:mm", CultureInfo.InvariantCulture),
                    UserId = x.UserId,
                    User = x.User.UserName,
                    AlbumId = x.AlbumId,
                    Album = x.Album.AlbumName,
                    Picture = x.Album.Picture,
                    Quantity = x.Quantity,
                    Price = x.Price,
                    Discount = x.Discount,
                    TotalPrice = x.TotalPrice,
                }).ToList();
               if (!String.IsNullOrEmpty(searchString))
             {
                orders = orders.Where(o => o.Album.ToLower().Contains(searchString.ToLower())).ToList();

            }
            return this.View(orders);
        }
        public ActionResult Create(int albumId, int quantity)
        {
            string userId = this.User.FindFirstValue(ClaimTypes.NameIdentifier);
            var user = this.context.Users.SingleOrDefault(u => u.Id == userId);
           var album = this.context.Albums.SingleOrDefault(x => x.Id == albumId);

            if (user == null || album.Quantity < quantity)
            {
                return this.RedirectToAction("Index, Album");
            }
            OrderConfirmVM orderForDb = new OrderConfirmVM
            {
                //Id = x.Id,
                UserId = userId,
                User = user.UserName,
                AlbumId = albumId,
                AlbumName = album.AlbumName,
                Picture = album.Picture,
                Quantity = quantity,
                Price = album.Price,
                Discount = album.Discount,
                TotalPrice = quantity * album.Price - quantity * album.Price * album.Discount / 100
            };
            return View(orderForDb);
        }
        // POST: OrderController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(OrderConfirmVM bindingModel)
        {
            if (this.ModelState.IsValid)
           {
                string userId = this.User.FindFirstValue(ClaimTypes.NameIdentifier);
               var user = this.context.Users.SingleOrDefault(u => u.Id == userId);
                var album = this.context.Albums.SingleOrDefault(x => x.Id == bindingModel.AlbumId);

                if (user == null || album.Quantity < bindingModel.Quantity || bindingModel.Quantity == 0)
                {
                    return this.RedirectToAction("Index, Album");
                }
                Order orderForDb = new Order
                {
                    OrderDate = DateTime.UtcNow,
                   AlbumId = bindingModel.AlbumId,
                   UserId = userId,
                    Quantity = bindingModel.Quantity,
                    Price = album.Price,
                    Discount = album.Discount,

                };
                album.Quantity-= bindingModel.Quantity;

                this.context.Albums.Update(album);
                this.context.Orders.Add(orderForDb);
                this.context.SaveChanges();
            }
            return this.RedirectToAction("Index", "Album");
        }
    }
}


