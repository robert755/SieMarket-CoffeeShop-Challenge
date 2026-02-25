using SieMarketProject.Classes;
namespace SieMarketProject.Services;
public class OrderService
{
    public decimal FinalPrice(Order order)
    {
       decimal subtotal= order.Items.Sum(item => item.Quantity * item.UnitPrice);
       if(subtotal > 500)
       {
        return subtotal * 0.9m; // 10% discount
    
       }
       return subtotal;

    }
    public string GetTopSpendingCustomer(List<Order> orders)
    { if(orders == null || orders.Count == 0)
        {
            return "No orders available";
        }
        var customerSpending = orders
            .GroupBy(order => order.CustomerName)
            .Select(group => new 
            {
                CustomerName = group.Key,
                TotalSpending = group.Sum(order => FinalPrice(order))
            })
            .OrderByDescending(x => x.TotalSpending)
            .FirstOrDefault();

        return customerSpending != null ? customerSpending.CustomerName : string.Empty;
    }

    public Dictionary<string, int> GetPopularProducts(List<Order> orders)
    {
        var productPopularity = new Dictionary<string, int>();

        foreach (var order in orders)
        {
            foreach (var item in order.Items)
            {
                if (productPopularity.ContainsKey(item.ProductName))
                {
                    productPopularity[item.ProductName] += item.Quantity;
                }
                else
                {
                    productPopularity[item.ProductName] = item.Quantity;
                }
            }
        }

        return productPopularity;
    }

}