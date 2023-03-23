--Create normalized tables for the library domain. it should include:

--books
--authors
--count of each book
--customers
--history which book was taken by whom and when
--Exstra
--Do the joint :)

CREATE TABLE IF NOT EXISTS authors(
	id SERIAL PRIMARY KEY,
	first_name VARCHAR(50) NOT NULL,
	last_name VARCHAR(50) NOT NULL
);

CREATE TABLE IF NOT EXISTS books(
	id SERIAL PRIMARY KEY,
	book_name VARCHAR(50) NOT NULL,	
	autor_id INT REFERENCES authors(id),
	amount SMALLINT 
);

CREATE TABLE IF NOT EXISTS customers(
	id SERIAL PRIMARY KEY, --And the account number at the same time
	first_name VARCHAR(50) NOT NULL,
	last_name VARCHAR(50) NOT NULL,
	loyalty BOOL
);

CREATE TABLE IF NOT EXISTS books_taken_transactions(
	id SERIAL PRIMARY KEY,
	customer_id INT REFERENCES customers(id),
	book_id INT REFERENCES books(id),
	when_took TIMESTAMP NOT NULL,
	when_returned TIMESTAMP 
);	


ALTER TABLE books
ALTER COLUMN book_name TYPE VARCHAR(100);

ALTER TABLE books_taken_transactions
ALTER COLUMN when_returned DROP NOT NULL;



INSERT INTO authors
	(first_name, last_name)
VALUES
	('Kvitka','Osnovyanenko'),
	('Stepan','Rudanskyi'),
	('Taras','Shevchenko');
	
INSERT INTO books
	(book_name, autor_id, amount)
VALUES
	('Perekotypole',1, 3),
	('Humoresky',2,5),
	('Kobzar',3,0);

INSERT INTO customers
	(first_name, last_name)
VALUES
	('Dmytro','Bonislavskyi'),
	('Vasyl','Popenko'),
	('Acrobat','Reader');

INSERT INTO books_taken_transactions
	(customer_id, book_id, when_took)
VALUES
	(1,1, '2023-01-15 12:00:00'),
	(1,2, '2023-02-05 12:00:00'),
	(2,2, '2022-12-25 12:00:00');
	



SELECT * FROM books_taken_transactions
FULL OUTER JOIN books ON books_taken_transactions.book_id = books.id

SELECT books_taken_transactions.when_took, books.book_name, CONCAT(customers.last_name, ' ', customers.first_name) as customer FROM books_taken_transactions
INNER JOIN books ON books_taken_transactions.book_id = books.id
INNER JOIN customers ON books_taken_transactions.customer_id = customers.id

SELECT * FROM books_taken_transactions
FULL OUTER JOIN books ON books_taken_transactions.book_id = books.id
WHERE books_taken_transactions.book_id IS NULL OR books.id IS NULL

SELECT * FROM books_taken_transactions
LEFT JOIN customers ON books_taken_transactions.customer_id = customers.id

SELECT * FROM books_taken_transactions
RIGHT JOIN customers ON books_taken_transactions.customer_id = customers.id
WHERE books_taken_transactions.book_id IS NULL


