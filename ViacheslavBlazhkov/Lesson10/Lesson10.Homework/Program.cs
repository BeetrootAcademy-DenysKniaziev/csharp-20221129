using Lesson10.Homework;

Author auth1 = new Author("Markus Zusak", "Australia", 1975);
Book book1 = Author.WriteBook("Book Thief", auth1);

Console.WriteLine($"{book1.Author} has wrote {book1.Title}");

PublishingHouse pubHouse1 = new PublishingHouse("FLC", "Lviv");
book1 = PublishingHouse.PublishBook(book1, pubHouse1, 249.99);

Console.WriteLine($"{book1.PublishingHouse} has publish {book1.Title}");

Console.WriteLine($"First book: {book1.Title}|{book1.Author}|{book1.PublishingHouse}|{book1.Price}");