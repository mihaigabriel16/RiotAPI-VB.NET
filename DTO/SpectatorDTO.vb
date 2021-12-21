Public Class CurrentGameInfoDTO
    Public Property gameId As Long
    Public Property gameType As String
    Public Property gameStartTime As Long
    Public Property mapId As Long
    Public Property gameLenght As Long
    Public Property platformId As String
    Public Property gameMode As String
    Public Property bannedChampions As List(Of BannedChampionDTO)
    Public Property participants As List(Of CurrentGameParticipantDTO)
End Class

Public Class BannedChampionDTO
    Public Property pickTurn As Integer
    Public Property championId As Long
    Public Property teamId As Long
End Class

Public Class ObserverDTO
    Public Property encryptionKey As String
End Class

Public Class CurrentGameParticipantDTO
    Public Property championId As Long
    Public Property perks As PerksDTO
    Public Property profileIconId As Long
    Public Property bot As Boolean
    Public Property teamId As Long
    Public Property summonerName As String
    Public Property summonerId As String
    Public Property spell1Id As Long
    Public Property spell2Id As Long
    Public Property gameCustomizationObjects As List(Of GameCustomizationObjectDTO)
End Class

Public Class PerksDTO
    Public Property perkIds As List(Of Long)
    Public Property perkStyle As Long
    Public Property perkSubStyle As Long
End Class

Public Class GameCustomizationObjectDTO
    Public Property category As String
    Public Property content As String
End Class
