using Game.Autoload;
using Godot;

namespace Game.UI;

public partial class LevelCompleteScreen : CanvasLayer
{
	private Button nextLevelButton;

	public override void _Ready()
	{
		nextLevelButton = GetNode<Button>("%NextLevelButton");

		nextLevelButton.Connect(Button.SignalName.Pressed, Callable.From(OnNextLevelButtonPressed));
	}

	public void OnNextLevelButtonPressed()
	{
		LevelManager.Instance.ChangeToNextLevel();
	}
}
