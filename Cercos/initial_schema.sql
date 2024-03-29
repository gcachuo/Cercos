﻿create table Users
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
create table Shapes
(
    Id       int primary key identity (1,1) not null,
    ClientId int,
    Code     varchar(50) unique,
    Name     varchar(50),
    constraint Shapes_Clients_ClientId_fk
        foreign key (ClientId) references Clients (Id)
            on update cascade on delete cascade
)
create table Orders
(
    Id       int primary key identity (1,1) not null,
    ClientId int,
    ShapeId int,
    constraint Orders_Clients_ClientId_fk
        foreign key (ClientId) references Clients (Id)
            on update cascade on delete cascade,
    constraint Orders_Shapes_ShapeId_fk
        foreign key (ShapeId) references Shapes (Id)
)