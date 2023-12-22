using System;
using Conversa.Runtime;
using Conversa.Runtime.Interfaces;

public class FavorabilityEvent : IConversationEvent
{
    public string ActorName { get; }
    public string Message { get; }
    public int Favorability { get; }
    public Action Advance { get; }
    public FavorabilityEvent(Actor actor, string message, int favorability, Action advance)
    {
        ActorName = actor.name;
        Message = message;
        Favorability = favorability;
        Advance = advance;
    }
}
