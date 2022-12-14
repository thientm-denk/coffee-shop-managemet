USE [master]
GO

CREATE DATABASE CoffeeShop
GO
USE CoffeeShop

CREATE TABLE DrinkTypes(
	[typeId] [int] IDENTITY(1,1) NOT NULL primary key,
	[Name] [nvarchar](50) NOT NULL,
 )
 CREATE TABLE Drinks(
	[drinkId] [int] IDENTITY(1,1) NOT NULL primary key,
	[typeId] [int] NOT NULL FOREIGN KEY REFERENCES DrinkTypes(typeId),
	[name] [nvarchar](50) NOT NULL,
	[price] [bigint] NOT NULL,
	)
CREATE TABLE Users(
	[userId] [int] IDENTITY(1,1) NOT NULL primary key,
	[Name] [nvarchar](50) NOT NULL,
	[password] [nvarchar](20) NOT NULL,
	[role] [nvarchar](10) NOT NULL,
)
CREATE TABLE Shifts(
	[shiftId] [int] IDENTITY(1,1) NOT NULL primary key,
	[shiftName] [nvarchar](30) NOT NULL,
	)
CREATE TABLE ShiftDetails(
	[shiftDetailsId] [int] IDENTITY(1,1) NOT NULL primary key,
	[userId] int NOT NULL FOREIGN KEY REFERENCES Users(userId),
	[shiftId] [int] NOT NULL FOREIGN KEY REFERENCES Shifts(shiftId),
	[date][date] NOT NULL,
	[openWallet] [bigint] NOT NULL,
	[closeWallet] [bigint] NOT NULL
)

CREATE TABLE Orders(
	[orderId] [int] IDENTITY(1,1) NOT NULL primary key,
	[shiftId] [int] NOT NULL FOREIGN KEY REFERENCES ShiftDetails(shiftDetailsId),
	[time] [time] NOT NULL,
	[date] [date] NOT NULL,
	[price] [bigint] NOT NULL,
)
CREATE TABLE Vouchers(
	[voucherId] [int] IDENTITY(0,1) NOT NULL primary key,
	[SaleRate] [int] NOT NULL,
	[Status] [nvarchar](20) NOT NULL,
	)
	CREATE TABLE OrderDetails(
	[orderDetailsId][int] IDENTITY(1,1) NOT NULL primary key,
	[orderId] [int] NOT NULL FOREIGN KEY REFERENCES Orders(orderId),
	[drinkId] [int] NOT NULL FOREIGN KEY REFERENCES Drinks(drinkId),
	[quantity] [int] NOT NULL,
	[vocherId] [int] FOREIGN KEY REFERENCES Vouchers(voucherId)
)

insert into DrinkTypes(Name)
values('coffee'),
      ('milktea'),
	  ('smoothie'),
	  ('juice'),
	  ('tea'),
	  ('freeze')

insert into Drinks(typeId, name, price)
values(1,'Black coffee',20000),
      (1,'Milk coffee',23000),
	  (1,'Espresso',20000),
	  (1,'Americano',20000),
	  (2,'Traditional milktea',35000),
	  (2,'Matcha milktea',35000),
	  (3,'Mango smoothie',30000),
	  (3,'Avocado smootie',35000),
	  (4,'Orange juice',25000),
	  (4,'Apple juice',25000),
	  (4,'Carrot juice',30000),
	  (5,'Ginger tea',20000),
	  (6,'Matcha freeze',40000),
	  (6,'Chocolate freeze',40000)

insert into Vouchers(SaleRate, Status)
values(0,''),
      (30,'big deal'),
	  (50,'super deal')

insert into Users(Name, password, role)
values('MinhThien','123456','MA'),
      ('ThanhBo','123456','EM'),
	  ('MinhDang','123456','EM'),
	  ('KhoiNguyen','123456','EM')

insert into Shifts(shiftName)
values('morning'),
      ('afternoon'),
	  ('evening')

insert into ShiftDetails(userId, shiftId, date, openWallet, closeWallet)
values(2,1,'10/14/2022', 1000000, 1500000),
      (3,2,'10/14/2022', 1500000, 2000000),
	  (4,3,'10/14/2022', 2000000, 300000)

insert into Orders(shiftId, time,date, price)
values(1,'8:20','10/30/2022',200000),
      (1,'9:00','10/30/2022',300000),
	  (2,'12:00','10/30/2022',500000),
	  (3,'20:00','10/30/2022',1000000)

insert into OrderDetails(orderId, drinkId, quantity, vocherId)
values(1,1,5,1),
      (1,2,2,null)



SET IDENTITY_INSERT Users off;