# paradox_tt
1. установить версию .Net 7
    * `https://dotnet.microsoft.com/en-us/download/dotnet/7.0`
2. зайти через консоль в папку 
     * `paradox_tt/Backend`
3. ввести следующие команды: 
    * `dotnet build`
    * `dotnet ef database update`
    * `dotnet run`

4. ссылка для перехода в swagger
    * `http://localhost:5000/swagger/index.html`
5. примеры фильтрации используя запросы через oData:
    * `http://localhost:5000/api/note/?$filter=date(dateCreate) eq 2024-04-21`
    * `http://localhost:5000/api/note/?$filter=title eq 'string'`
    * `http://localhost:5000/api/note/?$filter=title eq 'string' and date(dateCreate) eq 2024-04-21`