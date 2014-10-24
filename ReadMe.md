# HansKindberg-EPiServer-Modules

## Test it as a user (no automation tests I mean)
You can copy the **Module** on build. You need to

- If you previously have installed the **Module** you better uninstall it first or manually remove the module-nupkg-directory (HansKindberg.EPiServer.Modules.ModuleTemplate) from /Modules/_protected/ and the HansKindberg.EPiServer.Modules.ModuleTemplate.dll from **ModulesBin**
- [Set the **CopyModuleOnBuild** build-property to **true**](/EPiServer/Build/Build.props#L5)
- In the EPiServer project add a reference to the **Module** project
- In the EPiServer project remove the **HansKindberg.EPiServer.Shell.Modules** project reference

You can test installing the Module. You need to
- [Set the **CopyModuleOnBuild** build-property to **false**](/EPiServer/Build/Build.props#L5)
- In the EPiServer project remove the **Module** project reference
- In the EPiServer project add a reference to the **HansKindberg.EPiServer.Shell.Modules** project