Option Explicit On
Module GlobalVariables

    Public Const Pi = 3.14159265359
    Public Const EncoderResolution = 726559
    Public Const SidConst = 1.00273790935

    Public Enum ProtokollMode
        Send = 0
        Receive = 1
    End Enum

    Public Structure MyDate
        Dim YY As Double
        Dim MM As Double
        Dim DD As Double
    End Structure

    Public Structure MyTime
        Dim TimeDec As Double
        Dim H As Double
        Dim M As Double
        Dim S As Double
    End Structure

    Public Structure GeoDegMinSec
        Dim deg As Double
        Dim Min As Double
        Dim Sec As Double
        Dim Sign As String
    End Structure

    Public Structure GeoCoordinates
        Dim Latitude As Double
        Dim Longitude As Double
    End Structure

    Public Structure Vector
        Dim X As Double
        Dim Y As Double
        Dim z As Double
    End Structure

    Public Structure RaDec
        Dim Ra As Double        ' Rectascension as randian
        Dim Dec As Double       ' Declination as radian
    End Structure

    Public Structure AzAlt
        Dim Az As Double        ' Azimut as randian
        Dim Alt As Double       ' Altitude as radian
    End Structure

    Public Structure StarDescription
        Dim Index As Long
        Dim ProperName As String
        Dim Bayer As String
        Dim Constellation As String
        Dim Flamsteed As String
        Dim Ra As Double
        Dim Dec As Double
        Dim Mag As Double
        Dim StarDsc1 As String
        Dim StarDsc2 As String
        Dim StarDsc3 As String
        Dim StarDsc4 As String
        Dim StarDsc5 As String
    End Structure





    Public SimOffline As Boolean
    Public ErrorCount As Long
    Public ManualMovement As Boolean
    Public DefaultPath As String
    Public DefaultStarKatalog As String
    Public CommFileName As String
    Public AlignmentStarArray() As StarDescription

    Public ReadStatus As Boolean
    Public StatusMoving As Integer


    Public ObserverDateTimeUT As Date
    Public ObserverTimeUT As MyTime
    Public ObserverLatt As GeoDegMinSec
    Public ObserverLong As GeoDegMinSec
    Public ObserverRaDec As RaDec
    Public ObserverAzAlt As AzAlt
    Public GlobalOffset As AzAlt


    ' Preview
    Public PreviewRaDec As RaDec
    Public PreviewAzAlt As AzAlt

    Public GlbSiderialTime As Double
    Public GlbOberverPos As GeoCoordinates

    ' Main Horizontal System für die Matrixmetode in [radian]
    ' mathematischer Sinn gegen den Uhtzeigersinn (CCW)
    Public MatrixSystemSoll As AzAlt        ' is calculated: RaDec ->AzAlt -> plus GlobalOffset ->MatrixSystemSoll
    Public MatrixSystemIst As AzAlt

    Public MotorIncrSystem As Double       ' Horizontalsystem in [Increments] 0..726559 [CW]
    Public AzAltSystem As Double           ' Horzontsystem in [radian] aus RA DEC berechnet


    '==== Calibration ====
    Public GlbCalibStatus As Integer        ' 0: not calibrated
    ' 1: 1 point calibration
    ' 2: 2 point calibration

    '==== Init Time ====
    Public Cal_InitTime As Double
    Public TransformationMatrix(10, 10) As Double
    Public TransformationMatrix__OLD(10, 10) As Double

    '==== Reference Star 1 ====
    Public Cal_RaStar_1 As Double
    Public Cal_DecStar_1 As Double
    Public Cal_Star_1_RaDec As RaDec

    Public Cal_TelHorizAngle_1 As Double
    Public Cal_TelElevAngle_1 As Double
    Public Cal_Tel_1_AzAlt As AzAlt
    Public Cal_Time_1 As Double

    '==== Reference Star 2 ====
    Public Cal_RaStar_2 As Double
    Public Cal_DecStar_2 As Double
    Public Cal_Star_2_RaDec As RaDec
    Public Cal_TelHorizAngle_2 As Double
    Public Cal_TelElevAngle_2 As Double
    Public Cal_Tel_2_AzAlt As AzAlt
    Public Cal_Time_2 As Double

    Public TrackingisON As Boolean
    Public DiffMotorIncr As AzAlt
    Public MatrixLastCalc As AzAlt
    Public MatrixDiffCalc As AzAlt
    Public MotorLastCalc As AzAlt
    Public MotorDiffCalc As AzAlt

    Public MatrixSystemDiffPerSec As AzAlt
    Public TrackingSpeed As AzAlt

    Public ReadComm As String
    Public NexStarCommand As String

    '=== Test Only ===
    Public LastVal As AzAlt
    Public JetztTime As Double




    '=== Communication Test ===
    Public TestCommHandheldToMotor As Boolean
    Public TestCommMotorToHandheld As Boolean
    Public NexStarChar1 As String
    Public NexStarChar2 As String
    Public NexStarChar3 As String

    '=== Visualisieung ===
    Public GlbScale As Double
    Public GlbCx As Double
    Public GlbCY As Double



End Module
