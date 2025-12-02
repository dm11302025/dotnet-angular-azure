INSERT INTO dbo.Branches (BranchName, City, IFSC)
VALUES
('Central', 'Mumbai', 'BKID0000001'),
('Andheri', 'Mumbai', 'BKID0000002');
select * from dbo.Branches
INSERT INTO dbo.Customers (FirstName, LastName, Email, DateOfBirth)
VALUES
('Amit','Kumar','amit.k@example.com','1985-06-15'),
('Neha','Sharma','neha.s@example.com','1990-02-21'),
('Ravi','Patel', NULL, '1979-11-03');
INSERT INTO dbo.Accounts (CustomerID, BranchID, AccountType, Balance)
VALUES
(1,1,'S', 15000),
(2,2,'C', 500000),
(3,1,'S', 2500);