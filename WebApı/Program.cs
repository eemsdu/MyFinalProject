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
 
//Bana arka planda referans oluþtur 
//Kýsaca ýocler bizim yerimize newler 
/// controllera diyor ki sen baðýmlýlýk görürsen onun karþýlýðý virgülden sonra ki kýsýmdýr. bu bizim yerimize newler.Ýçerisinde data tutmuyorsak singleton kullanýrýz içerisinde veri tutmuyorsak 

//autofac,ninject,castlewindsor,structureMap,dryýnject,lightýnject -->ýoc container
//AOP --> Bir metotun önünde bir metotun sonunda bir metot hata verdiðinde çalýþan kod parçaçýðýdýr .
//postsharp 

//builder.Services.AddSingleton<IProductService,ProductManager>();
//builder.Services.AddSingleton<IProductDal,EfProductDal>();
 
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
//buraya autofac kullanmak için  yazdýn önemli 
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
