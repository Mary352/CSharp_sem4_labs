use master  

create database testdb
on primary
( name = N'testdb_mdf', filename = N'D:\4 סול\־־ֿ 4 סול\ֻ׀\2\lab_10\lab_10_OOP_ADO_dbcreator_mdf.mdf', 
   size = 5120Kb, maxsize = 10240Kb, filegrowth = 1024Kb),
( name = N'testdb_ndf', filename = N'D:\4 סול\־־ֿ 4 סול\ֻ׀\2\lab_10\lab_10_OOP_ADO_dbcreator_ndf.ndf', 
   size = 5120Kb, maxsize = 10240Kb, filegrowth = 10%)

