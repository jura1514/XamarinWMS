using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using XamarinWMS.Model;

namespace XamarinWMS.Data.Web_Service
{
    public class LocationManager
    {
        IRestService restService;

        public LocationManager(IRestService service)
        {
            restService = service;
        }

        public Task<List<LocationData>> GetTasksAsync()
        {
            return restService.RefreshLocDataAsync();
        }

        public Task SaveTaskAsync(LocationData loc, bool isNewLoc = false)
        {
            return restService.SaveLocationAsync(loc, isNewLoc);
        }

        public Task DeleteTaskAsync(LocationData loc)
        {
            return restService.DeleteLocationAsync(loc.LocationId);
        }
    }
}
