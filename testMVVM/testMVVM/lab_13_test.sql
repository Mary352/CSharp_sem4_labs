use master;
go
create database lab_13_test
on primary
( name = N'lab_13_test_mdf', filename = N'D:\4 סול\־־ֿ 4 סול\ֻ׀\2\testMVVM\testMVVM\lab_13_test_mdf.mdf', 
   size = 5120Kb, maxsize = 10240Kb, filegrowth = 1024Kb),
( name = N'lab_13_test_ndf', filename = N'D:\4 סול\־־ֿ 4 סול\ֻ׀\2\testMVVM\testMVVM\lab_13_test_ndf.ndf', 
   size = 5120Kb, maxsize = 10240Kb, filegrowth = 10%)
go
use lab_13_test;
--drop database lab_13_test;
create table Phones
(
	Title nvarchar(50) primary key,
	Company nvarchar(50),
	Price int
);

insert into Phones (Title, Company, Price)
values	('iPhone 7', 'Apple', 56000),
		('Galaxy S7 Edge', 'Samsung', 60000),
		('Elite x3', 'HP', 56000),
		('Mi5S', 'Xiaomi', 35000);