USE [Wells_Dashboard]
GO

/****** Object:  UserDefinedFunction [dbo].[GetCurrentRateTable]    Script Date: 9/18/2022 2:42:41 PM ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
CREATE OR ALTER FUNCTION [dbo].[GetCurrentRateTable]
(	
	
)
RETURNS TABLE 
AS
RETURN 
(
	/****** Script for SelectTopNRows command from SSMS  ******/
SELECT
      FORMAT(p.Date, 'd', 'US-EN') as date_days
      ,p.Rate
      ,w.Name
  FROM [dbo].[Production_Data] p 
  inner join [dbo].[Wells] w 
  ON p.WellId = w.Id
  where FORMAT(p.Date, 'd', 'US-EN') = FORMAT((select top(1) Date from [dbo].[Production_Data] order by Date desc ), 'd', 'US')
)
GO

