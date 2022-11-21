using System.Collections.Generic;
using System.Threading.Tasks;
using DesktopS1_Helper;
using DesktopS1_Model.DisplayDto;
using DesktopS1_Model.Entities;
using static DesktopoS1_DAL.InventoryCheckingReportFormDal;

namespace DesktopS1_BLL
{
    public class InventoryCheckingReportFormBll
    {
        public static InventoryCheckingReportFormBll InstanceBll => Singleton<InventoryCheckingReportFormBll>.Instance;

        /// <summary>
        /// 查询InventoryCheckingTask信息
        /// </summary>
        /// <param name="taskName"></param>
        /// <returns>返回查询到的结果</returns>
        public async Task<(InventoryCheckingTaskDisplayDto,int)> GetInventoryCheckingTaskByTaskNameAsync(string taskName) =>
            await InstanceDal.GetInventoryCheckingTaskByTaskNameAsync(taskName);

        public async Task<(List<CheckExceptionDisplayDto>, List<ReplenishedDisplayDto>)> GetCheckExceptionsAsync(int taskId) =>
            await InstanceDal.GetCheckExceptionsAsync(taskId);

    }
}