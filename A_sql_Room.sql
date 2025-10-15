
SELECT * FROM Depatment;
Select * from employee;

-- Update --
UPDATE employee
set depid = 1 , 
    firsName = 'Paniti' , 
    lastName = 'jahem'
where empID = 'A001';

DELETE from employee
where empID = 'A001';

SELECT tenant_id, full_name FROM Tenant

GROUP BY total 




INSERT INTO Room (room_id, [floor], [status]) VALUES
('101', 1, 'Available'),
('102', 1, 'Occupied'),
('103', 1, 'Available'),
('201', 2, 'Available'),
('202', 2, 'Occupied'),
('203', 2, 'Available'),
('301', 3, 'Occupied'),
('302', 3, 'Available'),
('303', 3, 'Available'),
('304', 3, 'Occupied');



INSERT INTO Facility (facility_id, brand, model, price, received_date, [description], room_id, type_id)
VALUES
(1, 'Standard', 'Standard Room'),
(2, 'Deluxe', 'Deluxe Room'),
(3, 'Suite', 'Suite Room'),
(4, 'Single', 'Single Room'),
(5, 'Double', 'Double Room'),
(6, 'Family', 'Family Room'),
(7, 'Penthouse', 'Penthouse Room'),
(8, 'Economy', 'Economy Room'),
(9, 'Luxury', 'Luxury Room'),
(10, 'VIP', 'VIP Room');


INSERT INTO Facility (facility_id) VALUES
('001' ),
('002' ),
('003' );

INSERT INTO Facility (facility_id, brand, model, price, received_date, [description], room_id, type_id) VALUES
(1, 'Ikea', 'Sofa01', 12000.00, '2566-04-01', 'Sofa', 301, 2);

INSERT INTO FacilityType (type_id, type_name, [description]) VALUES
(4, 'Bathroom', 'Bathroom accessories'),
(5, 'Outdoor', 'Outdoor equipment'),
(6, 'Fitness', 'Fitness equipment'),
(7, 'Office', 'Office supplies'),
(8, 'Decor', 'Decorative items'),
(9, 'Lighting', 'Lighting fixtures'),
(10, 'Storage', 'Storage solutions');

SELECT rental_id, start_date, end_date FROM Rental;

SELECT payment_id, amount, payment_date, installment, [month], [year] FROM Payment;

SELECT facility_id, brand, model, price, received_date, [description], room_id, type_id FROM Facility;

SELECT type_id, type_name, [description] FROM FacilityType;


INSERT INTO Tenant (tenant_id, full_name, citizen_id, address, phone, birth_date, [description]) VALUES
('001', 'Somchai Jahem', '1234567890123', '123/45 Moo 6, Bangkok', '0812345678', '1990-01-01', 'No description');

INSERT INTO Rental (rental_id, start_date, end_date, tenant_id, room_id) VALUES
('011', '2023-02-01', '2024-01-31', '001', '101'),
('012', '2023-03-01', '2024-02-28', '002', '102'),
('013', '2023-04-01', '2024-03-31', '003', '103'),
('014', '2023-05-01', '2024-04-30', '004', '201'),
('015', '2023-06-01', '2024-05-31', '005', '202'),
('016', '2023-07-01', '2024-06-30', '006', '203'),
('017', '2023-08-01', '2024-07-31', '007', '301'),
('018', '2023-09-01', '2024-08-31', '008', '302'),
('019', '2023-10-01', '2024-09-30', '009', '303'),
('020', '2023-11-01', '2024-10-31', '010', '304');

SELECT tenant_id, full_name FROM Tenant;

SELECT * FROM Room;

SELECT 
    t.tenant_id,
    t.full_name,
    t.citizen_id,
    t.address,
    t.phone,
    t.birth_date,
    t.[description],
    r.room_id,
    r.floor,
    r.[status],
    p.payment_id,
    p.amount,
    p.payment_date,
    p.installment,
    p.[month],
    p.[year],
    f.facility_id,
    f.brand,
    f.model,
    f.price,
    f.received_date,
    f.[description],
    ft.type_id,
    ft.type_name,
    ft.[description]
