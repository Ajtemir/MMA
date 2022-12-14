CREATE TABLE ProductPropertyKeys
(
    ProductPropertyKeyId int not null identity,
    ProductPropertyKeyName nvarchar(50) not null,
    CategoryId int not null,
    IsMultiple bit not null
)
go

alter table ProductPropertyKeys add constraint PK_ProductPropertyKeys primary key(ProductPropertyKeyId)
go

alter table ProductPropertyKeys add constraint FK_ProductPropertyKeys_Categories foreign key (CategoryId) references Categories(CategoryId)
go

alter table ProductPropertyKeys add constraint DF_ProductPropertyKeys_IsMultiple default 0 for IsMultiple
go