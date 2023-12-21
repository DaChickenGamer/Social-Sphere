using System.Collections;
using System.Collections.Generic;
using Conversa.Runtime;
using UnityEngine;

[CreateAssetMenu(fileName = "New Character", menuName = "Character")]
public class Character : ScriptableObject
{
    public string characterName;
    public Conversation characterConversation;
    public string characterQuestItem;
    public int characterFavorability = 0;
}
