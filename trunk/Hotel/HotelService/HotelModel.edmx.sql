
-- --------------------------------------------------
-- Entity Designer DDL Script for SQL Server 2005, 2008, and Azure
-- --------------------------------------------------
-- Date Created: 10/16/2011 18:54:25
-- Generated from EDMX file: C:\code\ASP.NET\HotelService\HotelService\HotelModel.edmx
-- --------------------------------------------------

SET QUOTED_IDENTIFIER OFF;
GO
USE [HotelDB];
GO
IF SCHEMA_ID(N'dbo') IS NULL EXECUTE(N'CREATE SCHEMA [dbo]');
GO

-- --------------------------------------------------
-- Dropping existing FOREIGN KEY constraints
-- --------------------------------------------------

IF OBJECT_ID(N'[dbo].[FK_RoomTypeRoom]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[Rooms] DROP CONSTRAINT [FK_RoomTypeRoom];
GO
IF OBJECT_ID(N'[dbo].[FK_RoomRoomReservation]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[RoomReservations] DROP CONSTRAINT [FK_RoomRoomReservation];
GO
IF OBJECT_ID(N'[dbo].[FK_GuestRoomReservation]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[RoomReservations] DROP CONSTRAINT [FK_GuestRoomReservation];
GO
IF OBJECT_ID(N'[dbo].[FK_RoomReservationPayment]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[Payments] DROP CONSTRAINT [FK_RoomReservationPayment];
GO

-- --------------------------------------------------
-- Dropping existing tables
-- --------------------------------------------------

IF OBJECT_ID(N'[dbo].[RoomTypes]', 'U') IS NOT NULL
    DROP TABLE [dbo].[RoomTypes];
GO
IF OBJECT_ID(N'[dbo].[Rooms]', 'U') IS NOT NULL
    DROP TABLE [dbo].[Rooms];
GO
IF OBJECT_ID(N'[dbo].[RoomReservations]', 'U') IS NOT NULL
    DROP TABLE [dbo].[RoomReservations];
GO
IF OBJECT_ID(N'[dbo].[Guests]', 'U') IS NOT NULL
    DROP TABLE [dbo].[Guests];
GO
IF OBJECT_ID(N'[dbo].[Payments]', 'U') IS NOT NULL
    DROP TABLE [dbo].[Payments];
GO

-- --------------------------------------------------
-- Creating all tables
-- --------------------------------------------------

-- Creating table 'RoomTypes'
CREATE TABLE [dbo].[RoomTypes] (
    [Id] int IDENTITY(1,1) NOT NULL,
    [Capacity] nvarchar(max)  NOT NULL,
    [DailyCharge] int  NOT NULL,
    [Name] nvarchar(max)  NOT NULL
);
GO

-- Creating table 'Rooms'
CREATE TABLE [dbo].[Rooms] (
    [Id] int IDENTITY(1,1) NOT NULL,
    [RoomNo] nvarchar(max)  NOT NULL,
    [RoomType_Id] int  NOT NULL
);
GO

-- Creating table 'RoomReservations'
CREATE TABLE [dbo].[RoomReservations] (
    [Id] int IDENTITY(1,1) NOT NULL,
    [StartDate] datetime  NOT NULL,
    [EndDate] datetime  NOT NULL,
    [NoOfGuest] int  NOT NULL,
    [Room_Id] int  NOT NULL,
    [Guest_Id] int  NOT NULL
);
GO

-- Creating table 'Guests'
CREATE TABLE [dbo].[Guests] (
    [Id] int IDENTITY(1,1) NOT NULL,
    [Name] nvarchar(max)  NOT NULL,
    [PassportNo] nvarchar(max)  NOT NULL
);
GO

-- Creating table 'Payments'
CREATE TABLE [dbo].[Payments] (
    [id] int IDENTITY(1,1) NOT NULL,
    [GuestAccount] nvarchar(max)  NOT NULL,
    [TotalCharge] nvarchar(max)  NOT NULL,
    [CardType] nvarchar(max)  NOT NULL,
    [RoomReservation_Id] int  NOT NULL
);
GO

-- --------------------------------------------------
-- Creating all PRIMARY KEY constraints
-- --------------------------------------------------

-- Creating primary key on [Id] in table 'RoomTypes'
ALTER TABLE [dbo].[RoomTypes]
ADD CONSTRAINT [PK_RoomTypes]
    PRIMARY KEY CLUSTERED ([Id] ASC);
GO

-- Creating primary key on [Id] in table 'Rooms'
ALTER TABLE [dbo].[Rooms]
ADD CONSTRAINT [PK_Rooms]
    PRIMARY KEY CLUSTERED ([Id] ASC);
GO

-- Creating primary key on [Id] in table 'RoomReservations'
ALTER TABLE [dbo].[RoomReservations]
ADD CONSTRAINT [PK_RoomReservations]
    PRIMARY KEY CLUSTERED ([Id] ASC);
GO

-- Creating primary key on [Id] in table 'Guests'
ALTER TABLE [dbo].[Guests]
ADD CONSTRAINT [PK_Guests]
    PRIMARY KEY CLUSTERED ([Id] ASC);
GO

-- Creating primary key on [id] in table 'Payments'
ALTER TABLE [dbo].[Payments]
ADD CONSTRAINT [PK_Payments]
    PRIMARY KEY CLUSTERED ([id] ASC);
GO

-- --------------------------------------------------
-- Creating all FOREIGN KEY constraints
-- --------------------------------------------------

-- Creating foreign key on [RoomType_Id] in table 'Rooms'
ALTER TABLE [dbo].[Rooms]
ADD CONSTRAINT [FK_RoomTypeRoom]
    FOREIGN KEY ([RoomType_Id])
    REFERENCES [dbo].[RoomTypes]
        ([Id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;

-- Creating non-clustered index for FOREIGN KEY 'FK_RoomTypeRoom'
CREATE INDEX [IX_FK_RoomTypeRoom]
ON [dbo].[Rooms]
    ([RoomType_Id]);
GO

-- Creating foreign key on [Room_Id] in table 'RoomReservations'
ALTER TABLE [dbo].[RoomReservations]
ADD CONSTRAINT [FK_RoomRoomReservation]
    FOREIGN KEY ([Room_Id])
    REFERENCES [dbo].[Rooms]
        ([Id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;

-- Creating non-clustered index for FOREIGN KEY 'FK_RoomRoomReservation'
CREATE INDEX [IX_FK_RoomRoomReservation]
ON [dbo].[RoomReservations]
    ([Room_Id]);
GO

-- Creating foreign key on [Guest_Id] in table 'RoomReservations'
ALTER TABLE [dbo].[RoomReservations]
ADD CONSTRAINT [FK_GuestRoomReservation]
    FOREIGN KEY ([Guest_Id])
    REFERENCES [dbo].[Guests]
        ([Id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;

-- Creating non-clustered index for FOREIGN KEY 'FK_GuestRoomReservation'
CREATE INDEX [IX_FK_GuestRoomReservation]
ON [dbo].[RoomReservations]
    ([Guest_Id]);
GO

-- Creating foreign key on [RoomReservation_Id] in table 'Payments'
ALTER TABLE [dbo].[Payments]
ADD CONSTRAINT [FK_RoomReservationPayment]
    FOREIGN KEY ([RoomReservation_Id])
    REFERENCES [dbo].[RoomReservations]
        ([Id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;

-- Creating non-clustered index for FOREIGN KEY 'FK_RoomReservationPayment'
CREATE INDEX [IX_FK_RoomReservationPayment]
ON [dbo].[Payments]
    ([RoomReservation_Id]);
GO

-- --------------------------------------------------
-- Script has ended
-- --------------------------------------------------