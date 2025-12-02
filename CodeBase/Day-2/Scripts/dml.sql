INSERT INTO Customers (FullName, Email, City)
VALUES ('John Doe', 'john@gmail.com', 'New York'),
       ('Mary Jane', 'mary@gmail.com', 'Chicago');
       INSERT INTO Products (ProductName, Price, Stock)
VALUES ('Laptop', 75000, 20),
       ('Smartphone', 25000, 50),
       ('Mouse', 800, 200);
       SELECT * FROM Customers;
       SELECT ProductName, Price FROM Products WHERE Price > 10000;
       SELECT * from Products
       UPDATE Products SET Stock = Stock - 2 WHERE ProductID = 1;
       DELETE FROM Products WHERE ProductID = 3;