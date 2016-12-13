using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using XamarinWMS.Model;

namespace XamarinWMS.Data.Web_Service
{
    public class PickManager
    {
        IRestService restService;

        public PickManager(IRestService service)
        {
            restService = service;
        }

        public Task<List<PickData>> GetTasksAsync()
        {
            return restService.RefreshPicksAsync();
        }

        public Task SaveTaskAsync(PickData user, bool isNewPick = false)
        {
            return restService.SavePickAsync(user, isNewPick);
        }

        public Task DeleteTaskAsync(PickData pick)
        {
            return restService.DeletePickAsync(pick.PickId);
        }
    }
}
