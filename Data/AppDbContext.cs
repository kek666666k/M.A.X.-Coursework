using Microsoft.EntityFrameworkCore;
using TrainingApp.Models;

namespace TrainingApp.Data;

/// <summary>
/// Контекст базы данных для системы учета тренировок
/// </summary>
public class AppDbContext : DbContext
{
    public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
    {
    }

    public DbSet<Training> Trainings => Set<Training>();
    public DbSet<Exercise> Exercises => Set<Exercise>();
    public DbSet<WorkoutExercise> WorkoutExercises => Set<WorkoutExercise>();

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);

        // Конфигурация Training
        modelBuilder.Entity<Training>(entity =>
        {
            entity.HasKey(e => e.Id);
            entity.Property(e => e.Title).IsRequired().HasMaxLength(100);
            entity.Property(e => e.Description).HasMaxLength(1000);
        });

        // Конфигурация Exercise
        modelBuilder.Entity<Exercise>(entity =>
        {
            entity.HasKey(e => e.Id);
            entity.Property(e => e.Name).IsRequired().HasMaxLength(100);
            entity.HasIndex(e => e.Name).IsUnique();
            entity.Property(e => e.Description).HasMaxLength(500);
        });

        // Конфигурация WorkoutExercise
        modelBuilder.Entity<WorkoutExercise>(entity =>
        {
            entity.HasKey(e => e.Id);

            entity.HasOne(we => we.Training)
                  .WithMany()
                  .HasForeignKey(we => we.TrainingId)
                  .OnDelete(DeleteBehavior.Cascade);

            entity.HasOne(we => we.Exercise)
                  .WithMany()
                  .HasForeignKey(we => we.ExerciseId)
                  .OnDelete(DeleteBehavior.Restrict);
        });

        // ============================================
        // БОЛЬШАЯ БАЗА УПРАЖНЕНИЙ (50+ упражнений)
        // ============================================
        modelBuilder.Entity<Exercise>().HasData(
            // ГРУДЬ
            new Exercise { Id = 1, Name = "Жим лёжа", MuscleGroup = "Грудь", Description = "Базовое упражнение на грудные мышцы" },
            new Exercise { Id = 2, Name = "Жим гантелей на наклонной скамье", MuscleGroup = "Грудь", Description = "Жим гантелей под углом 30-45 градусов" },
            new Exercise { Id = 3, Name = "Жим штанги на наклонной скамье", MuscleGroup = "Грудь", Description = "Жим штанги под углом 30-45 градусов" },
            new Exercise { Id = 4, Name = "Разводка гантелей лёжа", MuscleGroup = "Грудь", Description = "Сведение рук с гантелями в стороны" },
            new Exercise { Id = 5, Name = "Отжимания на брусьях", MuscleGroup = "Грудь", Description = "Отжимания с акцентом на грудные мышцы" },
            new Exercise { Id = 6, Name = "Сведение рук в кроссовере", MuscleGroup = "Грудь", Description = "Сведение рук через тросы кроссовера" },
            new Exercise { Id = 7, Name = "Пуловер с гантелью", MuscleGroup = "Грудь", Description = "Растяжение грудных мышц и широчайших" },
            new Exercise { Id = 8, Name = "Жим в тренажёре Хаммер", MuscleGroup = "Грудь", Description = "Жим в тренажёре для грудных" },

            // СПИНА
            new Exercise { Id = 9, Name = "Становая тяга", MuscleGroup = "Спина", Description = "Базовое упражнение на спину и ноги" },
            new Exercise { Id = 10, Name = "Тяга штанги в наклоне", MuscleGroup = "Спина", Description = "Тяга штанги к поясу в наклоне" },
            new Exercise { Id = 11, Name = "Тяга гантели в наклоне", MuscleGroup = "Спина", Description = "Тяга одной гантели с упором" },
            new Exercise { Id = 12, Name = "Подтягивания широким хватом", MuscleGroup = "Спина", Description = "Подтягивания для широчайших" },
            new Exercise { Id = 13, Name = "Тяга верхнего блока", MuscleGroup = "Спина", Description = "Тяга блока к груди" },
            new Exercise { Id = 14, Name = "Тяга горизонтального блока", MuscleGroup = "Спина", Description = "Тяга блока к животу сидя" },
            new Exercise { Id = 15, Name = "Гиперэкстензия", MuscleGroup = "Спина", Description = "Разгибание спины на тренажёре" },
            new Exercise { Id = 16, Name = "Шраги со штангой", MuscleGroup = "Спина", Description = "Подъём плеч со штангой" },
            new Exercise { Id = 17, Name = "Face Pull (тяга к лицу)", MuscleGroup = "Спина", Description = "Тяга каната к лицу для задних дельт" },

            // НОГИ
            new Exercise { Id = 18, Name = "Приседания со штангой", MuscleGroup = "Ноги", Description = "Базовое упражнение на ноги" },
            new Exercise { Id = 19, Name = "Жим ногами", MuscleGroup = "Ноги", Description = "Жим платформы ногами" },
            new Exercise { Id = 20, Name = "Выпады с гантелями", MuscleGroup = "Ноги", Description = "Шаги с гантелями" },
            new Exercise { Id = 21, Name = "Разгибание ног в тренажёре", MuscleGroup = "Ноги", Description = "Разгибание ног сидя" },
            new Exercise { Id = 22, Name = "Сгибание ног в тренажёре", MuscleGroup = "Ноги", Description = "Сгибание ног лёжа" },
            new Exercise { Id = 23, Name = "Румынская тяга", MuscleGroup = "Ноги", Description = "Мёртвая тяга на прямых ногах" },
            new Exercise { Id = 24, Name = "Подъёмы на носки", MuscleGroup = "Ноги", Description = "Икроножные мышцы" },
            new Exercise { Id = 25, Name = "Болгарские сплит-приседания", MuscleGroup = "Ноги", Description = "Приседания на одной ноге" },
            new Exercise { Id = 26, Name = "Ягодичный мостик", MuscleGroup = "Ноги", Description = "Подъём таза с весом" },

            // ПЛЕЧИ
            new Exercise { Id = 27, Name = "Армейский жим", MuscleGroup = "Плечи", Description = "Жим штанги стоя/сидя" },
            new Exercise { Id = 28, Name = "Жим гантелей сидя", MuscleGroup = "Плечи", Description = "Жим гантелей над головой" },
            new Exercise { Id = 29, Name = "Махи гантелями в стороны", MuscleGroup = "Плечи", Description = "Разведение гантелей через стороны" },
            new Exercise { Id = 30, Name = "Махи гантелями в наклоне", MuscleGroup = "Плечи", Description = "Разведение гантелей на задние дельты" },
            new Exercise { Id = 31, Name = "Протяжка штанги", MuscleGroup = "Плечи", Description = "Тяга штанги к подбородку" },
            new Exercise { Id = 32, Name = "Подъём рук перед собой", MuscleGroup = "Плечи", Description = "Подъём гантелей/штанги перед собой" },
            new Exercise { Id = 33, Name = "Разведение в стороны в тренажёре", MuscleGroup = "Плечи", Description = "Махи в тренажёре" },

            // БИЦЕПС
            new Exercise { Id = 34, Name = "Подъём штанги на бицепс", MuscleGroup = "Бицепс", Description = "Сгибание рук со штангой стоя" },
            new Exercise { Id = 35, Name = "Подъём гантелей на бицепс", MuscleGroup = "Бицепс", Description = "Сгибание рук с гантелями" },
            new Exercise { Id = 36, Name = "Молотки (Hammer Curls)", MuscleGroup = "Бицепс", Description = "Подъём гантелей нейтральным хватом" },
            new Exercise { Id = 37, Name = "Концентрированный подъём на бицепс", MuscleGroup = "Бицепс", Description = "Изолированный подъём с упором" },
            new Exercise { Id = 38, Name = "Подъём на бицепс на скамье Скотта", MuscleGroup = "Бицепс", Description = "Сгибание рук на пюпитре" },
            new Exercise { Id = 39, Name = "Подъём на бицепс в кроссовере", MuscleGroup = "Бицепс", Description = "Сгибание рук с нижнего блока" },

            // ТРИЦЕПС
            new Exercise { Id = 40, Name = "Французский жим", MuscleGroup = "Трицепс", Description = "Разгибание рук со штангой/гантелью" },
            new Exercise { Id = 41, Name = "Разгибание рук на блоке", MuscleGroup = "Трицепс", Description = "Разгибание с верхнего блока" },
            new Exercise { Id = 42, Name = "Отжимания от скамьи сзади", MuscleGroup = "Трицепс", Description = "Обратные отжимания" },
            new Exercise { Id = 43, Name = "Разгибание руки с гантелью из-за головы", MuscleGroup = "Трицепс", Description = "Изолированное упражнение" },
            new Exercise { Id = 44, Name = "Жим узким хватом", MuscleGroup = "Трицепс", Description = "Жим лёжа узким хватом" },
            new Exercise { Id = 45, Name = "Кикбэк с гантелью", MuscleGroup = "Трицепс", Description = "Разгибание руки в наклоне" },

            // ПРЕСС
            new Exercise { Id = 46, Name = "Планка", MuscleGroup = "Пресс", Description = "Статическое упражнение на кор" },
            new Exercise { Id = 47, Name = "Скручивания", MuscleGroup = "Пресс", Description = "Подъём корпуса лёжа" },
            new Exercise { Id = 48, Name = "Подъём ног в висе", MuscleGroup = "Пресс", Description = "Подъём ног на перекладине" },
            new Exercise { Id = 49, Name = "Велосипед", MuscleGroup = "Пресс", Description = "Косые скручивания" },
            new Exercise { Id = 50, Name = "Русские скручивания", MuscleGroup = "Пресс", Description = "Повороты корпуса с весом" },
            new Exercise { Id = 51, Name = "Боковая планка", MuscleGroup = "Пресс", Description = "Статика на косые мышцы" },

            // КАРДИО
            new Exercise { Id = 52, Name = "Бег на беговой дорожке", MuscleGroup = "Кардио", Description = "Бег в умеренном темпе" },
            new Exercise { Id = 53, Name = "Эллиптический тренажёр", MuscleGroup = "Кардио", Description = "Кардио на эллипсоиде" },
            new Exercise { Id = 54, Name = "Велотренажёр", MuscleGroup = "Кардио", Description = "Езда на велосипеде" },
            new Exercise { Id = 55, Name = "Скакалка", MuscleGroup = "Кардио", Description = "Прыжки со скакалкой" }
        );

        // ============================================
        // ТРЕНИРОВКИ С УПРАЖНЕНИЯМИ
        // ============================================

        // Тренировка 1: Понедельник
        modelBuilder.Entity<Training>().HasData(
            new Training
            {
                Id = 1,
                Title = "Понедельник - Тяжёлый жим",
                Date = new DateTime(2026, 4, 27),
                DurationMinutes = 70,
                Description = "Фокус: прогрессия в жиме\n\nОсновной блок:\n- Жим лёжа: 4×5 @ 87.5 кг (80%)\n- Жим гантелей наклонный: 3×8-10\n\nАксессуары:\n- Тяга штанги в наклоне: 4×8\n- Французский жим: 3×10-12\n- Face pull: 3×15-20\n- Планка: 3×45 сек"
            }
        );

        // Связываем упражнения с тренировкой 1
        modelBuilder.Entity<WorkoutExercise>().HasData(
            new WorkoutExercise { Id = 1, TrainingId = 1, ExerciseId = 1, Sets = 4, Reps = 5, WeightKg = 87.5, Notes = "80% от максимума, пауза на груди", Order = 1 },
            new WorkoutExercise { Id = 2, TrainingId = 1, ExerciseId = 2, Sets = 3, Reps = 10, WeightKg = 22, Notes = "Наклон 30 градусов", Order = 2 },
            new WorkoutExercise { Id = 3, TrainingId = 1, ExerciseId = 10, Sets = 4, Reps = 8, WeightKg = 60, Notes = "Тяга к поясу", Order = 3 },
            new WorkoutExercise { Id = 4, TrainingId = 1, ExerciseId = 40, Sets = 3, Reps = 12, WeightKg = 30, Notes = "Французский жим", Order = 4 },
            new WorkoutExercise { Id = 5, TrainingId = 1, ExerciseId = 17, Sets = 3, Reps = 20, WeightKg = null, Notes = "Face pull с канатом", Order = 5 },
            new WorkoutExercise { Id = 6, TrainingId = 1, ExerciseId = 46, Sets = 3, Reps = 1, WeightKg = null, Notes = "45 секунд", Order = 6 }
        );

        // Тренировка 2: Среда
        modelBuilder.Entity<Training>().HasData(
            new Training
            {
                Id = 2,
                Title = "Среда - Присед + Тяга сумо",
                Date = new DateTime(2026, 4, 29),
                DurationMinutes = 80,
                Description = "Фокус: низ тела + верхняя добивка\n\nОсновной блок:\n- Приседания: 4×4 @ 110 кг (85%)\n- Тяга сумо (техника): 4×5 @ 80-90 кг\n\nАксессуары:\n- Армейский жим: 3×8-10\n- Махи в стороны: 3×12-15\n- Молотки: 3×10-12\n- Гиперэкстензия: 3×12"
            }
        );

        modelBuilder.Entity<WorkoutExercise>().HasData(
            new WorkoutExercise { Id = 7, TrainingId = 2, ExerciseId = 18, Sets = 4, Reps = 4, WeightKg = 110, Notes = "85% от максимума", Order = 1 },
            new WorkoutExercise { Id = 8, TrainingId = 2, ExerciseId = 9, Sets = 4, Reps = 5, WeightKg = 85, Notes = "Техника сумо", Order = 2 },
            new WorkoutExercise { Id = 9, TrainingId = 2, ExerciseId = 27, Sets = 3, Reps = 10, WeightKg = 45, Notes = "Армейский жим стоя", Order = 3 },
            new WorkoutExercise { Id = 10, TrainingId = 2, ExerciseId = 29, Sets = 3, Reps = 15, WeightKg = 10, Notes = "Махи в стороны", Order = 4 },
            new WorkoutExercise { Id = 11, TrainingId = 2, ExerciseId = 36, Sets = 3, Reps = 12, WeightKg = 16, Notes = "Молотки", Order = 5 },
            new WorkoutExercise { Id = 12, TrainingId = 2, ExerciseId = 15, Sets = 3, Reps = 12, WeightKg = 20, Notes = "Гиперэкстензия с диском", Order = 6 }
        );

        // Тренировка 3: Пятница
        modelBuilder.Entity<Training>().HasData(
            new Training
            {
                Id = 3,
                Title = "Пятница - Скоростной жим",
                Date = new DateTime(2026, 5, 1),
                DurationMinutes = 80,
                Description = "Фокус: скорость, техника\n\nОсновной блок:\n- Жим лёжа (скоростной): 6×3 @ 77.5 кг\n- Жим лёжа (пауза): 3×5 @ 82.5 кг\n\nАксессуары (суперсеты):\n- Отжимания на брусьях + Тяга гантели\n- Разводка + Молотки\n- Пресс: 3×15"
            }
        );

        modelBuilder.Entity<WorkoutExercise>().HasData(
            new WorkoutExercise { Id = 13, TrainingId = 3, ExerciseId = 1, Sets = 6, Reps = 3, WeightKg = 77.5, Notes = "Скоростной жим, максимальная скорость", Order = 1 },
            new WorkoutExercise { Id = 14, TrainingId = 3, ExerciseId = 1, Sets = 3, Reps = 5, WeightKg = 82.5, Notes = "Пауза 2 секунды на груди", Order = 2 },
            new WorkoutExercise { Id = 15, TrainingId = 3, ExerciseId = 5, Sets = 3, Reps = 10, WeightKg = null, Notes = "Отжимания на брусьях", Order = 3 },
            new WorkoutExercise { Id = 16, TrainingId = 3, ExerciseId = 11, Sets = 3, Reps = 10, WeightKg = 30, Notes = "Тяга гантели", Order = 4 },
            new WorkoutExercise { Id = 17, TrainingId = 3, ExerciseId = 4, Sets = 3, Reps = 12, WeightKg = 14, Notes = "Разводка гантелей", Order = 5 },
            new WorkoutExercise { Id = 18, TrainingId = 3, ExerciseId = 47, Sets = 3, Reps = 15, WeightKg = null, Notes = "Скручивания на пресс", Order = 6 }
        );
    }
}