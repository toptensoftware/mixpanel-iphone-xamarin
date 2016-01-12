using System;
using ObjCRuntime;
using Foundation;
using UIKit;

namespace MixPanel
{
	[BaseType (typeof (NSObject))]
	public partial interface Mixpanel
	{

		[Export ("people", ArgumentSemantic.Retain)]
		MixpanelPeople People { get; }

		[Export ("distinctId", ArgumentSemantic.Copy)]
		string DistinctId { get; }

		[Export ("nameTag", ArgumentSemantic.Copy)]
		string NameTag { get; set; }

		[Export ("serverURL", ArgumentSemantic.Copy)]
		string ServerURL { get; set; }

		[Export ("flushInterval")]
		uint FlushInterval { get; set; }

		[Export ("flushOnBackground")]
		bool FlushOnBackground { get; set; }

		[Export ("showNetworkActivityIndicator")]
		bool ShowNetworkActivityIndicator { get; set; }

		[Export ("checkForSurveysOnActive")]
		bool CheckForSurveysOnActive { get; set; }

		[Export ("showSurveyOnActive")]
		bool ShowSurveyOnActive { get; set; }

		[Export ("checkForNotificationsOnActive")]
		bool CheckForNotificationsOnActive { get; set; }

		[Export ("checkForVariantsOnActive")]
		bool CheckForVariantsOnActive { get; set; }

		[Export ("showNotificationOnActive")]
		bool ShowNotificationOnActive { get; set; }

		[Export ("miniNotificationPresentationTime")]
		nfloat MiniNotificationPresentationTime { get; set; }

		[Export ("delegate", ArgumentSemantic.Assign)]
		MixpanelDelegate Delegate { get; set; }

		[Static, Export ("sharedInstanceWithToken:")]
		Mixpanel SharedInstanceWithToken (string apiToken);

		[Static, Export ("sharedInstance")]
		Mixpanel SharedInstance { get; }

		[Export ("initWithToken:launchOptions:andFlushInterval:")]
		IntPtr Constructor (string apiToken, NSDictionary launchOptions, uint flushInterval);

		[Export ("initWithToken:andFlushInterval:")]
		IntPtr Constructor (string apiToken, uint flushInterval);

		[Export ("identify:")]
		void Identify (string distinctId);

		[Export ("track:")]
		void Track (string evt);

		[Export ("track:properties:")]
		void Track (string evt, NSDictionary properties);

		[Export ("trackPushNotification:")]
		void TrackPushNotification(NSDictionary userinfo);

		[Export ("registerSuperProperties:")]
		void RegisterSuperProperties (NSDictionary properties);

		[Export ("registerSuperPropertiesOnce:")]
		void RegisterSuperPropertiesOnce (NSDictionary properties);

		[Export ("registerSuperPropertiesOnce:defaultValue:")]
		void RegisterSuperPropertiesOnce (NSDictionary properties, NSObject defaultValue);

		[Export ("unregisterSuperProperty:")]
		void UnregisterSuperProperty (string propertyName);

		[Export ("clearSuperProperties")]
		void ClearSuperProperties ();

		[Export ("currentSuperProperties")]
		NSDictionary CurrentSuperProperties { get; }

		[Export ("timeEvent:")]
		void TimeEvent(string evt);

		[Export ("clearTimedEvents")]
		void ClearTimedEvents();

		[Export ("reset")]
		void Reset ();

		[Export ("flush")]
		void Flush ();

		[Export ("archive")]
		void Archive ();

		[Export ("showSurveyWithID:")]
		void ShowSurveyWithID(uint ID);

		[Export ("showSurvey")]
		void ShowSurvey();

		[Export ("showNotificationWithID:")]
		void ShowNotificationWithID(uint ID);

		[Export ("showNotificationWithType:")]
		void ShowNotificationWithType(string ID);

		[Export ("showNotification")]
		void ShowNotification();

		[Export ("joinExperiments")]
		void JoinExperiments();

		[Export ("createAlias:forDistinctID:")]
		void CreateAliasForDistinctID(string alias, string distinctID);
	}

	[BaseType (typeof (NSObject))]
	public partial interface MixpanelPeople
	{

		[Export ("addPushDeviceToken:")]
		void AddPushDeviceToken (NSData deviceToken);

		[Export ("set:")]
		NSDictionary Set (NSDictionary properties);

