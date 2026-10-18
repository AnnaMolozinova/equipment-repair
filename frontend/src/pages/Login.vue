<template>
  <main>
    <h2>Вход в систему</h2>
    <form @submit.prevent>
      <div class="form-group">
        <label for="login">Логин</label>
        <input id="login" name="login" type="text" />
      </div>
      
      <div class="form-group">
        <label for="password">Пароль</label>
        <input id="password" name="password" type="password" />
      </div>
      
      <button type="submit">Войти</button>
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
input {
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