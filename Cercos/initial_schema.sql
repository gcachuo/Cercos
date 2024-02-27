create table Users
(
    Id       int primary key identity (1,1) not null,
    FullName varchar(50),
    Password varchar(500)
);
create table Clients
(
    Id      int primary key identity (1,1) not null,
    Name    varchar(50) unique,
    Address varchar(100),
    Phone   varchar(100),
    Email   varchar(100)
);