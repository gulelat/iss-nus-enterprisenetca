
-- --------------------------------------------------
-- Entity Designer DDL Script for SQL Server 2005, 2008, and Azure
-- --------------------------------------------------
-- Date Created: 10/22/2011 09:32:47
-- Generated from EDMX file: C:\Users\Pragati\ISS\Semester 4\Enterprise .NET\CA\Flight_DLL\Flight_DLL\FlightModel.edmx
-- --------------------------------------------------

SET QUOTED_IDENTIFIER OFF;
GO
USE [FlightDB];
GO
IF SCHEMA_ID(N'dbo') IS NULL EXECUTE(N'CREATE SCHEMA [dbo]');
GO

-- --------------------------------------------------
-- Dropping existing FOREIGN KEY constraints
-- --------------------------------------------------

IF OBJECT_ID(N'[dbo].[FK_Passenger_Reservation]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[Passenger] DROP CONSTRAINT [FK_Passenger_Reservation];
GO
IF OBJECT_ID(N'[dbo].[FK_Reservation_Route]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[Reservation] DROP CONSTRAINT [FK_Reservation_Route];
GO
IF OBJECT_ID(N'[dbo].[FK_Route_Destination]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[Route] DROP CONSTRAINT [FK_Route_Destination];
GO
IF OBJECT_ID(N'[dbo].[FK_Route_Destination1]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[Route] DROP CONSTRAINT [FK_Route_Destination1];
GO
IF OBJECT_ID(N'[dbo].[FK_Route_Flight]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[Route] DROP CONSTRAINT [FK_Route_Flight];
GO

-- --------------------------------------------------
-- Dropping existing tables
-- --------------------------------------------------

IF OBJECT_ID(N'[dbo].[Destination]', 'U') IS NOT NULL
    DROP TABLE [dbo].[Destination];
GO
IF OBJECT_ID(N'[dbo].[Flight]', 'U') IS NOT NULL
    DROP TABLE [dbo].[Flight];
GO
IF OBJECT_ID(N'[dbo].[Passenger]', 'U') IS NOT NULL
    DROP TABLE [dbo].[Passenger];
GO
IF OBJECT_ID(N'[dbo].[Reservation]', 'U') IS NOT NULL
    DROP TABLE [dbo].[Reservation];
GO
IF OBJECT_ID(N'[dbo].[Route]', 'U') IS NOT NULL
    DROP TABLE [dbo].[Route];
GO

-- --------------------------------------------------
-- Creating all tables
-- --------------------------------------------------

-- Creating table 'Destinations'
CREATE TABLE [dbo].[Destinations] (
    [CityCode] nvarchar(10)  NOT NULL,
    [City] nvarchar(50)  NOT NULL
);
GO

-- Creating table 'Flights'
CREATE TABLE [dbo].[Flights] (
    [FlightID] nvarchar(10)  NOT NULL,
    [Capacity] int  NOT NULL
);
GO

-- Creating table 'Passengers'
CREATE TABLE [dbo].[Passengers] (
    [PassengerID] int  NOT NULL,
    [PassengerName] nvarchar(50)  NOT NULL,
    [PassportNo] nvarchar(50)  NOT NULL,
    [ExpiryDate] datetime  NOT NULL,
    [ReservationID] nvarchar(10)  NOT NULL
);
GO

-- Creating table 'Reservations'
CREATE TABLE [dbo].[Reservations] (
    [ReservationID] nvarchar(10)  NOT NULL,
    [RouteID] int  NOT NULL,
    [ReservationDate] datetime  NOT NULL
);
GO

-- Creating table 'Routes'
CREATE TABLE [dbo].[Routes] (
    [RouteID] int  NOT NULL,
    [FlightID] nvarchar(10)  NOT NULL,
    [FlightTime] nvarchar(10)  NOT NULL,
    [StartCity] nvarchar(10)  NOT NULL,
    [EndCity] nvarchar(10)  NOT NULL,
    [AdultFare] real  NOT NULL,
    [ChildFare] real  NOT NULL
);
GO

-- --------------------------------------------------
-- Creating all PRIMARY KEY constraints
-- --------------------------------------------------

-- Creating primary key on [CityCode] in table 'Destinations'
ALTER TABLE [dbo].[Destinations]
ADD CONSTRAINT [PK_Destinations]
    PRIMARY KEY CLUSTERED ([CityCode] ASC);
GO

-- Creating primary key on [FlightID] in table 'Flights'
ALTER TABLE [dbo].[Flights]
ADD CONSTRAINT [PK_Flights]
    PRIMARY KEY CLUSTERED ([FlightID] ASC);
GO

-- Creating primary key on [PassengerID] in table 'Passengers'
ALTER TABLE [dbo].[Passengers]
ADD CONSTRAINT [PK_Passengers]
    PRIMARY KEY CLUSTERED ([PassengerID] ASC);
GO

-- Creating primary key on [ReservationID] in table 'Reservations'
ALTER TABLE [dbo].[Reservations]
ADD CONSTRAINT [PK_Reservations]
    PRIMARY KEY CLUSTERED ([ReservationID] ASC);
GO

-- Creating primary key on [RouteID] in table 'Routes'
ALTER TABLE [dbo].[Routes]
ADD CONSTRAINT [PK_Routes]
    PRIMARY KEY CLUSTERED ([RouteID] ASC);
GO

-- --------------------------------------------------
-- Creating all FOREIGN KEY constraints
-- --------------------------------------------------

-- Creating foreign key on [StartCity] in table 'Routes'
ALTER TABLE [dbo].[Routes]
ADD CONSTRAINT [FK_Route_Destination]
    FOREIGN KEY ([StartCity])
    REFERENCES [dbo].[Destinations]
        ([CityCode])
    ON DELETE NO ACTION ON UPDATE NO ACTION;

-- Creating non-clustered index for FOREIGN KEY 'FK_Route_Destination'
CREATE INDEX [IX_FK_Route_Destination]
ON [dbo].[Routes]
    ([StartCity]);
GO

-- Creating foreign key on [EndCity] in table 'Routes'
ALTER TABLE [dbo].[Routes]
ADD CONSTRAINT [FK_Route_Destination1]
    FOREIGN KEY ([EndCity])
    REFERENCES [dbo].[Destinations]
        ([CityCode])
    ON DELETE NO ACTION ON UPDATE NO ACTION;

-- Creating non-clustered index for FOREIGN KEY 'FK_Route_Destination1'
CREATE INDEX [IX_FK_Route_Destination1]
ON [dbo].[Routes]
    ([EndCity]);
GO

-- Creating foreign key on [FlightID] in table 'Routes'
ALTER TABLE [dbo].[Routes]
ADD CONSTRAINT [FK_Route_Flight]
    FOREIGN KEY ([FlightID])
    REFERENCES [dbo].[Flights]
        ([FlightID])
    ON DELETE NO ACTION ON UPDATE NO ACTION;

-- Creating non-clustered index for FOREIGN KEY 'FK_Route_Flight'
CREATE INDEX [IX_FK_Route_Flight]
ON [dbo].[Routes]
    ([FlightID]);
GO

-- Creating foreign key on [ReservationID] in table 'Passengers'
ALTER TABLE [dbo].[Passengers]
ADD CONSTRAINT [FK_Passenger_Reservation]
    FOREIGN KEY ([ReservationID])
    REFERENCES [dbo].[Reservations]
        ([ReservationID])
    ON DELETE NO ACTION ON UPDATE NO ACTION;

-- Creating non-clustered index for FOREIGN KEY 'FK_Passenger_Reservation'
CREATE INDEX [IX_FK_Passenger_Reservation]
ON [dbo].[Passengers]
    ([ReservationID]);
GO

-- Creating foreign key on [RouteID] in table 'Reservations'
ALTER TABLE [dbo].[Reservations]
ADD CONSTRAINT [FK_Reservation_Route]
    FOREIGN KEY ([RouteID])
    REFERENCES [dbo].[Routes]
        ([RouteID])
    ON DELETE NO ACTION ON UPDATE NO ACTION;

-- Creating non-clustered index for FOREIGN KEY 'FK_Reservation_Route'
CREATE INDEX [IX_FK_Reservation_Route]
ON [dbo].[Reservations]
    ([RouteID]);
GO

-- --------------------------------------------------
-- Script has ended
-- --------------------------------------------------