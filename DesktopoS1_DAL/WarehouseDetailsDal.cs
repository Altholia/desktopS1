using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data.Entity;
using System.Linq;
using System.Threading.Tasks;
using DesktopS1_Helper;
using DesktopS1_Model.DisplayDto;
using DesktopS1_Model.Entities;

namespace DesktopoS1_DAL
{
    public class WarehouseDetailsDal:Bll
    {
        private readonly S1Entities _context;
        public static WarehouseDetailsDal InstanceDal => Singleton<WarehouseDetailsDal>.Instance;

        public WarehouseDetailsDal()
        {
            _context=new S1Entities();
        }

        /// <summary>
        /// 获取所有的仓库信息
        /// </summary>
        /// <returns>返回查询到的仓库信息</returns>
        public async Task<List<WarehouseDisplayDto>> GetWarehouseAsync()
        {
            IEnumerable<Warehouse> warehouses = await _context.Warehouse
                .ToListAsync();

            List<WarehouseDisplayDto> warehouseDisplay = new List<WarehouseDisplayDto>();

            foreach (var warehouse in warehouses)
            {
                WarehouseDisplayDto dto=new WarehouseDisplayDto
                {
                    Id=warehouse.Id,
                    Name = warehouse.Name,
                    Address = warehouse.Address,
                    Area = warehouse.Area,
                    Phone = warehouse.Phone,
                    WarehouseKeeper = await _context.Staff
                        .AsNoTracking()
                        .Where(r => r.Id == warehouse.Manager)
                        .Select(r => r.FirstName)
                        .FirstOrDefaultAsync(),
                    LastCheckingDate = await _context.InventoryCheckingTask
                        .AsNoTracking()
                        .Where(r => r.WarehouseId == warehouse.Id)
                        .OrderByDescending(r => r.StartDate)
                        .Select(r => r.StartDate)
                        .FirstOrDefaultAsync()
                };
                warehouseDisplay.Add(dto);
            }

            return warehouseDisplay;
        }

        /// <summary>
        /// 获取仓库的分布信息
        /// </summary>
        /// <param name="warehouseId"></param>
        /// <returns>返回查询到的仓库分布信息</returns>
        public async Task<List<Zone>> GetZonesAsync(int warehouseId) =>
            await _context.Zone.Where(r => r.WarehouseId == warehouseId).ToListAsync();

        public async Task<List<PartDisplayDto>> GetParInformationByZoneId(int zoneId)
        {
            List<PartDisplayDto> dtos=new List<PartDisplayDto>();

            List<PartStorage> partCategories = await _context.PartStorage
                .AsNoTracking()
                .Where(r => r.ZoneId==zoneId)
                .ToListAsync();

            foreach (var partCategory in partCategories)
            {
                Part part = await _context.Part
                    .AsNoTracking()
                    .Where(r => r.Id == partCategory.PartId)
                    .FirstOrDefaultAsync();

                string partCategoryName = await _context.PartCategory
                    .Where(r => r.Id == part.CategoryId)
                    .Select(r => r.Name)
                    .FirstOrDefaultAsync();

                PartDisplayDto dto = new PartDisplayDto
                {
                    PartName = part.Name,
                    Category = partCategoryName,
                    Specification = part.Specification,
                    Amount = partCategory.Amount,
                    MinInventory = part.MinInventory
                };
                dtos.Add(dto);
            }

            return dtos;
        }
    }
}