<script setup>
import { ref } from 'vue'
import { useRouter } from 'vue-router'
import { addItem } from '../ticketsStore.js'

const router = useRouter()

// Объект формы
const form = ref({
  title: '',
  equipmentId: 0,
  description: ''
})

// Объект для ошибок
const errors = ref({
  title: '',
  equipmentId: '',
  description: ''
})

function onCreate() {
  // Сбрасываем старые ошибки
  errors.value = { title: '', equipmentId: '', description: '' }
  let isValid = true

  // Проверка темы (5-80 символов)
  const cleanTitle = form.value.title.trim()
  if (cleanTitle.length < 5 || cleanTitle.length > 80) {
    errors.value.title = 'Тема: от 5 до 80 символов'
    isValid = false
  }

  // Проверка оборудования (целое число > 0)
  if (form.value.equipmentId <= 0) {
    errors.value.equipmentId = 'Укажите номер оборудования (больше 0)'
    isValid = false
  }

  // Проверка описания (10-500 символов)
  const cleanDesc = form.value.description.trim()
  if (cleanDesc.length < 10 || cleanDesc.length > 500) {
    errors.value.description = 'Описание: от 10 до 500 символов'
    isValid = false
  }

  // Если есть ошибки — останавливаемся
  if (!isValid) return

  // Добавляем запись в общий массив
  addItem(cleanTitle, form.value.equipmentId, cleanDesc)

  // Очищаем форму
  form.value = { title: '', equipmentId: 0, description: '' }

  // Переходим на список
  router.push('/')
}
</script>

<template>
  <main>
    <h2>Создать заявку</h2>
    <form @submit.prevent="onCreate">
      
      <div class="form-group">
        <label for="title">Тема (5–80 символов)</label>
        <input id="title" name="title" type="text" v-model="form.title" autofocus />
        <span class="error" v-if="errors.title">{{ errors.title }}</span>
      </div>
      
      <div class="form-group">
        <label for="equipmentId">Номер оборудования</label>
        <input id="equipmentId" name="equipmentId" type="number" v-model.number="form.equipmentId" />
        <span class="error" v-if="errors.equipmentId">{{ errors.equipmentId }}</span>
      </div>
      
      <div class="form-group">
        <label for="description">Описание (10–500 символов)</label>
        <textarea id="description" name="description" rows="4" v-model="form.description"></textarea>
        <span class="error" v-if="errors.description">{{ errors.description }}</span>
      </div>
      
      <button type="submit">Создать</button>
    </form>
  </main>
</template>

<style scoped>
.form-group {
  margin-bottom: 15px;
  display: flex;
  flex-direction: column;
}
.form-group label {
  margin-bottom: 5px;
  font-weight: bold;
}
input, textarea {
  padding: 8px;
  border: 1px solid #ccc;
  border-radius: 4px;
}
button[type="submit"] {
  padding: 10px 20px;
  background-color: #42b983;
  color: white;
  border: none;
  border-radius: 4px;
  cursor: pointer;
}
.error {
  color: red;
  font-size: 0.9em;
  margin-top: 4px;
}
</style>