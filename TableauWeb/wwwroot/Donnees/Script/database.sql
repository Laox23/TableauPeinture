IF OBJECT_ID(N'[__EFMigrationsHistory]') IS NULL
BEGIN
    CREATE TABLE [__EFMigrationsHistory] (
        [MigrationId] nvarchar(150) NOT NULL,
        [ProductVersion] nvarchar(32) NOT NULL,
        CONSTRAINT [PK___EFMigrationsHistory] PRIMARY KEY ([MigrationId])
    );
END;

GO

CREATE TABLE [AspNetRoles] (
    [Id] nvarchar(450) NOT NULL,
    [Name] nvarchar(256) NULL,
    [NormalizedName] nvarchar(256) NULL,
    [ConcurrencyStamp] nvarchar(max) NULL,
    CONSTRAINT [PK_AspNetRoles] PRIMARY KEY ([Id])
);

GO

CREATE TABLE [AspNetUsers] (
    [Id] nvarchar(450) NOT NULL,
    [UserName] nvarchar(256) NULL,
    [NormalizedUserName] nvarchar(256) NULL,
    [Email] nvarchar(256) NULL,
    [NormalizedEmail] nvarchar(256) NULL,
    [EmailConfirmed] bit NOT NULL,
    [PasswordHash] nvarchar(max) NULL,
    [SecurityStamp] nvarchar(max) NULL,
    [ConcurrencyStamp] nvarchar(max) NULL,
    [PhoneNumber] nvarchar(max) NULL,
    [PhoneNumberConfirmed] bit NOT NULL,
    [TwoFactorEnabled] bit NOT NULL,
    [LockoutEnd] datetimeoffset NULL,
    [LockoutEnabled] bit NOT NULL,
    [AccessFailedCount] int NOT NULL,
    CONSTRAINT [PK_AspNetUsers] PRIMARY KEY ([Id])
);

GO

CREATE TABLE [Dimensions] (
    [DimensionId] int NOT NULL IDENTITY,
    [Hauteur] int NOT NULL,
    [Largeur] int NOT NULL,
    [Nom] nvarchar(max) NOT NULL,
    [EstActif] bit NOT NULL,
    CONSTRAINT [PK_Dimensions] PRIMARY KEY ([DimensionId])
);

GO

CREATE TABLE [Finitions] (
    [FinitionId] int NOT NULL IDENTITY,
    [Nom] nvarchar(max) NOT NULL,
    [EstActif] bit NOT NULL,
    CONSTRAINT [PK_Finitions] PRIMARY KEY ([FinitionId])
);

GO

CREATE TABLE [Images] (
    [ImageTableauId] int NOT NULL IDENTITY,
    [NomBase] nvarchar(max) NOT NULL,
    [Nom] nvarchar(max) NOT NULL,
    [MaxImpression] int NOT NULL,
    [EstActif] bit NOT NULL,
    CONSTRAINT [PK_Images] PRIMARY KEY ([ImageTableauId])
);

GO

CREATE TABLE [AspNetRoleClaims] (
    [Id] int NOT NULL IDENTITY,
    [RoleId] nvarchar(450) NOT NULL,
    [ClaimType] nvarchar(max) NULL,
    [ClaimValue] nvarchar(max) NULL,
    CONSTRAINT [PK_AspNetRoleClaims] PRIMARY KEY ([Id]),
    CONSTRAINT [FK_AspNetRoleClaims_AspNetRoles_RoleId] FOREIGN KEY ([RoleId]) REFERENCES [AspNetRoles] ([Id]) ON DELETE CASCADE
);

GO

CREATE TABLE [AspNetUserClaims] (
    [Id] int NOT NULL IDENTITY,
    [UserId] nvarchar(450) NOT NULL,
    [ClaimType] nvarchar(max) NULL,
    [ClaimValue] nvarchar(max) NULL,
    CONSTRAINT [PK_AspNetUserClaims] PRIMARY KEY ([Id]),
    CONSTRAINT [FK_AspNetUserClaims_AspNetUsers_UserId] FOREIGN KEY ([UserId]) REFERENCES [AspNetUsers] ([Id]) ON DELETE CASCADE
);

GO

CREATE TABLE [AspNetUserLogins] (
    [LoginProvider] nvarchar(128) NOT NULL,
    [ProviderKey] nvarchar(128) NOT NULL,
    [ProviderDisplayName] nvarchar(max) NULL,
    [UserId] nvarchar(450) NOT NULL,
    CONSTRAINT [PK_AspNetUserLogins] PRIMARY KEY ([LoginProvider], [ProviderKey]),
    CONSTRAINT [FK_AspNetUserLogins_AspNetUsers_UserId] FOREIGN KEY ([UserId]) REFERENCES [AspNetUsers] ([Id]) ON DELETE CASCADE
);

