using Web_DoTheThao.Repository;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

//Ket noi Db
	builder.Services.AddDbContext<DataContext>(options =>
	{
		options.UseSqlServer(builder.Configuration["ConnectionStrings:ConnectedDb"]);
	}
	);





// Add services to the container.
builder.Services.AddControllersWithViews();

builder.Services.AddDistributedMemoryCache(); /* cho phép b?n l?u tr? d? li?u trong b? nh? ?? c?i thi?n hi?u su?t c?a ?ng d?ng  */

builder.Services.AddSession(options =>
{
	options.IdleTimeout = TimeSpan.FromMinutes(30); /*   Thi?t l?p th?i gian ch? (idle timeout) cho phiên là 30 phút. N?u ng??i dùng không t??ng tác trong kho?ng th?i gian này, phiên s? h?t h?n. */
	options.Cookie.IsEssential = true; /*   cookie này s? ???c t?o ngay c? khi ng??i dùng t? ch?i cookie không c?n thi?t */
}

);

var app = builder.Build();



app.UseSession();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
	app.UseExceptionHandler("/Home/Error");
	// The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
	app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

app.UseAuthorization();

app.MapControllerRoute(
	name: "default",
	pattern: "{controller=Home}/{action=Index}/{id?}");

//Seeding data
var context =app.Services.CreateScope().ServiceProvider.GetRequiredService<DataContext>();
SeedData.SeedingData(context);


app.Run();
