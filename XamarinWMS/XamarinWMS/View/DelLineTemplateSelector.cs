using Xamarin.Forms;
using XamarinWMS.Model;

namespace XamarinWMS.View
{
    class DelLineTemplateSelector : DataTemplateSelector
    {
        public DataTemplate ValidTemplate { get; set; }

        public DataTemplate InvalidTemplate { get; set; }

        protected override DataTemplate OnSelectTemplate(object item, BindableObject container)
        {
            return ((DeliveryLineData)item).isUsedForStock == false ? InvalidTemplate : ValidTemplate;
        }
    }
}
