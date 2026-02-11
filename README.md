# 🎫 Sistema de Gestión de Tickets -- Backend API

API REST del **Sistema de Gestión de Tickets** desarrollada con **.NET 7
(ASP.NET Core Web API)** y **PostgreSQL**.\
Implementa autenticación **JWT**, arquitectura en capas (Clean
Architecture) y documentación con **Swagger**.

------------------------------------------------------------------------

## 🚀 Tecnologías Utilizadas

-   🧠 .NET 7 (ASP.NET Core Web API)
-   🐘 PostgreSQL
-   🔐 JWT Authentication
-   🧩 Entity Framework Core
-   📦 Npgsql.EntityFrameworkCore.PostgreSQL
-   🛠️ Swagger / OpenAPI
-   🧱 Clean Architecture (Domain, Application, Infrastructure,
    Persistence)

------------------------------------------------------------------------

## 📦 Paquetes NuGet Utilizados

-   Microsoft.AspNetCore.Authentication.JwtBearer\
-   Microsoft.EntityFrameworkCore\
-   Npgsql.EntityFrameworkCore.PostgreSQL

------------------------------------------------------------------------


## ⚙️ Configuración del Proyecto

### 🐘 1️⃣ Configurar la Base de Datos (PostgreSQL)

En el archivo **appsettings.json**:

``` json
"ConnectionStrings": {
  "Conexion": "Host=localhost;Username=postgres;Password=123456;Database=DB_tickets"
}
```

------------------------------------------------------------------------

### 🌐 2️⃣ Configurar el Frontend Permitido (CORS)

En **appsettings.Development.json**:

``` json
"web": "http://localhost:5173"
```

------------------------------------------------------------------------

## ▶️ Ejecutar el Proyecto

``` bash
dotnet restore
dotnet run
```

------------------------------------------------------------------------

## 📑 Documentación Swagger

Accede a Swagger:

    http://localhost:{PUERTO}/swagger/index.html

Ejemplo:

    http://localhost:5059/swagger/index.html

------------------------------------------------------------------------

## 🔐 Autenticación JWT

Endpoint de login:

    POST /api/usuario/login

Header requerido:



------------------------------------------------------------------------

## 🎫 Endpoints Principales

### Catálogos

    GET /api/catalogos/areas
    GET /api/catalogos/prioridades
    GET /api/catalogos/estados

### Tickets

    POST   /api/tickets
    GET    /api/tickets
    PATCH  /api/tickets/estado
    GET    /api/tickets/{codigo}
    GET    /api/tickets/usuario/{usuarioId}

### Usuarios

    POST /api/usuario/login

------------------------------------------------------------------------

## 🗄️ Base de Datos

-   Motor: PostgreSQL
-   Base de datos: DB_tickets

------------------------------------------------------------------------

## 🧑‍💻 Autor

Steven Jocz\
Desarrollador de Software \| .NET \| React \| PostgreSQL

------------------------------------------------------------------------


