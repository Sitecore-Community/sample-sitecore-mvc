using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MVC.Data.Models
{
    public class FacetValue
    {
        public FacetValue(string facetName, string facetTemplateId, int facetCount)
        {
            Name = facetName;
            TemplateId = facetTemplateId;
            Count = facetCount;
        }

        public string Name { get; set; }
        public string TemplateId { get; set; }
        public int Count { get; set; }
    }
}
