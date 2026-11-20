-- 1. Фильтр и сортировка (все новые заявки)
SELECT number, title, status, created_at
FROM tickets
WHERE status = 'New'
ORDER BY created_at DESC;

-- 2. JOIN (заявки с названием оборудования)
SELECT t.number, t.title, e.name AS equipment_name, t.status
FROM tickets AS t
JOIN equipment AS e ON e.id = t.equipment_id
ORDER BY t.created_at DESC;

-- 3. GROUP BY (подсчет заявок по статусам)
SELECT status, COUNT(*) AS count
FROM tickets
GROUP BY status
ORDER BY status;