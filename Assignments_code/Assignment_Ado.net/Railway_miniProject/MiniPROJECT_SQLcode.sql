 create database MiniProject
 use miniproject

 --------------------------------------------------------------------------------------------------------------------------
CREATE TABLE train (
    trainID int primary key,
    trainName varchar(50),
    Source varchar(50),
    Destination varchar(50),
    Status char(1) check (status IN ('Y', 'N'))
);
select*from train
-------------------------------------------------------------------------------------------------------------------------
create table Booking (
    BookingID int identity(1,1)  primary key,
    TrainID int,
    UserName varchar(50),
    berthType VARCHAR(50),
    Totaltickets int,
    BookingStatus CHAR(1) CHECK (BookingStatus IN ('Y', 'N')),
    payment_amount DECIMAL(10, 2),
    FOREIGN KEY (TrainID) REFERENCES train(TrainID),
    
);

select*from Booking	
-------------------------------------------------------------------------------------------------------
CREATE TABLE CancelTicket (
    CancelTicketID int identity(1,1) PRIMARY KEY,
    BookingID int,
    RefundAmount DECIMAL(10, 2),
    CancelDate DATETIME DEFAULT GETDATE(),
    foreign key (BookingID) references Booking(BookingID)
);
------------------------------------------------------------------------------------------------------------------

-- user table
CREATE TABLE UserPer(
    UserID int primary key,
    UserName VARCHAR(50),
    Password VARCHAR(50)
);
------------------------------------------------------------------------------------------------------
--  admin table
CREATE TABLE Admin (
    AdminID int primary key,
    Username VARCHAR(50),
    Password VARCHAR(50)
);
----------------------------------------------------------------------------------------------------
-- trainbirthinfo table
CREATE TABLE TrainBerthInfo (
    TrainBirthID int  IDENTITY(1,1) primary key,
    TrainID int,
    BerthClass VARCHAR(50),
    TotalSeats int,
    AvailableSeats int,
    price DECIMAL(10, 2),
    FOREIGN KEY (TrainID) REFERENCES train(TrainID)
);


--------------------------------------------------------------------------------------------------
insert into admin values (1,'Admin','1234'
);
insert into userper values (1,'User','1111'
);
-----------------------------------------------------------------------------------------------
--procedure for add a train

create or alter proc AddTrain
@TrainID int,
@TrainName VARCHAR(50),
@Source VARCHAR(50),
@Destination VARCHAR(50)
as
begin
    insert into Train (trainID,trainName, Source, Destination, Status)
    values(@TrainID ,@TrainName, @Source, @Destination, 'Y'); -- Assuming 'Y' indicates active status
end	



select*from train



-------------------------------------------------------------------------------------------

--procedure for updation a train or modify

create or alter proc ModifyTrain
@TrainID INT,@TrainName varchar(50) ,@Source varchar(50),
 @Destination VARCHAR(50)
as
  begin
    update Train set TrainName = @TrainName,Source = @Source, Destination = @Destination where TrainID = @TrainID;
end

exec ModifyTrain
 @TrainID=11222,@TrainName='Sabarmati Express',@Source='Chennai',@Destination='Ayodhya';

 -----------------------------------------------------------------------------------------------------
 -- Procedure to soft delete a train (set  status(N) to inactive)
create or alter proc SoftDeleteTrain @TrainID int
as
 begin
    update Train set Status = 'N' where TrainID = @TrainID;
end
go
 
 ----------------------------------------------------------------------------------------------

create or alter proc ChangeTrainStatus @TrainID int
as
begin
    update Train set 
	status = CASE 
                    WHEN Status = 'Y' THEN 'N'
                    WHEN Status = 'N' THEN 'Y'
                    ELSE Status
     end
    where TrainID = @TrainID;
end


select*from train
--to view only that particuler train on which any activity has been done
---------------------------------------------------------------------------------------------------

create or alter proc ViewTrainStatus
@TrainID INT
as 
begin
    select*from train where trainID=@TrainID;
END


EXEc ViewTrainStatus @TrainID=11222;
----------------------------------------------------------------------------------------------------
--proc  for  show  all the  trains

create or alter proc ShowAllTrain 
as 
begin
    select * from train;
