using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using XamarinWMS.Model;

namespace XamarinWMS.Data.Web_Service
{
    public class ProductManager
    {
        IRestService restService;

        public ProductManager(IRestService service)
        {
            restService = service;
        }

        public Task<List<ProductData>> GetTasksAsync()
        {
            return restService.RefreshProdDataAsync();
        }

        public Task SaveTaskAsync(ProductData prod, bool isNewProd = false)
        {
            return restService.SaveProdAsync(prod, isNewProd);
        }

        public Task DeleteTaskAsync(ProductData prod)
        {
            return restService.DeleteProdAsync(prod.ProdId);
        }
    }
}
