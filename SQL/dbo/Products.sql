create table Products
(
    ProductId bigint not null identity,
    Description nvarchar(150) null,
    Price money null,
    CategoryId int not null
)
go

alter table Products add constraint PK_Products primary key(ProductId)
go
alter table Products 
    add constraint FK_Products_Categories foreign key(CategoryId) references Categories(CategoryId)