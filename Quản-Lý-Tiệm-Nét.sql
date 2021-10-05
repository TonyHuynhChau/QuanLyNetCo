--drop database QuanLyPhongNet
CREATE DATABASE Net
GO	

USE Net
GO	


--ACCOUNT
--MAY
--LOAIMAY
--FOOD
--FOODFOODCATEGORY
--BILL
--BILLINFO


CREATE TABLE GruopACCOUNT
(
	GroupUser INT identity NOT NULL PRIMARY KEY,
    GroupName NVARCHAR(100)
)
GO

--ACCOUNT
CREATE TABLE ACCOUNT
(
  	ID int identity  primary key,
	AccountName varchar(30),
	Password varchar(30),
	UserName nvarchar(60),
	Sex nvarchar(30),
	GroupUser INT REFERENCES GruopACCOUNT(GroupUser) ,
	PhoneNumber varchar(11),
	Email varchar(100)
)
GO

--MAY
CREATE TABLE MAY
(	
  ID INT IDENTITY PRIMARY KEY ,
  NAME NVARCHAR(100) NOT NULL DEFAULT N'Chưa Đặt Tên',
  STATUS NVARCHAR(100) NOT NULL DEFAULT N'Trống',  --1:CO NGUOI / 0: TRONG   
)

GO

--FOODFOODCATEGORY

CREATE TABLE FOODCATEGORY
(
  ID INT IDENTITY PRIMARY KEY , 
  NAME NVARCHAR(100)  NOT NULL
)
GO

--FOOD

CREATE TABLE Food
(
    FoodID int identity(1,001) primary key,
	FoodName nvarchar(100),
	idFOODCATEGORY INT references FOODCATEGORY(ID),
	PriceUnit float,
	UnitLot nvarchar(100),
	InventoryNumber int,
)
GO

--BILL

CREATE TABLE BILL
(
  ID INT IDENTITY PRIMARY KEY , 
  DATECHECKIN DATETIME NOT NULL DEFAULT GETDATE() ,
  DATECHECKOUT DATETIME, 
  IDMAY INT NOT NULL,
  STATUS INT NOT NULL DEFAULT 0 -- 1:Đ? THANH TOÁN / 0: CHƯA THANH TOÁN  

  FOREIGN KEY (IDMAY) REFERENCES dbo.MAY(ID),
)
GO

--BILLINFO

CREATE TABLE BILLINFO
(
  ID INT IDENTITY PRIMARY KEY, 
  IDBILL INT NOT NULL,
  FoodID INT NOT NULL,
  COUNT	INT	NOT NULL DEFAULT 0 
  
  FOREIGN KEY (IDBILL) REFERENCES dbo.BILL(ID),
  FOREIGN KEY (FoodID) REFERENCES dbo.Food(FoodID)
)

CREATE TABLE BILLMonney
(
	ID INT IDENTITY PRIMARY KEY, 
	IDMAY INT ,
	IDBILL INT ,
	PriceTime FLOAT,
    PriceFodd FLOAT,
    TotalPrice FLOAT,
	Usetime VARCHAR(30),
	
	FOREIGN KEY (IDBILL) REFERENCES dbo.BILL(ID),
	FOREIGN KEY (IDMAY) REFERENCES dbo.MAY(ID)
)

--GroupAccount
INSERT INTO GruopACCOUNT(GroupName)VALUES(N'Quản Lý')
INSERT INTO GruopACCOUNT(GroupName)VALUES(N'Thường')

 
--ACCOUNT
insert into ACCOUNT values ('Kiezet','12',N'Anh Kiệt',N'Nam',1,'0123456789','Kiezet@gmail.com')


--FOODCATEGORY
insert into FOODCATEGORY values(N'Mì gói')
insert into FOODCATEGORY values(N'Cơm')
insert into FOODCATEGORY values(N'Phở')
insert into FOODCATEGORY values(N'Bún')
insert into FOODCATEGORY values(N'Nước Ngọt')
insert into FOODCATEGORY values(N'Trà')
insert into FOODCATEGORY values(N'Bia')
GO


