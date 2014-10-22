using System;
using System.Collections.Generic;
using EPiServer.SpecializedProperties;

namespace HansKindberg.EPiServer.Modules.TestApplication.Business.EPiServer.SpecializedProperties
{
	public class LinkItemWrapper : ILinkItem
	{
		#region Fields

		private readonly LinkItem _linkItem;

		#endregion

		#region Constructors

		public LinkItemWrapper(LinkItem linkItem)
		{
			if(linkItem == null)
				throw new ArgumentNullException("linkItem");

			this._linkItem = linkItem;
		}

		#endregion

		#region Properties

		public virtual IDictionary<string, string> Attributes
		{
			get { return this.LinkItem.Attributes; }
		}

		public virtual string Href
		{
			get { return this.LinkItem.Href; }
			set { this.LinkItem.Href = value; }
		}

		public virtual string Language
		{
			get { return this.LinkItem.Language; }
		}

		protected internal virtual LinkItem LinkItem
		{
			get { return this._linkItem; }
		}

		public virtual string Target
		{
			get { return this.LinkItem.Target; }
			set { this.LinkItem.Target = value; }
		}

		public virtual string Text
		{
			get { return this.LinkItem.Text; }
			set { this.LinkItem.Text = value; }
		}

		public virtual string Title
		{
			get { return this.LinkItem.Title; }
			set { this.LinkItem.Title = value; }
		}

		#endregion

		#region Methods

		public virtual object Clone()
		{
			return this.Copy();
		}

		public virtual ILinkItem Copy()
		{
			return (LinkItemWrapper) (LinkItem) (this.LinkItem.Clone());
		}

		public static LinkItemWrapper FromLinkItem(LinkItem linkItem)
		{
			return linkItem;
		}

		public virtual string GetMappedHref()
		{
			return this.LinkItem.GetMappedHref();
		}

		public static LinkItem ToLinkItem(LinkItemWrapper linkItemWrapper)
		{
			return linkItemWrapper;
		}

		public virtual string ToMappedLink()
		{
			return this.LinkItem.ToMappedLink();
		}

		public virtual string ToPermanentLink()
		{
			return this.LinkItem.ToPermanentLink();
		}

		#endregion

		#region Implicit operator

		public static implicit operator LinkItem(LinkItemWrapper linkItemWrapper)
		{
			if(linkItemWrapper == null)
				return null;

			return linkItemWrapper.LinkItem;
		}

		public static implicit operator LinkItemWrapper(LinkItem linkItem)
		{
			if(linkItem == null)
				return null;

			return new LinkItemWrapper(linkItem);
		}

		#endregion
	}
}