use Assignment2


--1. Retrieve a list of MANAGERS. 

select *from EMP where Job like 'm%'

--2. Find out the names and salaries of all employees earning more than 1000 per 
--month. 

select Ename,Sal from EMP where Sal>1000 order by	Sal asc;
--3. Display the names and salaries of all employees except JAMES. 


select ename,sal from EMP where not ename like 'james'
--other method
select  Ename,Sal from emp where Ename !='james'


--4. Find out the details of employees whose names begin with ‘S’. 

select Empno,Ename from EMP where Ename like 's%';
--5. Find out the names of all employees that have ‘A’ anywhere in their name. 

select Empno,Ename from EMP where Ename like '%A%';
--6. Find out the names of all employees that have ‘L’ as their third character in 
--their name. 
select Empno,Ename from EMP where Ename like '__l%';

--7. Compute daily salary of JONES. 



select Ename,sal /day(EOMONTH(GETDATE()))as daily_salary from emp where Ename='Jones';

--8. Calculate the total monthly salary of all employees. 
select  coalesce(Ename,'Total Employee') as Employee , sum(Sal)as 'Total salary' from EMP group by rollup(Ename);

--9. Print the average annual salary . 

select avg(Sal)as Average_salary from EMP ;
--10. Select the name, job, salary, department number of all employees except 
--SALESMAN from department number 30. 

select Ename,Job,Sal, DeptNo from EMP where not DeptNo like '30';

--11. List unique departments of the EMP table. 

select distinct DeptNo from EMP;


--12. List the name and salary of employees who earn more than 1500 and are in department 10 or 30. Label the columns Employee and Monthly Salary respectively.

select Ename as 'Employee' ,Sal as'Monthly Salary' from EMP where sal>1500 and DeptNo in (10,30)
--13. Display the name, job, and salary of all the employees whose job is MANAGER or 
--ANALYST and their salary is not equal to 1000, 3000, or 5000. 

select Ename,Job,Sal from emp where job in('Manager','Analyst')and Sal not in(1000,3000,5000);


--14. Display the name, salary and commission for all employees whose commission 
--amount is greater than their salary increased by 10%. 
select Ename, Sal, comm from EMP where comm > Sal * 0.1;

--15. Display the name of all employees who have two Ls in their name and are in 
--department 30 or their manager is 7782.
select *from emp
select*from EMP where Ename like '%l%l%' and DeptNo=30 or Mgr_id=7782;
--16. Display the names of employees with experience of over 30 years and under 40 yrs.
-- Count the total number of employees. 

select Ename, DATEDIFF(year,HireDate,getdate()) as EXPERIENCE                           --getting total exp
from EMP  where( select DATEDIFF(year,HireDate,getdate())) between 30 and 39            --checking the diff

select count(*) as TotalEmployees FROM EMP
--17. Retrieve the names of departments in ascending order and their employees in descending order. 


select d.Dname, e.Ename from DEPT d  LEFT JOIN EMP e on d.DeptNo= E.DeptNo 
order by d.Dname asc, e.Ename desc;



--18. Find out experience of MILLER. 

select DATEDIFF(year,HireDate,getdate()) as 'Miller EXP 'from emp where ename='miller'