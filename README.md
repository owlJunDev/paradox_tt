# paradox_tt

## Инструкция по запуску тестового задания
1. Настройка окружения
    * установка git: `sudo apt install git` 
    * `sudo apt update`
    * `sudo apt update`
    * установка .Net 7: `sudo apt install -y dotnet-sdk-7.0`
    * установка PostgreSQL: `sudo apt install postgresql`
    * вход в БД psql через пользователя по умолчанию: `sudo -u postgres psql`
    * изменение пароля у пользователя по умолчанию: `ALTER USER postgres WITH PASSWORD 'postgres';`
2. 
    * `git clone`
    * `cd paradox_tt/Backend`
    * `dotnet tool install --global dotnet-ef --version 7.0`
    * `dotnet build`
    * `export PATH="$PATH:$HOME/.dotnet/tools/"`
    * `dotnet ef database update`
    * `dotnet run`

3. ссылка для перехода в swagger: http://localhost:5000/swagger/index.html
4. примеры фильтрации используя запросы через oData:
    * [выборка по дате](http://localhost:5000/api/note/?$filter=date(dateCreate)%20eq%202024-04-21)
    * [выборка по названия](http://localhost:5000/api/note/?$filter=title%20eq%20%27title%27)
    * [выборка по дате и названию](http://localhost:5000/api/note/?$filter=title%20eq%20%27string%27%20and%20date(dateCreate)%20eq%202024-04-21)
    * [выборка по тегу](http://localhost:5000/api/note?$select=title,content&$filter=Tags/any(t:%20t/id%20eq%203))





<!-- 1. установить версию [.Net 7](https://dotnet.microsoft.com/en-us/download/dotnet/7.0) и [PostgreSQL](https://www.postgresql.org/download/)
    ## 
    В проекте используются параметры для подключени к бд по умолчанию, для изменения параметров внести изменения в [файле](/paradox_tt/Backend/appsettings.json)
    ## настройка подключения к установленной бд
    * из под windows 10
    * из под ubuntu 22.04 
        1. вход: `sudo -u postgres psql`
        2. изменение пароля у пользователя по умолчанию: `ALTER USER postgres WITH PASSWORD 'postgres';`
        3. создание нового супер аользователя: `CREATE USER username WITH PASSWORD 'password' SUPERUSER;`

2. зайти через консоль в папку 
     * `paradox_tt/Backend`
3. ввести следующие команды: 
    * `dotnet tool install --global dotnet-ef`
    * `dotnet build`
    * `dotnet ef migrations add init`
    * `dotnet ef database update`
    * `dotnet run` -->

