use master  
go
create database lab_10_OOP_ADO
/*on primary
( name = N'testdb_mdf', filename = N'D:\4 сем\ООП 4 сем\ЛР\2\lab_10\lab_10_OOP_ADO_mdf.mdf', 
   size = 5120Kb, maxsize = 10240Kb, filegrowth = 1024Kb),
( name = N'testdb_ndf', filename = N'D:\4 сем\ООП 4 сем\ЛР\2\lab_10\lab_10_OOP_ADO_ndf.ndf', 
   size = 5120Kb, maxsize = 10240Kb, filegrowth = 10%)*/
go
use lab_10_OOP_ADO;
--drop database lab_10_OOP_ADO;
create table Addresses
(
	AddressId int primary key,
	City nvarchar(50),
	Postcode nvarchar(50),
	Street nvarchar(50),
	House nvarchar(50),
	Apt nvarchar(50)
);

create table Students
(
	Surname nvarchar(50) primary key,
	[Name] nvarchar(50),
	Patronymic nvarchar(50),
	Age int,
	Speciality nvarchar(50),
	DateBirth date,
	Course int,
	[Group] int,
	AverageMark float,
	Gender nvarchar(50),
	[Address] int,
	Photo image,
	foreign key ([Address]) references Addresses (AddressId) on delete cascade
);

insert into Addresses (AddressId, City, Postcode, Street, House, Apt)
values	(1, 'Minsk', '226478', 'Surganova', '15', '8'),
		(2, 'Borisov', '127564', 'Kirova', '6', '1'),
		(3, 'Orsha', '226040', 'Ostrovskogo', '14', '105');

/*--проблема таким insert вставить фото
insert into Students (Surname, [Name], Patronymic, Age, Speciality, DateBirth, Course, [Group], AverageMark, Gender, [Address])
values	('nvbvd', 'dggfgg', 'dfggfdg', 22, 'ПИОТТ', '1999-03-12', 4, 10, 7.5, 'м', 1),
		('fggfg', 'wqeert', 'cvb', 19, 'ПОИБМС', '2002-04-08', 2, 8, 6.7, 'ж', 3),
		('pojk', 'hjhjj', 'unhj', 18, 'ПОИТ', '2003-01-03', 1, 4, 7.8, 'ж', 2);
*/
GO
CREATE PROCEDURE [dbo].[sp_InsertStudent]
	@surname nvarchar(50),
	@name nvarchar(50),
	@patronymic nvarchar(50),
	@age int,
	@speciality nvarchar(50),
	@dateBirth date,
	@course int,
	@group int,
	@averageMark float,
	@gender nvarchar(50),
	@address int,
	@photo image
AS
    INSERT INTO Students(Surname, [Name], Patronymic, Age, Speciality, DateBirth, Course, [Group], AverageMark, Gender, [Address], Photo)
    VALUES (@surname, @name, @patronymic, @age, @speciality, @dateBirth, @course, @group, @averageMark, @gender, @address, @photo)
GO

/*--проверка работы update с переменными у табл Addresses
declare @city nvarchar(50), @postcode nvarchar(50), @street nvarchar(50), @house nvarchar(50), @apt nvarchar(50), @addrId int;
set @city='sdjvbs';
set @postcode='112547';
set @street='fudghgt';
set @house='18';
set @apt='18';
set @addrId=2;
update Addresses set City=@city, Postcode=@postcode, Street = @street, House=@house, Apt=@apt where AddressId=@addrId;*/

/*--проверка работы update с переменными у табл Students
declare @name nvarchar(50), @patronymic nvarchar(50), @age int, @speciality nvarchar(50), @dateBirth date, @course int, @group int, @averageMark float,
@gender nvarchar(50), @address int, @surname nvarchar(50);
set @name='vnbjgj';
set @patronymic='gegcy';
set @age=21;
set @speciality='БТ';
set @dateBirth='2003-01-08';
set @course=1;
set @group=7;
set @averageMark=8.4;
set @gender='м';
set @address=3;
set @surname='eqr3';
UPDATE Students SET Name = @name, Patronymic = @patronymic, Age = @age, Speciality = @speciality, DateBirth=@dateBirth, Course=@course, [Group]=@group, 
AverageMark=@averageMark, Gender=@gender, Address=@address WHERE Surname=@surname
--Group без [] - ошибка, остальное работает
/*UPDATE Students SET Name = @name, Patronymic = @patronymic, Age = @age, Speciality = @speciality, DateBirth=@dateBirth, Course=@course, [Group]=@group, 
AverageMark=@averageMark, Gender=@gender, Address=@address WHERE Surname=@surname*/*/
