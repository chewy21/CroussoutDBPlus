using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CroussoutDBPlus
{
    public class Resources
    {
        public List<Resource> resourceList { get; set; }
}

    public class Resource
    {
        public long Id { get; set; }
        public string Name { get; set; }
        public long Quantity { get; set; }
        //public long SellPrice { get; private set; }


        public Resource(string name, long id) 
        {
            this.Name = name;
            this.Id = id;
            this.Quantity = 0;
        }
        public Resource(Item item) 
        {
            this.Id = item.Id;
            this.Name = item.Name;
            this.Quantity = 0;

        }
    }


}
