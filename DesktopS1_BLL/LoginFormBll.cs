using System.Threading.Tasks;
using DesktopoS1_DAL;
using DesktopS1_Helper;
using static DesktopoS1_DAL.LoginFormDal;

namespace DesktopS1_BLL
{
    public class LoginFormBll:Bll
    {
        public static LoginFormBll InstanceBll => Singleton<LoginFormBll>.Instance;

        public async Task<(bool,int,int)> UserLogin(string telephone, string password) =>
            await InstanceDal.UserLogin(telephone, password);
    }
}