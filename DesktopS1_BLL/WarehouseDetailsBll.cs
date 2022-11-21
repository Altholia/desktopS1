using System.Collections.Generic;
using System.Threading.Tasks;
using DesktopS1_Helper;
using DesktopS1_Model.DisplayDto;
using DesktopS1_Model.Entities;
using static DesktopoS1_DAL.WarehouseDetailsDal;

namespace DesktopS1_BLL
{
    public class WarehouseDetailsBll:Bll
    {
        public static WarehouseDetailsBll InstanceBll => Singleton<WarehouseDetailsBll>.Instance;

        /// <summary>
        /// 获取所有的仓库信息
        /// </summary>
        /// <returns>返回查询到的信息</returns>
        public async Task<List<WarehouseDisplayDto>> GetWarehouseAsync() =>
            await InstanceDal.GetWarehouseAsync();

        /// <summary>
        /// 获取所有的仓库分布信息
        /// </summary>
        /// <param name="warehouseId"></param>
        /// <returns>返回查询到仓库分布信息</returns>
        public async Task<List<Zone>> GetZonesAsync(int warehouseId) =>
            await InstanceDal.GetZonesAsync(warehouseId);

        public async Task<List<PartDisplayDto>> GetParInformationByZoneId(int zoneId) =>
            await InstanceDal.GetParInformationByZoneId(zoneId);
    }
}