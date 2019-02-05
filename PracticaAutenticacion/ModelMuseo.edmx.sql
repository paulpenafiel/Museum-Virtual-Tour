
-- --------------------------------------------------
-- Entity Designer DDL Script for SQL Server 2005, 2008, 2012 and Azure
-- --------------------------------------------------
-- Date Created: 02/17/2018 15:52:37
-- Generated from EDMX file: C:\Users\Usuario\Documents\Visual Studio 2017\Projects\PracticaAutenticacion\PracticaAutenticacion\ModelMuseo.edmx
-- --------------------------------------------------

SET QUOTED_IDENTIFIER OFF;
GO
USE [DBMuseo];
GO
IF SCHEMA_ID(N'dbo') IS NULL EXECUTE(N'CREATE SCHEMA [dbo]');
GO

-- --------------------------------------------------
-- Dropping existing FOREIGN KEY constraints
-- --------------------------------------------------


-- --------------------------------------------------
-- Dropping existing tables
-- --------------------------------------------------


-- --------------------------------------------------
-- Creating all tables
-- --------------------------------------------------

-- Creating table 'ComentarioSet'
CREATE TABLE [dbo].[ComentarioSet] (
    [IdComentario] int IDENTITY(1,1) NOT NULL,
    [NombreComentario] nvarchar(max)  NOT NULL,
    [TextoComentario] nvarchar(max)  NOT NULL,
    [FechaComentario] nvarchar(max)  NOT NULL,
    [PuntosComentario] nvarchar(max)  NOT NULL,
    [Area_IdArea] int  NOT NULL,
    [Estado_IdEstado] int  NOT NULL
);
GO

-- Creating table 'EstadoSet'
CREATE TABLE [dbo].[EstadoSet] (
    [IdEstado] int IDENTITY(1,1) NOT NULL,
    [NombreEstado] nvarchar(max)  NOT NULL
);
GO

-- Creating table 'AreaSet'
CREATE TABLE [dbo].[AreaSet] (
    [IdArea] int IDENTITY(1,1) NOT NULL,
    [NombreArea] nvarchar(max)  NOT NULL
);
GO

-- --------------------------------------------------
-- Creating all PRIMARY KEY constraints
-- --------------------------------------------------

-- Creating primary key on [IdComentario] in table 'ComentarioSet'
ALTER TABLE [dbo].[ComentarioSet]
ADD CONSTRAINT [PK_ComentarioSet]
    PRIMARY KEY CLUSTERED ([IdComentario] ASC);
GO

-- Creating primary key on [IdEstado] in table 'EstadoSet'
ALTER TABLE [dbo].[EstadoSet]
ADD CONSTRAINT [PK_EstadoSet]
    PRIMARY KEY CLUSTERED ([IdEstado] ASC);
GO

-- Creating primary key on [IdArea] in table 'AreaSet'
ALTER TABLE [dbo].[AreaSet]
ADD CONSTRAINT [PK_AreaSet]
    PRIMARY KEY CLUSTERED ([IdArea] ASC);
GO

-- --------------------------------------------------
-- Creating all FOREIGN KEY constraints
-- --------------------------------------------------

-- Creating foreign key on [Area_IdArea] in table 'ComentarioSet'
ALTER TABLE [dbo].[ComentarioSet]
ADD CONSTRAINT [FK_AreaComentario]
    FOREIGN KEY ([Area_IdArea])
    REFERENCES [dbo].[AreaSet]
        ([IdArea])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_AreaComentario'
CREATE INDEX [IX_FK_AreaComentario]
ON [dbo].[ComentarioSet]
    ([Area_IdArea]);
GO

-- Creating foreign key on [Estado_IdEstado] in table 'ComentarioSet'
ALTER TABLE [dbo].[ComentarioSet]
ADD CONSTRAINT [FK_EstadoComentario]
    FOREIGN KEY ([Estado_IdEstado])
    REFERENCES [dbo].[EstadoSet]
        ([IdEstado])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_EstadoComentario'
CREATE INDEX [IX_FK_EstadoComentario]
ON [dbo].[ComentarioSet]
    ([Estado_IdEstado]);
GO

-- --------------------------------------------------
-- Script has ended
-- --------------------------------------------------