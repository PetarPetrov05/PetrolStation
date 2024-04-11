CREATE TABLE Delivery(
	id int IDENTITY,
	PRIMARY KEY(id),
	name_ nvarchar(35),
	mol nvarchar(35),
	adress nvarchar(35),
	bulstat nvarchar(35)
);

CREATE TABLE Gas(
	id INT IDENTITY,
	PRIMARY KEY(id),
	type_ nvarchar(35)
);
CREATE TABLE GasTank(
	id INT IDENTITY,
	PRIMARY KEY(id),
	name_ varchar(10)
);
CREATE TABLE Gas_GasTank(
	id int IDENTITY,
	PRIMARY KEY (id),
	gasId int,
	FOREIGN KEY (gasId) REFERENCES Gas(id),
	gasTankId int,
	FOREIGN KEY (gasTankId) REFERENCES GasTank(id)

);
CREATE TABLE AllDelivered(
	id int IDENTITY,
	PRIMARY KEY (id),
	gasId int,
	FOREIGN KEY (gasId) REFERENCES Gas(id),
	deliveryId int,
	FOREIGN KEY (deliveryId) REFERENCES Delivery(id),
	quantity int,
	gasTankId int,
	FOREIGN KEY (gasTankId) REFERENCES GasTank(id),
	registerPlate nvarchar(35),
	driver nvarchar(35)
);
ALTER TABLE AllDelivered
ADD price decimal(5,2);

CREATE TABLE Price(
	id int IDENTITY,
	PRIMARY KEY (id),
	type_ nvarchar(35),
	price decimal(10,2)
);

CREATE TABLE Sold_Gas(
	id int IDENTITY,
	PRIMARY KEY(id),
	quantity decimal(10,2),
	date_ dateTime,
	sold_price decimal(10,2),
	type_ nvarchar(35),
	pump nvarchar(35)
);
INSERT INTO Delivery (name_,mol,adress,bulstat) VALUES ('demea','materialno otgovorno lice','adress','bulstat');
SELECT * FROM Delivery;
INSERT INTO Delivery (name_, mol, adress, bulstat)
VALUES (N'Иван Иванов', N'Иванович', N'ул. Цветна 5', N'123456789');

SELECT name_ FROM Delivery;
SELECT name_ FROM Delivery;

INSERT INTO Gas (type_) VALUES (N'газ');
INSERT INTO GasTank (name_) Values (3);
INSERT INTO Gas_GasTank (gasId,gasTankId) values (2,2);

INSERT INTO AllDelivered (gasId,deliveryId,quantity,gasTankId,registerPlate,driver,price) 
VALUES (2,1,1000,2,N'B 3453 TX',N'Иван',1.54);
SELECT * FROM AllDelivered;

SELECT (id) FROM GAS where (type_ = N'газ');

CREATE TABLE Roles(
	id INT IDENTITY,
	PRIMARY KEY(id),
	role_ nvarchar(20)
);

INSERT INTO Roles (role_) 
Values ('admin');

Select * from Roles;

CREATE TABLE Accounts(
	id int IDENTITY,
	PRIMARY KEY(id),
	name_ nvarchar(20),
	password_ nvarchar(20),
	roleId int,
	FOREIGN KEY (roleId) REFERENCES Roles(id),
);

INSERT INTO Accounts (name_,password_,roleId) VALUES ('Stefan','user',1);

SELECT Accounts.name_,Accounts.password_,Roles.role_ FROM Accounts JOIN Roles on Accounts.roleId = Roles.id;

CREATE TABLE Cards(
	id int IDENTITY,
	name_ nvarchar(35),
	phone_num nvarchar(35),
	card_num nvarchar(35),
	barcode_path nvarchar(255)
);
INSERT INTO Cards (name_,phone_num,card_num,barcode_path) VALUES (N'Petar',N'0323221',N'23243421',N'D:\VisualStudio\Projects\Petrol_Station\Petrol_Station\bin\Debug\net6.0-windows\1554472944.png');
DROP TABLE Cards;
SELECT * FROM Cards;
SELECT * FROM GasTank;
Select * from AllDelivered;
sELECT * FROM Gas;
SELECT AllDelivered.gasId, Gas.type_,Delivery.name_,AllDelivered.quantity,AllDelivered.gasTankId,AllDelivered.registerPlate,AllDelivered.driver,AllDelivered.price FROM AllDelivered Join Gas on AllDelivered.gasId = Gas.id join Delivery on AllDelivered.deliveryId = Delivery.id;
SELECT * FROM AllDelivered Join Gas on AllDelivered.gasId = Gas.id join Delivery on AllDelivered.deliveryId = Delivery.id where Gas.type_ = N'бензин';
SELECT card_num from Cards;
Select * from Sold_Gas;
ALTER TABLE Sold_Gas add kasierId int;
ALTER TABLE Sold_Gas add constraint FK_KasierID_Sold_Gas Foreign key (kasierId) references Accounts(id);
SELECT * FROM AllDelivered;
ALTER TABLE GasTank add quantity decimal(10,2);
SELECT * FROM GasTank;
UPDATE GasTank SET quantity -=110 where name_ = 1;
UPDATE GasTank SET quantity =0 ;
SELECT quantity FROM AllDelivered where gasId = 3;
SELECT quantity from GasTank where name_ = 1;
SELECT quantity from GasTank where name_ = 2;

SELECT * FROM Sold_Gas;

INSERT INTO Sold_Gas (quantity,date_,sold_price,type_,pump,kasierId) VALUES (200,'2024-04-11 17:12:00',2.5,N'Бензин',1,1);

