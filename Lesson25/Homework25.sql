--Using the same person’s table as on the lesson do next: 

--select all males
--select all persons with age about 18
--select all persons without address
--update age of all persons, add 1 year
--delete all rows without address
--count number of rows in table
--group persons by age and show how many persons with same age

CREATE TABLE IF NOT EXISTS tbl_persons(
	id SERIAL PRIMARY KEY,
	first_name VARCHAR(100) NOT NULL,
	last_name VARCHAR(100) NOT NULL,
	age SMALLINT NOT NULL,
	gender VARCHAR(1) NOT NULL,
	address VARCHAR(255)
)

INSERT INTO tbl_persons
	(first_name,last_name,age,gender,address)
VALUES
	('Dim','Bon',30,'M'),
	('Fim','Gon',18,'M'),
	('Zim','Xon',27,'M'),
	('Lim','Kon',19,'F'),
	('Rim','Ton',17,'F')
	
INSERT INTO tbl_persons
	(first_name,last_name,age,gender,address)
VALUES
	('Tim','Kon',49,'F', 'New Tampton'),
	('Oim','Ton',18,'F', 'New Tutpton')
	
SELECT * FROM tbl_persons
WHERE gender = 'M'

SELECT * FROM tbl_persons
WHERE age BETWEEN 17 AND 19 -- "About 18 :)"

SELECT * FROM tbl_persons
WHERE address = '' IS NOT FALSE
	
UPDATE tbl_persons
SET age = age +1

DELETE FROM tbl_persons
WHERE address = '' IS NOT FALSE

SELECT COUNT (id) 
FROM tbl_persons

SELECT age, COUNT(age)
FROM tbl_persons
GROUP BY age
					