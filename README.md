# Factory Maintenance

## About

This is a MVC web application designed to simplify the management of engineers and their respective machine repair operations for a mock factory. This user-friendly system allows access to full CRUD operations and the ability to register new machines and assign specific engineers to each machine for repairs. With a many-to-many relationship in place, engineers can have licenses to work on multiple machines while machines can also have a diverse team of engineers with expertise in repairing them. 

<html>
<img src="Factory/wwwroot/img/FactoryMaintenance.jpg">
</html>
Pushing to put media queries and responsive web design into practice, the content of this application dynamically rearranges itself to fit to screen when the window size is adjusted. 

> For instance:

<html>
<img src="Factory/wwwroot/img/FactoryMaintenanceResponsive.jpg">

## Technologies Used
* _Github_
* _VSCode_
* _C#_
* _.NET_
* _CSHTML_
* _CSS_
* _JSON_
* _Figma_
* _Bootstrap_
* _Google Fonts API_
* _Material Symbols_
* _MySQL Workbench_

## Prerequisites

* _MySQL_
* _MySQL Workbench_
* _Entity Framework Core_

## Application Setup

1. Clone this repo.
2. Open your shell (e.g., Terminal or GitBash) and navigate to this project's production directory called `Factory`. 
3. Within the production directory `Factory`, create a new file entitled `appsettings.json`.
4. Within `appsettings.json`, enter the following code:
```json
{
  "ConnectionStrings": {
      "DefaultConnection": "Server=localhost;Port=3306;database={DATABASE};uid={USERNAME};pwd={PASSWORD};",
  }
}
```
  > Be sure to replace the `{DATABASE}`, `{USERNAME}` and `{PASSWORD}` fields with your own relevant information. Do not include the curly brackets.
5. In production directory, enter the following command `dotnet ef database update`. 
  > This command will initialize the repository's migrations to establish and maintain the database.
6. In the production directory, you can enter the following command `dotnet watch run`.
  > This command will start the project in development mode with a watcher.

## Known Bugs

Currently no known bugs. If any issues are identified, please kindly address the issue to the owner of this repository.

## MIT License

Copyright (c) 2023 Jeremy Josol

Permission is hereby granted, free of charge, to any person obtaining a copy of this software and associated documentation files (the "Software"), to deal in the Software without restriction, including without limitation the rights to use, copy, modify, merge, publish, distribute, sublicense, and/or sell copies of the Software, and to permit persons to whom the Software is furnished to do so, subject to the following conditions:

The above copyright notice and this permission notice shall be included in all copies or substantial portions of the Software.

THE SOFTWARE IS PROVIDED "AS IS", WITHOUT WARRANTY OF ANY KIND, EXPRESS OR IMPLIED, INCLUDING BUT NOT LIMITED TO THE WARRANTIES OF MERCHANTABILITY, FITNESS FOR A PARTICULAR PURPOSE AND NONINFRINGEMENT. IN NO EVENT SHALL THE AUTHORS OR COPYRIGHT HOLDERS BE LIABLE FOR ANY CLAIM, DAMAGES OR OTHER LIABILITY, WHETHER IN AN ACTION OF CONTRACT, TORT OR OTHERWISE, ARISING FROM, OUT OF OR IN CONNECTION WITH THE SOFTWARE OR THE USE OR OTHER DEALINGS IN THE SOFTWARE.