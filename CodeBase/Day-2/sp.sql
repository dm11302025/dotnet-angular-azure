CREATE PROCEDURE usp_GetCustomerOrders
    @CustomerID INT
AS
BEGIN
    SELECT o.OrderID, o.OrderDate, p.ProductName, od.Quantity, od.SubTotal
    FROM Orders o
    JOIN OrderDetails od ON o.OrderID = od.OrderID
    JOIN Products p ON p.ProductID = od.ProductID
    WHERE o.CustomerID = @CustomerID;
END
EXEC usp_GetCustomerOrders @CustomerID = 1;
