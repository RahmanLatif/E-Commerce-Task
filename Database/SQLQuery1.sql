CREATE TABLE Products (
    Id int IDENTITY(1,1) PRIMARY KEY,
	ProductName varchar(255) NOT NULL,
    ProductDescription varchar(255),
    Category varchar(25) NOT NULL CHECK (Category IN('Appetizers', 'Burgers', 'Pizza', 'Combos', 'Drinks')),
    Price decimal NOT NULL,
	ProductImage varchar(255),
);

go
CREATE PROCEDURE GetProducts @Category varchar(255)
AS
begin
IF @Category = 'All'
    BEGIN
        SELECT * FROM Products 
    END
    ELSE
    BEGIN
        SELECT * FROM Products where Category=@Category
    END
END

go
CREATE PROCEDURE GetProduct @Id int
AS
SELECT * FROM Products where Id = @Id

go
CREATE PROCEDURE AddProduct @ProductName varchar(255), @ProductDescription varchar(255),@Category varchar(255),@Price decimal,@ProductImage varchar(255)
AS
insert into Products values(@ProductName,@ProductDescription,@Category,@Price,@ProductImage)

go
CREATE PROCEDURE EditProduct @Id int,@ProductName varchar(255), @ProductDescription varchar(255),@Category varchar(255),@Price decimal,@ProductImage varchar(255)
AS
update Products set ProductName=@ProductName,ProductDescription=@ProductDescription,Category=@Category,Price=@Price,ProductImage=@ProductImage where Id=@Id

go
CREATE PROCEDURE DeleteProduct @Id int
AS
delete from Products where Id=@Id