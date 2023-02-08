CREATE TABLE tbl_persons(
	id SERIAL PRIMARY KEY,
	first_name VARCHAR(100) NOT NULL,
	last_name VARCHAR(100) NOT NULL,
	age SMALLINT NOT NULL,
	gender VARCHAR(1) NOT NULL,
	address VARCHAR(255)
)

DELETE FROM tbl_persons
SELECT * FROM tbl_persons

INSERT INTO tbl_persons
	(first_name, last_name, age, gender, address)
VALUES 
	('Dima', 'Dimych', 18, 'M', 'Kiev'),
	('Leona', 'Jo', 12, 'W', NULL),
	('Slava', 'Smith', 34, 'M', NULL),
	('Mark', 'Tven', 23, 'M', 'Odessa'),
	('Ivan', 'Potapov', 67, 'M', NULL),
	('Lena', 'Cool', 26, 'W', NULL),
	('Vika', 'Ivanova', 27, 'W', 'Lviv'),
	('Artem', 'Sushko', 34, 'M', 'Poltava'),
	('Kate', 'Bin', 27, 'W', NULL),
	('Sveta', 'Potter', 18, 'W', 'Kherson')
	
	
SELECT id, first_name, last_name, age, gender, address FROM tbl_persons
WHERE gender = 'M'

UPDATE tbl_persons
SET age = age + 1

SELECT id, first_name, last_name, age, gender, address FROM tbl_persons
WHERE age > 15 AND age < 21

SELECT id, first_name, last_name, age, gender, address FROM tbl_persons
WHERE address is NULL

DELETE FROM tbl_persons
WHERE address is NULL

SELECT CONCAT('number of rows in table: ', COUNT(id)) as rows
FROM tbl_persons

SELECT age, COUNT(age)
FROM tbl_persons
GROUP BY age