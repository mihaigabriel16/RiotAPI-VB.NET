
Public Class LeagueEntryDTO
    Public Property leagueId As String
    Public Property summonerId As String
    Public Property summonerName As String
    Public Property queueType As String
    Public Property tier As String
    Public Property rank As String
    Public Property leaguePoints As Integer
    Public Property wins As Integer
    Public Property losses As Integer
    Public Property hotStreak As Boolean
    Public Property veteran As Boolean
    Public Property freshBlood As Boolean
    Public Property inactive As Boolean
    Public Property miniSeries As MiniSeriesDTO
End Class



Public Class MiniSeriesDTO
    Public Property losses As Integer
    Public Property progress As String
    Public Property target As Integer
    Public Property wins As Integer
End Class

