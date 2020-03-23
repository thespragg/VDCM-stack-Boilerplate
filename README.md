# Vue.js/dotnet core Web API/MondgoDB boilerplate - With authentication
dotnet core 3.1

## Project setup
To fully configure & run the boilerplate follow the steps below.

### MongoDb Setup
Install mongodb, run it using 'mongo' from the command line.
Create the users database:
```
use AccountDb
```

### Configure JWT
The server uses JWT to authenticate the API, these require a little bit of setup, follow the steps below and edit the server files:

First open Helpers.JwtProvider and change the following lines to your own audience and issuer info.
```
Audience = "boiler",
Issuer = "boiler"
```

In MiddleWare.Authentication, change the follow lines to match what you've put above:
```
ValidIssuer = "boiler",
ValidAudience = "boiler"
```

In appsettings.json change the following lines, you should make sure to change the secret to something unique.
```
"secret": "i7Y6SLHtKJgoRjGWXTTUzpPZ7x5zre7hsnle245zcoiFQOWSEULkr7Dem0GNhHUP9Q200UahjvY5UTQjvwcJv4Iyer7EPjxzltOpLI",
"expirationInMinutes": 1440
```

### FrontEnd setup
Install the npm dependencies:
```
npm install
```
#### Compiles and hot-reloads for development
```
npm run serve
```

#### Compiles and minifies for production
```
npm run build
```

#### Lints and fixes files
```
npm run lint
```

### Dependencies

#### Frontend
* Vuex
* Vue-router
* Axios

#### Backend
* Microsoft.AspNetCore.Authentication.JwtBearer
* Konscious.Security.Cryptography.Argon2
* Microsoft.EntityFrameworkCore.SqlServer
* Microsoft.EntityFrameworkCore.Tools
* Microsoft.Extensions.Logging.Debug
* Microsoft.IdentityModel.Tokens
* Microsoft.VisualStudio.Web.CodeGeneration.Design
* MongoDB.Driver
* System.IdentityModel.Tokens.Jwt
