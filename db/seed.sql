-- Добавляем пользователей
INSERT INTO users (id, login, full_name, role) VALUES
(1, 'dispatcher1', 'Иванов Иван', 'Dispatcher'),
(2, 'engineer1', 'Петров Петр', 'Engineer'),
(3, 'manager1', 'Сидоров Сидор', 'Manager');

-- Добавляем оборудование
INSERT INTO equipment (id, name) VALUES
(1, 'Станок фрезерный'),
(2, 'Насос водяной');

-- Добавляем заявки (во всех четырех статусах)
INSERT INTO tickets (id, number, title, description, equipment_id, status, created_by_user_id, assignee_user_id) VALUES
(1, 'REP-001', 'Станок не включается', 'При нажатии на кнопку пуск ничего не происходит', 1, 'New', 1, NULL),
(2, 'REP-002', 'Насос шумит', 'При работе издает сильный гул и вибрацию', 2, 'InProgress', 1, 2),
(3, 'REP-003', 'Замена ремня', 'Требуется плановая замена приводного ремня', 1, 'Closed', 1, 2),
(4, 'REP-004', 'Течь масла', 'Обнаружена течь масла на гидростанции', 2, 'Cancelled', 1, NULL);