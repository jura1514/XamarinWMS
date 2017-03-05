using System.IO;
using Windows.Storage;
using Xamarin.Forms;
using XamarinWMS.WinPhone;

[assembly: Dependency(typeof(FileHelper))]
namespace XamarinWMS.WinPhone
{
    public class FileHelper : IFileHelper
    {
        public string GetLocalFilePath(string filename)
        {
            return Path.Combine(ApplicationData.Current.LocalFolder.Path, filename);
        }
    }
}
