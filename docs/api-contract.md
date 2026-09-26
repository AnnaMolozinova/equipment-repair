# API-контракт

Базовый URL: `http://localhost:5000`

## Таблица эндпоинтов

| Метод и путь | Тело | Успех | Ошибка |
| :--- | :--- | :--- | :--- |
| GET /api/repair-requests | — | 200, массив или [] | — |
| GET /api/repair-requests/{id} | — | 200, объект | 404 |
| POST /api/repair-requests | title, equipmentId, description | 201, id, number, status: New | 400 |
| PATCH /api/repair-requests/{id}/assignee | assigneeUserId | 200 | 404 |
| PATCH /api/repair-requests/{id}/status | status | 200 | 404, 409 |

## Пример тела создания (POST)

```json
{
  "title": "Насос участка Б не запускается",
  "equipmentId": 2,
  "description": "После грозы гудит и встаёт через минуту"
}