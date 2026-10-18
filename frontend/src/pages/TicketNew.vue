<template>
  <main>
    <h2>Создать заявку</h2>
    <form @submit.prevent>
      <div class="form-group">
        <label for="title">Тема (5–80 символов)</label>
        <input id="title" name="title" type="text" autofocus />
      </div>
      
      <div class="form-group">
        <label for="equipmentId">Номер оборудования</label>
        <input id="equipmentId" name="equipmentId" type="number" />
      </div>
      
      <div class="form-group">
        <label for="description">Описание (10–500 символов)</label>
        <textarea id="description" name="description" rows="4"></textarea>
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
</style>