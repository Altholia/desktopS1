using System;

namespace DesktopS1_Model.DisplayDto
{
    public class InventoryCheckingTaskDisplayDto
    {
        public int Seq { get; set; }
        public string WarehouseName { get; set; }
        public string InventoryCheckingTaskName { get; set; }
        public string TaskType { get; set; }
        public DateTime CreateTime { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime? FinishDate { get; set; }
        public string Status { get; set; }

        public object this[int index]
        {
            get
            {
                switch (index)
                {
                    case 0:
                        return Seq;
                    case 1:
                        return WarehouseName;
                    case 2:
                        return InventoryCheckingTaskName;
                    case 3:
                        return TaskType;
                    case 4:
                        return CreateTime;
                    case 5:
                        return StartDate;
                    case 6:
                        return FinishDate;
                    case 7:
                        return Status;
                    default: return null;
                }
            }
        }
    }
}