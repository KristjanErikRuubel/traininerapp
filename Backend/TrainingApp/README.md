 #WebApp

Databases used in project
~~~
"MySqlConnection": "server=alpha.akaver.com;database=student2018_krruub;user=student2018;password=student2018",
"MsSqlConnection": "Server=alpha.akaver.com,1533;User Id=SA;Password=Admin.TalTech.1;Database=krruub_2020;MultipleActiveResultSets=true",
"MySqlLocalDbConnection": "Server=localhost:3306/;database=training-app;user=root;password=root"
~~~

Generate Identity UI Razor Pages (inside WebApp)
~~~
dotnet aspnet-codegenerator identity -dc DAL.App.EF.AppDbContext -f
~~~
~~~
dotnet ef migrations add InitialDbCreation --project DAL.App.EF --startup-project WebApp --context AppDbContext
dotnet ef database update --project DAL.App.EF --startup-project WebApp --context AppDbContext
dotnet ef database drop --project DAL.App.EF --startup-project WebApp --context AppDbContext
~~~

 ###Run in WebApp folder
API controller generation
~~~
dotnet aspnet-codegenerator controller -name BillController          -actions -m Bill          -dc AppDbContext -outDir ApiControllers -api --useAsyncActions  -f
dotnet aspnet-codegenerator controller -name NotificationController       -actions -m Notification        -dc AppDbContext -outDir ApiControllers -api --useAsyncActions  -f
dotnet aspnet-codegenerator controller -name NotificationAnswerController   -actions -m NotificationAnswer   -dc AppDbContext -outDir ApiControllers -api --useAsyncActions  -f
dotnet aspnet-codegenerator controller -name PersonController   -actions -m Person   -dc AppDbContext -outDir ApiControllers -api --useAsyncActions  -f
dotnet aspnet-codegenerator controller -name PersonInTeamController   -actions -dc AppDbContext -outDir ApiControllers -api --useAsyncActions  -f
dotnet aspnet-codegenerator controller -name UserInTrainingController   -actions -m UserInTraining -dc AppDbContext -outDir ApiControllers -api --useAsyncActions  -f
dotnet aspnet-codegenerator controller -name PersonInvitedToTrainingController  -dc AppDbContext -outDir ApiControllers -api --useAsyncActions  -f
dotnet aspnet-codegenerator controller -name TeamController  -actions -m Team   -dc AppDbContext -outDir ApiControllers -api --useAsyncActions  -f
dotnet aspnet-codegenerator controller -name TrainingController  -actions -m Training   -dc AppDbContext -outDir ApiControllers -api --useAsyncActions  -f
dotnet aspnet-codegenerator controller -name UserRoleInTeamController  -actions -m TrainingPlace -dc AppDbContext -outDir ApiControllers -api --useAsyncActions  -f
dotnet aspnet-codegenerator controller -name PlayerPositionController  -actions -m PlayerPosition -dc AppDbContext -outDir ApiControllers -api --useAsyncActions  -f
~~~
Aspnet controllers
~~~
dotnet aspnet-codegenerator controller -name BillController          -actions -m Bill          -dc AppDbContext -outDir Controllers --useDefaultLayout --useAsyncActions --referenceScriptLibraries -f
dotnet aspnet-codegenerator controller -name NotificationController -actions -m Notification -dc AppDbContext -outDir Controllers --useDefaultLayout --useAsyncActions --referenceScriptLibraries -f
dotnet aspnet-codegenerator controller -name NotificationAnswerController   -actions -m NotificationAnswer   -dc AppDbContext -outDir Controllers --useDefaultLayout --useAsyncActions --referenceScriptLibraries -f
dotnet aspnet-codegenerator controller -name PersonInTeamController   -actions -m PersonInTeam   -dc AppDbContext -outDir Controllers --useDefaultLayout --useAsyncActions --referenceScriptLibraries -f
dotnet aspnet-codegenerator controller -name UserInTrainingController   -actions -m UserInTraining   -dc AppDbContext -outDir Controllers --useDefaultLayout --useAsyncActions --referenceScriptLibraries -f
dotnet aspnet-codegenerator controller -name PersonInvitedToTrainingController   -actions -m PersonInvitedToTraining   -dc AppDbContext -outDir Controllers --useDefaultLayout --useAsyncActions --referenceScriptLibraries -f
dotnet aspnet-codegenerator controller -name TeamController  -actions -m Team   -dc AppDbContext -outDir Controllers --useDefaultLayout --useAsyncActions --referenceScriptLibraries -f
dotnet aspnet-codegenerator controller -name TrainingController  -actions -m Training   -dc AppDbContext -outDir Controllers --useDefaultLayout --useAsyncActions --referenceScriptLibraries -f
dotnet aspnet-codegenerator controller -name TrainingPlaceController  -actions -m TrainingPlace   -dc AppDbContext -outDir Controllers --useDefaultLayout --useAsyncActions --referenceScriptLibraries -f
dotnet aspnet-codegenerator controller -name PlayerPositionController  -actions -m PlayerPosition -dc AppDbContext -outDir Controllers --useDefaultLayout --useAsyncActions --referenceScriptLibraries -f
~~~