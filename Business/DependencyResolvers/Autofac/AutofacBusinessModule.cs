﻿using Autofac;
using Business.Abstract;
using Business.Concrete;
using DataAcces.Abstract;
using DataAcces.Concrete.EntityFramework;

namespace Business.DependencyResolvers.Autofac
{
    public class AutofacBusinessModule : Module
    {
        //Configuration elədiyimiz yerdir Load metodu
        protected override void Load(ContainerBuilder builder)
        {
            builder.RegisterType<ProductService>().As<IProductService>();
            builder.RegisterType<EfProductDal>().As<IProductDal>();
        }
    }
}