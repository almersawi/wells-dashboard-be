USE [Wells_Dashboard]
GO

/****** Object:  UserDefinedFunction [dbo].[GetRateSumTable]    Script Date: 9/18/2022 2:43:01 PM ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
CREATE OR ALTER FUNCTION [dbo].[GetRateSumTable]
(	

)
RETURNS TABLE 
AS
RETURN 
(
	select sum(Rate) as "rate_sum", FORMAT (Date, 'd', 'en-US') as "date_days"
	from wells_dashboard.dbo.production_data
	group by FORMAT (Date, 'd', 'en-US')
)
GO

