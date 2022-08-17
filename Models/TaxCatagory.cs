using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;

namespace OrdersOrganiser.Models
{
    [JsonConverter(typeof(StringEnumConverter))]
    public enum TaxCatagory
    {
        Standard = 0,
        Reduced = 1,
        Zero = 2
    }
}
