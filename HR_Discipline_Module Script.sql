ALTER Procedure [dbo].[AddAuditTrail]
@empID as int,
@process as nvarchar(50),
@date as date,
@timeTriggered as time(7)
AS
BEGIN
Insert Into auditTrail Values(@empID, @process, @date, @timeTriggered)
END
--Add Audit Trail entry

ALTER Procedure [dbo].[FileOffense]
@empID as int,
@offenseType as int,
@filed_emp_id as int,
@date as date,
@statement as varchar(100),
@evaluee_admin_id as int,
@decision as bit
AS
BEGIN
Insert Into empOffense Values (@empID, @offenseType, @filed_emp_id, @date, @statement, @evaluee_admin_id, @decision)
END

-- File Offense / Discipline Module

ALTER Procedure [dbo].[ViewAllEmployeeOffense]
as
begin
Select * from empOffense
end

-- View All Employee Offense / Discipline Module

ALTER Procedure [dbo].[ViewAllOffenseType]
as
begin
Select * from offenseType
end

-- View All Offense Type / Discipline Module

ALTER Procedure [dbo].[ViewAllProof]
as
begin
Select * from proof
end

-- View All proof

ALTER Procedure [dbo].[AddOffenseProof]
@empOffense as int,
@proof as image,
@date as date
as
begin
Insert Into proof Values (@empOffense, @proof, @date)
end

-- Add Offense Proof / Discipline Module

ALTER Procedure [dbo].[AddOffenseType]
@offenseType as nvarchar(50),
@offenseInfo as nvarchar(100)
as
begin
Insert Into offenseType Values (@offenseType, @offenseInfo)
end

-- Add Offense Type / Discipline Module

ALTER Procedure [dbo].[ViewOffenseByDate]
@date as date
as
begin
Select * from empOffense Where date = @date
end

-- View Offense By Date / Discipline Module

ALTER Procedure [dbo].[ViewOffenseByDecision]
@decision as bit
as
begin
Select * from empOffense Where decision = @decision
end

-- View Offense By Decision / Discipline Module

ALTER Procedure [dbo].[ViewOffenseTypeByID]
@offense_type_id as int
as
begin
Select * from offenseType WHERE offense_type_id = @offense_type_id
end

-- View OffenseType by ID / Discipline Module

ALTER Procedure [dbo].[ViewOffenseTypeByOffenseType]
@offense_type as nvarchar(50)
as
begin
Select * from offenseType Where offense_type = @offense_type
end

-- View OffenseType by Offense Type / Discipline Module

ALTER Procedure [dbo].[ViewPersonalOffenseByEmpID]
@empID as int
as
begin
Select * from empOffense Where emp_id = @empID
end

-- View Personal Offense By Employee ID / Discipline Module

ALTER Procedure [dbo].[ViewPersonalOffenseByOffenseEmpID]
@offense_emp_id as int
as
begin
Select * from empOffense Where offense_emp_id = @offense_emp_id
end

-- View Offense By Offense Emp ID / Discipline Module

ALTER Procedure [dbo].[ViewProofByDate]
@date as date
as
begin
Select * from proof Where date = @date
end

-- View Proof By date / Discipline Module

ALTER Procedure [dbo].[ViewProofByOffenseEmpID]
@offense_emp_id as int
as
begin
Select * from proof Where offense_emp_id = @offense_emp_id
end

-- View Proof by Offense Emp ID / Discipline Module

ALTER Procedure [dbo].[ViewProofByProofID]
@proofID as int
as
begin
Select * from proof Where proof_id = @proofID
end

-- View Proof By Proof ID / Discipline Module

ALTER Procedure [dbo].[DisplayAllEmployees]
AS
BEGIN
Select emp_id, password, last_name, first_name, middle_name, position_id, company_id, email_address, gender, address, primary_contact_number,alternative_contact_number, city, birthdate, sss_number, philhealth_number, biometric_code, employee_status from employee
END

-- Display All Employees / HR Module

ALTER Procedure [dbo].[ViewEmployeeInformation]
@empID as int
AS
BEGIN
Select * from employee where emp_id = @empID
end

-- View Employee Information / HR Module



ALTER Procedure [dbo].[InsertEmployee]
@password as nvarchar(15),
@lastName as varchar(50),
@firstName as varchar(50),
@middleName as varchar(50),
@positionID as int, 
@companyID as int,
@email as varchar(50),
@gender as varchar(10),
@address as varchar(100),
@primaryNumber as numeric(18,0),
@alternativeNumber as numeric(18,0),
@city as varchar(50),
@birthdate as date,
@sssNumber as int,
@philhealthNumber as int,
@biometricCode as int,
@employeeStatus as bit
AS
BEGIN
Insert Into employee Values(@password,@lastName,@firstName,@middleName,@positionID,@companyID,@email,@gender,@address,@primaryNumber,@alternativeNumber,@city, @birthdate,@sssNumber,@philhealthNumber,@biometricCode,@employeeStatus)
END

-- Insert Employee / HR Module

ALTER Procedure [dbo].[UpdateEmployee]
@password as nvarchar(15),
@lastName as varchar(50),
@firstName as varchar(50),
@middleName as varchar(50),
@email as varchar(50),
@gender as varchar(10),
@address as varchar(100),
@primaryNumber as numeric(18,0),
@alternativeNumber as numeric(18,0),
@city as varchar(50),
@birthdate as date,
@sssNumber as int,
@philhealthNumber as int,
@employeeStatus as bit,
@empID as int
AS
BEGIN
Update employee SET password = @password, last_name = @lastName, first_name = @firstName, middle_name = @middleName, email_address = @email, gender = @gender, address = @address, primary_contact_number = @primaryNumber, alternative_contact_number = @alternativeNumber, city = @city, birthdate = @birthdate, sss_number = @sssNumber, philhealth_number = @philhealthNumber, employee_status = @employeeStatus Where emp_id = @empID
END

--Update Employee / HR Module

ALTER Procedure [dbo].[FileLeaveRequest]
@empID as int,
@leaveTypeID as int,
@date_from as date,
@date_to as date,
@reason as nvarchar(100),
@admin_emp_id as int,
@request_status as bit
as
begin
Insert Into leaveRequest Values (@empID, @leaveTypeID, @date_from, @date_to, @reason, @admin_emp_id, @request_status)
end

-- File Leave Request / Leave Module

