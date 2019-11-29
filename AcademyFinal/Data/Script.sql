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
	[Name] varchar(50) not null,
);
GO

Create table Publisher 
(
	Id int primary key identity(1,1),
	[Name] varchar(50) not null,
);
GO

Create table Genre 
(
	Id int primary key identity(1,1),
	[Type] varchar(50) not null,
);
GO

Create Table WritenBy
(	
	Id int primary key identity(1,1),
	Author_Id int,
	Book_Id int,
	CONSTRAINT FK_AUTOR_BOOK FOREIGN KEY (Author_Id) 
		REFERENCES Author(Id) 
		ON DELETE CASCADE,
	CONSTRAINT FK_BOOK_AUTHOR FOREIGN KEY (Book_Id) 
		REFERENCES Book(Id) 
		ON DELETE CASCADE,
	CONSTRAINT UQ_BOOK_AUTHOR UNIQUE (Author_Id, Book_Id)
);
GO


Create Table PublishedBy
(	
	Id int primary key identity(1,1),
	Publisher_Id int not null,
	Book_Id int not null,
	CONSTRAINT FK_AUTOR_PUBLISHER FOREIGN KEY (Publisher_Id) 
		REFERENCES Publisher(Id) 
		ON DELETE CASCADE,
	CONSTRAINT FK_BOOK_PUBLISHER FOREIGN KEY (Book_Id) 
		REFERENCES Book(Id) 
		ON DELETE CASCADE,
	CONSTRAINT UQ_BOOK_PUBLISHER UNIQUE (Publisher_Id, Book_Id)
);
GO

Create Table GenreIs
(	
	Id int primary key identity(1,1),
	Genre_Id int not null,
	Book_Id int not null,
	CONSTRAINT FK_AUTOR_GENRE FOREIGN KEY (Genre_Id) 
		REFERENCES Genre(Id) 
		ON DELETE CASCADE,
	CONSTRAINT FK_BOOK_GENRE  FOREIGN KEY (Book_Id) 
		REFERENCES Book(Id) 
		ON DELETE CASCADE,
	CONSTRAINT UQ_BOOK_GENRE UNIQUE (Genre_Id, Book_Id)
);
GO


select Title,[Name] 
from Book
join WritenBy
on WritenBy.Book_Id = Book.Id
join Author
on WritenBy.Author_Id = Author.Id