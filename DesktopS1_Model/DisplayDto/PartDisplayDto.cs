using System;
using System.Data.Entity.Migrations.Model;

namespace DesktopS1_Model.DisplayDto
{
    public class PartDisplayDto
    {
        public string PartName { get; set; }
        public string Category { get; set; }
        public string Specification { get; set; }
        public int Amount { get; set; }
        public int MinInventory { get; set; }

        public object this[int id]
        {
            get
            {
                switch (id)
                {
                    case 0:
                        return PartName;
                    case 1:
                        return Category;
                    case 2:
                        return Specification;
                    case 3:
                        return Amount;
                    case 4:
                        return MinInventory;
                    default:
                        return null;
                }
            }
        }
    }
}