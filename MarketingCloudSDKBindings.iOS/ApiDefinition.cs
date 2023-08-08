using System;
using CoreLocation;
using Foundation;
using ObjCRuntime;
using SFMCSDK.iOS;
using UIKit;
using UserNotifications;

#if !NET
using NativeHandle = System.IntPtr;
#endif

namespace MarketingCloudSDK
{
    // @interface MobilePushSDK : NSObject
    [BaseType(typeof(NSObject))]
    [DisableDefaultCtor]
    interface MobilePushSDK
    {
        // +(instancetype _Nonnull)sharedInstance;
        [Static]
        [Export("sharedInstance")]
        MobilePushSDK SharedInstance();

        // -(BOOL)sfmc_configureWithDictionary:(NSDictionary * _Nonnull)configuration error:(NSError * _Nullable * _Nullable)error;
        [Export("sfmc_configureWithDictionary:error:")]
        bool Sfmc_configureWithDictionary(NSDictionary configuration, [NullAllowed] out NSError error);

        // -(BOOL)sfmc_configureWithDictionary:(NSDictionary * _Nonnull)configuration error:(NSError * _Nullable * _Nullable)error completionHandler:(void (^ _Nullable)(BOOL, NSString * _Nonnull, NSError * _Nonnull))completionHandler;
        [Export("sfmc_configureWithDictionary:error:completionHandler:")]
        bool Sfmc_configureWithDictionary(NSDictionary configuration, [NullAllowed] out NSError error, [NullAllowed] Action<bool, NSString, NSError> completionHandler);

        // -(void)sfmc_tearDown;
        [Export("sfmc_tearDown")]
        void Sfmc_tearDown();

        // -(BOOL)sfmc_setContactKey:(NSString * _Nonnull)contactKey;
        [Export("sfmc_setContactKey:")]
        bool Sfmc_setContactKey(string contactKey);

        // -(NSString * _Nullable)sfmc_contactKey;
        [NullAllowed, Export("sfmc_contactKey")]
        // [Verify(MethodToProperty)]
        string Sfmc_contactKey { get; }

        // -(BOOL)sfmc_addTag:(NSString * _Nonnull)tag;
        [Export("sfmc_addTag:")]
        bool Sfmc_addTag(string tag);

        // -(BOOL)sfmc_removeTag:(NSString * _Nonnull)tag;
        [Export("sfmc_removeTag:")]
        bool Sfmc_removeTag(string tag);

        // -(NSSet * _Nullable)sfmc_addTags:(NSArray * _Nonnull)tags;
        [Export("sfmc_addTags:")]
        // [Verify(StronglyTypedNSArray)]
        [return: NullAllowed]
        NSSet Sfmc_addTags(NSObject[] tags);

        // -(NSSet * _Nullable)sfmc_removeTags:(NSArray * _Nonnull)tags;
        [Export("sfmc_removeTags:")]
        // [Verify(StronglyTypedNSArray)]
        [return: NullAllowed]
        NSSet Sfmc_removeTags(NSObject[] tags);

        // -(NSSet * _Nullable)sfmc_tags;
        [NullAllowed, Export("sfmc_tags")]
        // [Verify(MethodToProperty)]
        NSSet Sfmc_tags { get; }

        // -(BOOL)sfmc_setAttributeNamed:(NSString * _Nonnull)name value:(NSString * _Nonnull)value;
        [Export("sfmc_setAttributeNamed:value:")]
        bool Sfmc_setAttributeNamed(string name, string value);

        // -(BOOL)sfmc_clearAttributeNamed:(NSString * _Nonnull)name;
        [Export("sfmc_clearAttributeNamed:")]
        bool Sfmc_clearAttributeNamed(string name);

        // -(NSDictionary * _Nullable)sfmc_attributes;
        [NullAllowed, Export("sfmc_attributes")]
        // [Verify(MethodToProperty)]
        NSDictionary Sfmc_attributes { get; }

        // -(NSDictionary * _Nullable)sfmc_setAttributes:(NSArray * _Nonnull)attributes;
        [Export("sfmc_setAttributes:")]
        // [Verify(StronglyTypedNSArray)]
        [return: NullAllowed]
        NSDictionary Sfmc_setAttributes(NSObject[] attributes);

        // -(NSDictionary * _Nullable)sfmc_clearAttributesNamed:(NSArray * _Nonnull)attributeNames;
        [Export("sfmc_clearAttributesNamed:")]
        // [Verify(StronglyTypedNSArray)]
        [return: NullAllowed]
        NSDictionary Sfmc_clearAttributesNamed(NSObject[] attributeNames);

        // -(void)sfmc_setDeviceToken:(NSData * _Nonnull)deviceToken;
        [Export("sfmc_setDeviceToken:")]
        void Sfmc_setDeviceToken(NSData deviceToken);

        // -(NSString * _Nullable)sfmc_deviceToken;
        [NullAllowed, Export("sfmc_deviceToken")]
        // [Verify(MethodToProperty)]
        string Sfmc_deviceToken { get; }

        // -(NSString * _Nullable)sfmc_appID;
        [NullAllowed, Export("sfmc_appID")]
        // [Verify(MethodToProperty)]
        string Sfmc_appID { get; }

        // -(NSString * _Nullable)sfmc_accessToken;
        [NullAllowed, Export("sfmc_accessToken")]
        // [Verify(MethodToProperty)]
        string Sfmc_accessToken { get; }

        // -(NSString * _Nullable)sfmc_deviceIdentifier;
        [NullAllowed, Export("sfmc_deviceIdentifier")]
        // [Verify(MethodToProperty)]
        string Sfmc_deviceIdentifier { get; }

        // -(void)sfmc_setNotificationRequest:(UNNotificationRequest * _Nonnull)request __attribute__((availability(ios, introduced=10)));
        [iOS(10, 0)]
        [Export("sfmc_setNotificationRequest:")]
        void Sfmc_setNotificationRequest(UNNotificationRequest request);

        // -(UNNotificationRequest * _Nonnull)sfmc_notificationRequest __attribute__((availability(ios, introduced=10)));
        [iOS(10, 0)]
        [Export("sfmc_notificationRequest")]
        // [Verify(MethodToProperty)]
        UNNotificationRequest Sfmc_notificationRequest { get; }

        // -(void)sfmc_setNotificationUserInfo:(NSDictionary * _Nonnull)userInfo;
        [Export("sfmc_setNotificationUserInfo:")]
        void Sfmc_setNotificationUserInfo(NSDictionary userInfo);

        // -(NSDictionary * _Nonnull)sfmc_notificationUserInfo;
        [Export("sfmc_notificationUserInfo")]
        // [Verify(MethodToProperty)]
        NSDictionary Sfmc_notificationUserInfo { get; }

        // -(void)sfmc_setPushEnabled:(BOOL)pushEnabled;
        [Export("sfmc_setPushEnabled:")]
        void Sfmc_setPushEnabled(bool pushEnabled);

        // -(BOOL)sfmc_pushEnabled;
        [Export("sfmc_pushEnabled")]
        // [Verify(MethodToProperty)]
        bool Sfmc_pushEnabled { get; }

        // -(NSString * _Nullable)sfmc_getSDKState __attribute__((swift_name("sfmc_getSDKState()")));
        [NullAllowed, Export("sfmc_getSDKState")]
        // [Verify(MethodToProperty)]
        string Sfmc_getSDKState { get; }

        // -(void)sfmc_setDebugLoggingEnabled:(BOOL)enabled;
        [Export("sfmc_setDebugLoggingEnabled:")]
        void Sfmc_setDebugLoggingEnabled(bool enabled);

        // -(BOOL)sfmc_getDebugLoggingEnabled;
        [Export("sfmc_getDebugLoggingEnabled")]
        // [Verify(MethodToProperty)]
        bool Sfmc_getDebugLoggingEnabled { get; }

