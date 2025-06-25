
# Fullstack Sample

This project contains three components: an ASP.NET Core Web API written in C#, a REST API built with Django REST Framework, and an Angular project that utilizes both backends. The C# backend implements GET and POST methods for the endpoint /api/products. The DRF backend implements a GET method for the endpoint /api/categories.

## Tech Stack

**Database:** 
- SQLite


**Client:** 
- Angular 20.0.4


**Server:**  
- ASP.NET Core 8  
- Django 5.2.3  
- Django REST Framework 3.16.0



## Local Testing Instructions

1. From the root of the project, open command prompt.  

```cmd
# Navigate into the WEB API project
C:\fullstack-sample> cd \ProductsWebApi\ProductsWebApi

# Start the .NET Web API Backend 
C:\fullstack-sample\ProductsWebApi\ProductsWebApi> dotnet run
```

2. Save the listening endpoint displayed in the output. For example: http://localhost:5047
3. Open a second Command Prompt from the project root and start the Django backend.

```cmd
# Navigate into the Django project
C:\fullstack-sample> cd \category_django_backend

# Generate default categories
C:\fullstack-sample\category_django_backend\> python manage.py loaddata category_data.json

# Start the Django Backend 
C:\fullstack-sample\category_django_backend\> python manage.py runserver
```

4. Save the deployment server endpoint displayed in the output. For example: http://127.0.0.1:8000
5. Update the contents of the proxy.config.json file in the root Angular project to contain the correct target endpoints.

```cmd
# Navigate into the Angular project
C:\fullstack-sample> cd \shop

# Start the Angular frontend 
C:\fullstack-sample\category_django_backend\> ng serve
```


## Challenges

1. My experience with Django comes from working on a project that was already far along in development.  So the challenge was learning how to initialize a new project with it.


## Assumptions

1. It would be acceptable to add some initial category data in the Web API project, since this data is needed to validate that products can be created after starting on this step. I still followed through on adding some categories in the Django project using a fixture.

2. It would be acceptable to generate the Django model using the command:

```cmd
python manage.py inspectdb > models_from_db.py
```