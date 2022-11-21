using System;

namespace DesktopS1_Model.DisplayDto
{
    public class CheckExceptionDisplayDto
    {
        public string PartName { get; set; }
        public string Specification { get; set; }
        public int StockAmount { get; set; }
        public int? CheckAmount { get; set; }

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
                        return StockAmount;
                    case 3:
                        return CheckAmount;
                    default: throw new IndexOutOfRangeException(nameof(index));
                }
            }
        }
    }
}