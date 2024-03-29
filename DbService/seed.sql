Build started...
Build succeeded.
The Entity Framework tools version '7.0.9' is older than that of the runtime '8.0.3'. Update the tools for the latest features and bug fixes. See https://aka.ms/AAc1fbw for more information.
IF OBJECT_ID(N'[__EFMigrationsHistory]') IS NULL
BEGIN
    CREATE TABLE [__EFMigrationsHistory] (
        [MigrationId] nvarchar(150) NOT NULL,
        [ProductVersion] nvarchar(32) NOT NULL,
        CONSTRAINT [PK___EFMigrationsHistory] PRIMARY KEY ([MigrationId])
    );
END;
GO

BEGIN TRANSACTION;
GO

CREATE TABLE [SearchProviders] (
    [Id] uniqueidentifier NOT NULL,
    [Name] nvarchar(max) NOT NULL,
    [Base64Image] NVARCHAR(MAX) NOT NULL,
    [BaseUrl] nvarchar(max) NOT NULL,
    [Created] datetime2 NOT NULL DEFAULT (getutcdate()),
    [Updated] datetime2 NOT NULL DEFAULT (getutcdate()),
    CONSTRAINT [PK_SearchProviders] PRIMARY KEY ([Id])
);
GO

CREATE TABLE [UserProfiles] (
    [Id] uniqueidentifier NOT NULL,
    [Name] nvarchar(450) NOT NULL,
    [Created] datetime2 NOT NULL DEFAULT (getutcdate()),
    [Updated] datetime2 NOT NULL DEFAULT (getutcdate()),
    CONSTRAINT [PK_UserProfiles] PRIMARY KEY ([Id])
);
GO

CREATE TABLE [UserSearches] (
    [Id] uniqueidentifier NOT NULL,
    [ProfileId] uniqueidentifier NOT NULL,
    [ProviderId] uniqueidentifier NOT NULL,
    [SearchTerms] nvarchar(450) NOT NULL,
    [Positions] nvarchar(max) NOT NULL,
    [Time] datetime2 NOT NULL,
    [Created] datetime2 NOT NULL DEFAULT (getutcdate()),
    [Updated] datetime2 NOT NULL DEFAULT (getutcdate()),
    CONSTRAINT [PK_UserSearches] PRIMARY KEY ([Id]),
    CONSTRAINT [FK_UserSearches_SearchProviders_ProviderId] FOREIGN KEY ([ProviderId]) REFERENCES [SearchProviders] ([Id]),
    CONSTRAINT [FK_UserSearches_UserProfiles_ProfileId] FOREIGN KEY ([ProfileId]) REFERENCES [UserProfiles] ([Id])
);
GO

IF EXISTS (SELECT * FROM [sys].[identity_columns] WHERE [name] IN (N'Id', N'Base64Image', N'BaseUrl', N'Created', N'Name', N'Updated') AND [object_id] = OBJECT_ID(N'[SearchProviders]'))
    SET IDENTITY_INSERT [SearchProviders] ON;
INSERT INTO [SearchProviders] ([Id], [Base64Image], [BaseUrl], [Created], [Name], [Updated])
VALUES ('216a9c6a-e257-4a02-a05d-28457ee21a53', N'base64:eee', N'https://www.dogpile.com/serp?q=\{0\}', '2024-03-19T10:40:54.5885241+00:00', N'Dogpile', '2024-03-19T10:40:54.5885242+00:00'),
('5e4832e6-cfed-4a51-8a4e-60892761e06b', N'base64:eee', N'https://www.google.co.uk/search?num=100&q=\{0\}', '2024-03-19T10:40:54.5885157+00:00', N'Google', '2024-03-19T10:40:54.5885210+00:00'),
('d3416981-bd62-4d49-8f0e-5355e86d82f1', N'base64:eee', N'https://www.google.co.uk/search?num=100&q=\{0\}', '2024-03-19T10:40:54.5885257+00:00', N'Google (Alt)', '2024-03-19T10:40:54.5885258+00:00');
IF EXISTS (SELECT * FROM [sys].[identity_columns] WHERE [name] IN (N'Id', N'Base64Image', N'BaseUrl', N'Created', N'Name', N'Updated') AND [object_id] = OBJECT_ID(N'[SearchProviders]'))
    SET IDENTITY_INSERT [SearchProviders] OFF;
GO

IF EXISTS (SELECT * FROM [sys].[identity_columns] WHERE [name] IN (N'Id', N'Created', N'Name', N'Updated') AND [object_id] = OBJECT_ID(N'[UserProfiles]'))
    SET IDENTITY_INSERT [UserProfiles] ON;
