using System;
using ObjCRuntime;


[assembly: LinkWith ("libMixPanel.a", LinkTarget.ArmV7 | LinkTarget.Arm64 | LinkTarget.Simulator | LinkTarget.Simulator64,
	Frameworks = "Foundation, CoreTelephony, UIKit, SystemConfiguration", 
	WeakFrameworks = "AdSupport",  LinkerFlags="-licucore", 
	ForceLoad = true)]
