USE [FlightDB]
GO
/****** Object:  Table [dbo].[Flight]    Script Date: 11/02/2011 23:38:56 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Flight](
	[FlightID] [nvarchar](10) NOT NULL,
	[Capacity] [int] NOT NULL,
 CONSTRAINT [PK_Flight] PRIMARY KEY CLUSTERED 
(
	[FlightID] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Destination]    Script Date: 11/02/2011 23:38:56 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Destination](
	[CityCode] [nvarchar](10) NOT NULL,
	[City] [nvarchar](50) NOT NULL,
 CONSTRAINT [PK_Table_1] PRIMARY KEY CLUSTERED 
(
	[CityCode] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Route]    Script Date: 11/02/2011 23:38:56 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Route](
	[RouteID] [int] NOT NULL,
	[FlightID] [nvarchar](10) NOT NULL,
	[FlightTime] [nvarchar](10) NOT NULL,
	[StartCity] [nvarchar](10) NOT NULL,
	[EndCity] [nvarchar](10) NOT NULL,
	[AdultFare] [real] NOT NULL,
	[ChildFare] [real] NOT NULL,
 CONSTRAINT [PK_Route] PRIMARY KEY CLUSTERED 
(
	[RouteID] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Reservation]    Script Date: 11/02/2011 23:38:56 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Reservation](
	[ReservationID] [nvarchar](10) NOT NULL,
	[RouteID] [int] NOT NULL,
	[ReservationDate] [date] NOT NULL,
	[FlightDate] [date] NOT NULL,
 CONSTRAINT [PK_Reservation] PRIMARY KEY CLUSTERED 
(
	[ReservationID] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Passenger]    Script Date: 11/02/2011 23:38:56 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Passenger](
	[PassengerID] [int] NOT NULL,
	[PassengerName] [nvarchar](50) NOT NULL,
	[PassportNo] [nvarchar](50) NOT NULL,
	[ExpiryDate] [date] NOT NULL,
	[ReservationID] [nvarchar](10) NOT NULL,
 CONSTRAINT [PK_Passenger] PRIMARY KEY CLUSTERED 
(
	[PassengerID] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  ForeignKey [FK_Passenger_Reservation]    Script Date: 11/02/2011 23:38:56 ******/
ALTER TABLE [dbo].[Passenger]  WITH CHECK ADD  CONSTRAINT [FK_Passenger_Reservation] FOREIGN KEY([ReservationID])
REFERENCES [dbo].[Reservation] ([ReservationID])
GO
ALTER TABLE [dbo].[Passenger] CHECK CONSTRAINT [FK_Passenger_Reservation]
GO
/****** Object:  ForeignKey [FK_Reservation_Route]    Script Date: 11/02/2011 23:38:56 ******/
ALTER TABLE [dbo].[Reservation]  WITH CHECK ADD  CONSTRAINT [FK_Reservation_Route] FOREIGN KEY([RouteID])
REFERENCES [dbo].[Route] ([RouteID])
GO
ALTER TABLE [dbo].[Reservation] CHECK CONSTRAINT [FK_Reservation_Route]
GO
/****** Object:  ForeignKey [FK_Route_Destination]    Script Date: 11/02/2011 23:38:56 ******/
ALTER TABLE [dbo].[Route]  WITH CHECK ADD  CONSTRAINT [FK_Route_Destination] FOREIGN KEY([StartCity])
REFERENCES [dbo].[Destination] ([CityCode])
GO
ALTER TABLE [dbo].[Route] CHECK CONSTRAINT [FK_Route_Destination]
GO
/****** Object:  ForeignKey [FK_Route_Destination1]    Script Date: 11/02/2011 23:38:56 ******/
ALTER TABLE [dbo].[Route]  WITH CHECK ADD  CONSTRAINT [FK_Route_Destination1] FOREIGN KEY([EndCity])
REFERENCES [dbo].[Destination] ([CityCode])
GO
ALTER TABLE [dbo].[Route] CHECK CONSTRAINT [FK_Route_Destination1]
GO
/****** Object:  ForeignKey [FK_Route_Flight]    Script Date: 11/02/2011 23:38:56 ******/
ALTER TABLE [dbo].[Route]  WITH CHECK ADD  CONSTRAINT [FK_Route_Flight] FOREIGN KEY([FlightID])
REFERENCES [dbo].[Flight] ([FlightID])
GO
ALTER TABLE [dbo].[Route] CHECK CONSTRAINT [FK_Route_Flight]
GO