FROM Tenant t
INNER JOIN Rental rn
    ON t.tenant_id = rn.tenant_id
INNER JOIN Room r
    ON rn.room_id = r.room_id
INNER JOIN Payment p
    ON rn.rental_id = p.rental_id
INNER JOIN Facility f
    ON r.room_id = f.room_id
INNER JOIN FacilityType ft
    ON f.type_id = ft.type_id;







DROP PROCEDURE AddRental
DROP PROCEDURE GetRentals
DROP PROCEDURE UpdateRental
DROP PROCEDURE DeleteRental
DROP 


CREATE PROCEDURE AddRental
    @rental_id INT,
    @start_date DATE,
    @end_date DATE,
    @tenant_id INT,
    @room_id INT
AS
BEGIN
    SET NOCOUNT ON;
    INSERT INTO Rental (rental_id, start_date, end_date, tenant_id, room_id)
    VALUES (@rental_id, @start_date, @end_date, @tenant_id, @room_id);
END
GO


CREATE PROCEDURE GetRentals
AS
BEGIN
    SET NOCOUNT ON;
    SELECT r.*, t.full_name, rm.floor
    FROM Rental r
    JOIN Tenant t ON r.tenant_id = t.tenant_id
    JOIN Room rm ON r.room_id = rm.room_id;
END
GO

CREATE PROCEDURE UpdateRental
    @rental_id INT,
    @start_date DATE,
    @end_date DATE,
    @tenant_id INT,
    @room_id INT
AS
BEGIN
    SET NOCOUNT ON;
    UPDATE Rental
    SET start_date = @start_date,
        end_date = @end_date,
        tenant_id = @tenant_id,
        room_id = @room_id
    WHERE rental_id = @rental_id;
END
GO

DROP PROCEDURE DeleteRental

CREATE PROCEDURE DeleteRental
    @rental_id INT
AS
BEGIN
    SET NOCOUNT ON;

    DECLARE @room_id INT;
    DECLARE @tenant_id INT;

    -- ดึงค่า room_id และ tenant_id ที่เชื่อมกับ rental_id นี้
    SELECT 
        @room_id = room_id,
        @tenant_id = tenant_id
    FROM Rental
    WHERE rental_id = @rental_id;

    -- 1️⃣ ลบ Payment ที่อ้างถึง Rental ก่อน
    DELETE FROM Payment WHERE rental_id = @rental_id;

    -- 2️⃣ ลบ Facility ที่อ้างถึง Room ก่อน (ถ้ามี)
    IF @room_id IS NOT NULL
        DELETE FROM Facility WHERE room_id = @room_id;

    -- 3️⃣ ลบ Rental
    DELETE FROM Rental WHERE rental_id = @rental_id;

    -- 4️⃣ ลบ Room ที่ไม่มีการใช้งานใน Rental อื่น
    IF @room_id IS NOT NULL AND NOT EXISTS (SELECT 1 FROM Rental WHERE room_id = @room_id)
        DELETE FROM Room WHERE room_id = @room_id;

    -- 5️⃣ ลบ Tenant ที่ไม่มีการเช่าใน Rental อื่น
    IF @tenant_id IS NOT NULL AND NOT EXISTS (SELECT 1 FROM Rental WHERE tenant_id = @tenant_id)
        DELETE FROM Tenant WHERE tenant_id = @tenant_id;
END
GO



CREATE PROCEDURE sp_DeleteTenant
    @tenant_id INT
AS
BEGIN
    SET NOCOUNT ON;

    -- ลบ Rental ก่อน (FK)
    DELETE FROM Rental
    WHERE tenant_id = @tenant_id;

    -- ลบ Tenant
    DELETE FROM Tenant
    WHERE tenant_id = @tenant_id;

    -- (ไม่ลบ Facility เพราะ Facility อยู่ตามห้อง ไม่เกี่ยวกับ Tenant)
