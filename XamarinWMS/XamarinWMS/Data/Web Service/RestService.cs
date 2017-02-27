using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Security;
using System.Text;
using System.Threading.Tasks;
using System.Web;
using XamarinWMS.Model;

namespace XamarinWMS.Data.Web_Service
{
    public class RestService : IRestService
    {
        HttpClient client;

        public List<DeliveryData> Deliveries { get; private set; }
        public List<DeliveryLineData> DeliveryLines { get; private set; }
        public List<OrderData> Orders { get; private set; }
        public List<PickData> Picks { get; private set; }

        public static string Username = "";
        public static string Password = "";

        public RestService()
        {
            var authData = string.Format("{0}:{1}", Username, Password);
            var authHeaderValue = Convert.ToBase64String(Encoding.UTF8.GetBytes(authData));

            client = new HttpClient();
            client.MaxResponseContentBufferSize = 256000;
            client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Basic", authHeaderValue);
        }

        public void ResetUserDetails()
        {
            Username = "";
            Password = "";
        }

        public async Task<List<DeliveryData>> RefreshDataAsync()
        {
            Deliveries = new List<DeliveryData>();

            var uri = new Uri(string.Format(Constants.RestUrlDel, string.Empty));

            try
            {
                var response = await client.GetAsync(uri);
                if (response.IsSuccessStatusCode)
                {
                    var content = await response.Content.ReadAsStringAsync();
                    Deliveries = JsonConvert.DeserializeObject<List<DeliveryData>>(content);
                }
            }
            catch (Exception ex)
            {
                Debug.WriteLine(@"				ERROR {0}", ex.Message);
            }

            return Deliveries;
        }

        public async Task SaveDeliveryAsync(DeliveryData del, bool isNewDel = false)
        {
            var uri = new Uri(string.Format(Constants.RestUrlDel, del.DeliveryId));

            try
            {
                var json = JsonConvert.SerializeObject(del);
                var content = new StringContent(json, Encoding.UTF8, "application/json");

                HttpResponseMessage response = null;
                if (isNewDel)
                {
                    response = await client.PostAsync(uri, content);
                }
                else
                {
                    response = await client.PutAsync(uri, content);
                }

                if (response.IsSuccessStatusCode)
                {
                    Debug.WriteLine(@"				Delivery successfully saved.");
                }

            }
            catch (Exception ex)
            {
                Debug.WriteLine(@"				ERROR {0}", ex.Message);
            }
        }

        public async Task DeleteDeliveryAsync(int id)
        {
            var uri = new Uri(string.Format(Constants.RestUrlDel, id));

            try
            {
                var response = await client.DeleteAsync(uri);

                if (response.IsSuccessStatusCode)
                {
                    Debug.WriteLine(@"				Delivery successfully deleted.");
                }

            }
            catch (Exception ex)
            {
                Debug.WriteLine(@"				ERROR {0}", ex.Message);
            }
        }

        /* Delivery Line REST Functions */

        public async Task<List<DeliveryLineData>> RefreshDelLineDataAsync()
        {
            DeliveryLines = new List<DeliveryLineData>();

            var uri = new Uri(string.Format(Constants.RestUrlDelLine, string.Empty));

            try
            {
                var response = await client.GetAsync(uri);
                if (response.IsSuccessStatusCode)
                {
                    var content = await response.Content.ReadAsStringAsync();
                    DeliveryLines = JsonConvert.DeserializeObject<List<DeliveryLineData>>(content);
                }
            }
            catch (Exception ex)
            {
                Debug.WriteLine(@"				ERROR {0}", ex.Message);
            }

            return DeliveryLines;
        }

        public async Task SaveDeliveryLineAsync(DeliveryLineData delLine, bool isNewDelLine = false)
        {
            var uri = new Uri(string.Format(Constants.RestUrlDelLine, delLine.DeliveryLineId));

            try
            {
                var json = JsonConvert.SerializeObject(delLine);
                var content = new StringContent(json, Encoding.UTF8, "application/json");

                HttpResponseMessage response = null;
                if (isNewDelLine)
                {
                    response = await client.PostAsync(uri, content);
                }
                else
                {
                    response = await client.PutAsync(uri, content);
                }

                if (response.IsSuccessStatusCode)
                {
                    Debug.WriteLine(@"				Delivery Line successfully saved.");
                }

            }
            catch (Exception ex)
            {
                Debug.WriteLine(@"				ERROR {0}", ex.Message);
            }
        }

        public async Task DeleteDeliveryLineAsync(int id)
        {
            var uri = new Uri(string.Format(Constants.RestUrlDelLine, id));

            try
            {
                var response = await client.DeleteAsync(uri);

                if (response.IsSuccessStatusCode)
                {
                    Debug.WriteLine(@"				Delivery Line successfully deleted.");
                }

            }
            catch (Exception ex)
            {
                Debug.WriteLine(@"				ERROR {0}", ex.Message);
            }
        }

        /* Order REST Functions */

        public async Task<List<OrderData>> RefreshOrderDataAsync()
        {
            Orders = new List<OrderData>();

            var uri = new Uri(string.Format(Constants.RestUrlOrder, string.Empty));

            try
            {
                var response = await client.GetAsync(uri);
                if (response.IsSuccessStatusCode)
                {
                    var content = await response.Content.ReadAsStringAsync();
                    Orders = JsonConvert.DeserializeObject<List<OrderData>>(content);
                }
            }
            catch (Exception ex)
            {
                Debug.WriteLine(@"				ERROR {0}", ex.Message);
            }

            return Orders;
        }

