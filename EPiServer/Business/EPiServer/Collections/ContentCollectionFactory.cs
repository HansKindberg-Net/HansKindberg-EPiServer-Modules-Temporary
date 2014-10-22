using System;
using System.Collections.Generic;
using System.Linq;
using EPiServer;
using EPiServer.Core;
using EPiServer.Filters;
using HansKindberg.EPiServer.Modules.TestApplication.Business.Collections;
using HansKindberg.EPiServer.Modules.TestApplication.Business.Pagination;

namespace HansKindberg.EPiServer.Modules.TestApplication.Business.EPiServer.Collections
{
	public class ContentCollectionFactory : IContentCollectionFactory
	{
		#region Fields

		private readonly bool _cast;
		private readonly IContentLoader _contentLoader;
		private readonly IContentListSettings _defaultContentListSettings;
		private readonly IContentTreeSettings _defaultContentTreeSettings;
		private readonly IContentFilter _filterForVisitor;
		private readonly IItemCollectionFactory _itemCollectionFactory;
		private readonly IPaginationFactory _paginationFactory;
		private readonly IContentFilter _visibleInMenuFilter;

		#endregion

		#region Constructors

		public ContentCollectionFactory(IContentLoader contentLoader, IContentFilter filterForVisitor, IContentFilter visibleInMenuFilter, bool cast, IPaginationFactory paginationFactory, IItemCollectionFactory itemCollectionFactory)
		{
			if(contentLoader == null)
				throw new ArgumentNullException("contentLoader");

			if(filterForVisitor == null)
				throw new ArgumentNullException("filterForVisitor");

			if(visibleInMenuFilter == null)
				throw new ArgumentNullException("visibleInMenuFilter");

			if(paginationFactory == null)
				throw new ArgumentNullException("paginationFactory");

			if(itemCollectionFactory == null)
				throw new ArgumentNullException("itemCollectionFactory");

			this._cast = cast;
			this._contentLoader = contentLoader;
			this._defaultContentListSettings = new ContentListSettings();
			this._defaultContentTreeSettings = new ContentTreeSettings();
			this._filterForVisitor = filterForVisitor;
			this._itemCollectionFactory = itemCollectionFactory;
			this._paginationFactory = paginationFactory;
			this._visibleInMenuFilter = visibleInMenuFilter;
		}

		#endregion

		#region Properties

		protected internal virtual bool Cast
		{
			get { return this._cast; }
		}

		protected internal virtual IContentLoader ContentLoader
		{
			get { return this._contentLoader; }
		}

		protected internal virtual IContentListSettings DefaultContentListSettings
		{
			get { return this._defaultContentListSettings; }
		}

		protected internal virtual IContentTreeSettings DefaultContentTreeSettings
		{
			get { return this._defaultContentTreeSettings; }
		}

		protected internal virtual IContentFilter FilterForVisitor
		{
			get { return this._filterForVisitor; }
		}

		protected internal virtual IItemCollectionFactory ItemCollectionFactory
		{
			get { return this._itemCollectionFactory; }
		}

		protected internal virtual IPaginationFactory PaginationFactory
		{
			get { return this._paginationFactory; }
		}

		protected internal virtual IContentFilter VisibleInMenuFilter
		{
			get { return this._visibleInMenuFilter; }
		}

		#endregion

		#region Methods

		public virtual IEnumerable<IListItem<T>> CreateContentList<T>(ContentReference root) where T : IContent
		{
			return this.CreateContentList<T>(root, this.DefaultContentListSettings);
		}

		public virtual IEnumerable<IListItem<T>> CreateContentList<T>(IEnumerable<ContentReference> roots) where T : IContent
		{
			return this.CreateContentList<T>(roots, this.DefaultContentListSettings);
		}

		public virtual IEnumerable<IListItem<T>> CreateContentList<T>(ContentReference root, IContentListSettings contentListSettings) where T : IContent
		{
			return this.CreateContentList<T>(root, contentListSettings, (IEnumerable<IContentFilter>) null);
		}

		public virtual IEnumerable<IListItem<T>> CreateContentList<T>(IEnumerable<ContentReference> roots, IContentListSettings contentListSettings) where T : IContent
		{
			return this.CreateContentList<T>(roots, contentListSettings, (IEnumerable<IContentFilter>) null);
		}

