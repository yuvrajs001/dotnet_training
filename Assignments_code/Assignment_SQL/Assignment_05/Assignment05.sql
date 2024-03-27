create database Assignment05



-- create department table
create table DEPT (
    DeptNo int primary key,
    Dname varchar(50),
    Loc varchar(40)
);

select* from DEPT

insert into DEPT (DeptNo, Dname, Loc)
values
    (10, 'ACCOUNTING', 'NEW YORK'),
    (20, 'RESEARCH', 'DALLAS'),
    (30, 'SALES', 'CHICAGO'),
    (40, 'OPERATIONS', 'BOSTON');

CREATE TABLE EMP (
    Empno int PRIMARY KEY,
    Ename varchar(50), 
    Job varchar(50), 
	HireDate date,
    Mgr_id int, 
    Sal decimal(10, 2),
    Comm decimal(10, 2),
    DeptNo int 
);
alter table EMP
add constraint fk_DeptNo foreign key(DeptNo) references DEPT(DeptNo)

insert into EMP (Empno, Ename, Job, Mgr_id,	HireDate, Sal, Comm, DeptNo)
values
    (7369, 'SMITH', 'CLERK', 7902, '1980-12-17', 800, NULL, 20),
    (7499, 'ALLEN', 'SALESMAN', 7698, '1981-02-20', 1600, 300, 30),
    (7521, 'WARD', 'SALESMAN', 7698, '1981-02-22', 1250, 500, 30),
    (7566, 'JONES', 'MANAGER', 7839, '1981-04-02', 2975, NULL, 20),
    (7654, 'MARTIN', 'SALESMAN', 7698, '1981-09-28', 1250, 1400, 30),
    (7698, 'BLAKE', 'MANAGER', 7839, '1981-05-01', 2850, NULL, 30),
    (7782, 'CLARK', 'MANAGER', 7839, '1981-06-09', 2450, NULL, 10),
    (7788, 'SCOTT', 'ANALYST', 7566, '1987-04-19', 3000, NULL, 20),
    (7839, 'KING', 'PRESIDENT', NULL, '1981-11-17', 5000, NULL, 10),
    (7844, 'TURNER', 'SALESMAN', 7698, '1981-09-08', 1500, 0, 30),
    (7876, 'ADAMS', 'CLERK', 7788, '1987-05-23', 1100, NULL, 20),
    (7900, 'JAMES', 'CLERK', 7698, '1981-12-03', 950, NULL, 30),
    (7902, 'FORD', 'ANALYST', 7566, '1981-12-03', 3000, NULL, 20),
    (7934, 'MILLER', 'CLERK', 7782, '1982-01-23', 1300, NULL, 10);

select*from EMP
 -----------------------------------------------
 ---------------------assignment05--------------
 --1. Write a T-Sql based procedure to generate complete payslip of a given employee with respect to the following condition

 --  a) HRA as 10% of Salary
 --  b) DA as 20% of Salary
 --  c) PF as 8% of Salary
 --  d) IT as 5% of Salary
 --  e) Deductions as sum of PF and IT
 --  f) Gross Salary as sum of Salary,HRA,DA
 --  g) Net Salary as Gross Salary - Deductions
create or alter proc Payslip @EmpNo int
as 
begin
select 'Employee Name'as Details,ename as Employee,cast(sal as nvarchar(20)) as BaiscPay,
        cast(sal * 0.1 as nvarchar(20)) as HRA,cast(sal * 0.2 as nvarchar(20)) as DA,
        cast(sal * 0.08 as nvarchar(20)) as PF,
        cast(sal * 0.05 as nvarchar(20)) as IT,
        cast((sal * 0.08) + (sal * 0.05) as nvarchar(20)) as TotalDeductions,
        cast(sal + (sal * 0.1) + (sal * 0.2) as nvarchar(20)) as GrossSalary,
        cast(sal + (sal * 0.1) + (sal * 0.2) - ((sal * 0.08) + (sal * 0.05)) as nvarchar(20)) as NetSalary
from EMP where Empno=@EmpNo 
end
execute Payslip @EmpNo=7934;