        // -(BOOL)sfmc_refreshWithFetchCompletionHandler:(void (^ _Nullable)(UIBackgroundFetchResult))completionHandler;
        [Export("sfmc_refreshWithFetchCompletionHandler:")]
        bool Sfmc_refreshWithFetchCompletionHandler([NullAllowed] Action<UIBackgroundFetchResult> completionHandler);

        // -(BOOL)sfmc_setSignedString:(NSString * _Nullable)signedString;
        [Export("sfmc_setSignedString:")]
        bool Sfmc_setSignedString([NullAllowed] string signedString);

        // -(void)sfmc_setRegistrationCallback:(void (^ _Nonnull)(NSDictionary * _Nonnull))registrationCallback;
        [Export("sfmc_setRegistrationCallback:")]
        void Sfmc_setRegistrationCallback(Action<NSDictionary> registrationCallback);

        // -(void)sfmc_unsetRegistrationCallback;
        [Export("sfmc_unsetRegistrationCallback")]
        void Sfmc_unsetRegistrationCallback();

        // -(NSString * _Nullable)sfmc_signedString;
        [NullAllowed, Export("sfmc_signedString")]
        // [Verify(MethodToProperty)]
        string Sfmc_signedString { get; }

        // -(BOOL)sfmc_isReady;
        [Export("sfmc_isReady")]
        // [Verify(MethodToProperty)]
        bool Sfmc_isReady { get; }

        // -(BOOL)sfmc_isInitializing;
        [Export("sfmc_isInitializing")]
        // [Verify(MethodToProperty)]
        bool Sfmc_isInitializing { get; }

        // -(BOOL)sfmc_resetDataPolicy;
        [Export("sfmc_resetDataPolicy")]
        // [Verify(MethodToProperty)]
        bool Sfmc_resetDataPolicy { get; }
    }

    // @protocol SFMCEvent <NSObject>
    /*
      Check whether adding [Model] to this declaration is appropriate.
      [Model] is used to generate a C# class that implements this protocol,
      and might be useful for protocols that consumers are supposed to implement,
      since consumers can subclass the generated class instead of implementing
      the generated interface. If consumers are not supposed to implement this
      protocol, then [Model] is redundant and will generate code that will never
      be used.
    */
    [Protocol]
    [BaseType(typeof(NSObject))]
    partial interface SFMCEvent
    {
        // @required -(NSString * _Nonnull)key;
        [Abstract]
        [Export("key")]
        // [Verify(MethodToProperty)]
        string Key { get; }

        // @required -(NSString * _Nullable)eventId;
        [Abstract]
        [NullAllowed, Export("eventId")]
        // [Verify(MethodToProperty)]
        string EventId { get; }

        // @required -(NSDictionary<NSString *,id> * _Nullable)parameters;
        [Abstract]
        [NullAllowed, Export("parameters")]
        // [Verify(MethodToProperty)]
        NSDictionary<NSString, NSObject> Parameters { get; }
    }

    // @interface SFMCEvent : NSObject
    //[BaseType(typeof(NSObject))]
    partial interface SFMCEvent
    {
        // +(id<SFMCEvent> _Nullable)customEventWithName:(NSString * _Nonnull)key;
        [Static]
        [Export("customEventWithName:")]
        [return: NullAllowed]
        SFMCEvent CustomEventWithName(string key);

        // +(id<SFMCEvent> _Nullable)customEventWithName:(NSString * _Nonnull)key withEventId:(NSString * _Nonnull)eventId;
        [Static]
        [Export("customEventWithName:withEventId:")]
        [return: NullAllowed]
        SFMCEvent CustomEventWithName(string key, string eventId);

        // +(id<SFMCEvent> _Nullable)customEventWithName:(NSString * _Nonnull)key withAttributes:(NSDictionary<NSString *,id> * _Nonnull)parameters;
        [Static]
        [Export("customEventWithName:withAttributes:")]
        [return: NullAllowed]
        SFMCEvent CustomEventWithName(string key, NSDictionary<NSString, NSObject> parameters);

        // +(id<SFMCEvent> _Nullable)customEventWithName:(NSString * _Nonnull)key withEventId:(NSString * _Nonnull)eventId withAttributes:(NSDictionary<NSString *,id> * _Nonnull)parameters;
        [Static]
        [Export("customEventWithName:withEventId:withAttributes:")]
        [return: NullAllowed]
        SFMCEvent CustomEventWithName(string key, string eventId, NSDictionary<NSString, NSObject> parameters);

        // +(NSDictionary<NSString *,id> * _Nullable)parseAndTrim:(NSDictionary<NSString *,id> * _Nonnull)parameters;
        [Static]
        [Export("parseAndTrim:")]
        [return: NullAllowed]
        NSDictionary<NSString, NSObject> ParseAndTrim(NSDictionary<NSString, NSObject> parameters);

        // +(NSString * _Nullable)validateAndPrepareKey:(id _Nonnull)key;
        [Static]
        [Export("validateAndPrepareKey:")]
        [return: NullAllowed]
        string ValidateAndPrepareKey(NSObject key);
    }

    // @interface Intelligence (MobilePushSDK)
    [Category]
    [BaseType(typeof(MobilePushSDK))]
    interface MobilePushSDK_Intelligence
    {
        // -(BOOL)sfmc_setPiIdentifier:(NSString * _Nullable)identifier;
        [Export("sfmc_setPiIdentifier:")]
        bool Sfmc_setPiIdentifier([NullAllowed] string identifier);

        // -(NSString * _Nullable)sfmc_piIdentifier;
        [NullAllowed, Export("sfmc_piIdentifier")]
        // [Verify(MethodToProperty)]
        string Sfmc_piIdentifier();

        // -(void)sfmc_trackMessageOpened:(NSDictionary * _Nonnull)inboxMessage;
        [Export("sfmc_trackMessageOpened:")]
        void Sfmc_trackMessageOpened(NSDictionary inboxMessage);

        // -(void)sfmc_trackPageViewWithURL:(NSString * _Nonnull)url title:(NSString * _Nullable)title item:(NSString * _Nullable)item search:(NSString * _Nullable)search;
        [Export("sfmc_trackPageViewWithURL:title:item:search:")]
        void Sfmc_trackPageViewWithURL(string url, [NullAllowed] string title, [NullAllowed] string item, [NullAllowed] string search);

        // -(void)sfmc_trackCartContents:(NSDictionary * _Nonnull)cartDictionary;
        [Export("sfmc_trackCartContents:")]
        void Sfmc_trackCartContents(NSDictionary cartDictionary);

        // -(void)sfmc_trackCartConversion:(NSDictionary * _Nonnull)orderDictionary;
        [Export("sfmc_trackCartConversion:")]
        void Sfmc_trackCartConversion(NSDictionary orderDictionary);

        // -(NSDictionary * _Nullable)sfmc_cartItemDictionaryWithPrice:(NSNumber * _Nonnull)price quantity:(NSNumber * _Nonnull)quantity item:(NSString * _Nonnull)item uniqueId:(NSString * _Nullable)uniqueId;
        [Export("sfmc_cartItemDictionaryWithPrice:quantity:item:uniqueId:")]
        [return: NullAllowed]
        NSDictionary Sfmc_cartItemDictionaryWithPrice(NSNumber price, NSNumber quantity, string item, [NullAllowed] string uniqueId);

        // -(NSDictionary * _Nullable)sfmc_cartDictionaryWithCartItemDictionaryArray:(NSArray * _Nonnull)cartItemDictionaryArray;
        [Export("sfmc_cartDictionaryWithCartItemDictionaryArray:")]
        // [Verify(StronglyTypedNSArray)]
        [return: NullAllowed]
        NSDictionary Sfmc_cartDictionaryWithCartItemDictionaryArray(NSObject[] cartItemDictionaryArray);

