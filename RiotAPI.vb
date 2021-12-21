Imports System.Net
Imports System.Web
Imports System.IO
Imports System.Reflection
Imports Newtonsoft.Json.Linq
Imports System.Xml
Imports Newtonsoft

Public Class RiotAPI
    Shared key As String
    Shared apiVersion As Integer
    Shared dt As String = DateTime.Now.ToString("yyyy-MM-dd HH-mm-ss")
    Shared methodName As String
    Shared API_URL_PLATFORM As String = "https://{0}.api.riotgames.com/lol/platform/v{1}/"
    Shared API_URL_CHAMPION_MASTERY As String = "https://{0}.api.riotgames.com/lol/champion-mastery/v{1}/"
    Shared API_URL_SPECTATOR As String = "https://{0}.api.riotgames.com/lol/spectator/v{1}/"
    Shared API_URL_STATIC As String = "https://{0}.api.riotgames.com/lol/static-data/v{1}/"
    Shared API_URL_MATCH As String = "https://{0}.api.riotgames.com/lol/match/v{1}/"
    Shared API_URL_LEAGUE As String = "https://{0}.api.riotgames.com/lol/league/v{1}/"
    Shared API_URL_SUMMONER As String = "https://{0}.api.riotgames.com/lol/summoner/v{1}/"

    Public Sub New(apiKey As String, apiver As Integer)
        key = apiKey
        apiVersion = apiver
    End Sub


#Region "Misc"
    Shared Sub AddCache(url As String)
        'Dim file As System.IO.StreamWriter
        'File = My.Computer.FileSystem.OpenTextFileWriter("Cache/" & dt & "-" & methodName & ".json", True)
        'File.WriteLine(JValue.Parse(request(url)).ToString(Formatting.Indented))
        'File.Close()
    End Sub
    Public Shared Function request(ByVal url As String) As String
        Dim req As WebRequest = WebRequest.Create(url)
        req.Headers.Add("X-Riot-Token", key)
        Dim res As System.Net.WebResponse = req.GetResponse()
        Using stream As System.IO.Stream = res.GetResponseStream()
            Dim sr As New System.IO.StreamReader(stream, Text.Encoding.GetEncoding("utf-8"))
            Dim r = sr.ReadToEnd()
            Return r
        End Using
    End Function

    Public Shared Function getChampions(patch As String) As Champions
        Dim req As WebRequest = WebRequest.Create("http://ddragon.leagueoflegends.com/cdn/" & patch & "/data/en_US/champion.json")
        Dim res As System.Net.WebResponse = req.GetResponse()
        Using stream As System.IO.Stream = res.GetResponseStream()
            Dim sr As New System.IO.StreamReader(stream, Text.Encoding.GetEncoding("utf-8"))
            Dim r As String = sr.ReadToEnd()
            Return Newtonsoft.Json.JsonConvert.DeserializeObject(Of Champions)(r)
        End Using
    End Function

    Public Function getAllGameData() As AllGameDataDTO
        System.Net.ServicePointManager.ServerCertificateValidationCallback = Function(senderX, certificate, chain, sslPolicyErrors)
                                                                                 Return True
                                                                             End Function
        Dim req As WebRequest = WebRequest.Create("https://127.0.0.1:2999/liveclientdata/allgamedata")
        Dim res As System.Net.WebResponse = req.GetResponse()

        Using stream As System.IO.Stream = res.GetResponseStream()
            Dim sr As New System.IO.StreamReader(stream, Text.Encoding.GetEncoding("utf-8"))
            Dim r As String = sr.ReadToEnd()
            Return Newtonsoft.Json.JsonConvert.DeserializeObject(Of AllGameDataDTO)(r)
        End Using
    End Function

    Public Function getVersion() As List(Of String)
        Dim req As WebRequest = WebRequest.Create("https://ddragon.leagueoflegends.com/api/versions.json")
        Dim res As System.Net.WebResponse = req.GetResponse()
        Using stream As System.IO.Stream = res.GetResponseStream()
            Dim sr As New System.IO.StreamReader(stream, Text.Encoding.GetEncoding("utf-8"))
            Dim r As String = sr.ReadToEnd()
            Return Newtonsoft.Json.JsonConvert.DeserializeObject(Of List(Of String))(r)
        End Using
    End Function
#End Region


