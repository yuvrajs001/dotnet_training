 create database Assessment01

 use Assessment01;

 create table Books(
    Id  int Primary key,
    Title varchar(50),
    Author Varchar(30),
    isbn varchar(20) Unique,
    Published_date Datetime
); 

insert into Books(Id,Title,Author,isbn,Published_date)
values
(1,'My First SQL book','Mary Parker',981483029127,'2012-02-22 12:08:17'),
(2,'My Second SQL book','John Mayer',857300922713,'1972-07-03 09:22:45'),
(3,'My Third SQL book','Cary Flint',523120967812,'2015-10-18 14:05:44')
select*from Books


-----------------------------------------------------------------------------------------
create table Reviews(
 id int,
 BookId int,
 Reviewer_Name  varchar(30),
 Content varchar(50),
 Rating int,
 Published_date datetime,
 foreign key  (bookId) REFERENCES books(id)
);

insert into Reviews(id,BookId,Reviewer_Name,Content,Rating,Published_date)
values(1,1,'John Smith','My first Review',4,'2017-12-10 05:50:11'),
(2,2,'John Smith',' My Second Review',5,'2017-10-13 15:05:12'),
(3,2,'Alice Review','Another Review',1,'2017-10-22 23:47:10')

---------------------------------------------------------------------------------------
create table Customers(
    Id int primary key,
    Name varchar(50),
    Age int,
    Address varchar(50),
    Salary decimal(10,2)
);


insert into Customers(Id, Name, Age, Address, Salary) 
VALUES 
(1, 'RAMESH', 32, 'AHMEDABAD', 2000.00),
(2, 'KHILAN', 25, 'DELHI', 1500.00),
(3, 'KAUSHIK', 23, 'KOTA', 2000.00),
(4, 'CHAITALI', 25, 'MUMBAI', 6500.00),
(5, 'HARDIK', 27, 'BHOPAL', 8500.00),
(6, 'KOMAL', 22, 'MP', 4500.00),
(7, 'MUFFY', 24, 'INDORE', 10000.00);



---------------------------------------------------------------------------------------
create table orders (
    Oid int primary key,
    Date datetime,
    Cust_id int,
    Amount decimal(10, 2)
);

insert into orders (Oid, Date, Cust_id, Amount)
values 
    (102, '2009-10-08 00:00:00', 3, 3000.00),
    (100, '2009-10-08 00:00:00', 3, 1500.00),
    (101, '2009-11-20 00:00:00', 2, 1560.00),
    (103, '2008-05-20 00:00:00', 4, 2060.00);


------------------------------------from 1-------------------------------------------



--Write a query to fetch the details of the books written by author whose name ends with er.

select *from Books where Author like '%er' 



--Display the Title ,Author and ReviewerName for all the books from the above table 
select b.Title, b.Author, r.Reviewer_Name from Books b join Reviews r on b.Id = r.BookId;


--------------------------------------from 2---------------------------------


--Display the  reviewer name who reviewed more than one book.
select Reviewer_Name from Reviews group by Reviewer_Name HAVING COUNT(BookId) > 1;

--------------------------------from3--------------------------------------

--Display the Name for the customer from above customer table  who live in same address which has character o anywhere in address
select Name from Customers where Address LIKE '%o%';



--
-----------------------------------------from 4----------------------------------
--Write a query to display the Date,Total no of customer placed order on same Date
select date, count(distinct cust_id) as total_customers
from orders
group by date;

select count(distinct cust_id) as total_customers_per_date from orders
group by date;

--------------------from 5---------------------------------------


create table Emp(
    id int primary key,
    name varchar(50),
    age int,
    address varchar(100),
    salary decimal(10, 2) null
	);

insert into emp(id, name, age, address, salary)
values 
    (1, 'Ramesh', 32, 'Ahmedabad', 2000.00),
    (2, 'Khilan', 25, 'Delhi', 1500.00),
    (3, 'Kaushik', 23, 'Kota', 2000.00),
    (4, 'Chaitali', 25, 'Mumbai', 6500.00),
    (5, 'Hardik', 27, 'Bhopal', 8500.00),
    (6, 'Komal', 22, 'MP', null),
    (7, 'Muffy', 24, 'Indore', null);

-- Display employees name in lower case with null salary
select lower(name) as name, salary from emp where salary is null;

-----------------------------------------------------------------------------------
-----------------students table

create table student (
    Id int primary key,
    Register_no int,
    Name varchar(50),
    Age int,
    Qualification varchar(50),
    Mobile_no varchar(15),
    Mail_id varchar(50),
    location varchar(50),
    gender char(1)
);

insert into student (Id, Register_no, Name, Age, Qualification, Mobile_no, Mail_id, location, gender)
values 
    (1, 2, 'sai', 22, 'B.E.', '9952836777', 'sai@gmail.com', 'Chennai', 'M'),
    (2, 3, 'kumar', 20, 'B.SC', '7890125648', 'kumar@gmail.com', 'Madurai', 'M'),
    (3, 4, 'selvi', 22, 'B.Tech', '8904567342', 'slevi@gmail.com', 'Salem', 'F'),
    (4, 5, 'nisha', 25, 'M.E', '7834672310', 'nisha@gmail.com', 'Theni', 'F'),
    (5, 6, 'sai saran', 21, 'B.A.', '7890345678', 'saran@gmail.com', 'Madurai', 'F'),
    (6, 7, 'tom', 23, 'BCA', '8901234675', 'tom@gmail.com', 'Pune', 'M');

-- Write a sql server query to display the Gender,Total no of male and female from the above relation
select gender, count(*) as total_MALE_female from student group by gender;