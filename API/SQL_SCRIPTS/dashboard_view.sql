USE [Wells_Dashboard]
GO

/****** Object:  View [dbo].[Dashboard_View]    Script Date: 9/18/2022 2:48:54 PM ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE OR ALTER VIEW [dbo].[Dashboard_View]
AS
SELECT        dbo.GetWellCount(N'Flowing') AS FlowingWellCount, dbo.GetWellCount(N'Shutin') AS ShutinWellCount, dbo.GetWellCount(N'Abandoned') AS AbandonedWellCount, dbo.GetWellCount(N'Producer') AS ProducerWellCount, 
                         dbo.GetWellCount(N'Injector') AS InjectorWellCount, dbo.GetWellCount(N'Single') AS SingleStringWellCount, dbo.GetWellCount(N'Dual') AS DualStringWellCount,
                             (SELECT        TOP (1) rate_sum
                               FROM            dbo.GetRateSumTable() AS p
                               ORDER BY date_days DESC) AS CurrentRate,
                             (SELECT        TOP (1) date_days
                               FROM            dbo.GetRateSumTable() AS p
                               ORDER BY date_days DESC) AS CurrentRateDate,
                             (SELECT        MAX(rate_sum) AS Expr1
                               FROM            dbo.GetRateSumTable() AS p) AS MaxDailyRate,
                             (SELECT        TOP (1) date_days
                               FROM            dbo.GetRateSumTable() AS p
                               ORDER BY rate_sum DESC) AS MaxDailyRateDate,
                             (SELECT        MIN(rate_sum) AS Expr1
                               FROM            dbo.GetRateSumTable() AS p) AS MinDailyRate,
                             (SELECT        TOP (1) date_days
                               FROM            dbo.GetRateSumTable() AS p
                               ORDER BY rate_sum) AS MinDailyRateDate,
                             (SELECT        TOP (1) Rate
                               FROM            dbo.GetCurrentRateTable() AS GetCurrentRateTable_1
                               ORDER BY Rate DESC) AS MaxWellCurrentRate,
                             (SELECT        TOP (1) Name
                               FROM            dbo.GetCurrentRateTable() AS GetCurrentRateTable_2
                               ORDER BY Rate DESC) AS WellWithMaxCurrentRate
FROM            dbo.Production_Data AS Production_Data_1 INNER JOIN
                         dbo.Wells ON Production_Data_1.WellId = dbo.Wells.Id INNER JOIN
                         dbo.Well_Schematic ON dbo.Wells.Id = dbo.Well_Schematic.WellId INNER JOIN
                         dbo.Well_Trajectory ON dbo.Wells.Id = dbo.Well_Trajectory.WellId
GROUP BY dbo.Wells.Id
GO

IF NOT EXISTS (SELECT * FROM sys.fn_listextendedproperty(N'MS_DiagramPane1' , N'SCHEMA',N'dbo', N'VIEW',N'Dashboard_View', NULL,NULL))
	EXEC sys.sp_addextendedproperty @name=N'MS_DiagramPane1', @value=N'[0E232FF0-B466-11cf-A24F-00AA00A3EFFF, 1.00]
Begin DesignProperties = 
   Begin PaneConfigurations = 
      Begin PaneConfiguration = 0
         NumPanes = 4
         Configuration = "(H (1[17] 4[15] 2[26] 3) )"
      End
      Begin PaneConfiguration = 1
         NumPanes = 3
         Configuration = "(H (1 [50] 4 [25] 3))"
      End
      Begin PaneConfiguration = 2
         NumPanes = 3
         Configuration = "(H (1 [50] 2 [25] 3))"
      End
      Begin PaneConfiguration = 3
         NumPanes = 3
         Configuration = "(H (4 [30] 2 [40] 3))"
      End
      Begin PaneConfiguration = 4
         NumPanes = 2
         Configuration = "(H (1 [56] 3))"
      End
      Begin PaneConfiguration = 5
         NumPanes = 2
         Configuration = "(H (2 [66] 3))"
      End
      Begin PaneConfiguration = 6
         NumPanes = 2
         Configuration = "(H (4 [50] 3))"
      End
      Begin PaneConfiguration = 7
         NumPanes = 1
         Configuration = "(V (3))"
      End
      Begin PaneConfiguration = 8
         NumPanes = 3
         Configuration = "(H (1[56] 4[18] 2) )"
      End
      Begin PaneConfiguration = 9
         NumPanes = 2
         Configuration = "(H (1 [75] 4))"
      End
      Begin PaneConfiguration = 10
         NumPanes = 2
         Configuration = "(H (1[66] 2) )"
      End
      Begin PaneConfiguration = 11
         NumPanes = 2
         Configuration = "(H (4 [60] 2))"
      End
      Begin PaneConfiguration = 12
         NumPanes = 1
         Configuration = "(H (1) )"
      End
      Begin PaneConfiguration = 13
         NumPanes = 1
         Configuration = "(V (4))"
      End
      Begin PaneConfiguration = 14
         NumPanes = 1
         Configuration = "(V (2))"
      End
      ActivePaneConfig = 0
   End
   Begin DiagramPane = 
      Begin Origin = 
         Top = 0
         Left = 0
      End
      Begin Tables = 
         Begin Table = "Production_Data_1"
            Begin Extent = 
               Top = 0
               Left = 39
               Bottom = 130
               Right = 221
            End
            DisplayFlags = 280
            TopColumn = 1
         End
         Begin Table = "Wells"
            Begin Extent = 
               Top = 29
               Left = 513
               Bottom = 159
               Right = 683
            End
            DisplayFlags = 280
            TopColumn = 0
         End
         Begin Table = "Well_Schematic"
            Begin Extent = 
               Top = 116
               Left = 259
               Bottom = 246
               Right = 429
            End
            DisplayFlags = 280
            TopColumn = 0
         End
         Begin Table = "Well_Trajectory"
            Begin Extent = 
               Top = 20
               Left = 880
               Bottom = 150
               Right = 1050
            End
            DisplayFlags = 280
            TopColumn = 0
         End
      End
   End
   Begin SQLPane = 
   End
   Begin DataPane = 
      Begin ParameterDefaults = ""
      End
      Begin ColumnWidths = 14
         Width = 284
         Width = 3195
         Width = 1500
         Width = 1500
         Width = 1500
         Width = 1500
         Width = 1860
         Width = 1500
         Width = 1500
         Width = 1500
         Width = 1500
         Width = 1500
         Width = 1500
         Width = 1500
      End
   End
   Begin CriteriaPane = 
      Begin ColumnWidths = 12
         Column = 1440
         Alias = 900
         Table = 1170
         Output = 720
         Append = 1400
         NewValue = 1170
         SortType = 1350
        ' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'VIEW',@level1name=N'Dashboard_View'
ELSE
BEGIN
	EXEC sys.sp_updateextendedproperty @name=N'MS_DiagramPane1', @value=N'[0E232FF0-B466-11cf-A24F-00AA00A3EFFF, 1.00]
Begin DesignProperties = 
   Begin PaneConfigurations = 
      Begin PaneConfiguration = 0
         NumPanes = 4
         Configuration = "(H (1[17] 4[15] 2[26] 3) )"
      End
      Begin PaneConfiguration = 1
         NumPanes = 3
         Configuration = "(H (1 [50] 4 [25] 3))"
      End
      Begin PaneConfiguration = 2
         NumPanes = 3
         Configuration = "(H (1 [50] 2 [25] 3))"
      End
      Begin PaneConfiguration = 3
         NumPanes = 3
         Configuration = "(H (4 [30] 2 [40] 3))"
      End
      Begin PaneConfiguration = 4
         NumPanes = 2
         Configuration = "(H (1 [56] 3))"
      End
      Begin PaneConfiguration = 5
         NumPanes = 2
         Configuration = "(H (2 [66] 3))"
      End
      Begin PaneConfiguration = 6
         NumPanes = 2
         Configuration = "(H (4 [50] 3))"
      End
      Begin PaneConfiguration = 7
         NumPanes = 1
         Configuration = "(V (3))"
      End
      Begin PaneConfiguration = 8
         NumPanes = 3
         Configuration = "(H (1[56] 4[18] 2) )"
      End
      Begin PaneConfiguration = 9
         NumPanes = 2
         Configuration = "(H (1 [75] 4))"
      End
      Begin PaneConfiguration = 10
         NumPanes = 2
         Configuration = "(H (1[66] 2) )"
      End
      Begin PaneConfiguration = 11
         NumPanes = 2
         Configuration = "(H (4 [60] 2))"
      End
      Begin PaneConfiguration = 12
         NumPanes = 1
         Configuration = "(H (1) )"
      End
      Begin PaneConfiguration = 13
         NumPanes = 1
         Configuration = "(V (4))"
      End
      Begin PaneConfiguration = 14
         NumPanes = 1
         Configuration = "(V (2))"
      End
      ActivePaneConfig = 0
   End
   Begin DiagramPane = 
      Begin Origin = 
         Top = 0
         Left = 0
      End
      Begin Tables = 
         Begin Table = "Production_Data_1"
            Begin Extent = 
               Top = 0
               Left = 39
               Bottom = 130
               Right = 221
            End
            DisplayFlags = 280
            TopColumn = 1
         End
         Begin Table = "Wells"
            Begin Extent = 
               Top = 29
               Left = 513
               Bottom = 159
               Right = 683
            End
            DisplayFlags = 280
            TopColumn = 0
         End
         Begin Table = "Well_Schematic"
            Begin Extent = 
               Top = 116
               Left = 259
               Bottom = 246
               Right = 429
            End
            DisplayFlags = 280
            TopColumn = 0
         End
         Begin Table = "Well_Trajectory"
            Begin Extent = 
               Top = 20
               Left = 880
               Bottom = 150
               Right = 1050
            End
            DisplayFlags = 280
            TopColumn = 0
         End
      End
   End
   Begin SQLPane = 
   End
   Begin DataPane = 
      Begin ParameterDefaults = ""
      End
      Begin ColumnWidths = 14
         Width = 284
         Width = 3195
         Width = 1500
         Width = 1500
         Width = 1500
         Width = 1500
         Width = 1860
         Width = 1500
         Width = 1500
         Width = 1500
         Width = 1500
         Width = 1500
         Width = 1500
         Width = 1500
      End
   End
   Begin CriteriaPane = 
      Begin ColumnWidths = 12
         Column = 1440
         Alias = 900
         Table = 1170
         Output = 720
         Append = 1400
         NewValue = 1170
         SortType = 1350
        ' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'VIEW',@level1name=N'Dashboard_View'
END
GO

IF NOT EXISTS (SELECT * FROM sys.fn_listextendedproperty(N'MS_DiagramPane2' , N'SCHEMA',N'dbo', N'VIEW',N'Dashboard_View', NULL,NULL))
	EXEC sys.sp_addextendedproperty @name=N'MS_DiagramPane2', @value=N' SortOrder = 1410
         GroupBy = 1350
         Filter = 1350
         Or = 1350
         Or = 1350
         Or = 1350
      End
   End
End
' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'VIEW',@level1name=N'Dashboard_View'
ELSE
BEGIN
	EXEC sys.sp_updateextendedproperty @name=N'MS_DiagramPane2', @value=N' SortOrder = 1410
         GroupBy = 1350
         Filter = 1350
         Or = 1350
         Or = 1350
         Or = 1350
      End
   End
End
' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'VIEW',@level1name=N'Dashboard_View'
END
GO

IF NOT EXISTS (SELECT * FROM sys.fn_listextendedproperty(N'MS_DiagramPaneCount' , N'SCHEMA',N'dbo', N'VIEW',N'Dashboard_View', NULL,NULL))
	EXEC sys.sp_addextendedproperty @name=N'MS_DiagramPaneCount', @value=2 , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'VIEW',@level1name=N'Dashboard_View'
ELSE
BEGIN
	EXEC sys.sp_updateextendedproperty @name=N'MS_DiagramPaneCount', @value=2 , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'VIEW',@level1name=N'Dashboard_View'
END
GO

