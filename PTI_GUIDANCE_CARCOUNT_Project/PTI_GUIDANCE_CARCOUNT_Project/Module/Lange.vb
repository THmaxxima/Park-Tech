Imports System.Windows.Forms
Imports System.Xml
Imports System.Data
Module Lange
    Dim cdb As New CDatabase
    Public msg_save(1) As String
    Public msg_update(1) As String
    Public msg_delete(1) As String
    Public lang_ As String = "TH"




    Public quetion_Delete, msg_Login_fail, msg_login_Cancel As String

    Public main_Text(50) As String
    Public Sub Load_Lange_label(ByRef form_ As Form, ByRef label_ As Label)
        Dim sql As String = ""
        sql = "SELECT [Lang_Select] FROM [LANG_Select] WHERE [Id_]='1'"
        Dim dt As DataTable = cdb.readTableData(sql, ConStr_Master)
        If dt.Rows.Count > 0 Then
            read_LANG_Label(dt.Rows(0).Item(0).ToString, form_, label_)
        End If
    End Sub

    Public Sub read_LANG_Label(ByVal lang_column As String, ByRef form_ As Form, ByRef label_ As Label)
        Dim sql As String = ""
        If lang_column = "" Then lang_column = "TH"

        sql = "SELECT Label_name," & lang_column & " FROM LANG_Discription WHERE [Form_name]='" & form_.Name & "'"
        Dim dt As DataTable = cdb.readTableData(sql, ConStr_Master)

        If dt.Rows.Count > 0 Then
            For i As Integer = 0 To dt.Rows.Count - 1
                If dt.Rows(i).Item(0).ToString.Trim = label_.Name Then
                    label_.Text = dt.Rows(i).Item(1).ToString.Trim
                End If
            Next
        End If
    End Sub

    Public Sub Load_Lange_button(ByRef form_ As Form, ByRef btn_ As Button)
        Dim sql As String = ""
        sql = "SELECT [Lang_Select] FROM [LANG_Select] WHERE [Id_]='1'"
        Dim dt As DataTable = cdb.readTableData(sql, ConStr_Master)
        If dt.Rows.Count > 0 Then
            read_LANG_button(dt.Rows(0).Item(0).ToString, form_, btn_)
        End If
    End Sub

    Public Sub read_LANG_button(ByVal lang_column As String, ByRef form_ As Form, ByRef btn_ As Button)
        Dim sql As String = ""
        If lang_column = "" Then lang_column = "TH"

        sql = "SELECT Label_name," & lang_column & " FROM LANG_Discription WHERE [Form_name]='" & form_.Name & "'"
        Dim dt As DataTable = cdb.readTableData(sql, ConStr_Master)

        If dt.Rows.Count > 0 Then
            For i As Integer = 0 To dt.Rows.Count - 1
                If dt.Rows(i).Item(0).ToString.Trim = btn_.Name Then
                    btn_.Text = dt.Rows(i).Item(1).ToString.Trim
                End If
            Next
        End If
    End Sub


    Public Sub read_LANG_obj(ByVal lang_column As String, ByRef form_ As Form, ByRef btn_ As Object)
        Dim sql As String = ""
        If lang_column = "" Then lang_column = "TH"

        sql = "SELECT Label_name," & lang_column & " FROM LANG_Discription WHERE [Form_name]='" & form_.Name & "' and Label_name='" & btn_.Name & "'"
        Dim dt As DataTable = cdb.readTableData(sql, ConStr_Master)

        If dt.Rows.Count > 0 Then
            btn_.Text = dt.Rows(i).Item(1).ToString.Trim
        End If

    End Sub


    Sub load_xml_Lang(ByVal file_path As String, ByVal lange_type As String)
        Dim xmlFile As XmlReader
        Dim ds As New DataSet

        xmlFile = XmlReader.Create(file_path, New XmlReaderSettings())
        ds.ReadXml(xmlFile)
        Dim i As Integer
        For i = 0 To ds.Tables(0).Rows.Count - 1
            If ds.Tables(0).Rows(i).Item("Product_name") = lange_type Then
                msg_save(0) = ds.Tables(0).Rows(i).Item("Product_save0")
                msg_save(1) = ds.Tables(0).Rows(i).Item("Product_save1")

                msg_update(0) = ds.Tables(0).Rows(i).Item("Product_update0")
                msg_update(1) = ds.Tables(0).Rows(i).Item("Product_update1")

                msg_delete(0) = ds.Tables(0).Rows(i).Item("Product_delete0")
                msg_delete(1) = ds.Tables(0).Rows(i).Item("Product_delete1")

                quetion_Delete = ds.Tables(0).Rows(i).Item("Product_qdelete")
                msg_Login_fail = ds.Tables(0).Rows(i).Item("Product_qflogin")
                msg_login_Cancel = ds.Tables(0).Rows(i).Item("Product_qcancel")


                main_Text(0) = ds.Tables(0).Rows(i).Item("Main_GroupPanel1")
                main_Text(1) = ds.Tables(0).Rows(i).Item("Main_GroupPanel2")
                main_Text(2) = ds.Tables(0).Rows(i).Item("Main_Label79")
                main_Text(3) = ds.Tables(0).Rows(i).Item("Main_lbl_Alam_Status_Sensor")
                main_Text(4) = ds.Tables(0).Rows(i).Item("Main_lbl_HH_Alert")
                main_Text(5) = ds.Tables(0).Rows(i).Item("Main_Label3")
                main_Text(6) = ds.Tables(0).Rows(i).Item("Main_lbl_HH")
                main_Text(7) = ds.Tables(0).Rows(i).Item("Main_lbl_Value")


                main_Text(8) = ds.Tables(0).Rows(i).Item("Main_DGV_Mas_floor0")
                main_Text(9) = ds.Tables(0).Rows(i).Item("Main_DGV_Mas_floor1")
                main_Text(10) = ds.Tables(0).Rows(i).Item("Main_DGV_Mas_floor2")
                main_Text(11) = ds.Tables(0).Rows(i).Item("Main_DGV_Mas_floor3")
                main_Text(12) = ds.Tables(0).Rows(i).Item("Main_DGV_Mas_floor4")
                main_Text(13) = ds.Tables(0).Rows(i).Item("Main_DGV_Mas_floor5")
                main_Text(14) = ds.Tables(0).Rows(i).Item("Main_DGV_Mas_floor6")
                main_Text(15) = ds.Tables(0).Rows(i).Item("Main_DGV_Mas_floor7")
            End If
        Next
    End Sub
   
    Public Sub Load_msg(ByVal lang_ As String)
        If lang_ = "TH" Then
            load_xml_Lang("lang\th.xml", "TH")
        End If
        If lang_ = "EN" Then
            load_xml_Lang("lang\en.xml", "EN")
        End If
    End Sub
End Module