INSERT INTO [UserProfiles] ([Id], [Created], [Name], [Updated])
VALUES ('088da3f6-8714-4f34-a078-87711c6825c2', '2024-03-19T10:40:54.5885299+00:00', N'Sara', '2024-03-19T10:40:54.5885300+00:00'),
('4dbb0b52-557f-40d3-bd8d-79b52463e6aa', '2024-03-19T10:40:54.5885314+00:00', N'Colin', '2024-03-19T10:40:54.5885315+00:00'),
('7bc7a2b6-1fcb-43e5-a27c-565b00146e7b', '2024-03-19T10:40:54.5885282+00:00', N'Paul', '2024-03-19T10:40:54.5885283+00:00');
IF EXISTS (SELECT * FROM [sys].[identity_columns] WHERE [name] IN (N'Id', N'Created', N'Name', N'Updated') AND [object_id] = OBJECT_ID(N'[UserProfiles]'))
    SET IDENTITY_INSERT [UserProfiles] OFF;
GO

CREATE INDEX [IX_UserProfiles_Name] ON [UserProfiles] ([Name]);
GO

CREATE INDEX [IX_UserSearches_ProfileId] ON [UserSearches] ([ProfileId]);
GO

CREATE INDEX [IX_UserSearches_ProviderId] ON [UserSearches] ([ProviderId]);
GO

CREATE INDEX [IX_UserSearches_SearchTerms] ON [UserSearches] ([SearchTerms]);
GO

INSERT INTO [__EFMigrationsHistory] ([MigrationId], [ProductVersion])
VALUES (N'20240319104054_init', N'8.0.3');
GO

COMMIT;
GO

BEGIN TRANSACTION;
GO

DELETE FROM [SearchProviders]
WHERE [Id] = '216a9c6a-e257-4a02-a05d-28457ee21a53';
SELECT @@ROWCOUNT;

GO

DELETE FROM [SearchProviders]
WHERE [Id] = '5e4832e6-cfed-4a51-8a4e-60892761e06b';
SELECT @@ROWCOUNT;

GO

DELETE FROM [SearchProviders]
WHERE [Id] = 'd3416981-bd62-4d49-8f0e-5355e86d82f1';
SELECT @@ROWCOUNT;

GO

DELETE FROM [UserProfiles]
WHERE [Id] = '088da3f6-8714-4f34-a078-87711c6825c2';
SELECT @@ROWCOUNT;

GO

DELETE FROM [UserProfiles]
WHERE [Id] = '4dbb0b52-557f-40d3-bd8d-79b52463e6aa';
SELECT @@ROWCOUNT;

GO

DELETE FROM [UserProfiles]
WHERE [Id] = '7bc7a2b6-1fcb-43e5-a27c-565b00146e7b';
SELECT @@ROWCOUNT;

GO

IF EXISTS (SELECT * FROM [sys].[identity_columns] WHERE [name] IN (N'Id', N'Base64Image', N'BaseUrl', N'Created', N'Name', N'Updated') AND [object_id] = OBJECT_ID(N'[SearchProviders]'))
    SET IDENTITY_INSERT [SearchProviders] ON;
INSERT INTO [SearchProviders] ([Id], [Base64Image], [BaseUrl], [Created], [Name], [Updated])
VALUES ('7ca1526f-4410-4fee-8ddf-457a480003de', N'base64:eee', N'https://www.google.co.uk/search?num=100&q={{0}}', '2024-03-19T12:08:30.1458025+00:00', N'Google (Alt)', '2024-03-19T12:08:30.1458026+00:00'),
('bd9c0848-3aa8-4b04-ba68-68dd984805fc', N'base64:eee', N'https://www.dogpile.com/serp?q={{0}}', '2024-03-19T12:08:30.1458008+00:00', N'Dogpile', '2024-03-19T12:08:30.1458010+00:00'),
('c8594551-2646-4472-a0da-ea6504c287a6', N'base64:eee', N'https://www.google.co.uk/search?num=100&q={{0}}', '2024-03-19T12:08:30.1457918+00:00', N'Google', '2024-03-19T12:08:30.1457974+00:00');
IF EXISTS (SELECT * FROM [sys].[identity_columns] WHERE [name] IN (N'Id', N'Base64Image', N'BaseUrl', N'Created', N'Name', N'Updated') AND [object_id] = OBJECT_ID(N'[SearchProviders]'))
    SET IDENTITY_INSERT [SearchProviders] OFF;
GO

IF EXISTS (SELECT * FROM [sys].[identity_columns] WHERE [name] IN (N'Id', N'Created', N'Name', N'Updated') AND [object_id] = OBJECT_ID(N'[UserProfiles]'))
    SET IDENTITY_INSERT [UserProfiles] ON;
INSERT INTO [UserProfiles] ([Id], [Created], [Name], [Updated])
VALUES ('3700b53a-c1e9-4303-b9b9-3b34e792eda5', '2024-03-19T12:08:30.1458044+00:00', N'Paul', '2024-03-19T12:08:30.1458045+00:00'),
('5dd241c4-2d10-4ce3-810e-11e014c55fa0', '2024-03-19T12:08:30.1458063+00:00', N'Sara', '2024-03-19T12:08:30.1458064+00:00'),
('db4644d4-ace1-4088-af61-3f369ddb72ca', '2024-03-19T12:08:30.1458079+00:00', N'Colin', '2024-03-19T12:08:30.1458080+00:00');
IF EXISTS (SELECT * FROM [sys].[identity_columns] WHERE [name] IN (N'Id', N'Created', N'Name', N'Updated') AND [object_id] = OBJECT_ID(N'[UserProfiles]'))
    SET IDENTITY_INSERT [UserProfiles] OFF;
