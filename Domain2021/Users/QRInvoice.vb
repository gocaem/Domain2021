Imports Newtonsoft.Json

Public Class EINVRESULTS
    <JsonProperty("status")>
    Public Property status As String

    <JsonProperty("INFO")>
    Public Property INFO As List(Of INFO)

    <JsonProperty("WARNINGS")>
    Public Property WARNINGS As List(Of Object)

    <JsonProperty("ERRORS")>
    Public Property ERRORS As List(Of Object)
End Class

Public Class INFO
    <JsonProperty("type")>
    Public Property type As String
    <JsonProperty("status")>
    Public Property status As String
    <JsonProperty("EINV_CODE")>
    Public Property EINV_CODE As String
    <JsonProperty("EINV_CATEGORY")>
    Public Property EINV_CATEGORY As String
    <JsonProperty("EINV_MESSAGE")>
    Public Property EINV_MESSAGE As String
End Class

Public Class Root
    <JsonProperty("EINV_RESULTS")>
    Public Property EINV_RESULTS As EINVRESULTS

    Public Property EINV_STATUS As String

    Public Property EINV_SINGED_INVOICE As String
    <JsonProperty("EINV_QR")>
    Public Property EINV_QR As String
    <JsonProperty("EINV_NUM")>
    Public Property EINV_NUM As String
    <JsonProperty("EINV_INV_UUID")>
    Public Property EINV_INV_UUID As String
End Class