		public virtual IEnumerable<IListItem<T>> CreateContentList<T>(ContentReference root, IEnumerable<IContentFilter> contentFilters) where T : IContent
		{
			return this.CreateContentList<T>(root, this.DefaultContentListSettings, contentFilters);
		}

		public virtual IEnumerable<IListItem<T>> CreateContentList<T>(IEnumerable<ContentReference> roots, IEnumerable<IContentFilter> contentFilters) where T : IContent
		{
			return this.CreateContentList<T>(roots, this.DefaultContentListSettings, contentFilters);
		}

		public virtual IEnumerable<IListItem<T>> CreateContentList<T>(ContentReference root, ContentReference currentContentLink) where T : IContent
		{
			return this.CreateContentList<T>(root, this.DefaultContentListSettings, currentContentLink);
		}

		public virtual IEnumerable<IListItem<T>> CreateContentList<T>(IEnumerable<ContentReference> roots, ContentReference currentContentLink) where T : IContent
		{
			return this.CreateContentList<T>(roots, this.DefaultContentListSettings, currentContentLink);
		}

		public virtual IEnumerable<IListItem<T>> CreateContentList<T>(ContentReference root, IContentListSettings contentListSettings, IEnumerable<IContentFilter> contentFilters) where T : IContent
		{
			return this.CreateContentList<T>(root, contentListSettings, contentFilters, null);
		}

		public virtual IEnumerable<IListItem<T>> CreateContentList<T>(IEnumerable<ContentReference> roots, IContentListSettings contentListSettings, IEnumerable<IContentFilter> contentFilters) where T : IContent
		{
			return this.CreateContentList<T>(roots, contentListSettings, contentFilters, null);
		}

		public virtual IEnumerable<IListItem<T>> CreateContentList<T>(ContentReference root, IContentListSettings contentListSettings, ContentReference currentContentLink) where T : IContent
		{
			return this.CreateContentList<T>(root, contentListSettings, null, currentContentLink);
		}

		public virtual IEnumerable<IListItem<T>> CreateContentList<T>(IEnumerable<ContentReference> roots, IContentListSettings contentListSettings, ContentReference currentContentLink) where T : IContent
		{
			return this.CreateContentList<T>(roots, contentListSettings, null, currentContentLink);
		}

		public virtual IEnumerable<IListItem<T>> CreateContentList<T>(ContentReference root, IEnumerable<IContentFilter> contentFilters, ContentReference currentContentLink) where T : IContent
		{
			return this.CreateContentList<T>(root, this.DefaultContentListSettings, contentFilters, currentContentLink);
		}

		public virtual IEnumerable<IListItem<T>> CreateContentList<T>(IEnumerable<ContentReference> roots, IEnumerable<IContentFilter> contentFilters, ContentReference currentContentLink) where T : IContent
		{
			return this.CreateContentList<T>(roots, this.DefaultContentListSettings, contentFilters, currentContentLink);
		}

		public virtual IEnumerable<IListItem<T>> CreateContentList<T>(ContentReference root, IContentListSettings contentListSettings, IEnumerable<IContentFilter> contentFilters, ContentReference currentContentLink) where T : IContent
		{
			if(root == null)
				throw new ArgumentNullException("root");

			return this.CreateContentList<T>(new[] {root}, contentListSettings, contentFilters, currentContentLink);
		}

		public virtual IEnumerable<IListItem<T>> CreateContentList<T>(IEnumerable<ContentReference> roots, IContentListSettings contentListSettings, IEnumerable<IContentFilter> contentFilters, ContentReference currentContentLink) where T : IContent
		{
			if(contentListSettings == null)
				throw new ArgumentNullException("contentListSettings");

			var children = this.GetFilteredChildren<T>(roots, contentListSettings, contentFilters, this.Cast);

			return this.ItemCollectionFactory.CreateListItems(children, this.CreateIsSelectedDelegate<T>(currentContentLink)).ToArray();
		}

