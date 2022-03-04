using Core.Utilities.Results;
using Entities.Concrete;
using Entities.Dtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Abstract
{
    public interface IProductService //iş kodunun soyutu 
    {
        IDataResult<List<Product>> GetAll();  
        // işlem sonucu ve mesajı da döndürmek istiyorum .
        IDataResult<List<Product>> GetAllCategoryId(int id);
        IDataResult<List<Product>> GetAllByUnitPrice(decimal min, decimal max);
        IDataResult<List<ProductDetailDto>> GetProductDetails();
        IDataResult<Product> GetById(int productId);
        IResult Add(Product product);
        IResult Update(Product product);

     
        //Restful --> Http --> Bir kaynağa ulaşmak için izlenilen yoldur 
        //Controller :Bizim sistemimizi kullanacak clientler bize hangi operasyonlarda bulunacaklarını ve/veya nasıl bulunacaklarını controllerda yazarız.
    }
}
