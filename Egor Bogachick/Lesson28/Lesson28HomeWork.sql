CREATE TABLE IF NOT EXISTS books(
	id SERIAL PRIMARY KEY,
	title varchar(150) NOT NULL,
	book_date date NOT NULL,
	author_id int REFERENCES authors (id),
	about_book text
);

SELECT * FROM books;

INSERT INTO books
	(title, book_date, author_id, about_book)
VALUES
	('Wind', '2014-06-05', NULL, 'Some text about book')
	('Fire', '2004-06-05', 1, 'Some text about book'),
	('Water', '2002-03-07', 2, 'Some text about book'),
	('Erth', '2010-08-01', 4, 'Some text about book'),
	('Air', '2013-05-05', 3, NULL);

CREATE TABLE IF NOT EXISTS authors(
	id SERIAL PRIMARY KEY,
	first_name varchar(100),
	last_name varchar(100) NOT NULL,
	about_author text
);

SELECT * FROM authors;

INSERT INTO authors
	(first_name, last_name, about_author)
VALUES
	('Jake', 'Kameron', 'Some text about author'),
	('Kate', 'Joline', 'Some text about author'),
	(NULL, 'Mysterious', NULL),
	('Bob', 'Mad', 'Some text about author');

CREATE TABLE IF NOT EXISTS count_books(
	id SERIAL PRIMARY KEY,
	book_id int REFERENCES books (id),
	number int 
);

SELECT * FROM count_books;

INSERT INTO count_books
	(book_id, number)
VALUES
	(1, 5),
	(2, 6),
	(3, 1),
	(4, 15);

CREATE TABLE IF NOT EXISTS customers(
	id SERIAL PRIMARY KEY,
	first_name varchar(100) NOT NULL,
	last_name varchar(100) NOT NULL,
	phone varchar(100),
	email varchar(100)
);

SELECT * FROM customers;

INSERT INTO customers
	(first_name, last_name, phone, email)
VALUES
	('Josh', 'Murray', '23-34-345', 'murray@gmail.com'),
	('Lisa', 'Simpson', NULL, 'lsimpson@gmail.com'),
	('Rose', 'Lomochenko', '16-43-678', NULL),
	('Ali', 'Le', '63-33-387', 'alile@gmail.com');

CREATE TABLE IF NOT EXISTS history(
	id SERIAL PRIMARY KEY,
	customer_id int REFERENCES customers (id),
	book_id int REFERENCES books (id),
	book_condition varchar(150)
);

SELECT * FROM history;

INSERT INTO history
	(customer_id, book_id, book_condition)
VALUES
	(1, 3, 'Good'),
	(2, 2, 'Normal'),
	(3, 4, 'Bad'),
	(4, 3, 'Not toched'),
	(2, 4, 'Good');


SELECT b.title, c.number, a.first_name, a.last_name, b.about_book, a.about_author 
FROM books b 
	FULL JOIN count_books c ON b.id = c.id 
	INNER JOIN authors a ON b.id = a.id ;

SELECT b.title, h.book_condition, c.first_name, c.last_name FROM history h FULL JOIN books b ON b.id = h.id FULL JOIN customers c ON h.id = c.id;

