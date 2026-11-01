<script setup>
import { ref } from 'vue'
import { useRouter } from 'vue-router'
import { createTicket } from '../api/tickets.js'

const router = useRouter()

const form = ref({
  title: '',
  equipmentId: 0,
  description: ''
})

const errors = ref({
  title: '',
  equipmentId: '',
  description: '',
  server: '' // Для общих ошибок сервера
})

const isSubmitting = ref(false)

async function onCreate() {
  if (isSubmitting.value) return // Защита от двойного клика

  // Сбрасываем ошибки
  errors.value = { title: '', equipmentId: '', description: '', server: '' }
  let isValid = true

  // Клиентская валидация
  const cleanTitle = form.value.title.trim()
  if (cleanTitle.length < 5 || cleanTitle.length > 80) {
    errors.value.title = 'Тема: от 5 до 80 символов'
    isValid = false
  }

  if (form.value.equipmentId <= 0) {
    errors.value.equipmentId = 'Укажите номер оборудования (больше 0)'
    isValid = false
  }

  const cleanDesc = form.value.description.trim()
  if (cleanDesc.length < 10 || cleanDesc.length > 500) {
    errors.value.description = 'Описание: от 10 до 500 символов'
    isValid = false
  }

  if (!isValid) return

  // Отправка на сервер (мок)
  isSubmitting.value = true
  try {
    await createTicket({
      title: cleanTitle,
      equipmentId: form.value.equipmentId,
      description: cleanDesc
    })
    
    // Успех — переходим на список
    router.push('/')
  } catch (err) {
    // Обработка ошибок сервера
    if (err.status === 400) {
      errors.value.server = 'Проверьте правильность заполнения полей.'
    } else if (err.status === 500) {
      errors.value.server = 'Сервер не смог обработать запрос (500).'
    } else {
      errors.value.server = 'Нет связи с сервером. Проверьте подключение.'
    }
  } finally {
    isSubmitting.value = false // Снимаем блокировку в любом случае
  }
}
</script>

<template>
  <main>
    <h2>Создать заявку</h2>
    
    <!-- Плашка с общей ошибкой сервера -->
    <div v-if="errors.server" class="server-error">
      {{ errors.server }}
    </div>

    <form @submit.prevent="onCreate">
      
      <div class="form-group">
        <label for="title">Тема (5–80 символов)</label>
        <input id="title" name="title" type="text" v-model="form.title" autofocus :disabled="isSubmitting" />
        <span class="error" v-if="errors.title">{{ errors.title }}</span>
      </div>
      
      <div class="form-group">
        <label for="equipmentId">Номер оборудования</label>
        <input id="equipmentId" name="equipmentId" type="number" v-model.number="form.equipmentId" :disabled="isSubmitting" />
        <span class="error" v-if="errors.equipmentId">{{ errors.equipmentId }}</span>
      </div>
      
      <div class="form-group">
        <label for="description">Описание (10–500 символов)</label>
        <textarea id="description" name="description" rows="4" v-model="form.description" :disabled="isSubmitting"></textarea>
        <span class="error" v-if="errors.description">{{ errors.description }}</span>
      </div>
      
      <button type="submit" :disabled="isSubmitting">
        {{ isSubmitting ? 'Создаём...' : 'Создать' }}
      </button>
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
button[type="submit"]:disabled {
  background-color: #a0d4b8;
  cursor: not-allowed;
}
.error {
  color: red;
  font-size: 0.9em;
  margin-top: 4px;
}
.server-error {
  padding: 10px;
  background-color: #ffe6e6;
  color: #cc0000;
  border: 1px solid #cc0000;
  border-radius: 4px;
  margin-bottom: 15px;
}
</style>