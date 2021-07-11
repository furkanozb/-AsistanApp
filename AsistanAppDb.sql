If Not Exists(Select * From sysdatabases Where Name='AsistanAppDb')
Create Database AsistanAppDb
GO
USE AsistanAppDb
GO
If Not Exists (Select * from INFORMATION_SCHEMA.TABLES Where TABLE_NAME='PaymentCategory')
Create Table PaymentCategory
(
	Id Int Identity,
	Name Nvarchar(50),
	Constraint PK_PaymentCategory_Id Primary Key(Id)
)
GO
If Not Exists (Select * from INFORMATION_SCHEMA.TABLES Where TABLE_NAME='Payment')
Create Table Payment
(
	Id Int Identity,
	PaymentCategoryId Int,
	Name Nvarchar(50),
	Price money,
	CreatedPaymentDate datetime,
	FinalDate datetime,
	Constraint PK_Payment_Id Primary Key(Id),
	Constraint FK_Payment_Id Foreign Key(PaymentCategoryId) References PaymentCategory(Id)
)
GO
If Not Exists (Select * from INFORMATION_SCHEMA.TABLES Where TABLE_NAME='Blok')
Create Table Blok
(
	Id Int Identity,
	Name Nvarchar(50),
	Constraint PK_Blok_Id Primary Key(Id)
)
GO
If Not Exists (Select * from INFORMATION_SCHEMA.TABLES Where TABLE_NAME='BlokFloor')
Create Table BlokFloor
(
	Id Int Identity,
	BlokId Int,
	Name Nvarchar(50),
	Constraint PK_BlokFloor_Id Primary Key(Id),
	Constraint FK_BlokFloor_Id Foreign Key (BlokId) References Blok(Id)
)
GO
If Not Exists (Select * from INFORMATION_SCHEMA.TABLES Where TABLE_NAME='NumberOfRoom')
Create Table NumberOfRoom
(
	Id Int Identity,
	Description Nvarchar(50),
	Constraint PK_NumberOfRoom_Id Primary Key(Id)
)
GO
If Not Exists (Select * from INFORMATION_SCHEMA.TABLES Where TABLE_NAME='Apartment')
Create Table Apartment
(
	Id Int Identity,	
	NumberOfRoomId Int,
	FloorId Int,
	UserId nvarchar(450),
	FullOrEmpty bit default 0,
	HostOrTenant bit default 0,
	Constraint PK_Apartment_Id Primary Key(Id),
	Constraint FK_Apartment_UserId Foreign Key(UserId) References AspNetUsers(Id),
	Constraint FK_Apartment_FloorId Foreign Key (FloorId) References BlokFloor(Id),
	Constraint FK_Apartment_NumberOfRoomId Foreign Key (NumberOfRoomId) References NumberOfRoom(Id)
)
If Not Exists (Select * from INFORMATION_SCHEMA.TABLES Where TABLE_NAME='Message')
Create Table Message
(
	Id Int Identity,
	WriterUserId nvarchar(450),
	RecipientId nvarchar(450),
	Content Nvarchar(max),
	CreatedAt smalldatetime,
	Constraint PK_Message_Id Primary Key(Id),
	Constraint FK_Car_WriterUserId Foreign Key(WriterUserId) References AspNetUsers(Id),
	Constraint FK_Car_RecipientId Foreign Key(RecipientId) References AspNetUsers(Id),
)
GO
If Not Exists (Select * from INFORMATION_SCHEMA.TABLES Where TABLE_NAME='Car')
Create Table Car
(
	Id Int Identity,
	UserId nvarchar(450),
	LicensePlate Nvarchar(15),
	Description Nvarchar(40),
	Constraint PK_Car_Id Primary Key(Id),
	Constraint FK_Car_UserId Foreign Key(UserId) References AspNetUsers(Id),
)
GO
If Not Exists (Select * from INFORMATION_SCHEMA.TABLES Where TABLE_NAME='Indent')
Create Table Indent
(
	Id Int Identity,
	PaymentId Int,
	ApartmentId Int,
	CreatedAt smalldatetime,
	Constraint PK_Indent_Id Primary Key(Id),
	Constraint FK_Indent_PaymentId Foreign Key(PaymentId) References Payment(Id),
	Constraint FK_Indent_ApartmentId Foreign Key(PaymentId) References Apartment(Id),
)

