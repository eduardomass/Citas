# Citas 📖
Creacion de Citas y confirmaciones de listas

## Objetivos 📋

Desarrollar un sistema que permita gestionar reuniones/citas. La misma se genera con un listado de emails. \

Utilizar Visual Studio 2019 y crear una aplicación utilizando `ASP.NET MVC Core versión 3.1`.

---------------------------------------

## Enunciado 📢

La idea principal de este trabajo práctico, es que ustedes se comporten como un equipo de desarrollo.\
Deben recopilar todas las dudas que tengan y evacuarlas con su nexo (el docente). 
Es importante destacar que este proceso no debe esperar a ser en clase, sino que debe darse a medida que vayan trabajando en el proyecto. 
Por otro lado es importante que agrupen sus consultas ya sea por criterios funcionales o técnicos y envíen correos con las consultas agrupadas en lugar de enviar cada consulta de forma independiente.

### Consultas

Las consultas que sean realizadas por correo a mailto:eduardo.mass@ort.edu.ar deben seguir el siguiente formato:

**Subject:**

- `[NT1-<CURSO LETRA>-GRP-<GRUPO NUMERO>] <Proyecto XXX> | Informativo o Consulta` *ej: [NT1-A-GRP-5] Agenda de Turnos | Consulta*

**Body:**

1. `<xxxxxxxx>` *ej: ¿Esta bien si usamos validaciones por java script y no razon?*
2. `<xxxxxxxx>` *ej: ¿Está bien que encaremos la validación del turno activo, con una propiedad booleana en el Turno?*

---------------------------------------

## Proceso de ejecución en alto nivel ☑️

- Crear un proyecto utilizando [visual studio].
- Adicionar todos los modelos dentro de la carpeta Models cada uno en un archivo separado.
- Especificar todas las restricciones y validaciones solicitadas a cada una de las entidades. [DataAnnotations].
- Crear las relaciones entre las entidades.
- Crear una carpeta Data que dentro tendrá al menos la clase que representará el contexto de la base de datos DbContext.
- Crear el DbContext utilizando base de datos sqlite. [DbContext], [Database Sqlite], [Db browser sqlite].
- Agregar los DbSet para cada una de las entidades en el DbContext.
- Crear el Scaffolding para permitir los CRUD de las entidades.
- Aplicar las adecuaciones y validaciones necesarias en los controladores.
- Realizar un sistema de login para los roles identificados en el sistema y un administrador.
- Un administrador podrá realizar todas tareas que impliquen interacción del lado del negocio (ABM "Alta-Baja-Modificación" de las entidades del sistema y configuraciones en caso de ser necesarias).
- Cada usuario sólo podrá tomar acción en el sistema en base al rol que tiene.
- Realizar todos los ajustes necesarios en los modelos y/o funcionalidades.
- Realizar los ajustes requeridos del lado de los permisos.
- Todo lo referido a la presentación de la aplicaión (cuestiones visuales).
- Para la visualización se recomienda utilizar [Bootstrap], pero se puede utilizar cualquier herramienta que el grupo considere.

---------------------------------------
## Base de Datos / SQL Lite
<details>
  <summary>(Mostrar mas)</summary>

  - Instalacion de SQL Lite [Db browser sqlite]
  - Entity Framework

  > Microsoft.EntityFramworkCore.SqlLite

  - Configuracion de Mildware (todo el proyecto misma base)
    - Clase : StartUp.cs
    - Metodo 
    ```C#
    public void ConfigureServices(IServiceCollection services)
    
    - Agregar
    
  ```C#
    services.AddDbContext<%NOMBRE DEL DBCONTEXT%>(options => 
    options.UseSqlite(@"filename=%PATH DEL ARCHIVO DE SQLLITE%.db"));
  ```

- Contexto
```C#
public class %NOMBRE DEL DBCONTEXT% : DbContext
{
   public %NOMBRE DEL DBCONTEXT%(DbContextOptions opciones) : base(opciones)
   {

   }
   public DbSet<%Modelo%> %Modelo en Plural% { get; set; }
}
```
   
   </details>
---------------------------------------


## Entidades básicas 📄

- Cita
- Usuario
- CitaUsuario
- CitaFechaPosible
- CitaUsuarioConfirmacion


| Entidad | Propiedades |
| ----- | ----- |
| Usuario | Nombre, Email, Password, Id |
| Cita | FechaCreacion , Id |
| CitaUsuario | CitaId, UsuarioId |
| CitaFechaPosible | Fecha, CitaId |
| CitaUsuarioConfirmacion |CitaId, UsuarioId, CitaFechaPosibleId |

**NOTA:** aquí un link para refrescar el uso de los [Data annotations].

---------------------------------------

## Características y Funcionalidades ⌨️

`Todas las entidades deben tener implementado su correspondiente ABM, a menos que sea implícito el no tener que soportar alguna de estas acciones.`


### Usuario

- Los usuarios se crean solamente con el Email. No hay una registracion.
- Si el usuario/email YA EXISTE entonces, no lo vuelve a crear. 
- El email es obligatorio
- Si cuando entra al sistema, el usuario n otiene password, se lo exige por primera vez

### Cita

- Se crea una cita en base a una fecha
- Se Asignan los mails a los que el sistema ingresara



[//]: # (referencias externas)
   [visual studio]: <https://visualstudio.microsoft.com/en/vs/>
   [Data annotations]: <https://www.c-sharpcorner.com/UploadFile/af66b7/data-annotations-for-mvc/>
   [Bootstrap]: <https://getbootstrap.com/>
   [DbContext]: <https://docs.microsoft.com/en-us/dotnet/api/microsoft.entityframeworkcore.dbcontext?view=efcore-3.1>
   [Database Sqlite]: <https://docs.microsoft.com/en-us/ef/core/providers/sqlite/?tabs=dotnet-core-cli>
   [Db browser sqlite]: <https://sqlitebrowser.org/>
   [DataAnnotations]: <https://docs.microsoft.com/en-us/dotnet/api/system.componentmodel.dataannotations?view=netcore-3.1>
