SELECT * FROM tbl_persons 
WHERE gender = 'M';

SELECT * FROM tbl_persons 
WHERE age = 18;

SELECT * FROM tbl_persons 
WHERE address IS Null;

UPDATE tbl_persons
SET age = age + 1;

DELETE FROM tbl_persons
WHERE address IS Null;

SELECT COUNT(*) FROM tbl_persons;

SELECT age, COUNT(age) FROM tbl_persons
GROUP BY age;