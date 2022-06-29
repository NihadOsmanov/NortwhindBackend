using Business.Abstract;
using DataAcces.Abstract;
using Entities.Concrete;
using System.Collections.Generic;
using System.Linq;

namespace Business.Concrete
{
    public class ProductService : IProductService
    {
        private readonly IProductDal _productDal;

        public ProductService(IProductDal productDal)
        {
            _productDal = productDal;
        }

        public void Update(Product product)
        {
            _productDal.Update(product);
        }

        public void Add(Product product)
        {
            _productDal.Add(product);
        }

        public void Delete(Product product)
        {
            _productDal.Delete(product);
        }

        public Product GetById(int productId)
        {
            return _productDal.Get(x => x.ProductId == productId);
        }

        public List<Product> GetList()
        {
            return _productDal.GetAll().ToList();
        }

        public List<Product> GetListByCategory(int categoryId)
        {
            return _productDal.GetAll(x => x.CategoryId == categoryId).ToList();
        }
    }
}