        public async Task SaveOrderAsync(OrderData order, bool isNewOrder = false)
        {
            var uri = new Uri(string.Format(Constants.RestUrlOrder, order.OrderId));

            try
            {
                var json = JsonConvert.SerializeObject(order);
                var content = new StringContent(json, Encoding.UTF8, "application/json");

                HttpResponseMessage response = null;
                if (isNewOrder)
                {
                    response = await client.PostAsync(uri, content);
                }
                else
                {
                    response = await client.PutAsync(uri, content);
                }

                if (response.IsSuccessStatusCode)
                {
                    Debug.WriteLine(@"				Order successfully saved.");
                }

            }
            catch (Exception ex)
            {
                Debug.WriteLine(@"				ERROR {0}", ex.Message);
            }
        }

        public async Task DeleteOrderAsync(int id)
        {
            var uri = new Uri(string.Format(Constants.RestUrlOrder, id));

            try
            {
                var response = await client.DeleteAsync(uri);

                if (response.IsSuccessStatusCode)
                {
                    Debug.WriteLine(@"				Order successfully deleted.");
                }

            }
            catch (Exception ex)
            {
                Debug.WriteLine(@"				ERROR {0}", ex.Message);
            }
        }

        /* Pick REST Functions */

        public async Task<List<PickData>> RefreshPicksAsync()
        {
            Picks = new List<PickData>();

            var uri = new Uri(string.Format(Constants.RestUrlPick, string.Empty));

            try
            {
                var response = await client.GetAsync(uri);
                if (response.IsSuccessStatusCode)
                {
                    var content = await response.Content.ReadAsStringAsync();
                    Picks = JsonConvert.DeserializeObject<List<PickData>>(content);
                }
            }
            catch (Exception ex)
            {
                Debug.WriteLine(@"				ERROR {0}", ex.Message);
            }

            return Picks;
        }

        public async Task SavePickAsync(PickData pick, bool isNewPick = false)
        {
            var uri = new Uri(string.Format(Constants.RestUrlPick, pick.PickId));

            try
            {
                var json = JsonConvert.SerializeObject(pick);
                var content = new StringContent(json, Encoding.UTF8, "application/json");

                HttpResponseMessage response = null;
                if (isNewPick)
                {
                    response = await client.PostAsync(uri, content);
                }
                else
                {
                    response = await client.PutAsync(uri, content);
                }

                if (response.IsSuccessStatusCode)
                {
                    Debug.WriteLine(@"				Pick successfully saved.");
                }

            }
            catch (Exception ex)
            {
                Debug.WriteLine(@"				ERROR {0}", ex.Message);
            }
        }

        public async Task DeletePickAsync(int id)
        {
            var uri = new Uri(string.Format(Constants.RestUrlPick, id));

            try
            {
                var response = await client.DeleteAsync(uri);

                if (response.IsSuccessStatusCode)
                {
                    Debug.WriteLine(@"				Pick successfully deleted.");
                }

            }
            catch (Exception ex)
            {
                Debug.WriteLine(@"				ERROR {0}", ex.Message);
            }
        }

        /* User REST Functions */

        public async Task<bool> SaveUserAsync(UserData user, bool isNewUser = false)
        {
            var uri = new Uri(string.Format(Constants.RestUrlUserRegister, user.ConfirmPassword));
            bool _respMsg = false;

            try
            {
                var json = JsonConvert.SerializeObject(user);
                var content = new StringContent(json, Encoding.UTF8, "application/json");

                HttpResponseMessage response = null;
                if (isNewUser)
                {
                    response = await client.PostAsync(uri, content);
                }
                else
                {
                    response = await client.PutAsync(uri, content);
                }

                if (response.IsSuccessStatusCode)
                {
                    Debug.WriteLine(@"				User successfully saved.");
                    _respMsg = true;
                }

            }
            catch (Exception ex)
            {
                Debug.WriteLine(@"				ERROR {0}", ex.Message);
            }
            return _respMsg;
        }

        public async Task<string> LoginUserAsync(string username, string password)
        {
            string _resp = "";

            var uri = new Uri(string.Format(Constants.RestUrlLogin));
            string str = "grant_type=password";
            str += "&username="+username;
            str += "&password="+password;
            try
            {
              //  var json = JsonConvert.SerializeObject(postString);
                var content = new StringContent(str, Encoding.UTF8, "application/x-www-form-urlencoded");

                HttpResponseMessage response = null;

                response = await client.PostAsync(uri, content);

                if (response.IsSuccessStatusCode)
                {

                    Debug.WriteLine(@"				Credentials are Correct.");

                    var tokenContent = await response.Content.ReadAsStringAsync();

                    TokenResponseModel tokenResponse = JsonConvert.DeserializeObject<TokenResponseModel>(tokenContent);

                    Username += tokenResponse.Username;
                    Password += tokenResponse.AccessToken;

                    return tokenResponse.AccessToken;
                }

            }
            catch (Exception ex)
            {
                Debug.WriteLine(@"				ERROR {0}", ex.Message);
                throw new SecurityException("Bad credentials", ex);
            }
            return _resp;
        }

        //public async Task LogOutTaskAsync()
        //{
        //    var uri = new Uri(string.Format(Constants.RestUrlLogOut));

        //    try
        //    {
        //        //var json = JsonConvert.SerializeObject(item);
        //        var content = new StringContent("", Encoding.UTF8, "application/json");

        //        HttpResponseMessage response = null;

        //        response = await client.PostAsync(uri, content);

        //        if (response.IsSuccessStatusCode)
        //        {
        //            Debug.WriteLine(@"				User successfully log out.");
        //        }

        //    }
        //    catch (Exception ex)
        //    {
        //        Debug.WriteLine(@"				ERROR {0}", ex.Message);
        //    }
        //}
    }
}
