# Api
![img](https://api.foxycart.com/assets/images/postman_interface.png)
### Creating requests/queries
- http://localhost:5000/api/movies/2
- http://localhost:5000/api/movies/2/casts
- http://localhost:5000/api/movies/1/casts/2
- http://localhost:5000/api/movies/4 --> return error 404
- http://localhost:5000/api/movies/2/casts/4 --> return error 404

### Api available in json and XML format
- http://localhost:5000/api/movies/1/casts/1?Accept=application/xml
- http://localhost:5000/api/movies/1/casts/1?Accept=application/json

## Entity Framework
### How to do a Migration (terminal)

- ../Api>$ dotnet tool install --global dotnet-ef
- ../Api>$ dotnet ef migrations add MovieInfoInitialMigration
- ../Api>$ dotnet ef database update
