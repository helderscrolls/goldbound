using Godot;

namespace Game.Building;

public partial class BuildingGhost : Node2D
{
	private Node2D topLeft;
	private Node2D bottomLeft;
	private Node2D topRight;
	private Node2D bottomRight;
	private Node2D spriteRoot;

	private Tween spriteTween;

	public override void _Ready()
	{
		topLeft = GetNode<Node2D>("TopLeft");
		bottomLeft = GetNode<Node2D>("BottomLeft");
		topRight = GetNode<Node2D>("TopRight");
		bottomRight = GetNode<Node2D>("BottomRight");
		spriteRoot = GetNode<Node2D>("SpriteRoot");
	}

	public void SetInvalid()
	{
		Modulate = Colors.Red;
		spriteRoot.Modulate = Modulate;
	}

	public void SetValid()
	{
		Modulate = Colors.White;
		spriteRoot.Modulate = Modulate;
	}

	public void SetDimensions(Vector2I dimensions)
	{
		bottomLeft.Position = dimensions * new Vector2I(0, 64);
		bottomRight.Position = dimensions * new Vector2I(64, 64);
		topRight.Position = dimensions * new Vector2I(64, 0);
	}

	public void AddSpriteNode(Node2D spriteNode)
	{
		spriteRoot.AddChild(spriteNode);
	}

	public void DoHoverAnimation()
	{
		if (spriteTween != null && spriteTween.IsValid())
		{
			spriteTween.Kill();
		}
		spriteTween = CreateTween();
		spriteTween
			.TweenProperty(spriteRoot, "global_position", GlobalPosition, .3)
			.SetTrans(Tween.TransitionType.Back)
			.SetEase(Tween.EaseType.Out);
	}
}
