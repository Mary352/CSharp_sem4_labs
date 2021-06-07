use lab_10_OOP_ADO;

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

