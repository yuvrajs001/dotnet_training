 create database CodeChallange 
 use codechallange

 create table Employee_Details (
    Empno int primary key,
    EmpName varchar(50) NOT NULL,
    Empsal numeric(10,2) check (Empsal >= 25000),
    Emptype char(1) check (Emptype IN ('Y', 'N'))
);
select*from Employee_Details

create or alter proc AddEmployeeDetails
    @EmpName VARCHAR(50),
    @Empsal NUMERIC(10,2),
    @EmpType char(1)
as
begin
    declare @NewEmpNo int;
    SELECT @NewEmpNo = isnull(MAX(Empno), 0) + 1 from Employee_Details;

    insert into Employee_Details (Empno, EmpName, Empsal, Emptype)
    values (@NewEmpNo, @EmpName, @Empsal, @EmpType);
END;

EXEC AddEmployeeDetails 
    @EmpName = 'John',
    @Empsal = 85000,
    @EmpType = 'Y';

create or alter proc ShowAllEmployee
as
begin
    Select Empno, EmpName, Empsal, Emptype
    from Employee_Details;
END;
