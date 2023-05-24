using Avalonia.Controls;
using Avalonia.Media.Imaging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace agac.Models
{
    public class ToolbarModel
    {
        public Bitmap? icon { set; get; }
        public ICommand? command { set; get; }
    }
}
