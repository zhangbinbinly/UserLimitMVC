
-- --------------------------------------------------
-- Entity Designer DDL Script for SQL Server 2005, 2008, and Azure
-- --------------------------------------------------
-- Date Created: 10/27/2014 17:53:57
-- Generated from EDMX file: E:\Projcets\ProjectTest\UserLimitMVC\UserLimitMVC.Model\DataModel.edmx
-- --------------------------------------------------

SET QUOTED_IDENTIFIER OFF;
GO
USE [UserLimit];
GO
IF SCHEMA_ID(N'dbo') IS NULL EXECUTE(N'CREATE SCHEMA [dbo]');
GO

-- --------------------------------------------------
-- Dropping existing FOREIGN KEY constraints
-- --------------------------------------------------


-- --------------------------------------------------
-- Dropping existing tables
-- --------------------------------------------------

IF OBJECT_ID(N'[dbo].[UserInfo]', 'U') IS NOT NULL
    DROP TABLE [dbo].[UserInfo];
GO
IF OBJECT_ID(N'[dbo].[Role]', 'U') IS NOT NULL
    DROP TABLE [dbo].[Role];
GO

-- --------------------------------------------------
-- Creating all tables
-- --------------------------------------------------

-- Creating table 'UserInfo'
CREATE TABLE [dbo].[UserInfo] (
    [ID] int IDENTITY(1,1) NOT NULL,
    [UserName] nvarchar(32)  NULL,
    [Password] nvarchar(16)  NULL
);
GO

-- Creating table 'Role'
CREATE TABLE [dbo].[Role] (
    [ID] int IDENTITY(1,1) NOT NULL,
    [RoleName] nvarchar(32)  NULL
);
GO

-- Creating table 'ActionInfo'
CREATE TABLE [dbo].[ActionInfo] (
    [ID] int IDENTITY(1,1) NOT NULL,
    [RequestUrl] nvarchar(50)  NULL,
    [RequestHttpType] nvarchar(16)  NULL,
    [ActionName] nvarchar(32)  NULL,
    [SubTime] datetime  NULL
);
GO

-- Creating table 'R_UserInfo_Action'
CREATE TABLE [dbo].[R_UserInfo_Action] (
    [ID] int IDENTITY(1,1) NOT NULL,
    [UserInfoID] int  NOT NULL,
    [ActionInfoID] int  NOT NULL,
    [HasPermation] bit  NOT NULL,
    [UserInfo_ID] int  NOT NULL,
    [ActionInfo_ID] int  NOT NULL
);
GO

-- Creating table 'R_UserInfo_Role'
CREATE TABLE [dbo].[R_UserInfo_Role] (
    [ID] int IDENTITY(1,1) NOT NULL,
    [UserInfoID] int  NOT NULL,
    [RoleID] int  NOT NULL,
    [UserInfo_ID] int  NOT NULL,
    [Role_ID] int  NOT NULL
);
GO

-- Creating table 'ActionInfoRole'
CREATE TABLE [dbo].[ActionInfoRole] (
    [ActionInfo_ID] int  NOT NULL,
    [Role_ID] int  NOT NULL
);
GO

-- --------------------------------------------------
-- Creating all PRIMARY KEY constraints
-- --------------------------------------------------

-- Creating primary key on [ID] in table 'UserInfo'
ALTER TABLE [dbo].[UserInfo]
ADD CONSTRAINT [PK_UserInfo]
    PRIMARY KEY CLUSTERED ([ID] ASC);
GO

-- Creating primary key on [ID] in table 'Role'
ALTER TABLE [dbo].[Role]
ADD CONSTRAINT [PK_Role]
    PRIMARY KEY CLUSTERED ([ID] ASC);
GO

-- Creating primary key on [ID] in table 'ActionInfo'
ALTER TABLE [dbo].[ActionInfo]
ADD CONSTRAINT [PK_ActionInfo]
    PRIMARY KEY CLUSTERED ([ID] ASC);
GO

-- Creating primary key on [ID] in table 'R_UserInfo_Action'
ALTER TABLE [dbo].[R_UserInfo_Action]
ADD CONSTRAINT [PK_R_UserInfo_Action]
    PRIMARY KEY CLUSTERED ([ID] ASC);
GO

-- Creating primary key on [ID] in table 'R_UserInfo_Role'
ALTER TABLE [dbo].[R_UserInfo_Role]
ADD CONSTRAINT [PK_R_UserInfo_Role]
    PRIMARY KEY CLUSTERED ([ID] ASC);
