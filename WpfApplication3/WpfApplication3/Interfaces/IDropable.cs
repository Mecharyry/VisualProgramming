using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WpfApplication3.Interfaces
{
    public interface IDropable
    {
        Type DataType
        {
            get;
        }

        void Drop(object obj);

        void Drop(object obj, double x, double y);
    }
}
