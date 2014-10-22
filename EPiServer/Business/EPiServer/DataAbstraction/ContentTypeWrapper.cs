using System;
using EPiServer.Data.Entity;
using EPiServer.DataAbstraction;

namespace HansKindberg.EPiServer.Modules.TestApplication.Business.EPiServer.DataAbstraction
{
	public class ContentTypeWrapper : IContentType
	{
		#region Fields

		private readonly ContentType _contentType;

		#endregion

		#region Constructors

		public ContentTypeWrapper(ContentType contentType)
		{
			if(contentType == null)
				throw new ArgumentNullException("contentType");

			this._contentType = contentType;
		}

		#endregion

		#region Properties

		protected internal virtual ContentType ContentType
		{
			get { return this._contentType; }
		}

		public virtual string Description
		{
			get { return this.ContentType.Description; }
			set { this.ContentType.Description = value; }
		}

		public virtual string DisplayName
		{
			get { return this.ContentType.DisplayName; }
			set { this.ContentType.DisplayName = value; }
		}

		public virtual string FullName
		{
			get { return this.ContentType.FullName; }
		}

		public virtual string GroupName
		{
			get { return this.ContentType.GroupName; }
			set { this.ContentType.GroupName = value; }
		}

		public virtual Guid Guid
		{
			get { return this.ContentType.GUID; }
			set { this.ContentType.GUID = value; }
		}

		public virtual int Id
		{
			get { return this.ContentType.ID; }
			set { this.ContentType.ID = value; }
		}

		public virtual bool IsAvailable
		{
			get { return this.ContentType.IsAvailable; }
			set { this.ContentType.IsAvailable = value; }
		}

		public virtual bool IsNew
		{
			get { return this.ContentType.IsNew; }
		}

		public virtual bool IsReadOnly
		{
			get { return this.ContentType.IsReadOnly; }
		}

		public virtual string LocalizedDescription
		{
			get { return this.ContentType.LocalizedDescription; }
		}

		public virtual string LocalizedFullName
		{
			get { return this.ContentType.LocalizedFullName; }
		}

		public virtual string LocalizedGroupName
		{
			get { return this.ContentType.LocalizedGroupName; }
		}

		public virtual string LocalizedName
		{
			get { return this.ContentType.LocalizedName; }
		}

		public virtual string Name
		{
			get { return this.ContentType.Name; }
			set { this.ContentType.Name = value; }
		}

		public virtual int SortOrder
		{
			get { return this.ContentType.SortOrder; }
			set { this.ContentType.SortOrder = value; }
		}

		#endregion

		#region Methods

		public virtual IContentType CreateWritableClone()
		{
			return new ContentTypeWrapper((ContentType) this.ContentType.CreateWritableClone());
		}

		object IReadOnly.CreateWritableClone()
		{
			return this.CreateWritableClone();
		}

		protected internal virtual bool Equals(ContentTypeWrapper other)
		{
			return this.Equals((IContentType) other);
		}

		public override bool Equals(object obj)
		{
			var contentType = obj as ContentType;

			if(contentType != null)
				return this.Equals(contentType);

			return this.Equals(obj as IContentType);
		}

		public virtual bool Equals(IContentType other)
		{
			if(other == null)
				return false;

			return this.Id == other.Id;
		}

		public static ContentTypeWrapper FromContentType(ContentType contentType)
		{
			return contentType;
		}

		public override int GetHashCode()
		{
			return this.ContentType.GetHashCode();
		}

		public virtual void MakeReadOnly()
		{
			this.ContentType.MakeReadOnly();
		}

		public static ContentType ToContentType(ContentTypeWrapper contentTypeWrapper)
		{
			return contentTypeWrapper;
		}

		#endregion

		#region Implicit operator

		public static implicit operator ContentType(ContentTypeWrapper contentTypeWrapper)
		{
			return contentTypeWrapper == null ? null : contentTypeWrapper.ContentType;
		}

		public static implicit operator ContentTypeWrapper(ContentType contentType)
		{
			return contentType == null ? null : new ContentTypeWrapper(contentType);
		}

		#endregion
	}
}