GO

CREATE TABLE [AspNetUserRoles] (
    [UserId] nvarchar(450) NOT NULL,
    [RoleId] nvarchar(450) NOT NULL,
    CONSTRAINT [PK_AspNetUserRoles] PRIMARY KEY ([UserId], [RoleId]),
    CONSTRAINT [FK_AspNetUserRoles_AspNetRoles_RoleId] FOREIGN KEY ([RoleId]) REFERENCES [AspNetRoles] ([Id]) ON DELETE CASCADE,
    CONSTRAINT [FK_AspNetUserRoles_AspNetUsers_UserId] FOREIGN KEY ([UserId]) REFERENCES [AspNetUsers] ([Id]) ON DELETE CASCADE
);

GO

CREATE TABLE [AspNetUserTokens] (
    [UserId] nvarchar(450) NOT NULL,
    [LoginProvider] nvarchar(128) NOT NULL,
    [Name] nvarchar(128) NOT NULL,
    [Value] nvarchar(max) NULL,
    CONSTRAINT [PK_AspNetUserTokens] PRIMARY KEY ([UserId], [LoginProvider], [Name]),
    CONSTRAINT [FK_AspNetUserTokens_AspNetUsers_UserId] FOREIGN KEY ([UserId]) REFERENCES [AspNetUsers] ([Id]) ON DELETE CASCADE
);

GO

CREATE TABLE [Tableaux] (
    [TableauId] int NOT NULL IDENTITY,
    [ImageTableauId] int NOT NULL,
    [DimensionId] int NOT NULL,
    [FinitionId] int NOT NULL,
    [UtilisateurId] int NOT NULL,
    [NombreImpression] int NOT NULL,
    [NomPdf] nvarchar(max) NOT NULL,
    [CodeVerif] nvarchar(max) NULL,
    [DateCreation] datetime2 NOT NULL,
    [UtilisateurId1] nvarchar(450) NULL,
    CONSTRAINT [PK_Tableaux] PRIMARY KEY ([TableauId]),
    CONSTRAINT [FK_Tableaux_Dimensions_DimensionId] FOREIGN KEY ([DimensionId]) REFERENCES [Dimensions] ([DimensionId]) ON DELETE CASCADE,
    CONSTRAINT [FK_Tableaux_Finitions_FinitionId] FOREIGN KEY ([FinitionId]) REFERENCES [Finitions] ([FinitionId]) ON DELETE CASCADE,
    CONSTRAINT [FK_Tableaux_Images_ImageTableauId] FOREIGN KEY ([ImageTableauId]) REFERENCES [Images] ([ImageTableauId]) ON DELETE CASCADE,
    CONSTRAINT [FK_Tableaux_AspNetUsers_UtilisateurId1] FOREIGN KEY ([UtilisateurId1]) REFERENCES [AspNetUsers] ([Id]) ON DELETE NO ACTION
);

GO

CREATE INDEX [IX_AspNetRoleClaims_RoleId] ON [AspNetRoleClaims] ([RoleId]);

GO

CREATE UNIQUE INDEX [RoleNameIndex] ON [AspNetRoles] ([NormalizedName]) WHERE [NormalizedName] IS NOT NULL;

GO

CREATE INDEX [IX_AspNetUserClaims_UserId] ON [AspNetUserClaims] ([UserId]);

GO

CREATE INDEX [IX_AspNetUserLogins_UserId] ON [AspNetUserLogins] ([UserId]);

GO

CREATE INDEX [IX_AspNetUserRoles_RoleId] ON [AspNetUserRoles] ([RoleId]);

GO

CREATE INDEX [EmailIndex] ON [AspNetUsers] ([NormalizedEmail]);

GO

CREATE UNIQUE INDEX [UserNameIndex] ON [AspNetUsers] ([NormalizedUserName]) WHERE [NormalizedUserName] IS NOT NULL;

GO

CREATE INDEX [IX_Tableaux_DimensionId] ON [Tableaux] ([DimensionId]);

GO

CREATE INDEX [IX_Tableaux_FinitionId] ON [Tableaux] ([FinitionId]);

GO

CREATE INDEX [IX_Tableaux_ImageTableauId] ON [Tableaux] ([ImageTableauId]);

GO

CREATE INDEX [IX_Tableaux_UtilisateurId1] ON [Tableaux] ([UtilisateurId1]);

GO

INSERT INTO [__EFMigrationsHistory] ([MigrationId], [ProductVersion])
VALUES (N'20200310201618_Initial', N'3.1.2');

GO

