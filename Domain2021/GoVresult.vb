Public Class AllDelegate
    Public Property GovNationalNo As Integer
    Public Property DelegateName As String
    Public Property StartDate As DateTime
    Public Property EndDate As DateTime
    Public Property DelegateNationalNo As String
    Public Property DelegateStatus As Integer
    Public Property Nationality As String
    Public Property Phone As String
    Public Property Email As String
    Public Property status As Boolean
End Class

Public Class GoVresult
    Public Property status As Boolean
    Public Property NationalNo As Integer
    Public Property Sector_name As String
    Public Property Sector_ID As Integer
    Public Property ParentID As Integer
    Public Property Phone As Object
    Public Property Name_En As String
    Public Property Name_Ar As String
    Public Property Email As String
    Public Property EntityStatus As String
    Public Property GovernateName As String
    Public Property GovernateID As Integer
    Public Property Address As String
    Public Property EntityType As Object
    Public Property EntityTypeID As Integer
    Public Property EntityStatus_ID As Integer
    Public Property allDelegates As List(Of AllDelegate)
End Class
