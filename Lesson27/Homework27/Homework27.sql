--Create few tables schemas:
--table for ‘phone book’
--table to store school schedule
--table to store user’s login history
--table to store bank accounts
--table to store bank transactions data
--EXTRA HOMEWORK:
--Use several ALTER/DROP operations with created tables			
					
CREATE TABLE IF NOT EXISTS phone_book(
	id SERIAL PRIMARY KEY,
	first_name VARCHAR(100) NOT NULL,
	last_name VARCHAR(100) NOT NULL,
	phone_number VARCHAR(20) NOT NULL
);

ALTER TABLE IF EXISTS phone_book 
	ADD COLUMN IF NOT EXISTS
	organisation VARCHAR(100) DEFAULT 'No Company Name';

SELECT * FROM phone_book
		
CREATE TABLE IF NOT EXISTS school_schedule(
	id SERIAL PRIMARY KEY,
	subject  VARCHAR(100) NOT NULL,
	start_time TIME  NOT NULL,
	end_time TIME  NOT NULL CHECK ( end_time - start_time = '00:45:00' )
);
					
INSERT INTO school_schedule
	(subject, start_time,end_time)
VALUES ('Math', '09:30:00', '10:15:00' );
					
SELECT * FROM school_schedule;		
					
DROP TABLE IF EXISTS school_schedule;


CREATE TABLE IF NOT EXISTS users_login_history(
	id SERIAL PRIMARY KEY,
	login_entered VARCHAR(100) NOT NULL,
	password_entered VARCHAR(100) NOT NULL,
	attempt_succeed  BOOL NOT NULL,
	attempt_time TIMESTAMP NOT NULL,
);

CREATE TABLE IF NOT EXISTS bank_accounts(
	account_number SMALLINT UNIQUE NOT NULL PRIMARY KEY,
	bank_mfo SMALLINT NOT NULL,
	customer_first_name VARCHAR(100) NOT NULL,
	customer_last_name VARCHAR(100) NOT NULL,
	secured_password VARCHAR(100) NOT NULL,
	acount_currency  VARCHAR(3) NOT NULL,
	ammount INT
);

SELECT * FROM bank_accounts;

ALTER TABLE IF EXISTS bank_accounts 
	ADD COLUMN IF NOT EXISTS
	secondary_acount_currency  VARCHAR(3) NOT NULL,
	ADD COLUMN IF NOT EXISTS
	secondary_currency_ammount INT;
	
--DO $$
--BEGIN
--  IF EXISTS(SELECT *
--    FROM information_schema.columns
--    WHERE table_name = 'bank_accounts' and column_name = 'acount_currency')
--  THEN
--     ALTER TABLE "public"."bank_accounts" RENAME COLUMN "ptimary_acount_currency" TO "acount_currency";
--  END IF;
--END $$;

DO
$$
    BEGIN
        ALTER TABLE bank_accounts
            RENAME COLUMN  acount_currency TO primary_acount_currency;
    EXCEPTION
        WHEN undefined_column THEN RAISE NOTICE 'column acount_currency does not exist';
    END;
$$;
DO
$$
    BEGIN
        ALTER TABLE bank_accounts
            RENAME COLUMN  ammount TO ptimary_currency_ammount;
    EXCEPTION
        WHEN undefined_column THEN RAISE NOTICE 'column ammount does not exist';
    END;
$$;

	
	CREATE TABLE IF NOT EXISTS bank_transactions_data(
	id SERIAL PRIMARY KEY
	sender_account_number SMALLINT NOT NULL,
	recipient_account_number SMALLINT NOT NULL,
	sender_bank_mfo SMALLINT NOT NULL,
	recipient_bank_mfo SMALLINT NOT NULL,
--	sender_id VARCHAR(100) NOT NULL,
	transaction_curency VARCHAR(3) NOT NULL,
	transaction_amount MONEY NOT NULL,
	attempt_succeed  BOOL NOT NULL,
	attempt_time TIMESTAMP NOT NULL,
);