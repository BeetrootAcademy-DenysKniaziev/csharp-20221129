----CREATE TABLE tbl_persons(
--	id SERIAL PRIMARY KEY,
--	first_name VARCHAR(100) NOT NULL,
--	last_name VARCHAR(100) NOT NULL,
--	age SMALLINT NOT NULL,
--	gender VARCHAR(1) NOT NULL,
--	address VARCHAR(255)
----)

SELECT age, first_name, COUNT(age)
FROM tbl_persons
GROUP BY age, first_name

SELECT CONCAT('hello, ', tbl_persons.first_name, ' ', tbl_persons.last_name) as greeting
FROM tbl_persons

SELECT MAX(age) AS max_age
FROM tbl_persons

SELECT COUNT(6) AS count
FROM tbl_persons

INSERT INTO tbl_persons
	(first_name, last_name, age, gender)
VALUES
	('Dima', 'Bonis2', 30, 'M'),
	('Ivan', 'Shy', 27, 'M')
	
	
INSERT INTO tbl_persons
	(first_name, last_name, age, gender, address)
VALUES
	('Denys', 'Kniaz', 27, 'M', 'UKRAINE')
	
UPDATE tbl_persons
SET age = age + 1
WHERE tbl_persons.first_name LIKE '%va%'

DELETE FROM tbl_persons WHERE id IN (SELECT id FROM tbl_persons WHERE tbl_persons.first_name = 'Denys' ORDER BY id DESC OFFSET 1)

