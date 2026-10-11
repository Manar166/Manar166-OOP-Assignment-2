using System;
using System.Collections.Generic;
using System.Text;

namespace SrpLab.WarehousePickListClasses
{
  
    public class PickingRoutePlanner
    {
        private WarehousePickList warehousePickList;

        public PickingRoutePlanner(WarehousePickList warehousePickList)
        {
            this.warehousePickList = warehousePickList;
        }

        public IReadOnlyList<(string Aisle, int Bin, string Sku, int Qty)> WalkingOrder()
        {
            // Path heuristic will change with warehouse layout tech.
            return warehousePickList.Lines
                .OrderBy(l => l.Aisle)
                .ThenBy(l => l.Bin)
                .Select(l => (l.Aisle, l.Bin, l.Sku, Math.Min(l.QtyNeeded, l.QtyOnHand)))
                .Where(x => x.Item4 > 0)
                .ToList();
        }
    }
}
