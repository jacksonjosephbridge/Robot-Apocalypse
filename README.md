# Install
1. Clone this git repo from the branch master.
2. Install the Nuget packages
3. define the database connection in the appsettings.json file line no 10 as:
    1. "server=MY_SERVER;database=Robot_Apocalypse;User ID=MY_USER;password=MY_PASSWORD;" or if you are using windows auth - "Data Source=MY_SERVER;Initial Catalog=Robot_Apocalypse;Integrated Security=true"
    
4. Run the following command in the Package Manager console to migrate and create DataBase:
    1. Add-Migration Robot_Apocalypse.Models.SurvivorContext
    2. update-database 
# Run
1. Default path of the API is /Swagger 
# System Requirements
* .NET Framework version 4.7.2.
* SQL server 2016
