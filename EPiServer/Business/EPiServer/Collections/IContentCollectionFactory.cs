using System;
using System.Collections.Generic;
using EPiServer.Core;
using EPiServer.Filters;
using HansKindberg.EPiServer.Modules.TestApplication.Business.Collections;
using HansKindberg.EPiServer.Modules.TestApplication.Business.Pagination;

namespace HansKindberg.EPiServer.Modules.TestApplication.Business.EPiServer.Collections
{
	public interface IContentCollectionFactory
	{
		#region Methods

		IEnumerable<IListItem<T>> CreateContentList<T>(ContentReference root) where T : IContent;
		IEnumerable<IListItem<T>> CreateContentList<T>(IEnumerable<ContentReference> roots) where T : IContent;
		IEnumerable<IListItem<T>> CreateContentList<T>(ContentReference root, IContentListSettings contentListSettings) where T : IContent;
		IEnumerable<IListItem<T>> CreateContentList<T>(IEnumerable<ContentReference> roots, IContentListSettings contentListSettings) where T : IContent;
		IEnumerable<IListItem<T>> CreateContentList<T>(ContentReference root, IEnumerable<IContentFilter> contentFilters) where T : IContent;
		IEnumerable<IListItem<T>> CreateContentList<T>(IEnumerable<ContentReference> roots, IEnumerable<IContentFilter> contentFilters) where T : IContent;
		IEnumerable<IListItem<T>> CreateContentList<T>(ContentReference root, ContentReference currentContentLink) where T : IContent;
		IEnumerable<IListItem<T>> CreateContentList<T>(IEnumerable<ContentReference> roots, ContentReference currentContentLink) where T : IContent;
		IEnumerable<IListItem<T>> CreateContentList<T>(ContentReference root, IContentListSettings contentListSettings, IEnumerable<IContentFilter> contentFilters) where T : IContent;
		IEnumerable<IListItem<T>> CreateContentList<T>(IEnumerable<ContentReference> roots, IContentListSettings contentListSettings, IEnumerable<IContentFilter> contentFilters) where T : IContent;
		IEnumerable<IListItem<T>> CreateContentList<T>(ContentReference root, IContentListSettings contentListSettings, ContentReference currentContentLink) where T : IContent;
		IEnumerable<IListItem<T>> CreateContentList<T>(IEnumerable<ContentReference> roots, IContentListSettings contentListSettings, ContentReference currentContentLink) where T : IContent;
		IEnumerable<IListItem<T>> CreateContentList<T>(ContentReference root, IEnumerable<IContentFilter> contentFilters, ContentReference currentContentLink) where T : IContent;
		IEnumerable<IListItem<T>> CreateContentList<T>(IEnumerable<ContentReference> roots, IEnumerable<IContentFilter> contentFilters, ContentReference currentContentLink) where T : IContent;
		IEnumerable<IListItem<T>> CreateContentList<T>(ContentReference root, IContentListSettings contentListSettings, IEnumerable<IContentFilter> contentFilters, ContentReference currentContentLink) where T : IContent;
		IEnumerable<IListItem<T>> CreateContentList<T>(IEnumerable<ContentReference> roots, IContentListSettings contentListSettings, IEnumerable<IContentFilter> contentFilters, ContentReference currentContentLink) where T : IContent;
		IPaginationInformation<T> CreateContentPagination<T>(ContentReference root, IPaginationSettings paginationSettings, Uri url) where T : IContent;
		IPaginationInformation<T> CreateContentPagination<T>(IEnumerable<ContentReference> roots, IPaginationSettings paginationSettings, Uri url) where T : IContent;
		IPaginationInformation<T> CreateContentPagination<T>(ContentReference root, IContentListSettings contentListSettings, IPaginationSettings paginationSettings, Uri url) where T : IContent;
		IPaginationInformation<T> CreateContentPagination<T>(IEnumerable<ContentReference> roots, IContentListSettings contentListSettings, IPaginationSettings paginationSettings, Uri url) where T : IContent;
		IPaginationInformation<T> CreateContentPagination<T>(ContentReference root, IEnumerable<IContentFilter> contentFilters, IPaginationSettings paginationSettings, Uri url) where T : IContent;
		IPaginationInformation<T> CreateContentPagination<T>(IEnumerable<ContentReference> roots, IEnumerable<IContentFilter> contentFilters, IPaginationSettings paginationSettings, Uri url) where T : IContent;
		IPaginationInformation<T> CreateContentPagination<T>(ContentReference root, ContentReference currentContentLink, IPaginationSettings paginationSettings, Uri url) where T : IContent;
		IPaginationInformation<T> CreateContentPagination<T>(IEnumerable<ContentReference> roots, ContentReference currentContentLink, IPaginationSettings paginationSettings, Uri url) where T : IContent;
		IPaginationInformation<T> CreateContentPagination<T>(ContentReference root, IContentListSettings contentListSettings, IEnumerable<IContentFilter> contentFilters, IPaginationSettings paginationSettings, Uri url) where T : IContent;
		IPaginationInformation<T> CreateContentPagination<T>(IEnumerable<ContentReference> roots, IContentListSettings contentListSettings, IEnumerable<IContentFilter> contentFilters, IPaginationSettings paginationSettings, Uri url) where T : IContent;
		IPaginationInformation<T> CreateContentPagination<T>(ContentReference root, IContentListSettings contentListSettings, ContentReference currentContentLink, IPaginationSettings paginationSettings, Uri url) where T : IContent;
		IPaginationInformation<T> CreateContentPagination<T>(IEnumerable<ContentReference> roots, IContentListSettings contentListSettings, ContentReference currentContentLink, IPaginationSettings paginationSettings, Uri url) where T : IContent;
		IPaginationInformation<T> CreateContentPagination<T>(ContentReference root, IEnumerable<IContentFilter> contentFilters, ContentReference currentContentLink, IPaginationSettings paginationSettings, Uri url) where T : IContent;
		IPaginationInformation<T> CreateContentPagination<T>(IEnumerable<ContentReference> roots, IEnumerable<IContentFilter> contentFilters, ContentReference currentContentLink, IPaginationSettings paginationSettings, Uri url) where T : IContent;
		IPaginationInformation<T> CreateContentPagination<T>(ContentReference root, IContentListSettings contentListSettings, IEnumerable<IContentFilter> contentFilters, ContentReference currentContentLink, IPaginationSettings paginationSettings, Uri url) where T : IContent;
		IPaginationInformation<T> CreateContentPagination<T>(IEnumerable<ContentReference> roots, IContentListSettings contentListSettings, IEnumerable<IContentFilter> contentFilters, ContentReference currentContentLink, IPaginationSettings paginationSettings, Uri url) where T : IContent;
		IEnumerable<ITreeNode<T>> CreateContentTree<T>(ContentReference root) where T : IContent;
		IEnumerable<ITreeNode<T>> CreateContentTree<T>(ContentReference root, IContentTreeSettings contentTreeSettings) where T : IContent;
		IEnumerable<ITreeNode<T>> CreateContentTree<T>(ContentReference root, IEnumerable<IContentFilter> contentFilters) where T : IContent;
		IEnumerable<ITreeNode<T>> CreateContentTree<T>(ContentReference root, ContentReference currentContentLink) where T : IContent;
		IEnumerable<ITreeNode<T>> CreateContentTree<T>(ContentReference root, IContentTreeSettings contentTreeSettings, IEnumerable<IContentFilter> contentFilters) where T : IContent;
		IEnumerable<ITreeNode<T>> CreateContentTree<T>(ContentReference root, IContentTreeSettings contentTreeSettings, ContentReference currentContentLink) where T : IContent;
		IEnumerable<ITreeNode<T>> CreateContentTree<T>(ContentReference root, IEnumerable<IContentFilter> contentFilters, ContentReference currentContentLink) where T : IContent;
		IEnumerable<ITreeNode<T>> CreateContentTree<T>(ContentReference root, IContentTreeSettings contentTreeSettings, IEnumerable<IContentFilter> contentFilters, ContentReference currentContentLink) where T : IContent;

		#endregion
	}
}