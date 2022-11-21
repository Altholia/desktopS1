using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Threading.Tasks;
using DesktopS1_Helper;
using static DesktopS1_Model.DisplayDto.UserDisplayDto;
using DesktopS1_Model.Entities;

namespace DesktopoS1_DAL
{
    public class ViewInventoryCheckingTaskFormDal:Bll
    {
        public static ViewInventoryCheckingTaskFormDal InstanceDal =>
            Singleton<ViewInventoryCheckingTaskFormDal>.Instance;

        private readonly S1Entities _context;
        public ViewInventoryCheckingTaskFormDal()
        {
            _context=new S1Entities();
        }

        /// <summary>
        /// 通过StaffID获取所有的仓库
        /// </summary>
        /// <param name="staffId"></param>
        /// <returns>返回该StaffID下的所有仓库</returns>
        public async Task<IEnumerable<string>> GetWarehouseByStaffId(int staffId) =>
            await _context.Warehouse.Where(r => r.Manager == staffId)
                .Select(r => r.Name)
                .ToListAsync();

        /// <summary>
        /// 获取所有的TaskStatus的Name属性
        /// </summary>
        /// <returns>返回Name集合</returns>
        public async Task<IEnumerable<string>> GetTaskStatusNames() =>
            await _context.TaskStatus.Select(r => r.Name)
                .ToListAsync();

        /// <summary>
        /// 通过WarehouseId获取指定的Name属性
        /// </summary>
        /// <param name="warehouseId"></param>
        /// <returns>返回Name属性</returns>
        public async Task<string> GetWarehouseNameByIdAsync(int warehouseId) =>
            await _context.Warehouse
                .Where(r => r.Id == warehouseId)
                .Select(r => r.Name)
                .FirstOrDefaultAsync();

        /// <summary>
        /// 根据TaskTypeId获取对应的Name属性
        /// </summary>
        /// <param name="taskTypeId"></param>
        /// <returns>返回Name</returns>
        public async Task<string> GetTaskTypeNameByIdAsync(int taskTypeId) =>
            await _context.TaskType
                .Where(r => r.Id == taskTypeId)
                .Select(r => r.Name)
                .FirstOrDefaultAsync();

        /// <summary>
        /// 通过TaskStatusId获取对应的Name属性
        /// </summary>
        /// <param name="taskStatusId"></param>
        /// <returns>返回Name属性</returns>
        public async Task<string> GetTaskStatusNameByIdAsync(int taskStatusId) =>
            await _context.TaskStatus
                .Where(r => r.Id == taskStatusId)
                .Select(r => r.Name)
                .FirstOrDefaultAsync();

        /// <summary>
        /// 查询ViewInventoryCheckingTask数据
        /// </summary>
        /// <param name="parameter"></param>
        /// <returns>返回集合</returns>
        /// <exception cref="ArgumentNullException"></exception>
        public async Task<IEnumerable<InventoryCheckingTask>> GetInventoryCheckingTaskFromSearchCondition(
            SearchParameter parameter)
        {
            if (parameter == null)
                throw new ArgumentNullException(nameof(parameter));

            IQueryable<InventoryCheckingTask> linq=_context.InventoryCheckingTask as IQueryable<InventoryCheckingTask>;

            if (parameter.WarehouseString.ToLower() != "all")
            {
                int warehouseId = await _context.Warehouse
                    .Where(r => r.Name.Equals(parameter.WarehouseString))
                    .Select(r => r.Id)
                    .FirstOrDefaultAsync();

                linq = linq.Where(r => r.WarehouseId == warehouseId);
            }
            else if (parameter.WarehouseString.ToLower() == "all")
            {
                IEnumerable<int> warehouseIds = await _context.Warehouse
                    .Where(r => InstanceUser.UserId == r.Manager)
                    .Select(r=>r.Id)
                    .ToListAsync();

                linq = linq.Where(r => warehouseIds.Contains(r.WarehouseId));

            }

            if (parameter.StatusString.ToLower() != "all")
            {
                int statusId = await _context.TaskStatus
                    .Where(r => r.Name.Equals(parameter.StatusString))
                    .Select(r => r.Id)
                    .FirstOrDefaultAsync();

                linq = linq.Where(r => r.StatusId == statusId);
            }
            else if (parameter.StatusString.ToLower() == "all")
            {
                IEnumerable<int> taskStatusIds = await _context.TaskStatus
                    .Select(r => r.Id)
                    .ToListAsync();

                linq = linq.Where(r => taskStatusIds.Contains(r.StatusId));
            }

            if (parameter.TaskTypeString.ToLower() != "all")
            {
                int taskTypeId = await _context.TaskType
                    .Where(r => r.Name.Equals(parameter.TaskTypeString))
                    .Select(r => r.Id)
                    .FirstOrDefaultAsync();

                linq = linq.Where(r => r.TaskTypeId == taskTypeId);
            }
            else if (parameter.TaskTypeString.ToLower() == "all")
            {
                IEnumerable<int> taskTypeIds = await _context.TaskType
                    .Select(r => r.Id)
                    .ToListAsync();

                linq = linq.Where(r => taskTypeIds.Contains(r.TaskTypeId));
            }

            return await linq.ToListAsync();
        }

        public async Task UpdateInventoryCheckingTaskStatus(string name,StatusEnum status,DateTime finishDateTime=default)
        {
            InventoryCheckingTask entity =  await _context.InventoryCheckingTask
                .FirstOrDefaultAsync(r => r.TaskName == name);

            if (entity == null)
                return;

            entity.StatusId = (int)status;
            if(status.ToString().Equals("Finished"))
                entity.FinishDate=finishDateTime;

            await _context.SaveChangesAsync();
        }
    }
}