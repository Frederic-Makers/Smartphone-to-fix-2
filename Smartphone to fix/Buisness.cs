using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Smartphone_to_fix
{
    class Buisness
    {
        public static ObservableCollection<ReparationPhone> clients { get; set; }
        public static WindowADD addWindown { get; set; }
        static Buisness()
        {
            clients = new ObservableCollection<ReparationPhone>();
            addWindown = new WindowADD();
        }
    }
}
