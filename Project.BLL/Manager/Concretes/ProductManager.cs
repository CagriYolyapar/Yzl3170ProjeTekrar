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
    public class ProductManager : BaseManager<Product> , IProductManager
    {
        readonly IProductRepository _proRep;

        public ProductManager(IProductRepository proRep) : base(proRep) 
        {
            _proRep = proRep;
        }
    }
}
