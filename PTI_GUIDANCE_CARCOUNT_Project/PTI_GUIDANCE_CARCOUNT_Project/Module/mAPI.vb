Option Strict Off
Option Explicit On
Module mAPI
	

	Public aCompanyName As String
	Public aAddress As String
	Public aDistrict As String
	Public aProvince As String
	Public aZipcode As String
	Public aPhone As String
	Public aFax As String
	
	
	
	
	Public Structure RGBTriplet
		Dim rgbBlue As Byte
		Dim rgbGreen As Byte
		Dim rgbRed As Byte
	End Structure
	
	Public Structure BITMAP
		Dim bmType As Integer
		Dim bmWidth As Integer
		Dim bmHeight As Integer
		Dim bmWidthBytes As Integer
		Dim bmPlanes As Short
		Dim bmBitsPixel As Short
		Dim bmBits As Integer
        Private _p1 As Integer
        Private _p2 As Integer
        Private _pixelFormat As Imaging.PixelFormat

        Sub New(p1 As Integer, p2 As Integer, pixelFormat As Imaging.PixelFormat)
            ' TODO: Complete member initialization 
            _p1 = p1
            _p2 = p2
            _pixelFormat = pixelFormat
        End Sub

    End Structure

	
	
	Public Const LOCALE_SSHORTDATE As Short = &H1Fs
	Public Const LOCALE_SLONGDATE As Short = &H20s
	Public Const LOCALE_STIMEFORMAT As Short = &H1003s
	
	Public Declare Function GetLocaleInfo Lib "kernel32"  Alias "GetLocaleInfoA"(ByVal Locale As Integer, ByVal LCType As Integer, ByVal lpLCData As String, ByVal cchData As Integer) As Integer
	Public Declare Function GetSystemDefaultLCID Lib "kernel32" () As Integer
	Public Declare Function SetLocaleInfo Lib "kernel32"  Alias "SetLocaleInfoA"(ByVal Locale As Integer, ByVal LCType As Integer, ByVal lpLCData As String) As Integer
	
	Public Declare Function GetComputerName Lib "kernel32"  Alias "GetComputerNameA"(ByVal lpBuffer As String, ByRef nSize As Integer) As Integer
    'Public Declare Function GetPrivateProfileString Lib "kernel32" Alias "GetPrivateProfileStringA" (ByVal lpApplicationName As String, ByVal lpKeyName As Any, ByVal lpDefault As String, ByVal lpReturnedString As String, ByVal nSize As Integer, ByVal lpFileName As String) As Integer
    'Public Declare Function WritePrivateProfileString Lib "kernel32" Alias "WritePrivateProfileStringA" (ByVal lpApplicationName As String, ByVal lpKeyName As Any, ByVal lpString As Any, ByVal lpFileName As String) As Integer
    Public Declare Ansi Function GetPrivateProfileString Lib "kernel32.dll" Alias "GetPrivateProfileStringA" (ByVal lpApplicationName As String, ByVal lpKeyName As String, ByVal lpDefault As String, ByVal lpReturnedString As System.Text.StringBuilder, ByVal nSize As Integer, ByVal lpFileName As String) As Integer
    Public Declare Ansi Function WritePrivateProfileString Lib "kernel32.dll" Alias "WritePrivateProfileStringA" (ByVal lpApplicationName As String, ByVal lpKeyName As String, ByVal lpString As String, ByVal lpFileName As String) As Integer
    Public Declare Function GetPrivateProfileSection Lib "kernel32" Alias "GetPrivateProfileSectionA" (ByVal lpAppName As String, ByVal lpReturnedString As String, ByVal nSize As Integer, ByVal lpFileName As String) As Integer
    Public Declare Function WritePrivateProfileSection Lib "kernel32" Alias "WritePrivateProfileSectionA" (ByVal lpAppName As String, ByVal lpString As String, ByVal lpFileName As String) As Integer


	Public Const GWL_EXSTYLE As Short = (-20)
	Public Const WS_EX_LAYERED As Integer = &H80000
	Public Const LWA_ALPHA As Short = &H2s
	
	Public Declare Function FindWindow Lib "user32"  Alias "FindWindowA"(ByVal lpClassName As String, ByVal lpWindowName As String) As Integer
	Public Declare Function SetParent Lib "user32" (ByVal hWndChild As Integer, ByVal hWndNewParent As Integer) As Integer
	



