using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Yad2Project.Services
{
        public interface IDataService<T>
        {
            List<T> DataList { get; set; }
            List<T> InitializeData();
            T GetItemById(int? id);
            void AddItem(T item);
        }

}
