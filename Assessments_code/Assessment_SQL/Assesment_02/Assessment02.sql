CREATE DATABASE Assessment02

 -- Create the table
create table Birthday (
    Name varchar(30),
    Birthdate date,
    Age int
);

--insert data
insert into Birthday(Name, Birthdate, Age)
values
    ('rohan', '1990-05-15', 31),
    ('mohan', '1999-09-20', 36),
    ('saurabh', '2014-03-10', 22);
	-------------------------------------------------------------------------------------------------------------
--1.	Write a query to display your birthday( day of week)
select Name, Birthdate, DATENAME(dw, Birthdate) as DayOfWeek from Birthday;

--2.	Write a query to display your age in days
select Name, Birthdate, Age, DATEDIFF(day,Birthdate,getdate()) as Days from Birthday;

 ----------------------------------------------------------------------------------------------------------------------------
--3.	Write a query to display all employees information those who joined before 5 years in the current month

--(Hint : If required update some HireDates in your EMP table of the assignment)

-- Inserting additional employee records with varying hire dates

insert into EMP (Empno, Ename, Job, HireDate, Sal, DeptNo)
values
    (9999, 'Don', 'ANALYST', '2022-03-15', 4000, 20), 
    (8888, 'Lucy', 'CLERK', '2023-05-20', 2000, 10),   
    (7777, 'Pritam', 'MANAGER', '2024-01-10', 5000, 30); 
	----------------------------------------------------------------------------------------
--who joined before 5 years in the current month

update EMP set HireDate = '2019-03-27' where Empno in (7934);
select*from EMP where HireDate <= dateadd(year, -5, getdate()) and month(HireDate) = month(getdate())
-- Query to display employees who joined in the last 5 years
Select * from EMP where HireDate >= DATEADD(YEAR, -5, GETDATE());  



----------------------------------------------------------------------------------------------------------------------
 
--4.	Create table Employee with empno, ename, sal, doj columns and perform the following operations in a single transaction
--	a. First insert 3 rows 
--	b. Update the second row sal with 15% increment  
--        c. Delete first row.
--After completing above all actions how to recall the deleted row without losing increment of second row.
 create table Employee (
 Empno int primary key,
 Ename varchar(20),
 Sal decimal(10, 2),
 Doj date
);
create table DeletedEmployee (  ---creating table temporary
    Empno int primary key,
    Ename varchar(20),
    Sal decimal(10, 2),
    Doj date
);

begin tran
---a)
insert into Employee (Empno, Ename, Sal, Doj)
	values (1, 'Mayank', 6000.00, '2023-03-01')
	,
        (2, 'Ram', 10000.00, '2022-03-01'),
       (3, 'Megha', 5500.00, '2023-01-01');

--b. Update the second row sal with 15% increment  
update Employee set Sal = sal*1.15  where Empno = 2;
--Delete the first row
delete from Employee where Empno = 1;

insert into DeletedEmployee                
select * from Employee where Empno = 1;--IT WILL insert the data into the temporary table so we can access again

commit tran
select * from Employee

-------------------now recall the deleted tran
insert into Employee
select * from DeletedEmployee;

--Drop the temporary table         
drop table DeletedEmployee;
-- verify the result
select * from Employee;

----------------------------------------------------------------------------------------------------------------------
--5.      Create a user defined function calculate Bonus for all employees of a  given job using 	following conditions
--	a.     For Deptno 10 employees 15% of sal as bonus.
--	b.     For Deptno 20 employees  20% of sal as bonus
--	c      For Others employees 5%of sal as bonus
create function Bonus(@DeptNo int, @Sal decimal(10, 2))
RETURNS decimal(10, 2)
as
begin
    return case 
        WHEN @DeptNo = 10 then 0.15 * @Sal -- 15% bonus 
        when @DeptNo = 20 then  0.20 * @Sal -- 20% bonus 
        else 0.05 * @Sal -- 5% bonus for other departments
end
end
-- Use the Bonus function to calculate bonus for DeptNo 20 employees
select Ename,Job,Sal,dbo.Bonus(20, Sal) AS Bonus from EMP