        // -(NSDictionary * _Nullable)sfmc_orderDictionaryWithOrderNumber:(NSString * _Nonnull)orderNumber shipping:(NSNumber * _Nonnull)shipping discount:(NSNumber * _Nonnull)discount cart:(NSDictionary * _Nonnull)cartDictionary;
        [Export("sfmc_orderDictionaryWithOrderNumber:shipping:discount:cart:")]
        [return: NullAllowed]
        NSDictionary Sfmc_orderDictionaryWithOrderNumber(string orderNumber, NSNumber shipping, NSNumber discount, NSDictionary cartDictionary);
    }

    [Static]
    // [Verify(ConstantsInterfaceAssociation)]
    partial interface Constants
    {
        // extern NSString *const _Nonnull MarketingCloudSDKInboxMessageKey;
        [Field("MarketingCloudSDKInboxMessageKey", "__Internal")]
        NSString MarketingCloudSDKInboxMessageKey { get; }
    }

    // @interface MarketingCloudSDKInboxMessagesDataSource : NSObject <SFMCSdkInboxMessagesDataSource>
    [BaseType(typeof(NSObject))]
    interface MarketingCloudSDKInboxMessagesDataSource : ISFMCSdkInboxMessagesDataSource
    {
        // -(id _Nullable)initWithMarketingCloudSDK:(MobilePushSDK * _Nonnull)sdk tableView:(UITableView * _Nonnull)tableView;
        [Export("initWithMarketingCloudSDK:tableView:")]
        NativeHandle Constructor(MobilePushSDK sdk, UITableView tableView);
    }

    // @interface MarketingCloudSDKInboxMessagesDelegate : NSObject <SFMCSdkInboxMessagesDelegate>
    [BaseType(typeof(NSObject))]
    interface MarketingCloudSDKInboxMessagesDelegate : ISFMCSdkInboxMessagesDelegate
    {
        // -(id _Nullable)initWithMarketingCloudSDK:(MobilePushSDK * _Nonnull)sdk tableView:(UITableView * _Nonnull)tableView dataSource:(MarketingCloudSDKInboxMessagesDataSource * _Nonnull)dataSource;
        [Export("initWithMarketingCloudSDK:tableView:dataSource:")]
        NativeHandle Constructor(MobilePushSDK sdk, UITableView tableView, MarketingCloudSDKInboxMessagesDataSource dataSource);
    }

    // @interface InboxMessages (MobilePushSDK)
    [Category]
    [BaseType(typeof(MobilePushSDK))]
    interface MobilePushSDK_InboxMessages
    {
        // -(NSArray * _Nullable)sfmc_getAllMessages;
        [NullAllowed, Export("sfmc_getAllMessages")]
        // [Verify(MethodToProperty), Verify(StronglyTypedNSArray)]
        NSObject[] Sfmc_getAllMessages();

        // -(NSArray * _Nullable)sfmc_getUnreadMessages;
        [NullAllowed, Export("sfmc_getUnreadMessages")]
        // [Verify(MethodToProperty), Verify(StronglyTypedNSArray)]
        NSObject[] Sfmc_getUnreadMessages();

        // -(NSArray * _Nullable)sfmc_getReadMessages;
        [NullAllowed, Export("sfmc_getReadMessages")]
        // [Verify(MethodToProperty), Verify(StronglyTypedNSArray)]
        NSObject[] Sfmc_getReadMessages();

        // -(NSArray * _Nullable)sfmc_getDeletedMessages;
        [NullAllowed, Export("sfmc_getDeletedMessages")]
        // [Verify(MethodToProperty), Verify(StronglyTypedNSArray)]
        NSObject[] Sfmc_getDeletedMessages();

        // -(NSUInteger)sfmc_getAllMessagesCount;
        [Export("sfmc_getAllMessagesCount")]
        // [Verify(MethodToProperty)]
        nuint Sfmc_getAllMessagesCount();

        // -(NSUInteger)sfmc_getUnreadMessagesCount;
        [Export("sfmc_getUnreadMessagesCount")]
        // [Verify(MethodToProperty)]
        nuint Sfmc_getUnreadMessagesCount();

        // -(NSUInteger)sfmc_getReadMessagesCount;
        [Export("sfmc_getReadMessagesCount")]
        // [Verify(MethodToProperty)]
        nuint Sfmc_getReadMessagesCount();

        // -(NSUInteger)sfmc_getDeletedMessagesCount;
        [Export("sfmc_getDeletedMessagesCount")]
        // [Verify(MethodToProperty)]
        nuint Sfmc_getDeletedMessagesCount();

        // -(BOOL)sfmc_markMessageRead:(NSDictionary * _Nonnull)messageDictionary;
        [Export("sfmc_markMessageRead:")]
        bool Sfmc_markMessageRead(NSDictionary messageDictionary);

        // -(BOOL)sfmc_markMessageDeleted:(NSDictionary * _Nonnull)messageDictionary;
        [Export("sfmc_markMessageDeleted:")]
        bool Sfmc_markMessageDeleted(NSDictionary messageDictionary);

        // -(BOOL)sfmc_markMessageWithIdRead:(NSString * _Nonnull)messageId;
        [Export("sfmc_markMessageWithIdRead:")]
        bool Sfmc_markMessageWithIdRead(string messageId);

        // -(BOOL)sfmc_markMessageWithIdDeleted:(NSString * _Nonnull)messageId;
        [Export("sfmc_markMessageWithIdDeleted:")]
        bool Sfmc_markMessageWithIdDeleted(string messageId);

        // -(BOOL)sfmc_markAllMessagesRead;
        [Export("sfmc_markAllMessagesRead")]
        // [Verify(MethodToProperty)]
        bool Sfmc_markAllMessagesRead();

        // -(BOOL)sfmc_markAllMessagesDeleted;
        [Export("sfmc_markAllMessagesDeleted")]
        // [Verify(MethodToProperty)]
        bool Sfmc_markAllMessagesDeleted();

        // -(BOOL)sfmc_refreshMessages;
        [Export("sfmc_refreshMessages")]
        // [Verify(MethodToProperty)]
        bool Sfmc_refreshMessages();

        // -(MarketingCloudSDKInboxMessagesDataSource * _Nullable)sfmc_inboxMessagesTableViewDataSourceForTableView:(UITableView * _Nonnull)tableView;
        [Export("sfmc_inboxMessagesTableViewDataSourceForTableView:")]
        [return: NullAllowed]
        MarketingCloudSDKInboxMessagesDataSource Sfmc_inboxMessagesTableViewDataSourceForTableView(UITableView tableView);

        // -(MarketingCloudSDKInboxMessagesDelegate * _Nullable)sfmc_inboxMessagesTableViewDelegateForTableView:(UITableView * _Nonnull)tableView dataSource:(MarketingCloudSDKInboxMessagesDataSource * _Nonnull)dataSource;
        [Export("sfmc_inboxMessagesTableViewDelegateForTableView:dataSource:")]
        [return: NullAllowed]
        MarketingCloudSDKInboxMessagesDelegate Sfmc_inboxMessagesTableViewDelegateForTableView(UITableView tableView, MarketingCloudSDKInboxMessagesDataSource dataSource);
    }

    // @protocol MarketingCloudSDKLocationDelegate <NSObject>
    [Protocol, Model(AutoGeneratedName = true)]
    [BaseType(typeof(NSObject))]
    interface MarketingCloudSDKLocationDelegate
    {
        // @required -(BOOL)sfmc_shouldShowLocationMessage:(NSDictionary * _Nonnull)message forRegion:(NSDictionary * _Nonnull)region;
        [Abstract]
        [Export("sfmc_shouldShowLocationMessage:forRegion:")]
        bool ForRegion(NSDictionary message, NSDictionary region);
    }

