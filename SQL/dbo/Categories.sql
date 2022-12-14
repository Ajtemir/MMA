CREATE TABLE Categories
(
    CategoryId int not null identity,
    CategoryName nvarchar(50) not null,
    ParentCategoryId int null
)
go
alter table Categories add constraint PK_Categories primary key(CategoryId)
go
alter table Categories add constraint FK_Categories_ParentCategoryId_CategoryId foreign key (ParentCategoryId) references Categories(CategoryId)