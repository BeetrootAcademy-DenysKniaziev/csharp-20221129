CREATE TABLE IF NOT EXISTS books (
	id serial PRIMARY KEY,
	name varchar(50) NOT NULL,
	author_id int NOT NULL,
	FOREIGN KEY (author_id) REFERENCES authors (id) 
);
SELECT * FROM books

CREATE TABLE IF NOT EXISTS authors (
	id serial PRIMARY KEY,
	first_name varchar(50) NOT NULL,
	last_name varchar(50) NOT NULL,
	date_of_born date NOT NULL,
	date_of_die date 
);
SELECT * FROM authors

CREATE TABLE IF NOT EXISTS count_of_book (
	id serial PRIMARY KEY,
	count int NOT NULL DEFAULT 0,
	book_id int NOT NULL,
	FOREIGN KEY (book_id) REFERENCES books (id)
);
SELECT * FROM count_of_book

CREATE TABLE IF NOT EXISTS customers (
	id serial PRIMARY KEY,
	first_name varchar(50) NOT NULL,
	last_name varchar(50) NOT NULL,
	adress varchar(50) NOT NULL
);
SELECT * FROM customers

CREATE TABLE IF NOT EXISTS history_book (
	id serial PRIMARY KEY,
	date date NOT NULL,
	book_id int NOT NULL,
	customer_id int NOT NULL,
	FOREIGN KEY (book_id) REFERENCES books (id),
	FOREIGN KEY (customer_id) REFERENCES customers (id)
);
SELECT * FROM history_book

INSERT INTO authors
      (first_name, last_name, date_of_born, date_of_die)
VALUES 
      ('Devid', 'Shark', '1795-03-12', '1891-07-1'),
	  ('Iva', 'Shyts', '1863-12-3', '1935-07-29'),
	  ('Darth', 'Vader', '1913-06-23', '1998-09-6')
INSERT INTO authors
      (first_name, last_name, date_of_born)
VALUES
	  ('Tony', 'Stark', '1977-10-16')
	  
INSERT INTO books
      (name, author_id)
VALUES 
 	  ('AAAAA', 3),
	  ('BBBBB', 3),
	  ('CCCCC', 1),
	  ('DDDDD', 2),
	  ('EEEEE', 4)
	  
INSERT INTO customers
      (first_name, last_name, adress)
VALUES 
 	  ('Abu', 'Cin', 'Green Street 12'),
	  ('Axfg', 'Bfea', 'Street 1')
	  
INSERT INTO count_of_book
      (count, book_id)
VALUES 
 	  (24, 1),
	  (45, 2),
	  (10, 3),
	  (78, 4),
	  (49, 5)
	  
	  
INSERT INTO history_book
      (date, book_id, customer_id)
VALUES
 	  ('2023-02-19', 3, 1),
	  ('2023-02-19', 4, 2)

SELECT * FROM books  RIGHT JOIN history_book
ON books.id = history_book.book_id
SELECT * FROM books INNER JOIN authors
ON books.author_id = authors.id
SELECT * FROM books  LEFT JOIN history_book
ON books.id = history_book.book_id
SELECT * FROM history_book INNER JOIN customers
ON history_book.customer_id = customers.id
 
SELECT count_of_book.count, books.name, 
 CONCAT (authors.first_name,' ',authors.last_name) AS authors_name, 
 CONCAT (authors.date_of_born,' - ',authors.date_of_die) AS date,
 CONCAT (customers.first_name,' ',customers.last_name) AS customers_name,
 customers.adress, history_book.date
 FROM books INNER JOIN authors ON books.author_id = authors.id
 LEFT JOIN count_of_book ON books.id = count_of_book.book_id 
 FULL JOIN history_book  ON books.id = history_book.book_id 
 FULL JOIN customers ON history_book.customer_id = customers.id