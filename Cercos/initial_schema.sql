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
    ShapeId  int,
    constraint Orders_Clients_ClientId_fk
        foreign key (ClientId) references Clients (Id)
            on update cascade on delete cascade,
    constraint Orders_Shapes_ShapeId_fk
        foreign key (ShapeId) references Shapes (Id)
)
create table Measures
(
    Id   int primary key identity (1,1) not null,
    Name varchar(50) unique
);
SET IDENTITY_INSERT Measures ON;
INSERT INTO Measures (Id, Name)
VALUES (1, N'Milimetros');
INSERT INTO Measures (Id, Name)
VALUES (2, N'Fierros');
SET IDENTITY_INSERT Measures OFF;
create table Materials
(
    Id        int primary key identity (1,1) not null,
    Name      varchar(50) unique,
    MeasureId int,
    constraint Materials_Measures_MeasureId_fk foreign key (MeasureId) references Measures (Id) on update cascade on delete cascade
);
SET IDENTITY_INSERT Materials ON;
INSERT INTO Materials (Id, Name, MeasureId)
VALUES (1, N'Hule',2);
INSERT INTO Materials (Id, Name, MeasureId)
VALUES (2, N'Salpa',1);
INSERT INTO Materials (Id, Name, MeasureId)
VALUES (3, N'Cuero',1);
INSERT INTO Materials (Id, Name, MeasureId)
VALUES (4, N'Microporosa',2);
INSERT INTO Materials (Id, Name, MeasureId)
VALUES (5, N'PVC',1);
INSERT INTO Materials (Id, Name, MeasureId)
VALUES (6, N'TR',1);
INSERT INTO Materials (Id, Name, MeasureId)
VALUES (7, N'Mixto',2);
INSERT INTO Materials (Id, Name, MeasureId)
VALUES (8, N'Otro',2);
SET IDENTITY_INSERT Materials OFF;