<script setup="">
	import { ref } from 'vue'

	// Текущий экран: 'list' | 'new' | 'login'
	const screen = ref('list')

	// Тестовые данные (в ЛР5 заменим на запросы к серверу)
	const items = ref([
	{ id: 1, number: 'A-101', title: 'Насос не запускается', equipmentId: 2, status: 'New' },
	{ id: 2, number: 'A-102', title: 'Проверить вентиль', equipmentId: 1, status: 'InProgress' }
	])
</script>

<template>
	<div class="app-container">
		<header>
			<h1>Ремонт оборудования</h1>
			<nav>
				<button type="button" @click="screen = 'list'">Список</button>
				<button type="button" @click="screen = 'new'">Создать</button>
				<button type="button" @click="screen = 'login'">Вход</button>
			</nav>
		</header>

		<!-- ЭКРАН 1: Список -->
		<main v-if="screen === 'list'">
			<h2>Список заявок</h2>
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
		</main>

		<!-- ЭКРАН 2: Создание -->
		<main v-else-if="screen === 'new'">
			<h2>Создать заявку</h2>
			<form @submit.prevent="">
				<div class="form-group">
					<label for="title">Тема (5–80 символов)</label>
					<input id="title" name="title" type="text" autofocus="" />
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

		<!-- ЭКРАН 3: Вход -->
		<main v-else-if="screen === 'login'">
			<h2>Вход в систему</h2>
			<form @submit.prevent="">
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
	</div>
</template>

<style scoped="">
	.app-container {
	font-family: sans-serif;
	max-width: 800px;
	margin: 0 auto;
	padding: 20px;
	}
	header {
	border-bottom: 2px solid #ccc;
	margin-bottom: 20px;
	}
	nav button {
	margin-right: 10px;
	padding: 8px 16px;
	cursor: pointer;
	}
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