# AMADEUS

![This is an alt text.](/img.jpg "Amadeus technical test")

## Recomendations

* First create a database in sql server, the name should be "AMADEUS".
* Execute the query in `queryDatab.sql`
* Change the database password in every `settings.json`
* Check the API endpoint inside of the frontend  file `environment.ts`, in any case you can change the url.
* This project has 2 modules:
    * `Auth`, the route is `http://localhost:4200/auth` the default user is : "email":"admi1@mail.com", "password":"admin1234", nevertheless, the login is no require because `Guard` is not working, therefore,  you can use the dashboard without authentication. 
    * `Dashboard`, the route is `http://localhost:4200`

## Structure

1. amadeus.frontend (Angular v.17)
    * Primeng(v17).
    * Tailwind.
2. amadeus.backend
    1. src.
        1. BuildingBlocks
            * .Net 8.0
            * .Net 6.0
        2. Auth service( .NET 8) - No require for working.
        3. Produts service( .NET 6)
            * API.
            * Application(bussiness)
                * DTO.
                * Interfaces.
                * Behavirous. 
                * Etc.
            * Infrastructure.
                * Entity framework.
                * Repository pattern.
                * UnitOfWork pattern.
            * Domain
    2. tests.
        1. Products test(XUni framework)
            * Test for every use case and validators.

3. `queryDatab.sql` has sql server query, it is require for creating table and data test.


Author : Italo Guevara