using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using XamarinWMS.Model;

namespace XamarinWMS.Data.Web_Service
{
    public interface IRestService
    {
        Task<List<DeliveryData>> RefreshDataAsync();

        Task SaveDeliveryAsync(DeliveryData del, bool isNewDel);

        Task DeleteDeliveryAsync(int id);
    }
}
