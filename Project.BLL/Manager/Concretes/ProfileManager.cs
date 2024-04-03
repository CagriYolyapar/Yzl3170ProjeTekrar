using Project.BLL.Manager.Abstracts;
using Project.DAL.Repositories.Abstracts;
using Project.ENTITIES.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project.BLL.Manager.Concretes
{
    public class ProfileManager : BaseManager<AppUserProfile> , IProfileManager
    {
        readonly IAppUserProfileRepository _pRep;

        public ProfileManager(IAppUserProfileRepository pRep) : base(pRep) 
        {
            _pRep = pRep;
        }
    }
}
