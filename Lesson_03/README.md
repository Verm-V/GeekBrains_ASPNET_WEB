*[�����](./../README.md)*  
  
### ������� ��� ����� �3
  
- [X] ���������� ����������� ASP.NET Core MVC ���������� 
� ����������� ������ �� ������� ������������, �������� � ������������.  
- [X] ��� ������ �������� � ������������ ������������ ����������.  
- [X] �������������� ���������� ��������� SOLID, 
� ����� ���������� Dependency Injection ����������� ���������� ��������� ASP.NET Core..  
  
- [X] ������������ ������� api ��� ������ � ���������� persons:  
  
```cs  
GET /persons/{id} - ��������� �������� �� ��������������  
GET /persons/search?searchTerm={term} - ����� �������� �� �����  
GET /persons/?skip={5}&take={10} - ��������� ������ ����� � ����������  
POST /persons - ���������� ����� ������� � ���������  
PUT /persons - ���������� ������������ ������� � ���������  
DELETE /persons/{id} - �������� ������� �� ���������  
```  
  
����� Person:  
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
  
**[����� ��������������� ������ (��� �����������) =>](Docs/task-03_data.md)**  
  
  
---  
  
### ��������� �� ���������� �������  
  
������� ���������.  
  
������� ASP.NET Core ����������, ������� ��������� �������� API  
  
���������� ���������� � ��� API ����� ������� �����: 
### **[persons.verm-v.ru](persons.verm-v.ru)**  
(���������� ��������������� �� VPS �� Visual Studio, ����� Web Deploy �� IIS)  
  
---  
  
����� ��������������� ������ ��� �������� �������� � ����������� ������ GeneratedData, � ������� ������.  
������ � ���� ������ �������������� ����� ����������� �� ��������� �������:  
  
*PersonController(API) <-> PersonsManager <-> PersonsRepository <-> GeneratedData*  
  
�� ������� ���������(�������) � ����������� ������������ ����������. ��� �� ��� ��� �������� ����� DI � �������������� IServiceCollection  
  
��������� ���������� ��� �������� �� DTO � ������ Person  
������������� ���������� ������������ ����� NLog  
  
  