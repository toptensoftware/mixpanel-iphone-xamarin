using System;
using MonoTouch.ObjCRuntime;


[assembly: LinkWith ("libMixPanel.a", LinkTarget.ArmV7 | LinkTarget.ArmV7s | LinkTarget.Simulator,
	Frameworks = "Foundation, CoreTelephony, UIKit, SystemConfiguration", 
	WeakFrameworks = "AdSupport",  LinkerFlags="-licucore", 
	ForceLoad = true)]
