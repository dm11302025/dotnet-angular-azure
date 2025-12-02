CREATE FUNCTION fn_GetDiscount(@Amount DECIMAL(10,2))
RETURNS DECIMAL(10,2)
AS
BEGIN
    DECLARE @Discount DECIMAL(10,2)
    SET @Discount = @Amount * 0.10
    RETURN @Discount
END
SELECT dbo.fn_GetDiscount(5000) AS DiscountAmount;
SELECT dbo.fn_GetDiscount(50000) AS DiscountAmount;