    // @interface Location (MobilePushSDK)
    [Category]
    [BaseType(typeof(MobilePushSDK))]
    interface MobilePushSDK_Location
    {
        // -(void)sfmc_setLocationDelegate:(id<MarketingCloudSDKLocationDelegate> _Nullable)delegate;
        [Export("sfmc_setLocationDelegate:")]
        void Sfmc_setLocationDelegate([NullAllowed] MarketingCloudSDKLocationDelegate @delegate);

        // -(void)sfmc_setSFMCSdkLocationDelegate:(id<SFMCSdkLocationDelegate> _Nullable)delegate;
        [Export("sfmc_setSFMCSdkLocationDelegate:")]
        void Sfmc_setSFMCSdkLocationDelegate([NullAllowed] SFMCSdkLocationDelegate @delegate);

        // -(CLRegion * _Nullable)sfmc_regionFromDictionary:(NSDictionary * _Nonnull)dictionary;
        [Export("sfmc_regionFromDictionary:")]
        [return: NullAllowed]
        CLRegion Sfmc_regionFromDictionary(NSDictionary dictionary);

        // -(BOOL)sfmc_locationEnabled;
        [Export("sfmc_locationEnabled")]
        // [Verify(MethodToProperty)]
        bool Sfmc_locationEnabled();

        // -(void)sfmc_startWatchingLocation;
        [Export("sfmc_startWatchingLocation")]
        void Sfmc_startWatchingLocation();

        // -(void)sfmc_stopWatchingLocation;
        [Export("sfmc_stopWatchingLocation")]
        void Sfmc_stopWatchingLocation();

        // -(BOOL)sfmc_watchingLocation;
        [Export("sfmc_watchingLocation")]
        // [Verify(MethodToProperty)]
        bool Sfmc_watchingLocation();

        // -(NSDictionary<NSString *,NSString *> * _Nullable)sfmc_lastKnownLocation;
        [NullAllowed, Export("sfmc_lastKnownLocation")]
        // [Verify(MethodToProperty)]
        NSDictionary<NSString, NSString> Sfmc_lastKnownLocation();
    }

    //[Static]
    // [Verify(ConstantsInterfaceAssociation)]
    partial interface Constants
    {
        // extern NSString *const _Nonnull MarketingCloudSDKErrorDomain;
        [Field("MarketingCloudSDKErrorDomain", "__Internal")]
        NSString MarketingCloudSDKErrorDomain { get; }

        // extern NSNotificationName  _Nonnull const SFMCFrameworkDidSetupNotification;
        [Field("SFMCFrameworkDidSetupNotification", "__Internal")]
        NSString SFMCFrameworkDidSetupNotification { get; }

        // extern NSNotificationName  _Nonnull const SFMCFrameworkDidTeardownNotification;
        [Field("SFMCFrameworkDidTeardownNotification", "__Internal")]
        NSString SFMCFrameworkDidTeardownNotification { get; }

        // extern NSNotificationName  _Nonnull const SFMCFoundationRegistrationResponseSucceededNotification;
        [Field("SFMCFoundationRegistrationResponseSucceededNotification", "__Internal")]
        NSString SFMCFoundationRegistrationResponseSucceededNotification { get; }

        // extern NSNotificationName  _Nonnull const SFMCFoundationUNNotificationReceivedNotification;
        [Field("SFMCFoundationUNNotificationReceivedNotification", "__Internal")]
        NSString SFMCFoundationUNNotificationReceivedNotification { get; }

        // extern NSNotificationName  _Nonnull const SFMCInboxMessagesRefreshCompleteNotification;
        [Field("SFMCInboxMessagesRefreshCompleteNotification", "__Internal")]
        NSString SFMCInboxMessagesRefreshCompleteNotification { get; }

        // extern NSNotificationName  _Nonnull const SFMCInboxMessagesNewInboxMessagesNotification;
        [Field("SFMCInboxMessagesNewInboxMessagesNotification", "__Internal")]
        NSString SFMCInboxMessagesNewInboxMessagesNotification { get; }

        // extern NSNotificationName  _Nonnull const SFMCInboxMessagesUpdateStatusCompleteNotification;
        [Field("SFMCInboxMessagesUpdateStatusCompleteNotification", "__Internal")]
        NSString SFMCInboxMessagesUpdateStatusCompleteNotification { get; }

        // extern NSNotificationName  _Nonnull const SFMCInboxMessagesNotificationHandledNotification;
        [Field("SFMCInboxMessagesNotificationHandledNotification", "__Internal")]
        NSString SFMCInboxMessagesNotificationHandledNotification { get; }

        // extern NSNotificationName  _Nonnull const SFMCOpenDirectMessageNotificationHandledNotification;
        [Field("SFMCOpenDirectMessageNotificationHandledNotification", "__Internal")]
        NSString SFMCOpenDirectMessageNotificationHandledNotification { get; }

        // extern NSNotificationName  _Nonnull const SFMCLocationDidFixLocationNotification;
        [Field("SFMCLocationDidFixLocationNotification", "__Internal")]
        NSString SFMCLocationDidFixLocationNotification { get; }

        // extern NSNotificationName  _Nonnull const SFMCLocationDidReceiveLocationUpdateNotification;
        [Field("SFMCLocationDidReceiveLocationUpdateNotification", "__Internal")]
        NSString SFMCLocationDidReceiveLocationUpdateNotification { get; }

        // extern NSNotificationName  _Nonnull const SFMCLocationGeofenceRefreshCompleteNotification;
        [Field("SFMCLocationGeofenceRefreshCompleteNotification", "__Internal")]
        NSString SFMCLocationGeofenceRefreshCompleteNotification { get; }

        // extern NSNotificationName  _Nonnull const SFMCDidEnterLocationRegionMessageNotification;
        [Field("SFMCDidEnterLocationRegionMessageNotification", "__Internal")]
        NSString SFMCDidEnterLocationRegionMessageNotification { get; }

        // extern NSNotificationName  _Nonnull const SFMCDidExitLocationRegionMessageNotification;
        [Field("SFMCDidExitLocationRegionMessageNotification", "__Internal")]
        NSString SFMCDidExitLocationRegionMessageNotification { get; }

        // extern NSNotificationName  _Nonnull const SFMCDidDisplayLocationMessageNotification;
        [Field("SFMCDidDisplayLocationMessageNotification", "__Internal")]
        NSString SFMCDidDisplayLocationMessageNotification { get; }

        // extern NSNotificationName  _Nonnull const SFMCBeaconRefreshCompleteNotification;
        [Field("SFMCBeaconRefreshCompleteNotification", "__Internal")]
        NSString SFMCBeaconRefreshCompleteNotification { get; }

        // extern NSNotificationName  _Nonnull const SFMCDidRangeBeaconLocationMessageNotification;
        [Field("SFMCDidRangeBeaconLocationMessageNotification", "__Internal")]
        NSString SFMCDidRangeBeaconLocationMessageNotification { get; }

        // extern NSNotificationName  _Nonnull const SFMCLocationDidStartMonitoringForRegionNotification;
        [Field("SFMCLocationDidStartMonitoringForRegionNotification", "__Internal")]
        NSString SFMCLocationDidStartMonitoringForRegionNotification { get; }

        // extern NSNotificationName  _Nonnull const SFMCFrameworkDidBlockNotification;
        [Field("SFMCFrameworkDidBlockNotification", "__Internal")]
        NSString SFMCFrameworkDidBlockNotification { get; }
    }

    //[Static]
    // [Verify(ConstantsInterfaceAssociation)]
    partial interface Constants
    {
        // extern NSString *const _Nonnull SFMCURLTypeCloudPage;
        [Field("SFMCURLTypeCloudPage", "__Internal")]
        NSString SFMCURLTypeCloudPage { get; }

        // extern NSString *const _Nonnull SFMCURLTypeOpenDirect;
        [Field("SFMCURLTypeOpenDirect", "__Internal")]
        NSString SFMCURLTypeOpenDirect { get; }

