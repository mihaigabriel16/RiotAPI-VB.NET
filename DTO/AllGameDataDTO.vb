Public Class AllGameDataDTO
	Public Property activePlayer As ActivePlayer
	Public Property allPlayers As List(Of Player)
	Public Property events As ArrayEvent
	Public Property gameData As GameData
End Class

Public Class ArrayEvent
	Public Property Events As List(Of GameEvent)
End Class

Public Class GameEvent
	Public Property EventID As Integer
	Public Property EventName As String
	Public Property EventTime As Single
End Class

Public Class GameData
	Public Property gameMode As String
	Public Property gameTime As Single
	Public Property mapName As String
	Public Property mapNumber As Integer
	Public Property mapTerrain As String
End Class

Public Class Player
	Public Property championName As String
	Public Property isBot As Boolean
	Public Property isDead As Boolean
	Public Property items As List(Of Item)
	Public Property level As Integer
	Public Property position As String
	Public Property rawChampionName As String
	Public Property rawSkinName As String
	Public Property respawnTimer As Single
	Public Property runes As PlayerRunes
	Public Property scores As PlayerScores
	Public Property skinID As Integer
	Public Property skinName As String
	Public Property summonerName As String
	Public Property summonerSpells As SummonerSpells
	Public Property team As String
End Class

Public Class SummonerSpells
	Public Property summonerSpellOne As SummonerSpell
	Public Property summonerSpellTwo As SummonerSpell
End Class

Public Class SummonerSpell
	Public Property displayName As String
	Public Property rawDescription As String
	Public Property rawDisplayName As String
End Class

Public Class PlayerScores
	Public Property assists As Integer
	Public Property creepScore As Integer
	Public Property deaths As Integer
	Public Property kills As Integer
	Public Property wardScore As Single
End Class

Public Class PlayerRunes
	Public Property keystone As GeneralRune
	Public Property primaryRuneTree As GeneralRune
	Public Property secondaryRuneTree As GeneralRune
End Class

Public Class Item
	Public Property canUse As Boolean
	Public Property consumable As Boolean
	Public Property count As Integer
	Public Property displayName As String
	Public Property itemID As Integer
	Public Property price As Integer
	Public Property rawDescription As String
	Public Property rawDisplayName As String
	Public Property slot As Integer
End Class

Public Class ActivePlayer
	Public Property abilities As Abilites
	Public Property championStats As ChampionStats
	Public Property currentGold As Single
	Public Property fullRunes As FullRunes
	Public Property level As Integer
	Public Property summonerName As String
End Class

Public Class FullRunes
	Public Property generalRunes As List(Of GeneralRune)
	Public Property keystone As GeneralRune
	Public Property primaryRuneTree As GeneralRune
	Public Property secondaryRuneTree As GeneralRune
	Public Property statRunes As List(Of StatRune)
End Class

Public Class StatRune
	Public Property id As Integer
	Public Property rawDescription As String
End Class

Public Class GeneralRune
	Public Property displayName As String
	Public Property id As Integer
	Public Property rawDescription As String
	Public Property rawDisplayName As String
End Class

Public Class ChampionStats
	Public Property abilityPower As Single
	Public Property armor As Single
	Public Property armorPenetrationFlat As Single
	Public Property armorPenetrationPercent As Single
	Public Property attackDamage As Single
	Public Property attackRange As Single
	Public Property attackSpeed As Single
	Public Property bonusArmorPenetrationPercent As Single
	Public Property bonusMagicPenetrationPercent As Single
	Public Property cooldownReduction As Single
	Public Property critChance As Single
	Public Property critDamage As Single
	Public Property currentHealth As Single
	Public Property healthRegenRate As Single
	Public Property lifeSteal As Single
	Public Property magicLethality As Single
	Public Property magicPenetrationFlat As Single
	Public Property magicPenetrationPercent As Single
	Public Property magicResist As Single
	Public Property maxHealth As Single
	Public Property moveSpeed As Single
	Public Property physicalLethality As Single
	Public Property resourceMax As Single
	Public Property resourceRegenRate As Single
	Public Property resourceType As String
	Public Property resourceValue As Single
	Public Property spellVamp As Single
	Public Property tenacity As Single
End Class


Public Class Abilites
	Public Property E As AbilityDTO
	Public Property Passive As PassiveDTO
	Public Property Q As AbilityDTO
	Public Property R As AbilityDTO
	Public Property W As AbilityDTO
End Class

Public Class AbilityDTO
	Public Property abilityLevel As Integer
	Public Property displayName As String
	Public Property id As String
	Public Property rawDescription As String
	Public Property rawDisplayName As String
End Class

Public Class PassiveDTO
	Public Property displayName As String
	Public Property id As String
	Public Property rawDescription As String
	Public Property rawDisplayName As String
End Class