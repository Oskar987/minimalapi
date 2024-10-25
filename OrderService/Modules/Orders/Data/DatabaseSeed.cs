using Microsoft.EntityFrameworkCore;
using OrderService.Modules.Orders.Models;

namespace OrderService.Modules.Orders.Data;

public static class DatabaseSeed
{
    public static void SeedData(this WebApplication app, bool isProduction)
    {
        using var scope = app.Services.CreateScope();
        ApplicationDataContext applicationDataContext = scope.ServiceProvider.GetService<ApplicationDataContext>();

        if (isProduction)
        {
            Console.WriteLine("===> Attempting to apply migrations");

            try
            {
                applicationDataContext.Database.Migrate();
            }
            catch (Exception e)
            {
                Console.WriteLine("===> Could not run migrations");
            }
        }

        if (applicationDataContext != null && !applicationDataContext.Orders.Any())
        {
            var orderOne = new Order
            {
                Id = Guid.NewGuid(),
                Items = new (),
                Status = OrderStatus.Submitted,
                Email = "pavel@google.com"
            };
            
            var orderTwo = new Order
            {
                Id = Guid.NewGuid(),
                Items = new (),
                Status = OrderStatus.Paid,
                Email = "evgeniy@google.com"
            };

            var orderItemOne = new OrderItem
            {
                Id = Guid.NewGuid(),
                ProductName = "CLR via C#, J.Richter",
                Price = 40,
                Count = 1,
                OrderId = orderOne.Id
            };
            
            var orderItemTwo = new OrderItem
            {
                Id = Guid.NewGuid(),
                ProductName = "Clean Code, R.Martin",
                Price = 30,
                Count = 1,
                OrderId = orderTwo.Id
            };
            
            orderOne.Items.Add(orderItemOne);
            orderTwo.Items.Add(orderItemTwo);
            
            applicationDataContext.Orders.AddRange(orderOne, orderTwo);
            applicationDataContext.SaveChanges();
        }
        else
        {
            Console.WriteLine("===> We are already have orders");
        }
    }
}