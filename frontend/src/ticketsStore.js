import { ref } from 'vue'

export const items = ref([
  { id: 1, number: 'A-101', title: 'Насос не запускается', equipmentId: 2, status: 'New' },
  { id: 2, number: 'A-102', title: 'Проверить вентиль', equipmentId: 1, status: 'InProgress' }
])

// Счётчик для новых заявок
export let nextId = 3

// Функция добавления новой заявки
export function addItem(title, equipmentId, description) {
  items.value.push({
    id: nextId,
    number: `TMP-${nextId}`,
    title: title,
    equipmentId: equipmentId,
    description: description,
    status: 'New'
  })
  nextId++
}