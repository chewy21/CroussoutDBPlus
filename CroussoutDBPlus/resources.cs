using Newtonsoft.Json;
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

        public Resources() 
        {
            this.resourceList = new List<Resource>();
        }
        public void ResetAllQuantities()
        {
            foreach (var resource in resourceList)
            {
                resource.Quantity = 0;
            }
        }
    }

    public class Resource
    {
        public long Id { get; set; }
        public string Name { get; set; }
        public long Quantity { get; set; }
        //public long SellPrice { get; private set; }

        [JsonConstructor]
        public Resource(long id, string name, long quantity)
        {
            Id = id;
            Name = name;
            Quantity = 0;
        }

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
