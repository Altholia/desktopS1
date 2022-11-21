using System;

namespace DesktopS1_Model.DisplayDto
{
    public class ReplenishedDisplayDto
    {
        public string PartName { get; set; }
        public string Specification { get; set; }
        public int? CheckAmount { get; set; }
        public int MinInventory { get; set; }

        public object this[int index]
        {
            get
            {
                switch (index)
                {
                    case 0:
                        return PartName;
                    case 1:
                        return Specification;
                    case 2:
                        return CheckAmount;
                    case 3:
                        return MinInventory;
                    default: throw new IndexOutOfRangeException(nameof(index));
                }
            }
        }
    }
}