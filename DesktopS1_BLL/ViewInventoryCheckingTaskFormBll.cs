using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DesktopS1_Helper;
using DesktopS1_Model.DisplayDto;
using DesktopS1_Model.Entities;
using static DesktopoS1_DAL.ViewInventoryCheckingTaskFormDal;

namespace DesktopS1_BLL
{
    public class ViewInventoryCheckingTaskFormBll:Bll
    {
        public static ViewInventoryCheckingTaskFormBll InstanceBll =>
            Singleton<ViewInventoryCheckingTaskFormBll>.Instance;

        /// <summary>
        /// 根据StaffId获取该员工管理的仓库
        /// </summary>
        /// <param name="staffId"></param>
        /// <returns>返回仓库名称</returns>
        public async Task<IEnumerable<string>> GetWarehouseByStaffId(int staffId) =>
            await InstanceDal.GetWarehouseByStaffId(staffId);

        /// <summary>
        /// 获取所有的TaskStatus的Name属性
        /// </summary>
        /// <returns>返回Name集合</returns>
        public async Task<IEnumerable<string>> GetTaskStatusNames() =>
            await InstanceDal.GetTaskStatusNames();

        /// <summary>
        /// 获取InventoryCheckingTask
        /// </summary>
        /// <param name="parameter"></param>
        /// <returns></returns>
        /// <exception cref="ArgumentNullException"></exception>
        public async Task<List<InventoryCheckingTaskDisplayDto>> GetInventoryCheckingTaskFromSearchCondition(
            SearchParameter parameter)
        {
            if (parameter == null)
                throw new ArgumentNullException(nameof(parameter));

            IEnumerable<InventoryCheckingTask> entities =
                await InstanceDal.GetInventoryCheckingTaskFromSearchCondition(parameter);

            if (!entities.Any())
                return null;

            int seq = 0;
            List<InventoryCheckingTaskDisplayDto> dtos=new List<InventoryCheckingTaskDisplayDto>();

            foreach (var entity in entities)
            {
                InventoryCheckingTaskDisplayDto dto = new InventoryCheckingTaskDisplayDto
                {
                    Seq = seq,
                    WarehouseName = await InstanceDal.GetWarehouseNameByIdAsync(entity.WarehouseId),
                    InventoryCheckingTaskName = entity.TaskName.Trim(),
                    TaskType = await InstanceDal.GetTaskTypeNameByIdAsync(entity.TaskTypeId),
                    CreateTime = entity.CreateTime,
                    StartDate = entity.StartDate,
                    FinishDate = entity.FinishDate,
                    Status = await InstanceDal.GetTaskStatusNameByIdAsync(entity.StatusId)
                };
                seq++;
                dtos.Add(dto);
            }

            return dtos;
        }

        public async Task UpdateInventoryCheckingTaskStatus(string name,StatusEnum status, DateTime finishDateTime = default) =>
            await InstanceDal.UpdateInventoryCheckingTaskStatus(name,status,finishDateTime);

    }
}