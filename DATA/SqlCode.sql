--Tìm bill với id  bàn chưa thanh toán
SELECT * FROM BILL WHERE idTable = 1 and status = 0 
--------------------------------------------------
--Lấy Danh Sách BillInfo theo IDBIll
SELECT * FROM BillInfo WHERE idBill = 10 
--------------------------------------------------
--Tạo PROC for Bill and BillInfo
go
CREATE PROC InsertBill
@idTable int,
@userName nvarchar(100) = "user"
as 
begin


	Select * from bill, BillInfo where idTable = 13


	INSERT Bill ( DateCheckIn , DateCheckOut , idTable , status, UserName,totalPrice )
	VALUES           ( GETDATE() , Null , @idTable , 0 , @userName,)
end
go
CREATE PROC InsertTable
@idTable int
as 
begin
	UPDATE TableFood( id, name, status)
	VALUES           (@idTable, )
end
go
CREATE PROC InsertBillInfo
@idBill int, @idFood int ,@count int
AS
BEGIN
	----
	DECLARE @isBillInfo int;
	DECLARE @FCount int = 1;
	SELECT @isBillInfo = id, @FCount = count 
	FROM BillInfo 
	WHERE idBill = @idBill AND idFood = @idFood
	----
	IF(@isBillInfo > 0)
	BEGIN 
		DECLARE @newCount int = @FCount + @count
		IF(@newCount > 0)
			UPDATE BillInfo SET count = @FCount + @count WHERE idFood = @idFood
		ELSE
			DELETE BillInfo WHERE idBill = @idBill AND idFood = @idFood 
	END
	----
	ELSE
	BEGIN 
		INSERT BillInfo( idBill , idFood , count )
		VALUES ( @idBill , @idFood , @count )
	END

END 
GO
--------------------------------------------------
-- Tìm IDBill Max

SELECT max(id) FROM Bill
GO
--------------------------------------------------
--Lấy Danh Sách Bàn 

CREATE PROC GetTableList
AS SELECT * FROM TableFood
GO

EXEC GetTableList

--------------------------------------------------
-- Lấy Danh Sách ListView 

SELECT food.name , BillInfo.count , food.price, food.price * BillInfo.count from BillInfo,Food, Bill
WHERE bill.id = BillInfo.idBill AND food.id = BillInfo.idFood AND idTable = 8


SELECT DISTINCT  food.name , BillInfo.count , food.price, food.price * BillInfo.count As totalprice 
from BillInfo,Food, Bill,TableFood 
WHERE bill.id = BillInfo.idBill AND food.id = BillInfo.idFood AND TableFood.status = N'Trống' 

SELECT  food.name , BillInfo.count , food.price, food.price * BillInfo.count As totalprice
from BillInfo,Food, Bill,TableFood 
WHERE bill.status = 0 AND bill.id = BillInfo.idBill AND food.id = BillInfo.idFood AND TableFood.status = N'Có Khách' AND TableFood.id = 7 AND idTable = 7
--------------------------------------------------
-- Tạo Trigger set trạng thái bàn

ALTER TRIGGER UpdateBillInfo 
ON BillInfo For Insert , Update
As 
Begin
	DECLARE @idBill int

	SELECT @idBill = idBill from Inserted

	DECLARE @idTable int

	SELECT @idTable = idTable from Bill Where id = @idBill AND status = 0

	UPDATE TableFood SET status = N'Có Khách' WHERE id = @idTable
End
Go

ALTER TRIGGER UpdateBill
ON Bill For Update
As 
Begin
	DECLARE @idBill int

	SELECT @idBill = id from Inserted

	DECLARE @idTable int

	SELECT @idTable = idTable from Bill Where id = @idBill

	DECLARE @count int = 0
	
	SELECT @count = count(*) from Bill WHERE idTable = @idTable AND status = 0

	IF(@count = 0) 
		UPDATE TableFood SET status = N'Trống' WHERE id = @idTable
End
Go
--------------------------------------------------

DELETE BillInfo
DELETE bill


----------------
--Chuyển Bàn 

