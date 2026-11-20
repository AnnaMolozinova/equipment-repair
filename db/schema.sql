-- 1. Удаляем старые таблицы (если есть), чтобы скрипт можно было запускать повторно
DROP TABLE IF EXISTS tickets CASCADE;
DROP TABLE IF EXISTS equipment CASCADE;
DROP TABLE IF EXISTS users CASCADE;

-- 2. Таблица Пользователи
CREATE TABLE users (
    id integer PRIMARY KEY,
    login text NOT NULL UNIQUE,
    full_name text NOT NULL,
    role text NOT NULL CHECK (role IN ('Dispatcher', 'Engineer', 'Manager'))
);

-- 3. Таблица Оборудование (справочник)
CREATE TABLE equipment (
    id integer PRIMARY KEY,
    name text NOT NULL
);

-- 4. Таблица Заявки (главный объект)
CREATE TABLE tickets (
    id integer PRIMARY KEY,
    number text NOT NULL UNIQUE,
    title text NOT NULL CHECK (char_length(title) BETWEEN 5 AND 80),
    description text CHECK (char_length(description) BETWEEN 10 AND 500),
    equipment_id integer NOT NULL REFERENCES equipment (id),
    status text NOT NULL CHECK (status IN ('New', 'InProgress', 'Closed', 'Cancelled')),
    created_at timestamptz NOT NULL DEFAULT now(),
    created_by_user_id integer REFERENCES users (id),
    assignee_user_id integer REFERENCES users (id) NULL
);

-- 5. Индексы
-- Ускоряет фильтрацию списка заявок по статусу (WHERE status = 'New')
CREATE INDEX tickets_status_idx ON tickets (status);
-- Ускоряет соединение заявок с оборудованием (JOIN ON equipment.id = tickets.equipment_id)
CREATE INDEX tickets_equipment_id_idx ON tickets (equipment_id);