        // extern NSString *const _Nonnull SFMCURLTypeAction;
        [Field("SFMCURLTypeAction", "__Internal")]
        NSString SFMCURLTypeAction { get; }
    }

    // @protocol MarketingCloudSDKURLHandlingDelegate <NSObject>
    [Protocol, Model(AutoGeneratedName = true)]
    [BaseType(typeof(NSObject))]
    interface MarketingCloudSDKURLHandlingDelegate
    {
        // @required -(void)sfmc_handleURL:(NSURL * _Nonnull)url type:(NSString * _Nonnull)type;
        [Abstract]
        [Export("sfmc_handleURL:type:")]
        void Type(NSUrl url, string type);
    }

    // @interface URLHandling (MobilePushSDK)
    [Category]
    [BaseType(typeof(MobilePushSDK))]
    interface MobilePushSDK_URLHandling
    {
        // -(void)sfmc_setURLHandlingDelegate:(id<MarketingCloudSDKURLHandlingDelegate> _Nullable)delegate;
        [Export("sfmc_setURLHandlingDelegate:")]
        void Sfmc_setURLHandlingDelegate([NullAllowed] MarketingCloudSDKURLHandlingDelegate @delegate);

        // -(void)sfmc_setSFMCSdkURLHandlingDelegate:(id<SFMCSdkURLHandlingDelegate> _Nullable)delegate;
        [Export("sfmc_setSFMCSdkURLHandlingDelegate:")]
        void Sfmc_setSFMCSdkURLHandlingDelegate([NullAllowed] SFMCSdkURLHandlingDelegate @delegate);
    }

    // @protocol MarketingCloudSDKEventDelegate <NSObject>
    [Protocol, Model(AutoGeneratedName = true)]
    [BaseType(typeof(NSObject))]
    interface MarketingCloudSDKEventDelegate
    {
        // @optional -(BOOL)sfmc_shouldShowInAppMessage:(NSDictionary * _Nonnull)message;
        [Export("sfmc_shouldShowInAppMessage:")]
        bool Sfmc_shouldShowInAppMessage(NSDictionary message);

        // @optional -(void)sfmc_didShowInAppMessage:(NSDictionary * _Nonnull)message;
        [Export("sfmc_didShowInAppMessage:")]
        void Sfmc_didShowInAppMessage(NSDictionary message);

        // @optional -(void)sfmc_didCloseInAppMessage:(NSDictionary * _Nonnull)message;
        [Export("sfmc_didCloseInAppMessage:")]
        void Sfmc_didCloseInAppMessage(NSDictionary message);
    }

    // @interface Events (MobilePushSDK)
    [Category]
    [BaseType(typeof(MobilePushSDK))]
    interface MobilePushSDK_Events
    {
        // -(void)sfmc_setEventDelegate:(id<MarketingCloudSDKEventDelegate> _Nullable)delegate;
        [Export("sfmc_setEventDelegate:")]
        void Sfmc_setEventDelegate([NullAllowed] MarketingCloudSDKEventDelegate @delegate);

        // -(void)sfmc_setInAppEventDelegate:(id<SFMCSdkInAppMessageEventDelegate> _Nullable)delegate;
        [Export("sfmc_setInAppEventDelegate:")]
        void Sfmc_setInAppEventDelegate([NullAllowed] SFMCSdkInAppMessageEventDelegate @delegate);

        // -(NSString * _Nullable)sfmc_messageIdForMessage:(NSDictionary * _Nonnull)message;
        [Export("sfmc_messageIdForMessage:")]
        [return: NullAllowed]
        string Sfmc_messageIdForMessage(NSDictionary message);

        // -(void)sfmc_showInAppMessage:(NSString * _Nonnull)messageId;
        [Export("sfmc_showInAppMessage:")]
        void Sfmc_showInAppMessage(string messageId);

        // -(BOOL)sfmc_setInAppMessageFontName:(NSString * _Nullable)fontName;
        [Export("sfmc_setInAppMessageFontName:")]
        bool Sfmc_setInAppMessageFontName([NullAllowed] string fontName);

        // -(void)sfmc_track:(id _Nullable)events;
        [Export("sfmc_track:")]
        void Sfmc_track([NullAllowed] NSObject events);
    }

    // @interface MarketingCloudSDKConfigBuilder : NSObject
    [BaseType(typeof(NSObject))]
    interface MarketingCloudSDKConfigBuilder
    {
        // -(NSDictionary * _Nullable)sfmc_build;
        [NullAllowed, Export("sfmc_build")]
        // [Verify(MethodToProperty)]
        NSDictionary Sfmc_build { get; }

        // -(instancetype _Nonnull)sfmc_setApplicationId:(NSString * _Nonnull)setApplicationId;
        [Export("sfmc_setApplicationId:")]
        MarketingCloudSDKConfigBuilder Sfmc_setApplicationId(string setApplicationId);

        // -(instancetype _Nonnull)sfmc_setAccessToken:(NSString * _Nonnull)setAccessToken;
        [Export("sfmc_setAccessToken:")]
        MarketingCloudSDKConfigBuilder Sfmc_setAccessToken(string setAccessToken);

        // -(instancetype _Nonnull)sfmc_setLocationEnabled:(NSNumber * _Nonnull)setLocationEnabled;
        [Export("sfmc_setLocationEnabled:")]
        MarketingCloudSDKConfigBuilder Sfmc_setLocationEnabled(NSNumber setLocationEnabled);

        // -(instancetype _Nonnull)sfmc_setInboxEnabled:(NSNumber * _Nonnull)setInboxEnabled;
        [Export("sfmc_setInboxEnabled:")]
        MarketingCloudSDKConfigBuilder Sfmc_setInboxEnabled(NSNumber setInboxEnabled);

        // -(instancetype _Nonnull)sfmc_setPiAnalyticsEnabled:(NSNumber * _Nonnull)setPiAnalyticsEnabled;
        [Export("sfmc_setPiAnalyticsEnabled:")]
        MarketingCloudSDKConfigBuilder Sfmc_setPiAnalyticsEnabled(NSNumber setPiAnalyticsEnabled);

        // -(instancetype _Nonnull)sfmc_setUseLegacyPIIdentifier:(NSNumber * _Nonnull)etUseLegacyPIIdentifier;
        [Export("sfmc_setUseLegacyPIIdentifier:")]
        MarketingCloudSDKConfigBuilder Sfmc_setUseLegacyPIIdentifier(NSNumber etUseLegacyPIIdentifier);

        // -(instancetype _Nonnull)sfmc_setAnalyticsEnabled:(NSNumber * _Nonnull)setAnalyticsEnabled;
        [Export("sfmc_setAnalyticsEnabled:")]
        MarketingCloudSDKConfigBuilder Sfmc_setAnalyticsEnabled(NSNumber setAnalyticsEnabled);

        // -(instancetype _Nonnull)sfmc_setMid:(NSString * _Nonnull)setMid;
        [Export("sfmc_setMid:")]
        MarketingCloudSDKConfigBuilder Sfmc_setMid(string setMid);

        // -(instancetype _Nonnull)sfmc_setMarketingCloudServerUrl:(NSString * _Nonnull)setMarketingCloudServerUrl;
        [Export("sfmc_setMarketingCloudServerUrl:")]
        MarketingCloudSDKConfigBuilder Sfmc_setMarketingCloudServerUrl(string setMarketingCloudServerUrl);

        // -(instancetype _Nonnull)sfmc_setApplicationControlsBadging:(NSNumber * _Nonnull)setApplicationControlsBadging;
        [Export("sfmc_setApplicationControlsBadging:")]
        MarketingCloudSDKConfigBuilder Sfmc_setApplicationControlsBadging(NSNumber setApplicationControlsBadging);

