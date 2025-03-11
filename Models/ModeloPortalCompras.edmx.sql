
-- --------------------------------------------------
-- Entity Designer DDL Script for SQL Server 2005, 2008, 2012 and Azure
-- --------------------------------------------------
-- Date Created: 12/15/2024 23:27:07
-- Generated from EDMX file: C:\Users\afeij\Desktop\portal-de-compras no tocar funciona ok\Models\ModeloPortalCompras.edmx
-- --------------------------------------------------

SET QUOTED_IDENTIFIER OFF;
GO
USE [PortalCompras];
GO
IF SCHEMA_ID(N'dbo') IS NULL EXECUTE(N'CREATE SCHEMA [dbo]');
GO

-- --------------------------------------------------
-- Dropping existing FOREIGN KEY constraints
-- --------------------------------------------------

IF OBJECT_ID(N'[dbo].[FK_AdjudicacionLicitacionProveedor_LicitacionCotizacionProv]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[AdjudicacionLicitacionProveedors] DROP CONSTRAINT [FK_AdjudicacionLicitacionProveedor_LicitacionCotizacionProv];
GO
IF OBJECT_ID(N'[dbo].[FK_AdjudicacionLicitacionProveedor_Licitaciones]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[AdjudicacionLicitacionProveedors] DROP CONSTRAINT [FK_AdjudicacionLicitacionProveedor_Licitaciones];
GO
IF OBJECT_ID(N'[dbo].[FK_AdjudicacionLicitacionProveedor_Producto]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[AdjudicacionLicitacionProveedors] DROP CONSTRAINT [FK_AdjudicacionLicitacionProveedor_Producto];
GO
IF OBJECT_ID(N'[dbo].[FK_LicitacionCotizacionProv_Licitaciones]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[LicitacionCotizacionProvs] DROP CONSTRAINT [FK_LicitacionCotizacionProv_Licitaciones];
GO
IF OBJECT_ID(N'[dbo].[FK_LicitacionCotizacionProv_Producto]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[LicitacionCotizacionProvs] DROP CONSTRAINT [FK_LicitacionCotizacionProv_Producto];
GO
IF OBJECT_ID(N'[dbo].[FK_LicitacionCotizacionProv_Proveedor]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[LicitacionCotizacionProvs] DROP CONSTRAINT [FK_LicitacionCotizacionProv_Proveedor];
GO
IF OBJECT_ID(N'[dbo].[FK_Licitaciones_Licitador]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[Licitaciones] DROP CONSTRAINT [FK_Licitaciones_Licitador];
GO
IF OBJECT_ID(N'[dbo].[FK_Licitador_OrganismoLicitante]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[Licitadors] DROP CONSTRAINT [FK_Licitador_OrganismoLicitante];
GO
IF OBJECT_ID(N'[dbo].[FK_Licitaciones_Productoes]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[Licitaciones] DROP CONSTRAINT [FK_Licitaciones_Productoes];
GO

-- --------------------------------------------------
-- Dropping existing tables
-- --------------------------------------------------

IF OBJECT_ID(N'[dbo].[AdjudicacionLicitacionProveedors]', 'U') IS NOT NULL
    DROP TABLE [dbo].[AdjudicacionLicitacionProveedors];
GO
IF OBJECT_ID(N'[dbo].[LicitacionCotizacionProvs]', 'U') IS NOT NULL
    DROP TABLE [dbo].[LicitacionCotizacionProvs];
GO
IF OBJECT_ID(N'[dbo].[Licitaciones]', 'U') IS NOT NULL
    DROP TABLE [dbo].[Licitaciones];
GO
IF OBJECT_ID(N'[dbo].[Licitadors]', 'U') IS NOT NULL
    DROP TABLE [dbo].[Licitadors];
GO
IF OBJECT_ID(N'[dbo].[OrganismoLicitantes]', 'U') IS NOT NULL
    DROP TABLE [dbo].[OrganismoLicitantes];
GO
IF OBJECT_ID(N'[dbo].[Productoes]', 'U') IS NOT NULL
    DROP TABLE [dbo].[Productoes];
GO
IF OBJECT_ID(N'[dbo].[Proveedors]', 'U') IS NOT NULL
    DROP TABLE [dbo].[Proveedors];
GO

-- --------------------------------------------------
-- Creating all tables
-- --------------------------------------------------

-- Creating table 'AdjudicacionLicitacionProveedors'
CREATE TABLE [dbo].[AdjudicacionLicitacionProveedors] (
    [IdAdjudicacion] int  NOT NULL,
    [IdLicitacion] int  NOT NULL,
    [IdCotizacion] int  NOT NULL,
    [IdProducto] int  NOT NULL,
    [FormaPagoAdj] varchar(max)  NOT NULL
);
GO

-- Creating table 'LicitacionCotizacionProvs'
CREATE TABLE [dbo].[LicitacionCotizacionProvs] (
    [IdCotizacion] int  NOT NULL,
    [IdLicitacion] int  NOT NULL,
    [IdProducto] int  NOT NULL,
    [IdProveedor] int  NOT NULL,
    [FechaCotizacionProveedor] datetime  NOT NULL,
    [PrecioUnitario] int  NOT NULL
);
GO

-- Creating table 'Licitaciones'
CREATE TABLE [dbo].[Licitaciones] (
    [IdLicitacion] int  NOT NULL,
    [NombreLicitacion] varchar(max)  NOT NULL,
    [IdLicitador] int  NOT NULL,
    [FechaCreacionLicitacion] datetime  NOT NULL,
    [FechaCierreLicitacion] datetime  NOT NULL,
    [FechaAdjudicacionLicitacion] datetime  NOT NULL,
    [ObservacionesLicitacion] varchar(max)  NOT NULL,
    [IdProducto] int  NOT NULL
);
GO

-- Creating table 'Licitadors'
CREATE TABLE [dbo].[Licitadors] (
    [IdLicitador] int  NOT NULL,
    [IdOrganismoLicitante] int  NOT NULL,
    [NombreLicitador] varchar(max)  NOT NULL
);
GO

-- Creating table 'OrganismoLicitantes'
CREATE TABLE [dbo].[OrganismoLicitantes] (
    [IdOrganismoLicitante] int  NOT NULL,
    [NombreOrganismoLicitante] varchar(max)  NOT NULL,
    [ContactoOrganismoLicitante] int  NOT NULL,
    [DireccionOrganismoLicitante] varchar(max)  NOT NULL
);
GO

-- Creating table 'Productoes'
CREATE TABLE [dbo].[Productoes] (
    [IdProducto] int  NOT NULL,
    [NombreProducto] varchar(max)  NOT NULL,
    [DescripcionProducto] varchar(max)  NOT NULL
);
GO

-- Creating table 'Proveedors'
CREATE TABLE [dbo].[Proveedors] (
    [IdProveedor] int  NOT NULL,
    [NombreProveedor] varchar(max)  NOT NULL,
    [CUITProveedor] int  NOT NULL,
    [TelProveedor] int  NOT NULL,
    [CorreoProveedor] varchar(max)  NOT NULL,
    [DomicilioProveedor] varchar(max)  NOT NULL
);
GO

-- --------------------------------------------------
-- Creating all PRIMARY KEY constraints
-- --------------------------------------------------

-- Creating primary key on [IdAdjudicacion] in table 'AdjudicacionLicitacionProveedors'
ALTER TABLE [dbo].[AdjudicacionLicitacionProveedors]
ADD CONSTRAINT [PK_AdjudicacionLicitacionProveedors]
    PRIMARY KEY CLUSTERED ([IdAdjudicacion] ASC);
GO

-- Creating primary key on [IdCotizacion] in table 'LicitacionCotizacionProvs'
ALTER TABLE [dbo].[LicitacionCotizacionProvs]
ADD CONSTRAINT [PK_LicitacionCotizacionProvs]
    PRIMARY KEY CLUSTERED ([IdCotizacion] ASC);
GO

-- Creating primary key on [IdLicitacion] in table 'Licitaciones'
ALTER TABLE [dbo].[Licitaciones]
ADD CONSTRAINT [PK_Licitaciones]
    PRIMARY KEY CLUSTERED ([IdLicitacion] ASC);
GO

-- Creating primary key on [IdLicitador] in table 'Licitadors'
ALTER TABLE [dbo].[Licitadors]
ADD CONSTRAINT [PK_Licitadors]
    PRIMARY KEY CLUSTERED ([IdLicitador] ASC);
GO

-- Creating primary key on [IdOrganismoLicitante] in table 'OrganismoLicitantes'
ALTER TABLE [dbo].[OrganismoLicitantes]
ADD CONSTRAINT [PK_OrganismoLicitantes]
    PRIMARY KEY CLUSTERED ([IdOrganismoLicitante] ASC);
GO

-- Creating primary key on [IdProducto] in table 'Productoes'
ALTER TABLE [dbo].[Productoes]
ADD CONSTRAINT [PK_Productoes]
    PRIMARY KEY CLUSTERED ([IdProducto] ASC);
GO

-- Creating primary key on [IdProveedor] in table 'Proveedors'
ALTER TABLE [dbo].[Proveedors]
ADD CONSTRAINT [PK_Proveedors]
    PRIMARY KEY CLUSTERED ([IdProveedor] ASC);
GO

-- --------------------------------------------------
-- Creating all FOREIGN KEY constraints
-- --------------------------------------------------

-- Creating foreign key on [IdCotizacion] in table 'AdjudicacionLicitacionProveedors'
ALTER TABLE [dbo].[AdjudicacionLicitacionProveedors]
ADD CONSTRAINT [FK_AdjudicacionLicitacionProveedor_LicitacionCotizacionProv]
    FOREIGN KEY ([IdCotizacion])
    REFERENCES [dbo].[LicitacionCotizacionProvs]
        ([IdCotizacion])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_AdjudicacionLicitacionProveedor_LicitacionCotizacionProv'
CREATE INDEX [IX_FK_AdjudicacionLicitacionProveedor_LicitacionCotizacionProv]
ON [dbo].[AdjudicacionLicitacionProveedors]
    ([IdCotizacion]);
GO

-- Creating foreign key on [IdLicitacion] in table 'AdjudicacionLicitacionProveedors'
ALTER TABLE [dbo].[AdjudicacionLicitacionProveedors]
ADD CONSTRAINT [FK_AdjudicacionLicitacionProveedor_Licitaciones]
    FOREIGN KEY ([IdLicitacion])
    REFERENCES [dbo].[Licitaciones]
        ([IdLicitacion])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_AdjudicacionLicitacionProveedor_Licitaciones'
CREATE INDEX [IX_FK_AdjudicacionLicitacionProveedor_Licitaciones]
ON [dbo].[AdjudicacionLicitacionProveedors]
    ([IdLicitacion]);
GO

-- Creating foreign key on [IdProducto] in table 'AdjudicacionLicitacionProveedors'
ALTER TABLE [dbo].[AdjudicacionLicitacionProveedors]
ADD CONSTRAINT [FK_AdjudicacionLicitacionProveedor_Producto]
    FOREIGN KEY ([IdProducto])
    REFERENCES [dbo].[Productoes]
        ([IdProducto])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_AdjudicacionLicitacionProveedor_Producto'
CREATE INDEX [IX_FK_AdjudicacionLicitacionProveedor_Producto]
ON [dbo].[AdjudicacionLicitacionProveedors]
    ([IdProducto]);
GO

-- Creating foreign key on [IdLicitacion] in table 'LicitacionCotizacionProvs'
ALTER TABLE [dbo].[LicitacionCotizacionProvs]
ADD CONSTRAINT [FK_LicitacionCotizacionProv_Licitaciones]
    FOREIGN KEY ([IdLicitacion])
    REFERENCES [dbo].[Licitaciones]
        ([IdLicitacion])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_LicitacionCotizacionProv_Licitaciones'
CREATE INDEX [IX_FK_LicitacionCotizacionProv_Licitaciones]
ON [dbo].[LicitacionCotizacionProvs]
    ([IdLicitacion]);
GO

-- Creating foreign key on [IdProducto] in table 'LicitacionCotizacionProvs'
ALTER TABLE [dbo].[LicitacionCotizacionProvs]
ADD CONSTRAINT [FK_LicitacionCotizacionProv_Producto]
    FOREIGN KEY ([IdProducto])
    REFERENCES [dbo].[Productoes]
        ([IdProducto])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_LicitacionCotizacionProv_Producto'
CREATE INDEX [IX_FK_LicitacionCotizacionProv_Producto]
ON [dbo].[LicitacionCotizacionProvs]
    ([IdProducto]);
GO

-- Creating foreign key on [IdProveedor] in table 'LicitacionCotizacionProvs'
ALTER TABLE [dbo].[LicitacionCotizacionProvs]
ADD CONSTRAINT [FK_LicitacionCotizacionProv_Proveedor]
    FOREIGN KEY ([IdProveedor])
    REFERENCES [dbo].[Proveedors]
        ([IdProveedor])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_LicitacionCotizacionProv_Proveedor'
CREATE INDEX [IX_FK_LicitacionCotizacionProv_Proveedor]
ON [dbo].[LicitacionCotizacionProvs]
    ([IdProveedor]);
GO

-- Creating foreign key on [IdLicitador] in table 'Licitaciones'
ALTER TABLE [dbo].[Licitaciones]
ADD CONSTRAINT [FK_Licitaciones_Licitador]
    FOREIGN KEY ([IdLicitador])
    REFERENCES [dbo].[Licitadors]
        ([IdLicitador])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_Licitaciones_Licitador'
CREATE INDEX [IX_FK_Licitaciones_Licitador]
ON [dbo].[Licitaciones]
    ([IdLicitador]);
GO

-- Creating foreign key on [IdOrganismoLicitante] in table 'Licitadors'
ALTER TABLE [dbo].[Licitadors]
ADD CONSTRAINT [FK_Licitador_OrganismoLicitante]
    FOREIGN KEY ([IdOrganismoLicitante])
    REFERENCES [dbo].[OrganismoLicitantes]
        ([IdOrganismoLicitante])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_Licitador_OrganismoLicitante'
CREATE INDEX [IX_FK_Licitador_OrganismoLicitante]
ON [dbo].[Licitadors]
    ([IdOrganismoLicitante]);
GO

-- Creating foreign key on [IdProducto] in table 'Licitaciones'
ALTER TABLE [dbo].[Licitaciones]
ADD CONSTRAINT [FK_Licitaciones_Productoes]
    FOREIGN KEY ([IdProducto])
    REFERENCES [dbo].[Productoes]
        ([IdProducto])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_Licitaciones_Productoes'
CREATE INDEX [IX_FK_Licitaciones_Productoes]
ON [dbo].[Licitaciones]
    ([IdProducto]);
GO

-- --------------------------------------------------
-- Script has ended
-- --------------------------------------------------