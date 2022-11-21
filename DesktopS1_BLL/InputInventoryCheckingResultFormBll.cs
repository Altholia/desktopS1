using System.Collections;
using System.Collections.Generic;
using System.Threading.Tasks;
using DesktopS1_Helper;
using DesktopS1_Model.DisplayDto;
using static DesktopoS1_DAL.InputInventoryCheckingResultFormDal;

namespace DesktopS1_BLL
{
    public class InputInventoryCheckingResultFormBll:Bll
    {
        public static InputInventoryCheckingResultFormBll InstanceBll =>
            Singleton<InputInventoryCheckingResultFormBll>.Instance;

        /// <summary>
        /// 通过TaskName获取TaskID
        /// </summary>
        /// <param name="taskName"></param>
        /// <returns></returns>
        public async Task<int> GetTaskIdByTaskNameAsync(string taskName) =>
            await InstanceDal.GetTaskIdByTaskNameAsync(taskName);

        /// <summary>
        /// 为Information_DataGridView数据网格获取填充内容
        /// </summary>
        /// <param name="warehouseName">仓库名称</param>
        /// <param name="taskId">任务ID</param>
        /// <returns></returns>
        public async Task<IEnumerable<InformationDataGridViewDisplayDto>> GetInformationDataGridViewDtoAsync(
            string warehouseName, int taskId) =>
            await InstanceDal.GetInformationDataGridViewDtoAsync(warehouseName, taskId);

        /// <summary>
        /// 保存用户修改的数据
        /// </summary>
        /// <param name="parameters"></param>
        /// <returns></returns>
        public async Task<bool> SaveTaskDetailAsync(List<InputInventorySaveParameter> parameters) =>
            await InstanceDal.SaveTaskDetailAsync(parameters);
    }
}