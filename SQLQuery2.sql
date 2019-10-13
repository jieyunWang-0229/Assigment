

CREATE TABLE [dbo].[Category] (
    [CategoryId] INT IDENTITY (1, 1) NOT NULL,
    [CategoryName] NVARCHAR (MAX) NOT NULL,
    
    PRIMARY KEY (CategoryId )
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
	[CategoryId]   INT NOT NULL,
    PRIMARY KEY (AttractionId ),
	FOREIGN KEY (CategoryId) REFERENCES Category(CategoryId)
);
GO