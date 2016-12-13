using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using XamarinWMS.Model;

namespace XamarinWMS.Data.Web_Service
{
    public class UserManager
    {
        IRestService restService;

        public UserManager(IRestService service)
        {
            restService = service;
        }

        //public Task<List<UserData>> GetTasksAsync()
        //{
        //    return restService.RefreshUsersAsync();
        //}

        public Task<bool> SaveTaskAsync(UserData user, bool isNewUser )
        {
            return restService.SaveUserAsync(user, isNewUser);
        }

        //public Task DeleteTaskAsync(UserData user)
        //{
        //    return restService.DeleteUserAsync(user.UserName);
        //}

    }
}
