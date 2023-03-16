CREATE TABLE IF NOT EXISTS tbl_persons(
	id SERIAL PRIMARY KEY,
	first_name VARCHAR(100) NOT NULL,
	last_name VARCHAR(100) NOT NULL,
	age SMALLINT NOT NULL,
	gender VARCHAR(1) NOT NULL,
	address VARCHAR(255)
); 

DELETE FROM tbl_persons;

SELECT * FROM tbl_persons;

INSERT INTO tbl_persons
	(first_name, last_name, age, gender, address)
VALUES
	('Egor', 'Bogachik', 21, 'M', '23 Wall Street'),
	('Kate', 'Le', 17, 'F', '15 Low Street'),
	('Bogdan', 'Reynolds', 18, 'M', NULL),
	('Liz', 'Falcon', 18, 'F', NULL),
	('Alex', 'Shevchenko', 17, 'M', '12 Some Street'),
	('Tony', 'Montana', 15, 'M', '6 Grow Street'), 
	('Victoria', 'Secret', 22, 'F', NULL),
	('Robert', 'Ivanov', 19, 'M', '23 Some street');
	
	
SELECT * FROM tbl_persons WHERE gender = 'M';

SELECT * FROM tbl_persons WHERE age > 16 AND age < 20;

SELECT * FROM tbl_persons WHERE address IS NULL;

UPDATE tbl_persons SET age = age + 1;

DELETE FROM tbl_persons WHERE address IS NULL;

SELECT CONCAT('Number of rows: ', COUNT(id)) AS ROW FROM tbl_persons;

SELECT age, COUNT(age) FROM tbl_persons GROUP BY age;

