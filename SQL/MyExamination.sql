
SELECT * FROM tblEmployee

--Employee No.
--Last Name
--First Name
--Middle Name
--Birthdate
--Department
--Address

Create table tblEmployee(        
    EmployeeNo int IDENTITY(1,1) NOT NULL,        
    LastName varchar(50) NOT NULL,        
    FirstName varchar(50) NOT NULL,        
    MiddleName varchar(50) NULL,        
    Birthdate datetime NULL,    
	Department varchar(50) NOT NULL,   
	Address varchar(50) NOT NULL   
) 

CREATE PROCEDURE spAddEmployee         
(    
    @LastName VARCHAR(50),
	@FirstName VARCHAR(50),         
	@MiddleName VARCHAR(50),         
    @Birthdate datetime,        
    @Department VARCHAR(20),        
    @Address VARCHAR(50)        
)        
as         
Begin         
    Insert into tblEmployee (LastName,FirstName,MiddleName, Birthdate, Department, Address)         
    Values (@LastName,@FirstName,@MiddleName, @Birthdate,@Department,@Address)         
End


Create procedure spUpdateEmployee          
(          
	@EmpId INTEGER ,        
    @LastName VARCHAR(50),
	@FirstName VARCHAR(50),         
	@MiddleName VARCHAR(50),         
    @Birthdate datetime,        
    @Department VARCHAR(20),        
    @Address VARCHAR(50)           
)          
as          
begin          
   Update tblEmployee           
   set LastName = @LastName,
   FirstName = @FirstName,
   MiddleName = @MiddleName,
   Birthdate = @Birthdate,
   Department = @Department,
   Address = @Address	
   where EmployeeNo=@EmpId          
End

Create procedure spDeleteEmployee         
(          
   @EmpId int          
)          
as           
begin          
   Delete from tblEmployee where EmployeeNo=@EmpId          
End 

Create procedure spGetAllEmployees      
as      
Begin      
    select *      
    from tblEmployee      
End  

Create procedure spReportList      
as      
Begin      
    select Count(EmployeeNo) AS Employee , department AS Department
    from tblEmployee
	group by department
End  
