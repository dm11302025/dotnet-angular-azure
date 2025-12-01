DECLARE @CustName NVARCHAR(100);

DECLARE cust_cursor CURSOR FOR
SELECT CustomerName FROM Customers;

OPEN cust_cursor;
FETCH NEXT FROM cust_cursor INTO @CustName;

WHILE @@FETCH_STATUS = 0
BEGIN
    PRINT 'Hello ' + @CustName;
    FETCH NEXT FROM cust_cursor INTO @CustName;
END

CLOSE cust_cursor;
DEALLOCATE cust_cursor;
