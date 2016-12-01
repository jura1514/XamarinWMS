using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;
using XamarinWMS.Model;

namespace XamarinWMS.Data.Web_Service
{
    public class RestService : IRestService
    {
        HttpClient client;

        public List<DeliveryData> Deliveries { get; private set; }
        public List<DeliveryLineData> DeliveryLines { get; private set; }
        public List<OrderData> Orders { get; private set; }

        public RestService()
        {
            var authData = string.Format("{0}:{1}", Constants.Username, Constants.Password);
            var authHeaderValue = Convert.ToBase64String(Encoding.UTF8.GetBytes(authData));

            client = new HttpClient();
            client.MaxResponseContentBufferSize = 256000;
            client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Basic", authHeaderValue);
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
    }
}
