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
insert Apartments values (5,'testurl5',2000000,1)
insert Apartments values (6,'testurl6',3000000,2)
insert Apartments values (7,'testurl7',4000000,3)
insert Apartments values (8,'testurl8',5000000,4)
insert Apartments values (9,'testurl9',30000000,10)
insert Apartments values (10,'testurl10',40000000,10)


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
insert ApartmentPriceHistory values (1,'2023-01-08',1700000)
insert ApartmentPriceHistory values (2,'2023-02-08',2700000)
insert ApartmentPriceHistory values (3,'2023-03-08',3700000)
insert ApartmentPriceHistory values (4,'2023-12-08',5700000)
insert ApartmentPriceHistory values (1,'2023-05-09',2700000)
insert ApartmentPriceHistory values (2,'2023-06-09',3700000)
insert ApartmentPriceHistory values (3,'2023-07-09',4700000)
insert ApartmentPriceHistory values (4,'2023-8-09',7770000)
insert ApartmentPriceHistory values (5,'2023-9-09',18500000)
insert ApartmentPriceHistory values (5,'2023-11-09',29500000)
insert ApartmentPriceHistory values (6,'2023-10-08',5400000)
insert ApartmentPriceHistory values (6,'2023-10-18',5300000)
insert ApartmentPriceHistory values (6,'2023-11-08',5200000)
insert ApartmentPriceHistory values (7,'2023-9-18',4300000)
insert ApartmentPriceHistory values (7,'2023-9-08',4200000)
insert ApartmentPriceHistory values (7,'2023-10-08',4100000)
insert ApartmentPriceHistory values (8,'2023-8-08',14500000)
insert ApartmentPriceHistory values (8,'2023-8-18',13500000)
insert ApartmentPriceHistory values (8,'2023-9-08',12500000)
insert ApartmentPriceHistory values (9,'2023-7-08',11500000)
insert ApartmentPriceHistory values (9,'2023-7-18',10500000)
insert ApartmentPriceHistory values (9,'2023-6-08',9500000)
insert ApartmentPriceHistory values (10,'2023-5-08',54500000)
insert ApartmentPriceHistory values (10,'2023-5-18',53500000)
insert ApartmentPriceHistory values (10,'2023-4-08',52500000)
insert ApartmentPriceHistory values (10,'2023-4-18',51500000)