ALTER PROC SwitchTable
@IdTable1 int , @IdTable2 int
As Begin 
	Declare @idFirstBill int

	Declare @idSecondBill int

	Declare @idFirstBillEmpty int =1 

	Declare @idSecondBillEmpty int =1

	Select @idSecondBill = id from Bill where idTable = @IdTable2 AND status =0

	Select @idFirstBill = id from Bill where idTable = @IdTable1  AND status =0
	IF(@idFirstBill IS NULl)
	BEGIN 
		INSERT Bill
		( DateCheckIn, DateCheckOut, idTable, status,UserName )
		VALUES 
		( GETDATE(), null, @IdTable1, 0, 'user' )
		SELECT @idFirstBill = Max(id) from Bill where idTable = @IdTable1  AND status =0
	END

	SELECT @idFirstBillEmpty = Count(*) from BillInfo WHERE idBill =@idFirstBill


	IF(@idSecondBill IS NULl)
	BEGIN 
		INSERT Bill
		(DateCheckIn, DateCheckOut, idTable, status, UserName )
		VALUES 
		( GETDATE(), null, @IdTable2, 0, 'user' )
		SELECT @idSecondBill = Max(id) from bill where idTable = @IdTable2 AND status =0
	END

	SELECT @idSecondBillEmpty = Count(*) from BillInfo WHERE idBill =@idSecondBill

	SELECT id into temp FROM BillInfo WHERE idBill = @idSecondBill
	Update BillInfo SET idBill = @idSecondBill WHERE idBill = @idFirstBill
	Update BillInfo SET idBill = @idFirstBill WHERE id IN (Select * from temp)
	select id from temp
	DROP TABLE temp
	IF(@idFirstBillEmpty = 0)
	UPDATE	TableFood SET status = N'Trống' WHERE id = @IdTable2
	IF(@idSecondBillEmpty = 0)
	UPDATE	TableFood SET status = N'Trống' WHERE id = @IdTable1
END
Go

select * from bill where idTable = 11
select * from bill where idTable = 5 
EXEC SwitchTable @idTable1 = 11, @idTable2 = 5
 
--------------------------------------------------------

CREATE PROC MergeTable
@IdTable1 int , @IdTable2 int
As Begin 
	Declare @idFirstBill int

	Declare @idSecondBill int

	Declare @idFirstBillEmpty int =1 

	Declare @idSecondBillEmpty int =1

	Select @idSecondBill = id from Bill where idTable = @IdTable2 AND status =0

	Select @idFirstBill = id from Bill where idTable = @IdTable1  AND status =0
	IF(@idFirstBill IS NULl)
	BEGIN 
		INSERT Bill
		( DateCheckIn, DateCheckOut, idTable, status,UserName )
		VALUES 
		( GETDATE(), null, @IdTable1, 0, 'user' )
		SELECT @idFirstBill = Max(id) from Bill where idTable = @IdTable1  AND status =0
	END

	SELECT @idFirstBillEmpty = Count(*) from BillInfo WHERE idBill =@idFirstBill


	IF(@idSecondBill IS NULl)
	BEGIN 
		INSERT Bill
		(DateCheckIn, DateCheckOut, idTable, status, UserName )
		VALUES 
		( GETDATE(), null, @IdTable2, 0, 'user' )
		SELECT @idSecondBill = Max(id) from bill where idTable = @IdTable2 AND status =0
	END

	SELECT @idSecondBillEmpty = Count(*) from BillInfo WHERE idBill =@idSecondBill

	SELECT id into temp FROM BillInfo WHERE idBill = @idSecondBill
	Update BillInfo SET idBill = @idSecondBill WHERE idBill = @idFirstBill
	Update BillInfo SET idBill = @idFirstBill WHERE id IN (Select * from temp)
	select id from temp
	DROP TABLE temp
	IF(@idFirstBillEmpty = 0)
	UPDATE	TableFood SET status = N'Trống' WHERE id = @IdTable2
	IF(@idSecondBillEmpty = 0)
	UPDATE	TableFood SET status = N'Trống' WHERE id = @IdTable1
END
Go