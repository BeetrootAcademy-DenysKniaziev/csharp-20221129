CREATE TABLE IF NOT EXISTS phone_book (
	id serial PRIMARY KEY,
	first_name varchar(50) NOT NULL,
	last_name varchar(50) NOT NULL,
	number varchar(50) UNIQUE
);

SELECT * FROM phone_book
ORDER BY phone_book.id

--DROP TABLE IF EXISTS phone_book

SELECT CONCAT('HELLO, ', phone_book.first_name,' ', phone_book.last_name) AS result
FROM phone_book

INSERT INTO phone_book 
      (first_name, last_name, number)
 VALUES 
      ('Devid', 'Shark', '156-483-781'),
	  ('Iva', 'Shyts', '561-491-358'),
	  ('Darth', 'Vader', '666-666-666'),
	  ('Tony', 'Stark', '156-365-777')
	  
CREATE TABLE IF NOT EXISTS school_schedule (
	id serial PRIMARY KEY,
	day varchar(50) NOT NULL,
	lesson_name varchar(50) NOT NULL,
	time varchar(50) NOT NULL 
);

--DROP TABLE IF EXISTS school_schedule

SELECT * FROM school_schedule
ORDER BY school_schedule.id

INSERT INTO school_schedule 
      (day, lesson_name, time)
 VALUES 
     ('Monday', 'Physics', '08:00-10:30'),
	 ('Tuesday', 'History', '11:00-13:00')
	 
ALTER TABLE IF EXISTS school_schedule ADD COLUMN big_test boolean NOT NULL DEFAULT false

UPDATE school_schedule
SET big_test = true
WHERE school_schedule.day <> 'Monday'

CREATE TABLE IF NOT EXISTS login_history (
	id serial PRIMARY KEY,
	login varchar(50) NOT NULL,
	day varchar(50) NOT NULL,
	enter_time varchar(50) NOT NULL,
	exit_time varchar(50) NOT NULL
);

SELECT * FROM login_history
ORDER BY school_schedule.id

CREATE TABLE IF NOT EXISTS bank_account
(
	id serial PRIMARY KEY,
	first_name varchar(50) NOT NULL,
	lastName varchar(500) NOT NULL,
	balance decimal NOT NULL CHECK (balance>0)
);

CREATE TABLE IF NOT EXISTS bank_transaction (
	id serial PRIMARY KEY,
	from_person varchar(50) NOT NULL,
	to_person varchar(50) NOT NULL,
	transaction_date time NOT NULL
);

DROP DATABASE IF EXISTS shop;