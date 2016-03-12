# DrinkOrder
В проекте реализован минимально необходимый (на мой взгляд) функционал.
Источник данных - файлы drinks.txt (список напитков) и Additives.txt (список добавок).
Каждый файл содержит записи 'id;name;price'. Если запись не парсится в корректные данные, то она игнорируется.

Что можно было бы добавить:
- Возможность локализации
- Цвета интерфейса
- Повторная печать списка напитков и добавок
- Инструмент добавления данных (или полноценная база данных на чём-нибудь типа PostgreSQL)
- Запись ошибок в лог (например, используя NLog)