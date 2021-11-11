using BlazorBeast.Server;
using Microsoft.AspNetCore.Components;
using Timers;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();
builder.Services.AddRazorPages();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

// builder.Services.AddSingleton<ITimerFactory, TimerFactory>();
// builder.Services.AddScoped(sp => new HttpClient { BaseAddress = new Uri( sp.GetRequiredService<NavigationManager>().BaseUri ) });

var app = builder.Build();

app.UseSwagger();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseWebAssemblyDebugging();
}
else
{
    app.UseExceptionHandler("/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();

app.UseBlazorFrameworkFiles();
app.UseStaticFiles();

app.UseRouting();


app.MapRazorPages();
app.MapControllers();
app.MapHighScoresApi();
app.MapFallbackToPage("/_Host");

app.UseSwaggerUI();
app.Run();
