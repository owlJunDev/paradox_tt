# paradox_tt
1. установить версию [.Net 7](https://dotnet.microsoft.com/en-us/download/dotnet/7.0) и [PostgreSQL](https://www.postgresql.org/download/)
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
    * `dotnet ef database update`
    * `dotnet run`

4. ссылка для перехода в swagger: http://localhost:5000/swagger/index.html
5. примеры фильтрации используя запросы через oData:
    * `http://localhost:5000/api/note/?$filter=date(dateCreate) eq 2024-04-21`
    * `http://localhost:5000/api/note/?$filter=title eq 'string'`
    * `http://localhost:5000/api/note/?$filter=title eq 'string' and date(dateCreate) eq 2024-04-21`