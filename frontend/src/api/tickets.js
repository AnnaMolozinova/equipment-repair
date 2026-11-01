import { mockGetTickets, mockCreateTicket } from './mockTickets.js'

const baseUrl = import.meta.env.VITE_API_BASE_URL

// Переключатель: true - используем мок, false - реальный fetch (пригодится в ЛР10)
const USE_MOCK = true

export async function getTickets() {
  if (USE_MOCK) {
    const response = await mockGetTickets()
    if (!response.ok) throw new Error('Ошибка загрузки списка')
    return response.data
  }

  // Настоящий запрос (пока не используется)
  const response = await fetch(`${baseUrl}/api/tickets`)
  if (!response.ok) throw new Error(`HTTP error! status: ${response.status}`)
  return await response.json()
}

export async function createTicket(body) {
  if (USE_MOCK) {
    const response = await mockCreateTicket(body)
    if (!response.ok) {
      // Если это 400, выбрасываем ошибку с кодом, чтобы форма её поймала
      const error = new Error(response.data.message || 'Ошибка сервера')
      error.status = response.status
      throw error
    }
    return response.data
  }

  // Настоящий запрос (пока не используется)
  const response = await fetch(`${baseUrl}/api/tickets`, {
    method: 'POST',
    headers: { 'Content-Type': 'application/json' },
    body: JSON.stringify(body)
  })
  
  if (!response.ok) {
    const error = new Error('Ошибка сервера')
    error.status = response.status
    throw error
  }
  return await response.json()
}