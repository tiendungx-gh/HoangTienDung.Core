using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HoangTienDung.Core.Entity.Model
{
    public class CacheModel
    {
        public CacheModel(string Key,object Vakue)
        {
            this.Key = Key;
            this.Value= Vakue;
        }
        public string Key { get; set; }
        public object Value { get; set; }
    }
}
