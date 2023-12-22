using System;
using System.Linq;
using Conversa.Runtime;
using Conversa.Runtime.Interfaces;

[Serializable]
[Port("Previous", "previous", typeof(BaseNode), Flow.In, Capacity.Many)]
[Port("Next", "next", typeof(BaseNode), Flow.Out, Capacity.One)]
public class FavorabilityNode : BaseNode, IEventNode
{
    public Actor actor;
    public string message;
    public int favorability;

    public void Process(Conversation conversation, ConversationEvents conversationEvents)
    {
        var e = new FavorabilityEvent(actor, message, favorability, () =>
        {
            var nextNode = conversation.GetOppositeNodes(GetNodePort("next")).FirstOrDefault();
            conversation.Process(nextNode, conversationEvents);
        });
        
        conversationEvents.OnConversationEvent.Invoke(e);
    }
}
