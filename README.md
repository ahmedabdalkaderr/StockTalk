# StockTalk

## Project Description
StockTalk is a backend service designed to manage stock-related entities, including stocks, comments, and users. The system provides a RESTful API to handle operations such as adding and updating stocks, managing comments, and retrieving stock data. Built with ASP.NET Core and Entity Framework, StockTalk ensures a scalable architecture and efficient data management with SQL Server as the database.

# Technologies Used
Framework: ASP.NET Core 8

Database: SQL Server

ORM: Entity Framework Core

Unit Testing: xUnit, Moq

Dependency Injection: Built-in ASP.NET Core DI container

Documentation: Swagger (OpenAPI)

## Application Setup

1. **Clone the repository**
    ```bash
      git clone https://github.com/ahmedabdalkaderr/StockTalk.git
    ```
2. **Install dependencies**

    Build project to install required dependencies.

4. **Setting Up SQL Server Connection**

    To connect to a SQL Server database, you need to set up your connection string to your server. in applicatoin json file add the following line:
    ```bash
      "ConnectionStrings": {
        "DefaultConnection": "Server=<server-name>;Database=StockTalkDB;User Id=<user-name>;Password=<password>;"
       }
    ```
    Replace server-name, user-name, password, with your actual SQL Server connection details.

5. **Update Database**
   ```bash
     dotnet run
   ```
6. **Running the app**
   ```bash
    dotnet watch run
   ```   
7. **Testing**   
   to run unit testing files:
   ```bash
    dotnet test
   ```

## REST Endpoints
To view the full API documentation, follow these steps:

1. **Start the Application**:
    Make sure your application is running.

2. **Open Swagger UI**:
    Once the application is running, open your web browser and navigate to:
    ```bash
     http://localhost:3000/api](https://localhost:7180/swagger/index.html
    ```
    
    after navigating you will see end points look like this :
   
     ![image](https://github.com/user-attachments/assets/d5b08fc0-0647-4bf0-a878-3ea97c8f96d0)


## Authentication Strategy

 **Authentication Workflow**:
   
    **Registration/Login**: Users register and log in, receiving a JWT upon successful authentication.

    **Token Storage**: The JWT is stored securely (e.g., in local storage) on the client side. 

    **Request Authorization**: For each request, the JWT is sent in the HTTP headers to verify the user's identity and.       permissions.
   
   
