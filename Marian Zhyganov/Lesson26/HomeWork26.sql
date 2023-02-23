CREATE TABLE tbl_persons(
	id SERIAL PRIMARY KEY,
	first_name VARCHAR(100) NOT NULL,
	last_name VARCHAR(100) NOT NULL,
	age SMALLINT NOT NULL,
	gender VARCHAR(1) NOT NULL,
	address VARCHAR(255)
)
SELECT * FROM tbl_persons

INSERT INTO tbl_persons
(first_name,last_name,age,gender,address)	

VALUES
('Marian','Zhyganov',21,'M',NULL),
('Ivan','Shytskyi',27,'M','Ukraine'),
('Oleg','Morelovsk',21,'M','Ukraine'),
('Nastya','Zhyganova',21,'W',NULL),
('Roma','Sudor',21,'M','Ukraine'),
('Nastya','Voloshina',21,'W','Ukraine')

SELECT * FROM tbl_persons
WHERE gender = 'M'

UPDATE tbl_persons
SET age = age + 1

SELECT * FROM tbl_persons
WHERE age > 15 AND age < 21

SELECT * FROM tbl_persons
WHERE address is NULL

DELETE FROM tbl_persons
WHERE address is NULL

SELECT CONCAT('number of rows in table: ', COUNT(id)) as rows
FROM tbl_persons

SELECT age, COUNT(age)
FROM tbl_persons
GROUP BY age