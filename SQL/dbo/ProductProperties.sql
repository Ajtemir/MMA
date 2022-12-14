CREATE TABLE ProductProperties
(
    ProductId              bigint not null,
    ProductPropertyKeyId   int not null,
    ProductPropertyValueId int not null,
)
go

CREATE CLUSTERED INDEX IX_ProductProperties_ProductId ON ProductProperties(ProductId ASC)
go

alter table ProductProperties
    add constraint PK_ProductProperties
        primary key (ProductId,ProductPropertyKeyId,ProductPropertyValueId)
go

alter table ProductProperties
    add constraint FK_ProductProperties_Products 
        foreign key (ProductId) references Products(ProductId)
        on delete cascade 
go

alter table ProductProperties
    add constraint FK_ProductProperties_ProductPropertyKeys 
        foreign key (ProductPropertyKeyId) references ProductPropertyKeys (ProductPropertyKeyId)
go

alter table ProductProperties
    add constraint FK_ProductProperties_ProductPropertyValues 
        foreign key (ProductPropertyValueId) references ProductPropertyValues(ProductPropertyValueId)
go

