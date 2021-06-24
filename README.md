## INSTRUCTIONS

### PREREQUISITES

Make sure that SQL server service is running locally since we will be using `localhost` to host our database.

 ### RUNNING PROJECT

1. Clone project using this command - git clone https://github.com/hardikshah7/HealthCatalystAssessment.git
2. Navigate to the folder which contains the solution.
3. Open Administrator Command prompt at this location and run `dotnet run`.
    OR
   Open the solution file using visual studio and hit Run/F5.
4. Use Swagger UI to send GET or POST requests.
    OR
   Use POSTMAN to send requests.

Sample POST request - 
Request URL- `http://localhost:5002​/api​/User`

Body-

`{
  "firstName": "Readme",
  "lastName": "User",
  "address": "Visual studio",
  "age": 4,
  "interests": [
    "Reading"
  ]
}`

Sample GET request - 
`http://localhost:5002/api/User/search?searchTerm=Readme`

NOTE - The database will be seeded automatically upon startup. There are no additional steps needed.

### Powershell scripts(Extra Credit) -
The project contains add.ps1 and search.ps1 scripts to add or search users.

#### TESTS - 
I had some issues getting the unit tests to run. I would appreciate any feedback on where I went wrong setting up the tests.
