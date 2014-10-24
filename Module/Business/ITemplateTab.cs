using System;

namespace HansKindberg.EPiServer.ModuleTemplate.Business
{
	public interface ITemplateTab
	{
		#region Properties

		bool Active { get; }
		string Description { get; }
		int Index { get; }
		string LocalDescription { get; }
		string LocalName { get; }
		string LocalizationPath { get; }
		string Name { get; }
		TemplateTabType TabType { get; }
		Uri Url { get; }

		#endregion
	}
}