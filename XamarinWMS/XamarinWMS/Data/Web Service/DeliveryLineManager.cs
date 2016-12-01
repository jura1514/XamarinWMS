using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using XamarinWMS.Model;

namespace XamarinWMS.Data.Web_Service
{
    public class DeliveryLineManager
    {
        IRestService restService;

        public DeliveryLineManager(IRestService service)
        {
            restService = service;
        }

        public Task<List<DeliveryLineData>> GetTasksAsync()
        {
            return restService.RefreshDelLineDataAsync();
        }

        public Task SaveTaskAsync(DeliveryLineData delLine, bool isNewDelLine = false)
        {
            return restService.SaveDeliveryLineAsync(delLine, isNewDelLine);
        }

        public Task DeleteTaskAsync(DeliveryLineData delLine)
        {
            return restService.DeleteDeliveryLineAsync(delLine.DeliveryLineId);
        }
    }
}
