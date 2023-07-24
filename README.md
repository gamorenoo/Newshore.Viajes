# Newshore.Viajes

Prueba desarrollada como ejercicio para el Examen o prueba de ingreso a NEWSHORE

### Newshore.Viajes.WebApi
Carpeta que contiene el Proyecto Api desarrollado en net core.
El api se encarga de verificar si una ruta de vuelo se encuentra en los datos recibidos por el servicio de vuelo proporciando teniendo encuenta los criterios de busqeudas ingresados por el usuario desde el Front 

### newshore-viajes-web
Carpeta que contiene el Proyecto web desarrollado en Angular.
El front se encarga de hacer peticiones al servicio descrito anteriormente para buscar rutas de vuelo y muestra los resultados en pantalla. Una vez realizada la búsqueda, le da la posibilidad al usuario de realizar conversiones a otras monedas (COP, EUR y GBP).

## 2. Herramientas e instrucciones
### Herramientas utilizadas
- C# Como lenguaje de programación orientado a Objetos (BackEnd)
- Net Core 6 plataforma de desarrollo
- Angular como framework de desarrollo para el FrontEnd
- Visual Studio 2022 IDE para el desarrollo del Api
- Visual studio Code IDE paral desarrollo del Front
- Suwgger coomo conjuto de herramienta para construir, documentar, y utilizar/probar el servicios/api
- Serilog para la captura de logs en archivos
- Microsoft Test Framework como herramienta para creación de pruebas unitarias

### Requerimientos Ejecucion Api :
- Visual studio versión 2022
### Requerimientos Front :
Angular
```
Package                         Versión
---------------------------------------------------------
@angular-devkit/architect       0.1601.4
@angular-devkit/build-angular   16.1.4
@angular-devkit/core            16.1.4
@angular-devkit/schematics      16.1.4
@angular/cli                    16.1.4
@schematics/angular             16.1.4
rxjs                            7.8.1
typescript                      5.1.6
```
Node versión v18.16.1


### Pasos para ejecución Api :
Para ejecutar el proyecto de forma local, se debe, realizar los siguientes pasos: 
1. Clonar o descargar el repositorio de la solución
2. verificar/restaurar todos los paquetes Nuget de la solución
3. Ajecutar aplicación

### Pasos para ejecución Aplicación web :
1. Clonar o descargar el repositorio de la solución
2. Valiadr las versiones  de angular descrutas anteriormente en la pc donde se desea probar la aplicación
3. Ejecutar "npm install" para restaurar los paquetes del proyecto
4. ejecutar "ng serve --open" para arrancar la aplicación

## 3. Arquitectura 
### Principales requerimientos no funcionales
- Disponibilidad
- Testeabilidad
- Mantenibilidad

### Decisiones
- Se usa manejo de cache en memoria para optimizar la cantidad de peticiones que se hacen al API: https://recruiting-api.newshore.es/api/flights/2
- Se usa Base de datos de sql server en memoria, lo anterior para guardar un historial de consultas, ademas que nos ayuda a ejecutar pruebas locales en otros dispositivos mas rapidos y evitando posibles errores, ya que no es necesari instalar el motros de Sql Server.
- Se usa en servicio de terceros para eralizar la conversipon de divisas (https://www.exchangerate-api.com/).
