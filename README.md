# BWERP
Develop ERP web for Buwon Vina using Blazor Server .NET 6.0

## Techstack
- ASP.NET 6.0
- REST API
- SQL Server
- Visual studio 2022
- Entity Framework Core
- Blazor Server

## How to run
- Clone project from Github
- Setup database connection in project BWERP.Api --> appsettings.json
- Setup startup project is multiple projects
- Database will be created automatically when run API project.

## References
- Microsoft Docs: https://learn.microsoft.com/en-us/aspnet/core/blazor/fundamentals/handle-errors?view=aspnetcore-6.0
- Blazor University: https://blazor-university.com/

## Add Summernote
- Add package BlazingComponents.Summernote (0.0.6).
- Add reference to style sheet & javascript references Add the following line to the head tag of your _Layout.cshtml (Blazor Server) or index.html (Blazor WebAssembly).
- CSS: <link href="./_content/BlazingComponents.Summernote/summernote/summernote-lite.min.css" rel="stylesheet" />
- JS: <script src="./_content/BlazingComponents.Summernote/summernote/jquery-3.4.1.slim.min.js"></script>
<script src="./_content/BlazingComponents.Summernote/summernote/summernote-lite.min.js"></script>
- Usage: <BlazingComponents.Summernote.Editor @bind-content="@content" />
