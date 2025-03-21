
using Game.Resources.Level;
using Godot;

namespace Game.UI;

public partial class LevelSelectSection : PanelContainer
{
	[Signal]
	public delegate void LevelSelectedEventHandler(int levelIndex);

	private Button button;
	private Label resourceCountLabel;
	private Label levelNumberLabel;
	private int levelIndex;

	public override void _Ready()
	{
		button = GetNode<Button>("%Button");
		resourceCountLabel = GetNode<Label>("%ResourceCountLabel");
		levelNumberLabel = GetNode<Label>("%LevelNumberLabel");

		button.Connect(Button.SignalName.Pressed, Callable.From(OnButtonPressed));
	}

	public void SetLevelDefinition(LevelDefinitionResource levelDefinition)
	{
		resourceCountLabel.Text = levelDefinition.StartingResourceCount.ToString();
		levelNumberLabel.Text = levelDefinition.Id;

	}

	public void SetLevelIndex(int index)
	{
		levelIndex = index;
		levelNumberLabel.Text = $"Level {index + 1}";
	}

	private void OnButtonPressed()
	{
		EmitSignal(SignalName.LevelSelected, levelIndex);
	}
}
