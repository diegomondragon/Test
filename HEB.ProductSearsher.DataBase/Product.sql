CREATE TABLE [dbo].[Product] (
    [Id]           INT            IDENTITY (1, 1) NOT NULL,
    [Description]  NVARCHAR (MAX) NULL,
    [LastSold]     DATETIME       NULL,
    [ShelfLife]    BIGINT         NULL,
    [DepartmentId] INT            NULL,
    [Price]        FLOAT (53)     NULL,
    [UnitId]       INT            NULL,
    [xFor]         INT            NULL,
    [Cost]         FLOAT (53)     NULL,
    CONSTRAINT [PK__Product__3214EC07C1AE02DA] PRIMARY KEY CLUSTERED ([Id] ASC),
    CONSTRAINT [FK_Product_ToDepartment] FOREIGN KEY ([DepartmentId]) REFERENCES [dbo].[Department] ([Id]),
    CONSTRAINT [FK_Product_ToUnit] FOREIGN KEY ([UnitId]) REFERENCES [dbo].[Unit] ([Id])
);






