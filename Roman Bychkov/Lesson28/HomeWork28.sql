DROP TABLE IF EXISTS taken_of_book,count_of_book, book, author, library_;

CREATE TABLE IF NOT EXISTS author
(
	id serial PRIMARY KEY,
	name varchar(30) not null,
	surname varchar(30) not null,
	birthday date not null,
	date_of_death date
);


CREATE TABLE IF NOT EXISTS customer
(
	id serial PRIMARY KEY,
	name varchar(30) not null,
	surname varchar(30) not null,
	birthday date not null,
	indeficator int not null UNIQUE
);

CREATE TABLE IF NOT EXISTS book
(
	id serial PRIMARY KEY,
	name varchar(30) not null,
	indeficator int not null UNIQUE,
	id_author int not null,
	year_of_production smallint not null,
	FOREIGN KEY (id_author) REFERENCES author (id) ON DELETE CASCADE
);

CREATE TABLE IF NOT EXISTS library_
(
	id serial PRIMARY KEY,
	name varchar(30) not null,
	address varchar(50) not null
);


CREATE TABLE IF NOT EXISTS count_of_book
(
	id serial PRIMARY KEY,
	count int DEFAULT 0 CHECK(count>=0),
	available_count int DEFAULT 0 CHECK(available_count<=count),
	id_book int not null,
	id_liblary int not null,
	FOREIGN KEY (id_book) REFERENCES book (indeficator) ON DELETE CASCADE,
	FOREIGN KEY (id_liblary) REFERENCES library_ (id) ON DELETE CASCADE
);
CREATE TABLE IF NOT EXISTS taken_of_book
(
	id serial PRIMARY KEY,
	date date not null,
	id_info_book int not null,
	id_customer int not null,
	FOREIGN KEY (id_info_book) REFERENCES count_of_book (id),
	FOREIGN KEY (id_customer) REFERENCES customer (indeficator)
);

Insert into customer (name,surname,birthday, indeficator) Values
('Walter', 'White','1995-01-12',123),
('Robert', 'Paulson','2000-05-01',321);

Insert into author (name,surname,birthday) Values
('John', 'Cena','2020-01-01'),
('Paul', 'Alen','2000-01-01');


Insert into book (name,indeficator,id_author,year_of_production) Values
('Spectre', 222, 1,2000),
('Space', 350,1,1880),
('RedApple', 349,2,1900);

Insert into library_ (name,address) Values
('Library#1', 'st. Bridge'),
('Library#3', 'st. WhiteHouse');

Insert into count_of_book (count,available_count,id_book,id_liblary) Values
(10, 5,349,1);

Insert into taken_of_book (date, id_info_book,id_customer) Values
('2023-02-03', 1,123);







---the book and its author
Select * 
FROM book INNER JOIN author
ON book.id_author = author.id;

--where can I get the right book?
Select library_.name, library_.address
FROM count_of_book INNER JOIN library_ ON id_liblary = library_.id
INNER JOIN book
ON count_of_book.id_book=book.indeficator 
Where book.name = 'RedApple';

--get info where i can get a book
Select book.name, library_.address
FROM count_of_book INNER JOIN library_ ON id_liblary = library_.id
RIGHT JOIN book
ON count_of_book.id_book=book.indeficator;

--get info about taken of books
Select taken_of_book.date, book.name, book.indeficator, customer.indeficator, customer.surname
FROM taken_of_book INNER JOIN count_of_book 
ON id_info_book = count_of_book.id
INNER JOIN book ON
id_book = book.indeficator
INNER JOIN customer
ON id_customer=customer.indeficator;


