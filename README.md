# Формулировка задания
Разработать кроссплатформенное клиент-серверное приложение.
Серверное приложение отправляет текстовые сообщения в клиентское приложение.
Содержимое сообщения должно варьироваться от следующих условий: если чисел в дате и времени (с точностью до секунд), установленных на сервере, в момент отправки:

● больше четных, то отправляем сообщение «чет!»;

● больше нечетных — «нечет!»;

● при равном значении четных и нечетных чисел — «равно!».

Клиентское приложение подключается к серверу по сети и начинает отображать полученные сообщения.
![{37803181-473F-43CD-8F2A-8E066560A34B}](https://github.com/user-attachments/assets/c7add405-51ec-45c8-a264-9801af2a1190)

# Описание проекта
Приложение на ASP.NET, которое использует SignalR для отправки сообщений. Фоновая задача каждые 3 сек отправляет подключенным клиентам датувремя + сообщение о четности.

# GitHub Actions
При пуше в main выполняется прогон тестов и сборка+публикация docker образа.

# Запуск приложения
### Запуск опубликованного контейнера:

`docker run -d -p 80:80 sergeinevolin/datetimesender:latest`

и смотреть на `http://localhost/index.html`

### Локальный запуск:
1. Выгрузить себе репозиторий
2. Сбилдить контейнер `docker build -t datetime-sender .`
3. Запустить `docker run -p 5000:8080 datetime-sender` и смотреть на `http://localhost:5000/index.html`
