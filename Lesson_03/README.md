*[�����](./../README.md)*  
  
### ������� ��� ����� �3
  
- [ ] ���������� ����������� ASP.NET Core MVC ���������� 
� ����������� ������ �� ������� ������������, �������� � ������������.  
- [ ] ��� ������ �������� � ������������ ������������ ����������.  
- [ ] �������������� ���������� ��������� SOLID, 
� ����� ���������� Dependency Injection ����������� ���������� ��������� ASP.NET Core..  
  
- [ ] ������������ ������� api ��� ������ � ���������� persons:  
  
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
  
    