--Food
insert into Food values (N'Mì xào trứng',1,10000,N'Dĩa',15)
insert into Food values (N'Mì xào bò',1,15000,N'Dĩa',20)
insert into Food values (N'Mì xào bò trứng',1,20000,N'Dĩa',11)
insert into Food values (N'Cơm chiên trứng',2,12000,N'Dĩa',12)
insert into Food values (N'Cơm chiên thịt heo',2,15000,N'Dĩa',14)
insert into Food values (N'Cơm xào bò',2,20000,N'Dĩa',16)
insert into Food values (N'Bún xào',4,12000,N'Dĩa',13)
insert into Food values (N'Phở gà',3,20000,N'Tô',8)
insert into Food values (N'Phở bò',3,22000,N'Tô',6)
insert into Food values (N'7 UP',5,10000,N'Chai',35)
insert into Food values (N'Pepsi',5,10000,N'Chai',25)
insert into Food values (N'Coca',5,10000,N'Chai',40)
insert into Food values (N'Trà xanh không độ',6,12000,N'Chai',21)
insert into Food values (N'C2',6,8000,N'Chai',32)
insert into Food values (N'Fanta',5,10000,N'Chai',22)
insert into Food values (N'Mirinda xá xị',5,10000,N'Chai',20)
insert into Food values (N'Rồng Đỏ',5,10000,N'Hủ',45)
insert into Food values (N'STING dâu',5,10000,N'Chai',48)
insert into Food values (N'STING dâu',5,12000,N'Lon',35)
insert into Food values (N'STING vàng',5,12000,N'Chai',47)
insert into Food values (N'RED BULL',5,12000,N'Lon',50)
insert into Food values (N'Trà Đá',6,12000,N'Ly',100)
insert into Food values (N'Trà Đá ca',6,12000,N'Ca',100)
insert into Food values (N'Bia Tiger',7,15000,N'Lon',42)
GO

--MAY
insert into MAY values ('MAYVIP-1',N'Trống')
insert into MAY values ('MAYVIP-2',N'Trống')
insert into MAY values ('MAYVIP-3',N'Trống')
insert into MAY values ('MAYVIP-4',N'Trống')
insert into MAY values ('MAYVIP-5',N'Trống')
insert into MAY values ('MAYVIP-6',N'Trống')
insert into MAY values ('MAYVIP-7',N'Trống')
insert into MAY values ('MAYVIP-8',N'Trống')
insert into MAY values ('MAYVIP-9',N'Trống')
insert into MAY values ('MAYVIP-10',N'Trống')
GO


CREATE PROC USP_Login
@userName nvarchar(100), @passWord nvarchar(100)
AS
BEGIN
	SELECT * FROM dbo.ACCOUNT WHERE AccountName = @userName AND PassWord = @passWord
END
GO


CREATE PROC USP_GetComputerList
as select *FROM MAY 
GO

Exec dbo.USP_GetComputerList
go


CREATE PROC USP_InsertBill
@ClientID INT
AS
BEGIN
	INSERT INTO Bill
	(
		DateCheckIn,
		DateCheckOut,
		IDMAY,
		[status]
	)
	VALUES
	(
		GETDATE(),
		NULL,
		@ClientID,
		0
	)
END
GO

CREATE	PROC USP_InsertBillinfo
@BillID INT, @MenuID INT, @count INT
AS
BEGIN
	
	DECLARE @BillExits INT;
	DECLARE @F_DCount INT = 0;
		
	
    SELECT @BillExits = IDBILL, @F_DCount= count
      FROM BillInfo WHERE IDBILL=@BillID AND FoodID=@MenuID
    
	IF(@BillExits > 0)
	BEGIN	  
	    DECLARE @new INT = @F_DCount + @count
	    IF(@new > 0)
	       UPDATE BillInfo SET count =@F_DCount + @count WHERE IDBILL=@BillID AND FoodID=@MenuID
	    ELSE
	    	DELETE dbo.BillInfo WHERE IDBILL=@BillID AND FoodID=@MenuID 
	END
	ELSE
      BEGIN	
	   INSERT	dbo.BillInfo
        ( IDBILL, FoodID, count )
        VALUES 
        ( @BillID, 
          @MenuID,
          @count 
        )         

      END   