		[Export ("set:to:")]
		void Set (string property, NSObject obj);

		[Export ("setOnce:")]
		void SetOnce(NSDictionary properties);

		[Export ("increment:")]
		void Increment (NSDictionary properties);

		[Export ("increment:by:")]
		void Increment (string property, NSNumber amount);

		[Export ("append:")]
		void Append (NSDictionary properties);

		[Export ("union:")]
		void Union (NSDictionary properties);

		[Export ("trackCharge:")]
		void TrackCharge (NSNumber amount);

		[Export ("trackCharge:withProperties:")]
		void TrackCharge (NSNumber amount, NSDictionary properties);

		[Export ("clearCharges")]
		void ClearCharges ();

		[Export ("deleteUser")]
		void DeleteUser ();
	}

	[Model, BaseType (typeof (NSObject))]
	public partial interface MixpanelDelegate
	{

		[Export ("mixpanelWillFlush:")]
		bool mixpanelWillFlush (Mixpanel mixpanel);
	}

	[BaseType (typeof (NSObject))]
	public partial interface MPTweak
	{
		[Export ("initWithName:andEncoding:")]
		IntPtr Constructor (string name, string encoding);

		[Export ("name", ArgumentSemantic.Copy)]
		string Name { get; }

		[Export ("encoding", ArgumentSemantic.Copy)]
		string Encoding { get; }

		[Export ("defaultValue", ArgumentSemantic.Strong)]
		NSObject DefaultValue { get; set; }

		[Export ("currentValue", ArgumentSemantic.Strong)]
		NSObject CurrentValue { get; set; }

		[Export ("minimumValue", ArgumentSemantic.Strong)]
		NSObject MinimumValue { get; set; }

		[Export ("maximumValue", ArgumentSemantic.Strong)]
		NSObject MaximumValue { get; set; }

	}

	[BaseType (typeof (NSObject))]
	public partial interface MPTweakStore
	{
		[Static, Export ("sharedInstance")]
		MPTweakStore SharedInstance ();

		[Export ("tweaks", ArgumentSemantic.Copy)]
		MPTweak[] Tweaks { get; }

		[Export ("tweakWithName:")]
		MPTweak TweakWithName (string name);

		[Export ("addTweak:")]
		void AddTweak (MPTweak tweak);

		[Export ("removeTweak:")]
		void RemoveTweak (MPTweak tweak);

		[Export ("reset")]
		void Reset ();
	}

}
/*
	[BaseType (typeof (NSObject))]
	public partial interface MPCJSONSerializer
	{

		[Static, Export ("serializer")]
		NSObject Serializer { get; }

		[Export ("serializeObject:error:")]
		string SerializeObject (NSObject inObject, out NSError outError);

		[Export ("serializeArray:error:")]
		string SerializeArray (NSArray inArray, out NSError outError);

		[Export ("serializeDictionary:error:")]
		string SerializeDictionary (NSDictionary inDictionary, out NSError outError);
	}}

	[BaseType (typeof (NSObject))]
	public partial interface MPCJSONDataSerializer
	{

		[Static, Export ("serializer")]
		NSObject Serializer { get; }

		[Export ("serializeObject:error:")]
		NSData SerializeObject (NSObject inObject, out NSError outError);

		[Export ("serializeNull:error:")]
		NSData SerializeNull (NSNull inNull, out NSError outError);

		[Export ("serializeNumber:error:")]
		NSData SerializeNumber (NSNumber inNumber, out NSError outError);

		[Export ("serializeString:error:")]
		NSData SerializeString (string inString, out NSError outError);

		[Export ("serializeArray:error:")]
		NSData SerializeArray (NSArray inArray, out NSError outError);

		[Export ("serializeDictionary:error:")]
		NSData SerializeDictionary (NSDictionary inDictionary, out NSError outError);
	}

	[BaseType (typeof (NSObject))]
	public partial interface MPCSerializedJSONData
	{

		[Export ("data", ArgumentSemantic.Retain)]
		NSData Data { get; }

		[Export ("initWithData:")]
		IntPtr Constructor (NSData inData);
	}

	[Category, BaseType (typeof (NSData))]
	public partial interface MP_Base64_NSData
	{

		[Static, Export ("mp_dataFromBase64String:")]
		NSData Mp_dataFromBase64String (string aString);

		[Static, Export ("mp_base64EncodedString")]
		string Mp_base64EncodedString { get; }
	}

*/