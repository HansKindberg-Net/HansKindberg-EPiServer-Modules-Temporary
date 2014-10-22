namespace HansKindberg.EPiServer.Modules.TestApplication.Business.Collections
{
	public interface ITreeNode : IListItem
	{
		#region Properties

		bool FirstSibling { get; }
		bool LastSibling { get; }
		bool Leaf { get; }
		int Level { get; }
		ITreeNode NextNode { get; }
		ITreeNode NextSibling { get; }
		ITreeNode PreviousNode { get; }
		ITreeNode PreviousSibling { get; }
		bool SelectedAncestor { get; }
		int SiblingIndex { get; }

		#endregion
	}

	public interface ITreeNode<out T> : ITreeNode, IListItem<T>
	{
		#region Properties

		new ITreeNode<T> NextNode { get; }
		new ITreeNode<T> NextSibling { get; }
		new ITreeNode<T> PreviousNode { get; }
		new ITreeNode<T> PreviousSibling { get; }

		#endregion
	}
}