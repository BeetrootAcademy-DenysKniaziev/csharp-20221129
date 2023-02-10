 --CREATE TABLE tbl_persons(
   --id serial PRIMARY KEY,
    --first_name VARCHAR(100)NOT NULL,
    --last_name VARCHAR(100) NOT NULL,
    --age SMALLINT NOT NULL,
    --gender VARCHAR(1) NOT NULL,
    --adress VARCHAR(255)
 --)
 SELECT * FROM tbl_persons
 ORDER BY tbl_persons.id
 
 INSERT INTO tbl_persons 
      (first_name, last_name, age, gender)
 VALUES 
      ('Devid', 'Boni', 30, 'M'),
	  ('Iva', 'Shyts', 27, 'M')
	  
 INSERT INTO tbl_persons 
      (first_name, last_name, age, gender, adress)
 VALUES 
      ('Nick', 'Neti', 30, 'M', 'UK')
	  
 INSERT INTO tbl_persons 
      (first_name, last_name, age, gender, adress)
 VALUES 
      ('Rick', 'Dass', 30, 'M', 'USA')

UPDATE tbl_persons
SET age = age+1
WHERE tbl_persons.first_name LIKE '%v%'

UPDATE tbl_persons
SET adress = 'UA'
WHERE tbl_persons.first_name LIKE '%Dima%'

UPDATE tbl_persons
SET first_name = 'Ivan'
WHERE tbl_persons.first_name LIKE '%Iv%'

DELETE FROM tbl_persons
WHERE id = (SELECT id FROM tbl_persons WHERE tbl_persons.first_name = 'Ivan' LIMIT 1 OFFSET 1)

DELETE FROM tbl_persons
WHERE id IN (SELECT id FROM tbl_persons WHERE tbl_persons.first_name = 'Rick' AND tbl_persons.id != 7)

SELECT age, COUNT(age)
FROM tbl_persons
GROUP BY age

SELECT CONCAT('HELLO, ', tbl_persons.first_name,' ', tbl_persons.last_name) AS result
FROM tbl_persons

-- HOMEWORK
 INSERT INTO tbl_persons 
      (first_name, last_name, age, gender, adress)
 VALUES 
      ('Marta', 'Dub', 30, 'F', 'UA'),
	  ('Anastasia', 'Zub', 30, 'F', 'PL'),
	  ('Vita', 'Kub', 30, 'F', 'FR')
	  
 SELECT * FROM tbl_persons
 ORDER BY tbl_persons.id
	  
--select all males
SELECT * 
FROM tbl_persons
WHERE tbl_persons.gender = 'M'

--select all persons with age about 30
SELECT * 
FROM tbl_persons
WHERE tbl_persons.age > 30

--select all persons without address
SELECT id, first_name, last_name, age, gender
FROM tbl_persons

--update age of all persons, add 1 year
UPDATE tbl_persons
SET age = age + 1

--delete all rows without address
DELETE FROM tbl_persons
where tbl_persons.adress IS NULL

--count number of rows in table
SELECT COUNT(*) 
FROM tbl_persons

--group persons by age and show how many persons with same age
 INSERT INTO tbl_persons 
      (first_name, last_name, age, gender, adress)
 VALUES 
      ('Iryna', 'Hak', 25, 'F', 'UA'),
	  ('Julia', 'Bak', 29, 'F', 'PL'),
	  ('Victor', 'Dak', 25, 'M', 'FR'),
	  ('Mate', 'Sop', 27, 'M', 'FR')
	  
SELECT age, COUNT (1) AS persons
FROM tbl_persons
GROUP BY age