END
GO







SELECT tenant_id, full_name, citizen_id,  FROM Tenant
SELECT payment_id, amount, payment_date, installment, [month], [year], rental_id FROM Payment;




DROP PROCEDURE sp_SearchTenantRoomStatus;

EXEC sp_SearchTenantRoomStatus
    @FullName = '1',
    @RoomId = NULL,
    @Status = 'NULL';

CREATE PROCEDURE sp_SearchTenantRoomStatus
    @FullName NVARCHAR(100) = NULL,
    @RoomId INT = NULL,
    @Status NVARCHAR(50) = NULL
AS
BEGIN
    SET NOCOUNT ON;

    SELECT 
        t.tenant_id,
        t.full_name,
        r.room_id,
        r.[status],
        r.floor
    FROM Tenant t
    INNER JOIN Rental rn
        ON t.tenant_id = rn.tenant_id
    INNER JOIN Room r
        ON rn.room_id = r.room_id
    WHERE (@FullName IS NULL OR t.full_name LIKE '%' + @FullName + '%')
      AND (@RoomId IS NULL OR r.room_id = @RoomId)
      AND (@Status IS NULL OR r.[status] = @Status)
END
GO







SELECT * FROM Facility




CREATE PROCEDURE sp_SearchTenantRoomStatus
    @FullName NVARCHAR(100) = NULL,
    @RoomId NVARCHAR(10) = NULL,
    @Status NVARCHAR(50) = NULL
AS
BEGIN
    SELECT 
        t.tenant_id,
        t.full_name,
        r.room_id,
        r.[status],
        r.floor
    FROM Tenant t
    INNER JOIN Rental rn
        ON t.tenant_id = rn.tenant_id
    INNER JOIN Room r
        ON rn.room_id = r.room_id
    WHERE (@FullName IS NULL OR t.full_name LIKE '%' + @FullName + '%')
      AND (@RoomId IS NULL OR r.room_id = @RoomId)
      AND (@Status IS NULL OR r.[status] = @Status)
END


sp_SearchTenantRoomStatus;

sp_GetTenantBasic


CREATE PROCEDURE sp_GetTenantBasic
AS
BEGIN
    SET NOCOUNT ON;

    SELECT 
        t.tenant_id,
        t.full_name,
        t.citizen_id,
        t.address,
        t.phone,
        t.birth_date,
        t.[description] AS t_description,
        ro.floor,
        ro.room_id,
        ro.[status] AS room_status,
        r.rental_id,
        r.start_date,
        r.end_date,
        f.facility_id,
        f.brand,
        f.model,
        f.price,
        f.received_date,
        f.[description] AS f_description,
        ft.type_id AS ft_type_id,
        ft.type_name,
        ft.[description] AS ft_description,
        p.payment_id,
        p.amount,
        p.payment_date,
        p.installment,
        p.[month] AS payment_month,
        p.[year] AS payment_year
    FROM Tenant t
    LEFT JOIN Rental r ON t.tenant_id = r.tenant_id
    LEFT JOIN Room ro ON r.room_id = ro.room_id
    LEFT JOIN Facility f ON ro.room_id = f.room_id
    LEFT JOIN FacilityType ft ON f.type_id = ft.type_id
    LEFT JOIN Payment p ON r.rental_id = p.rental_id;
END
GO

DROP PROCEDURE sp_GetTenantBasic;


SELECT room_id, [floor], [status] 
FROM Room

SELECT facility_id, brand, model, price, received_date, [description], room_id, type_id 
FROM Facility

SELECT type_id, type_name, [description] 
FROM FacilityType


SELECT tenant_id, full_name, citizen_id, address, phone, birth_date, [description]
FROM Tenant

