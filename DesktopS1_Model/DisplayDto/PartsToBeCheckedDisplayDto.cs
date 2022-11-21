using System;
using System.Runtime.CompilerServices;

namespace DesktopS1_Model.DisplayDto
{
    public class PartsToBeCheckedDisplayDto
    {
        public int Seq { get; set; }
        public string Zone { get; set; }
        public int PartId { get; set; }
        public string PartName { get; set; }
        public string Unit { get; set; }
        public string Specification { get; set; }
        public int StockAmount { get; set; }

        public object this[int index]
        {
            get
            {
                switch (index)
                {
                    case 0:
                        return Seq;
                    case 1:
                        return Zone;
                    case 2:
                        return PartId;
                    case 3:
                        return PartName;
                    case 4:
                        return Unit;
                    case 5:
                        return Specification;
                    case 6:
                        return StockAmount;
                    default:
                        throw new ArgumentException();
                }
            }
        }
    }
}