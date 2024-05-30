# AMADEUS
Technical Test.
![This is an alt text.](/img.jpg "Amadeus technical test")

## Recomendations

* Try to use the git branch `Products` because of the tests are uncompleted, if you have any trouble, you case use the next command on windows:
    ```
    # go to repository directory
    cd <repository-name>

    # list every remote branch, after that create those branches in your local repostiroy
    git branch -r | ForEach-Object {
        if ($_ -notmatch '->') {
            $remoteBranch = $_.Trim()
            $localBranch = $remoteBranch -replace 'origin/', ''
            git branch --track $localBranch $remoteBranch
        }
    }

    # Update the local branches
    git fetch --all
    ```
* First create a database in sql server, the name should be "AMADEUS".
* Execute the query in `queryDatab.sql`
* Change the database password in every `settings.json`
* Check the API endpoint inside of the frontend  file `environment.ts`, in any case you can change the url.
* This project has 2 modules:
    * `Auth`, the route is `http://localhost:4200/auth` the default user is : "email":"admi1@mail.com", "password":"admin1234", nevertheless, the login is no require becase `Guard` is not working, therefore,  you can use the dashboard without authentication. 
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
        1. Products test
3. `queryDatab.sql` has sql server query, it is require for creating table and data test.


Author : Italo Guevara