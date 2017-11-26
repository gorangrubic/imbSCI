using System.Reflection;

// This should be the same version as below
[assembly: AssemblyFileVersion("0.1.*")]

#if DEBUG
[assembly: AssemblyInformationalVersion("0.1.*")]
#else
[assembly: AssemblyInformationalVersion("0.1.9")]
#endif
