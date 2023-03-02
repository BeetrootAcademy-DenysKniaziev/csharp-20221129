CREATE TABLE IF NOT EXISTS phone_book (
	PersonID serial PRIMARY KEY,
    LastName varchar(40) NOT NULL,
    FirstName varchar(40) NOT NULL,
	Age smallint,
    City varchar(40),
	Phone varchar(20) NOT NULL
);

CREATE TABLE IF NOT EXISTS school_schedule (
	DayName varchar(20) UNIQUE PRIMARY KEY,
	FirstLesson varchar(30) DEFAULT '-',
	SecondLesson varchar(30) DEFAULT '-',
	ThirdLesson varchar(30) DEFAULT '-',
	FourthLesson varchar(30) DEFAULT '-'
);

CREATE TABLE IF NOT EXISTS login_history (
	ActionID serial PRIMARY KEY,
	UserID int NOT NULL,
	ActionType varchar(20) NOT NULL,
	ActionDate date NOT NULL
);

CREATE TABLE IF NOT EXISTS bank_accounts (
	AccountID serial PRIMARY KEY,
	LastName varchar(40) NOT NULL,
    FirstName varchar(40) NOT NULL,
	Age smallint NOT NULL,
    Address varchar(40) NOT NULL,
	Phone varchar(20) NOT NULL,
	Balance money NOT NULL
);

CREATE TABLE IF NOT EXISTS transactions (
	TransactionID serial PRIMARY KEY,
	UserID int NOT NULL,
	ActionWithMoney money NOT NULL,
	ActionDate date NOT NULL
);

DROP TABLE transactions;

ALTER TABLE phone_book
ADD newColumn varchar(30) NOT NULL;

ALTER TABLE phone_book
DROP COLUMN City;

ALTER TABLE phone_book
RENAME COLUMN Phone to PhoneNumber;