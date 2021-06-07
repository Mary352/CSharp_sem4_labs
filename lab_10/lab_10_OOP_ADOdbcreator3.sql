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