		public virtual IPaginationInformation<T> CreateContentPagination<T>(ContentReference root, IPaginationSettings paginationSettings, Uri url) where T : IContent
		{
			return this.CreateContentPagination<T>(root, this.DefaultContentListSettings, paginationSettings, url);
		}

		public virtual IPaginationInformation<T> CreateContentPagination<T>(IEnumerable<ContentReference> roots, IPaginationSettings paginationSettings, Uri url) where T : IContent
		{
			return this.CreateContentPagination<T>(roots, this.DefaultContentListSettings, paginationSettings, url);
		}

		public virtual IPaginationInformation<T> CreateContentPagination<T>(ContentReference root, IContentListSettings contentListSettings, IPaginationSettings paginationSettings, Uri url) where T : IContent
		{
			return this.CreateContentPagination<T>(root, contentListSettings, (IEnumerable<IContentFilter>) null, paginationSettings, url);
		}

		public virtual IPaginationInformation<T> CreateContentPagination<T>(IEnumerable<ContentReference> roots, IContentListSettings contentListSettings, IPaginationSettings paginationSettings, Uri url) where T : IContent
		{
			return this.CreateContentPagination<T>(roots, contentListSettings, (IEnumerable<IContentFilter>) null, paginationSettings, url);
		}

		public virtual IPaginationInformation<T> CreateContentPagination<T>(ContentReference root, IEnumerable<IContentFilter> contentFilters, IPaginationSettings paginationSettings, Uri url) where T : IContent
		{
			return this.CreateContentPagination<T>(root, this.DefaultContentListSettings, contentFilters, paginationSettings, url);
		}

		public virtual IPaginationInformation<T> CreateContentPagination<T>(IEnumerable<ContentReference> roots, IEnumerable<IContentFilter> contentFilters, IPaginationSettings paginationSettings, Uri url) where T : IContent
		{
			return this.CreateContentPagination<T>(roots, this.DefaultContentListSettings, contentFilters, paginationSettings, url);
		}

		public virtual IPaginationInformation<T> CreateContentPagination<T>(ContentReference root, ContentReference currentContentLink, IPaginationSettings paginationSettings, Uri url) where T : IContent
		{
			return this.CreateContentPagination<T>(root, this.DefaultContentListSettings, currentContentLink, paginationSettings, url);
		}

		public virtual IPaginationInformation<T> CreateContentPagination<T>(IEnumerable<ContentReference> roots, ContentReference currentContentLink, IPaginationSettings paginationSettings, Uri url) where T : IContent
		{
			return this.CreateContentPagination<T>(roots, this.DefaultContentListSettings, currentContentLink, paginationSettings, url);
		}

		public virtual IPaginationInformation<T> CreateContentPagination<T>(ContentReference root, IContentListSettings contentListSettings, IEnumerable<IContentFilter> contentFilters, IPaginationSettings paginationSettings, Uri url) where T : IContent
		{
			return this.CreateContentPagination<T>(root, contentListSettings, contentFilters, null, paginationSettings, url);
		}

		public virtual IPaginationInformation<T> CreateContentPagination<T>(IEnumerable<ContentReference> roots, IContentListSettings contentListSettings, IEnumerable<IContentFilter> contentFilters, IPaginationSettings paginationSettings, Uri url) where T : IContent
		{
			return this.CreateContentPagination<T>(roots, contentListSettings, contentFilters, null, paginationSettings, url);
		}

		public virtual IPaginationInformation<T> CreateContentPagination<T>(ContentReference root, IContentListSettings contentListSettings, ContentReference currentContentLink, IPaginationSettings paginationSettings, Uri url) where T : IContent
		{
			return this.CreateContentPagination<T>(root, contentListSettings, null, currentContentLink, paginationSettings, url);
		}

		public virtual IPaginationInformation<T> CreateContentPagination<T>(IEnumerable<ContentReference> roots, IContentListSettings contentListSettings, ContentReference currentContentLink, IPaginationSettings paginationSettings, Uri url) where T : IContent
		{
			return this.CreateContentPagination<T>(roots, contentListSettings, null, currentContentLink, paginationSettings, url);
		}