END
GO

CREATE TRIGGER UTG_UpdateBillInfo
ON dbo.BILLINFO FOR INSERT ,UPDATE
AS
BEGIN
	DECLARE @idBill INT
	
    SELECT @idBill = IDBILL FROM INSERTED
    
    DECLARE @idComputer INT	
    
    SELECT @idComputer=IDMAY FROM BILL AS b WHERE id =@idBill AND b.[STATUS] = 0
    
    UPDATE MAY SET [STATUS] = N'Có Người' WHERE id = @idComputer
    	
END
GO

CREATE TRIGGER UTG_UpdateBill
ON dbo.BILL FOR UPDATE
AS
BEGIN
	DECLARE @idBill INT
	
	SELECT @idBill =id FROM INSERTED
		
    DECLARE @idComputer INT	
    
    SELECT @idComputer=IDMAY FROM BILL AS b WHERE  b.ID =@idBill
    
    DECLARE @count INT = 0
    
    SELECT @count =COUNT(*) FROM BILL AS b WHERE b.IDMAY =@idComputer AND b.[STATUS] = 0
    
    IF(@count = 0)
       UPDATE MAY SET [STATUS] = N'Trống' WHERE id = @idComputer
      
END
GO

CREATE PROC USP_InsertMonneyTime
@IDmay INT  , @idBill INT , @priceTime INT ,@priceFodd INT , @totalPrice INT , @Usetime TIME
AS
BEGIN
INSERT INTO BILLMonney
(
	-- ID -- this column value is auto-generated
	IDMAY,
	IDBILL,
	PriceTime,
	PriceFodd,
	TotalPrice,
	Usetime
)
VALUES
(
	@IDmay,
	@idBill,
	@priceTime,
	@priceFodd,
	@totalPrice,
	@Usetime
)
END
GO

CREATE PROC USP_GetListBill 
@checkIn NVARCHAR(100) , @checkOut  NVARCHAR(100)
AS
BEGIN
     SELECT m.NAME, b.PriceTime,b.PriceFodd,b.TotalPrice,b.Usetime ,CONVERT(VARCHAR(30),b2.DATECHECKIN,103) AS N'Ngày Giờ Vào',CONVERT(VARCHAR(30),b2.DATECHECKOUT,103)AS N'Ngày Giờ Ra'
     FROM BILLMonney AS b,MAY AS m,BILL AS b2
     WHERE m.ID=b.IDMAY AND b2.ID=b.IDBILL AND CONVERT(VARCHAR(30),b2.DATECHECKIN,103) >= @checkIn AND CONVERT(VARCHAR(30),b2.DATECHECKOUT,103) <=@checkOut
END
GO


CREATE PROC USP_GetListBill2 
AS
BEGIN
    SELECT m.NAME, b.PriceTime,b.PriceFodd,b.TotalPrice,b.Usetime ,b2.DATECHECKIN,b2.DATECHECKOUT FROM BILLMonney AS b,MAY AS m,BILL AS b2 WHERE m.ID=b.IDMAY AND b2.ID=b.IDBILL 
END
GO


CREATE PROC USP_GetListBill3 
AS
BEGIN
	SELECT f.FoodID, f.FoodName,f2.NAME,f.PriceUnit,f.UnitLot,f.InventoryNumber FROM Food AS f,FOODCATEGORY AS f2 WHERE f2.ID=f.idFOODCATEGORY
END
GO

CREATE PROC USP_GetNV
AS
BEGIN
	SELECT a.AccountName,a.[Password],a.UserName,a.Sex,ga.GroupName,a.PhoneNumber,a.Email  FROM ACCOUNT AS a, GruopACCOUNT AS ga WHERE ga.GroupUser=a.GroupUser
END
GO
