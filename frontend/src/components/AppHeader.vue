<template>
  <header>
    <h1>Ремонт оборудования</h1>
    <nav>
      <router-link to="/">Список</router-link>
      <router-link to="/new">Создать</router-link>
      <router-link to="/login">Вход</router-link>
    </nav>
  </header>
</template>

<style scoped>
header {
  border-bottom: 2px solid #ccc;
  margin-bottom: 20px;
  padding-bottom: 10px;
}
nav {
  display: flex;
  gap: 15px;
}
nav a {
  text-decoration: none;
  color: #2c3e50;
  padding: 8px 16px;
  border: 1px solid #ccc;
  border-radius: 4px;
}
nav a:hover {
  background-color: #f0f0f0;
}
nav a.router-link-active {
  background-color: #42b983;
  color: white;
  border-color: #42b983;
}
</style>