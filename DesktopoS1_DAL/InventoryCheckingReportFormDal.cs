using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Threading.Tasks;
using DesktopS1_Helper;
using DesktopS1_Model.DisplayDto;
using DesktopS1_Model.Entities;

namespace DesktopoS1_DAL
{
    public class InventoryCheckingReportFormDal
    {
        public static InventoryCheckingReportFormDal InstanceDal => Singleton<InventoryCheckingReportFormDal>.Instance;

        private readonly S1Entities _context;

        public InventoryCheckingReportFormDal()
        {
            _context = new S1Entities();
        }

        /// <summary>
        /// 查询InventoryCheckingTask信息
        /// </summary>
        /// <param name="taskName"></param>
        /// <returns>返回查询到的结果</returns>
        public async Task<(InventoryCheckingTaskDisplayDto,int)> GetInventoryCheckingTaskByTaskNameAsync(string taskName)
        {
            InventoryCheckingTask dto = await _context.InventoryCheckingTask.FirstOrDefaultAsync(r => r.TaskName == taskName);
            if (dto == null)
                throw new ArgumentNullException(nameof(dto));

            var displayDto = new InventoryCheckingTaskDisplayDto
            {
                WarehouseName = await _context.Warehouse.Where(r => r.Id == dto.WarehouseId).Select(r => r.Name)
                    .FirstOrDefaultAsync(),
                InventoryCheckingTaskName = dto.TaskName,
                TaskType = await _context.TaskType.Where(r => r.Id == dto.TaskTypeId).Select(r => r.Name)
                    .FirstOrDefaultAsync(),
                CreateTime = dto.CreateTime,
                StartDate = dto.StartDate,
                FinishDate = dto.FinishDate,
                Status = await _context.TaskStatus.Where(r => r.Id == dto.StatusId).Select(r => r.Name)
                    .FirstOrDefaultAsync()
            };

            return (displayDto, dto.Id);
        }

        public async Task<(List<CheckExceptionDisplayDto>,List<ReplenishedDisplayDto>)> GetCheckExceptionsAsync(int taskId)
        {
            IEnumerable<TaskDetail> taskDetails =
                await _context.TaskDetail.Where(r => r.TaskId == taskId).ToListAsync();
            if (!taskDetails.Any())
                throw new ArgumentNullException(nameof(taskDetails));

            List<CheckExceptionDisplayDto> checkExceptions=new List<CheckExceptionDisplayDto>();
            List<ReplenishedDisplayDto> replenishedDtos=new List<ReplenishedDisplayDto>();

            foreach (var taskDetail in taskDetails)
            {
                Part part = await _context.Part.FirstOrDefaultAsync(r => r.Id == taskDetail.PartId);
                if (part == null)
                    throw new ArgumentNullException(nameof(part));

                if (taskDetail.StockAmount != taskDetail.CheckAmount&&taskDetail.CheckAmount>=part.MinInventory)
                {
                    CheckExceptionDisplayDto checkException = new CheckExceptionDisplayDto
                    {
                        PartName = part.Name,
                        Specification = part.Specification,
                        StockAmount = taskDetail.StockAmount,
                        CheckAmount = taskDetail.CheckAmount
                    };
                    checkExceptions.Add(checkException);
                }else if (taskDetail.CheckAmount < part.MinInventory)
                {
                    ReplenishedDisplayDto replenishedDto = new ReplenishedDisplayDto
                    {
                        PartName = part.Name,
                        Specification = part.Specification,
                        CheckAmount = taskDetail.CheckAmount,
                        MinInventory = part.MinInventory
                    };
                    replenishedDtos.Add(replenishedDto);
                }
            }

            return (checkExceptions, replenishedDtos);
        }

    }
}