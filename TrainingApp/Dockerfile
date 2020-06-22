FROM mcr.microsoft.com/dotnet/core/sdk:latest AS build
WORKDIR /app
COPY . .
RUN dotnet restore
WORKDIR /app/WebApp
RUN dotnet publish -c Release -o out
FROM mcr.microsoft.com/dotnet/core/aspnet:latest AS runtime
WORKDIR /app
EXPOSE 80
ENV ConnectionStrings:SqlServerConnection="Server=alpha.akaver.com,1533;User Id=student;Password=Student.Bad.password.0;Database=krruub_2020;MultipleActiveResultSets=true"
COPY --from=build /app/WebApp/out ./
ENTRYPOINT ["dotnet", "WebApp.dll"]
