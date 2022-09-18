USE [Wells_Dashboard]
GO

/****** Object:  View [dbo].[Well_Summary_View]    Script Date: 9/18/2022 4:07:54 PM ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE OR ALTER VIEW [dbo].[Well_Summary_View]
AS
SELECT        MAX(dbo.Wells.Id) AS WellId, MAX(dbo.Wells.Name) AS Name, MAX(dbo.Wells.Lat) AS Lat, MAX(dbo.Wells.Lon) AS Lon, MAX(Production_Data_1.Rate) AS MaxProdRate, MIN(Production_Data_1.Rate) AS MinProdRate, 
                         AVG(Production_Data_1.Rate) AS AvgProdRate,
                             (SELECT        TOP (1) Rate
                               FROM            dbo.Production_Data
                               WHERE        (WellId = dbo.Wells.Id)
                               ORDER BY Date DESC) AS LastProdRate,
                             (SELECT        TOP (1) Date
                               FROM            dbo.Production_Data AS Production_Data_3
                               WHERE        (WellId = dbo.Wells.Id) AND (Rate IS NOT NULL)
                               ORDER BY Date DESC) AS LastProdDate,
                             (SELECT        TOP (1) Date
                               FROM            dbo.Production_Data AS Production_Data_4
                               WHERE        (WellId = dbo.Wells.Id) AND (WellheadPressure IS NOT NULL)
                               ORDER BY Date DESC) AS LastWhPressureDate, MAX(Production_Data_1.WellheadPressure) AS MaxWhPressure, MIN(Production_Data_1.WellheadPressure) AS MinWhPressure, AVG(Production_Data_1.WellheadPressure) 
                         AS AvgWhPressure,
                             (SELECT        TOP (1) WellheadPressure
                               FROM            dbo.Production_Data AS Production_Data_2
                               WHERE        (WellId = dbo.Wells.Id)
                               ORDER BY Date DESC) AS LastWhPressure, MAX(Well_Schematic_1.Bottom) AS MaxSchematicBottom,
                             (SELECT        TOP (1) North
                               FROM            dbo.Well_Trajectory
                               WHERE        (WellId = dbo.Wells.Id)
                               ORDER BY Md DESC) AS LastNorth,
                             (SELECT        TOP (1) East
                               FROM            dbo.Well_Trajectory AS Well_Trajectory_3
                               WHERE        (WellId = dbo.Wells.Id)
                               ORDER BY Md DESC) AS LastEast,
                             (SELECT        TOP (1) Tvd
                               FROM            dbo.Well_Trajectory AS Well_Trajectory_2
                               WHERE        (WellId = dbo.Wells.Id)
                               ORDER BY Md DESC) AS LastTvd, MAX(dbo.Wells.Status) AS Status, MAX(dbo.Wells.Type) AS Type, MAX(dbo.Wells.StringType) AS StringType
FROM            dbo.Production_Data AS Production_Data_1 RIGHT OUTER JOIN
                         dbo.Wells ON Production_Data_1.WellId = dbo.Wells.Id LEFT OUTER JOIN
                         dbo.Well_Schematic AS Well_Schematic_1 ON dbo.Wells.Id = Well_Schematic_1.WellId LEFT OUTER JOIN
                         dbo.Well_Trajectory AS Well_Trajectory_1 ON dbo.Wells.Id = Well_Trajectory_1.WellId
GROUP BY dbo.Wells.Id
GO

IF NOT EXISTS (SELECT * FROM sys.fn_listextendedproperty(N'MS_DiagramPane1' , N'SCHEMA',N'dbo', N'VIEW',N'Well_Summary_View', NULL,NULL))
	EXEC sys.sp_addextendedproperty @name=N'MS_DiagramPane1', @value=N'[0E232FF0-B466-11cf-A24F-00AA00A3EFFF, 1.00]
Begin DesignProperties = 
   Begin PaneConfigurations = 
      Begin PaneConfiguration = 0
         NumPanes = 4
         Configuration = "(H (1[40] 4[20] 2[20] 3) )"
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
               Top = 6
               Left = 38
               Bottom = 136
               Right = 236
            End
            DisplayFlags = 280
            TopColumn = 0
         End
         Begin Table = "Wells"
            Begin Extent = 
               Top = 6
               Left = 274
               Bottom = 136
               Right = 460
            End
            DisplayFlags = 280
            TopColumn = 0
         End
         Begin Table = "Well_Schematic_1"
            Begin Extent = 
               Top = 6
               Left = 498
               Bottom = 136
               Right = 684
            End
            DisplayFlags = 280
            TopColumn = 0
         End
         Begin Table = "Well_Trajectory_1"
            Begin Extent = 
               Top = 6
               Left = 722
               Bottom = 136
               Right = 908
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
      Begin ColumnWidths = 21
         Width = 284
         Width = 1500
         Width = 1500
         Width = 1500
         Width = 1500
         Width = 1500
         Width = 1500
         Width = 1500
         Width = 1500
         Width = 1500
         Width = 1500
         Width = 1500
         Width = 1500
         Width = 1500
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
         Column ' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'VIEW',@level1name=N'Well_Summary_View'
ELSE
BEGIN
	EXEC sys.sp_updateextendedproperty @name=N'MS_DiagramPane1', @value=N'[0E232FF0-B466-11cf-A24F-00AA00A3EFFF, 1.00]
Begin DesignProperties = 
   Begin PaneConfigurations = 
      Begin PaneConfiguration = 0
         NumPanes = 4
         Configuration = "(H (1[40] 4[20] 2[20] 3) )"
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
               Top = 6
               Left = 38
               Bottom = 136
               Right = 236
            End
            DisplayFlags = 280
            TopColumn = 0
         End
         Begin Table = "Wells"
            Begin Extent = 
               Top = 6
               Left = 274
               Bottom = 136
               Right = 460
            End
            DisplayFlags = 280
            TopColumn = 0
         End
         Begin Table = "Well_Schematic_1"
            Begin Extent = 
               Top = 6
               Left = 498
               Bottom = 136
               Right = 684
            End
            DisplayFlags = 280
            TopColumn = 0
         End
         Begin Table = "Well_Trajectory_1"
            Begin Extent = 
               Top = 6
               Left = 722
               Bottom = 136
               Right = 908
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
      Begin ColumnWidths = 21
         Width = 284
         Width = 1500
         Width = 1500
         Width = 1500
         Width = 1500
         Width = 1500
         Width = 1500
         Width = 1500
         Width = 1500
         Width = 1500
         Width = 1500
         Width = 1500
         Width = 1500
         Width = 1500
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
         Column ' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'VIEW',@level1name=N'Well_Summary_View'
END
GO

IF NOT EXISTS (SELECT * FROM sys.fn_listextendedproperty(N'MS_DiagramPane2' , N'SCHEMA',N'dbo', N'VIEW',N'Well_Summary_View', NULL,NULL))
	EXEC sys.sp_addextendedproperty @name=N'MS_DiagramPane2', @value=N'= 1440
         Alias = 900
         Table = 1170
         Output = 720
         Append = 1400
         NewValue = 1170
         SortType = 1350
         SortOrder = 1410
         GroupBy = 1350
         Filter = 1350
         Or = 1350
         Or = 1350
         Or = 1350
      End
   End
End
' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'VIEW',@level1name=N'Well_Summary_View'
ELSE
BEGIN
	EXEC sys.sp_updateextendedproperty @name=N'MS_DiagramPane2', @value=N'= 1440
         Alias = 900
         Table = 1170
         Output = 720
         Append = 1400
         NewValue = 1170
         SortType = 1350
         SortOrder = 1410
         GroupBy = 1350
         Filter = 1350
         Or = 1350
         Or = 1350
         Or = 1350
      End
   End
End
' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'VIEW',@level1name=N'Well_Summary_View'
END
GO

IF NOT EXISTS (SELECT * FROM sys.fn_listextendedproperty(N'MS_DiagramPaneCount' , N'SCHEMA',N'dbo', N'VIEW',N'Well_Summary_View', NULL,NULL))
	EXEC sys.sp_addextendedproperty @name=N'MS_DiagramPaneCount', @value=2 , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'VIEW',@level1name=N'Well_Summary_View'
ELSE
BEGIN
	EXEC sys.sp_updateextendedproperty @name=N'MS_DiagramPaneCount', @value=2 , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'VIEW',@level1name=N'Well_Summary_View'
END
GO

