using FileSort.Interface;
using FileSort.Service;
using TinyIoC;

namespace FileSort
{
    public static class Bootstrap
    {
        public static void Register()
        {
            TinyIoCContainer.Current.Register<IFileService>(new FileService());
            TinyIoCContainer.Current.Register<ISortService>(new SortService());
        }
    }
}
