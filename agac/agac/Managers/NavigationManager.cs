using agac.Controls;
using agac.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace agac.Managers
{
    public class NavigationManager : BaseViewModel
    {
        PageControl _root;
        public PageControl root
        {
            private set { _root = value; }
            get
            {
                Count = pages.Count;
                return _root;
            }
        }

        List<PageControl> pages { set; get; }

        int _count;
        public int Count
        {
            set
            {
                _count = value;
                OnPropertyChanged("Count");
            }
            get { return pages.Count; }
        }

        public NavigationManager()
        {
            pages = new List<PageControl>();
        }

        public void SetRoot(PageControl page)
        {
            root = page;
        }

        public void Clear()
        {
            pages.Clear();
            Count = pages.Count;
        }

        public void Add(PageControl page)
        {
            pages.Add(page);
            Count = pages.Count;
        }

        public PageControl LastOrDefault()
        {
            return pages.LastOrDefault();
        }

        public bool Remove(PageControl page)
        {
            return pages.Remove(page);
        }
    }
}
