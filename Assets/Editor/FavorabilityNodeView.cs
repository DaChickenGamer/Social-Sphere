using Conversa.Editor;
using Conversa.Runtime;
using UnityEngine;
using UnityEngine.UIElements;

public class FavorabilityNodeView : BaseNodeView<FavorabilityNode>
{
    protected override string Title => "Favorability";
    
    // Constructers
    public FavorabilityNodeView(Conversation conversation) : base(new FavorabilityNode(), conversation){}
    
    public FavorabilityNodeView(FavorabilityNode data, Conversation conversation) : base(data, conversation){}
    
    // Methods
    private TextField actorField;
    private TextField messageField;
    private IntegerField favorabilityField;

    protected override void SetBody()
    {
        actorField = new TextField();
        actorField.SetValueWithoutNotify(Data.actor.DisplayName);
        actorField.RegisterValueChangedCallback(e => Data.actor.DisplayName = e.newValue);
        actorField.isDelayed = true;
        
        messageField = new TextField();
        messageField.SetValueWithoutNotify(Data.message);
        messageField.RegisterValueChangedCallback(e => Data.message = e.newValue);
        messageField.isDelayed = true;
        
        favorabilityField = new IntegerField();
        favorabilityField.SetValueWithoutNotify(Data.favorability);
        favorabilityField.RegisterValueChangedCallback(e => Data.favorability = e.newValue);
        favorabilityField.isDelayed = true;
        
        var wrapper = new VisualElement();
        wrapper.AddToClassList("p-5");
        wrapper.Add(favorabilityField);

        bodyContainer.Add(wrapper);
    }
    
    [NodeMenuModifier(8)]
    private static void ModifyMenu(NodeMenuTree tree, Conversation conversation)
    {
        tree.AddMenuEntry<FavorabilityNodeView>("Favorability Message"); 
    }
}
