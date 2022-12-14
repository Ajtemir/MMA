create table ProductPropertyValues
(
    ProductPropertyValueId   int          not null identity,
    ProductPropertyValueName nvarchar(50) not null,
    ProductPropertyKeyId     int          not null
)
alter table ProductPropertyValues
    add constraint PK_ProductPropertyValues primary key (ProductPropertyValueId)
alter table ProductPropertyValues
    add constraint FK_ProductPropertyValues_ProductPropertyKeys foreign key (ProductPropertyKeyId) references ProductPropertyKeys(ProductPropertyKeyId) 
