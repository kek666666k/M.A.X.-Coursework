# Training Tracker - Система учета тренировочного процесса

## 📋 Описание
Веб-приложение для учета и управления тренировочным процессом, разработанное на платформе .NET 8 с использованием ASP.NET Core Blazor Server. Приложение позволяет вести базу упражнений, планировать тренировки, добавлять упражнения с параметрами (подходы, повторения, вес), а также анализировать статистику и прогресс.

## 🛠 Стек технологий
- .NET 8 / ASP.NET Core 8
- Blazor Server (Razor-компоненты, маршрутизация)
- Entity Framework Core 8 (подход CodeFirst, SQLite)
- FluentValidation (валидация форм)
- Docker & Docker Compose (Multi-stage build, volumes)
- Git (GitHub, ветки main/dev)
- Dependency Injection (IServiceCollection, репозитории, сервисы)

## 🏗 Архитектура и структура проекта
Приложение построено по многоуровневой архитектуре с внедрением зависимостей:

TrainingApp/
├── Data/               # AppDbContext, конфигурация Fluent API, Seed-данные
├── Migrations/         # Миграции EF Core
├── Models/             # Сущности: Training, Exercise, WorkoutExercise (1:N связи)
├── Repositories/       # Интерфейсы и реализации паттерна Repository
├── Services/           # Бизнес-логика, абстракция доступа к данным
├── Validators/         # Правила валидации FluentValidation
├── Pages/              # Blazor-страницы с маршрутизацией
├── Shared/             # MainLayout, NavMenu, общие компоненты
├── wwwroot/            # Статические файлы (CSS, иконки)
├── Dockerfile          # Multi-stage сборка контейнера
├── docker-compose.yml  # Оркестрация контейнеров
└── appsettings.json    # Конфигурация (строки подключения, логирование)

## 🚀 Инструкция по запуску

### Локальный запуск
1. Клонируйте репозиторий:
   git clone https://github.com/kek666666k/M.A.X.-Coursework.git
   cd TrainingApp

2. Восстановите пакеты:
   dotnet restore

3. Примените миграции базы данных:
   dotnet ef database update

4. Запустите приложение:
   dotnet run

Приложение доступно по адресу: http://localhost:5000

### Запуск через Docker
1. Убедитесь, что Docker Desktop запущен.

2. Соберите и запустите контейнеры:
   docker-compose up -d --build

3. Приложение доступно по адресу: http://localhost:5000

4. Для остановки:
   docker-compose down

Контейнер использует multi-stage build. База данных сохраняется в volume для персистентности данных между перезапусками.

## 🗄 База данных и миграции
Проект использует подход CodeFirst. Связи между сущностями настроены через Fluent API:
- Training 1:N WorkoutExercise
- Exercise 1:N WorkoutExercise

Реализованы seed-данные для начального заполнения БД.
Миграции применяются автоматически при запуске приложения.

Управление миграциями:
- dotnet ef migrations add <Name>    # Создать миграцию
- dotnet ef database update          # Применить миграции
- dotnet ef migrations list          # Просмотр списка миграций

## 🧪 Функционал
✅ CRUD-операции для тренировок и упражнений
✅ Валидация форм через FluentValidation
✅ Привязка упражнений к тренировкам с указанием подходов, повторений и веса
✅ Страница статистики и аналитики прогресса
✅ Адаптивный интерфейс Blazor Server с маршрутизацией
✅ Полная контейнеризация (Docker + docker-compose)

## 📄 Документация
- Исходный код размещён в Git-репозитории с историей коммитов.
- Код соответствует стандартам оформления, содержит XML-комментарии к публичным методам.
- Отсутствуют захардкоженные данные (конфигурация вынесена в appsettings.json).

## 👨‍💻 Автор
GitHub: https://github.com/kek666666k
Дата: Апрель 2026