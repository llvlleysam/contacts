create database contacts
go 

use contacts
go 

create table dbo.[User]
(
	Id int not null identity(1000,1) primary key,
	Username varchar(32) not null unique, --EMail
	Password binary(16) not null ,
	Fullname varchar(32) not null ,
	avatar varchar(32)
)

create table dbo.contact 
(
	Id int not null identity(1000,1) primary key,
	UserId int not null foreign key references dbo.[User](Id),
	fullname varchar(32) not null,
	Email varchar(32),
	avatar varchar(32)
) --**

create table dbo.Phonetype
(
	Id tinyint not null primary key,
	title varchar(32) not null
)
insert into dbo.Phonetype values
(1,'Home'), (2,'Work'), (3,'Mobile')

select * from Phonetype


create table dbo.phone
(
	Id int not null identity(1000,1) primary key,
	ContactId int not null foreign key references dbo.[contact](Id),
	PhonetypeId tinyint not null foreign key references dbo.[phonetype](Id),
	Number varchar(32) not null
)

create table dbo.Favorite
(
	ContactId int not null primary key foreign key references dbo.[contact](Id),
)