SELECT rental_id, start_date, end_date, tenant_id, room_id 
FROM Rental

SELECT payment_id, amount, payment_date, installment, [month], [year], rental_id 
FROM Payment

CREATE PROCEDURE sp_SearchTenantRoomStatus
    @FullName NVARCHAR(100) = NULL,
    @RoomId NVARCHAR(10) = NULL,
    @Status NVARCHAR(50) = NULL
AS
BEGIN
    SELECT 
        t.tenant_id,
        t.full_name,
        r.room_id,
        r.[status],
        r.floor
    FROM Tenant t
    INNER JOIN Rental rn
        ON t.tenant_id = rn.tenant_id
    INNER JOIN Room r
        ON rn.room_id = r.room_id
    WHERE (@FullName IS NULL OR t.full_name LIKE '%' + @FullName + '%')
      AND (@RoomId IS NULL OR r.room_id = @RoomId)
      AND (@Status IS NULL OR r.[status] = @Status)
END



ALTER TABLE Tenant
DROP COLUMN tenant_id;

ALTER TABLE Tenant
ADD tenant_id INT IDENTITY(1,1) PRIMARY KEY;

-- ทำแบบเดียวกับ Rental และ Payment

-- Tenant
ALTER TABLE Tenant DROP COLUMN tenant_id;
ALTER TABLE Tenant ADD tenant_id INT IDENTITY(1,1) PRIMARY KEY;

-- Rental
ALTER TABLE Rental DROP COLUMN rental_id;
ALTER TABLE Rental ADD rental_id INT IDENTITY(1,1) PRIMARY KEY;

-- Payment
ALTER TABLE Payment DROP COLUMN payment_id;
ALTER TABLE Payment ADD payment_id INT IDENTITY(1,1) PRIMARY KEY;

DELETE FROM Room;

DELETE FROM Facility

SELECT * FROM Facility

SELECT * FROM Room;

EXEC sp_AddTenant
    @full_name = 'Test User',
    @phone = '0812345678',
    @address = '123 Test St, Bangkok',
    @citizen_id = '1234567890123',
    @birth_date = '1990-01-01',
    @description = 'New tenant',
    @type_id = 1,
    @floor = 1,
    @room_id = 101,
    @price = 15000.00;
-- Error Example --
    
Msg 515, Level 16, State 2, Procedure sp_AddTenant, Line 57
Cannot insert the value NULL into column 'brand', table 'apartment.dbo.Facility'; column does not allow nulls. INSERT fails.
Total execution time: 00:00:00.049

CREATE PROCEDURE sp_AddTenant
    @full_name NVARCHAR(100),
    @phone NVARCHAR(20),
    @address NVARCHAR(200),
    @citizen_id NVARCHAR(20),
    @birth_date DATE,
    @description NVARCHAR(MAX),
    @type_id INT,
    @floor INT,
    @room_id INT,
    @price DECIMAL(10,2)
