
CREATE TABLE IF NOT EXISTS phone_book(
    id serial PRIMARY KEY,
    name varchar(30) not null,
    lastName varchar(30) not null,
	phoneNumber bigint not null CHECK (LENGTH(CAST(phoneNumber as text)) = 12 )
	);
ALTER TABLE phone_book
  ADD COLUMN indeficator smallint CHECK(indeficator<9999);
  
CREATE TABLE IF NOT EXISTS school_schedule(
    id serial PRIMARY KEY,
    subject varchar(30) not null,
    room smallint not null CHECK (room BETWEEN 100 AND 999),
	startTime date not null,
	endTime date not null,
	CHECK (startTime < endTime) 							
	);
ALTER TABLE school_schedule
  DROP COLUMN endTime;
  
ALTER TABLE school_schedule
  ADD COLUMN teacher varchar(30);

CREATE TABLE IF NOT EXISTS users_login_history
(
	id serial PRIMARY KEY,
	login date not null,
	nick varchar(30) not null
);


CREATE TABLE IF NOT EXISTS bank_account
(
	id serial PRIMARY KEY,
	name varchar(30) not null,
	lastName varchar(30) not null,
	balance decimal(9,2) not null CHECK(balance>0),
	indeficator bigint not null,
	created date not null,
	UNIQUE(indeficator)
);


CREATE TABLE IF NOT EXISTS bank_transactions_data
(
	id serial PRIMARY KEY,
	sum decimal(9) not null CHECK(sum>0),
	indeficator_From bigint not null REFERENCES bank_account(indeficator),
	indeficator_To bigint not null REFERENCES bank_account(indeficator),
	created time not null,
	CHECK(indeficator_From!=indeficator_To)
);


ALTER Table bank_account
ALTER COLUMN indeficator TYPE int;

ALTER Table bank_account
ALTER COLUMN balance TYPE numeric(8,5);
  
DROP TABLE IF EXISTS bank_account CASCADE;

DROP DATABASE IF EXISTS basehomework26;

