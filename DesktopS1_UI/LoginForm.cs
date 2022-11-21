using System;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using DesktopS1_Model.DisplayDto;
using static DesktopS1_BLL.LoginFormBll;
using static DesktopS1_Model.DisplayDto.UserDisplayDto;

namespace DesktopS1_UI
{
    public partial class LoginForm : Form
    {
        private int _loginError = 0;//记录登录失败的次数，当>=3时Login_Button变为不可用,登录成功则归零

        public LoginForm()
        {
            InitializeComponent();
        }

        /// <summary>
        /// 用户登录
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private async void Login_Button_Click(object sender, EventArgs e)
        {
            string telephoneString = Telephone_TextBox.Text.Trim();
            string passwordString = Password_TextBox.Text.Trim();

            if (string.IsNullOrWhiteSpace(telephoneString) || string.IsNullOrWhiteSpace(passwordString))
            {
                MessageBox.Show(@"账户或密码不能为空", @"警告", MessageBoxButtons.OKCancel, MessageBoxIcon.Warning);
                return;
            }


            (bool isLogin, int roleId, int userId) = await InstanceBll.UserLogin(telephoneString, passwordString);

            if (isLogin)
            {
                MessageBox.Show(@"登录成功，点击OK跳转", @"登录成功", MessageBoxButtons.OK, MessageBoxIcon.None);
                _loginError = 0;//登录成功，次数归零

                InstanceUser.Telephone = telephoneString;
                InstanceUser.Password = passwordString;
                InstanceUser.RoleId = roleId;
                InstanceUser.UserId = userId;

                DisplayWinForm(roleId); //根据不同的身份显示不同的面板
            }
            else
            {
                MessageBox.Show(@"登录失败，请查看账户和密码是否正确", @"错误", MessageBoxButtons.OK, MessageBoxIcon.Error);
                Password_TextBox.Clear();

                _loginError++;//登录失败次数+1
                if (_loginError >= 3)
                {
                    Login_Button.Enabled = false;//禁用Login_Button，并显示滑动拼图验证
                    VerifyForm verifyForm = new VerifyForm();
                    verifyForm.ShowDialog();

                    Login_Button.Enabled = true;
                    _loginError = 0;
                }
            }
        }

        /// <summary>
        /// 根据不同的身份显示不同的界面
        /// </summary>
        /// <param name="roleId"></param>
        private void DisplayWinForm(int roleId)
        {
            switch (roleId)
            {
                case 1:
                    break;
                case 2:
                    new WarehouseDetailForm().Show();
                    break;
                case 3:
                    break;
                case 4:
                    break;
                case 5:
                    break;
                case 6:
                    ViewInventoryCheckingTaskForm.InstanceForm.Show();
                    break;
            }
            this.Hide();
        }

        private void Cancel_Button_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }
    }
}