AS
BEGIN
    SET NOCOUNT ON;

    BEGIN TRY
        BEGIN TRANSACTION;

        -- 1️⃣ Tenant
        DECLARE @tenant_id INT;
        SELECT @tenant_id = ISNULL(MAX(tenant_id), 0) + 1
        FROM Tenant WITH (TABLOCKX);

        INSERT INTO Tenant (tenant_id, full_name, phone, address, citizen_id, birth_date, [description])
        VALUES (@tenant_id, @full_name, @phone, @address, @citizen_id, @birth_date, @description);

        -- 2️⃣ Room (ถ้ายังไม่มี)
        IF NOT EXISTS (SELECT 1 FROM Room WHERE room_id = @room_id)
        BEGIN
            INSERT INTO Room (room_id, [floor], [status])
            VALUES (@room_id, @floor, N'มีผู้เช่า');
        END

        -- 3️⃣ Rental
        DECLARE @rental_id INT;
        SELECT @rental_id = ISNULL(MAX(rental_id), 0) + 1
        FROM Rental WITH (TABLOCKX);

        INSERT INTO Rental (rental_id, tenant_id, room_id, start_date, end_date)
        VALUES (@rental_id, @tenant_id, @room_id, GETDATE(), DATEADD(MONTH, 1, GETDATE()));

        -- 4️⃣ Facility
        IF EXISTS (SELECT 1 FROM Facility WHERE room_id = @room_id AND type_id = @type_id)
        BEGIN
            UPDATE Facility
            SET price = @price
            WHERE room_id = @room_id AND type_id = @type_id;
        END
        ELSE
        BEGIN
            DECLARE @facility_id INT;
            SELECT @facility_id = ISNULL(MAX(facility_id), 0) + 1
            FROM Facility WITH (TABLOCKX);

            INSERT INTO Facility (
                facility_id, room_id, type_id, price,
                brand, model, received_date, [description]
            )
            VALUES (
                @facility_id, @room_id, @type_id, @price,
                N'Brand', N'Model', GETDATE(), N'escription'
            );
        END

        -- 5️⃣ Payment
        DECLARE @payment_id INT;
        SELECT @payment_id = ISNULL(MAX(payment_id), 0) + 1
        FROM Payment WITH (TABLOCKX);

        INSERT INTO Payment (payment_id, rental_id, amount, payment_date, installment, [month], [year])
        VALUES (@payment_id, @rental_id, 0, GETDATE(), 1, MONTH(GETDATE()), YEAR(GETDATE()));

        COMMIT TRANSACTION;
    END TRY
    BEGIN CATCH
        ROLLBACK TRANSACTION;
        THROW;
    END CATCH
END
GO




DROP PROCEDURE sp_AddTenant;







DROP PROCEDURE sp_EditTenant

CREATE PROCEDURE sp_EditTenant
    @tenant_id INT,
    @full_name NVARCHAR(100),
    @phone NVARCHAR(20),
    @address NVARCHAR(200),
    @citizen_id NVARCHAR(20),
    @birth_date DATE,
    @description NVARCHAR(MAX),
    @type_id INT,
    @room_id INT,
    @price DECIMAL(10,2)
AS
BEGIN
    SET NOCOUNT ON;

    -- ตรวจสอบค่าหลัก ๆ ว่าไม่เป็น Null
    IF @full_name IS NULL OR @phone IS NULL OR @address IS NULL OR @citizen_id IS NULL
    BEGIN
        RAISERROR('กรุณากรอกข้อมูลทั้งหมดให้ครบ', 16, 1);
        RETURN;
    END

    -- อัปเดต Tenant
    UPDATE Tenant
    SET full_name = @full_name,
        phone = @phone,
        address = @address,
        citizen_id = @citizen_id,
        birth_date = @birth_date,
        [description] = @description
    WHERE tenant_id = @tenant_id;

    -- อัปเดต Rental
    UPDATE Rental
    SET room_id = @room_id,
        start_date = GETDATE(),  -- อัปเดตวันที่ล่าสุด
        end_date = GETDATE()
    WHERE tenant_id = @tenant_id;

    -- อัปเดตราคา Facility ของห้องนั้น
    UPDATE Facility
    SET price = @price
    WHERE room_id = @room_id AND type_id = @type_id;
END
GO




SELECT payment_id, amount, payment_date, installment, [month], [year] FROM Payment;



CREATE PROCEDURE sp_DeleteTenant
    @tenant_id INT
AS
BEGIN
    SET NOCOUNT ON;

    -- ลบ Rental ก่อน (FK)
    DELETE FROM Rental
    WHERE tenant_id = @tenant_id;

    -- ลบ Tenant
    DELETE FROM Tenant
    WHERE tenant_id = @tenant_id;

    -- (ไม่ลบ Facility เพราะ Facility อยู่ตามห้อง ไม่เกี่ยวกับ Tenant)
END
GO