GO

-- Creating primary key on [ActionInfo_ID], [Role_ID] in table 'ActionInfoRole'
ALTER TABLE [dbo].[ActionInfoRole]
ADD CONSTRAINT [PK_ActionInfoRole]
    PRIMARY KEY NONCLUSTERED ([ActionInfo_ID], [Role_ID] ASC);
GO

-- --------------------------------------------------
-- Creating all FOREIGN KEY constraints
-- --------------------------------------------------

-- Creating foreign key on [UserInfo_ID] in table 'R_UserInfo_Action'
ALTER TABLE [dbo].[R_UserInfo_Action]
ADD CONSTRAINT [FK_UserInfoR_UserInfo_Action]
    FOREIGN KEY ([UserInfo_ID])
    REFERENCES [dbo].[UserInfo]
        ([ID])
    ON DELETE NO ACTION ON UPDATE NO ACTION;

-- Creating non-clustered index for FOREIGN KEY 'FK_UserInfoR_UserInfo_Action'
CREATE INDEX [IX_FK_UserInfoR_UserInfo_Action]
ON [dbo].[R_UserInfo_Action]
    ([UserInfo_ID]);
GO

-- Creating foreign key on [ActionInfo_ID] in table 'R_UserInfo_Action'
ALTER TABLE [dbo].[R_UserInfo_Action]
ADD CONSTRAINT [FK_ActionInfoR_UserInfo_Action]
    FOREIGN KEY ([ActionInfo_ID])
    REFERENCES [dbo].[ActionInfo]
        ([ID])
    ON DELETE NO ACTION ON UPDATE NO ACTION;

-- Creating non-clustered index for FOREIGN KEY 'FK_ActionInfoR_UserInfo_Action'
CREATE INDEX [IX_FK_ActionInfoR_UserInfo_Action]
ON [dbo].[R_UserInfo_Action]
    ([ActionInfo_ID]);
GO

-- Creating foreign key on [UserInfo_ID] in table 'R_UserInfo_Role'
ALTER TABLE [dbo].[R_UserInfo_Role]
ADD CONSTRAINT [FK_UserInfoR_UserInfo_Role]
    FOREIGN KEY ([UserInfo_ID])
    REFERENCES [dbo].[UserInfo]
        ([ID])
    ON DELETE NO ACTION ON UPDATE NO ACTION;

-- Creating non-clustered index for FOREIGN KEY 'FK_UserInfoR_UserInfo_Role'
CREATE INDEX [IX_FK_UserInfoR_UserInfo_Role]
ON [dbo].[R_UserInfo_Role]
    ([UserInfo_ID]);
GO

-- Creating foreign key on [Role_ID] in table 'R_UserInfo_Role'
ALTER TABLE [dbo].[R_UserInfo_Role]
ADD CONSTRAINT [FK_RoleR_UserInfo_Role]
    FOREIGN KEY ([Role_ID])
    REFERENCES [dbo].[Role]
        ([ID])
    ON DELETE NO ACTION ON UPDATE NO ACTION;

-- Creating non-clustered index for FOREIGN KEY 'FK_RoleR_UserInfo_Role'
CREATE INDEX [IX_FK_RoleR_UserInfo_Role]
ON [dbo].[R_UserInfo_Role]
    ([Role_ID]);
GO

-- Creating foreign key on [ActionInfo_ID] in table 'ActionInfoRole'
ALTER TABLE [dbo].[ActionInfoRole]
ADD CONSTRAINT [FK_ActionInfoRole_ActionInfo]
    FOREIGN KEY ([ActionInfo_ID])
    REFERENCES [dbo].[ActionInfo]
        ([ID])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating foreign key on [Role_ID] in table 'ActionInfoRole'
ALTER TABLE [dbo].[ActionInfoRole]
ADD CONSTRAINT [FK_ActionInfoRole_Role]
    FOREIGN KEY ([Role_ID])
    REFERENCES [dbo].[Role]
        ([ID])
    ON DELETE NO ACTION ON UPDATE NO ACTION;

-- Creating non-clustered index for FOREIGN KEY 'FK_ActionInfoRole_Role'
CREATE INDEX [IX_FK_ActionInfoRole_Role]
ON [dbo].[ActionInfoRole]
    ([Role_ID]);
GO

-- --------------------------------------------------
-- Script has ended
-- --------------------------------------------------