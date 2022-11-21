using System;
using System.Collections;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Threading.Tasks;
using DesktopS1_Helper;
using DesktopS1_Model.DisplayDto;
using DesktopS1_Model.Entities;

namespace DesktopoS1_DAL
{
    public class InputInventoryCheckingResultFormDal:Bll
    {
        private readonly S1Entities _context;

        public static InputInventoryCheckingResultFormDal InstanceDal =>
            Singleton<InputInventoryCheckingResultFormDal>.Instance;
        public InputInventoryCheckingResultFormDal()
        {
            _context = new S1Entities();
        }

        public async Task<int> GetTaskIdByTaskNameAsync(string taskName) =>
            await _context.InventoryCheckingTask
                .Where(r => r.TaskName == taskName)
                .Select(r => r.Id)
                .FirstOrDefaultAsync();

        /// <summary>
        /// 为Information_DataGridView数据网格获取填充内容
        /// </summary>
        /// <param name="warehouseName">仓库名称</param>
        /// <param name="taskId">任务ID</param>
        /// <returns></returns>
        public async Task<IEnumerable<InformationDataGridViewDisplayDto>> GetInformationDataGridViewDtoAsync(
            string warehouseName,
            int taskId)
        {
            List<InformationDataGridViewDisplayDto> dtos = new List<InformationDataGridViewDisplayDto>();
            
            int warehouseId = await _context.Warehouse
                .Where(r => r.Name == warehouseName)
                .Select(r => r.Id)
                .FirstOrDefaultAsync();

            List<Zone> zones = await _context.Zone
                .Where(r => r.WarehouseId == warehouseId)
                .ToListAsync();

            List<PartStorage> partStorages = new List<PartStorage>();
            foreach (var zone in zones)
            {
                List<PartStorage> dto = await _context.PartStorage
                    .Where(r => r.ZoneId == zone.Id)
                    .ToListAsync();

                partStorages.AddRange(dto);
            }

            int seq = 0;
            foreach (var partStorage in partStorages)
            {
                int categoryId = await _context.Part
                    .Where(r => r.Id == partStorage.PartId)
                    .Select(r => r.CategoryId)
                    .FirstOrDefaultAsync();

                Part part = await _context.Part
                    .Where(r => r.Id == partStorage.PartId)
                    .FirstOrDefaultAsync();

                TaskDetail taskDetail = await _context.TaskDetail
                    .Where(r => r.PartId == part.Id && r.TaskId == taskId)
                    .FirstOrDefaultAsync();

                if (part == null)
                    continue;

                if (taskDetail == null)
                    continue;

                InformationDataGridViewDisplayDto dto = new InformationDataGridViewDisplayDto
                {
                    Seq = seq++,
                    Zone = zones
                        .Where(r => r.Id == partStorage.ZoneId)
                        .Select(r => r.Name)
                        .FirstOrDefault(),
                    Category = await _context.PartCategory
                        .Where(r => r.Id == categoryId)
                        .Select(r => r.Name)
                        .FirstOrDefaultAsync(),
                    PartName = part.Name,
                    Unit = part.Unit,
                    Specification = part.Specification,
                    StockAmount = taskDetail.StockAmount,
                    CheckAmount = taskDetail.CheckAmount
                };

                dtos.Add(dto);
            }

            return dtos;
        }

        /// <summary>
        /// 保存用户修改的数据
        /// </summary>
        /// <param name="parameters"></param>
        /// <returns></returns>
        public async Task<bool> SaveTaskDetailAsync(List<InputInventorySaveParameter> parameters)
        {
            foreach (var parameter in parameters)
            {
                int taskId = await _context.InventoryCheckingTask
                    .Where(r => r.TaskName == parameter.TaskName)
                    .Select(r => r.Id)
                    .FirstOrDefaultAsync();
                Part part = await _context.Part
                    .Where(r => r.Name == parameter.PartName)
                    .FirstOrDefaultAsync();

                TaskDetail dto = await _context.TaskDetail
                    .Where(r => r.TaskId == taskId && r.PartId == part.Id)
                    .FirstOrDefaultAsync();
                if (dto == null)
                    return false;

                if (parameter.CheckAmount > part.MaxInventory)
                    return false;

                dto.CheckAmount = parameter.CheckAmount == 0 ? null : parameter.CheckAmount;
                dto.IsChecked = parameter.CheckAmount == 0 ? 0 : 1;
            }

            return await _context.SaveChangesAsync() >= 0;
        }
    }
}