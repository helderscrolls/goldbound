using Game.Autoload;
using Godot;

namespace Game.UI;

public partial class MainMenu : Node
{
	private Button playButton;

	public override void _Ready()
	{
		playButton = GetNode<Button>("%PlayButton");

		playButton.Connect(Button.SignalName.Pressed, Callable.From(OnPlayButtonPressed));
	}

	private void OnPlayButtonPressed()
	{
		LevelManager.Instance.ChangeToLevel(0);
	}

}
