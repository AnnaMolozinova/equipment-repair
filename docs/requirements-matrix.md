# Матрица требований

| Требование ЛР1 | Поле или сущность | Запрос | Критерий |
| :--- | :--- | :--- | :--- |
| Диспетчер создаёт заявку | RepairRequest, title, equipmentId, description | POST /api/repair-requests | 1 |
| Руководитель назначает инженера | assigneeUserId | PATCH /api/repair-requests/{id}/assignee | 2 |
| Инженер переводит в работу | status | PATCH /api/repair-requests/{id}/status | 3 |
