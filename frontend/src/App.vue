<script setup="">
	import AppHeader from './components/AppHeader.vue'
</script>

<template>
	<div class="app-container">
		<AppHeader />
		<router-view />
	</div>
</template>

<style>
	body {
	font-family: sans-serif;
	margin: 0;
	padding: 0;
	}
	.app-container {
	max-width: 800px;
	margin: 0 auto;
	padding: 20px;
	}
</style>