        // -(instancetype _Nonnull)sfmc_setDelayRegistrationUntilContactKeyIsSet:(NSNumber * _Nonnull)delayRegistrationUntilContactKeyIsSet;
        [Export("sfmc_setDelayRegistrationUntilContactKeyIsSet:")]
        MarketingCloudSDKConfigBuilder Sfmc_setDelayRegistrationUntilContactKeyIsSet(NSNumber delayRegistrationUntilContactKeyIsSet);
    }

    // @interface PushConfig : NSObject <SFMCSdkModuleConfig>
    [BaseType(typeof(NSObject), Name = "_TtC17MarketingCloudSDK10PushConfig")]
    [DisableDefaultCtor]
    interface PushConfig : ISFMCSdkModuleConfig
    {
        // @property (nonatomic) BOOL trackScreens;
        [Export("trackScreens")]
        bool TrackScreens { get; set; }

        // @property (readonly, nonatomic) enum SFMCSdkModuleName name;
        [Export("name")]
        SFMCSdkModuleName Name { get; }

        // @property (readonly, copy, nonatomic) NSString * _Nonnull appId;
        [Export("appId")]
        string AppId { get; }
    }

    // @interface PushConfigBuilder : NSObject
    [BaseType(typeof(NSObject), Name = "_TtC17MarketingCloudSDK17PushConfigBuilder")]
    [DisableDefaultCtor]
    interface PushConfigBuilder
    {
        // -(instancetype _Nonnull)initWithAppId:(NSString * _Nonnull)appId __attribute__((objc_designated_initializer));
        [Export("initWithAppId:")]
        [DesignatedInitializer]
        NativeHandle Constructor(string appId);

        // -(PushConfigBuilder * _Nonnull)setAccessToken:(NSString * _Nonnull)accessToken;
        [Export("setAccessToken:")]
        PushConfigBuilder SetAccessToken(string accessToken);

        // -(PushConfigBuilder * _Nonnull)setMarketingCloudServerUrl:(NSURL * _Nonnull)endpoint;
        [Export("setMarketingCloudServerUrl:")]
        PushConfigBuilder SetMarketingCloudServerUrl(NSUrl endpoint);

        // -(PushConfigBuilder * _Nonnull)setMid:(NSString * _Nonnull)mid;
        [Export("setMid:")]
        PushConfigBuilder SetMid(string mid);

        // -(PushConfigBuilder * _Nonnull)setLocationEnabled:(BOOL)enabled;
        [Export("setLocationEnabled:")]
        PushConfigBuilder SetLocationEnabled(bool enabled);

        // -(PushConfigBuilder * _Nonnull)setInboxEnabled:(BOOL)enabled;
        [Export("setInboxEnabled:")]
        PushConfigBuilder SetInboxEnabled(bool enabled);

        // -(PushConfigBuilder * _Nonnull)setAnalyticsEnabled:(BOOL)enabled;
        [Export("setAnalyticsEnabled:")]
        PushConfigBuilder SetAnalyticsEnabled(bool enabled);

        // -(PushConfigBuilder * _Nonnull)setPIAnalyticsEnabled:(BOOL)enabled;
        [Export("setPIAnalyticsEnabled:")]
        PushConfigBuilder SetPIAnalyticsEnabled(bool enabled);

        // -(PushConfigBuilder * _Nonnull)setUseLegacyPIIdentifier:(BOOL)enabled;
        [Export("setUseLegacyPIIdentifier:")]
        PushConfigBuilder SetUseLegacyPIIdentifier(bool enabled);

        // -(PushConfigBuilder * _Nonnull)setApplicationControlsBadging:(BOOL)enabled;
        [Export("setApplicationControlsBadging:")]
        PushConfigBuilder SetApplicationControlsBadging(bool enabled);

        // -(PushConfigBuilder * _Nonnull)setDelayRegistrationUntilContactKeyIsSet:(BOOL)enabled;
        [Export("setDelayRegistrationUntilContactKeyIsSet:")]
        PushConfigBuilder SetDelayRegistrationUntilContactKeyIsSet(bool enabled);

        // -(PushConfigBuilder * _Nonnull)setEnableScreenEntryTracking:(BOOL)enabled;
        [Export("setEnableScreenEntryTracking:")]
        PushConfigBuilder SetEnableScreenEntryTracking(bool enabled);

        // -(PushConfig * _Nonnull)build;
        [Export("build")]
        // [Verify(MethodToProperty)]
        PushConfig Build();
    }

    // @interface SFMCSdkPushModule : NSObject <PushInterface, SFMCModule, Subscriber>
    [BaseType(typeof(NSObject))]
    [DisableDefaultCtor]
    interface SFMCSdkPushModule : IPushInterface, ISFMCModule, ISubscriber
    {
        // @property (nonatomic) enum SFMCSdkModuleName name;
        [Export("name", ArgumentSemantic.Assign)]
        SFMCSdkModuleName Name { get; set; }

        // @property (copy, nonatomic, class) NSString * _Nonnull moduleVersion;
        [Static]
        [Export("moduleVersion")]
        string ModuleVersion { get; set; }

        // @property (copy, nonatomic, class) NSDictionary<NSString *,NSString *> * _Nullable stateProperties;
        [Static]
        [NullAllowed, Export("stateProperties", ArgumentSemantic.Copy)]
        NSDictionary<NSString, NSString> StateProperties { get; set; }

        // @property (nonatomic, class) enum SFMCSdkModuleStatus status;
        [Static]
        [Export("status", ArgumentSemantic.Assign)]
        SFMCSdkModuleStatus Status { get; set; }

        // @property (readonly, nonatomic, strong, class) SFMCSdkPushModule * _Nonnull shared;
        [Static]
        [Export("shared", ArgumentSemantic.Strong)]
        SFMCSdkPushModule Shared { get; }

        // @property (readonly, nonatomic, strong, class) SFMCSdkModuleLogger * _Nonnull logger;
        [Static]
        [Export("logger", ArgumentSemantic.Strong)]
        SFMCSdkModuleLogger Logger { get; }

        // +(SFMCSdkModuleLogger * _Nonnull)getLogger __attribute__((warn_unused_result("")));
        [Static]
        [Export("getLogger")]
        // [Verify(MethodToProperty)]
        SFMCSdkModuleLogger GetLogger();

        // -(id<SFMCSdkModuleIdentity> _Nullable)getIdentity __attribute__((warn_unused_result("")));
        [NullAllowed, Export("getIdentity")]
        // [Verify(MethodToProperty)]
        SFMCSdkModuleIdentity Identity { get; }

        // -(void)receiveWithMessage:(SFMCSdkMessage * _Nonnull)message;
        [Export("receiveWithMessage:")]
        void ReceiveWithMessage(SFMCSdkMessage message);

        // +(void)sendSfmcEvent:(SFMCEvent * _Nonnull)event category:(enum SFMCSdkEventCategory)category;
        [Static]
        [Export("sendSfmcEvent:category:")]
        void SendSfmcEvent(SFMCEvent @event, SFMCSdkEventCategory category);

        // +(void)sendIdentityEventForTags;
        [Static]
        [Export("sendIdentityEventForTags")]
        void SendIdentityEventForTags();

        // +(void)sendIdentityEventForContactKey;
        [Static]
        [Export("sendIdentityEventForContactKey")]
        void SendIdentityEventForContactKey();

        // +(void)sendIdentityEventForAttributes;
        [Static]
        [Export("sendIdentityEventForAttributes")]
        void SendIdentityEventForAttributes();

        // +(NSDictionary<NSString *,id> * _Nonnull)metadata __attribute__((warn_unused_result("")));
        [Static]
        [Export("metadata")]
        // [Verify(MethodToProperty)]
        NSDictionary<NSString, NSObject> Metadata { get; }

