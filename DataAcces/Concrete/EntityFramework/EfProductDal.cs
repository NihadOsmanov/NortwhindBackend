using Core.DataAcces.EntityFramework;
using DataAcces.Abstract;
using DataAcces.Concrete.EntityFramework.Context;
using Entities.Concrete;

namespace DataAcces.Concrete.EntityFramework
{
    public class EfProductDal:EfEntityRepositoryBase<Product, NorthwindContext>,IProductDal
    {
    }
}