#Region "Summoner"
    Public Function GetSummonerByName(ByVal name As String, ByVal platform As String) As SummonerDTO
        Dim api_call As String = "summoners/by-name/" & name & ""
        Dim url As String = String.Format(API_URL_SUMMONER, platform, apiVersion) + api_call
        methodName = System.Reflection.MethodBase.GetCurrentMethod().Name
        AddCache(url)
        Return Json.JsonConvert.DeserializeObject(Of SummonerDTO)(request(url))
    End Function

    Public Function GetSummoners(encryptedSummonerId As String, ByVal platform As String) As SummonerDTO
        Dim api_call = "summoners/"
        Dim url As String = String.Format(API_URL_SUMMONER, platform, apiVersion) + api_call + encryptedSummonerId
        methodName = System.Reflection.MethodBase.GetCurrentMethod().Name
        AddCache(url)
        Return Newtonsoft.Json.JsonConvert.DeserializeObject(Of SummonerDTO)(request(url))
    End Function

    Public Function GetSummonersByAccount(encryptedAccountId As String, ByVal platform As String) As SummonerDTO
        Dim api_call = "summoners/by-account/"
        Dim url As String = String.Format(API_URL_SUMMONER, platform, apiVersion) + api_call + encryptedAccountId
        methodName = System.Reflection.MethodBase.GetCurrentMethod().Name
        AddCache(url)
        Return Newtonsoft.Json.JsonConvert.DeserializeObject(Of SummonerDTO)(request(url))
    End Function

    Public Function GetSummonersByPUUID(encryptedPUUID As String, ByVal platform As String) As SummonerDTO
        Dim api_call = "summoners/by-puuid/"
        Dim url As String = String.Format(API_URL_SUMMONER, platform, apiVersion) + api_call + encryptedPUUID
        methodName = System.Reflection.MethodBase.GetCurrentMethod().Name
        AddCache(url)
        Return Newtonsoft.Json.JsonConvert.DeserializeObject(Of SummonerDTO)(request(url))
    End Function
#End Region


#Region "Matches"
    Public Function GetMatches(matchId As String, ByVal platform As String) As MatchDTO
        Dim api_call = "matches/"
        Dim url = String.Format(API_URL_MATCH, platform, apiVersion) + api_call + matchId
        methodName = System.Reflection.MethodBase.GetCurrentMethod().Name
        AddCache(url)
        Return Newtonsoft.Json.JsonConvert.DeserializeObject(Of MatchDTO)(request(url))
    End Function

    Public Function GetMatchlistsByAccountID(encryptedAccountId As String, ByVal platform As String)
        Dim api_call = "matchlists/by-account/"
        Dim url = String.Format(API_URL_MATCH, platform, apiVersion) + api_call + encryptedAccountId
        methodName = System.Reflection.MethodBase.GetCurrentMethod().Name
        AddCache(url)
        Return Newtonsoft.Json.JsonConvert.DeserializeObject(request(url))
    End Function

    Public Function GetTimelinesByMatch(matchId As String, ByVal platform As String) As MatchTimelineDTO
        Dim api_call = "timelines/by-match/"
        Dim url = String.Format(API_URL_MATCH, platform, apiVersion) + api_call + matchId
        methodName = System.Reflection.MethodBase.GetCurrentMethod().Name
        AddCache(url)
        Return Newtonsoft.Json.JsonConvert.DeserializeObject(Of MatchTimelineDTO)(request(url))
    End Function
#End Region


#Region "Champion Mastery"
    Public Function GetChampionMasteryBySummoner(encryptedSummonerId As String, ByVal platform As String) As List(Of ChampionMasteryDTO)
        Dim api_call = "champion-masteries/by-summoner/"
        Dim url = String.Format(API_URL_CHAMPION_MASTERY, platform, apiVersion) + api_call + encryptedSummonerId
        methodName = System.Reflection.MethodBase.GetCurrentMethod().Name
        AddCache(url)
        Return Newtonsoft.Json.JsonConvert.DeserializeObject(Of List(Of ChampionMasteryDTO))(request(url))

    End Function

    Public Function GetChampionMasteryBySummonerAndChampionId(encryptedSummonerId As String, championId As Integer, ByVal platform As String) As ChampionMasteryDTO
        Dim api_call = "champion-masteries/by-summoner/" + encryptedSummonerId + "/by-champion/" + championId.ToString
        Dim url = String.Format(API_URL_CHAMPION_MASTERY, platform, apiVersion) + api_call
        methodName = System.Reflection.MethodBase.GetCurrentMethod().Name
        AddCache(url)
        Return Newtonsoft.Json.JsonConvert.DeserializeObject(Of ChampionMasteryDTO)(request(url))
    End Function

    Public Function GetScoresBySummoner(encryptedSummonerId As String) As Integer
        Dim api_call = "scores/by-summoner/" + encryptedSummonerId
        Dim url = API_URL_CHAMPION_MASTERY + api_call
        methodName = System.Reflection.MethodBase.GetCurrentMethod().Name
        AddCache(url)
        Return request(url)
    End Function
#End Region


#Region "League"
    Public Function GetLeagueBySummonerID(ByVal id As String, ByVal platform As String)
        Dim api_call As String = "entries/by-summoner/" & id & ""
        Dim url As String = String.Format(API_URL_LEAGUE, platform, apiVersion) + api_call
        methodName = System.Reflection.MethodBase.GetCurrentMethod().Name
        AddCache(url)
        Return Newtonsoft.Json.JsonConvert.DeserializeObject(Of List(Of LeagueEntryDTO))(request(url))
    End Function
#End Region


#Region "Spectator"
    Public Function SpectateActiveGame(ByVal id As String, ByVal platform As String) As CurrentGameInfoDTO
        Dim api_call As String = "active-games/by-summoner/" & id & ""
        Dim url As String = String.Format(API_URL_SPECTATOR, platform, apiVersion) + api_call
        methodName = System.Reflection.MethodBase.GetCurrentMethod().Name
        AddCache(url)
        Return Json.JsonConvert.DeserializeObject(Of CurrentGameInfoDTO)(request(url))
    End Function
#End Region

End Class
