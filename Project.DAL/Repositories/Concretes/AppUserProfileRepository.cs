﻿using Project.DAL.ContextClasses;
using Project.ENTITIES.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project.DAL.Repositories.Concretes
{
    public class AppUserProfileRepository : BaseRepository<AppUserProfile>
    {
        public AppUserProfileRepository(MyContext db) : base(db)
        {
        }
    }
}
