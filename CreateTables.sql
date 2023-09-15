CREATE TABLE Apartments
(
    Id INT PRIMARY KEY IDENTITY,
    NumberOfApartment INT DEFAULT 18, 
    Url VARCHAR(500) NOT NULL,
    Price float (20) NOT NULL,
    Rooms INT
);
 
CREATE TABLE ApartmentPriceHistory
(
    Id INT PRIMARY KEY IDENTITY,
    ApartmentId INT REFERENCES Apartments (Id),
    PriceChangeDate Date
);