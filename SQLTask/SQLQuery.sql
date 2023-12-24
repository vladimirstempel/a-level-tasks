use [AdventureWorks2019]

-- 1. Retrieve all information from the Sales.Customer table
select * from Sales.Customer

-- 2. Retrieve all information from the Sales.Store table sorted by Name in alphabetical order
select * from Sales.Store order by [Name] asc

-- 3. Retrieve all information from the HumanResources.Employee table about ten employees who were born after 1989-09-28
select top(10) * from HumanResources.Employee where BirthDate > '1989-09-28'

-- 4. Retrieve employees from the HumanResources.Employee table whose last character of LoginID is 0. Output only NationalIDNumber, LoginID, JobTitle. Data must be sorted by JobTitle by kill
select NationalIDNumber, LoginID, JobTitle from HumanResources.Employee where LoginID like '%0' order by JobTitle asc

-- 5. Retrieve from the Person.Person table all information about records that have been updated in 2008 (ModifiedDate) and MiddleName contains value and Title does not contain a value
select * from Person.Person where ModifiedDate >= '2008-01-01' and ModifiedDate < '2009-01-01' and MiddleName is not NULL and Title is NULL

-- 6. Display department name (HumanResources.Department.Name) WITHOUT repetition in which there are employees . Use HumanResources.EmployeeDepartmentHistory and HumanResources.Department tables
select distinct [Name] from HumanResources.Department as HRD
	inner join HumanResources.EmployeeDepartmentHistory as HREDH
	on HRD.DepartmentID = HREDH.DepartmentID and HREDH.EndDate is NULL

-- 7. Group data from Sales.SalesPerson table by TerritoryID and print the amount of CommissionPct if it is greater than 0
select TerritoryID, CommissionPct from Sales.SalesPerson
	where CommissionPct > 0
	group by TerritoryID, CommissionPct

-- 8. Display all employee information (HumanResources.Employee) which have the largest number vacations (HumanResources.Employee.VacationHours)
select * from HumanResources.Employee
	where VacationHours = (
		select MAX(VacationHours) from HumanResources.Employee
	)

-- 9.Display all employee information (HumanResources.Employee) which have a position (HumanResources.Employee.JobTitle) 'Sales Representative' or 'Network Administrator' or 'Network Manager'
select * from HumanResources.Employee where JobTitle in ('Sales Representative', 'Network Administrator', 'Network Manager')

-- 10. Display all employee information (HumanResources.Employee) and their orders (Purchasing.PurchaseOrderHeader). IF THE EMPLOYEE DOES NOT HAVE ORDERS SHOULD BE DISPLAYED TOO!!!
select * from HumanResources.Employee as HRE
	left join Purchasing.PurchaseOrderHeader as PPOH on HRE.BusinessEntityID = PPOH.EmployeeID