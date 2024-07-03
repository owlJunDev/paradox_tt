# paradox_tt

## Инструкция по запуску тестового задания
### Настройка окружения для Ubuntu 22.04
1. `sudo apt update`
2. установка [.Net 7](https://dotnet.microsoft.com/en-us/download/dotnet/7.0): 
    * `sudo apt install -y dotnet-sdk-7.0`
3. установка [PostgreSQL 16](https://www.postgresql.org/download/): 
    * `sudo sh -c 'echo "deb http://apt.postgresql.org/pub/repos/apt $(lsb_release -cs)-pgdg main" > /etc/apt/sources.list.d/pgdg.list'`
    * `curl -fsSL https://www.postgresql.org/media/keys/ACCC4CF8.asc | sudo gpg --dearmor -o /etc/apt/trusted.gpg.d/postgresql.gpg`
    * `sudo apt update`
    * `sudo apt install postgresql-16`
4. `sudo apt update`
5. запуск PostgreSQL: 
    * `sudo service postgresql start`
6. вход в БД psql через пользователя по умолчанию: 
    * `sudo -u postgres psql`
7. изменение пароля у пользователя по умолчанию: 
    * `ALTER USER postgres WITH PASSWORD 'postgres';`
### установка и запуск проекта
 
1. `git clone https://github.com/owlJunDev/paradox_tt.git`
2. `cd paradox_tt/Backend`
3. `dotnet tool install --global dotnet-ef --version 7.0`
4. `export PATH="$PATH:$HOME/.dotnet/tools/"`
5. `dotnet build`
6. `dotnet ef database update`
7. `dotnet run`

### ссылка для перехода в swagger: 
    http://localhost:5000/swagger/index.html
### примеры фильтрации используя запросы через oData:
* [выборка по дате](http://localhost:5000/api/note/?$filter=date(dateCreate)%20eq%202024-04-21)
* [выборка по названия](http://localhost:5000/api/note/?$filter=title%20eq%20%27title%27)
* [выборка по дате и названию](http://localhost:5000/api/note/?$filter=title%20eq%20%27string%27%20and%20date(dateCreate)%20eq%202024-04-21)
* [выборка по тегу](http://localhost:5000/api/note?$select=title,content&$filter=Tags/any(t:%20t/id%20eq%203))