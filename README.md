# Система заявок на ремонт оборудования участка

**Студент:** Молозинова Анна
**Группа:** ТРИС-3-23

**Стек:** Vue 3 + ASP.NET Core + PostgreSQL

**Статус темы:** На проверке

## Документы

- [Заявка на тему](docs/project-proposal.md)
- [Требования](docs/lab-01-requirements.md)
- [Архитектура](docs/architecture.md)
- [Модель данных](docs/data-model.md)
- [API-контракт](docs/api-contract.md)
- [Матрица требований](docs/requirements-matrix.md)

## Запуск клиента (Frontend)

Для работы нужен **Node.js LTS**.

```bash
cd frontend
npm install
npm run dev
```
Открыть адрес, который напишет терминал (обычно http://localhost:5173).
## Запуск бэкенда (Backend)

Для запуска нужен **.NET SDK 8.0 или новее**.

```bash
cd backend
dotnet restore
dotnet run

- API: http://localhost:5000
- Документация (Scalar/Swagger): http://localhost:5000/scalar/v1
- Проверка живости: http://localhost:5000/health

**Важно:** данные заявок пока хранятся только в памяти, после перезапуска сервера они пропадут. `/health` проверяет только живость процесса, настоящее создание заявок появится в ЛР8.