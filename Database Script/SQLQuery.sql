CREATE DATABASE WebinarRegistration;

USE WebinarRegistration;

CREATE TABLE Registrations (
    Id INT PRIMARY KEY IDENTITY,
    WebinarTopic NVARCHAR(100) NOT NULL,
    FirstName NVARCHAR(50) NOT NULL,
    LastName NVARCHAR(50) NOT NULL,
    Email NVARCHAR(100) NOT NULL,
    Company NVARCHAR(100),
    Title NVARCHAR(100),
    Questions NVARCHAR(MAX)
);


select * from Registrations
