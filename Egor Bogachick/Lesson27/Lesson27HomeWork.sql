CREATE TABLE IF NOT EXISTS phone_book(
	id SERIAL PRIMARY KEY,
	first_name varchar(100) NOT NULL,
	last_name VARCHAR(100) NOT NULL,
	number VARCHAR(50) NOT NULL,
	address VARCHAR(100)
);

SELECT * FROM phone_book;

ALTER TABLE phone_book ADD COLUMN IF NOT EXISTS city varchar(100);

DROP TABLE phone_book;


CREATE TABLE IF NOT EXISTS school_schedule(
	id SERIAL PRIMARY KEY,
	lesson varchar(100) NOT NULL,
	day varchar(100),
	time_start VARCHAR(100),
	time_end VARCHAR(100)
);

SELECT * FROM school_schedule;

ALTER TABLE school_schedule
ALTER COLUMN time_start TYPE time 
USING time_start::time without time zone;

DROP TABLE school_schedule;


CREATE TABLE IF NOT EXISTS login_history(
	id SERIAL PRIMARY KEY,
	site VARCHAR(300) NOT NULL,
	day varchar(100) NOT NULL,
	time_start VARCHAR(255)  NOT NULL,
	time_end VARCHAR(255) NOT NULL
);

SELECT * FROM login_history;

DROP TABLE phone_book;


CREATE TABLE IF NOT EXISTS bank_accounts(
	id SERIAL PRIMARY KEY,
	login VARCHAR(50) NOT NULL,
	password VARCHAR(50) NOT NULL,
	first_name varchar(100) NOT NULL,
	last_name VARCHAR(100) NOT NULL,
	registration_date date NOT NULL,
	amount money
);

SELECT * FROM bank_accounts;

ALTER TABLE bank_accounts
RENAME COLUMN first_name TO name;

DROP TABLE bank_accounts;


CREATE TABLE IF NOT EXISTS bank_transactions(
	id SERIAL PRIMARY KEY,
	transaction_name VARCHAR(100),
	sender_name VARCHAR(200) NOT NULL,
	recipient_name VARCHAR(200) NOT NULL,
	transaction_date date NOT NULL,
	money_amount money NOT NULL
);

SELECT * FROM bank_transactions;

ALTER TABLE bank_transactions
DROP COLUMN transaction_name;

DROP TABLE bank_transactions;

