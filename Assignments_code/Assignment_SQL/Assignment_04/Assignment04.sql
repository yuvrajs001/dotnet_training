create database Assignment04

use Assignment04
------------------------------------------------------------------------------
--1.	Write a T-SQL Program to find the factorial of a given number.
 declare @number int
 declare @factorial int
 set @factorial=1          --hold the final value
 set @number=8

 if @number=0
 begin
      print 'Factorial of 0 is 1';
 end
 else
 begin
     if @number<1
 begin
     print 'Factorial is can not be defined for negative numbers'
 end  
 else 
 begin
    declare @count int
	set @count=1
   
   while @count<=@number
      begin 
        set @factorial=@factorial*@count;
	    set @count+=1;
      end;
      print 'factorial of  '+cast(@number as varchar(20)) + ' is  '+' '+cast(@factorial as varchar(30))
end;
end;



--2.	Create a stored procedure to generate multiplication tables up to a given number.

create or alter proc CreateTable(@number int, @multiplier int=1)
as 
 begin
     declare @result int 
	 set @result=@number
	 print 'Multiplication of this table '+cast(@number as varchar(30))+':'

	 while @multiplier<=10
	 begin 
	    print cast(@number as varchar(30)) + ' * ' + CAST(@multiplier as varchar(30)) + ' = ' + CAST(@result as varchar(20));
	    set @result=@number*@multiplier;
		set @multiplier+=1;
     end 
	 print ' '
end 

exec CreateTable @number=3



--3.  Create a trigger to restrict data manipulation on EMP 
--table during General holidays. Display the error message like “Due to
-- Independence day you cannot manipulate data” or "Due To Diwali",
-- you cannot manupulate" etc

--Note: Create holiday table as (holiday_date,Holiday_name)
-- store at least 4 holiday details. try to 
--match and stop manipulation 

create table Holiday(Holiday_date date primary key,Holiday_name varchar(30));

insert into Holiday (holiday_date,holiday_name) 
values
('2024-03-24', 'New Year Day'),
('2024-07-04', 'Independence Day'),
('2024-10-27', 'Diwali'),
('2024-12-25', 'Christmas'),
('2024-04-01', 'April Fools Day'),
('2024-05-01', 'Labor Day');

create table Employee (
    Id int primary key,
    Name varchar(30),
    Salary Decimal(10, 2),
    Address varchar(30)
);
select*from Employee

create or alter trigger Stop_Dml_Operation
ON Employee  for insert ,update,delete
as
begin
    Declare @totalHoliday int;
    set @totalHoliday=(select COUNT(*)from Holiday where Holiday_date=CONVERT(date,GETDATE()))
   -- If there is a holiday it will rollback the transaction and throw error message 
    if @totalHoliday > 0
    begin
	     declare @errormessage varchar(50)
		 declare @HolidayName varchar(30)
		 select @HolidayName=holiday_name from Holiday where Holiday_date=convert(date,getdate());
	    
		set @errormessage = 'Due to '+ @HolidayName+',you can nott manipulate the data';
        
         RAISERROR(@errormessage, 16, 1);
        rollback transaction
    end
end


 insert into Employee values
 
 (1,'ashu',1500.00,'lucknow')
