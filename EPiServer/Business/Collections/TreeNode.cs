using System;

namespace HansKindberg.EPiServer.Modules.TestApplication.Business.Collections
{
	public class TreeNode : ListItem, ITreeNode
	{
		#region Fields

		private int _siblingIndex;

		#endregion

		#region Properties

		public virtual bool FirstSibling
		{
			get { return this.SiblingIndex == 0; }
		}

		public virtual bool LastSibling { get; set; }
		public virtual bool Leaf { get; set; }
		public virtual int Level { get; set; }
		public virtual ITreeNode NextNode { get; set; }
		public virtual ITreeNode NextSibling { get; set; }
		public virtual ITreeNode PreviousNode { get; set; }
		public virtual ITreeNode PreviousSibling { get; set; }
		public virtual bool SelectedAncestor { get; set; }

		public virtual int SiblingIndex
		{
			get { return this._siblingIndex; }
			set
			{
				if(value < 0)
					throw new ArgumentOutOfRangeException("value", value, "The value can not be less than zero.");

				this._siblingIndex = value;
			}
		}

		#endregion
	}

	public class TreeNode<T> : TreeNode, ITreeNode<T>
	{
		#region Properties

		public new virtual ITreeNode<T> NextNode
		{
			get { return (ITreeNode<T>) base.NextNode; }
			set { base.NextNode = value; }
		}

		public new virtual ITreeNode<T> NextSibling
		{
			get { return (ITreeNode<T>) base.NextSibling; }
			set { base.NextSibling = value; }
		}

		public new virtual ITreeNode<T> PreviousNode
		{
			get { return (ITreeNode<T>) base.PreviousNode; }
			set { base.PreviousNode = value; }
		}

		public new virtual ITreeNode<T> PreviousSibling
		{
			get { return (ITreeNode<T>) base.PreviousSibling; }
			set { base.PreviousSibling = value; }
		}

		public new virtual T Value
		{
			get { return (T) base.Value; }
			set { base.Value = value; }
		}

		#endregion
	}
}