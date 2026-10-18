import { ref } from 'vue'

export const items = ref([
  { id: 1, number: 'A-101', title: 'Насос не запускается', equipmentId: 2, status: 'New' },
  { id: 2, number: 'A-102', title: 'Проверить вентиль', equipmentId: 1, status: 'InProgress' }
])