GO

INSERT INTO [__EFMigrationsHistory] ([MigrationId], [ProductVersion])
VALUES (N'20240319120830_seed2', N'8.0.3');
GO

COMMIT;
GO

BEGIN TRANSACTION;
GO

DELETE FROM [SearchProviders]
WHERE [Id] = '7ca1526f-4410-4fee-8ddf-457a480003de';
SELECT @@ROWCOUNT;

GO

DELETE FROM [SearchProviders]
WHERE [Id] = 'bd9c0848-3aa8-4b04-ba68-68dd984805fc';
SELECT @@ROWCOUNT;

GO

DELETE FROM [SearchProviders]
WHERE [Id] = 'c8594551-2646-4472-a0da-ea6504c287a6';
SELECT @@ROWCOUNT;

GO

DELETE FROM [UserProfiles]
WHERE [Id] = '3700b53a-c1e9-4303-b9b9-3b34e792eda5';
SELECT @@ROWCOUNT;

GO

DELETE FROM [UserProfiles]
WHERE [Id] = '5dd241c4-2d10-4ce3-810e-11e014c55fa0';
SELECT @@ROWCOUNT;

GO

DELETE FROM [UserProfiles]
WHERE [Id] = 'db4644d4-ace1-4088-af61-3f369ddb72ca';
SELECT @@ROWCOUNT;

GO

IF EXISTS (SELECT * FROM [sys].[identity_columns] WHERE [name] IN (N'Id', N'Base64Image', N'BaseUrl', N'Created', N'Name', N'Updated') AND [object_id] = OBJECT_ID(N'[SearchProviders]'))
    SET IDENTITY_INSERT [SearchProviders] ON;
INSERT INTO [SearchProviders] ([Id], [Base64Image], [BaseUrl], [Created], [Name], [Updated])
VALUES ('463981c8-fa6e-4ba2-9ab7-01f89d3b290c', N'base64:eee', N'https://www.google.co.uk/search?num=100&q={0}', '2024-03-19T12:10:24.3464949+00:00', N'Google (Alt)', '2024-03-19T12:10:24.3464950+00:00'),
('a35fbea2-e41e-4692-9071-1c8bb29a0365', N'base64:eee', N'https://www.google.co.uk/search?num=100&q={0}', '2024-03-19T12:10:24.3464841+00:00', N'Google', '2024-03-19T12:10:24.3464898+00:00'),
('c5951b98-e351-4561-9ea0-9fa2c59b23d4', N'base64:eee', N'https://www.dogpile.com/serp?q={0}', '2024-03-19T12:10:24.3464931+00:00', N'Dogpile', '2024-03-19T12:10:24.3464933+00:00');
IF EXISTS (SELECT * FROM [sys].[identity_columns] WHERE [name] IN (N'Id', N'Base64Image', N'BaseUrl', N'Created', N'Name', N'Updated') AND [object_id] = OBJECT_ID(N'[SearchProviders]'))
    SET IDENTITY_INSERT [SearchProviders] OFF;
GO

IF EXISTS (SELECT * FROM [sys].[identity_columns] WHERE [name] IN (N'Id', N'Created', N'Name', N'Updated') AND [object_id] = OBJECT_ID(N'[UserProfiles]'))
    SET IDENTITY_INSERT [UserProfiles] ON;
INSERT INTO [UserProfiles] ([Id], [Created], [Name], [Updated])
VALUES ('4f8ea409-957b-4296-bf49-7bbce84903ea', '2024-03-19T12:10:24.3465021+00:00', N'Colin', '2024-03-19T12:10:24.3465022+00:00'),
('c2d69d70-43e8-4c69-b15f-76e6d052d0d9', '2024-03-19T12:10:24.3464979+00:00', N'Paul', '2024-03-19T12:10:24.3464980+00:00'),
('d487ae02-e8b7-4b1c-8d3c-5802679dfe66', '2024-03-19T12:10:24.3465005+00:00', N'Sara', '2024-03-19T12:10:24.3465006+00:00');
IF EXISTS (SELECT * FROM [sys].[identity_columns] WHERE [name] IN (N'Id', N'Created', N'Name', N'Updated') AND [object_id] = OBJECT_ID(N'[UserProfiles]'))
    SET IDENTITY_INSERT [UserProfiles] OFF;
GO

INSERT INTO [__EFMigrationsHistory] ([MigrationId], [ProductVersion])
VALUES (N'20240319121024_seed3', N'8.0.3');
GO

COMMIT;
GO


