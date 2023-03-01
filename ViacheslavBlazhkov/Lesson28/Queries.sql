CREATE TABLE authors (
	author_id serial PRIMARY KEY,
	first_name varchar(30),
	last_name varchar(30) NOT NULL
);

CREATE TABLE customers (
	customer_id serial PRIMARY KEY,
	first_name varchar(30) NOT NULL,
	last_name varchar(30) NOT NULL,
	phone_number varchar(20) NOT NULL,
	email varchar(30)
);

CREATE TABLE genres (
	genre_id serial PRIMARY KEY,
	genre_title varchar(30) NOT NULL
);

CREATE TABLE books (
	book_id serial PRIMARY KEY,
	title varchar(30) NOT NULL,
	genre int REFERENCES genres(genre_id),
	author int REFERENCES authors(author_id)
);

CREATE TABLE libraries (
	library_id serial PRIMARY KEY,
	library_name varchar(30),
	address varchar(30)
);

CREATE TABLE books_counts (
	record_id serial PRIMARY KEY,
	book int REFERENCES books(book_id) NOT NULL,
	library_ int REFERENCES libraries(library_id) NOT NULL
);

CREATE TABLE operations (
	operation_id serial PRIMARY KEY,
	operation_type varchar(30) NOT NULL
);

CREATE TABLE books_histories (
	action_id serial PRIMARY KEY,
	library_giver int REFERENCES libraries(library_id) NOT NULL,
	operation int REFERENCES operations(operation_id) NOT NULL,
	customer int REFERENCES customers(customer_id) NOT NULL,
	book int REFERENCES books(book_id) NOT NULL,
	action_date date DEFAULT NOW()
);
