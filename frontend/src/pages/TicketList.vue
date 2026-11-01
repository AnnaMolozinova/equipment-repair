<script setup>
import { ref, onMounted } from 'vue'
import { items } from '../ticketsStore.js'
import { getTickets } from '../api/tickets.js'
import TicketTable from '../components/TicketTable.vue'

// Состояния: 'loading', 'empty', 'data', 'error'
const screen = ref('loading')
const errorMessage = ref('')

async function loadData() {
  screen.value = 'loading'
  errorMessage.value = ''
  
  try {
    const data = await getTickets()
    items.value = data // Обновляем глобальный массив
    
    if (data.length === 0) {
      screen.value = 'empty'
    } else {
      screen.value = 'data'
    }
  } catch (err) {
    screen.value = 'error'
    errorMessage.value = err.message || 'Нет связи с сервером'
  }
}

// Запускаем загрузку при открытии страницы
onMounted(() => {
  loadData()
})
</script>

<template>
  <main>
    <h2>Список заявок</h2>

    <!-- Состояние загрузки -->
    <div v-if="screen === 'loading'" class="state-msg">
      Загрузка...
    </div>

    <!-- Состояние ошибки -->
    <div v-else-if="screen === 'error'" class="state-msg error">
      Ошибка: {{ errorMessage }}
    </div>

    <!-- Состояние пустого списка -->
    <div v-else-if="screen === 'empty'" class="state-msg">
      Записей пока нет.
    </div>

    <!-- Состояние с данными -->
    <div v-else-if="screen === 'data'">
      <TicketTable :items="items" />
    </div>
  </main>
</template>

<style scoped>
.state-msg {
  padding: 20px;
  background-color: #f0f0f0;
  border-radius: 4px;
  text-align: center;
  margin-top: 20px;
}
.error {
  background-color: #ffe6e6;
  color: #cc0000;
}
</style>