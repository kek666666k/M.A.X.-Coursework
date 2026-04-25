# Training Tracker - Система учета тренировочного процесса

## 📋 Описание
Веб-приложение для учета и управления тренировками, разработанное на ASP.NET Core 8 с использованием Blazor Server.

## 🛠 Технологии
- **.NET 8**
- **ASP.NET Core Blazor Server**
- **Entity Framework Core** (CodeFirst подход)
- **SQLite** база данных
- **Docker** и **Docker Compose**
- **Repository Pattern**
- **Dependency Injection**

## 📁 Структура проекта
TrainingApp/
├── Data/ # DbContext и конфигурация БД
├── Models/ # Сущности (Training, Exercise, WorkoutExercise)
├── Repositories/ # Репозитории (ITrainingRepository, TrainingRepository)
├── Services/ # Сервисы (ITrainingService, TrainingService)
├── Pages/ # Blazor компоненты
├── Shared/ # Общие компоненты (MainLayout, NavMenu)
└── wwwroot/ # Статические файлы