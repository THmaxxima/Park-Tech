Imports System.Drawing.Imaging
Imports System.IO

Module Mod_function
    Public Function ImgToByteArray(img As Image, imgFormat As ImageFormat) As Byte()
        Dim tmpData As Byte()
            Using ms As New MemoryStream()
                img.Save(ms, imgFormat)

                tmpData = ms.ToArray  'dispose of memstream
            End Using
            Return tmpData

    End Function

    'Public Function imgToByteArray(ByVal img As Image) As Byte()
    '    Using mStream As New MemoryStream()
    '        img.Save(mStream, img.RawFormat)
    '        Return mStream.ToArray()
    '    End Using
    'End Function

End Module
