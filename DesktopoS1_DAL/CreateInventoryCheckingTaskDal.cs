using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Threading.Tasks;
using DesktopS1_Helper;
using DesktopS1_Model.DisplayDto;
using DesktopS1_Model.Entities;

namespace DesktopoS1_DAL
{
    public class CreateInventoryCheckingTaskDal:Bll
    {
        private readonly S1Entities _context;

        public static CreateInventoryCheckingTaskDal InstanceDal =>
            Singleton<CreateInventoryCheckingTaskDal>.Instance;

        public CreateInventoryCheckingTaskDal()
        {
            _context=new S1Entities();
        }

        /// <summary>
        /// 获取TaskType的Name属性
        /// </summary>
        /// <returns>返回Name集合</returns>
        public async Task<List<string>> GetTaskTypeNameAsync() => await _context.TaskType
            .AsNoTracking()
            .Select(r => r.Name)
            .ToListAsync();

        /// <summary>
        /// 获取用来填充Checked_TableLayoutPanel的数据
        /// </summary>
        /// <param name="warehouseName"></param>
        /// <returns></returns>
        public async Task<IEnumerable<PartsToBeCheckedDisplayDto>> GetPartsToBeCheckedAsync(string warehouseName)
        {
            List<PartsToBeCheckedDisplayDto> dtos=new List<PartsToBeCheckedDisplayDto>();

            int warehouseId = await _context.Warehouse
                .Where(r => r.Name == warehouseName.Trim())
                .Select(r => r.Id)
                .FirstOrDefaultAsync();

            List<Zone> zones = await _context.Zone
                .Where(r => r.WarehouseId == warehouseId)
                .ToListAsync();

            int seq = 1;
            foreach (var zone in zones)
            {
                List<PartStorage> items = await _context.PartStorage
                    .Where(r => r.ZoneId == zone.Id)
                    .ToListAsync();
                if (!items.Any())
                    return null;

                foreach (var item in items)
                {
                    Part part = await _context.Part.FindAsync(item.PartId);
                    if (part == null)
                        continue;

                    PartsToBeCheckedDisplayDto dto = new PartsToBeCheckedDisplayDto
                    {
                        Seq = seq,
                        Zone = zone.Name,
                        PartId = part.Id,
                        PartName = part.Name,
                        Unit = part.Unit,
                        Specification = part.Specification,
                        StockAmount = item.Amount
                    };
                    seq++;
                    dtos.Add(dto);
                }
            }

            return dtos.OrderBy(r => r.Zone).ThenBy(r => r.PartName);
        }

        /// <summary>
        /// 获取Warehouse的Id
        /// </summary>
        /// <param name="warehouseName"></param>
        /// <returns>返回ID</returns>
        public async Task<int> GetWarehouseIdAsync(string warehouseName) =>
            await _context.Warehouse
                .Where(r => r.Name == warehouseName)
                .Select(r => r.Id)
                .FirstOrDefaultAsync();

        /// <summary>
        /// 根据TaskTypeName获取ID
        /// </summary>
        /// <param name="taskTypeName"></param>
        /// <returns>返回查询到的ID</returns>
        public async Task<int> GetTaskTypeIdAsync(string taskTypeName) =>
            await _context.TaskType
                .Where(r => r.Name == taskTypeName)
                .Select(r => r.Id)
                .FirstOrDefaultAsync();

        /// <summary>
        /// 根据warehouseId和zoneName获取zoneId
        /// </summary>
        /// <param name="warehouseId">仓库ID</param>
        /// <param name="zoneNames"></param>
        /// <returns>返回查询到的zoneId</returns>
        public async Task<List<int>> GetZoneIdAsync(int warehouseId, List<string> zoneNames) =>
            await _context.Zone
                .Where(r => r.WarehouseId == warehouseId && zoneNames.Contains(r.Name))
                .Select(r => r.Id)
                .ToListAsync();

        /// <summary>
        /// 根据warehouseId获取对应的所有的zoneName
        /// </summary>
        /// <param name="warehouseId"></param>
        /// <returns>返回zoneId集合</returns>
        public async Task<List<string>> GetZoneIdsAsync(int warehouseId) =>
            await _context.Zone
                .Where(r => r.WarehouseId == warehouseId)
                .Select(r => r.Name)
                .ToListAsync();

        /// <summary>
        /// 添加InventoryCheckingTask
        /// </summary>
        /// <param name="dto"></param>
        public void AddInventoryCheckingTask(InventoryCheckingTask dto) =>
            _context.InventoryCheckingTask.Add(dto);

        /// <summary>
        /// 根据zoneIds和taskId添加TaskDetail实体到数据库中
        /// </summary>
        /// <param name="zoneIds">仓库分区ID</param>
        /// <param name="taskId">任务ID</param>
        public async Task<bool> AddTaskDetail(List<int> zoneIds,int taskId)
        {
            S1Entities context = new S1Entities();

            List<TaskDetail> taskDetails = new List<TaskDetail>();

            List<PartStorage> partStorages = await context.PartStorage
                .Where(r => zoneIds.Contains(r.ZoneId))
                .ToListAsync();

            foreach (var partStorage in partStorages)
            {
                TaskDetail taskDetail = new TaskDetail
                {
                    TaskId = taskId,
                    PartId = partStorage.PartId,
                    StockAmount = partStorage.Amount,
                    CheckAmount = null,
                    IsChecked = 0
                };

                taskDetails.Add(taskDetail);
            }

            context.TaskDetail.AddRange(taskDetails);

            return await context.SaveChangesAsync() >= 0;
        }

        /// <summary>
        /// 保存更改
        /// </summary>
        /// <returns></returns>
        public async Task<bool> SaveChangeAsync() =>
            await _context.SaveChangesAsync() >= 0;
    }
}