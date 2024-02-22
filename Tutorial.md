# Mac VSCode SQLServer Docker ASP.Net EFCore Tutorial

### Since SQLServer is a Windows native program you will have to use Docker, This short tutorial will show you how to setup VSCode on mac to run ASP.Net web api with Entity Framework Core using SQL Server for the database.

#### List of Software
- Docker https://www.docker.com/
- VSCode https://code.visualstudio.com/
- Azure Data Studio [download-azure-data-studio from Microsoft](https://learn.microsoft.com/en-us/azure-data-studio/download-azure-data-studio?tabs=macOS-install%2Cwin-user-install%2Credhat-install%2Cwindows-uninstall%2Credhat-uninstall#download-azure-data-studio)
- Make sure you have rosett Rosetta 2 installed if unsure run the following in the terminal
`/usr/sbin/softwareupdate --install-rosetta --agree-to-license`



#### List of MUST HAVE VSCode extensions
##### Note that some of the extensions will get installed automatically when you install C# Dev Kit
- C#, C# Dev Kit, Intellicode for C# Dev Kit
- .Net Extension Pack
- .Net Install Tool

#### List of NICE TO HAVE VSCode extensions that just makes life easier 
- SQL Server mssql
- Docker
- NuGet Gallery
- Prettier
- Meterial Icon Theme (channges the icons in explorer)
- PlantUML (For visual documentation of UML diagrams)
- C# Extensions (by JoshKreativ)
- Better Comments
- Auto Rename Tag


#### List of CLI Commands (Command Line Interface) (MAC Terminal)
- **cd** (goes to base directory)
- **cd < Name >** (goes into the folder with the name if its in you current directory)
- **ls** (list files in the current directory)
- **mkdir < Name >** (creates a new folder with the Name)
- **clear** (clears the terminal)
- **code .** ("Code space fullstop" opens current folder in VSCode)
- 
- **dotnet new webapi -o < Name >** (Creates a new webapi project in the current directory with the Name)
- **dotnet build** (builds the aplication)
- **dotnet run** (runs the aplication)
- **dotnet watch run** (runs the aplication and watch for changes in the code base, if there is any changes it runs hotreload so you can see the changes straigt awai in the api)


# Docker

#### Go to [Docker.com/get-started](https://www.docker.com/get-started/)
- Download the version for you operating system and install it

#### Go to [hub.docker.com/signup](https://hub.docker.com/signup)
- make a free account and verify it

#### Open Docker Desktop
- login using your docker hub login

#### In the terminal run the following
- `docker pull mcr.microsoft.com/mssql/server:2022-latest`
- `docker run -e "ACCEPT_EULA=Y" -e "MSSQL_SA_PASSWORD=<YourStrong@Passw0rd>" -p 1433:1433 --name sql2022 --hostname MySQLHost -d mcr.microsoft.com/mssql/server:2022-latest`
- Change the `sql2022` to the name you want your container to have
- Change `MySQLHost` to the host name you want to have
- Change `<YourStrong@Passw0rd>` with a personal password. This will be used to login into you database in Azure Data Studio and VSCode
![docker commands in terminal](<Pictures/Screenshot 2024-02-21 at 15.53.13.png>)

- You are probably getting the following warning `WARNING: The requested image's platform (linux/amd64) does not match the detected host platform (linux/arm64/v8) and no specific platform was requested` but as long as you container is running fine its not a problem.

- **the password have to follow the sql server quideline**
1. Length: The password must be at least 8 characters long.

2. Complexity: The password must include a mix of uppercase and lowercase letters, numbers, and special characters.

3. Non-Obvious: The password should not be easily guessable, such as "password", "12345678", or the username.

4. No Null or Empty: The password cannot be a null or an empty string.

#### Docker desptop
- See your containers and copy the container id from here (dont worry if the names are different)
![Docker desktop gui with highlighting of container and container id](<Pictures/Screenshot 2024-02-21 at 16.06.21.png>)

- You can start and stop docker containers from the gui, but in this tutorial we will be using the terminal, so press the stop button and opent the terminal.

- To make sure docker is running your container write the following in the terminal `docker ps` to see if its running if there is no running container write `docker start < container id>` then run `docker ps` again to see if its running, if you still cant see it, then go back to the docker section or use ChatGPT
![Terminal running docker commands](<Pictures/Screenshot 2024-02-21 at 14.43.26.png>)

### Docker CLI Commands
- **docker run < name >**(runs image or container with the name)
- **docker pull < name >**(pulls the image with the name)
- **docker ps** (shows list of running containers)
- **docker start < container id>** (starts the container with the id)
- **docker stop < container id>** (stops the container with the id) 

# Azure Data Studio
#### Go to [Microsoft Azure Data Studio](https://learn.microsoft.com/en-us/azure-data-studio/download-azure-data-studio?tabs=macOS-install%2Cwin-user-install%2Credhat-install%2Cwindows-uninstall%2Credhat-uninstall#download-azure-data-studio)
- Under install choose macOS and click Download Azure Data Studio for macOS.
- After its downloaded run the instalation 

- The picture below shows two ways to add a new connection in Azure data studio
- Use localhost for Server, 
- sa for User 
- And the password you made when starting the docker connection
- <img alt="shows two ways to add a new connection in Azure data studio" src="Pictures/Screenshot 2024-02-21 at 14.51.38.png " width="500" height="400">  <img alt="Azure data studio new connection screenshot" src="Pictures/Screenshot 2024-02-21 at 15.00.20.png" width="400" height="400">
  
   
 <br>
  


- Now you can open the localhost right click on Databases folder and click New Database, this lets you make a new databse that you can call whatever you want. You will need the name of the database when setting up you ConnectionString later
  
   
 <br>
  


 <img alt="Azure data studio new connection screenshot" src="Pictures/Screenshot 2024-02-21 at 16.28.27.png" width="200" height="200">
  
   
 <br>
  

 # VSCode
 - Go to https://code.visualstudio.com/ to download and install
 - Download the MUST HAVE Extensions (and the nice to have if you feel like it)
 - You can open folder by going to File - Open or using `command + o` or by using terminal
 - Open the terminal you can use shortcut `control + ~` or click in terminal in the top of you computers navbar
 - You want to make sure that the terminal also is in the rigt folder. Its a lot easier if your folder is not nested inside a bunch of other folders.

 - In this example i will go to the root folder using `cd` then into my repoes folder using `cd repoes` then make a new folder called Test using `mkdir Test` then get a list of my folders using `ls`then navigate into that folder i want to run my code in in this example i dont want to use the Test folder but the MacTutorial i do this by using `cd MacTutorial` 
 - The last comand `code .` opens the folder in VSCode

![Terminal commands for navigating and creating folders](<Pictures/Screenshot 2024-02-21 at 16.59.31.png>)

   
 <br>
  
### Now we are ready to set up our project. 
- Use `clear` to clear the terminal
- Run `dotnet new webapi -o MacAPI` in the terminal, this setup the standard webapi from dotnet (you can also use `dotnet new mvc`) both the webapi and the mvc scaffold commands can be used with or without the -o command this just lets you prename the files and save you time.
- Now open the Explorer and see that the files have been added
- Build the project to make sure everything is working using `dotnet build` but first move into the API using `cd` otherwise it cant build
- Run your aplication using `dotnet watch run` this should open your api in your prefered browser
- `control + c` stops the program from running

<img alt="VSCode file explorer" src="Pictures/Screenshot 2024-02-21 at 17.15.38.png" width="200" height="200">
<img alt="Terminal commands for dotnet" src="Pictures/Screenshot 2024-02-21 at 17.24.05.png" width="700" height="350">

### Add Packages for EF Core and Code Generator
- Run the following commands in the terminal
- `dotnet add package Microsoft.EntityFrameworkCore`
- `dotnet add package Microsoft.EntityFrameworkCore.SqlServer`
- `dotnet add package Microsoft.EntityFrameworkCore.Design`
- `dotnet add package Microsoft.VisualStudio.Web.CodeGeneration.Design`
- `dotnet tool install --global dotnet-aspnet-codegenerator`

### Add Models
- Now we build our models for this example i will use 2 simple classes.
- Add a folder called Models in the and the two classes I am using Book and Author as example these have a many to many relationship since there can be multiple Authors writing one Book and an Author can have many Books so both the have a ICollection as navigation property to the other class
```
namespace MacAPI.Models
{
public class Book
{
    public int BookId { get; set; }
    public string? Title { get; set; }
    public ICollection<Author>? Authors { get; set; }
}
}
```
```
namespace MacAPI.Models
{
public class Author
{
    public int AuthorId { get; set; }
    public string? Name { get; set; }
    public ICollection<Book>? Books { get; set; }
}
}
```
### Add DataContext
- Then make another folder called Data and add the data context file in this example i will use `LibraryContext`
- The Make sure to add using statements too Microsoft.EntityFrameworkCore and your Models
- Class inherit from `DbContext`
- The constructor needs to need to take one parameter of `DbContextOptions` and inherit from base
- The `DbSet` maps the classes to the tables so your C# class Book becomes table Books you can also overide these, but it is best practice to use the general naming conventions
- The relations between the two classes gets set to many to many in the override of the OnModelCreating method
```
using MacAPI.Models;
using Microsoft.EntityFrameworkCore;

namespace MacAPI.Data
{
public class LibraryContext : DbContext
{
    public LibraryContext(DbContextOptions dbContextOptions) 
    : base(dbContextOptions)
    {
        
    }
    
    public DbSet<Book> Books { get; set; }
    public DbSet<Author> Authors { get; set; }
    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Book>()
            .HasMany(b => b.Authors)
            .WithMany(a => a.Books);
    }
}
}
```
### Add ConnectionString to appsettings.json
- Copy and past the folling connectionstring into your appsettings.json file
- Change the `MacAPI_Database` to your database name and `<YourStrong@Passw0rd>` to your password
- its important that you have `TrustServerCertificcate=true` otherwise the connection wont get build
```
  "ConnectionStrings": {
    "Default": "Server=localhost; Database=MacAPI_Database; User Id=sa; Password=<YourStrong@Passw0rd>; TrustServerCertificate=true"
},
```
### Add DbContext to Program.cs file
- Add the following above the `var app = builder.Build();` since we need to find the connectionstring before building the app
- The Name `"Default"` needs to be the same as from your connectionstring
```
builder.Services.AddDbContext<LibraryContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("Default")));
```
### Change InvariantGlobalization
- Go to `.csproj` folder in my example its called `MacAPI.csproj`
- Change the InvariantGlobalization rto `false`
```
<InvariantGlobalization>false</InvariantGlobalization>
```
### Run Migration and Update Database
- Run the following in the terminal `dotnet ef migrations add InitialCreate`
- Open explorer and the new Migrations folder, there should be 3 files `InitialCreate`, `InitialCreate.Designer` and `Snapshot`. Open the Designer file and make sure the tables looks correct
- If you wanrt to change something dont change it in these files, go back to your Models or DbContext files and change it and then make a new migration with a new name
- Run `dotnet ef database update` in the terminal
- <img alt="dotnet ef migration terminal command" src="Pictures/Screenshot 2024-02-21 at 19.32.44.png" width="600" height="100"> <img alt="vscode explorer showing migration files" src="Pictures/Screenshot 2024-02-21 at 19.41.51.png" width="300" height="300">

### Open Databse
- Go to Azure Data Studio and update the database. Open the tables folder and make sure they are all there 
- Since we made a many to many relations there should be 3 tables `Books`, `Authors` and `AuthorBooks`, there is also the migration history table showing each migration thats been made so its easy to go back to an earlier one.
   
 <br>
  
![Azure Data Studio Screenshot](<Pictures/Screenshot 2024-02-21 at 20.35.05.png>)