-- เพิ่ม Payment
DROP PROCEDURE sp_AddPayment

CREATE PROCEDURE sp_AddPayment
    @rental_id INT,
    @payment_id INT = NULL,          -- ให้กำหนดเองหรือคำนวณ MAX+1
    @amount DECIMAL(10,2) = 0,
    @installment INT = 1,
    @month INT = NULL,
    @year INT = NULL
AS
BEGIN
    SET NOCOUNT ON;

    -- ตรวจสอบว่า rental_id มีอยู่จริง
    IF NOT EXISTS (SELECT 1 FROM Rental WHERE rental_id = @rental_id)
    BEGIN
        RAISERROR('rental_id ไม่พบในตาราง Rental', 16, 1);
        RETURN;
    END

    -- ถ้าไม่ได้กำหนด payment_id ให้คำนวณ MAX+1
    IF @payment_id IS NULL
        SELECT @payment_id = ISNULL(MAX(payment_id),0)+1 FROM Payment WITH(TABLOCKX);

    INSERT INTO Payment(payment_id, rental_id, amount, payment_date, installment, [month], [year])
    VALUES(
        @payment_id,
        @rental_id,
        @amount,
        GETDATE(),
        @installment,
        ISNULL(@month, MONTH(GETDATE())),
        ISNULL(@year, YEAR(GETDATE()))
    );
END
GO




ALTER PROCEDURE sp_EditPayment
    @payment_id INT,
    @amount DECIMAL(10,2),
    @installment INT,
    @month INT = NULL,
    @year INT = NULL
AS
BEGIN
    SET NOCOUNT ON;

    UPDATE Payment
    SET amount = @amount,
        installment = @installment,
        [month] = ISNULL(@month, MONTH(GETDATE())),
        [year] = ISNULL(@year, YEAR(GETDATE()))
    WHERE payment_id = @payment_id;
END
GO




-- ลบ Payment
CREATE PROCEDURE sp_DeletePayment
    @payment_id INT
AS
BEGIN
    DELETE FROM Payment WHERE payment_id = @payment_id;
END
GO














































































1	Somchai Jahem	1234567890123	123/45 Moo 6, Bangkok	0812345678	2533-01-01	No description	1	101	1
1	Somchai Jahem	1234567890123	123/45 Moo 6, Bangkok	0812345678	2533-01-01	No description	1	101	2
2	Somsak Lim	2345678901234	234/56 Moo 7, Bangkok	0812345679	2534-02-02	No description	1	102	1
2	Somsak Lim	2345678901234	234/56 Moo 7, Bangkok	0812345679	2534-02-02	No description	1	102	2
3	Somnuk Phan	3456789012345	345/67 Moo 8, Bangkok	0812345680	2535-03-03	No description	1	103	1
3	Somnuk Phan	3456789012345	345/67 Moo 8, Bangkok	0812345680	2535-03-03	No description	1	103	3
4	Somying Jai	4567890123456	456/78 Moo 9, Bangkok	0812345681	2536-04-04	No description	2	201	3
4	Somying Jai	4567890123456	456/78 Moo 9, Bangkok	0812345681	2536-04-04	No description	2	201	1
5	Sompong Tan	5678901234567	567/89 Moo 10, Bangkok	0812345682	2537-05-05	No description	2	202	3
6	Somboon Lek	6789012345678	678/90 Moo 11, Bangkok	0812345683	2538-06-06	No description	2	203	3
7	Somchai Lek	7890123456789	789/01 Moo 12, Bangkok	0812345684	2539-07-07	No description	3	301	NULL
8	Somsri Nam	8901234567890	890/12 Moo 13, Bangkok	0812345685	2540-08-08	No description	3	302	NULL
9	Somjai Mai	9012345678901	901/23 Moo 14, Bangkok	0812345686	2541-09-09	No description	3	303	NULL
10	Somnuek Rak	0123456789012	012/34 Moo 15, Bangkok	0812345687	2542-10-10	No description	3	304	NULL
sp_GetTenantBasic;