        // -(void)tearDown __attribute__((deprecated("This method will be removed as the Push Module will automatically handle tear downs upon initializations")));
        [Export("tearDown")]
        void TearDown();

        // -(NSString * _Nullable)contactKey __attribute__((warn_unused_result("")));
        [NullAllowed, Export("contactKey")]
        // [Verify(MethodToProperty)]
        string ContactKey { get; }

        // -(BOOL)addTag:(NSString * _Nonnull)tag __attribute__((warn_unused_result("")));
        [Export("addTag:")]
        bool AddTag(string tag);

        // -(NSSet * _Nullable)addTags:(NSArray * _Nonnull)tags __attribute__((warn_unused_result("")));
        [Export("addTags:")]
        // [Verify(StronglyTypedNSArray)]
        [return: NullAllowed]
        NSSet AddTags(NSObject[] tags);

        // -(BOOL)removeTag:(NSString * _Nonnull)tag __attribute__((warn_unused_result("")));
        [Export("removeTag:")]
        bool RemoveTag(string tag);

        // -(NSSet * _Nullable)tags __attribute__((warn_unused_result("")));
        [NullAllowed, Export("tags")]
        // [Verify(MethodToProperty)]
        NSSet Tags { get; }

        // -(void)setDeviceToken:(NSData * _Nonnull)deviceToken;
        [Export("setDeviceToken:")]
        void SetDeviceToken(NSData deviceToken);

        // -(void)setDebugLoggingEnabled:(BOOL)enabled;
        [Export("setDebugLoggingEnabled:")]
        void SetDebugLoggingEnabled(bool enabled);

        // -(NSString * _Nullable)deviceToken __attribute__((warn_unused_result("")));
        [NullAllowed, Export("deviceToken")]
        // [Verify(MethodToProperty)]
        string DeviceToken { get; }

        // -(NSDictionary * _Nullable)attributes __attribute__((warn_unused_result("")));
        [NullAllowed, Export("attributes")]
        // [Verify(MethodToProperty)]
        NSDictionary Attributes { get; }

        // -(NSString * _Nullable)accessToken __attribute__((warn_unused_result("")));
        [NullAllowed, Export("accessToken")]
        // [Verify(MethodToProperty)]
        string AccessToken { get; }

        // -(NSString * _Nullable)deviceIdentifier __attribute__((warn_unused_result("")));
        [NullAllowed, Export("deviceIdentifier")]
        // [Verify(MethodToProperty)]
        string DeviceIdentifier { get; }

        // -(UNNotificationRequest * _Nullable)notificationRequest __attribute__((warn_unused_result("")));
        // -(void)setNotificationRequest:(UNNotificationRequest * _Nonnull)request;
        [NullAllowed, Export("notificationRequest")]
        // [Verify(MethodToProperty)]
        UNNotificationRequest NotificationRequest { get; set; }

        // -(NSDictionary * _Nonnull)notificationUserInfo __attribute__((warn_unused_result("")));
        // -(void)setNotificationUserInfo:(NSDictionary * _Nonnull)userInfo;
        [Export("notificationUserInfo")]
        // [Verify(MethodToProperty)]
        NSDictionary NotificationUserInfo { get; set; }

        // -(BOOL)pushEnabled __attribute__((warn_unused_result("")));
        // -(void)setPushEnabled:(BOOL)pushEnabled;
        [Export("pushEnabled")]
        // [Verify(MethodToProperty)]
        bool PushEnabled { get; set; }

        // -(BOOL)refreshWithFetchCompletionHandler:(void (^ _Nullable)(UIBackgroundFetchResult))completionHandler __attribute__((warn_unused_result("")));
        [Export("refreshWithFetchCompletionHandler:")]
        bool RefreshWithFetchCompletionHandler([NullAllowed] Action<UIBackgroundFetchResult> completionHandler);

        // -(BOOL)setSignedString:(NSString * _Nullable)signedString __attribute__((warn_unused_result("")));
        [Export("setSignedString:")]
        bool SetSignedString([NullAllowed] string signedString);

        // -(void)setRegistrationCallback:(void (^ _Nonnull)(NSDictionary * _Nonnull))registrationCallback;
        [Export("setRegistrationCallback:")]
        void SetRegistrationCallback(Action<NSDictionary> registrationCallback);

        // -(void)unsetRegistrationCallback;
        [Export("unsetRegistrationCallback")]
        void UnsetRegistrationCallback();

        // -(NSString * _Nullable)signedString __attribute__((warn_unused_result("")));
        [NullAllowed, Export("signedString")]
        // [Verify(MethodToProperty)]
        string SignedString { get; }

        // -(void)setEventDelegate:(id<SFMCSdkInAppMessageEventDelegate> _Nullable)delegate;
        [Export("setEventDelegate:")]
        void SetEventDelegate([NullAllowed] SFMCSdkInAppMessageEventDelegate @delegate);

        // -(NSString * _Nullable)messageIdForMessage:(NSDictionary * _Nonnull)forMessage __attribute__((warn_unused_result("")));
        [Export("messageIdForMessage:")]
        [return: NullAllowed]
        string MessageIdForMessage(NSDictionary forMessage);

        // -(void)showInAppMessageWithMessageId:(NSString * _Nonnull)messageId;
        [Export("showInAppMessageWithMessageId:")]
        void ShowInAppMessageWithMessageId(string messageId);

        // -(BOOL)setInAppMessageWithFontName:(NSString * _Nullable)fontName __attribute__((warn_unused_result("")));
        [Export("setInAppMessageWithFontName:")]
        bool SetInAppMessageWithFontName([NullAllowed] string fontName);

        // -(NSArray * _Nullable)getAllMessages __attribute__((warn_unused_result("")));
        [NullAllowed, Export("getAllMessages")]
        // [Verify(MethodToProperty), Verify(StronglyTypedNSArray)]
        NSObject[] AllMessages { get; }

        // -(NSArray * _Nullable)getUnreadMessages __attribute__((warn_unused_result("")));
        [NullAllowed, Export("getUnreadMessages")]
        // [Verify(MethodToProperty), Verify(StronglyTypedNSArray)]
        NSObject[] UnreadMessages { get; }

        // -(NSArray * _Nullable)getReadMessages __attribute__((warn_unused_result("")));
        [NullAllowed, Export("getReadMessages")]
        // [Verify(MethodToProperty), Verify(StronglyTypedNSArray)]
        NSObject[] ReadMessages { get; }

        // -(NSArray * _Nullable)getDeletedMessages __attribute__((warn_unused_result("")));
        [NullAllowed, Export("getDeletedMessages")]
        // [Verify(MethodToProperty), Verify(StronglyTypedNSArray)]
        NSObject[] DeletedMessages { get; }

        // -(NSUInteger)getAllMessagesCount __attribute__((warn_unused_result("")));
        [Export("getAllMessagesCount")]
        // [Verify(MethodToProperty)]
        nuint AllMessagesCount { get; }

        // -(NSUInteger)getUnreadMessagesCount __attribute__((warn_unused_result("")));
        [Export("getUnreadMessagesCount")]
        // [Verify(MethodToProperty)]
        nuint UnreadMessagesCount { get; }

        // -(NSUInteger)getReadMessagesCount __attribute__((warn_unused_result("")));
        [Export("getReadMessagesCount")]
        // [Verify(MethodToProperty)]
        nuint ReadMessagesCount { get; }

        // -(NSUInteger)getDeletedMessagesCount __attribute__((warn_unused_result("")));
        [Export("getDeletedMessagesCount")]
        // [Verify(MethodToProperty)]
        nuint DeletedMessagesCount { get; }

        // -(BOOL)markMessageRead:(NSDictionary * _Nonnull)messageDictionary __attribute__((warn_unused_result("")));
        [Export("markMessageRead:")]
        bool MarkMessageRead(NSDictionary messageDictionary);

