﻿using Newtonsoft.Json;
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
        public List<LocationData> Locations { get; private set; }
        public List<ProductData> Products { get; private set; }

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
            string delId = del.DeliveryId.ToString();
            var uri = new Uri(string.Format(Constants.RestUrlDel, del.DeliveryId));

            if (!isNewDel)
            {
                Constants.PutDeleteRestUrlDel += delId;
                uri = new Uri(string.Format(Constants.PutDeleteRestUrlDel));
            }

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

            if (!isNewDel)
            {
                Constants.PutDeleteRestUrlDel = Constants.PutDeleteRestUrlDel.Replace(delId, "");
            }
        }

        public async Task DeleteDeliveryAsync(int id)
        {
            string delId = id.ToString();
            Constants.PutDeleteRestUrlDel += delId;
            var uri = new Uri(string.Format(Constants.PutDeleteRestUrlDel));

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

            Constants.PutDeleteRestUrlDel = Constants.PutDeleteRestUrlDel.Replace(delId, "");
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
            string delLineId = delLine.DeliveryLineId.ToString();

            if (!isNewDelLine)
            {
                Constants.PutDeleteRestUrlDelLine += delLineId;
                uri = new Uri(string.Format(Constants.PutDeleteRestUrlDelLine));
            }

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

            if (!isNewDelLine)
            {
                Constants.PutDeleteRestUrlDelLine = Constants.PutDeleteRestUrlDelLine.Replace(delLineId, "");
            }
        }

        public async Task DeleteDeliveryLineAsync(int id)
        {
            string delLineId = id.ToString();
            Constants.PutDeleteRestUrlDelLine += delLineId;

            var uri = new Uri(string.Format(Constants.PutDeleteRestUrlDelLine));

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

            Constants.PutDeleteRestUrlDelLine = Constants.PutDeleteRestUrlDelLine.Replace(delLineId, "");
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

            string orderId = order.OrderId.ToString();

            if (!isNewOrder)
            {
                Constants.PutDeleteRestUrlOrder += orderId;
                uri = new Uri(string.Format(Constants.PutDeleteRestUrlOrder));
            }

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

            if (!isNewOrder)
            {
                Constants.PutDeleteRestUrlOrder = Constants.PutDeleteRestUrlOrder.Replace(orderId, "");
            }
        }

        public async Task DeleteOrderAsync(int id)
        {
            string orderId = id.ToString();
            Constants.PutDeleteRestUrlOrder += orderId;

            var uri = new Uri(string.Format(Constants.PutDeleteRestUrlOrder));

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

            Constants.PutDeleteRestUrlOrder = Constants.PutDeleteRestUrlOrder.Replace(orderId, "");
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

            string pickId = pick.PickId.ToString();

            if (!isNewPick)
            {
                Constants.PutDeleteRestUrlPick += pickId;
                uri = new Uri(string.Format(Constants.PutDeleteRestUrlPick));
            }

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
                else
                {
                    Debug.WriteLine(@"				Pick is not saved.");
                }

            }
            catch (Exception ex)
            {
                Debug.WriteLine(@"				ERROR {0}", ex.Message);
            }

            if (!isNewPick)
            {
                Constants.PutDeleteRestUrlPick = Constants.PutDeleteRestUrlPick.Replace(pickId, "");
            }
        }

        public async Task DeletePickAsync(int id)
        {
            string pickId = id.ToString();
            Constants.PutDeleteRestUrlPick += pickId;

            var uri = new Uri(string.Format(Constants.PutDeleteRestUrlPick));

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

            Constants.PutDeleteRestUrlPick = Constants.PutDeleteRestUrlPick.Replace(pickId, "");
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

        /* Locations REST Functions */

        public async Task<List<LocationData>> RefreshLocDataAsync()
        {
            Locations = new List<LocationData>();

            var uri = new Uri(string.Format(Constants.RestUrlLoc, string.Empty));

            try
            {
                var response = await client.GetAsync(uri);
                if (response.IsSuccessStatusCode)
                {
                    var content = await response.Content.ReadAsStringAsync();
                    Locations = JsonConvert.DeserializeObject<List<LocationData>>(content);
                }
            }
            catch (Exception ex)
            {
                Debug.WriteLine(@"				ERROR {0}", ex.Message);
            }

            return Locations;
        }

        public async Task SaveLocationAsync(LocationData Loc, bool isNewLoc = false)
        {
            var uri = new Uri(string.Format(Constants.RestUrlLoc, Loc.LocationId));

            if (!isNewLoc)
            {
                Constants.PutDeleteRestUrlLoc += Loc.LocationId;
                uri = new Uri(string.Format(Constants.PutDeleteRestUrlLoc));
            }

            try
            {
                var json = JsonConvert.SerializeObject(Loc);
                var content = new StringContent(json, Encoding.UTF8, "application/json");

                HttpResponseMessage response = null;
                if (isNewLoc)
                {
                    response = await client.PostAsync(uri, content);
                }
                else
                {
                    response = await client.PutAsync(uri, content);
                }

                if (response.IsSuccessStatusCode)
                {
                    Debug.WriteLine(@"				Location successfully saved.");
                }

            }
            catch (Exception ex)
            {
                Debug.WriteLine(@"				ERROR {0}", ex.Message);
            }

            if (!isNewLoc)
            {
                Constants.PutDeleteRestUrlLoc = Constants.PutDeleteRestUrlLoc.Replace(Loc.LocationId, "");
            }
        }

        public async Task DeleteLocationAsync(string Locid)
        {
            Constants.PutDeleteRestUrlLoc += Locid;

            var uri = new Uri(string.Format(Constants.PutDeleteRestUrlLoc));

            try
            {
                var response = await client.DeleteAsync(uri);

                if (response.IsSuccessStatusCode)
                {
                    Debug.WriteLine(@"				Location successfully deleted.");
                }

            }
            catch (Exception ex)
            {
                Debug.WriteLine(@"				ERROR {0}", ex.Message);
            }

            Constants.PutDeleteRestUrlLoc = Constants.PutDeleteRestUrlLoc.Replace(Locid, "");
        }

        /* Product REST Functions */

        public async Task<List<ProductData>> RefreshProdDataAsync()
        {
            Products = new List<ProductData>();

            var uri = new Uri(string.Format(Constants.RestUrlProd, string.Empty));

            try
            {
                var response = await client.GetAsync(uri);
                if (response.IsSuccessStatusCode)
                {
                    var content = await response.Content.ReadAsStringAsync();
                    Products = JsonConvert.DeserializeObject<List<ProductData>>(content);
                }
            }
            catch (Exception ex)
            {
                Debug.WriteLine(@"				ERROR {0}", ex.Message);
            }

            return Products;
        }

        public async Task SaveProdAsync(ProductData Prod, bool isNewProd = false)
        {
            var uri = new Uri(string.Format(Constants.RestUrlProd, Prod.ProdId));

            if (!isNewProd)
            {
                Constants.PutDeleteRestUrlProd += Prod.ProdId;
                uri = new Uri(string.Format(Constants.PutDeleteRestUrlProd));
            }

            try
            {
                var json = JsonConvert.SerializeObject(Prod);
                var content = new StringContent(json, Encoding.UTF8, "application/json");

                HttpResponseMessage response = null;
                if (isNewProd)
                {
                    response = await client.PostAsync(uri, content);
                }
                else
                {
                    response = await client.PutAsync(uri, content);
                }

                if (response.IsSuccessStatusCode)
                {
                    Debug.WriteLine(@"				Product successfully saved.");
                }

            }
            catch (Exception ex)
            {
                Debug.WriteLine(@"				ERROR {0}", ex.Message);
            }

            if (!isNewProd)
            {
                Constants.PutDeleteRestUrlProd = Constants.PutDeleteRestUrlProd.Replace(Prod.ProdId, "");
            }
        }

        public async Task DeleteProdAsync(string ProdId)
        {
            Constants.PutDeleteRestUrlProd += ProdId;

            var uri = new Uri(string.Format(Constants.PutDeleteRestUrlProd));

            try
            {
                var response = await client.DeleteAsync(uri);

                if (response.IsSuccessStatusCode)
                {
                    Debug.WriteLine(@"				Product successfully deleted.");
                }

            }
            catch (Exception ex)
            {
                Debug.WriteLine(@"				ERROR {0}", ex.Message);
            }

            Constants.PutDeleteRestUrlProd = Constants.PutDeleteRestUrlProd.Replace(ProdId, "");
        }
    }
}
