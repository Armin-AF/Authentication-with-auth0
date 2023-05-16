# SecureAPIAut0 Demo Project

This is a demo project that demonstrates how to use Auth0 for authentication in an ASP.NET Core Web API project. Auth0 is a cloud-based identity and access management platform that provides authentication, authorization, and user management solutions.

## Prerequisites
To run this project, you will need the following:

- An Auth0 account
- .NET 6 SDK or higher installed on your machine
- An IDE such as Visual Studio or Visual Studio Code

## Getting Started
- Clone the repository or download the source code.
- In the appsettings.json file, replace the Domain and Audience values with your Auth0 account's domain and audience. You can find these values in your Auth0 dashboard.

```bash
"Auth0": {
  "Domain": "https://your-domain.auth0.com/",
  "Audience": "https://your-audience.com/"
}
```
- Run the application. You can do this using the command-line interface or your IDE. The application will start on http://localhost:5000.
- To test the application's endpoints, use an HTTP client like Postman or cURL. There are three endpoints available:

. GET api/public: Returns a public message.
. GET api/private: Returns a private message that requires authentication.
. GET api/private-scoped: Returns a message that requires authentication and the read:messages scope.
. GET api/claims: Returns all the claims of the token.

You can authenticate by including an Authorization header with a valid JWT token in the format Bearer <token>. You can obtain a JWT token by logging in to your Auth0 account and following the instructions in the documentation.

## More Information
For more information on using Auth0 in ASP.NET Core, see the official documentation.
https://auth0.com/docs
