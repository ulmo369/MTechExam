# MTechExam

## Employee System

This is a sample Employee Management System project. It allows users to manage employee records, including filtering and sorting employees by birth date. The project also demonstrates the validation of RFC formats and ensures the uniqueness of RFCs

## Prerequisites

Before running the project, ensure you have the following installed:

- [.NET SDK](https://dotnet.microsoft.com/download) (Version 6.0 or later)
- [SQLite](https://www.sqlite.org/download.html) (for the database)


## 1. Clone the Repository

Clone this repository to your local machine using the following command:
```bash
git clone https://github.com/ulmo369/MTechExam.git
```

## 2. Run the Project


### restore dependencies:
```bash
dotnet restore
```

### Apply database migrations:
```bash
dotnet ef migrations add InitialCreate
dotnet ef database update
```

### Run the project:
```bash
dotnet run
```

The project will be running on `http://localhost:5158`