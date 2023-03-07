Imports Microsoft.VisualBasic
Imports System
Imports System.Data
Imports System.Configuration
Imports System.Collections
Imports System.Web
Imports System.Web.Security
Imports System.Web.UI
Imports System.Web.UI.WebControls
Imports System.Web.UI.WebControls.WebParts
Imports System.Web.UI.HtmlControls
Imports System.Collections.Generic
Imports DevExpress.Web

Namespace GetSelectedValuesAllColumns
	Partial Public Class _Default
		Inherits System.Web.UI.Page
		Protected Sub Page_Init(ByVal sender As Object, ByVal e As EventArgs)
			ASPxGridView1.DataSource = GetData()
			ASPxGridView1.KeyFieldName = "ID"
			ASPxGridView1.SettingsBehavior.AllowSelectByRowClick = True
			ASPxGridView1.DataBind()

			If (Not IsPostBack) AndAlso (Not IsCallback) Then
				ASPxGridView1.Columns(ASPxGridView1.KeyFieldName).Visible = False
			End If
		End Sub

		Private Function GetData() As DataTable
			Dim table As New DataTable()
			table.Columns.Add("ID", GetType(Integer))
			table.Columns.Add("Name", GetType(String))
			table.Columns.Add("Date", GetType(DateTime))
			table.Columns.Add("IsActive", GetType(Boolean))
			For i As Integer = 0 To 9
				table.Rows.Add(i, "Item " & i.ToString(), DateTime.Now.AddDays(i), i Mod 2 = 0)
			Next i
			Return table
		End Function
		Protected Sub ASPxButton1_Click(ByVal sender As Object, ByVal e As EventArgs)
			GetSelectedValues()
			PrintSelectedValues()
		End Sub


		Private selectedValues As List(Of Object)

		Private Sub GetSelectedValues()
			Dim fieldNames As List(Of String) = New List(Of String)()
			For Each column As GridViewColumn In ASPxGridView1.Columns
				If TypeOf column Is GridViewDataColumn Then
					fieldNames.Add((CType(column, GridViewDataColumn)).FieldName)
				End If
			Next column
			selectedValues = ASPxGridView1.GetSelectedFieldValues(fieldNames.ToArray())
		End Sub

		Private Sub PrintSelectedValues()
			If selectedValues Is Nothing Then
				Return
			End If
			Dim result As String = ""
			For Each item As Object() In selectedValues
				For Each value As Object In item
				   result &= String.Format("{0}&nbsp;&nbsp;&nbsp;&nbsp;", value)
				Next value
				result &= "</br>"
			Next item
			Literal1.Text = result
		End Sub
	End Class
End Namespace
