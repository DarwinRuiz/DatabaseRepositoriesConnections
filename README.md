# DatabaseRepositoriesConnections

## Description
**DatabaseRepositoriesConnections** is a Blazor-based project that implements CRUD operations on a database table. The project demonstrates how to connect and manipulate data in a Blazor application using different data access technologies such as ADO.NET, Entity Framework, Datasets, and Dapper.

## Technologies Used
- **Blazor**: Framework for building interactive client-side web applications using C#.
- **ADO.NET**: Data access technology that allows efficient interaction with relational databases.
- **Entity Framework**: ORM (Object-Relational Mapper) that facilitates access and manipulation of database data using C# objects.
- **Datasets**: In-memory objects that contain tabular data.
- **Dapper**: Micro ORM for .NET that simplifies the execution of SQL queries efficiently.

## Features
- Implementation of CRUD operations (Create, Read, Update, Delete) on a database table.
- Use of different data access technologies to interact with the database.
- Practical example of how to use ADO.NET, Entity Framework, Datasets, and Dapper in a Blazor project.

## Requirements
- .NET 7.0 or higher
- SQL Server (or another compatible database)



## Project Structure
- **DatabaseRepositoriesConnections.DataStuff**
  - **Repositories**
    - **ADOConnectedRepository.cs**: Data access implementation using ADO.NET.
    - **EFRepository.cs**: Data access implementation using Entity Framework.
    - **ADODisconnectedRepository.cs**: Data access implementation using Datasets.
    - **DapperRepository.cs**: Data access implementation using Dapper.
  - **Models**
    - **CustomerModel.cs**: Data model representing the database table.
- **DatabaseRepositoriesConnections**
  - **Shared**
    - **MainLayout.razor**: Main page of the application.
  - **Pages**
    - **Dashboard.razor**: Page for managing CRUD operations on the data.



# DatabaseRepositoriesConnections

## Descripción
**DatabaseRepositoriesConnections** es un proyecto basado en Blazor que implementa un CRUD sobre una tabla de bases de datos. El proyecto muestra cómo conectar y manipular datos en una aplicación Blazor utilizando diferentes tecnologías de acceso a datos como ADO.NET, Entity Framework, Datasets y Dapper.

## Tecnologías Utilizadas
- **Blazor**: Framework para crear aplicaciones web interactivas del lado del cliente usando C#.
- **ADO.NET**: Tecnología de acceso a datos que permite interactuar con bases de datos relacionales de manera eficiente.
- **Entity Framework**: ORM (Object-Relational Mapper) que facilita el acceso y manipulación de datos en bases de datos utilizando objetos C#.
- **Datasets**: Objetos en memoria que contienen datos tabulares.
- **Dapper**: Micro ORM para .NET que facilita la ejecución de consultas SQL de manera eficiente.

## Características
- Implementación de operaciones CRUD (Crear, Leer, Actualizar, Eliminar) sobre una tabla de bases de datos.
- Uso de diferentes tecnologías de acceso a datos para interactuar con la base de datos.
- Ejemplo práctico de cómo usar ADO.NET, Entity Framework, Datasets y Dapper en un proyecto Blazor.

## Requisitos
- .NET 7.0 o superior
- SQL Server (u otra base de datos compatible)


## Estructura del Proyecto
- **DatabaseRepositoriesConnections.DataStuff**
  - **Repositories**
    - **ADOConnectedRepository.cs**: Implementación de acceso a datos usando ADO.NET.
    - **EFRepository.cs**: Implementación de acceso a datos usando Entity Framework.
    - **ADODisconnectedRepository.cs**: Implementación de acceso a datos usando Datasets.
    - **DapperRepository.cs**: Implementación de acceso a datos usando Dapper.
  - **Models**
    - **CustomerModel.cs**: Modelo de datos que representa la tabla de la base de datos.
- **DatabaseRepositoriesConnections**
  - **Shared**
    - **MainLayout.razor**: Página principal de la aplicación.
  - **Pages**
    - **Dashboard.razor**: Página para la gestión CRUD de los datos.