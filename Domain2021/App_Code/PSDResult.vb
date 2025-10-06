
Public Class RRoot
    Public Class Country
        Public Property VALUE As String
        Public Property A_DESCRIPTION As String
        Public Property E_DESCRIPTION As String
        Public Property PARENT_VALUE As Object
        Public Property LAST_UPDATE_DATE As String
        Public Property LAST_UPDATE_USER As String
        Public Property S_DBLINK As String
    End Class

    Public Class Datum
        Public Property ID As String
        Public Property FULL_NAME As Object
        Public Property E_FULL_NAME As String
        Public Property NAT_CNTRY_VALUE As String
        Public Property NATIONAL_ID_NO As String
        Public Property FIRST_NAME As String
        Public Property FATHER_NAME As Object
        Public Property GRAND_FNAME As Object
        Public Property FAMILY_NAME As String
        Public Property E_FIRST_NAME As String
        Public Property E_FATHER_NAME As Object
        Public Property E_GRAND_FNAME As Object
        Public Property E_FAMILY_NAME As String
        Public Property MOTHER_NAME As Object
        Public Property BIRTH_DATE As String
        Public Property GENDER As String
        Public Property MARITAL_STATUS As Object
        Public Property RELEGION_VALUE As String
        Public Property country As List(Of Country)
        Public Property arrival As List(Of Object)
        Public Property religions As List(Of Religion)
        Public Property residencies As List(Of Object)
        Public Property document As List(Of Document)
        Public Property departure As List(Of Object)
    End Class

    Public Class DocCountry
        Public Property VALUE As String
        Public Property A_DESCRIPTION As String
        Public Property E_DESCRIPTION As String
        Public Property PARENT_VALUE As Object
        Public Property LAST_UPDATE_DATE As String
        Public Property LAST_UPDATE_USER As String
        Public Property S_DBLINK As String
    End Class

    Public Class DocType
        Public Property VALUE As String
        Public Property A_DESCRIPTION As String
        Public Property E_DESCRIPTION As String
        Public Property PARENT_VALUE As Object
        Public Property LAST_UPDATE_DATE As String
        Public Property LAST_UPDATE_USER As String
        Public Property S_DBLINK As Object
    End Class

    Public Class Document
        Public Property ID As String
        Public Property PRS_ID As String
        Public Property SER_NO As String
        Public Property DOCTYP_VALUE As String
        Public Property CNTRY_VALUE As String
        Public Property DOC_NO As String
        Public Property ISSUE_DATE As Object
        Public Property EXPIRY_DATE As String
        Public Property ISSUE_PLACE As Object
        Public Property docCountry As DocCountry
        Public Property docType As DocType
    End Class

    Public Class Religion
        Public Property VALUE As String
        Public Property A_DESCRIPTION As String
        Public Property E_DESCRIPTION As String
        Public Property PARENT_VALUE As Object
        Public Property LAST_UPDATE_DATE As String
        Public Property LAST_UPDATE_USER As String
        Public Property S_DBLINK As String
    End Class

    Public Class Root
        Public Property status As Boolean
        Public Property message As String
        Public Property data As List(Of Datum)
    End Class

End Class