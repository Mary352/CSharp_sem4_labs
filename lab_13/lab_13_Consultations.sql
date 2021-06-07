use master;
go
create database lab_13_Consultations
on primary
( name = N'lab_13_Consultations_mdf', filename = N'D:\4 сем\ООП 4 сем\ЛР\2\lab_13\lab_13_Consultations_mdf.mdf', 
   size = 5120Kb, maxsize = 10240Kb, filegrowth = 1024Kb),
( name = N'lab_13_Consultations_ndf', filename = N'D:\4 сем\ООП 4 сем\ЛР\2\lab_13\lab_13_Consultations_ndf.ndf', 
   size = 5120Kb, maxsize = 10240Kb, filegrowth = 10%)
go
use lab_13_Consultations;
--drop database lab_13_Consultations;
create table Lecturers
(
	SNP nvarchar(60) primary key,
	[Subject] nvarchar(50) not null,
	ConsultDateTime datetime not null,
	StudNum int not null,
	MaxStudNum int not null
);

insert into Lecturers (SNP, [Subject], ConsultDateTime, StudNum, MaxStudNum)
values	('Пацей Н.В.', 'ООТПиСП', '2021-08-06 15:40:00', 30, 30),
		('Смелов В.В.', 'ОСиСП', '2021-15-06 13:50:00', 40, 40),
		('Жиляк Н.А.', 'Web-дизайн и ШП', '2021-20-06 09:50:00', 35, 35);