using System;
using System.Collections.Generic;
using System.Text;

namespace SrpLab.WarehousePickListClasses
{
    public class PickerScriptGenerator
    {
        private WarehousePickList warehousePickList;
        private StockAllocator stockAllocator;
        private PickingRoutePlanner pickingRoutePlanner;

        public PickerScriptGenerator(WarehousePickList warehousePickList, 
            StockAllocator stockAllocator,
            PickingRoutePlanner pickingRoutePlanner)
        {
            this.warehousePickList = warehousePickList;
            this.stockAllocator = stockAllocator;
            this.pickingRoutePlanner = pickingRoutePlanner;
        }

        public string PickerScript()
        {
            // UX wording for handheld devices — separate owners.
            var steps = pickingRoutePlanner.WalkingOrder()
                .Select((s, i) => $"{i + 1}. Go aisle {s.Aisle} bin {s.Bin}: pick {s.Qty} × {s.Sku}");
            var shortfalls = stockAllocator.Allocate().Where(a =>
            {
                var need = warehousePickList.Lines.First(l => l.Sku == a.Sku).QtyNeeded;
                return a.Allocated < need;
            });
            var warn = shortfalls.Any()
                ? "SHORTAGES: " + string.Join(", ", shortfalls.Select(s => s.Sku))
                : "SHORTAGES: none";
            return string.Join('\n', steps) + "\n" + warn;
        }
    }
}
