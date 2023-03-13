﻿using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
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
        //public IActionResult Index()
        //{
        //    string userId = this.User.FindFirstValue(ClaimTypes.NameIdentifier);
        //    var user = context.Users.SingleOrDefault(u => u.Id == userId);

        //    List<OrderIndex> orders = context.Orders
        //        .Select(x => new OrderIndex
        //        {
        //            Id = x.Id,
        //            OrderDate = x.OrderDate.ToString("dd-MMM,yyyy hh:mm", CultureInfo.InvariantCulture),
        //            UserId = x.UserId,
        //            User = x.User.UserName,
        //            ProductId = x.ProductId,
        //            Product = x.Product.ProductName,
        //            Picture = x.Product.Picture,
        //            Quantity = x.Quantity,
        //            Price = x.Price,
        //            Discount = x.Discount,
        //            TotalPrice = x.TotalPrice,
        //        }).ToList();
        //    return View(orders);
        //}
        //public IActionResult MyOrders(string searchString)
        //{
        //    string currentUserId = this.User.FindFirstValue(ClaimTypes.NameIdentifier);
        //    var user = this.context.Users.SingleOrDefault(u => u.Id == currentUserId);
        //    if (user == null)
        //    {
        //        return null;
        //    }
        //    List<OrderIndex> orders = context
        //        .Orders
        //        .Where(x => x.UserId == user.Id)
        //        .Select(x => new OrderIndex
        //        {
        //            Id = x.Id,
        //            OrderDate = x.OrderDate.ToString("dd-MMM,yyyy hh:mm", CultureInfo.InvariantCulture),
        //            UserId = x.UserId,
        //            User = x.User.UserName,
        //            ProductId = x.ProductId,
        //            Product = x.Product.ProductName,
        //            Picture = x.Product.Picture,
        //            Quantity = x.Quantity,
        //            Price = x.Price,
        //            Discount = x.Discount,
        //            TotalPrice = x.TotalPrice,
        //        }).ToList();
        //    if (!String.IsNullOrEmpty(searchString))
        //    {
        //        orders = orders.Where(o => o.Product.ToLower().Contains(searchString.ToLower())).ToList();

        //    }
        //    return this.View(orders);
        //}
        //public ActionResult Create(int productId, int quantity)
        //{
        //    string userId = this.User.FindFirstValue(ClaimTypes.NameIdentifier);
        //    var user = this.context.Users.SingleOrDefault(u => u.Id == userId);
        //    var product = this.context.Products.SingleOrDefault(x => x.Id == productId);

        //    if (user == null || product.Quantity < quantity)
        //    {
        //        return this.RedirectToAction("Index, Product");
        //    }
        //    OrderConfirmVM orderForDb = new OrderConfirmVM
        //    {
        //        UserId = userId,
        //        User = user.UserName,
        //        ProductId = productId,
        //        ProductName = product.ProductName,
        //        Picture = product.Picture,

        //        Quantity = quantity,
        //        Price = product.Price,
        //        Discount = product.Discount,
        //        TotalPrice = quantity * product.Price - quantity * product.Price * product.Discount / 100
        //    };
        //    return View(orderForDb);
        //}
        //public ActionResult Create(OrderConfirmVM bindingModel)
        //{
        //    if (this.ModelState.IsValid)
        //    {
        //        string userId = this.User.FindFirstValue(ClaimTypes.NameIdentifier);
        //        var user = this.context.Users.SingleOrDefault(u => u.Id == userId);
        //        var product = this.context.Products.SingleOrDefault(x => x.Id == bindingModel.ProductId);

        //        if (user == null || product.Quantity < bindingModel.Quantity || bindingModel.Quantity == 0)
        //        {
        //            return this.RedirectToAction("Index, Product");
        //        }
        //        Order orderForDb = new Order
        //        {
        //            OrderDate = DateTime.UtcNow,
        //            ProductId = bindingModel.ProductId,
        //            UserId = userId,
        //            Quantity = bindingModel.Quantity,
        //            Price = product.Price,
        //            Discount = product.Discount,

        //        };
        //        product.Quantity = bindingModel.Quantity;

        //        this.context.Products.Update(product);
        //        this.context.Orders.Add(orderForDb);
        //        this.context.SaveChanges();
        //    }
        //    return this.RedirectToAction("Index", "Product");
        //}
    }
}


