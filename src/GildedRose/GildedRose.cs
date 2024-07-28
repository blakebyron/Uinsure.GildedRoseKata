using System.Collections.Generic;

namespace GildedRoseKata
{
    public class GildedRose
    {
        IList<Item> Items;
        private ItemUpdateService svcUpdateQuality;

        public GildedRose(IList<Item> Items)
        {
            svcUpdateQuality = new ItemUpdateService();
            this.Items = Items;
        }

        public void UpdateQuality()
        {
            foreach (var item in Items)
            {
                UpdateItem(item);
            }
        }

        private void UpdateItem(Item item)
        {
            var updateService = svcUpdateQuality.GetItemUpdateService(item.Name);
            if (updateService != null)
            {
                updateService.UpdateSellin(item);
                updateService.UpdateQuality(item);
                return;
            }
        }
    }
}
