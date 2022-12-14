create table Users
(
    PhoneNumber nvarchar(15) not null,
    FirstName nvarchar(50) null,
    Surname nvarchar(50) null,
    Patronymic nvarchar(50) null,
)

go
alter table Users add constraint PK_Users primary key(PhoneNumber)


