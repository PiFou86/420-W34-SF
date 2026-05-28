# Démo ORM avec .Net, Entity Framework Core, Oracle

## DAL (Data Access Layer)

Les classes DTOs utilisent des attributs afin de définir les noms des colonnes qui sont sensibles à la casse.

## Anti-pattern

L'utilisation des dépôts de données est ici un anti-pattern car Entity Framework Core est fait pour suivre les modifications. Or, dans notre modèle, on protège chaque couche des différentes technologie. 

Si nous ne faisons pas cela, la couche affaire va être polluée par les attributs de la couches de données. De plus, cela obligerait à définir les entités d'affaires comme étant les même que les entités de données. Cela n'est pas une bonne idée, car les classes d'affaires n'ont pas forcément les mêmes attributs que les classes de données qui ne servent "qu'à la persistance".

## Design de l'application

![Design de l'application](./Design/Design.png)

## Diagramme de dépendances de l'exemple

Version simplifiée :

![image](https://github.com/user-attachments/assets/4eb08ab7-ff27-490d-a902-b6ede9e86022)

Version plus détaillée :

![image](https://github.com/user-attachments/assets/89cf0605-764c-4cf3-84c9-5d6f1268ccb5)

## Démo Mac :

### Conteneur SQL Server Developer

```bash
docker run -e "ACCEPT_EULA=Y" -e "SA_PASSWORD=Bonjour01.+" -p 1433:1433 --name sqlserver -d mcr.microsoft.com/mssql/server:2019-latest
```

### Execution

```bash
dotnet run --project ./DemoEF_Console/DemoEF_Console.csproj
```

### Scaffolding

Installation du tool si nécessaire :

```bash
dotnet tool install --global dotnet-ef --version "8.*"
```

```bash
mkdir -p ~/tmp/demo-orm-scaffolding
cd ~/tmp/demo-orm-scaffolding

dotnet new classlib -n DAL -f net8.0

dotnet add ./DAL/DAL.csproj package Microsoft.EntityFrameworkCore.SqlServer --version "8.*"
dotnet add ./DAL/DAL.csproj package Microsoft.EntityFrameworkCore.Design --version "8.*"

dotnet ef dbcontext scaffold "Server=localhost,1433;Database=Module10_ORM;User Id=sa;Password=Bonjour01.+;MultipleActiveResultSets=true;Trust Server Certificate=true" Microsoft.EntityFrameworkCore.SqlServer -o ./DAL/Models -f --project ./DAL/DAL.csproj

ls ./DAL/Models -l
```

## Chaines de connexion

### SQL Server - Container

```json
{
  "ConnectionStrings": {
    "PersonnesConnection": "Server=localhost,1433;Database=Module10_ORM;User Id=sa;Password=Bonjour01.+;MultipleActiveResultSets=true;Trust Server Certificate=true"
  }
}
```

### SQL Server - Windows Authentication

```json
{
  "ConnectionStrings": {
    "PersonnesConnection": "Server=.;Database=Module10_ORM;User Id=sa;Password=Bonjour01.+;MultipleActiveResultSets=true;Trust Server Certificate=true"
  }
}
```
