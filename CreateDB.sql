use "TestDB2"

CREATE TABLE Apartments
(
    Id INT PRIMARY KEY IDENTITY,
    NumberOfApartment INT DEFAULT 18, 
    Url VARCHAR(500),
    Price float NOT NULL,
    Rooms INT
);

CREATE TABLE ApartmentPriceHistory
(
    Id INT PRIMARY KEY IDENTITY,
    ApartmentId INT REFERENCES Apartments (Id),
    PriceChangeDate Date,
    PriceAtDate float NOT NULL,
);

insert Apartments values (1,'testurl1',1000000,1)
insert Apartments values (2,'testurl2',1200000,2)
insert Apartments values (3,'testurl3',2000000,3)
insert Apartments values (4,'testurl4',3000000,4)
insert Apartments values (5,'testurl5',50000000,10)

insert ApartmentPriceHistory values (1,'2023-07-08',1500000)
insert ApartmentPriceHistory values (2,'2023-08-08',2500000)
insert ApartmentPriceHistory values (3,'2023-09-08',3500000)
insert ApartmentPriceHistory values (4,'2023-10-08',5500000)
insert ApartmentPriceHistory values (1,'2023-07-09',2500000)
insert ApartmentPriceHistory values (2,'2023-08-09',3500000)
insert ApartmentPriceHistory values (3,'2023-09-09',4500000)
insert ApartmentPriceHistory values (4,'2023-10-09',7500000)
insert ApartmentPriceHistory values (5,'2023-10-09',17500000)
insert ApartmentPriceHistory values (5,'2023-11-09',27500000)