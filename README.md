# Task
Write console app which calculates total price of drink with extras.

Drinks:
1) Coffee - Id - 1; - Price $15
2) Tea - Id - 2; - Price $10

Extras:
1) Milk - Id - 1; - Price $2
2) Sugar - Id - 2; - Price $1
3) Cinnamon - Id - 3; - Price $3
4) Lemon - Id - 4; - Price $1
Input is ID of drink at first, then comma-separated IDs of extras.
Output is total price.

Example:
Input drink: 1
Input extras: 2,3,2
Total: $20

Please mind the incorrect input, extensibility (adding drinks and/or extras, database etc)

# Result
Project contains minimal required functionlaity.
Data source - files drinks.txt (drink list) и Additives.txt (extras list).
Each file contains records 'id;name;price'. If record cannot be parsed, it is ignored.

Also, excessive class structure added to enable quick replacement of data source.

Further enhancements:
- Internationalization
- Interface colors
- Repeat output of drinks and extras 
- Data edit tool (or database using something SQLite or PostgreSQL)
- Error logging (e.g. using NLog)

# DrinkOrder
В проекте реализован минимально необходимый (на мой взгляд) функционал.
Источник данных - файлы drinks.txt (список напитков) и Additives.txt (список добавок).
Каждый файл содержит записи 'id;name;price'. Если запись не парсится в корректные данные, то она игнорируется.

Добавлена избыточная в данном случае, но полезная структура классов для быстрой замены источника данных.

Что можно было бы добавить:
- Возможность локализации
- Цвета интерфейса
- Повторная печать списка напитков и добавок
- Инструмент добавления данных (или полноценная база данных на чём-нибудь типа PostgreSQL)
- Запись ошибок в лог (например, используя NLog)