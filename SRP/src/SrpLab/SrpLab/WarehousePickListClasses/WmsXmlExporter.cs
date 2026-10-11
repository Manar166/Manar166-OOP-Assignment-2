using System;
using System.Collections.Generic;
using System.Text;

namespace SrpLab.WarehousePickListClasses
{
    public class WmsXmlExporter
    {
        StockAllocator stockAllocator;

        public WmsXmlExporter(StockAllocator stockAllocator)
        {
            this.stockAllocator = stockAllocator;
        }

        public string WmsXmlBatch(string batchId)
        {
            // Integration contract with WMS — third reason to change.
            var parts = stockAllocator.Allocate().Select(a => $"<line sku=\"{a.Sku}\" qty=\"{a.Allocated}\" />");
            return $"<batch id=\"{batchId}\">{string.Join("", parts)}</batch>";
        }
    }
}
