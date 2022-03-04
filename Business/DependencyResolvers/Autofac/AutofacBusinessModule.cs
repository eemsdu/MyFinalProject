using Autofac;
using Business.Abstract;
using Business.CCS;
using Business.Concrete;
using DataAccess.Abstract;
using DataAccess.Concrete.EntityFramework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.DependencyResolvers.Autofac
{
    public class AutofacBusinessModule:Module
    {
        //uygulamayı çalıştırıldıgında çalışan kod
        protected override void Load(ContainerBuilder builder)
        {
            //birisi Iproduct service isterse productmanager ver .
            //bir kere instance eder ve hep o kullanılır 
            //bu şekilde yaparak newleme probleminden kurtulduk o bizim yerimize newliyor 
            builder.RegisterType<ProductManager>().As<IProductService>().SingleInstance();
            builder.RegisterType<EfProductDal>().As<IProductDal>().SingleInstance();
            builder.RegisterType<FileLogger>().As<ILogger>().SingleInstance();
            builder.RegisterType<CategoryManager>().As<ICategoryService>().SingleInstance();
            builder.RegisterType<EfCategoryDal>().As<ICategoryDal>().SingleInstance();
        }
    }
}
