Imports System
Imports System.Collections.Generic
Imports System.Threading

Namespace WebDesigner_DataLoading
    Public Class SalesPersonData
        Public Property SalesPerson() As String
        Public Property Quantity() As Integer

        Public Shared Function CreateData() As List(Of SalesPersonData)

            Dim data As New List(Of SalesPersonData)()
            Dim salesPersons() As String = {"Andrew Fuller", "Michael Suyama",
                                            "Robert King", "Nancy Davolio",
                                            "Margaret Peacock", "Laura Callahan",
                                            "Steven Buchanan", "Janet Leverling"}

            For i As Integer = 0 To 99
                Dim record As New SalesPersonData()
                Dim seed As Long = CLng(Date.Now.Ticks) And &HFFFF
                record.SalesPerson = salesPersons((New Random(seed)).Next(0, salesPersons.Length))
                record.Quantity = (New Random(seed)).Next(0, 100)
                data.Add(record)
                Thread.Sleep(3)
            Next i
            Return data
        End Function
    End Class
End Namespace