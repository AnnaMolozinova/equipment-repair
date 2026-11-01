const delay = (ms) => new Promise((resolve) => setTimeout(resolve, ms))

// Учебные данные, имитирующие базу данных сервера
let mockItems = [
  { id: 1, number: 'A-101', title: 'Насос не запускается', equipmentId: 2, status: 'New' },
  { id: 2, number: 'A-102', title: 'Проверить вентиль', equipmentId: 1, status: 'InProgress' }
]
let nextId = 3

export async function mockGetTickets() {
  await delay(500) // имитация задержки сети
  return { ok: true, status: 200, data: mockItems }
}

export async function mockCreateTicket(body) {
  await delay(500) // имитация задержки сети

  // Проверка на короткую тему (имитация 400 ошибки)
  if (!body.title || body.title.trim().length < 5) {
    return { ok: false, status: 400, data: { message: 'Слишком короткая тема' } }
  }

  // Имитация 500 ошибки (если в теме написать слово "ошибка")
  if (body.title.toLowerCase().includes('ошибка')) {
    return { ok: false, status: 500, data: { message: 'Сервер упал' } }
  }

  const newTicket = {
    id: nextId,
    number: `TMP-${nextId}`,
    title: body.title,
    equipmentId: body.equipmentId,
    description: body.description,
    status: 'New'
  }
  
  mockItems.push(newTicket)
  nextId++

  return { ok: true, status: 201, data: newTicket }
}