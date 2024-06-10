#Study Guide

## ASP.NET

1. What is ASP.NET?
    - An open source web framework, created by Microsoft, to let us make web apps using .NET. We specifically are using it to create web APIs.
2. Structure of a URL:
    - https://www.geeksforgeeks.org/components-of-a-url/
    - Our URL is made up of separate sections. For example, let's use this sample URL from the above article:
        - https://www.example.co.uk/blog/article/search?/docid=720&h1=en
        - First: Scheme - https:// is the scheme that denotes which protocol is used. Most modern sites will use https.
        - Second: Domain - The site being accessed
        - Third: Path - "blog/article/search" Where to send the request
        - Fourth: Query String Separator - "?" Everything after the ? is a search parameter
        - Fifth: Query String - "docid=720&h1=en"
3. What does ASP.NET give us?
    - Model binding/JSON serialization happening under the hood
        - We are converting things like JSON text and query parameters into objects that we can 
        work with in our code. And ASP.NET does this for us automatically.
    - ASP.NET handles our Dependency Injection, as long as we register our different dependencies inside the Program.cs.
    - Gives us access to a starting template for our program, that makes it easy to then add our layers to.
4. What is middleware? **(No longer on the Exam)**
    - ***Middleware is a pipeline that handles our incoming requests.** We have been using it under the hood the entire time.
    It is set-up using Program.cs. It allows different sets of software to interact with our request after it hits our API.
    - app.UseHttpsRedirection(); <-- example of Middleware>
        - It specifically is the HTTPS redirection middleware. All this does is route a request using the http schemeto use https automatically.
        - Our Controllers are technically part of Middleware


5. ASP.NET vs Entity Framework:
    1. ASP.NET - Inside of our TrackMyStuffAPI, we have built an ASP.NET web API.
        1. Program.cs
        2. Registering dependencies with our Builder
        3. Our controllers that extend ControllerBase
        4. The different AppSettings.json files
        5. Properties directory with LaunchSettings.json
    2. Entity Framework Core
        1. Inside of TrackMyStuffAPI we have chosen to use EF Core as an Object Relational Mapper (ORM)
        2. EF Core Specific Items:
            1. Migration folder
            2. The "dotnet ef" famil of CLI commands we use for migrations and database updates
            3. TrackMyStuffContext that inherits from DBContext
            4. The structure of our model classes is influenced by EF Core
        3. EF Core, like ADO.NET only concerns itself with database access. Gitting things to and from the database.
    EF: Data Access: 

    ## REST

    1. What kinds of return data can we get inside of an HTTP response? (hint: besides JSON!)
        - We can get:
            - JSON
            - Plain text (this is not really done anymore)
            - XML (Microsoft's JSON competitor, not really used much for web development anymore)
    2. What does an HTTP method being idempotent mean?
        - A method being IDEMPOTENT means that the result of one request and the result of many repeated requests will be the same.
        - For example, if I have a user named "Ross," and I send a DELETE request to delete the "Ross"user, one request vs many behaves the same.
        - Which methods are idempotent? Which aren't?
            - GET, PUT, DELETE (It's the affect on the data)
            - POST, PATCH 
    3. What does our API being "stateless" mean?
       1. We are not saving some sort of record of previous HTTP requests that were sent to our server
       2. Every request may as well be the first request ever sent. 
    4. PUT vs PATCH - Both can be used to update, but what is the difference?
       1. PUT - replaces everything about the object, effectively recreating it in place
       2. PATCH - replaces specific information about the object
    5. What is a URI/URL?
       1. ULR: Uniform Resource Locator - address of a unique resource, whether hosted locally or on the internet.
       
    6. What is JSON and what does it look like?
       1. It is a special text format that can be used to represent objects.
       2. Technically stands for Javascript Object Notation, though this wont be on the exam. 
       3. Here is a sample of JSON - In this case representing a user object in TrackMyStuff
        {
           username: "Phillip",
           userID: "6ffd4f60-3252-44ab-8e6b-29f586f9eef6"
       } 
    ## (Not on the Exam) EF Core vs ASP.NET  
    1. ASP.NET vs Entity Framework Core (THIS WILL NOT BE ON THE EXAM, ITS JUST GOOD TO KNOW)
       1. ASP.NET - Inside of our TrackMyStuffAPI, we have build an ASP.NET web api.
          1. Program.cs
          2. Our HTTP verb tags on our controller methods
          3. registering dependencies with our builder
          4. our controllers that extend controllerbase
          5. the different appsettings.json files
          6. the properties directory with launchSettings.json
          7. SwaggerUI for testing
       2. Entity Framework Core
           1. Inside of TrackMyStuffAPI we have chosen to use EF Core as an Object Relational Mapper.
           2. Our EF Core specific components are things like:
              1. The migration folder
              2. The "dotnet ef" family of CLI commands we use for migrations and database updates
              3. The TrackMyStuffContext that inherits from DBContext
              4. The structure of our model classes is influenced by EF Core
           3. EF Core, like ADO.NET only concerns itself with database access. Getting things to and from our database. 