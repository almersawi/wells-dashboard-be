USE [Wells_Dashboard]
GO

/****** Object:  UserDefinedFunction [dbo].[GetWellCount]    Script Date: 9/18/2022 2:49:05 PM ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO


CREATE OR ALTER FUNCTION [dbo].[GetWellCount]
(	
	-- Add the parameters for the function here
	@Category nvarchar(50)
)
RETURNS int 
AS
BEGIN 

	DECLARE @returnvalue INT;

	SELECT @returnvalue = Count(*) FROM dbo.Wells WHERE Status = @Category OR Type = @Category OR StringType = @Category;
	RETURN(@returnvalue);


END
GO

