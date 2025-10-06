Public Class Validation

    Shared Function validate_experssion(ByVal value As String) As Boolean


        Return System.Text.RegularExpressions.Regex.IsMatch(value, "[\']|[\;]|[\/*|\|]|[\*/|=]|[\+]|(--)|(___)|(%)|(%%)")


    End Function

End Class


