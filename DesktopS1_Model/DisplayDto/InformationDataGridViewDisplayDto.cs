using System.Runtime.CompilerServices;

namespace DesktopS1_Model.DisplayDto
{
    public class InformationDataGridViewDisplayDto
    {
        public int  Seq { get; set; }
        public string Zone { get; set; }
        public string Category { get; set; }
        public string PartName { get; set; }
        public string Unit { get; set; }
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
                        return Seq;
                    case 1:
                        return Zone;
                    case 2:
                        return Category;
                    case 3:
                        return PartName;
                    case 4:
                        return Unit;
                    case 5:
                        return Specification;
                    case 6:
                        return StockAmount;
                    case 7:
                        return CheckAmount;
                    default:
                        return null;
                }
            }
        }
    }
}