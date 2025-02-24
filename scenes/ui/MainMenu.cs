using Game.Autoload;
using Godot;

namespace Game.UI;

public partial class MainMenu : Node
{
	private Button playButton;
	private Control mainMenuContainer;
	private LevelSelectScreen levelSelectScreen;

	public override void _Ready()
	{
		playButton = GetNode<Button>("%PlayButton");
		mainMenuContainer = GetNode<Control>("%MainMenuContainer");
		levelSelectScreen = GetNode<LevelSelectScreen>("%LevelSelectScreen");

		levelSelectScreen.Visible = false;
		mainMenuContainer.Visible = true;

		playButton.Connect(Button.SignalName.Pressed, Callable.From(OnPlayButtonPressed));
		levelSelectScreen.Connect(LevelSelectScreen.SignalName.BackPressed, Callable.From(OnLevelSelectBackPressed));
	}

	private void OnPlayButtonPressed()
	{
		mainMenuContainer.Visible = false;
		levelSelectScreen.Visible = true;
	}

	private void OnLevelSelectBackPressed()
	{
		mainMenuContainer.Visible = true;
		levelSelectScreen.Visible = false;
	}
}
