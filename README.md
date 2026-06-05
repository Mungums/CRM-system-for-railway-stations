# CRM-system-for-railway-stations

## Создание БД
```sql
CREATE DATABASE IF NOT EXISTS CRMSystemForRailway DEFAULT CHARACTER SET utf8mb4 COLLATE utf8mb4_general_ci;
```

## Добавление таблиц
```sql
CREATE TABLE Crews (
  Id int PRIMARY KEY AUTO_INCREMENT NOT NULL,
  CrewName varchar(100) NOT NULL
);

CREATE TABLE TrainTypes (
  Id int PRIMARY KEY AUTO_INCREMENT NOT NULL,
  TypeName varchar(100) NOT NULL
);

CREATE TABLE Trains (
  StationId int NOT NULL,
  Id int PRIMARY KEY AUTO_INCREMENT NOT NULL,
  TrainTypeId int NOT NULL,
  Name varchar(100) DEFAULT NULL,
  FOREIGN KEY (TrainTypeId) REFERENCES TrainTypes(Id)
);

CREATE TABLE Stations (
  Id int PRIMARY KEY AUTO_INCREMENT NOT NULL,
  Name varchar(100) NOT NULL,
  Inn varchar(12) NOT NULL,
  Address varchar(255) DEFAULT NULL
);


CREATE TABLE Positions (
  Id int PRIMARY KEY AUTO_INCREMENT NOT NULL,
  PositionName varchar(100) NOT NULL
);

CREATE TABLE Personnel (
  Id int PRIMARY KEY AUTO_INCREMENT NOT NULL,
  StationId int NOT NULL,
  PersonInn varchar(12) NOT NULL,
  FullName varchar(150) NOT NULL,
  PositionId int NOT NULL,
  CrewId int NOT NULL,
  FOREIGN KEY (StationId) REFERENCES Stations(Id),
  FOREIGN KEY (PositionId) REFERENCES Positions(Id),
  FOREIGN KEY (CrewId) REFERENCES Crews(Id)
);

CREATE TABLE Routes (
  Id int PRIMARY KEY AUTO_INCREMENT NOT NULL,
  OwnerStationId int NOT NULL,
  TrainId int NOT NULL,
  DepartureStationId int NOT NULL,
  ArrivalStationId int NOT NULL,
  DepartureTime time NOT NULL,
  ArrivalTime time NOT NULL,
  CrewId int NOT NULL,
  FOREIGN KEY (TrainId) REFERENCES Trains(Id),
  FOREIGN KEY (OwnerStationId) REFERENCES Stations(id),
  FOREIGN KEY (DepartureStationId) REFERENCES Stations(Id),
  FOREIGN KEY (ArrivalStationId) REFERENCES Stations(Id),
  FOREIGN KEY (CrewId) REFERENCES Crews(Id)
);

CREATE TABLE RouteDetails (
  RouteId int NOT NULL,
  StopNumber int NOT NULL,
  StationId int NOT NULL,
  ArrivalTime time DEFAULT NULL,
  DepartureTime time DEFAULT NULL,
  PRIMARY KEY (RouteId, StopNumber),
  FOREIGN KEY (RouteId) REFERENCES Routes(Id),
  FOREIGN KEY (StationId) REFERENCES Stations(Id)
);
```
