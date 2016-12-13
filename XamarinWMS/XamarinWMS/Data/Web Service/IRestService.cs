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

        /* Dlivery Line REST */ 

        Task<List<DeliveryLineData>> RefreshDelLineDataAsync();

        Task SaveDeliveryLineAsync(DeliveryLineData delLine, bool isNewDelLine);

        Task DeleteDeliveryLineAsync(int id);

        /* Order REST */

        Task<List<OrderData>> RefreshOrderDataAsync();

        Task SaveOrderAsync(OrderData order, bool isNewOrder);

        Task DeleteOrderAsync(int id);

        /* Pick REST */

        Task<List<PickData>> RefreshPicksAsync();

        Task SavePickAsync(PickData pick, bool isNewPick);

        Task DeletePickAsync(int pick);

        /* User REST */

        //Task<List<UserData>> RefreshUsersAsync();

        Task<bool> SaveUserAsync(UserData user, bool isNewUser);

        //Task DeleteUserAsync(string userName);
    }
}
