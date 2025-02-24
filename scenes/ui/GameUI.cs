using Game.Manager;
using Game.Resources.Building;
using Godot;

namespace Game.UI;

public partial class GameUI : CanvasLayer
{
	[Signal]
	public delegate void BuildingResourceSelectedEventHandler(BuildingResource buildingResource);

	private VBoxContainer buildingSectionContainer;
	private Label resourceLabel;

	[Export]
	private BuildingManager buildingManager;
	[Export]
	private BuildingResource[] buildingResources;
	[Export]
	private PackedScene buildingSectionScene;

	public override void _Ready()
	{
		buildingSectionContainer = GetNode<VBoxContainer>("%BuildingSectionContainer");
		resourceLabel = GetNode<Label>("%ResourceLabel");
		CreateBuildingSections();

		buildingManager.Connect(BuildingManager.SignalName.AvailableResourceCountChanged, Callable.From<int>(OnAvailableResourceCountChanged));
	}

	public void HideUI()
	{
		Visible = false;
	}

	private void CreateBuildingSections()
	{
		foreach (var buildingResource in buildingResources)
		{
			var buildingSection = buildingSectionScene.Instantiate<BuildingSection>();
			buildingSectionContainer.AddChild(buildingSection);
			buildingSection.SetBuildingResource(buildingResource);

			buildingSection.Connect(BuildingSection.SignalName.SelectButtonPressed, Callable.From(() =>
			{
				EmitSignal(SignalName.BuildingResourceSelected, buildingResource);
			}));
		}
	}

	private void OnAvailableResourceCountChanged(int availableResourceCount)
	{
		resourceLabel.Text = availableResourceCount.ToString();
	}
}
