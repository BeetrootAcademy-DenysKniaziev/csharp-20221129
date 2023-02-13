CREATE TABLE IF NOT EXISTS phone_book (
	id SERIAL PRIMARY KEY,
	name varchar(50) NOT NULL,
	last_name varchar(50) NOT NULL,
	address text,
	phone_number integer
);

SELECT * FROM phone_book
DROP TABLE phone_book


CREATE TABLE IF NOT EXISTS school_schedule (
	id SERIAL PRIMARY KEY,
	day varchar(10) NOT NULL,
	name varchar(50) NOT NULL,
	start varchar(5) NOT NULL
);

SELECT * FROM school_schedule

ALTER TABLE school_schedule
ALTER COLUMN start TYPE TIME
USING start::time without time zone;

ALTER TABLE school_schedule
DROP COLUMN id;

ALTER TABLE school_schedule
ADD end_time TIME;

ALTER TABLE school_schedule
ALTER COLUMN end_time TYPE TIME 
USING end_time::time without time zone;

ALTER TABLE school_schedule
RENAME COLUMN start TO start_time;


CREATE TABLE IF NOT EXISTS login_history (
	id SERIAL PRIMARY KEY,
	site_name varchar(50) NOT NULL,
	day varchar(10) NOT NULL,
	enter_time varchar(5) NOT NULL,
	exit_time varchar(5) NOT NULL
);

SELECT * FROM login_history


ALTER TABLE login_history
ALTER COLUMN enter_time TYPE time
USING enter_time::time without time zone;

ALTER TABLE login_history
ALTER COLUMN exit_time TIME UTC+2 NOT NULL;


CREATE TABLE IF NOT EXISTS bank_account (
	id SERIAL PRIMARY KEY,
	name varchar(50) NOT NULL,
	last_name varchar(50) NOT NULL,
	registration_date date Not NULL,
	money money NULL
);
SELECT * FROM bank_account


CREATE TABLE IF NOT EXISTS bank_transaction (
	id SERIAL PRIMARY KEY,
	from_person varchar(50) NOT NULL,
	to_person varchar(50) NOT NULL,
	transaction_date timestamp Not NULL,
	money money NULL
);
SELECT * FROM bank_transaction

DROP DATABASE lesson;