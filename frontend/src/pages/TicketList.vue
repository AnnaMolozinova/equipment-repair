<script setup>
import { items } from '../ticketsStore.js'
import TicketTable from '../components/TicketTable.vue'
</script>

<template>
  <main>
    <h2>Список заявок</h2>
    <TicketTable :items="items" />
  </main>
</template>