using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using XamarinWMS.Model;

namespace XamarinWMS.Data.Web_Service
{
    public class OrderManager
    {
        IRestService restService;

        public OrderManager(IRestService service)
        {
            restService = service;
        }

        public Task<List<OrderData>> GetTasksAsync()
        {
            return restService.RefreshOrderDataAsync();
        }

        public Task SaveTaskAsync(OrderData order, bool isNewOrder = false)
        {
            return restService.SaveOrderAsync(order, isNewOrder);
        }

        public Task DeleteTaskAsync(OrderData order)
        {
            return restService.DeleteOrderAsync(order.OrderId);
        }
    }
}
