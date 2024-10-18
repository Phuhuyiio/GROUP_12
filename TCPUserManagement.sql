CREATE DATABASE UserManagement
Use UserManagement
Go

Create Table Users
(
	UserId int identity(1,1),
	Username nvarchar(20) not null,
	Password varchar(MAX) not null,
	Email varchar(MAX) not null,
	FullName nvarchar(50) not null,
	BirthDay date not null,
	Constraint PK_Users Primary Key(UserId),
);
--------------------------------------------------------------------
