using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Components.Server;
using TrainingApp.Data;
using TrainingApp.Repositories;
using TrainingApp.Services;
using FluentValidation;
using System.Reflection;

var builder = WebApplication.CreateBuilder(args);

// ============================================
// 1. Регистрация сервисов (Dependency Injection)
// ============================================

// Blazor Server и Razor Pages
builder.Services.AddRazorPages();
builder.Services.AddServerSideBlazor();

// Entity Framework Core (SQLite)
builder.Services.AddDbContext<AppDbContext>(options =>
    options.UseSqlite(builder.Configuration.GetConnectionString("DefaultConnection")));

// Валидация (FluentValidation) - требование ТЗ
// Регистрируем все валидаторы из сборки
builder.Services.AddValidatorsFromAssembly(Assembly.GetExecutingAssembly());

// --- Тренировки (Training) ---
builder.Services.AddScoped<ITrainingRepository, TrainingRepository>();
builder.Services.AddScoped<ITrainingService, TrainingService>();

// --- Упражнения (Exercise) ---
builder.Services.AddScoped<IExerciseRepository, ExerciseRepository>();
builder.Services.AddScoped<IExerciseService, ExerciseService>();

// --- Связь Тренировка-Упражнение (WorkoutExercise) ---
builder.Services.AddScoped<IWorkoutExerciseRepository, WorkoutExerciseRepository>();
builder.Services.AddScoped<IWorkoutExerciseService, WorkoutExerciseService>();

// ============================================
// 2. Сборка приложения и Middleware
// ============================================

var app = builder.Build();

// Настройка окружения
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Error");
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();
app.UseRouting();

app.MapBlazorHub();
app.MapFallbackToPage("/_Host");

// ============================================
// 3. Применение миграций при запуске
// ============================================

using (var scope = app.Services.CreateScope())
{
    var services = scope.ServiceProvider;
    try
    {
        var context = services.GetRequiredService<AppDbContext>();
        await context.Database.MigrateAsync();
    }
    catch (Exception ex)
    {
        var logger = services.GetRequiredService<ILogger<Program>>();
        logger.LogError(ex, "Ошибка при миграции или инициализации базы данных.");
    }
}

// ============================================
// 4. Запуск
// ============================================

app.Run();