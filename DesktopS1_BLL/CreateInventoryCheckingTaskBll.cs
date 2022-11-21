using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DesktopS1_Helper;
using DesktopS1_Model.DisplayDto;
using DesktopS1_Model.Entities;
using static DesktopoS1_DAL.CreateInventoryCheckingTaskDal;

namespace DesktopS1_BLL
{
    public class CreateInventoryCheckingTaskBll:Bll
    {
        public static CreateInventoryCheckingTaskBll InstanceBll => 
            Singleton<CreateInventoryCheckingTaskBll>.Instance;

        /// <summary>
        /// 获取TaskType的Name属性值
        /// </summary>
        /// <returns>返回Name集合</returns>
        public async Task<List<string>> GetTaskTypeNameAsync() => 
            await InstanceDal.GetTaskTypeNameAsync();

        /// <summary>
        /// 获取用来填充Checked_TableLayoutPanel的数据
        /// </summary>
        /// <param name="warehouseName"></param>
        /// <returns>返回查询到的数据</returns>
        public async Task<IEnumerable<PartsToBeCheckedDisplayDto>> GetPartsToBeCheckedAsync(string warehouseName) =>
            await InstanceDal.GetPartsToBeCheckedAsync(warehouseName);

        /// <summary>
        /// 获取Warehouse的Id
        /// </summary>
        /// <param name="warehouseName"></param>
        /// <returns>返回ID</returns>
        public async Task<int> GetWarehouseIdAsync(string warehouseName) =>
            await InstanceDal.GetWarehouseIdAsync(warehouseName);

        /// <summary>
        /// 获取TaskType的Id
        /// </summary>
        /// <param name="taskTypeName"></param>
        /// <returns>返回ID</returns>
        public async Task<int> GetTaskTypeIdAsync(string taskTypeName) =>
            await InstanceDal.GetTaskTypeIdAsync(taskTypeName);

        /// <summary>
        /// 根据warehouseId和zoneName获取zoneId
        /// </summary>
        /// <param name="warehouseId">仓库ID</param>
        /// <param name="zoneNames"></param>
        /// <returns>返回查询到的zoneId</returns>
        public async Task<List<int>> GetZoneIdAsync(int warehouseId, List<string> zoneNames) =>
            await InstanceDal.GetZoneIdAsync(warehouseId, zoneNames);

        /// <summary>
        /// 根据warehouseId获取对应的zoneName集合
        /// </summary>
        /// <param name="warehouseId"></param>
        /// <returns>返回zoneId集合</returns>
        public async Task<List<string>> GetZoneIdsAsync(int warehouseId) =>
            await InstanceDal.GetZoneIdsAsync(warehouseId);

        /// <summary>
        /// 添加InventoryCheckingTask实体数据
        /// </summary>
        /// <param name="dto"></param>
        public void AddInventoryCheckingTask(InventoryCheckingTask dto) =>
            InstanceDal.AddInventoryCheckingTask(dto);

        public async Task<bool> AddTaskDetail(List<int> zoneIds,int taskId) =>
            await InstanceDal.AddTaskDetail(zoneIds,taskId);

        public async Task<bool> SaveChangeAsync() =>
            await InstanceDal.SaveChangeAsync();
    }
}