		public virtual IPaginationInformation<T> CreateContentPagination<T>(ContentReference root, IEnumerable<IContentFilter> contentFilters, ContentReference currentContentLink, IPaginationSettings paginationSettings, Uri url) where T : IContent
		{
			return this.CreateContentPagination<T>(root, this.DefaultContentListSettings, contentFilters, currentContentLink, paginationSettings, url);
		}

		public virtual IPaginationInformation<T> CreateContentPagination<T>(IEnumerable<ContentReference> roots, IEnumerable<IContentFilter> contentFilters, ContentReference currentContentLink, IPaginationSettings paginationSettings, Uri url) where T : IContent
		{
			return this.CreateContentPagination<T>(roots, this.DefaultContentListSettings, contentFilters, currentContentLink, paginationSettings, url);
		}

		public virtual IPaginationInformation<T> CreateContentPagination<T>(ContentReference root, IContentListSettings contentListSettings, IEnumerable<IContentFilter> contentFilters, ContentReference currentContentLink, IPaginationSettings paginationSettings, Uri url) where T : IContent
		{
			if(root == null)
				throw new ArgumentNullException("root");

			return this.CreateContentPagination<T>(new[] {root}, contentListSettings, contentFilters, currentContentLink, paginationSettings, url);
		}

		public virtual IPaginationInformation<T> CreateContentPagination<T>(IEnumerable<ContentReference> roots, IContentListSettings contentListSettings, IEnumerable<IContentFilter> contentFilters, ContentReference currentContentLink, IPaginationSettings paginationSettings, Uri url) where T : IContent
		{
			if(contentListSettings == null)
				throw new ArgumentNullException("contentListSettings");

			var children = this.GetFilteredChildren<T>(roots, contentListSettings, contentFilters, this.Cast);

			return this.PaginationFactory.Create<T>(children, paginationSettings, url, this.CreateIsSelectedDelegate<T>(currentContentLink));
		}

		public virtual IEnumerable<ITreeNode<T>> CreateContentTree<T>(ContentReference root) where T : IContent
		{
			return this.CreateContentTree<T>(root, this.DefaultContentTreeSettings);
		}

		public virtual IEnumerable<ITreeNode<T>> CreateContentTree<T>(ContentReference root, IContentTreeSettings contentTreeSettings) where T : IContent
		{
			return this.CreateContentTree<T>(root, contentTreeSettings, (IEnumerable<IContentFilter>) null);
		}

		public virtual IEnumerable<ITreeNode<T>> CreateContentTree<T>(ContentReference root, IEnumerable<IContentFilter> contentFilters) where T : IContent
		{
			return this.CreateContentTree<T>(root, this.DefaultContentTreeSettings, contentFilters);
		}

		public virtual IEnumerable<ITreeNode<T>> CreateContentTree<T>(ContentReference root, ContentReference currentContentLink) where T : IContent
		{
			return this.CreateContentTree<T>(root, this.DefaultContentTreeSettings, currentContentLink);
		}

		public virtual IEnumerable<ITreeNode<T>> CreateContentTree<T>(ContentReference root, IContentTreeSettings contentTreeSettings, IEnumerable<IContentFilter> contentFilters) where T : IContent
		{
			return this.CreateContentTree<T>(root, contentTreeSettings, contentFilters, null);
		}

		public virtual IEnumerable<ITreeNode<T>> CreateContentTree<T>(ContentReference root, IContentTreeSettings contentTreeSettings, ContentReference currentContentLink) where T : IContent
		{
			return this.CreateContentTree<T>(root, contentTreeSettings, null, currentContentLink);
		}

		public virtual IEnumerable<ITreeNode<T>> CreateContentTree<T>(ContentReference root, IEnumerable<IContentFilter> contentFilters, ContentReference currentContentLink) where T : IContent
		{
			return this.CreateContentTree<T>(root, this.DefaultContentTreeSettings, contentFilters, currentContentLink);
		}

