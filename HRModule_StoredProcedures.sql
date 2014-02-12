USE [dheltassys]
GO
/****** Object:  StoredProcedure [dbo].[AddPermanentPasswordForAccount]    Script Date: 02/13/2014 06:59:05 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
ALTER Procedure [dbo].[AddPermanentPasswordForAccount]
@password as nvarchar(15),
@emp_id as int
AS
BEGIN
Update employee SET password = @password Where emp_id = @emp_id
END

USE [dheltassys]
GO
/****** Object:  StoredProcedure [dbo].[ViewEmployeeInformation]    Script Date: 02/13/2014 06:59:09 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
ALTER Procedure [dbo].[ViewEmployeeInformation]
@company_id as int,
@position_id as int
AS
BEGIN
Select emp_id as [Employee ID],
last_name as [Last name],
first_name as [First name],
middle_name as [Middle name],
(Select position_name from position where position_id = @position_id) as [Position],
(Select company_name from company where company_id = @company_id) as [Company],
email_address as [E-mail],
gender as [Gender],
address as [Address],
primary_contact_number as [Primary Contact Number],
alternative_contact_number as [Alternative Contact Number],
city as [City],
birthdate as [Birthdate],
sss_number as [SSS Number],
philhealth_number as [PhilHealth Number],
employee_status as [Employee Status]
From employee Where company_id = @company_id
END

USE [dheltassys]
GO
/****** Object:  StoredProcedure [dbo].[AddAuditTrail]    Script Date: 02/13/2014 06:59:03 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
ALTER Procedure [dbo].[AddAuditTrail]
@emp_id as int,
@process as nvarchar(50)
AS
BEGIN
Insert Into auditTrail Values (@emp_id, @process, CONVERT (date, SYSDATETIME()), convert(varchar(10), GETDATE(), 108))
END

USE [dheltassys]
GO
/****** Object:  StoredProcedure [dbo].[AddAccountSetTempPassword]    Script Date: 02/13/2014 06:59:00 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
ALTER Procedure [dbo].[AddAccountSetTempPassword]
@password as nvarchar(15),
@last_name as varchar(50),
@first_name as varchar(50),
@middle_name as varchar(50),
@position_name as varchar(50),
@company_name as varchar(50),
@biometrics_image as image
AS
Begin
	Insert Into employee 
		(password, 
		last_name, 
		first_name, 
		middle_name, 
		position_id, 
		company_id,
		biometrics_image)
	Values 
		(@password, 
		@last_name,
		@first_name, 
		@middle_name, 
		(Select position_id 
		from position 
		where position_name = @position_name),
		(Select company_id 
		from company 
		where company_name = @company_name),
		@biometrics_image)
END

USE [dheltassys]
GO
/****** Object:  StoredProcedure [dbo].[AddAccountDetails]    Script Date: 02/13/2014 06:58:55 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
ALTER Procedure [dbo].[AddAccountDetails]
@email as varchar(50),
@gender as varchar(10),
@address as varchar(100),
@primary_contact_number as varchar(20),
@alternative_contact_number as varchar(20),
@city as varchar(50),
@birthday as date,
@sss_number as int,
@philhealth_number as int,
@emp_id as int
AS
Begin
Update employee SET email_address = @email,
gender = @gender,
address = @address,
primary_contact_number = @primary_contact_number,
alternative_contact_number = @alternative_contact_number,
city = @city,
birthdate = @birthday,
sss_number = @sss_number,
philhealth_number = @philhealth_number,
employee_status = 1
WHERE emp_id = @emp_id
END