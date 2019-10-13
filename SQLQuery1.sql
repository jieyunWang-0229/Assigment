CREATE TABLE [dbo].[Customers] (
    [Id]        INT IDENTITY (1, 1) NOT NULL,
    [FirstName] NVARCHAR (MAX) NOT NULL,
    [LastName]  NVARCHAR (MAX) NOT NULL,
    [Password]  NVARCHAR (MAX) NOT NULL,
    [Email]     NVARCHAR (MAX) NOT NULL,
    [Moblie]    NVARCHAR (MAX) NOT NULL,
    [Dob]       DATE           NOT NULL,
    [Address]   NVARCHAR (MAX) NOT NULL,
    [UserId]    NVARCHAR (MAX) NOT NULL,
    PRIMARY KEY  (Id)
);
GO


CREATE TABLE [dbo].[Attractions] (
    [AttractionId] INT IDENTITY (1, 1) NOT NULL,
    [AttractionName] NVARCHAR (MAX) NOT NULL,
    [Location]     NVARCHAR (MAX) NOT NULL,
	[Longitude]    DECIMAL(38) NOT NULL,
	[Latitude]     DECIMAL(38) NOT NULL,
    [Detail]       NVARCHAR (MAX) NOT NULL,
	[Image]        NVARCHAR (MAX) NOT NULL,
    PRIMARY KEY (AttractionId )
);
GO


CREATE TABLE [dbo].[Tickets] (
    [TicketId]       INT IDENTITY (1, 1) NOT NULL,
	[TicketName]     NVARCHAR (MAX) NOT NULL,
    [TicketDate]     DATE           NOT NULL,
    [TicketType]     NVARCHAR (MAX) NOT NULL,
    [TicketPrice]    DECIMAL (18)   NOT NULL,
    [TicketTotalQty] INT            NOT NULL,
    [AttractionId]   INT            NOT NULL,
    PRIMARY KEY CLUSTERED (TicketId),
    FOREIGN KEY (AttractionId) REFERENCES Attractions(AttractionId)
);
GO

CREATE TABLE [dbo].[Orders] (
    [OrderId]     INT          IDENTITY (1, 1) NOT NULL,
    [OrderDate]   DATE         NOT NULL,
    [OrderAmount] DECIMAL (18) NOT NULL,
    [TicketQty]   INT          NOT NULL,
    [TicketId]    INT          NOT NULL,
    [CustomersId] INT          NOT NULL,
    PRIMARY KEY CLUSTERED (OrderId ASC),
    FOREIGN KEY (TicketId) REFERENCES Tickets(TicketId),
    FOREIGN KEY (CustomersId) REFERENCES Customers (Id)
);
GO
CREATE TABLE [dbo].[CartStatus] (
    [CartStatusId]INT          IDENTITY (1, 1) NOT NULL,
    [CartStatu]   DATE         NOT NULL,
    PRIMARY KEY CLUSTERED (CartStatusId ASC),    
);
GO

CREATE TABLE [dbo].[Cart] (
    [CartId]       INT          IDENTITY (1, 1) NOT NULL,
	[TicketId]    INT          NOT NULL,
    [CartStatusId]INT          NOT NULL,
   	[CustomersId] INT          NOT NULL
    PRIMARY KEY CLUSTERED (CartStatusId ASC),
    FOREIGN KEY (TicketId) REFERENCES Tickets(TicketId),
    FOREIGN KEY (CustomersId) REFERENCES Customers (Id),
	FOREIGN KEY (CartStatusId) REFERENCES CartStatus (CartStatusId)

);
GO