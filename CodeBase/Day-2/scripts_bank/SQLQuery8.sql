CREATE PROCEDURE dbo.usp_GetCustomerAccounts
@CustomerID INT
AS
BEGIN
SET NOCOUNT ON;
SELECT a.AccountID, a.Balance, a.AccountType, b.BranchName
FROM dbo.Accounts a
JOIN dbo.Branches b ON a.BranchID = b.BranchID
WHERE a.CustomerID = @CustomerID;
END;
GO
-- Execute
EXEC dbo.usp_GetCustomerAccounts @CustomerID = 1;