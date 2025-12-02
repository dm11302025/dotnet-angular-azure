CREATE PROCEDURE dbo.usp_DepositToAccount
@AccountID BIGINT,
@Amount MONEY
AS
BEGIN
SET NOCOUNT ON;
IF @Amount <= 0
BEGIN
--THROW 50001, 'Amount must be greater than zero.', 1;
print 'Amount must be greater than zero'
END
BEGIN TRY
BEGIN TRAN;
UPDATE dbo.Accounts
SET Balance = Balance + @Amount
WHERE AccountID = @AccountID;
INSERT INTO dbo.Transactions(AccountID, Amount, TranType, Description)
VALUES (@AccountID, @Amount, 'D', 'Deposit');
COMMIT TRAN;
END TRY
BEGIN CATCH
IF XACT_STATE() <> 0
ROLLBACK TRAN;
DECLARE @ErrMsg NVARCHAR(4000) = ERROR_MESSAGE();
DECLARE @ErrNo INT = ERROR_NUMBER();
THROW @ErrNo, @ErrMsg, 1;
END CATCH
END
GO