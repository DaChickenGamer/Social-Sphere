using Conversa.Runtime;
using Conversa.Runtime.Events;
using Conversa.Runtime.Interfaces;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class ConversaController : MonoBehaviour
{
	public Conversation conversation;
	[SerializeField] private UIController uiController;
	
	[SerializeField] private Button startDialogueButton;

	private ConversationRunner runner;

	private void Start()
	{
		runner = new ConversationRunner(conversation);
		runner.OnConversationEvent.AddListener(HandleConversationEvent);
		// Change to Interaction
		// startDialogueButton.onClick.AddListener(HandleStartConversation);
		// startDialogueButton.onClick.AddListener(uiController.Show);

		if (conversation.name == "Tutorial")
		{
			HandleStartConversation();
			uiController.Show();
		}
	}

	private void HandleConversationEvent(IConversationEvent e)
	{
		switch (e)
		{
			case MessageEvent messageEvent:
				HandleMessage(messageEvent);
				break;
			case ChoiceEvent choiceEvent:
				HandleChoice(choiceEvent);
				break;
			case ActorMessageEvent actorMessageEvent:
				HandleActorMessageEvent(actorMessageEvent);
				break;
			case ActorChoiceEvent actorChoiceEvent:
				HandleActorChoiceEvent(actorChoiceEvent);
				break;
			case UserEvent userEvent:
				HandleUserEvent(userEvent);
				break;
			case EndEvent _:
				HandleEnd();
				break;
		}
	}

	private void HandleActorMessageEvent(ActorMessageEvent evt)
	{
		
		var actorDisplayName = evt.Actor == null ? "" : evt.Actor.DisplayName;
		uiController.ShowMessage(actorDisplayName, evt.Message, evt.Advance);
	}

	private void HandleActorChoiceEvent(ActorChoiceEvent evt)
	{
		var actorDisplayName = evt.Actor == null ? "" : evt.Actor.DisplayName;
		if (evt.Actor is AvatarActor avatarActor)
			uiController.ShowChoice(actorDisplayName, evt.Message, avatarActor.Avatar, evt.Options);
		else
			uiController.ShowChoice(actorDisplayName, evt.Message, null, evt.Options);
	}

	private void HandleMessage(MessageEvent e) => uiController.ShowMessage(e.Actor, e.Message, () => e.Advance());

	private void HandleChoice(ChoiceEvent e) => uiController.ShowChoice(e.Actor, e.Message, null, e.Options);

	private static void HandleUserEvent(UserEvent userEvent)
	{
		if (userEvent.Name == "Food bought")
			Debug.Log("We can use this event to update the inventory, for instance");
	}

	private void HandleStartConversation()
	{
		runner.Begin();
	}

	private void HandleEnd()
	{
		uiController.Hide();
	}
}
