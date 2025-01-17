using HospitalServer;


var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

//added
builder.Services.AddSignalR();


var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

//added
app.UseRouting();

app.UseAuthorization();

app.MapControllers();

//added
app.MapHub<HospitalChatHub>("/hospitalchathub");
app.UseEndpoints(endpoints =>
{
    endpoints.MapHub<HospitalInventoryHub>("/hospitalinventoryhub");
});

app.Run();