#If DEBUG_PRINT_BITMAP Then
		Debug.Print "*** BITMAP Data ***"
		Debug.Print "bmType       "; bm.bmType
		Debug.Print "bmWidth      "; bm.bmWidth
		Debug.Print "bmHeight     "; bm.bmHeight
		Debug.Print "bmWidthBytes "; bm.bmWidthBytes
		Debug.Print "bmPlanes     "; bm.bmPlanes
		Debug.Print "bmBitsPixel  "; bm.bmBitsPixel
		Debug.Print "BitsPerPixel "; bits_per_pixel
#End If

    Function Get_Section(ByVal pSec As String, ByVal pFile As String, ByRef pVal As String) As Boolean
        Dim a As Long, aBuff As New System.Text.StringBuilder(500)
        Dim nResult As String = Space(5000)

        On Error GoTo Err
        a = GetPrivateProfileSection(pSec, nResult, 500, pFile)
        If a > 0 Then
            pVal = Left(nResult.ToString, a)
            Get_Section = True
        Else
            Get_Section = False
        End If

        Exit Function

Err:
        Get_Section = False
        Call mError.WriteError("mMain", "Get_Section Return = " & a, Err.Number, Err.Description)
    End Function

    Function Get_Config(ByVal pSec As String, ByVal pKey As String, ByVal pFile As String, ByRef pVal As String) As Boolean
        Dim a As Long, aBuff As New System.Text.StringBuilder(500)
        Dim nResult As New System.Text.StringBuilder(500)

        On Error GoTo Err
        a = GetPrivateProfileString(pSec, pKey, "", nResult, 500, pFile)
        If a > 0 Then
            pVal = Left(nResult.ToString, a)
            Get_Config = True
        Else
            Get_Config = False
        End If

        Exit Function

Err:
        Get_Config = False
        Call mError.WriteError("mMain", "Get_Config Return = " & a, Err.Number, Err.Description)
    End Function

    Function Write_Config(ByVal pSec As String, ByVal pKey As String, ByVal pFile As String, ByVal pVal As String) As Boolean
        Dim a As Long, aBuff As New System.Text.StringBuilder(500)
        On Error GoTo Err
        a = WritePrivateProfileString(pSec, pKey, pVal, pFile)
        If a > 0 Then
            Write_Config = True
        Else
            Write_Config = False
        End If
        Exit Function

Err:
        Write_Config = False
        Call mError.WriteError("mMain", "Set_Config Return = " & a, Err.Number, Err.Description)
    End Function

    Function SetLongDateFormat(ByRef aFormat As String) As Boolean
        Dim sReturn As String = ""
        Dim r As Integer
        Dim LCID As Integer
        LCID = GetSystemDefaultLCID()
        r = GetLocaleInfo(LCID, LOCALE_SLONGDATE, sReturn, Len(sReturn))
        If r Then
            sReturn = Space(r)
            r = GetLocaleInfo(LCID, LOCALE_SLONGDATE, sReturn, Len(sReturn))
            If r Then
                If Left(sReturn, r - 1) <> aFormat Then
                    Call SetLocaleInfo(LCID, LOCALE_SLONGDATE, aFormat)
                End If
            End If
        End If

    End Function

    Function SetShortDateFormat(ByRef aFormat As String) As Boolean
        Dim sReturn As String = ""
        Dim r As Integer
        Dim LCID As Integer
        LCID = GetSystemDefaultLCID()
        r = GetLocaleInfo(LCID, LOCALE_SSHORTDATE, sReturn, Len(sReturn))
        If r Then
            sReturn = Space(r)
            r = GetLocaleInfo(LCID, LOCALE_SSHORTDATE, sReturn, Len(sReturn))
            If r Then
                If Left(sReturn, r - 1) <> aFormat Then
                    Call SetLocaleInfo(LCID, LOCALE_SSHORTDATE, aFormat)
                End If
            End If
        End If

    End Function

    Function SetTimeFormat(ByRef aFormat As String) As Boolean
        Dim sReturn As String = ""
        Dim r As Integer
        Dim LCID As Integer
        LCID = GetSystemDefaultLCID()
        r = GetLocaleInfo(LCID, LOCALE_STIMEFORMAT, sReturn, Len(sReturn))
        If r Then
            sReturn = Space(r)
            r = GetLocaleInfo(LCID, LOCALE_STIMEFORMAT, sReturn, Len(sReturn))
            If r Then
                If Left(sReturn, r - 1) <> aFormat Then
                    Call SetLocaleInfo(LCID, LOCALE_STIMEFORMAT, aFormat)
                End If
            End If
        End If

    End Function


End Module