        // -(BOOL)markMessageDeleted:(NSDictionary * _Nonnull)messageDictionary __attribute__((warn_unused_result("")));
        [Export("markMessageDeleted:")]
        bool MarkMessageDeleted(NSDictionary messageDictionary);

        // -(BOOL)markMessageWithIdReadWithMessageId:(NSString * _Nonnull)messageId __attribute__((warn_unused_result("")));
        [Export("markMessageWithIdReadWithMessageId:")]
        bool MarkMessageWithIdReadWithMessageId(string messageId);

        // -(BOOL)markMessageWithIdDeletedWithMessageId:(NSString * _Nonnull)messageId __attribute__((warn_unused_result("")));
        [Export("markMessageWithIdDeletedWithMessageId:")]
        bool MarkMessageWithIdDeletedWithMessageId(string messageId);

        // -(BOOL)markAllMessagesRead __attribute__((warn_unused_result("")));
        [Export("markAllMessagesRead")]
        // [Verify(MethodToProperty)]
        bool MarkAllMessagesRead { get; }

        // -(BOOL)markAllMessagesDeleted __attribute__((warn_unused_result("")));
        [Export("markAllMessagesDeleted")]
        // [Verify(MethodToProperty)]
        bool MarkAllMessagesDeleted { get; }

        // -(BOOL)refreshMessages __attribute__((warn_unused_result("")));
        [Export("refreshMessages")]
        // [Verify(MethodToProperty)]
        bool RefreshMessages { get; }

        // -(id<SFMCSdkInboxMessagesDataSource> _Nullable)inboxMessagesTableViewDataSourceForTableView:(UITableView * _Nonnull)tableView __attribute__((warn_unused_result("")));
        [Export("inboxMessagesTableViewDataSourceForTableView:")]
        [return: NullAllowed]
        SFMCSdkInboxMessagesDataSource InboxMessagesTableViewDataSourceForTableView(UITableView tableView);

        // -(id<SFMCSdkInboxMessagesDelegate> _Nullable)inboxMessagesTableViewDelegateForTableView:(UITableView * _Nonnull)tableView dataSource:(id<SFMCSdkInboxMessagesDataSource> _Nonnull)dataSource __attribute__((warn_unused_result("")));
        [Export("inboxMessagesTableViewDelegateForTableView:dataSource:")]
        [return: NullAllowed]
        SFMCSdkInboxMessagesDelegate InboxMessagesTableViewDelegateForTableView(UITableView tableView, SFMCSdkInboxMessagesDataSource dataSource);

        // -(BOOL)setPiIdentifier:(NSString * _Nullable)identifier __attribute__((warn_unused_result("")));
        [Export("setPiIdentifier:")]
        bool SetPiIdentifier([NullAllowed] string identifier);

        // -(NSString * _Nullable)piIdentifier __attribute__((warn_unused_result("")));
        [NullAllowed, Export("piIdentifier")]
        // [Verify(MethodToProperty)]
        string PiIdentifier { get; }

        // -(void)trackMessageOpened:(NSDictionary * _Nonnull)inboxMessage;
        [Export("trackMessageOpened:")]
        void TrackMessageOpened(NSDictionary inboxMessage);

        // -(void)trackPageViewWithUrl:(NSString * _Nonnull)url title:(NSString * _Nullable)title item:(NSString * _Nullable)item search:(NSString * _Nullable)search;
        [Export("trackPageViewWithUrl:title:item:search:")]
        void TrackPageViewWithUrl(string url, [NullAllowed] string title, [NullAllowed] string item, [NullAllowed] string search);

        // -(void)trackCartContents:(NSDictionary * _Nonnull)cartDictionary;
        [Export("trackCartContents:")]
        void TrackCartContents(NSDictionary cartDictionary);

        // -(void)trackCartConversion:(NSDictionary * _Nonnull)orderDictionary;
        [Export("trackCartConversion:")]
        void TrackCartConversion(NSDictionary orderDictionary);

        // -(NSDictionary * _Nullable)cartItemDictionaryWithPrice:(NSNumber * _Nonnull)price quantity:(NSNumber * _Nonnull)quantity item:(NSString * _Nonnull)item uniqueId:(NSString * _Nullable)uniqueId __attribute__((warn_unused_result("")));
        [Export("cartItemDictionaryWithPrice:quantity:item:uniqueId:")]
        [return: NullAllowed]
        NSDictionary CartItemDictionaryWithPrice(NSNumber price, NSNumber quantity, string item, [NullAllowed] string uniqueId);

        // -(NSDictionary * _Nullable)cartDictionaryWithCartItem:(NSArray * _Nonnull)cartItem __attribute__((warn_unused_result("")));
        [Export("cartDictionaryWithCartItem:")]
        // [Verify(StronglyTypedNSArray)]
        [return: NullAllowed]
        NSDictionary CartDictionaryWithCartItem(NSObject[] cartItem);

        // -(NSDictionary * _Nullable)orderDictionaryWithOrderNumber:(NSString * _Nonnull)orderNumber shipping:(NSNumber * _Nonnull)shipping discount:(NSNumber * _Nonnull)discount cart:(NSDictionary * _Nonnull)cart __attribute__((warn_unused_result("")));
        [Export("orderDictionaryWithOrderNumber:shipping:discount:cart:")]
        [return: NullAllowed]
        NSDictionary OrderDictionaryWithOrderNumber(string orderNumber, NSNumber shipping, NSNumber discount, NSDictionary cart);

        // -(void)setLocationDelegate:(id<SFMCSdkLocationDelegate> _Nullable)delegate;
        [Export("setLocationDelegate:")]
        void SetLocationDelegate([NullAllowed] SFMCSdkLocationDelegate @delegate);

        // -(CLRegion * _Nullable)regionFromDictionary:(NSDictionary * _Nonnull)dictionary __attribute__((warn_unused_result("")));
        [Export("regionFromDictionary:")]
        [return: NullAllowed]
        CLRegion RegionFromDictionary(NSDictionary dictionary);

        // -(BOOL)locationEnabled __attribute__((warn_unused_result("")));
        [Export("locationEnabled")]
        // [Verify(MethodToProperty)]
        bool LocationEnabled { get; }

        // -(void)startWatchingLocation;
        [Export("startWatchingLocation")]
        void StartWatchingLocation();

        // -(void)stopWatchingLocation;
        [Export("stopWatchingLocation")]
        void StopWatchingLocation();

        // -(BOOL)watchingLocation __attribute__((warn_unused_result("")));
        [Export("watchingLocation")]
        // [Verify(MethodToProperty)]
        bool WatchingLocation { get; }

        // -(NSDictionary<NSString *,NSString *> * _Nullable)lastKnownLocation __attribute__((warn_unused_result("")));
        [NullAllowed, Export("lastKnownLocation")]
        // [Verify(MethodToProperty)]
        NSDictionary<NSString, NSString> LastKnownLocation { get; }

        // -(void)setURLHandlingDelegate:(id<SFMCSdkURLHandlingDelegate> _Nullable)delegate;
        [Export("setURLHandlingDelegate:")]
        void SetURLHandlingDelegate([NullAllowed] SFMCSdkURLHandlingDelegate @delegate);

        // +(id<SFMCModule> _Nullable)initModuleWithConfig:(id<SFMCSdkModuleConfig> _Nonnull)config components:(SFMCSdkComponents * _Nonnull)components __attribute__((objc_method_family("none"))) __attribute__((warn_unused_result("")));
        [Export("initModuleWithConfig:components:")]
        [return: NullAllowed]
        SFMCModule Components(SFMCSdkModuleConfig config, SFMCSdkComponents components);

        // -(BOOL)resetDataPolicy __attribute__((warn_unused_result("")));
        [Export("resetDataPolicy")]
        // [Verify(MethodToProperty)]
        bool ResetDataPolicy { get; }
    }
}