SELECT * FROM Room
SELECT * FROM Facility;
SELECT * FROM FacilityType;
SELECT * FROM Tenant;
SELECT * FROM Rental;
SELECT * FROM Payment;

DROP SELECT * FROM Room;


SELECT room_id, [floor], [status] FROM Room;
101	1	ว่าง
102	1	มีผู้เช่า
103	1	ว่าง
201	2	ว่าง
202	2	มีผู้เช่า
203	2	ว่าง
301	3	ว่าง
302	3	มีผู้เช่า
303	3	ว่าง
304	3	ว่าง


INSERT INTO Tenant (tenant_id, full_name, citizen_id, address, phone, birth_date, [description]) VALUES
('002', 'Somsak Lim', '2345678901234', '234/56 Moo 7, Bangkok', '0812345679', '1991-02-02', 'No description'),
('003', 'Somnuk Phan', '3456789012345', '345/67 Moo 8, Bangkok', '0812345680', '1992-03-03', 'No description'),
('004', 'Somying Jai', '4567890123456', '456/78 Moo 9, Bangkok', '0812345681', '1993-04-04', 'No description'),
('005', 'Sompong Tan', '5678901234567', '567/89 Moo 10, Bangkok', '0812345682', '1994-05-05', 'No description'),
('006', 'Somboon Lek', '6789012345678', '678/90 Moo 11, Bangkok', '0812345683', '1995-06-06', 'No description'),
('007', 'Somchai Lek', '7890123456789', '789/01 Moo 12, Bangkok', '0812345684', '1996-07-07', 'No description'),
('008', 'Somsri Nam', '8901234567890', '890/12 Moo 13, Bangkok', '0812345685', '1997-08-08', 'No description'),
('009', 'Somjai Mai', '9012345678901', '901/23 Moo 14, Bangkok', '0812345686', '1998-09-09', 'No description'),
('010', 'Somnuek Rak', '0123456789012', '012/34 Moo 15, Bangkok', '0812345687', '1999-10-10', 'No description');


SELECT * FROM Tenant;


SELECT rental_id, start_date, end_date, tenant_id, room_id 
FROM Rental

INSERT INTO Rental (rental_id, start_date, end_date, tenant_id, room_id ) VALUES
('002', '2023-03-01', '2024-02-28', '002', '102'),
('003', '2023-04-01', '2024-03-31', '003', '103'),
('004', '2023-05-01', '2024-04-30', '004', '201'),
('005', '2023-06-01', '2024-05-31', '005', '202'),
('006', '2023-07-01', '2024-06-30', '006', '203'),
('007', '2023-08-01', '2024-07-31', '007', '301'),
('008', '2023-09-01', '2024-08-31', '008', '302'),
('009', '2023-10-01', '2024-09-30', '009', '303'),
('010', '2023-11-01', '2024-10-31', '010', '304');

SELECT payment_id, amount, payment_date, installment, [month], [year], rental_id 
FROM Payment;

INSERT INTO Payment (payment_id, amount, payment_date, installment, [month], [year], rental_id) VALUES
('001', 12000.00, '2023-02-05', 1, 2, 2023, '001'),
('002', 12000.00, '2023-03-05', 2, 3, 2023, '002'),
('003', 12000.00, '2023-04-05', 3, 4, 2023, '003'),
('004', 12000.00, '2023-05-05', 4, 5, 2023, '004'),
('005', 12000.00, '2023-06-05', 5, 6, 2023, '005'),
('006', 12000.00, '2023-07-05', 6, 7, 2023, '006'),
('007', 12000.00, '2023-08-05', 7, 8, 2023, '007'),
('008', 12000.00, '2023-09-05', 8, 9, 2023, '008'),
('009', 12000.00, '2023-10-05', 9, 10, 2023, '009'),
('010', 12000.00, '2023-11-05', 10, 11, 2023,'010');

