IF OBJECT_ID(N'[__EFMigrationsHistory]') IS NULL
BEGIN
    CREATE TABLE [__EFMigrationsHistory] (
        [MigrationId] nvarchar(150) NOT NULL,
        [ProductVersion] nvarchar(32) NOT NULL,
        CONSTRAINT [PK___EFMigrationsHistory] PRIMARY KEY ([MigrationId])
    );
END;

GO

CREATE TABLE [Users] (
    [Id] int NOT NULL IDENTITY,
    [UserName] nvarchar(max) NULL,
    [NickName] nvarchar(max) NULL,
    [Password] nvarchar(max) NULL,
    [Email] nvarchar(max) NULL,
    CONSTRAINT [PK_Users] PRIMARY KEY ([Id])
);

GO

INSERT INTO [__EFMigrationsHistory] ([MigrationId], [ProductVersion])
VALUES (N'20200106192214_MyFirstMigration', N'3.1.0');

GO

INSERT INTO [__EFMigrationsHistory] ([MigrationId], [ProductVersion])
VALUES (N'20200107160653_MySecondMigration', N'3.1.0');

GO

DECLARE @var0 sysname;
SELECT @var0 = [d].[name]
FROM [sys].[default_constraints] [d]
INNER JOIN [sys].[columns] [c] ON [d].[parent_column_id] = [c].[column_id] AND [d].[parent_object_id] = [c].[object_id]
WHERE ([d].[parent_object_id] = OBJECT_ID(N'[Users]') AND [c].[name] = N'UserName');
IF @var0 IS NOT NULL EXEC(N'ALTER TABLE [Users] DROP CONSTRAINT [' + @var0 + '];');
ALTER TABLE [Users] ALTER COLUMN [UserName] nvarchar(450) NULL;

GO

DECLARE @var1 sysname;
SELECT @var1 = [d].[name]
FROM [sys].[default_constraints] [d]
INNER JOIN [sys].[columns] [c] ON [d].[parent_column_id] = [c].[column_id] AND [d].[parent_object_id] = [c].[object_id]
WHERE ([d].[parent_object_id] = OBJECT_ID(N'[Users]') AND [c].[name] = N'NickName');
IF @var1 IS NOT NULL EXEC(N'ALTER TABLE [Users] DROP CONSTRAINT [' + @var1 + '];');
ALTER TABLE [Users] ALTER COLUMN [NickName] nvarchar(450) NULL;

GO

DECLARE @var2 sysname;
SELECT @var2 = [d].[name]
FROM [sys].[default_constraints] [d]
INNER JOIN [sys].[columns] [c] ON [d].[parent_column_id] = [c].[column_id] AND [d].[parent_object_id] = [c].[object_id]
WHERE ([d].[parent_object_id] = OBJECT_ID(N'[Users]') AND [c].[name] = N'Email');
IF @var2 IS NOT NULL EXEC(N'ALTER TABLE [Users] DROP CONSTRAINT [' + @var2 + '];');
ALTER TABLE [Users] ALTER COLUMN [Email] nvarchar(450) NULL;

GO

ALTER TABLE [Users] ADD [Bio] nvarchar(max) NULL;

GO

ALTER TABLE [Users] ADD [BirthDate] datetime2 NOT NULL DEFAULT '0001-01-01T00:00:00.0000000';

GO

ALTER TABLE [Users] ADD [City] nvarchar(max) NULL;

GO

ALTER TABLE [Users] ADD [Country] nvarchar(max) NULL;

GO

ALTER TABLE [Users] ADD [LastOnlineDate] datetime2 NOT NULL DEFAULT '0001-01-01T00:00:00.0000000';

GO

ALTER TABLE [Users] ADD [Sex] int NOT NULL DEFAULT 0;

GO

ALTER TABLE [Users] ADD [ZodiacId] int NULL;

GO

CREATE TABLE [Cities] (
    [id] int NOT NULL IDENTITY,
    [name] nvarchar(max) NULL,
    [state_id] int NOT NULL,
    CONSTRAINT [PK_Cities] PRIMARY KEY ([id])
);

GO

CREATE TABLE [Countries] (
    [id] int NOT NULL IDENTITY,
    [sortname] nvarchar(max) NULL,
    [name] nvarchar(max) NULL,
    [phonecode] int NOT NULL,
    CONSTRAINT [PK_Countries] PRIMARY KEY ([id])
);

GO

CREATE TABLE [Image] (
    [Id] int NOT NULL IDENTITY,
    [Url] nvarchar(max) NULL,
    [PictureType] int NOT NULL,
    [UserDbEntityId] int NULL,
    CONSTRAINT [PK_Image] PRIMARY KEY ([Id]),
    CONSTRAINT [FK_Image_Users_UserDbEntityId] FOREIGN KEY ([UserDbEntityId]) REFERENCES [Users] ([Id]) ON DELETE NO ACTION
);