		public virtual IEnumerable<ITreeNode<T>> CreateContentTree<T>(ContentReference root, IContentTreeSettings contentTreeSettings, IEnumerable<IContentFilter> contentFilters, ContentReference currentContentLink) where T : IContent
		{
			if(contentTreeSettings == null)
				throw new ArgumentNullException("contentTreeSettings");

			this.ValidateNumberOfLevels(contentTreeSettings.NumberOfLevels);

			var contentTree = new List<ITreeNode<T>>();

			var currentContentAncestorLinks = currentContentLink != null ? this.ContentLoader.GetAncestors(currentContentLink).Select(ancestor => ancestor.ContentLink) : new ContentReference[0];

			this.PopulateContentTree(contentTree, this.GetRootAsCollectionOrChildren<IContent>(root, contentTreeSettings.IncludeRoot), 0, contentTreeSettings, contentFilters, currentContentLink, currentContentAncestorLinks, this.Cast);

			return contentTree.ToArray();
		}

		protected internal virtual Func<T, bool> CreateIsSelectedDelegate<T>(ContentReference currentContentLink) where T : IContent
		{
			if(currentContentLink == null)
				return child => false;

			return child => this.IsSelected(child.ContentLink, currentContentLink) || this.IsSelectedAncestor(child.ContentLink, currentContentLink);
		}

		protected internal virtual void Filter(IList<IContent> contents, IContentCollectionSettings contentCollectionSettings, IEnumerable<IContentFilter> contentFilters)
		{
			if(contents == null)
				throw new ArgumentNullException("contents");

			if(contentCollectionSettings == null)
				throw new ArgumentNullException("contentCollectionSettings");

			if(contentCollectionSettings.OnlyForVisitor)
				this.FilterForVisitor.Filter(contents);

			if(contentCollectionSettings.OnlyVisibleInMenu)
				this.VisibleInMenuFilter.Filter(contents);

			foreach(var contentFilter in (contentFilters ?? new IContentFilter[0]).Where(contentFilter => contentFilter != null))
			{
				contentFilter.Filter(contents);
			}
		}

		protected internal virtual IEnumerable<T> GetChildren<T>(ContentReference contentLink) where T : IContent
		{
			return this.GetChildren<T>(contentLink, false);
		}

		protected internal virtual IEnumerable<T> GetChildren<T>(ContentReference contentLink, bool recursive) where T : IContent
		{
			foreach(var child in this.ContentLoader.GetChildren<T>(contentLink))
			{
				yield return child;

				if(recursive)
				{
					// ReSharper disable ConditionIsAlwaysTrueOrFalse
					foreach(var recursiveChild in this.GetChildren<T>(child.ContentLink, recursive))
					{
						yield return recursiveChild;
					}
					// ReSharper restore ConditionIsAlwaysTrueOrFalse					
				}
			}
		}

		protected internal virtual IList<T> GetFilteredChildren<T>(IEnumerable<ContentReference> contentLinks, IContentListSettings contentListSettings, IEnumerable<IContentFilter> contentFilters, bool cast) where T : IContent
		{
			if(contentLinks == null)
				throw new ArgumentNullException("contentLinks");

			if(contentListSettings == null)
				throw new ArgumentNullException("contentListSettings");

			var children = new List<IContent>();

			foreach(var contentLink in contentLinks)
			{
				children.AddRange(this.GetChildren<IContent>(contentLink, contentListSettings.Recursive));
			}

			return this.GetTypedFilteredContents<T>(children, contentListSettings, contentFilters, cast);
		}

		protected internal virtual IEnumerable<T> GetRootAsCollectionOrChildren<T>(ContentReference root, bool includeRoot) where T : IContent
		{
			return includeRoot ? new[] {this.ContentLoader.Get<T>(root)} : this.GetChildren<T>(root);
		}

		protected internal virtual IList<T> GetTypedFilteredContents<T>(IList<IContent> contents, IContentCollectionSettings contentCollectionSettings, IEnumerable<IContentFilter> contentFilters, bool cast) where T : IContent
		{
			if(contents == null)
				throw new ArgumentNullException("contents");

			this.Filter(contents, contentCollectionSettings, contentFilters);

			var typedContents = new List<T>(cast ? contents.Cast<T>() : contents.OfType<T>());

			return typedContents;
		}

		protected internal virtual bool IsSelected(ContentReference contentLink, ContentReference currentContentLink)
		{
			if(contentLink == null || currentContentLink == null)
				return false;

			return contentLink.CompareToIgnoreWorkID(currentContentLink);
		}

