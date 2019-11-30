CREATE DATABASE BookStore;
GO

USE BookStore;
GO


Create Table Book
(
	Id int primary key identity(1,1),
	Title varchar(100) not null,
);
GO

Create table Author 
(
	Id int primary key identity(1,1),
	AuthorName varchar(50) Unique not null,
);
GO

Create table Publisher 
(
	Id int primary key identity(1,1),
	PublisherName varchar(50) Unique not null,
);
GO

Create table Genre 
(
	Id int primary key identity(1,1),
	TypeGenre varchar(50) Unique not null,
);
GO

Create Table WritenBy
(	
	
	Author_Id int not null,
	Book_Id int not null,
	CONSTRAINT FK_AUTOR_BOOK FOREIGN KEY (Author_Id) 
		REFERENCES Author(Id) 
		ON DELETE CASCADE,
	CONSTRAINT FK_BOOK_AUTHOR FOREIGN KEY (Book_Id) 
		REFERENCES Book(Id) 
		ON DELETE CASCADE,
	CONSTRAINT PK_BOOK_AUTHOR PRIMARY KEY (Author_Id,Book_Id)
);
GO


Create Table PublishedBy
(	
	Publisher_Id int,
	Book_Id int,
	CONSTRAINT FK_AUTOR_PUBLISHER FOREIGN KEY (Publisher_Id) 
		REFERENCES Publisher(Id) 
		ON DELETE CASCADE,
	CONSTRAINT FK_BOOK_PUBLISHER FOREIGN KEY (Book_Id) 
		REFERENCES Book(Id) 
		ON DELETE CASCADE,
	CONSTRAINT PK_BOOK_PUBLISHER PRIMARY KEY (Publisher_Id,Book_Id)
);
GO

Create Table GenreIs
(	
	Genre_Id int,
	Book_Id int,
	CONSTRAINT FK_AUTOR_GENRE FOREIGN KEY (Genre_Id) 
		REFERENCES Genre(Id) 
		ON DELETE CASCADE,
	CONSTRAINT FK_BOOK_GENRE  FOREIGN KEY (Book_Id) 
		REFERENCES Book(Id) 
		ON DELETE CASCADE,
	CONSTRAINT PK_GENRE_BOOK PRIMARY KEY (Genre_Id, Book_Id)
);
GO


select Title,AuthorName 
from Book
join WritenBy
on WritenBy.Book_Id = Book.Id
join Author
on WritenBy.Author_Id = Author.Id
join Genre
on WritenBy.Book_Id = Genre.Id



DROP DATABASE BookStore;
GO

Insert into 
Genre 
Values
('Fantasia'),
('Policial'),
('Accion'),
('Suspenso')

select * from Genre
select * from Author
Select * from Book
Select * from GenreIs