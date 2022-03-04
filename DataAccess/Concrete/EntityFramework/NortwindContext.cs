using Entities.Concrete;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Concrete.EntityFramework
{
    //Context:Db tabloları ile proje classlarını bağlamak
    public class NortwindContext:DbContext
    {
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
            //projenin hangi veri tabanı ile ilişkili olduğunu söylediğim yer 
        {
            optionsBuilder.UseSqlServer(@"Data Source=DESKTOP-8M7D7GE\MSSQLSERVER1;Initial Catalog=NORTHWND;User ID=sa;Password=1234");
        }
        //hangi nesnem hangi nesneye karşılık gelecek bunu db setler ile yapıyorum  
        public DbSet<Product> Products { get; set; }
        //benim Product nesnemi  veri tabanımda ki products ile bağla demektir.
        //context hangi veri tabanına bağlanacağımı buldu
        //benim hangi classım hangisine eşit olacağını bul 
        public DbSet<Category> Categories { get; set;}

        public DbSet<Customer> Customers { get; set;}

        public DbSet<Order> Orders { get; set; }

    }
}
