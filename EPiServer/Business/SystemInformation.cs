using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Linq;

namespace HansKindberg.EPiServer.Modules.TestApplication.Business
{
	public class SystemInformation
	{
		#region Fields

		private IList<string> _detailedInformation;

		#endregion

		#region Properties

		public virtual IList<string> DetailedInformation
		{
			get { return this._detailedInformation ?? (this._detailedInformation = new List<string>()); }
		}

		public virtual string Heading { get; set; }
		public virtual string Information { get; set; }

		[SuppressMessage("Microsoft.Naming", "CA1721:PropertyNamesShouldNotMatchGetMethods")]
		public virtual SystemInformationType Type { get; set; }

		#endregion

		#region Methods

		public virtual void AddDetailedInformation(IEnumerable<string> detailedInformation)
		{
			if(detailedInformation == null)
				throw new ArgumentNullException("detailedInformation");

			// ReSharper disable PossibleMultipleEnumeration

			if(detailedInformation.Any(detail => detail == null))
				throw new ArgumentException("The collection can not contain null values.", "detailedInformation");

			List<string> list = (List<string>) this.DetailedInformation;

			list.AddRange(detailedInformation);

			// ReSharper restore PossibleMultipleEnumeration
		}

		#endregion
	}
}