END
exec ShowAllTrain;
--------------------------------------------------------------------------------------------------

create or alter proc AddTrainBerthInfo
    @TrainID int,
    @BerthClass varchar(50),
    @TotalSeats int,
    @AvailableSeats int,
    @Price decimal(10, 2)
as
begin
        insert into TrainBerthInfo (TrainID, BerthClass, TotalSeats, AvailableSeats, Price)
        values ( @TrainID, @BerthClass, @TotalSeats, @AvailableSeats, @Price);
end

----------------------------------------------------------------------------------------------------------------------------------


-------------------------------------------------------------------------------------------------------

--procedure for see only active trains
---------------------
create or alter proc GetActiveTrains
as
BEGIN
    select * from Train where Status = 'Y';
END
----------------------------------procedure for birth details----------------------------
create or alter proc GetBirthDetal
@TrainID INT
as
begin
    exec GetActiveTrains
	select*from  TrainBerthInfo WHERE TrainID=@TrainID;

end


---------------------------------------------------------------------------------

-- Procedure for  the booking process-------------------
create or alter proc BookTrainTicket
    @UserName varchar(50),
    @TrainID int,
    @BerthClass varchar(50),
    @TotalTickets int
as
begin
    -- Calculate booking amount 
    declare @Price decimal(10, 2);
    declare @BookingAmount decimal(10, 2);

    select @Price = price from TrainBerthInfo where TrainID = @TrainID AND BerthClass = @BerthClass;
    set @BookingAmount = @Price * @TotalTickets;

    -- Check if the train and berth class  seats are available
    declare @AvailableSeats int;
    select  @AvailableSeats = AvailableSeats from TrainBerthInfo where TrainID = @TrainID AND BerthClass = @BerthClass;

    if @AvailableSeats >= @TotalTickets
    begin
        -- Update available seats
        update TrainBerthInfo set AvailableSeats = AvailableSeats - @TotalTickets
        where TrainID = @TrainID AND BerthClass = @BerthClass;

        -- Insert booking details
        insert into  Booking (TrainID,UserName, berthType, Totaltickets, BookingStatus, payment_amount)
        values (@TrainID, @UserName, @BerthClass, @TotalTickets, 'Y', @BookingAmount);
		end

END


--------------------------------------------------------------------------------------------------------------------------------
CREATE OR ALTER PROC Printticket
@BookingID int
as 
begin
    select*from Booking where BookingID=@BookingID;
end


Create or alter proc GetLastBookingID
as
begin

    SELECT MAX(BookingID) AS LastBookingID FROM Booking;
END
--------------------------procedure to cancel ticket------------------------------------------------------------------------

CREATE   PROCEDURE CancelTicketData  
    @BookingID int  
AS  
BEGIN  
    declare @RefundAmount DECIMAL(10, 2);  
    declare @TotalAmount DECIMAL(10, 2);  
    declare @BookingStatus CHAR(1);  
    declare @TrainID INT;  
    declare @BerthClass VARCHAR(50);  
    declare @TotalTickets int ;  
  
    -- Get booking details and berth class  
    select  
        @BookingStatus = BookingStatus,  
        @TotalAmount = payment_amount,  
        @TrainID = TrainID,  
        @BerthClass = berthType,  
        @TotalTickets = Totaltickets  
    from Booking  
    where BookingID = @BookingID;  
  
    if @BookingStatus = 'Y'  
    begin  
        -- Calculate refund amount (60%)  
        set @RefundAmount = @TotalAmount * 0.6;  
  
        -- Insert into CancelTicket table  
        INSERT INTO CancelTicket (BookingID, RefundAmount)  
        VALUES (@BookingID, @RefundAmount);  
  
        -- Update booking status to 'N' (Cancelled)  
        UPDATE Booking   
        SET BookingStatus = 'N'  
        WHERE BookingID = @BookingID;  
  
        -- Update available seats for the canceled tickets in the respective berth class  
        update TrainBerthInfo  
        set AvailableSeats = AvailableSeats + @TotalTickets where TrainID = @TrainID AND BerthClass = @BerthClass;  
    END  
END
SP_helptext CancelTicketData
exec CancelTicketData @bookingID=2

select*from CancelTicket