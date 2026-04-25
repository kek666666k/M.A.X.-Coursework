using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace TrainingApp.Migrations
{
    /// <inheritdoc />
    public partial class AddExercisesAndWorkouts : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Exercises",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Name = table.Column<string>(type: "TEXT", maxLength: 100, nullable: false),
                    MuscleGroup = table.Column<string>(type: "TEXT", maxLength: 50, nullable: true),
                    Description = table.Column<string>(type: "TEXT", maxLength: 500, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Exercises", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Trainings",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Title = table.Column<string>(type: "TEXT", maxLength: 100, nullable: false),
                    Date = table.Column<DateTime>(type: "TEXT", nullable: false),
                    DurationMinutes = table.Column<int>(type: "INTEGER", nullable: false),
                    Description = table.Column<string>(type: "TEXT", maxLength: 1000, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Trainings", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "WorkoutExercises",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    TrainingId = table.Column<int>(type: "INTEGER", nullable: false),
                    ExerciseId = table.Column<int>(type: "INTEGER", nullable: false),
                    Sets = table.Column<int>(type: "INTEGER", nullable: false),
                    Reps = table.Column<int>(type: "INTEGER", nullable: false),
                    WeightKg = table.Column<double>(type: "REAL", nullable: true),
                    Notes = table.Column<string>(type: "TEXT", nullable: true),
                    Order = table.Column<int>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_WorkoutExercises", x => x.Id);
                    table.ForeignKey(
                        name: "FK_WorkoutExercises_Exercises_ExerciseId",
                        column: x => x.ExerciseId,
                        principalTable: "Exercises",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_WorkoutExercises_Trainings_TrainingId",
                        column: x => x.TrainingId,
                        principalTable: "Trainings",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "Exercises",
                columns: new[] { "Id", "Description", "MuscleGroup", "Name" },
                values: new object[,]
                {
                    { 1, "Базовое упражнение на грудные мышцы", "Грудь", "Жим лёжа" },
                    { 2, "Жим гантелей под углом 30-45 градусов", "Грудь", "Жим гантелей на наклонной скамье" },
                    { 3, "Жим штанги под углом 30-45 градусов", "Грудь", "Жим штанги на наклонной скамье" },
                    { 4, "Сведение рук с гантелями в стороны", "Грудь", "Разводка гантелей лёжа" },
                    { 5, "Отжимания с акцентом на грудные мышцы", "Грудь", "Отжимания на брусьях" },
                    { 6, "Сведение рук через тросы кроссовера", "Грудь", "Сведение рук в кроссовере" },
                    { 7, "Растяжение грудных мышц и широчайших", "Грудь", "Пуловер с гантелью" },
                    { 8, "Жим в тренажёре для грудных", "Грудь", "Жим в тренажёре Хаммер" },
                    { 9, "Базовое упражнение на спину и ноги", "Спина", "Становая тяга" },
                    { 10, "Тяга штанги к поясу в наклоне", "Спина", "Тяга штанги в наклоне" },
                    { 11, "Тяга одной гантели с упором", "Спина", "Тяга гантели в наклоне" },
                    { 12, "Подтягивания для широчайших", "Спина", "Подтягивания широким хватом" },
                    { 13, "Тяга блока к груди", "Спина", "Тяга верхнего блока" },
                    { 14, "Тяга блока к животу сидя", "Спина", "Тяга горизонтального блока" },
                    { 15, "Разгибание спины на тренажёре", "Спина", "Гиперэкстензия" },
                    { 16, "Подъём плеч со штангой", "Спина", "Шраги со штангой" },
                    { 17, "Тяга каната к лицу для задних дельт", "Спина", "Face Pull (тяга к лицу)" },
                    { 18, "Базовое упражнение на ноги", "Ноги", "Приседания со штангой" },
                    { 19, "Жим платформы ногами", "Ноги", "Жим ногами" },
                    { 20, "Шаги с гантелями", "Ноги", "Выпады с гантелями" },
                    { 21, "Разгибание ног сидя", "Ноги", "Разгибание ног в тренажёре" },
                    { 22, "Сгибание ног лёжа", "Ноги", "Сгибание ног в тренажёре" },
                    { 23, "Мёртвая тяга на прямых ногах", "Ноги", "Румынская тяга" },
                    { 24, "Икроножные мышцы", "Ноги", "Подъёмы на носки" },
                    { 25, "Приседания на одной ноге", "Ноги", "Болгарские сплит-приседания" },
                    { 26, "Подъём таза с весом", "Ноги", "Ягодичный мостик" },
                    { 27, "Жим штанги стоя/сидя", "Плечи", "Армейский жим" },
                    { 28, "Жим гантелей над головой", "Плечи", "Жим гантелей сидя" },
                    { 29, "Разведение гантелей через стороны", "Плечи", "Махи гантелями в стороны" },
                    { 30, "Разведение гантелей на задние дельты", "Плечи", "Махи гантелями в наклоне" },
                    { 31, "Тяга штанги к подбородку", "Плечи", "Протяжка штанги" },
                    { 32, "Подъём гантелей/штанги перед собой", "Плечи", "Подъём рук перед собой" },
                    { 33, "Махи в тренажёре", "Плечи", "Разведение в стороны в тренажёре" },
                    { 34, "Сгибание рук со штангой стоя", "Бицепс", "Подъём штанги на бицепс" },
                    { 35, "Сгибание рук с гантелями", "Бицепс", "Подъём гантелей на бицепс" },
                    { 36, "Подъём гантелей нейтральным хватом", "Бицепс", "Молотки (Hammer Curls)" },
                    { 37, "Изолированный подъём с упором", "Бицепс", "Концентрированный подъём на бицепс" },
                    { 38, "Сгибание рук на пюпитре", "Бицепс", "Подъём на бицепс на скамье Скотта" },
                    { 39, "Сгибание рук с нижнего блока", "Бицепс", "Подъём на бицепс в кроссовере" },
                    { 40, "Разгибание рук со штангой/гантелью", "Трицепс", "Французский жим" },
                    { 41, "Разгибание с верхнего блока", "Трицепс", "Разгибание рук на блоке" },
                    { 42, "Обратные отжимания", "Трицепс", "Отжимания от скамьи сзади" },
                    { 43, "Изолированное упражнение", "Трицепс", "Разгибание руки с гантелью из-за головы" },
                    { 44, "Жим лёжа узким хватом", "Трицепс", "Жим узким хватом" },
                    { 45, "Разгибание руки в наклоне", "Трицепс", "Кикбэк с гантелью" },
                    { 46, "Статическое упражнение на кор", "Пресс", "Планка" },
                    { 47, "Подъём корпуса лёжа", "Пресс", "Скручивания" },
                    { 48, "Подъём ног на перекладине", "Пресс", "Подъём ног в висе" },
                    { 49, "Косые скручивания", "Пресс", "Велосипед" },
                    { 50, "Повороты корпуса с весом", "Пресс", "Русские скручивания" },
                    { 51, "Статика на косые мышцы", "Пресс", "Боковая планка" },
                    { 52, "Бег в умеренном темпе", "Кардио", "Бег на беговой дорожке" },
                    { 53, "Кардио на эллипсоиде", "Кардио", "Эллиптический тренажёр" },
                    { 54, "Езда на велосипеде", "Кардио", "Велотренажёр" },
                    { 55, "Прыжки со скакалкой", "Кардио", "Скакалка" }
                });

            migrationBuilder.InsertData(
                table: "Trainings",
                columns: new[] { "Id", "Date", "Description", "DurationMinutes", "Title" },
                values: new object[,]
                {
                    { 1, new DateTime(2026, 4, 27, 0, 0, 0, 0, DateTimeKind.Unspecified), "Фокус: прогрессия в жиме\n\nОсновной блок:\n- Жим лёжа: 4×5 @ 87.5 кг (80%)\n- Жим гантелей наклонный: 3×8-10\n\nАксессуары:\n- Тяга штанги в наклоне: 4×8\n- Французский жим: 3×10-12\n- Face pull: 3×15-20\n- Планка: 3×45 сек", 70, "Понедельник - Тяжёлый жим" },
                    { 2, new DateTime(2026, 4, 29, 0, 0, 0, 0, DateTimeKind.Unspecified), "Фокус: низ тела + верхняя добивка\n\nОсновной блок:\n- Приседания: 4×4 @ 110 кг (85%)\n- Тяга сумо (техника): 4×5 @ 80-90 кг\n\nАксессуары:\n- Армейский жим: 3×8-10\n- Махи в стороны: 3×12-15\n- Молотки: 3×10-12\n- Гиперэкстензия: 3×12", 80, "Среда - Присед + Тяга сумо" },
                    { 3, new DateTime(2026, 5, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Фокус: скорость, техника\n\nОсновной блок:\n- Жим лёжа (скоростной): 6×3 @ 77.5 кг\n- Жим лёжа (пауза): 3×5 @ 82.5 кг\n\nАксессуары (суперсеты):\n- Отжимания на брусьях + Тяга гантели\n- Разводка + Молотки\n- Пресс: 3×15", 80, "Пятница - Скоростной жим" }
                });

            migrationBuilder.InsertData(
                table: "WorkoutExercises",
                columns: new[] { "Id", "ExerciseId", "Notes", "Order", "Reps", "Sets", "TrainingId", "WeightKg" },
                values: new object[,]
                {
                    { 1, 1, "80% от максимума, пауза на груди", 1, 5, 4, 1, 87.5 },
                    { 2, 2, "Наклон 30 градусов", 2, 10, 3, 1, 22.0 },
                    { 3, 10, "Тяга к поясу", 3, 8, 4, 1, 60.0 },
                    { 4, 40, "Французский жим", 4, 12, 3, 1, 30.0 },
                    { 5, 17, "Face pull с канатом", 5, 20, 3, 1, null },
                    { 6, 46, "45 секунд", 6, 1, 3, 1, null },
                    { 7, 18, "85% от максимума", 1, 4, 4, 2, 110.0 },
                    { 8, 9, "Техника сумо", 2, 5, 4, 2, 85.0 },
                    { 9, 27, "Армейский жим стоя", 3, 10, 3, 2, 45.0 },
                    { 10, 29, "Махи в стороны", 4, 15, 3, 2, 10.0 },
                    { 11, 36, "Молотки", 5, 12, 3, 2, 16.0 },
                    { 12, 15, "Гиперэкстензия с диском", 6, 12, 3, 2, 20.0 },
                    { 13, 1, "Скоростной жим, максимальная скорость", 1, 3, 6, 3, 77.5 },
                    { 14, 1, "Пауза 2 секунды на груди", 2, 5, 3, 3, 82.5 },
                    { 15, 5, "Отжимания на брусьях", 3, 10, 3, 3, null },
                    { 16, 11, "Тяга гантели", 4, 10, 3, 3, 30.0 },
                    { 17, 4, "Разводка гантелей", 5, 12, 3, 3, 14.0 },
                    { 18, 47, "Скручивания на пресс", 6, 15, 3, 3, null }
                });

            migrationBuilder.CreateIndex(
                name: "IX_Exercises_Name",
                table: "Exercises",
                column: "Name",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_WorkoutExercises_ExerciseId",
                table: "WorkoutExercises",
                column: "ExerciseId");

            migrationBuilder.CreateIndex(
                name: "IX_WorkoutExercises_TrainingId",
                table: "WorkoutExercises",
                column: "TrainingId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "WorkoutExercises");

            migrationBuilder.DropTable(
                name: "Exercises");

            migrationBuilder.DropTable(
                name: "Trainings");
        }
    }
}
