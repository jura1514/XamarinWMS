using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using XamarinWMS.Data.Web_Service;
using XamarinWMS.Model;

namespace XamarinWMS.Data
{
    public class DeliveryManager
    {
        IRestService restService;

        public DeliveryManager(IRestService service)
        {
            restService = service;
        }

        public Task<List<DeliveryData>> GetTasksAsync()
        {
            return restService.RefreshDataAsync();
        }

        public Task SaveTaskAsync(DeliveryData del, bool isNewDel = false)
        {
            return restService.SaveDeliveryAsync(del, isNewDel);
        }

        public Task DeleteTaskAsync(DeliveryData del)
        {
            return restService.DeleteDeliveryAsync(del.DeliveryId);
        }
    }
}
