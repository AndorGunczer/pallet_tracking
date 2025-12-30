
EF erstellt die Datenbank durch die folgende Kommandos:
    dotnet ef migrations add InitialCreate
    dotnet ef database update

Um die Lösung zu bauen und ausführen/starten
    dotnet clean
    dotnet restore
    dotnet build

Wenn du Dotnet Modul installieren möchtest:
    dotnet add package Npgsql.EntityFrameworkCore.PostgreSQL --version 8.0.7

Es kann Unterschied zwischen Host Dotnet Version und Projekt version geben. (Dann muss man einige Module selbst installieren)

Module:
    Npgsql.EntityFrameworkCore.PostgreSQL
    Microsoft.AspNetCore.SignalR.Core


brew tap junian/homebrew-dotnet
brew install dotnet-sdk@8.0    

Um DB builder zu konfigurieren:
    Erselle eine appsettings.json Datei
->
{
    "ConnectionStrings": {
      "DefaultConnection": "Host=localhost;Port=5433;Database=mydb;Username=postgres;Password=secret;"
    },
    "Logging": {
      "LogLevel": {
        "Default": "Information",
        "Microsoft.AspNetCore": "Warning"
      }
    }
  }
  

Für Migrationen:
dotnet nuget locals all --clear
dotnet tool install --global dotnet-ef --version 8.0.0
dotnet add package Microsoft.EntityFrameworkCore.Design --version 8.0.0

Um Datenbank Migration auszuführen: dotnet ef database update