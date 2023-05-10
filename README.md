
# Github API Case

A web application to show and save sales using .NET 6

##About
API to consume data from the Github API and persist it in the database according to business rules:

a) Fetch and store the top repositories for 5 languages of your choice;
b) List the repositories found;
c) View the details of each repository.

## Installation and Run

You can use docker-compose to run this application with:

```bash
  docker-compose up --build
```
There are 2 instances in the docker compose, an instance of postgres, 
the backend application writen in .NET 6

## Run Locally
When you run the docker-compose command will run in:

http://localhost:5015/

## Running Tests
The tests it's already in the Dockerfile script and runs when you build the application, you can see the logs in the terminal that you run the application

## API Reference
You can access http://localhost:5015/swagger/index.html 
to see a swagger documentation of the API

## Note
Open issues for improvements here: [issues](https://github.com/gmkranz/btg-it-price-backend-challenge/issues). 


