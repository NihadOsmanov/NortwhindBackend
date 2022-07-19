using Business.Abstract;
using Business.Constants;
using Business.ValidationRules.FluentValidation;
using Core.Aspects.Autofac.Validation;
using Core.Utilities.Results;
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

        public IResult Update(Product product)
        {
            _productDal.Update(product);
            return new SuccesResult(Messages.ProductUpdated);
        }

        [ValidationAspects(typeof(ProductValidator))]
        public IResult Add(Product product)
        {
            _productDal.Add(product);
            return new SuccesResult(Messages.ProductAdded);
        }

        public IResult Delete(Product product)
        {
            _productDal.Delete(product);
            return new SuccesResult(Messages.ProductDeleted);
        }

        public IDataResult<Product> GetById(int productId)
        {
            var result = _productDal.Get(x => x.ProductId == productId);
            return new SuccesDataResult<Product>(result);
        }

        public IDataResult<List<Product>> GetList()
        {
            var result = _productDal.GetAll().ToList();
            return new SuccesDataResult<List<Product>>(result);
        }

        public IDataResult<List<Product>> GetListByCategory(int categoryId)
        {
            var result = _productDal.GetAll(x => x.CategoryId == categoryId).ToList();
            return new SuccesDataResult<List<Product>>(result);
        }
    }
}
