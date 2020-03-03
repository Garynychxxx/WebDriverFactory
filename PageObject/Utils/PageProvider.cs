using System;

namespace PageObject.Utils
{
    public class PageProvider<T> where T : class
    {
        private T _page;
        public T GetPage() => _page ?? (_page = Activator.CreateInstance<T>());
    }
}