DELETE FROM Payment;

     /*
   Databass STORED PROCEDURES 

Relational Schema:

ห้องพัก(รหัสห้อง ชั้น สถานะห้อง)
อุปหารณ์ทำนายความสพดวก(รหะสอุปกรณ์ ยี่ห้อ รุ่น ราคา วันที่ วันที่รับมา ข้อมูลอื่นๆ รหัสห้อง รหัสประเภทห้อง)
ประเภทห้อง(รหัสประเภทห้อง ชื่อประเภทห้อง ข้อมูลอื่นๆ)
ผู้เช่า(รหัสผู้เช่า ชื่อ-นามสกุล ที่อยู่ทะเบียนบ้าน เบอร์โทรศัพท์ วันเกิด ข้อมูลอื่นๆ)
การาเช่า(รหัสสัญญา วันที่เริ่มเช่า วันที่สิ้นสุด รหัสผู้เช่า รหัสห้อง)
การชำระเงิน(รหัสการชำระเงิน วันที่ชำระเงิน จำนวนเงิน งวดที่ งวดเดือน ปี รหัสการเช่า)

Data Sictionary:
Table name      Attribute name      Description     DataType        Size        Key     Null        Reference

ห้องพัก           room_id             รหัสห้อง           int             5          PK      Not null          -
Room            floor               ชั้น              int             5         -       Not null          -
                room_status         สถานะห้อง         varchar         50          -       Not null          -

Facility        facility_id         รหะสอุปกรณ์        int            5          PK      Not null          -
                brand               ยี่ห้อ              varchar        50         -       Not null          -
                model               รุ่น               varchar        50         -       Not null          -
                price               ราคา             float           10,2          -       Not null          -
                purchase_date       วันที่รับมา          date            -          -       Not null          -
                other                ข้อมูลอื่นๆ          text            -          -       Null              -
                room_id             รหัสห้อง           int             5          FK      Not null          ห้องพัก(room_id)
                room_type_id        รหัสประเภทห้อง      int             5          FK      Not null          ประเภทห้อง(room_type_id)

FacilityType    room_type_id        รหัสประเภทห้อง      int             5          PK      Not null          -
                room_type_name      ชื่อประเภทห้อง      varchar         50          -       Not null          -
                other                ข้อมูลอื่นๆ          text            -          -       Null              -

Tenant          tenant_id           รหัสผู้เช่า         int             5          PK      Not null          -
                full_name           ชื่อ-นามสกุล       varchar         100         -       Not null          -
                Citizen_id          หมายเลขประจำตัวประชาชน varchar      13         -       Not null          -
                address             ที่อยู่ทะเบียนบ้าน   text            -          -       Not null          -
                phone_number        เบอร์โทรศัพท์      varchar         20         -       Not null          -
                birth_date          วันเกิด           date            -          -       Not null          -
                other                ข้อมูลอื่นๆ          text            -          -       Null              -

Rontal         rental_id           รหัสสัญญา         int             5          PK      Not null          -
                start_date          วันที่เริ่มเช่า       date            -          -       Not null          -
                end_date            วันที่สิ้นสุด        date            -          -       Not null          -
                tenant_id           รหัสผู้เช่า         int             5          FK      Not null          ผู้เช่า(tenant_id)
                room_id             รหัสห้อง           int             5          FK      Not null          ห้องพัก(room_id)

Payment        payment_id          รหัสการชำระเงิน     int             5          PK      Not null          -
                payment_date        วันที่ชำระเงิน       date            -          -       Not null          -
                amount              จำนวนเงิน           float           -          -       Not null          -
                installment         งวดที่              int             5          -       Not null          -
                installment_month   งวดเดือน           varchar         20         -       Not null          -
                installment_year    ปี                 int             5          -       Not null          -
                rental_id           รหัสการเช่า         int             5          FK      Not null          การาเช่า(rental_id)


 */