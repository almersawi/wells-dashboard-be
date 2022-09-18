USE [Wells_Dashboard]
GO

/****** Object:  UserDefinedFunction [dbo].[GetWellWithMaxProdRate]    Script Date: 9/18/2022 2:43:31 PM ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date, ,>
-- Description:	<Description, ,>
-- =============================================
CREATE OR ALTER FUNCTION [dbo].[GetWellWithMaxProdRate]
(

)
RETURNS nvarchar(50)
AS
BEGIN
	-- Declare the return variable here
	DECLARE @namevalue nvarchar(50);


		SELECT TOP(1) @namevalue = Name FROM dbo.Wells w INNER JOIN dbo.Production_Data p ON w.Id = p.WellId
		ORDER BY p.Rate DESC  ;
		RETURN(@namevalue);



END
GO

