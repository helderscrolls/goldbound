using Godot;

namespace Game.UI;

public partial class MainMenu : Node
{
	private Button playButton;
	private Button quitButton;
	private Control mainMenuContainer;
	private LevelSelectScreen levelSelectScreen;

	public override void _Ready()
	{
		playButton = GetNode<Button>("%PlayButton");
		quitButton = GetNode<Button>("%QuitButton");
		mainMenuContainer = GetNode<Control>("%MainMenuContainer");
		levelSelectScreen = GetNode<LevelSelectScreen>("%LevelSelectScreen");

		levelSelectScreen.Visible = false;
		mainMenuContainer.Visible = true;

		playButton.Connect(Button.SignalName.Pressed, Callable.From(OnPlayButtonPressed));
		quitButton.Connect(Button.SignalName.Pressed, Callable.From(OnQuitButtonPressed));
		levelSelectScreen.Connect(LevelSelectScreen.SignalName.BackPressed, Callable.From(OnLevelSelectBackPressed));
	}

	private void OnPlayButtonPressed()
	{
		mainMenuContainer.Visible = false;
		levelSelectScreen.Visible = true;
	}

	private void OnQuitButtonPressed()
	{
		GetTree().Quit();
	}

	private void OnLevelSelectBackPressed()
	{
		mainMenuContainer.Visible = true;
		levelSelectScreen.Visible = false;
	}
}
