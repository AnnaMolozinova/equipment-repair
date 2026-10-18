<script setup>
defineProps({
  items: { type: Array, required: true }
})
</script>

<template>
  <table>
    <thead>
      <tr>
        <th>Номер</th>
        <th>Тема</th>
        <th>Оборудование (ID)</th>
        <th>Статус</th>
      </tr>
    </thead>
    <tbody>
      <tr v-for="item in items" :key="item.id">
        <td>{{ item.number }}</td>
        <td>{{ item.title }}</td>
        <td>{{ item.equipmentId }}</td>
        <td>{{ item.status }}</td>
      </tr>
    </tbody>
  </table>
</template>

<style scoped>
table {
  width: 100%;
  border-collapse: collapse;
  margin-top: 10px;
}
th, td {
  border: 1px solid #ddd;
  padding: 8px;
  text-align: left;
}
th {
  background-color: #f4f4f4;
}
</style>