GO

CREATE TABLE [Zodiac] (
    [Id] int NOT NULL IDENTITY,
    [Sign] int NOT NULL,
    [StartDate] datetime2 NOT NULL,
    [EndDate] datetime2 NOT NULL,
    CONSTRAINT [PK_Zodiac] PRIMARY KEY ([Id])
);

GO

CREATE TABLE [States] (
    [id] int NOT NULL IDENTITY,
    [name] nvarchar(max) NULL,
    [CountryId] int NULL,
    CONSTRAINT [PK_States] PRIMARY KEY ([id]),
    CONSTRAINT [FK_States_Countries_CountryId] FOREIGN KEY ([CountryId]) REFERENCES [Countries] ([id]) ON DELETE NO ACTION
);

GO

CREATE UNIQUE INDEX [IX_Users_Email] ON [Users] ([Email]) WHERE [Email] IS NOT NULL;

GO

CREATE UNIQUE INDEX [IX_Users_NickName] ON [Users] ([NickName]) WHERE [NickName] IS NOT NULL;

GO

CREATE UNIQUE INDEX [IX_Users_UserName] ON [Users] ([UserName]) WHERE [UserName] IS NOT NULL;

GO

CREATE INDEX [IX_Users_ZodiacId] ON [Users] ([ZodiacId]);

GO

CREATE INDEX [IX_Image_UserDbEntityId] ON [Image] ([UserDbEntityId]);

GO

CREATE INDEX [IX_States_CountryId] ON [States] ([CountryId]);

GO

ALTER TABLE [Users] ADD CONSTRAINT [FK_Users_Zodiac_ZodiacId] FOREIGN KEY ([ZodiacId]) REFERENCES [Zodiac] ([Id]) ON DELETE NO ACTION;

GO

INSERT INTO [__EFMigrationsHistory] ([MigrationId], [ProductVersion])
VALUES (N'20200109193128_thirdmigrations', N'3.1.0');

GO

INSERT INTO [__EFMigrationsHistory] ([MigrationId], [ProductVersion])
VALUES (N'20200111133540_FourthMigration', N'3.1.0');

GO

ALTER TABLE [States] DROP CONSTRAINT [FK_States_Countries_CountryId];

GO

DROP INDEX [IX_States_CountryId] ON [States];

GO

DECLARE @var3 sysname;
SELECT @var3 = [d].[name]
FROM [sys].[default_constraints] [d]
INNER JOIN [sys].[columns] [c] ON [d].[parent_column_id] = [c].[column_id] AND [d].[parent_object_id] = [c].[object_id]
WHERE ([d].[parent_object_id] = OBJECT_ID(N'[States]') AND [c].[name] = N'CountryId');
IF @var3 IS NOT NULL EXEC(N'ALTER TABLE [States] DROP CONSTRAINT [' + @var3 + '];');
ALTER TABLE [States] DROP COLUMN [CountryId];

GO

ALTER TABLE [States] ADD [country_id] int NULL;

GO

DECLARE @var4 sysname;
SELECT @var4 = [d].[name]
FROM [sys].[default_constraints] [d]
INNER JOIN [sys].[columns] [c] ON [d].[parent_column_id] = [c].[column_id] AND [d].[parent_object_id] = [c].[object_id]
WHERE ([d].[parent_object_id] = OBJECT_ID(N'[Cities]') AND [c].[name] = N'state_id');
IF @var4 IS NOT NULL EXEC(N'ALTER TABLE [Cities] DROP CONSTRAINT [' + @var4 + '];');
ALTER TABLE [Cities] ALTER COLUMN [state_id] int NULL;

GO

CREATE INDEX [IX_States_country_id] ON [States] ([country_id]);

GO

CREATE INDEX [IX_Cities_state_id] ON [Cities] ([state_id]);

GO

ALTER TABLE [Cities] ADD CONSTRAINT [FK_Cities_States_state_id] FOREIGN KEY ([state_id]) REFERENCES [States] ([id]) ON DELETE NO ACTION;

GO

ALTER TABLE [States] ADD CONSTRAINT [FK_States_Countries_country_id] FOREIGN KEY ([country_id]) REFERENCES [Countries] ([id]) ON DELETE NO ACTION;

GO

INSERT INTO [__EFMigrationsHistory] ([MigrationId], [ProductVersion])
VALUES (N'20200113135942_Fiveth', N'3.1.0');

GO

INSERT INTO [__EFMigrationsHistory] ([MigrationId], [ProductVersion])
VALUES (N'20200113141109_Sixth', N'3.1.0');

GO

