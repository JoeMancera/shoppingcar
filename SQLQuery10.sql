
CREATE TABLE [dbo].[Cliente] (
    [Id]      INT     IDENTITY(1,1)       NOT NULL,
    [Nombres] VARCHAR (MAX)  NOT NULL,
    [Correo]  VARCHAR  (MAX) NOT NULL,
    [Clave]   VARCHAR (50)   NOT NULL,
    PRIMARY KEY CLUSTERED ([Id] ASC)
);

CREATE TABLE [dbo].[Producto] (
    [Id]     INT      IDENTITY(1,1)     NOT NULL,
    [Nombre] VARCHAR (10)    NOT NULL,
    [Precio] VARCHAR (10)    NOT NULL,
    [Path]   VARCHAR (MAX) NULL,
    PRIMARY KEY CLUSTERED ([Id] ASC)
);

CREATE TABLE [dbo].[Estado] (
    [Id]     INT     IDENTITY(1,1)      NOT NULL,
    [Nombre] VARCHAR (MAX) NOT NULL,
    CONSTRAINT [PK_Estado] PRIMARY KEY CLUSTERED ([Id] ASC)
);

CREATE TABLE [dbo].[Pedido] (
    [Id]        INT IDENTITY(1,1) NOT NULL,
    [ClienteId] INT NOT NULL,
    [EstadoId]  INT NOT NULL,
    PRIMARY KEY CLUSTERED ([Id] ASC),
    CONSTRAINT [FK_Pedido_ClienteId] FOREIGN KEY ([ClienteId]) REFERENCES [dbo].[Cliente] ([Id]),
    CONSTRAINT [FK_Estado_EstadoId] FOREIGN KEY ([EstadoId]) REFERENCES [dbo].[Estado] ([Id])
);

CREATE TABLE [dbo].[DetallePedido] (
    [Id]         INT IDENTITY(1,1) NOT NULL ,
    [PedidoId]   INT NOT NULL,
    [ProductoId] INT NOT NULL,
    [Cantidad]   INT NOT NULL,
    PRIMARY KEY CLUSTERED ([Id] ASC),
    CONSTRAINT [FK_Pedido_PedidoId] FOREIGN KEY ([PedidoId]) REFERENCES [dbo].[Pedido] ([Id]),
    CONSTRAINT [FK_Producto_ProductoId] FOREIGN KEY ([ProductoId]) REFERENCES [dbo].[Producto] ([Id])
);






