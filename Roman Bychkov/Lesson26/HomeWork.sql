--CREATE TABLE tbl_persons(
--	id SERIAL PRIMARY KEY,
	--first_name VARCHAR(100) NOT NULL,
	--last_name VARCHAR(100) NOT NULL,
	--age SMALLINT NOT NULL,
	--gender VARCHAR(1) NOT NULL,
	--address VARCHAR(255)
--)
Insert Into tbl_persons 
	(first_name, last_name, age, gender, address)
VALUES
	('Russell', 'Crowe', '18', 'M', 'London'),
	('Harry', 'Axe', '20', 'M', 'London'),
	('John', 'Cena', '45', 'M', 'Pekin')
	('Walter', 'White', '56', 'M', 'Albuquerque'),
	('Skyler', 'White', '39', 'W', 'Albuquerque'),
	('Tyler', 'Durden', '25', 'M', 'California'),
	('Penelopa', 'Cruz', '44', 'W', 'Madrid'),
	('Kim', 'Wexler', '40', 'W', 'Florida'),
	('Gabe', 'Newell', '61', 'M', 'New Zeland'),
	('John', 'Cena', '45', 'M', 'Pekin')
	
Insert Into tbl_persons 
	(first_name, last_name, age, gender)
VALUES
	('Kate', 'Bruce', '19', 'W'),
	('Harry', 'McQuer', '40', 'M')
	
select * 
from tbl_persons

--Task1 select all males
select * from tbl_persons
where gender = 'M'

--Task2 select all persons with age about 18
select * 
from tbl_persons
where age between 16 and 21

--Task3 select all persons without address
select * from tbl_persons
where address is null

--Task4 update age of all persons, add 1 year
update tbl_persons
set age=age+1

--Task5 delete all rows without address
delete from tbl_persons
where address is null

--Task6 count number of rows in table
select count(*)
from tbl_persons

--Task7 group persons by age and show how many persons with same age
select count(age), age
from tbl_persons
group by age