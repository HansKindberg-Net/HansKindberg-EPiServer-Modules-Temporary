using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;

namespace HansKindberg.EPiServer.Modules.TestApplication.Business.EPiServer.SpecializedProperties
{
	public interface ILinkItem : ICloneable
	{
		#region Properties

		IDictionary<string, string> Attributes { get; }
		string Href { get; set; }
		string Language { get; }
		string Target { get; set; }
		string Text { get; set; }
		string Title { get; set; }

		#endregion

		#region Methods

		ILinkItem Copy();

		[SuppressMessage("Microsoft.Design", "CA1024:UsePropertiesWhereAppropriate")]
		string GetMappedHref();

		string ToMappedLink();
		string ToPermanentLink();

		#endregion
	}
}