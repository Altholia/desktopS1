using System;
using System.Data.Entity;
using System.Linq;
using System.Threading.Tasks;
using DesktopS1_Helper;
using DesktopS1_Model.Entities;

namespace DesktopoS1_DAL
{
    public class LoginFormDal:Bll
    {
        private readonly S1Entities _context;
        public static LoginFormDal InstanceDal => Singleton<LoginFormDal>.Instance;

        public LoginFormDal()
        {
            _context = new S1Entities();
        }

        public async Task<(bool, int,int)> UserLogin(string telephone, string password)
        {
            Staff staff = await _context.Staff
                .FirstOrDefaultAsync(r => r.Telephone.Equals(telephone) && r.Password.Equals(password));

            if (staff == null)
                return (false, -1, -1);

            return (true, staff.RoleId, staff.Id);
        }

    }
}