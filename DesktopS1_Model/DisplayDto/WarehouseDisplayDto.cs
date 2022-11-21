using System;

namespace DesktopS1_Model.DisplayDto
{
    public class WarehouseDisplayDto
    {
        public int Id { get; set; }
        public string Name { get; set; }//仓库名称
        public int Area { get; set; }//仓库面积
        public string WarehouseKeeper { get; set; }//仓库管理员姓名
        public string Phone { get; set; }//仓库电话
        public string Address { get; set; }//仓库地址
        public DateTime LastCheckingDate { get; set; }//上次盘点时间
    }
}