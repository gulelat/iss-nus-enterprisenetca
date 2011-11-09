
-- --------------------------------------------------
-- Entity Designer DDL Script for SQL Server 2005, 2008, and Azure
-- --------------------------------------------------
-- Date Created: 10/29/2011 11:00:43
-- Generated from EDMX file: J:\Shree\Net-II\CA\Project\trunk\TourAgency\TA.DAL\TourAgencyModel.edmx
-- --------------------------------------------------

SET QUOTED_IDENTIFIER OFF;
GO
USE [TourAgency];
GO
IF SCHEMA_ID(N'dbo') IS NULL EXECUTE(N'CREATE SCHEMA [dbo]');
GO

-- --------------------------------------------------
-- Dropping existing FOREIGN KEY constraints
-- --------------------------------------------------

IF OBJECT_ID(N'[dbo].[FK_PackageBooking]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[Bookings] DROP CONSTRAINT [FK_PackageBooking];
GO
IF OBJECT_ID(N'[dbo].[FK_BookingPassenger]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[Passengers] DROP CONSTRAINT [FK_BookingPassenger];
GO

-- --------------------------------------------------
-- Dropping existing tables
-- --------------------------------------------------

IF OBJECT_ID(N'[dbo].[Packages]', 'U') IS NOT NULL
    DROP TABLE [dbo].[Packages];
GO
IF OBJECT_ID(N'[dbo].[Bookings]', 'U') IS NOT NULL
    DROP TABLE [dbo].[Bookings];
GO
IF OBJECT_ID(N'[dbo].[Passengers]', 'U') IS NOT NULL
    DROP TABLE [dbo].[Passengers];
GO

-- --------------------------------------------------
-- Creating all tables
-- --------------------------------------------------

-- Creating table 'Packages'
CREATE TABLE [dbo].[Packages] (
    [Code] int IDENTITY(1,1) NOT NULL,
    [Name] nvarchar(max)  NOT NULL,
    [Duration] int  NOT NULL,
    [Capacity] int  NOT NULL,
    [HotelId] nvarchar(max)  NOT NULL,
    [FlightId] nvarchar(max)  NOT NULL
);
GO

-- Creating table 'Bookings'
CREATE TABLE [dbo].[Bookings] (
    [PackageCode] int  NOT NULL,
    [BookingCode] int IDENTITY(1,1) NOT NULL,
    [StartDate] datetime  NOT NULL,
    [Package_Code] int  NOT NULL
);
GO

-- Creating table 'Passengers'
CREATE TABLE [dbo].[Passengers] (
    [Id] int IDENTITY(1,1) NOT NULL,
    [Name] nvarchar(max)  NOT NULL,
    [Passport] nvarchar(max)  NOT NULL,
    [Booking_BookingCode] int  NOT NULL
);
GO

-- Creating table 'Users'
CREATE TABLE [dbo].[Users] (
    [UserId] int IDENTITY(1,1) NOT NULL,
    [Password] nvarchar(max)  NOT NULL
);
GO

-- --------------------------------------------------
-- Creating all PRIMARY KEY constraints
-- --------------------------------------------------

-- Creating primary key on [Code] in table 'Packages'
ALTER TABLE [dbo].[Packages]
ADD CONSTRAINT [PK_Packages]
    PRIMARY KEY CLUSTERED ([Code] ASC);
GO

-- Creating primary key on [BookingCode] in table 'Bookings'
ALTER TABLE [dbo].[Bookings]
ADD CONSTRAINT [PK_Bookings]
    PRIMARY KEY CLUSTERED ([BookingCode] ASC);
GO

-- Creating primary key on [Id] in table 'Passengers'
ALTER TABLE [dbo].[Passengers]
ADD CONSTRAINT [PK_Passengers]
    PRIMARY KEY CLUSTERED ([Id] ASC);
GO

-- Creating primary key on [UserId] in table 'Users'
ALTER TABLE [dbo].[Users]
ADD CONSTRAINT [PK_Users]
    PRIMARY KEY CLUSTERED ([UserId] ASC);
GO

-- --------------------------------------------------
-- Creating all FOREIGN KEY constraints
-- --------------------------------------------------

-- Creating foreign key on [Package_Code] in table 'Bookings'
ALTER TABLE [dbo].[Bookings]
ADD CONSTRAINT [FK_PackageBooking]
    FOREIGN KEY ([Package_Code])
    REFERENCES [dbo].[Packages]
        ([Code])
    ON DELETE NO ACTION ON UPDATE NO ACTION;

-- Creating non-clustered index for FOREIGN KEY 'FK_PackageBooking'
CREATE INDEX [IX_FK_PackageBooking]
ON [dbo].[Bookings]
    ([Package_Code]);
GO

-- Creating foreign key on [Booking_BookingCode] in table 'Passengers'
ALTER TABLE [dbo].[Passengers]
ADD CONSTRAINT [FK_BookingPassenger]
    FOREIGN KEY ([Booking_BookingCode])
    REFERENCES [dbo].[Bookings]
        ([BookingCode])
    ON DELETE NO ACTION ON UPDATE NO ACTION;

-- Creating non-clustered index for FOREIGN KEY 'FK_BookingPassenger'
CREATE INDEX [IX_FK_BookingPassenger]
ON [dbo].[Passengers]
    ([Booking_BookingCode]);
GO

-- --------------------------------------------------
-- Script has ended
-- --------------------------------------------------