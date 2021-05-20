*[Назад](./../README.md)*  
  
### Задание для урока №3
  
- [X] Необходимо реализовать ASP.NET Core MVC приложение 
с разделением логики на уровень контроллеров, сервисов и репозиториев.  
- [X] Для уровня сервисов и репозиториев использовать интерфейсы.  
- [X] Приветствуется соблюдение принципов SOLID, 
а также применение Dependency Injection встроенными средствами платформы ASP.NET Core..  
  
- [X] Предлагается создать api для работы с коллекцией persons:  
  
```cs  
GET /persons/{id} - получение человека по идентификатору  
GET /persons/search?searchTerm={term} - поиск человека по имени  
GET /persons/?skip={5}&take={10} - получение списка людей с пагинацией  
POST /persons - добавление новой персоны в коллекцию  
PUT /persons - обновление существующей персоны в коллекции  
DELETE /persons/{id} - удаление персоны из коллекции  
```  
  
Класс Person:  
```cs
public class Person
{
   public int Id { get; set; }
   public string FirstName { get; set; }
   public string LastName { get; set; }
   public string Email { get; set; }
   public string Company { get; set; }
   public int Age { get; set; }
}
```  
  
**[Набор сгенерированных данных (для репозитория) =>](Docs/task-03_data.md)**  
  
  
---  
  
### Пояснения по выполнению задания  
  
Задание выполнено.  
  
Создано ASP.NET Core приложение, которое реализует заданный API  
  
Запущенное приложение и его API можно увидеть здесь: 
### **[persons.verm-v.ru](persons.verm-v.ru)**  
(Приложение устанавливалось на VPS из Visual Studio, через Web Deploy на IIS)  
  
---  
  
Набор сгенерированных данных для простоты хранится в статическом классе GeneratedData, в обычном списке.  
Доступ к этим данным осуществляется через репозиторий по следующей цепочке:  
  
*PersonController(API) <-> PersonsManager <-> PersonsRepository <-> GeneratedData*  
  
На уровнях менеджера(сервиса) и репозитория используются интерфейсы. Так же все это делается через DI с использованием IServiceCollection  
  
Подключен автомаппер для перевода из DTO в модель Person  
Дополнительно подключено логгирование через NLog  
  
  