		protected internal virtual bool IsSelectedAncestor(ContentReference contentLink, ContentReference currentContentLink)
		{
			if(contentLink == null || currentContentLink == null)
				return false;

			return this.IsSelectedAncestor(contentLink, this.ContentLoader.GetAncestors(currentContentLink).Select(ancestor => ancestor.ContentLink));
		}

		protected internal virtual bool IsSelectedAncestor(ContentReference contentLink, IEnumerable<ContentReference> currentContentAncestorLinks)
		{
			// ReSharper disable PossibleMultipleEnumeration
			if(contentLink == null || currentContentAncestorLinks == null || !currentContentAncestorLinks.Any())
				return false;

			return currentContentAncestorLinks.Any(ancestorContentLink => ancestorContentLink.CompareToIgnoreWorkID(contentLink));
			// ReSharper restore PossibleMultipleEnumeration
		}

		protected internal virtual void PopulateContentTree<T>(IList<ITreeNode<T>> contentTree, IEnumerable<IContent> allLevelNodes, int level, IContentTreeSettings contentTreeSettings, IEnumerable<IContentFilter> contentFilters, ContentReference currentContentLink, IEnumerable<ContentReference> currentContentAncestorLinks, bool cast) where T : IContent
		{
			if(contentTree == null)
				throw new ArgumentNullException("contentTree");

			if(allLevelNodes == null)
				throw new ArgumentNullException("allLevelNodes");

			if(level < 0)
				throw new ArgumentOutOfRangeException("level", level, "The level can not be less than zero.");

			if(contentTreeSettings == null)
				throw new ArgumentNullException("contentTreeSettings");

			this.ValidateNumberOfLevels(contentTreeSettings.NumberOfLevels);

			if(level >= contentTreeSettings.NumberOfLevels)
				return;

			// ReSharper disable PossibleMultipleEnumeration

			var filteredLevelNodes = this.GetTypedFilteredContents<T>(allLevelNodes.ToList(), contentTreeSettings, contentFilters, cast);

			TreeNode<T> previousSibling = null;

			for(int i = 0; i < filteredLevelNodes.Count; i++)
			{
				var levelNode = filteredLevelNodes[i];

				var previousNode = contentTree.LastOrDefault() as TreeNode<T>;

				var contentTreeNode = new TreeNode<T>
				{
					Index = contentTree.Count,
					Last = true,
					Leaf = true,
					Level = level,
					PreviousNode = previousNode,
					PreviousSibling = previousSibling,
					SiblingIndex = i,
					Value = levelNode
				};

				if(previousNode != null)
				{
					previousNode.Last = false;
					previousNode.NextNode = contentTreeNode;
				}

				if(previousSibling != null)
					previousSibling.NextSibling = contentTreeNode;

				if(currentContentLink != null)
				{
					contentTreeNode.Selected = this.IsSelected(levelNode.ContentLink, currentContentLink);

					contentTreeNode.SelectedAncestor = this.IsSelectedAncestor(levelNode.ContentLink, currentContentAncestorLinks);
				}

				if(i == filteredLevelNodes.Count - 1)
					contentTreeNode.LastSibling = true;

				contentTree.Add(contentTreeNode);

				var contentTreeCount = contentTree.Count;

				var expand = contentTreeSettings.ExpandAll || contentTreeNode.Selected || contentTreeNode.SelectedAncestor;

				if(expand)
					this.PopulateContentTree(contentTree, this.GetChildren<IContent>(levelNode.ContentLink), level + 1, contentTreeSettings, contentFilters, currentContentLink, currentContentAncestorLinks, cast);

				if(contentTree.Count > contentTreeCount)
				{
					contentTreeNode.Leaf = false;
				}

				previousSibling = contentTreeNode;

				// ReSharper restore PossibleMultipleEnumeration
			}
		}

		protected internal virtual void ValidateNumberOfLevels(int numberOfLevels)
		{
			if(numberOfLevels < 1)
				throw new ArgumentOutOfRangeException("numberOfLevels", numberOfLevels, "The number of levels can not be less than one.");
		}

		#endregion
	}
}