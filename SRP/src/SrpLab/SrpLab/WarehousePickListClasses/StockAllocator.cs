using System;
using System.Collections.Generic;
using System.Text;

namespace SrpLab.WarehousePickListClasses
{
    public class StockAllocator
    {
        private readonly WarehousePickList warehousePickList;

        public StockAllocator(WarehousePickList warehousePickList)
        {
            this.warehousePickList = warehousePickList;
        }

        public IReadOnlyList<(string Sku, int Allocated)> Allocate()
        {
            // Allocation/backorder policy ≠ walking path ≠ human instructions.
            var result = new List<(string, int)>();
            foreach (var line in warehousePickList.Lines)
            {
                var alloc = Math.Min(line.QtyNeeded, line.QtyOnHand);
                result.Add((line.Sku, alloc));
            }
            return result;
        }
    }
}
