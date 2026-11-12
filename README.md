# UniversityDbApp

3-апта лабораториялық жұмысы: ASP.NET Core MVC, .NET 8, EF Core 8 және MS SQL Server LocalDB арқылы Code-First миграциясын тексеру.

## Жобаны ашу және дерекқорды жасау

1. Visual Studio 2022 бағдарламасында түбірдегі `UniversityDbApp.sln` файлын ашыңыз.
2. **Tools > NuGet Package Manager > Package Manager Console** тармағын таңдаңыз.
3. Package Manager Console терезесіндегі **Default project** тізімінен `UniversityDbApp` таңдаңыз.
4. Жобаға бастапқы `InitialDb` миграциясы қосылған. Қаласаңыз, миграция тарихын Package Manager Console арқылы тексеріңіз:

   ```powershell
   PM> Get-Migration
   ```

5. LocalDB дерекқорын құрып, миграцияны қолданыңыз:

   ```powershell
   PM> Update-Database
   ```

   Командаларды орындау кезінде `UniversityDbApp` жобасы таңдалғанын және Visual Studio-де startup project ретінде белгіленгенін тексеріңіз. Қосымша, сайт іске қосылғанда қолда бар миграциялар автоматты түрде қолданылады. Модельге кейін өзгеріс енгізсеңіз, жаңа миграцияны `Add-Migration ӨзгерісАтауы` командасымен құрып, `Update-Database` командасын орындаңыз.

## SQL Server Object Explorer және скриншот

1. **View > SQL Server Object Explorer** терезесін ашыңыз.
2. `(localdb)\MSSQLLocalDB` серверін ашыңыз. Сервер көрінбесе, SQL Server түйінін оң жақ батырмамен шертіп, **Add SQL Server** арқылы `(localdb)\MSSQLLocalDB` қосыңыз.
3. **Databases > UniversityDb > Tables** тармағын кеңейтіңіз.
4. `dbo.Departments`, `dbo.Teachers` және EF Core құрған `dbo.__EFMigrationsHistory` кестелері бар екенін тексеріңіз. `dbo.Teachers` кестесін оң жақ батырмамен шертіп, **View Data** таңдасаңыз, бастапқы оқытушылар деректері көрінеді.
5. Скриншот авахын тулд кестелер харагдаж байгаа SQL Server Object Explorer цонхыг тохируулж, **Win + Shift + S** басыңыз; хэсгийг сонгон зураг авна. Скриншотыг лабораторийн тайлан эсвэл GitHub репозиторийн холбогдох хэсэгт оруулна.

## Жобаны іске қосу

Миграцияны қолданғаннан кейін Visual Studio-де **F5** басыңыз. Басты бетте екі кафедра және оларға тіркелген оқытушылар көрсетіледі. **Оқытушы қосу** батырмасын басып, аты-жөнін, электрондық поштасын және кафедрасын толтырып, **Сақтау** батырмасын басыңыз.

Қосылым жолы `appsettings.json` ішінде LocalDB пайдалануға бапталған:

```text
Server=(localdb)\MSSQLLocalDB;Database=UniversityDb;Trusted_Connection=True;MultipleActiveResultSets=true;TrustServerCertificate=True
```

## GitHub репозиторийіне жіберу

GitHub сайтында бос репозиторий жасаңыз. Төмендегі `<GitHub-репозиторий-URL>` орнына сол репозиторийдің нақты HTTPS URL мекенжайын қойыңыз:

```powershell
git init
git add .
git commit -m "UniversityDbApp лабораториялық жұмысын қосу"
git branch -M main
git remote add origin <GitHub-репозиторий-URL>
git push -u origin main
```

Репозиторийге скриншотты жүктеу үшін сурет файлын жобаға, мысалы `screenshots` қалтасына қосып, қайтадан `git add .`, `git commit` және `git push` командаларын орындаңыз.
