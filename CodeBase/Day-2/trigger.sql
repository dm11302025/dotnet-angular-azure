CREATE TRIGGER trg_AfterOrderInsert
ON Orders
AFTER INSERT
AS
BEGIN
    PRINT 'New order placed successfully!';
END
insert into Orders values(1,getdate(),15000)
