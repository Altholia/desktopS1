namespace DesktopS1_Helper
{
    /// <summary>
    /// 该类是InputInventoryCheckingResult窗体的Save按钮的参数
    /// </summary>
    public class InputInventorySaveParameter
    {
        public string TaskName { get; set; }
        public string PartName { get; set; }
        public int? CheckAmount { get; set; }
    }
}