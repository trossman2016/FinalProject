using Microsoft.VisualStudio.TestTools.UnitTesting;
using FinalProject;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FinalProject.Tests
{
    [TestClass()]
    public class ItemsTests
    {
        public static List<ItemData> Items = new List<ItemData>();
        public ItemData item = new ItemData();
        public ItemData item2 = new ItemData();

        [TestMethod()]
        public void ItemsTest()
        {
            item.ItemNumber = "1";
            item.Description = "Pencil";
            item.QtyOnHand = 50;
            item.RetailPrice = .75;
            item.WholesalePrice = .25;
            item.InventoryValue = item.RetailPrice * item.QtyOnHand;

            item2.ItemNumber = "2";
            item2.Description = "Pen";
            item2.QtyOnHand = 50;
            item2.RetailPrice = 1.25;
            item2.WholesalePrice = .75;
            item2.InventoryValue = item2.RetailPrice * item2.QtyOnHand;

            Items.Add(item);
            Items.Add(item2);

            Assert.AreEqual(Items[0].ItemNumber, item.ItemNumber);
        }

        [TestMethod()]
        public void RemoveTest()
        {
            ItemsTest();

            Items.RemoveAt(0);
            Assert.AreEqual(Items[0].ItemNumber, "2");
        }
    }
}