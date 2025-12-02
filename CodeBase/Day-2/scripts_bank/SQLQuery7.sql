create procedure GetCustomerById(@Cid int)
as
begin
select * from dbo.Customers where CustomerID=@Cid
end
Go
exec GetCustomerById 1
exec GetCustomerById 2
exec GetCustomerById @Cid=1