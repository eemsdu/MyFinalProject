using Autofac;
using Autofac.Extensions.DependencyInjection;
using Business.Abstract;
using Business.Concrete;
using Business.DependencyResolvers.Autofac;
using DataAccess.Abstract;
using DataAccess.Concrete.EntityFramework;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllers();
 
//Bana arka planda referans olu�tur 
//K�saca �ocler bizim yerimize newler 
/// controllera diyor ki sen ba��ml�l�k g�r�rsen onun kar��l��� virg�lden sonra ki k�s�md�r. bu bizim yerimize newler.��erisinde data tutmuyorsak singleton kullan�r�z i�erisinde veri tutmuyorsak 

//autofac,ninject,castlewindsor,structureMap,dry�nject,light�nject -->�oc container
//AOP --> Bir metotun �n�nde bir metotun sonunda bir metot hata verdi�inde �al��an kod par�a����d�r .
//postsharp 

//builder.Services.AddSingleton<IProductService,ProductManager>();
//builder.Services.AddSingleton<IProductDal,EfProductDal>();
 
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
//buraya autofac kullanmak i�in  yazd�n �nemli 
builder.Host.UseServiceProviderFactory(new AutofacServiceProviderFactory());
builder.Host.ConfigureContainer<ContainerBuilder>(builder =>
{
    builder.RegisterModule(new AutofacBusinessModule());
});

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())

{
    app.UseSwagger();
    app.UseSwaggerUI();
    
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
