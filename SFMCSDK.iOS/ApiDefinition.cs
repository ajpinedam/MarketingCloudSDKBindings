using System;
using CoreLocation;
using Foundation;
using ObjCRuntime;
using UIKit;
using UserNotifications;
using NativeHandle = System.IntPtr;

namespace SFMCSDK
{
    [Static]
    // [Verify(ConstantsInterfaceAssociation)]
    partial interface Constants
    {
        // extern NSString *const _Nullable kSFKeychainItemExceptionType;
        [Field("kSFKeychainItemExceptionType", "__Internal")]
        [NullAllowed]
        NSString kSFKeychainItemExceptionType { get; }

        // extern NSString *const _Nullable kSFKeychainItemExceptionErrorCodeKey;
        [Field("kSFKeychainItemExceptionErrorCodeKey", "__Internal")]
        [NullAllowed]
        NSString kSFKeychainItemExceptionErrorCodeKey { get; }
    }

    // @interface  (UIViewController)
    [Category]
    [BaseType(typeof(UIViewController))]
    public interface UIViewController_
    {
        // +(void)swizzleViewDidAppearForScreenTracking;
        [Static]
        [Export("swizzleViewDidAppearForScreenTracking")]
        void SwizzleViewDidAppearForScreenTracking();
    }

    // [Verify(ConstantsInterfaceAssociation)]
    public partial interface Constants
    {
        // extern double SFMCSdkVersionNumber;
        [Field("SFMCSdkVersionNumber", "__Internal")]
        double SFMCSdkVersionNumber { get; }

        // extern const unsigned char[] SFMCSdkVersionString;
        [Field("SFMCSdkVersionString", "__Internal")]
        NSString SFMCSdkVersionString { get; }
    }

    // @protocol SFMCSdkEvent
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
    public interface SFMCSdkEvent
    {
        // @required @property (readonly, copy, nonatomic) NSString * _Nonnull id;
        [Abstract]
        [Export("id")]
        string Id { get; }

        // @required @property (readonly, copy, nonatomic) NSString * _Nonnull name;
        [Abstract]
        [Export("name")]
        string Name { get; }

        // @required @property (readonly, nonatomic) enum SFMCSdkEventCategory category;
        [Abstract]
        [Export("category")]
        SFMCSdkEventCategory Category { get; }

        // @required @property (readonly, copy, nonatomic) NSDictionary<NSString *,id> * _Nullable attributes;
        [Abstract]
        [NullAllowed, Export("attributes", ArgumentSemantic.Copy)]
        NSDictionary<NSString, NSObject> Attributes { get; }
    }

    // @interface SFMCSdkEngagementEvent : NSObject <SFMCSdkEvent>
    [BaseType(typeof(NSObject))]
    [DisableDefaultCtor]
    public interface SFMCSdkEngagementEvent : SFMCSdkEvent
    {
        // @property (readonly, copy, nonatomic) NSString * _Nonnull id;
        [Export("id")]
        string Id { get; }

        // @property (readonly, nonatomic) enum SFMCSdkEventCategory category;
        [Export("category")]
        SFMCSdkEventCategory Category { get; }

        // @property (readonly, copy, nonatomic) NSDictionary<NSString *,id> * _Nullable attributes;
        [NullAllowed, Export("attributes", ArgumentSemantic.Copy)]
        NSDictionary<NSString, NSObject> Attributes { get; }

        // @property (readonly, copy, nonatomic) NSString * _Nonnull name;
        [Export("name")]
        string Name { get; }
    }

    // @interface SFMCSdkCartEvent : SFMCSdkEngagementEvent
    [BaseType(typeof(SFMCSdkEngagementEvent))]
    public interface SFMCSdkCartEvent
    {
        // @property (readonly, copy, nonatomic) NSArray<SFMCSdkLineItem *> * _Nonnull lineItems;
        [Export("lineItems", ArgumentSemantic.Copy)]
        SFMCSdkLineItem[] LineItems { get; }
    }

    // @interface SFMCSdkAddToCartEvent : SFMCSdkCartEvent
    [BaseType(typeof(SFMCSdkCartEvent))]
    public interface SFMCSdkAddToCartEvent
    {
        // -(instancetype _Nonnull)initWithLineItem:(SFMCSdkLineItem * _Nonnull)lineItem __attribute__((objc_designated_initializer));
        [Export("initWithLineItem:")]
        [DesignatedInitializer]
        NativeHandle Constructor(SFMCSdkLineItem lineItem);
    }

    // @interface SFMCSdkBehavior : NSObject
    [BaseType(typeof(NSObject))]
    [DisableDefaultCtor]
    public interface SFMCSdkBehavior
    {
    }

    // @interface SFMCSdkAppBackgrounded : SFMCSdkBehavior
    [BaseType(typeof(SFMCSdkBehavior))]
    public interface SFMCSdkAppBackgrounded
    {
    }

    // @interface SFMCSdkAppForegrounded : SFMCSdkBehavior
    [BaseType(typeof(SFMCSdkBehavior))]
    public interface SFMCSdkAppForegrounded
    {
    }

    // @interface SFMCSdkAppVersionChanged : SFMCSdkBehavior
    [BaseType(typeof(SFMCSdkBehavior))]
    public interface SFMCSdkAppVersionChanged
    {
    }

    // @interface SFMCSdkAuthHeader : NSObject
    [BaseType(typeof(NSObject))]
    [DisableDefaultCtor]
    public interface SFMCSdkAuthHeader
    {
        // @property (readonly, copy, nonatomic) NSString * _Nonnull key;
        [Export("key")]
        string Key { get; }

        // @property (readonly, copy, nonatomic) NSString * _Nonnull value;
        [Export("value")]
        string Value { get; }

        // -(instancetype _Nonnull)initWithKey:(NSString * _Nonnull)key value:(NSString * _Nonnull)value __attribute__((objc_designated_initializer));
        [Export("initWithKey:value:")]
        [DesignatedInitializer]
        NativeHandle Constructor(string key, string value);
    }

    // @protocol SFMCSdkAuthenticator
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
    public interface SFMCSdkAuthenticator
    {
        // @required @property (readonly, nonatomic, strong) NSLock * _Nonnull lock;
        [Abstract]
        [Export("lock", ArgumentSemantic.Strong)]
        NSLock Lock { get; }

        // @required -(SFMCSdkAuthHeader * _Nullable)getCachedTokenHeader __attribute__((warn_unused_result("")));
        [Abstract]
        [NullAllowed, Export("getCachedTokenHeader")]
        // [Verify(MethodToProperty)]
        SFMCSdkAuthHeader CachedTokenHeader { get; }

        // @required -(SFMCSdkAuthHeader * _Nullable)refreshAuthTokenHeader __attribute__((warn_unused_result("")));
        [Abstract]
        [NullAllowed, Export("refreshAuthTokenHeader")]
        // [Verify(MethodToProperty)]
        SFMCSdkAuthHeader RefreshAuthTokenHeader { get; }

        // @required -(void)deleteCachedToken;
        [Abstract]
        [Export("deleteCachedToken")]
        void DeleteCachedToken();
    }

    // @interface SFMCSdkBehaviorManager : NSObject
    [BaseType(typeof(NSObject))]
    [DisableDefaultCtor]
    public interface SFMCSdkBehaviorManager
    {
    }

    // @protocol SFMCSdkBehaviorObserver
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
    public interface SFMCSdkBehaviorObserver
    {
        // @required @property (readonly, copy, nonatomic) NSSet<NSNumber *> * _Nonnull behaviorTypesToObserve;
        [Abstract]
        [Export("behaviorTypesToObserve", ArgumentSemantic.Copy)]
        NSSet<NSNumber> BehaviorTypesToObserve { get; }

        // @required -(void)onBehaviorWithBehavior:(SFMCSdkBehavior * _Nonnull)behavior;
        [Abstract]
        [Export("onBehaviorWithBehavior:")]
        void OnBehaviorWithBehavior(SFMCSdkBehavior behavior);
    }

    // @protocol CdpInterface
    /*
      Check whether adding [Model] to this declaration is appropriate.
      [Model] is used to generate a C# class that implements this protocol,
      and might be useful for protocols that consumers are supposed to implement,
      since consumers can subclass the generated class instead of implementing
      the generated interface. If consumers are not supposed to implement this
      protocol, then [Model] is redundant and will generate code that will never
      be used.
    */
    [Protocol(Name = "_TtP7SFMCSDK12CdpInterface_")]
    public interface CdpInterface
    {
        // @required -(enum SFMCSdkConsent)getConsent __attribute__((warn_unused_result("")));
        [Abstract]
        [Export("getConsent")]
        // [Verify(MethodToProperty)]
        SFMCSdkConsent Consent { get; }

        // @required -(void)setConsentWithConsent:(enum SFMCSdkConsent)consent;
        [Abstract]
        [Export("setConsentWithConsent:")]
        void SetConsentWithConsent(SFMCSdkConsent consent);

        // @required -(void)setLocationWithCoordinates:(id<SFMCSdkCoordinates> _Nullable)coordinates expiresIn:(NSInteger)expiresIn;
        [Abstract]
        [Export("setLocationWithCoordinates:expiresIn:")]
        void SetLocationWithCoordinates([NullAllowed] SFMCSdkCoordinates coordinates, nint expiresIn);

        // @required -(id<SFMCSdkModuleIdentity> _Nullable)getIdentity __attribute__((warn_unused_result("")));
        [Abstract]
        [NullAllowed, Export("getIdentity")]
        // [Verify(MethodToProperty)]
        SFMCSdkModuleIdentity Identity { get; }
    }

    // @interface SFMCSdkCDP : NSObject <CdpInterface>
    [BaseType(typeof(NSObject))]
    [DisableDefaultCtor]
    public interface SFMCSdkCDP : CdpInterface
    {
        // -(enum SFMCSdkModuleStatus)getStatus __attribute__((warn_unused_result("")));
        [Export("getStatus")]
        // [Verify(MethodToProperty)]
        SFMCSdkModuleStatus Status { get; }

        // -(id<SFMCSdkModuleIdentity> _Nullable)getIdentity __attribute__((warn_unused_result("")));
        [NullAllowed, Export("getIdentity")]
        // [Verify(MethodToProperty)]
        SFMCSdkModuleIdentity Identity { get; }

        // -(enum SFMCSdkConsent)getConsent __attribute__((warn_unused_result("")));
        [Export("getConsent")]
        // [Verify(MethodToProperty)]
        SFMCSdkConsent Consent { get; }

        // -(void)setConsentWithConsent:(enum SFMCSdkConsent)consent;
        [Export("setConsentWithConsent:")]
        void SetConsentWithConsent(SFMCSdkConsent consent);

        // -(void)setLocationWithCoordinates:(id<SFMCSdkCoordinates> _Nullable)coordinates expiresIn:(NSInteger)expiresIn;
        [Export("setLocationWithCoordinates:expiresIn:")]
        void SetLocationWithCoordinates([NullAllowed] SFMCSdkCoordinates coordinates, nint expiresIn);
    }

    // @interface SFMCSdkOrderEvent : SFMCSdkEngagementEvent
    [BaseType(typeof(SFMCSdkEngagementEvent))]
    public interface SFMCSdkOrderEvent
    {
        // @property (readonly, nonatomic, strong) SFMCSdkOrder * _Nonnull order;
        [Export("order", ArgumentSemantic.Strong)]
        SFMCSdkOrder Order { get; }
    }

    // @interface SFMCSdkCancelOrderEvent : SFMCSdkOrderEvent
    [BaseType(typeof(SFMCSdkOrderEvent))]
    public interface SFMCSdkCancelOrderEvent
    {
        // -(instancetype _Nonnull)initWithOrder:(SFMCSdkOrder * _Nonnull)order __attribute__((objc_designated_initializer));
        [Export("initWithOrder:")]
        [DesignatedInitializer]
        NativeHandle Constructor(SFMCSdkOrder order);
    }

    // @interface SFMCSdkCatalogObject : NSObject
    [BaseType(typeof(NSObject))]
    [DisableDefaultCtor]
    public interface SFMCSdkCatalogObject
    {
        // @property (readonly, copy, nonatomic) NSString * _Nonnull type;
        [Export("type")]
        string Type { get; }

        // @property (readonly, copy, nonatomic) NSString * _Nonnull id;
        [Export("id")]
        string Id { get; }

        // @property (readonly, copy, nonatomic) NSDictionary<NSString *,id> * _Nonnull attributes;
        [Export("attributes", ArgumentSemantic.Copy)]
        NSDictionary<NSString, NSObject> Attributes { get; }

        // @property (readonly, copy, nonatomic) NSDictionary<NSString *,NSArray<NSString *> *> * _Nonnull relatedCatalogObjects;
        [Export("relatedCatalogObjects", ArgumentSemantic.Copy)]
        NSDictionary<NSString, NSArray<NSString>> RelatedCatalogObjects { get; }

        // -(instancetype _Nonnull)initWithType:(NSString * _Nonnull)type id:(NSString * _Nonnull)id attributes:(NSDictionary<NSString *,id> * _Nonnull)attributes relatedCatalogObjects:(NSDictionary<NSString *,NSArray<NSString *> *> * _Nonnull)relatedCatalogObjects __attribute__((objc_designated_initializer));
        [Export("initWithType:id:attributes:relatedCatalogObjects:")]
        [DesignatedInitializer]
        NativeHandle Constructor(string type, string id, NSDictionary<NSString, NSObject> attributes, NSDictionary<NSString, NSArray<NSString>> relatedCatalogObjects);
    }

    // @interface SFMCSdkCatalogObjectEvent : SFMCSdkEngagementEvent
    [BaseType(typeof(SFMCSdkEngagementEvent))]
    public interface SFMCSdkCatalogObjectEvent
    {
        // @property (readonly, nonatomic, strong) SFMCSdkCatalogObject * _Nonnull catalogObject;
        [Export("catalogObject", ArgumentSemantic.Strong)]
        SFMCSdkCatalogObject CatalogObject { get; }
    }

    // @interface SFMCSdkCommentCatalogObjectEvent : SFMCSdkCatalogObjectEvent
    [BaseType(typeof(SFMCSdkCatalogObjectEvent))]
    public interface SFMCSdkCommentCatalogObjectEvent
    {
        // -(instancetype _Nonnull)initWithCatalogObject:(SFMCSdkCatalogObject * _Nonnull)catalogObject __attribute__((objc_designated_initializer));
        [Export("initWithCatalogObject:")]
        [DesignatedInitializer]
        NativeHandle Constructor(SFMCSdkCatalogObject catalogObject);
    }

    // @interface SFMCSdkCompatibility : NSObject
    [BaseType(typeof(NSObject))]
    [DisableDefaultCtor]
    public interface SFMCSdkCompatibility
    {
    }

    // @interface SFMCSdkCompletedCall : NSObject
    [BaseType(typeof(NSObject))]
    [DisableDefaultCtor]
    public interface SFMCSdkCompletedCall
    {
        // @property (readonly, nonatomic, strong) SFMCSdkWrappedRequest * _Nonnull wrappedRequest;
        [Export("wrappedRequest", ArgumentSemantic.Strong)]
        SFMCSdkWrappedRequest WrappedRequest { get; }

        // @property (readonly, nonatomic, strong) SFMCSdkWrappedResponse * _Nonnull wrappedResponse;
        [Export("wrappedResponse", ArgumentSemantic.Strong)]
        SFMCSdkWrappedResponse WrappedResponse { get; }

        // -(instancetype _Nonnull)init:(SFMCSdkWrappedRequest * _Nonnull)wrappedRequest :(SFMCSdkWrappedResponse * _Nonnull)wrappedResponse __attribute__((objc_designated_initializer));
        [Export("init::")]
        [DesignatedInitializer]
        NativeHandle Constructor(SFMCSdkWrappedRequest wrappedRequest, SFMCSdkWrappedResponse wrappedResponse);
    }

    // @interface SFMCSdkConfig : NSObject
    [BaseType(typeof(NSObject))]
    [DisableDefaultCtor]
    public interface SFMCSdkConfig
    {
    }

    // @interface SFMCSdkConfigBuilder : NSObject
    [BaseType(typeof(NSObject))]
    public interface SFMCSdkConfigBuilder
    {
        // -(SFMCSdkConfigBuilder * _Nonnull)setCdpWithConfig:(id<SFMCSdkModuleConfig> _Nonnull)config onCompletion:(void (^ _Nullable)(enum SFMCSdkOperationResult))onCompletion __attribute__((warn_unused_result("")));
        [Export("setCdpWithConfig:onCompletion:")]
        SFMCSdkConfigBuilder SetCdpWithConfig(SFMCSdkModuleConfig config, [NullAllowed] Action<SFMCSdkOperationResult> onCompletion);

        // -(SFMCSdkConfigBuilder * _Nonnull)setPushWithConfig:(id<SFMCSdkModuleConfig> _Nonnull)config onCompletion:(void (^ _Nullable)(enum SFMCSdkOperationResult))onCompletion __attribute__((warn_unused_result("")));
        [Export("setPushWithConfig:onCompletion:")]
        SFMCSdkConfigBuilder SetPushWithConfig(SFMCSdkModuleConfig config, [NullAllowed] Action<SFMCSdkOperationResult> onCompletion);

        // -(SFMCSdkConfig * _Nonnull)build __attribute__((warn_unused_result("")));
        [Export("build")]
        // [Verify(MethodToProperty)]
        SFMCSdkConfig Build { get; }
    }

    // @protocol SFMCSdkCoordinates
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
    public interface SFMCSdkCoordinates
    {
        // @required @property (readonly, nonatomic) double latitude;
        [Abstract]
        [Export("latitude")]
        double Latitude { get; }

        // @required @property (readonly, nonatomic) double longitude;
        [Abstract]
        [Export("longitude")]
        double Longitude { get; }
    }

    // @interface SFMCSdkCustomEvent : NSObject <SFMCSdkEvent>
    [BaseType(typeof(NSObject))]
    [DisableDefaultCtor]
    interface SFMCSdkCustomEvent : SFMCSdkEvent
    {
        // @property (readonly, copy, nonatomic) NSString * _Nonnull id;
        [Export("id")]
        string Id { get; }

        // @property (readonly, copy, nonatomic) NSString * _Nonnull name;
        [Export("name")]
        string Name { get; }

        // @property (readonly, nonatomic) enum SFMCSdkEventCategory category;
        [Export("category")]
        SFMCSdkEventCategory Category { get; }

        // @property (readonly, copy, nonatomic) NSDictionary<NSString *,id> * _Nullable attributes;
        [NullAllowed, Export("attributes", ArgumentSemantic.Copy)]
        NSDictionary<NSString, NSObject> Attributes { get; }

        // -(instancetype _Nullable)initWithName:(NSString * _Nonnull)name attributes:(NSDictionary<NSString *,id> * _Nullable)attributes __attribute__((objc_designated_initializer));
        [Export("initWithName:attributes:")]
        [DesignatedInitializer]
        NativeHandle Constructor(string name, [NullAllowed] NSDictionary<NSString, NSObject> attributes);
    }

    // @interface SFMCSdkDeliverOrderEvent : SFMCSdkOrderEvent
    [BaseType(typeof(SFMCSdkOrderEvent))]
    public interface SFMCSdkDeliverOrderEvent
    {
        // -(instancetype _Nonnull)initWithOrder:(SFMCSdkOrder * _Nonnull)order __attribute__((objc_designated_initializer));
        [Export("initWithOrder:")]
        [DesignatedInitializer]
        NativeHandle Constructor(SFMCSdkOrder order);
    }

    // @interface SFMCSdkEncryptionManager : NSObject
    [BaseType(typeof(NSObject))]
    [DisableDefaultCtor]
    public interface SFMCSdkEncryptionManager
    {
        // -(NSData * _Nullable)encryptWithString:(NSString * _Nonnull)string __attribute__((warn_unused_result("")));
        [Export("encryptWithString:")]
        [return: NullAllowed]
        NSData EncryptWithString(string @string);

        // -(NSString * _Nullable)decryptWithStringData:(NSData * _Nonnull)stringData __attribute__((warn_unused_result("")));
        [Export("decryptWithStringData:")]
        [return: NullAllowed]
        string DecryptWithStringData(NSData stringData);
    }

    // @interface SFMCSdkEventBus : NSObject
    [BaseType(typeof(NSObject))]
    [DisableDefaultCtor]
    public interface SFMCSdkEventBus
    {
        // +(void)publishWithProducer:(enum SFMCSdkMessageProducer)producer event:(id<SFMCSdkEvent> _Nonnull)event;
        [Static]
        [Export("publishWithProducer:event:")]
        void PublishWithProducer(SFMCSdkMessageProducer producer, SFMCSdkEvent @event);

        // +(void)publishToTarget:(enum SFMCSdkModuleName)target producer:(enum SFMCSdkMessageProducer)producer event:(id<SFMCSdkEvent> _Nonnull)event;
        [Static]
        [Export("publishToTarget:producer:event:")]
        void PublishToTarget(SFMCSdkModuleName target, SFMCSdkMessageProducer producer, SFMCSdkEvent @event);

        // +(void)subscribeWithSubscriber:(id<Subscriber> _Nonnull)subscriber;
        [Static]
        [Export("subscribeWithSubscriber:")]
        void SubscribeWithSubscriber(Subscriber subscriber);

        // +(void)unsubscribeWithSubscriber:(id<Subscriber> _Nonnull)subscriber;
        [Static]
        [Export("unsubscribeWithSubscriber:")]
        void UnsubscribeWithSubscriber(Subscriber subscriber);
    }

    // @interface SFMCSdkExchangeOrderEvent : SFMCSdkOrderEvent
    [BaseType(typeof(SFMCSdkOrderEvent))]
    public interface SFMCSdkExchangeOrderEvent
    {
        // -(instancetype _Nonnull)initWithOrder:(SFMCSdkOrder * _Nonnull)order __attribute__((objc_designated_initializer));
        [Export("initWithOrder:")]
        [DesignatedInitializer]
        NativeHandle Constructor(SFMCSdkOrder order);
    }

    // @interface SFMCSdkFakeEvent : NSObject <SFMCSdkEvent>
    [BaseType(typeof(NSObject))]
    [DisableDefaultCtor]
    public interface SFMCSdkFakeEvent : SFMCSdkEvent
    {
        // @property (readonly, copy, nonatomic) NSString * _Nonnull id;
        [Export("id")]
        string Id { get; }

        // @property (readonly, copy, nonatomic) NSString * _Nonnull name;
        [Export("name")]
        string Name { get; }

        // @property (readonly, nonatomic) enum SFMCSdkEventCategory category;
        [Export("category")]
        SFMCSdkEventCategory Category { get; }

        // @property (readonly, copy, nonatomic) NSDictionary<NSString *,id> * _Nullable attributes;
        [NullAllowed, Export("attributes", ArgumentSemantic.Copy)]
        NSDictionary<NSString, NSObject> Attributes { get; }

        // -(instancetype _Nullable)initWithName:(NSString * _Nonnull)name __attribute__((objc_designated_initializer));
        [Export("initWithName:")]
        [DesignatedInitializer]
        NativeHandle Constructor(string name);
    }

    // @interface SFMCSdkFavoriteCatalogObjectEvent : SFMCSdkCatalogObjectEvent
    [BaseType(typeof(SFMCSdkCatalogObjectEvent))]
    public interface SFMCSdkFavoriteCatalogObjectEvent
    {
        // -(instancetype _Nonnull)initWithCatalogObject:(SFMCSdkCatalogObject * _Nonnull)catalogObject __attribute__((objc_designated_initializer));
        [Export("initWithCatalogObject:")]
        [DesignatedInitializer]
        NativeHandle Constructor(SFMCSdkCatalogObject catalogObject);
    }

    // @interface SFMCSdkIDENTITY : NSObject
    [BaseType(typeof(NSObject))]
    [DisableDefaultCtor]
    public interface SFMCSdkIDENTITY
    {
        // -(NSString * _Nonnull)toJson __attribute__((warn_unused_result("")));
        [Export("toJson")]
        // [Verify(MethodToProperty)]
        string ToJson { get; }

        // -(void)setProfileId:(NSString * _Nonnull)profile;
        [Export("setProfileId:")]
        void SetProfileId(string profile);

        // -(void)setProfileIdWithProfile:(NSString * _Nonnull)profile rawModules:(NSArray<NSNumber *> * _Nonnull)rawModules;
        [Export("setProfileIdWithProfile:rawModules:")]
        void SetProfileIdWithProfile(string profile, NSNumber[] rawModules);

        // -(void)setProfileIdWithProfiles:(NSDictionary<NSNumber *,NSString *> * _Nonnull)profiles;
        [Export("setProfileIdWithProfiles:")]
        void SetProfileIdWithProfiles(NSDictionary<NSNumber, NSString> profiles);

        // -(void)clearProfileAttributeWithKey:(NSString * _Nonnull)key;
        [Export("clearProfileAttributeWithKey:")]
        void ClearProfileAttributeWithKey(string key);

        // -(void)clearProfileAttributesWithKeys:(NSArray<NSString *> * _Nonnull)keys;
        [Export("clearProfileAttributesWithKeys:")]
        void ClearProfileAttributesWithKeys(string[] keys);

        // -(void)setProfileAttributes:(NSDictionary<NSString *,NSString *> * _Nonnull)attributes;
        [Export("setProfileAttributes:")]
        void SetProfileAttributes(NSDictionary<NSString, NSString> attributes);

        // -(void)setProfileAttributesNamedWithAttributes:(NSDictionary<NSString *,NSString *> * _Nonnull)attributes rawModules:(NSArray<NSNumber *> * _Nonnull)rawModules;
        [Export("setProfileAttributesNamedWithAttributes:rawModules:")]
        void SetProfileAttributesNamedWithAttributes(NSDictionary<NSString, NSString> attributes, NSNumber[] rawModules);

        // -(void)setProfileAttributesNamed:(NSDictionary<NSNumber *,NSDictionary<NSString *,NSString *> *> * _Nonnull)attributes;
        [Export("setProfileAttributesNamed:")]
        void SetProfileAttributesNamed(NSDictionary<NSNumber, NSDictionary<NSString, NSString>> attributes);
    }

    // @protocol SFMCSdkIdentityEventProtocol <SFMCSdkEvent>
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
    public interface SFMCSdkIdentityEventProtocol : SFMCSdkEvent
    {
        // @required @property (readonly, copy, nonatomic) NSString * _Nullable profileId;
        [Abstract]
        [NullAllowed, Export("profileId")]
        string ProfileId { get; }

        // @required @property (readonly, copy, nonatomic) NSDictionary<NSString *,NSString *> * _Nullable profileAttributes;
        [Abstract]
        [NullAllowed, Export("profileAttributes", ArgumentSemantic.Copy)]
        NSDictionary<NSString, NSString> ProfileAttributes { get; }

        // @required @property (readonly, copy, nonatomic) NSDictionary<NSString *,id> * _Nullable attributes;
        [Abstract]
        [NullAllowed, Export("attributes", ArgumentSemantic.Copy)]
        NSDictionary<NSString, NSObject> Attributes { get; }
    }

    // @interface SFMCSdkIdentityEvent : NSObject <SFMCSdkIdentityEventProtocol>
    [BaseType(typeof(NSObject))]
    [DisableDefaultCtor]
    public interface SFMCSdkIdentityEvent : SFMCSdkIdentityEventProtocol
    {
        // @property (readonly, copy, nonatomic) NSString * _Nonnull id;
        [Export("id")]
        string Id { get; }

        // @property (readonly, copy, nonatomic) NSString * _Nonnull name;
        [Export("name")]
        string Name { get; }

        // @property (readonly, nonatomic) enum SFMCSdkEventCategory category;
        [Export("category")]
        SFMCSdkEventCategory Category { get; }

        // @property (readonly, copy, nonatomic) NSString * _Nullable profileId;
        [NullAllowed, Export("profileId")]
        string ProfileId { get; }

        // @property (readonly, copy, nonatomic) NSDictionary<NSString *,NSString *> * _Nullable profileAttributes;
        [NullAllowed, Export("profileAttributes", ArgumentSemantic.Copy)]
        NSDictionary<NSString, NSString> ProfileAttributes { get; }

        // @property (readonly, copy, nonatomic) NSDictionary<NSString *,id> * _Nullable attributes;
        [NullAllowed, Export("attributes", ArgumentSemantic.Copy)]
        NSDictionary<NSString, NSObject> Attributes { get; }

        // -(instancetype _Nonnull)initWithProfileId:(NSString * _Nonnull)profileId __attribute__((objc_designated_initializer));
        [Export("initWithProfileId:")]
        [DesignatedInitializer]
        NativeHandle Constructor(string profileId);

        // -(instancetype _Nonnull)initWithProfileAttributes:(NSDictionary<NSString *,NSString *> * _Nonnull)profileAttributes __attribute__((objc_designated_initializer));
        [Export("initWithProfileAttributes:")]
        [DesignatedInitializer]
        NativeHandle Constructor(NSDictionary<NSString, NSString> profileAttributes);

        // -(instancetype _Nonnull)initWithAttributes:(NSDictionary<NSString *,id> * _Nonnull)attributes __attribute__((objc_designated_initializer));
        [Export("initWithAttributes:")]
        [DesignatedInitializer]
        NativeHandle Constructor(NSDictionary<NSString, NSObject> attributes);
    }

    // @protocol SFMCSdkInAppMessageEventDelegate
    [Protocol, Model(AutoGeneratedName = true)]
    public interface SFMCSdkInAppMessageEventDelegate
    {
        // @optional -(BOOL)sfmc_shouldShowInAppMessage:(NSDictionary * _Nonnull)message __attribute__((warn_unused_result("")));
        [Export("sfmc_shouldShowInAppMessage:")]
        bool Sfmc_shouldShowInAppMessage(NSDictionary message);

        // @optional -(void)sfmc_didShowInAppMessage:(NSDictionary * _Nonnull)message;
        [Export("sfmc_didShowInAppMessage:")]
        void Sfmc_didShowInAppMessage(NSDictionary message);

        // @optional -(void)sfmc_didCloseInAppMessage:(NSDictionary * _Nonnull)message;
        [Export("sfmc_didCloseInAppMessage:")]
        void Sfmc_didCloseInAppMessage(NSDictionary message);
    }

    // @protocol SFMCSdkInboxMessagesDataSource <UITableViewDataSource>
    [Protocol, Model(AutoGeneratedName = true)]
    public interface SFMCSdkInboxMessagesDataSource : IUITableViewDataSource
    {
    }

    // @protocol SFMCSdkInboxMessagesDelegate <UITableViewDelegate>
    [Protocol, Model(AutoGeneratedName = true)]
    public interface SFMCSdkInboxMessagesDelegate : IUITableViewDelegate
    {
    }

    // @interface SFMCSdkLineItem : NSObject
    [BaseType(typeof(NSObject))]
    [DisableDefaultCtor]
    public interface SFMCSdkLineItem
    {
        // @property (readonly, copy, nonatomic) NSString * _Nonnull catalogObjectType;
        [Export("catalogObjectType")]
        string CatalogObjectType { get; }

        // @property (readonly, copy, nonatomic) NSString * _Nonnull catalogObjectId;
        [Export("catalogObjectId")]
        string CatalogObjectId { get; }

        // @property (readonly, nonatomic) NSInteger quantity;
        [Export("quantity")]
        nint Quantity { get; }

        // @property (readonly, nonatomic, strong) NSDecimalNumber * _Nullable price;
        [NullAllowed, Export("price", ArgumentSemantic.Strong)]
        NSDecimalNumber Price { get; }

        // @property (readonly, copy, nonatomic) NSString * _Nullable currency;
        [NullAllowed, Export("currency")]
        string Currency { get; }

        // @property (readonly, copy, nonatomic) NSDictionary<NSString *,id> * _Nullable attributes;
        [NullAllowed, Export("attributes", ArgumentSemantic.Copy)]
        NSDictionary<NSString, NSObject> Attributes { get; }

        // -(instancetype _Nonnull)initWithCatalogObjectType:(NSString * _Nonnull)catalogObjectType catalogObjectId:(NSString * _Nonnull)catalogObjectId quantity:(NSInteger)quantity price:(NSDecimalNumber * _Nullable)price currency:(NSString * _Nullable)currency attributes:(NSDictionary<NSString *,id> * _Nonnull)attributes __attribute__((objc_designated_initializer));
        [Export("initWithCatalogObjectType:catalogObjectId:quantity:price:currency:attributes:")]
        [DesignatedInitializer]
        NativeHandle Constructor(string catalogObjectType, string catalogObjectId, nint quantity, [NullAllowed] NSDecimalNumber price, [NullAllowed] string currency, NSDictionary<NSString, NSObject> attributes);
    }

    // @protocol SFMCSdkLocationDelegate
    [Protocol, Model(AutoGeneratedName = true)]
    public interface SFMCSdkLocationDelegate
    {
        // @required -(BOOL)sfmc_shouldShowLocationMessage:(NSDictionary * _Nonnull)message forRegion:(NSDictionary * _Nonnull)region __attribute__((warn_unused_result("")));
        [Abstract]
        [Export("sfmc_shouldShowLocationMessage:forRegion:")]
        bool ForRegion(NSDictionary message, NSDictionary region);
    }

    // @interface SFMCSdkLogOutputter : NSObject
    [BaseType(typeof(NSObject))]
    public interface SFMCSdkLogOutputter
    {
        // -(void)outWithLevel:(enum SFMCSdkLogLevel)level subsystem:(NSString * _Nonnull)subsystem category:(enum SFMCSdkLoggerCategory)category message:(NSString * _Nonnull)message;
        [Export("outWithLevel:subsystem:category:message:")]
        void OutWithLevel(SFMCSdkLogLevel level, string subsystem, SFMCSdkLoggerCategory category, string message);
    }

    // @protocol Logger
    /*
      Check whether adding [Model] to this declaration is appropriate.
      [Model] is used to generate a C# class that implements this protocol,
      and might be useful for protocols that consumers are supposed to implement,
      since consumers can subclass the generated class instead of implementing
      the generated interface. If consumers are not supposed to implement this
      protocol, then [Model] is redundant and will generate code that will never
      be used.
    */
    [Protocol(Name = "_TtP7SFMCSDK6Logger_")]
    public interface Logger
    {
        // @required @property (readonly, copy, nonatomic) NSArray<NSString *> * _Nonnull redactedValues;
        [Abstract]
        [Export("redactedValues", ArgumentSemantic.Copy)]
        string[] RedactedValues { get; }
    }

    // @interface SFMCSdkMessage : NSObject
    [BaseType(typeof(NSObject))]
    [DisableDefaultCtor]
    public interface SFMCSdkMessage
    {
    }

    // @protocol SFMCSdkModuleConfig
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
    public interface SFMCSdkModuleConfig
    {
        // @required @property (readonly, nonatomic) enum SFMCSdkModuleName name;
        [Abstract]
        [Export("name")]
        SFMCSdkModuleName Name { get; }

        // @required @property (readonly, copy, nonatomic) NSString * _Nonnull appId;
        [Abstract]
        [Export("appId")]
        string AppId { get; }

        // @required @property (readonly, nonatomic) BOOL trackScreens;
        [Abstract]
        [Export("trackScreens")]
        bool TrackScreens { get; }
    }

    // @protocol SFMCSdkModuleIdentity
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
    public interface SFMCSdkModuleIdentity
    {
        // @required @property (readonly, copy, nonatomic) NSString * _Nonnull applicationId;
        [Abstract]
        [Export("applicationId")]
        string ApplicationId { get; }

        // @required @property (readonly, copy, nonatomic) NSString * _Nullable profileId;
        [Abstract]
        [NullAllowed, Export("profileId")]
        string ProfileId { get; }

        // @required @property (readonly, copy, nonatomic) NSString * _Nullable installationId;
        [Abstract]
        [NullAllowed, Export("installationId")]
        string InstallationId { get; }

        // @required @property (readonly, copy, nonatomic) NSDictionary<NSString *,id> * _Nullable customProperties;
        [Abstract]
        [NullAllowed, Export("customProperties", ArgumentSemantic.Copy)]
        NSDictionary<NSString, NSObject> CustomProperties { get; }

        // @required -(NSString * _Nullable)customPropertiesToJson __attribute__((warn_unused_result("")));
        [Abstract]
        [NullAllowed, Export("customPropertiesToJson")]
        // [Verify(MethodToProperty)]
        string CustomPropertiesToJson { get; }
    }

    // @interface SFMCSdkModuleLogger : NSObject <Logger>
    [BaseType(typeof(NSObject))]
    [DisableDefaultCtor]
    public interface SFMCSdkModuleLogger : Logger
    {
        // @property (copy, nonatomic) NSArray<NSString *> * _Nonnull redactedValues;
        [Export("redactedValues", ArgumentSemantic.Copy)]
        string[] RedactedValues { get; set; }

        // -(instancetype _Nonnull)initWithModule:(enum SFMCSdkModuleName)module_ redactedValues:(NSArray<NSString *> * _Nonnull)redactedValues __attribute__((objc_designated_initializer));
        [Export("initWithModule:redactedValues:")]
        [DesignatedInitializer]
        NativeHandle Constructor(SFMCSdkModuleName module_, string[] redactedValues);

        // -(void)setWithRedactedValues:(NSArray<NSString *> * _Nonnull)redactedValues;
        [Export("setWithRedactedValues:")]
        void SetWithRedactedValues(string[] redactedValues);

        // -(void)debugWithCategory:(enum SFMCSdkLoggerCategory)category message:(NSString * _Nonnull)message;
        [Export("debugWithCategory:message:")]
        void DebugWithCategory(SFMCSdkLoggerCategory category, string message);

        // -(void)warningWithCategory:(enum SFMCSdkLoggerCategory)category message:(NSString * _Nonnull)message;
        [Export("warningWithCategory:message:")]
        void WarningWithCategory(SFMCSdkLoggerCategory category, string message);

        // -(void)errorWithCategory:(enum SFMCSdkLoggerCategory)category message:(NSString * _Nonnull)message;
        [Export("errorWithCategory:message:")]
        void ErrorWithCategory(SFMCSdkLoggerCategory category, string message);

        // -(void)faultWithCategory:(enum SFMCSdkLoggerCategory)category message:(NSString * _Nonnull)message;
        [Export("faultWithCategory:message:")]
        void FaultWithCategory(SFMCSdkLoggerCategory category, string message);
    }

    // @interface SFMCSdkNetworkManager : NSObject
    [BaseType(typeof(NSObject))]
    [DisableDefaultCtor]
    public interface SFMCSdkNetworkManager
    {
        // -(instancetype _Nonnull)initWithNetworkPreferences:(SFMCSdkSecurePrefs * _Nonnull)networkPreferences authenticator:(id<SFMCSdkAuthenticator> _Nullable)authenticator __attribute__((objc_designated_initializer));
        [Export("initWithNetworkPreferences:authenticator:")]
        [DesignatedInitializer]
        NativeHandle Constructor(SFMCSdkSecurePrefs networkPreferences, [NullAllowed] SFMCSdkAuthenticator authenticator);

        // -(SFMCSdkCompletedCall * _Nonnull)executeSync:(SFMCSdkWrappedRequest * _Nonnull)wrappedRequest __attribute__((warn_unused_result("")));
        [Export("executeSync:")]
        SFMCSdkCompletedCall ExecuteSync(SFMCSdkWrappedRequest wrappedRequest);

        // -(void)executeAsync:(SFMCSdkWrappedRequest * _Nonnull)wrappedRequest completionHandler:(void (^ _Nonnull)(SFMCSdkCompletedCall * _Nonnull))completionHandler;
        [Export("executeAsync:completionHandler:")]
        void ExecuteAsync(SFMCSdkWrappedRequest wrappedRequest, Action<SFMCSdkCompletedCall> completionHandler);

        // -(BOOL)isBlockedByRetryAfter:(NSString * _Nonnull)requestName __attribute__((warn_unused_result("")));
        [Export("isBlockedByRetryAfter:")]
        bool IsBlockedByRetryAfter(string requestName);
    }

    // @interface SFMCSdkOrder : NSObject
    [BaseType(typeof(NSObject))]
    [DisableDefaultCtor]
    public interface SFMCSdkOrder
    {
        // @property (readonly, copy, nonatomic) NSString * _Nonnull id;
        [Export("id")]
        string Id { get; }

        // @property (readonly, copy, nonatomic) NSArray<SFMCSdkLineItem *> * _Nonnull lineItems;
        [Export("lineItems", ArgumentSemantic.Copy)]
        SFMCSdkLineItem[] LineItems { get; }

        // @property (readonly, nonatomic, strong) NSDecimalNumber * _Nullable totalValue;
        [NullAllowed, Export("totalValue", ArgumentSemantic.Strong)]
        NSDecimalNumber TotalValue { get; }

        // @property (readonly, copy, nonatomic) NSString * _Nullable currency;
        [NullAllowed, Export("currency")]
        string Currency { get; }

        // @property (readonly, copy, nonatomic) NSDictionary<NSString *,id> * _Nonnull attributes;
        [Export("attributes", ArgumentSemantic.Copy)]
        NSDictionary<NSString, NSObject> Attributes { get; }

        // -(instancetype _Nonnull)initWithId:(NSString * _Nonnull)id lineItems:(NSArray<SFMCSdkLineItem *> * _Nonnull)lineItems totalValue:(NSDecimalNumber * _Nullable)totalValue currency:(NSString * _Nullable)currency attributes:(NSDictionary<NSString *,id> * _Nonnull)attributes __attribute__((objc_designated_initializer));
        [Export("initWithId:lineItems:totalValue:currency:attributes:")]
        [DesignatedInitializer]
        NativeHandle Constructor(string id, SFMCSdkLineItem[] lineItems, [NullAllowed] NSDecimalNumber totalValue, [NullAllowed] string currency, NSDictionary<NSString, NSObject> attributes);
    }

    // @protocol PushInterface
    /*
      Check whether adding [Model] to this declaration is appropriate.
      [Model] is used to generate a C# class that implements this protocol,
      and might be useful for protocols that consumers are supposed to implement,
      since consumers can subclass the generated class instead of implementing
      the generated interface. If consumers are not supposed to implement this
      protocol, then [Model] is redundant and will generate code that will never
      be used.
    */
    [Protocol(Name = "_TtP7SFMCSDK13PushInterface_")]
    public interface PushInterface
    {
        // @required -(id<SFMCSdkModuleIdentity> _Nullable)getIdentity __attribute__((warn_unused_result("")));
        [Abstract]
        [NullAllowed, Export("getIdentity")]
        // [Verify(MethodToProperty)]
        SFMCSdkModuleIdentity Identity { get; }

        // @required -(void)tearDown;
        [Abstract]
        [Export("tearDown")]
        void TearDown();

        // @required -(NSString * _Nullable)contactKey __attribute__((warn_unused_result("")));
        [Abstract]
        [NullAllowed, Export("contactKey")]
        // [Verify(MethodToProperty)]
        string ContactKey { get; }

        // @required -(BOOL)addTag:(NSString * _Nonnull)tag __attribute__((warn_unused_result("")));
        [Abstract]
        [Export("addTag:")]
        bool AddTag(string tag);

        // @required -(NSSet * _Nullable)addTags:(NSArray * _Nonnull)tags __attribute__((warn_unused_result("")));
        [Abstract]
        [Export("addTags:")]
        // [Verify(StronglyTypedNSArray)]
        [return: NullAllowed]
        NSSet AddTags(NSObject[] tags);

        // @required -(BOOL)removeTag:(NSString * _Nonnull)tag __attribute__((warn_unused_result("")));
        [Abstract]
        [Export("removeTag:")]
        bool RemoveTag(string tag);

        // @required -(NSSet * _Nullable)tags __attribute__((warn_unused_result("")));
        [Abstract]
        [NullAllowed, Export("tags")]
        // [Verify(MethodToProperty)]
        NSSet Tags { get; }

        // @required -(void)setDeviceToken:(NSData * _Nonnull)deviceToken;
        [Abstract]
        [Export("setDeviceToken:")]
        void SetDeviceToken(NSData deviceToken);

        // @required -(void)setDebugLoggingEnabled:(BOOL)enabled;
        [Abstract]
        [Export("setDebugLoggingEnabled:")]
        void SetDebugLoggingEnabled(bool enabled);

        // @required -(NSDictionary * _Nullable)attributes __attribute__((warn_unused_result("")));
        [Abstract]
        [NullAllowed, Export("attributes")]
        // [Verify(MethodToProperty)]
        NSDictionary Attributes { get; }

        // @required -(NSString * _Nullable)deviceToken __attribute__((warn_unused_result("")));
        [Abstract]
        [NullAllowed, Export("deviceToken")]
        // [Verify(MethodToProperty)]
        string DeviceToken { get; }

        // @required -(NSString * _Nullable)accessToken __attribute__((warn_unused_result("")));
        [Abstract]
        [NullAllowed, Export("accessToken")]
        // [Verify(MethodToProperty)]
        string AccessToken { get; }

        // @required -(NSString * _Nullable)deviceIdentifier __attribute__((warn_unused_result("")));
        [Abstract]
        [NullAllowed, Export("deviceIdentifier")]
        // [Verify(MethodToProperty)]
        string DeviceIdentifier { get; }

        // @required -(UNNotificationRequest * _Nullable)notificationRequest __attribute__((warn_unused_result("")));
        // @required -(void)setNotificationRequest:(UNNotificationRequest * _Nonnull)request;
        [Abstract]
        [NullAllowed, Export("notificationRequest")]
        // [Verify(MethodToProperty)]
        UNNotificationRequest NotificationRequest { get; set; }

        // @required -(NSDictionary * _Nonnull)notificationUserInfo __attribute__((warn_unused_result("")));
        // @required -(void)setNotificationUserInfo:(NSDictionary * _Nonnull)userInfo;
        [Abstract]
        [Export("notificationUserInfo")]
        // [Verify(MethodToProperty)]
        NSDictionary NotificationUserInfo { get; set; }

        // @required -(BOOL)pushEnabled __attribute__((warn_unused_result("")));
        // @required -(void)setPushEnabled:(BOOL)pushEnabled;
        [Abstract]
        [Export("pushEnabled")]
        // [Verify(MethodToProperty)]
        bool PushEnabled { get; set; }

        // @required -(BOOL)refreshWithFetchCompletionHandler:(void (^ _Nullable)(UIBackgroundFetchResult))completionHandler __attribute__((warn_unused_result("")));
        [Abstract]
        [Export("refreshWithFetchCompletionHandler:")]
        bool RefreshWithFetchCompletionHandler([NullAllowed] Action<UIBackgroundFetchResult> completionHandler);

        // @required -(void)setRegistrationCallback:(void (^ _Nonnull)(NSDictionary * _Nonnull))registrationCallback;
        [Abstract]
        [Export("setRegistrationCallback:")]
        void SetRegistrationCallback(Action<NSDictionary> registrationCallback);

        // @required -(void)unsetRegistrationCallback;
        [Abstract]
        [Export("unsetRegistrationCallback")]
        void UnsetRegistrationCallback();

        // @required -(BOOL)setSignedString:(NSString * _Nullable)signedString __attribute__((warn_unused_result("")));
        [Abstract]
        [Export("setSignedString:")]
        bool SetSignedString([NullAllowed] string signedString);

        // @required -(NSString * _Nullable)signedString __attribute__((warn_unused_result("")));
        [Abstract]
        [NullAllowed, Export("signedString")]
        // [Verify(MethodToProperty)]
        string SignedString { get; }

        // @required -(void)setEventDelegate:(id<SFMCSdkInAppMessageEventDelegate> _Nullable)delegate;
        [Abstract]
        [Export("setEventDelegate:")]
        void SetEventDelegate([NullAllowed] SFMCSdkInAppMessageEventDelegate @delegate);

        // @required -(NSString * _Nullable)messageIdForMessage:(NSDictionary * _Nonnull)forMessage __attribute__((warn_unused_result("")));
        [Abstract]
        [Export("messageIdForMessage:")]
        [return: NullAllowed]
        string MessageIdForMessage(NSDictionary forMessage);

        // @required -(void)showInAppMessageWithMessageId:(NSString * _Nonnull)messageId;
        [Abstract]
        [Export("showInAppMessageWithMessageId:")]
        void ShowInAppMessageWithMessageId(string messageId);

        // @required -(BOOL)setInAppMessageWithFontName:(NSString * _Nullable)fontName __attribute__((warn_unused_result("")));
        [Abstract]
        [Export("setInAppMessageWithFontName:")]
        bool SetInAppMessageWithFontName([NullAllowed] string fontName);

        // @required -(NSArray * _Nullable)getAllMessages __attribute__((warn_unused_result("")));
        [Abstract]
        [NullAllowed, Export("getAllMessages")]
        // [Verify(MethodToProperty), Verify(StronglyTypedNSArray)]
        NSObject[] AllMessages { get; }

        // @required -(NSArray * _Nullable)getUnreadMessages __attribute__((warn_unused_result("")));
        [Abstract]
        [NullAllowed, Export("getUnreadMessages")]
        // [Verify(MethodToProperty), Verify(StronglyTypedNSArray)]
        NSObject[] UnreadMessages { get; }

        // @required -(NSArray * _Nullable)getReadMessages __attribute__((warn_unused_result("")));
        [Abstract]
        [NullAllowed, Export("getReadMessages")]
        // [Verify(MethodToProperty), Verify(StronglyTypedNSArray)]
        NSObject[] ReadMessages { get; }

        // @required -(NSArray * _Nullable)getDeletedMessages __attribute__((warn_unused_result("")));
        [Abstract]
        [NullAllowed, Export("getDeletedMessages")]
        // [Verify(MethodToProperty), Verify(StronglyTypedNSArray)]
        NSObject[] DeletedMessages { get; }

        // @required -(NSUInteger)getAllMessagesCount __attribute__((warn_unused_result("")));
        [Abstract]
        [Export("getAllMessagesCount")]
        // [Verify(MethodToProperty)]
        nuint AllMessagesCount { get; }

        // @required -(NSUInteger)getUnreadMessagesCount __attribute__((warn_unused_result("")));
        [Abstract]
        [Export("getUnreadMessagesCount")]
        // [Verify(MethodToProperty)]
        nuint UnreadMessagesCount { get; }

        // @required -(NSUInteger)getReadMessagesCount __attribute__((warn_unused_result("")));
        [Abstract]
        [Export("getReadMessagesCount")]
        // [Verify(MethodToProperty)]
        nuint ReadMessagesCount { get; }

        // @required -(NSUInteger)getDeletedMessagesCount __attribute__((warn_unused_result("")));
        [Abstract]
        [Export("getDeletedMessagesCount")]
        // [Verify(MethodToProperty)]
        nuint DeletedMessagesCount { get; }

        // @required -(BOOL)markMessageRead:(NSDictionary * _Nonnull)messageDictionary __attribute__((warn_unused_result("")));
        [Abstract]
        [Export("markMessageRead:")]
        bool MarkMessageRead(NSDictionary messageDictionary);

        // @required -(BOOL)markMessageDeleted:(NSDictionary * _Nonnull)messageDictionary __attribute__((warn_unused_result("")));
        [Abstract]
        [Export("markMessageDeleted:")]
        bool MarkMessageDeleted(NSDictionary messageDictionary);

        // @required -(BOOL)markMessageWithIdReadWithMessageId:(NSString * _Nonnull)messageId __attribute__((warn_unused_result("")));
        [Abstract]
        [Export("markMessageWithIdReadWithMessageId:")]
        bool MarkMessageWithIdReadWithMessageId(string messageId);

        // @required -(BOOL)markMessageWithIdDeletedWithMessageId:(NSString * _Nonnull)messageId __attribute__((warn_unused_result("")));
        [Abstract]
        [Export("markMessageWithIdDeletedWithMessageId:")]
        bool MarkMessageWithIdDeletedWithMessageId(string messageId);

        // @required -(BOOL)markAllMessagesRead __attribute__((warn_unused_result("")));
        [Abstract]
        [Export("markAllMessagesRead")]
        // [Verify(MethodToProperty)]
        bool MarkAllMessagesRead { get; }

        // @required -(BOOL)markAllMessagesDeleted __attribute__((warn_unused_result("")));
        [Abstract]
        [Export("markAllMessagesDeleted")]
        // [Verify(MethodToProperty)]
        bool MarkAllMessagesDeleted { get; }

        // @required -(BOOL)refreshMessages __attribute__((warn_unused_result("")));
        [Abstract]
        [Export("refreshMessages")]
        // [Verify(MethodToProperty)]
        bool RefreshMessages { get; }

        // @required -(id<SFMCSdkInboxMessagesDataSource> _Nullable)inboxMessagesTableViewDataSourceForTableView:(UITableView * _Nonnull)tableView __attribute__((warn_unused_result("")));
        [Abstract]
        [Export("inboxMessagesTableViewDataSourceForTableView:")]
        [return: NullAllowed]
        SFMCSdkInboxMessagesDataSource InboxMessagesTableViewDataSourceForTableView(UITableView tableView);

        // @required -(id<SFMCSdkInboxMessagesDelegate> _Nullable)inboxMessagesTableViewDelegateForTableView:(UITableView * _Nonnull)tableView dataSource:(id<SFMCSdkInboxMessagesDataSource> _Nonnull)dataSource __attribute__((warn_unused_result("")));
        [Abstract]
        [Export("inboxMessagesTableViewDelegateForTableView:dataSource:")]
        [return: NullAllowed]
        SFMCSdkInboxMessagesDelegate InboxMessagesTableViewDelegateForTableView(UITableView tableView, SFMCSdkInboxMessagesDataSource dataSource);

        // @required -(BOOL)setPiIdentifier:(NSString * _Nullable)identifier __attribute__((warn_unused_result("")));
        [Abstract]
        [Export("setPiIdentifier:")]
        bool SetPiIdentifier([NullAllowed] string identifier);

        // @required -(NSString * _Nullable)piIdentifier __attribute__((warn_unused_result("")));
        [Abstract]
        [NullAllowed, Export("piIdentifier")]
        // [Verify(MethodToProperty)]
        string PiIdentifier { get; }

        // @required -(void)trackMessageOpened:(NSDictionary * _Nonnull)inboxMessage;
        [Abstract]
        [Export("trackMessageOpened:")]
        void TrackMessageOpened(NSDictionary inboxMessage);

        // @required -(void)trackPageViewWithUrl:(NSString * _Nonnull)url title:(NSString * _Nullable)title item:(NSString * _Nullable)item search:(NSString * _Nullable)search;
        [Abstract]
        [Export("trackPageViewWithUrl:title:item:search:")]
        void TrackPageViewWithUrl(string url, [NullAllowed] string title, [NullAllowed] string item, [NullAllowed] string search);

        // @required -(void)trackCartContents:(NSDictionary * _Nonnull)cartDictionary;
        [Abstract]
        [Export("trackCartContents:")]
        void TrackCartContents(NSDictionary cartDictionary);

        // @required -(void)trackCartConversion:(NSDictionary * _Nonnull)orderDictionary;
        [Abstract]
        [Export("trackCartConversion:")]
        void TrackCartConversion(NSDictionary orderDictionary);

        // @required -(NSDictionary * _Nullable)cartItemDictionaryWithPrice:(NSNumber * _Nonnull)price quantity:(NSNumber * _Nonnull)quantity item:(NSString * _Nonnull)item uniqueId:(NSString * _Nullable)uniqueId __attribute__((warn_unused_result("")));
        [Abstract]
        [Export("cartItemDictionaryWithPrice:quantity:item:uniqueId:")]
        [return: NullAllowed]
        NSDictionary CartItemDictionaryWithPrice(NSNumber price, NSNumber quantity, string item, [NullAllowed] string uniqueId);

        // @required -(NSDictionary * _Nullable)cartDictionaryWithCartItem:(NSArray * _Nonnull)cartItem __attribute__((warn_unused_result("")));
        [Abstract]
        [Export("cartDictionaryWithCartItem:")]
        // [Verify(StronglyTypedNSArray)]
        [return: NullAllowed]
        NSDictionary CartDictionaryWithCartItem(NSObject[] cartItem);

        // @required -(NSDictionary * _Nullable)orderDictionaryWithOrderNumber:(NSString * _Nonnull)orderNumber shipping:(NSNumber * _Nonnull)shipping discount:(NSNumber * _Nonnull)discount cart:(NSDictionary * _Nonnull)cart __attribute__((warn_unused_result("")));
        [Abstract]
        [Export("orderDictionaryWithOrderNumber:shipping:discount:cart:")]
        [return: NullAllowed]
        NSDictionary OrderDictionaryWithOrderNumber(string orderNumber, NSNumber shipping, NSNumber discount, NSDictionary cart);

        // @required -(void)setLocationDelegate:(id<SFMCSdkLocationDelegate> _Nullable)delegate;
        [Abstract]
        [Export("setLocationDelegate:")]
        void SetLocationDelegate([NullAllowed] SFMCSdkLocationDelegate @delegate);

        // @required -(CLRegion * _Nullable)regionFromDictionary:(NSDictionary * _Nonnull)dictionary __attribute__((warn_unused_result("")));
        [Abstract]
        [Export("regionFromDictionary:")]
        [return: NullAllowed]
        CLRegion RegionFromDictionary(NSDictionary dictionary);

        // @required -(BOOL)locationEnabled __attribute__((warn_unused_result("")));
        [Abstract]
        [Export("locationEnabled")]
        // [Verify(MethodToProperty)]
        bool LocationEnabled { get; }

        // @required -(void)startWatchingLocation;
        [Abstract]
        [Export("startWatchingLocation")]
        void StartWatchingLocation();

        // @required -(void)stopWatchingLocation;
        [Abstract]
        [Export("stopWatchingLocation")]
        void StopWatchingLocation();

        // @required -(BOOL)watchingLocation __attribute__((warn_unused_result("")));
        [Abstract]
        [Export("watchingLocation")]
        // [Verify(MethodToProperty)]
        bool WatchingLocation { get; }

        // @required -(NSDictionary<NSString *,NSString *> * _Nullable)lastKnownLocation __attribute__((warn_unused_result("")));
        [Abstract]
        [NullAllowed, Export("lastKnownLocation")]
        // [Verify(MethodToProperty)]
        NSDictionary<NSString, NSString> LastKnownLocation { get; }

        // @required -(void)setURLHandlingDelegate:(id<SFMCSdkURLHandlingDelegate> _Nullable)delegate;
        [Abstract]
        [Export("setURLHandlingDelegate:")]
        void SetURLHandlingDelegate([NullAllowed] SFMCSdkURLHandlingDelegate @delegate);

        // @required -(BOOL)resetDataPolicy __attribute__((warn_unused_result("")));
        [Abstract]
        [Export("resetDataPolicy")]
        // [Verify(MethodToProperty)]
        bool ResetDataPolicy { get; }
    }

    // @interface SFMCSdkPUSH : NSObject <PushInterface>
    [BaseType(typeof(NSObject))]
    [DisableDefaultCtor]
    public interface SFMCSdkPUSH : PushInterface
    {
        // -(enum SFMCSdkModuleStatus)getStatus __attribute__((warn_unused_result("")));
        [Export("getStatus")]
        // [Verify(MethodToProperty)]
        SFMCSdkModuleStatus Status { get; }

        // -(id<SFMCSdkModuleIdentity> _Nullable)getIdentity __attribute__((warn_unused_result("")));
        [NullAllowed, Export("getIdentity")]
        // [Verify(MethodToProperty)]
        SFMCSdkModuleIdentity Identity { get; }

        // -(void)tearDown __attribute__((deprecated("The SFMCSdk takes care of tear downs during initializations, making this method unnecessary. Its usage should be avoided to prevent race conditions.")));
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

        // -(NSDictionary * _Nullable)attributes __attribute__((warn_unused_result("")));
        [NullAllowed, Export("attributes")]
        // [Verify(MethodToProperty)]
        NSDictionary Attributes { get; }

        // -(NSString * _Nullable)deviceToken __attribute__((warn_unused_result("")));
        [NullAllowed, Export("deviceToken")]
        // [Verify(MethodToProperty)]
        string DeviceToken { get; }

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

        // -(void)setRegistrationCallback:(void (^ _Nonnull)(NSDictionary * _Nonnull))registrationCallback;
        [Export("setRegistrationCallback:")]
        void SetRegistrationCallback(Action<NSDictionary> registrationCallback);

        // -(void)unsetRegistrationCallback;
        [Export("unsetRegistrationCallback")]
        void UnsetRegistrationCallback();

        // -(BOOL)setSignedString:(NSString * _Nullable)signedString __attribute__((warn_unused_result("")));
        [Export("setSignedString:")]
        bool SetSignedString([NullAllowed] string signedString);

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

        // -(BOOL)resetDataPolicy __attribute__((warn_unused_result("")));
        [Export("resetDataPolicy")]
        // [Verify(MethodToProperty)]
        bool ResetDataPolicy { get; }
    }

    // @interface SFMCSdkPreorderEvent : SFMCSdkOrderEvent
    [BaseType(typeof(SFMCSdkOrderEvent))]
    interface SFMCSdkPreorderEvent
    {
        // -(instancetype _Nonnull)initWithOrder:(SFMCSdkOrder * _Nonnull)order __attribute__((objc_designated_initializer));
        [Export("initWithOrder:")]
        [DesignatedInitializer]
        NativeHandle Constructor(SFMCSdkOrder order);
    }

    // @interface SFMCSdkPurchaseOrderEvent : SFMCSdkOrderEvent
    [BaseType(typeof(SFMCSdkOrderEvent))]
    interface SFMCSdkPurchaseOrderEvent
    {
        // -(instancetype _Nonnull)initWithOrder:(SFMCSdkOrder * _Nonnull)order __attribute__((objc_designated_initializer));
        [Export("initWithOrder:")]
        [DesignatedInitializer]
        NativeHandle Constructor(SFMCSdkOrder order);
    }

    // @interface SFMCSdkQuickViewCatalogObjectEvent : SFMCSdkCatalogObjectEvent
    [BaseType(typeof(SFMCSdkCatalogObjectEvent))]
    interface SFMCSdkQuickViewCatalogObjectEvent
    {
        // -(instancetype _Nonnull)initWithCatalogObject:(SFMCSdkCatalogObject * _Nonnull)catalogObject __attribute__((objc_designated_initializer));
        [Export("initWithCatalogObject:")]
        [DesignatedInitializer]
        NativeHandle Constructor(SFMCSdkCatalogObject catalogObject);
    }

    // @interface SFMCSdkRemoveFromCartEvent : SFMCSdkCartEvent
    [BaseType(typeof(SFMCSdkCartEvent))]
    interface SFMCSdkRemoveFromCartEvent
    {
        // -(instancetype _Nonnull)initWithLineItem:(SFMCSdkLineItem * _Nonnull)lineItem __attribute__((objc_designated_initializer));
        [Export("initWithLineItem:")]
        [DesignatedInitializer]
        NativeHandle Constructor(SFMCSdkLineItem lineItem);
    }

    // @interface SFMCSdkReplaceCartEvent : SFMCSdkCartEvent
    [BaseType(typeof(SFMCSdkCartEvent))]
    interface SFMCSdkReplaceCartEvent
    {
        // -(instancetype _Nonnull)initWithLineItems:(NSArray<SFMCSdkLineItem *> * _Nonnull)lineItems __attribute__((objc_designated_initializer));
        [Export("initWithLineItems:")]
        [DesignatedInitializer]
        NativeHandle Constructor(SFMCSdkLineItem[] lineItems);
    }

    // @interface SFMCSdkReturnOrderEvent : SFMCSdkOrderEvent
    [BaseType(typeof(SFMCSdkOrderEvent))]
    interface SFMCSdkReturnOrderEvent
    {
        // -(instancetype _Nonnull)initWithOrder:(SFMCSdkOrder * _Nonnull)order __attribute__((objc_designated_initializer));
        [Export("initWithOrder:")]
        [DesignatedInitializer]
        NativeHandle Constructor(SFMCSdkOrder order);
    }

    // @interface SFMCSdkReviewCatalogObjectEvent : SFMCSdkCatalogObjectEvent
    [BaseType(typeof(SFMCSdkCatalogObjectEvent))]
    interface SFMCSdkReviewCatalogObjectEvent
    {
        // -(instancetype _Nonnull)initWithCatalogObject:(SFMCSdkCatalogObject * _Nonnull)catalogObject __attribute__((objc_designated_initializer));
        [Export("initWithCatalogObject:")]
        [DesignatedInitializer]
        NativeHandle Constructor(SFMCSdkCatalogObject catalogObject);
    }

    // @protocol SFMCModule
    /*
      Check whether adding [Model] to this declaration is appropriate.
      [Model] is used to generate a C# class that implements this protocol,
      and might be useful for protocols that consumers are supposed to implement,
      since consumers can subclass the generated class instead of implementing
      the generated interface. If consumers are not supposed to implement this
      protocol, then [Model] is redundant and will generate code that will never
      be used.
    */
    [Protocol(Name = "_TtP7SFMCSDK10SFMCModule_")]
    public interface SFMCModule
    {
        // @required @property (readonly, nonatomic) enum SFMCSdkModuleName name;
        [Abstract]
        [Export("name")]
        SFMCSdkModuleName Name { get; }

        // @required @property (readonly, copy, nonatomic, class) NSString * _Nonnull moduleVersion;
        [Static, Abstract]
        [Export("moduleVersion")]
        string ModuleVersion { get; }

        // @required @property (copy, nonatomic, class) NSDictionary<NSString *,NSString *> * _Nullable stateProperties;
        [Static, Abstract]
        [NullAllowed, Export("stateProperties", ArgumentSemantic.Copy)]
        NSDictionary<NSString, NSString> StateProperties { get; set; }

        // @required +(id<SFMCModule> _Nullable)initModuleWithConfig:(id<SFMCSdkModuleConfig> _Nonnull)config components:(SFMCSdkComponents * _Nonnull)components __attribute__((objc_method_family("none"))) __attribute__((warn_unused_result("")));
        [Static, Abstract]
        [Export("initModuleWithConfig:components:")]
        [return: NullAllowed]
        SFMCModule Components(SFMCSdkModuleConfig config, SFMCSdkComponents components);
    }

    // @interface SFMCSdk : NSObject
    [BaseType(typeof(NSObject))]
    [DisableDefaultCtor]
    public interface SFMCSdk
    {
        // @property (nonatomic, strong, class) SFMCSdkCDP * _Nonnull cdp;
        [Static]
        [Export("cdp", ArgumentSemantic.Strong)]
        SFMCSdkCDP Cdp { get; set; }

        // @property (nonatomic, strong, class) SFMCSdkPUSH * _Nonnull mp;
        [Static]
        [Export("mp", ArgumentSemantic.Strong)]
        SFMCSdkPUSH Mp { get; set; }

        // @property (nonatomic, strong, class) SFMCSdkIDENTITY * _Nonnull identity;
        [Static]
        [Export("identity", ArgumentSemantic.Strong)]
        SFMCSdkIDENTITY Identity { get; set; }

        // @property (copy, nonatomic, class) NSString * _Nonnull sdkVersion;
        [Static]
        [Export("sdkVersion")]
        string SdkVersion { get; set; }

        // +(void)initializeSdk:(SFMCSdkConfig * _Nonnull)configuration;
        [Static]
        [Export("initializeSdk:")]
        void InitializeSdk(SFMCSdkConfig configuration);

        // +(void)trackWithEvent:(id<SFMCSdkEvent> _Nonnull)event;
        [Static]
        [Export("trackWithEvent:")]
        void TrackWithEvent(SFMCSdkEvent @event);

        // +(NSString * _Nonnull)state __attribute__((warn_unused_result("")));
        [Static]
        [Export("state")]
        // [Verify(MethodToProperty)]
        string State { get; }

        // +(void)setLoggerWithLogLevel:(enum SFMCSdkLogLevel)logLevel logOutputter:(SFMCSdkLogOutputter * _Nonnull)logOutputter;
        [Static]
        [Export("setLoggerWithLogLevel:logOutputter:")]
        void SetLoggerWithLogLevel(SFMCSdkLogLevel logLevel, SFMCSdkLogOutputter logOutputter);

        // +(void)setAutoMergePolicyOnCompletion:(void (^ _Nonnull)(BOOL))onCompletion;
        [Static]
        [Export("setAutoMergePolicyOnCompletion:")]
        void SetAutoMergePolicyOnCompletion(Action<bool> onCompletion);

        // +(void)setManualMergePolicyWithHandler:(void (^ _Nonnull)(NSDictionary * _Nonnull, NSDictionary * _Nonnull))handler;
        [Static]
        [Export("setManualMergePolicyWithHandler:")]
        void SetManualMergePolicyWithHandler(Action<NSDictionary, NSDictionary> handler);

        // +(enum SFMCSDKDataMergePolicy)getDataMergePolicy __attribute__((warn_unused_result("")));
        [Static]
        [Export("getDataMergePolicy")]
        // [Verify(MethodToProperty)]
        SFMCSDKDataMergePolicy DataMergePolicy { get; }

        // +(BOOL)resetDataPolicyWithAppId:(NSString * _Nonnull)appId __attribute__((warn_unused_result("")));
        [Static]
        [Export("resetDataPolicyWithAppId:")]
        bool ResetDataPolicyWithAppId(string appId);

        // +(void (^ _Nullable)(BOOL))getAutoDataPolicyCallBack __attribute__((warn_unused_result("")));
        [Static]
        [NullAllowed, Export("getAutoDataPolicyCallBack")]
        // [Verify(MethodToProperty)]
        Action<bool> AutoDataPolicyCallBack { get; }

        // +(void (^ _Nullable)(NSDictionary * _Nonnull, NSDictionary * _Nonnull))getManualDataPolicyCallBack __attribute__((warn_unused_result("")));
        [Static]
        [NullAllowed, Export("getManualDataPolicyCallBack")]
        // [Verify(MethodToProperty)]
        Action<NSDictionary, NSDictionary> ManualDataPolicyCallBack { get; }

        // +(void)clearLoggerFilters;
        [Static]
        [Export("clearLoggerFilters")]
        void ClearLoggerFilters();

        // TODO: Binding errors
        // +(void)setKeychainAccessibleAttributeWithAccessibleAttribute:(CFTypeRef _Nullable)accessibleAttribute;
        //[Static]
        //[Export("setKeychainAccessibleAttributeWithAccessibleAttribute:")]
        //unsafe void SetKeychainAccessibleAttributeWithAccessibleAttribute([NullAllowed] void* accessibleAttribute);

        // TODO: Binding errors
        // +(CFTypeRef _Nullable)keychainAccessibleAttribute __attribute__((warn_unused_result("")));
        //[Static]
        //[NullAllowed, Export("keychainAccessibleAttribute")]
        //// [Verify(MethodToProperty)]
        //unsafe void* KeychainAccessibleAttribute { get; }

        // +(void)setKeychainAccessErrorsAreFatalWithErrorsAreFatal:(BOOL)errorsAreFatal;
        [Static]
        [Export("setKeychainAccessErrorsAreFatalWithErrorsAreFatal:")]
        void SetKeychainAccessErrorsAreFatalWithErrorsAreFatal(bool errorsAreFatal);

        // +(BOOL)keychainAccessErrorsAreFatal __attribute__((warn_unused_result("")));
        [Static]
        [Export("keychainAccessErrorsAreFatal")]
        // [Verify(MethodToProperty)]
        bool KeychainAccessErrorsAreFatal { get; }

        // +(void)setFileProtectionTypeWithFileProtectionType:(NSFileProtectionType _Nullable)fileProtectionType;
        [Static]
        [Export("setFileProtectionTypeWithFileProtectionType:")]
        void SetFileProtectionTypeWithFileProtectionType([NullAllowed] string fileProtectionType);

        // +(NSFileProtectionType _Nullable)fileProtectionType __attribute__((warn_unused_result("")));
        [Static]
        [NullAllowed, Export("fileProtectionType")]
        // [Verify(MethodToProperty)]
        string FileProtectionType { get; }

        // +(void)tearDownModuleWithName:(enum SFMCSdkModuleName)name __attribute__((deprecated("The SFMCSdk takes care of tear downs during initializations, making this method unnecessary. Its usage should be avoided to prevent race conditions.")));
        [Static]
        [Export("tearDownModuleWithName:")]
        void TearDownModuleWithName(SFMCSdkModuleName name);
    }

    // @interface SFMCSdkComponents : NSObject
    [BaseType(typeof(NSObject))]
    [DisableDefaultCtor]
    public interface SFMCSdkComponents
    {
        // @property (readonly, nonatomic, strong) SFMCSdkEncryptionManager * _Nonnull encryptionManager;
        [Export("encryptionManager", ArgumentSemantic.Strong)]
        SFMCSdkEncryptionManager EncryptionManager { get; }

        // @property (readonly, nonatomic, strong) SFMCSdkStorageManager * _Nonnull storageManager;
        [Export("storageManager", ArgumentSemantic.Strong)]
        SFMCSdkStorageManager StorageManager { get; }

        // @property (readonly, nonatomic, strong) SFMCSdkBehaviorManager * _Nonnull behaviorManager;
        [Export("behaviorManager", ArgumentSemantic.Strong)]
        SFMCSdkBehaviorManager BehaviorManager { get; }

        // -(SFMCSdkNetworkManager * _Nonnull)createNetworkManagerWithAuthenticator:(id<SFMCSdkAuthenticator> _Nullable)authenticator __attribute__((warn_unused_result("")));
        [Export("createNetworkManagerWithAuthenticator:")]
        SFMCSdkNetworkManager CreateNetworkManagerWithAuthenticator([NullAllowed] SFMCSdkAuthenticator authenticator);
    }

    // @interface SFMCSdkLogger : NSObject <Logger>
    [BaseType(typeof(NSObject), Name = "_TtC7SFMCSDK13SFMCSdkLogger")]
    public interface SFMCSdkLogger : Logger
    {
        // @property (readonly, nonatomic, strong, class) SFMCSdkLogger * _Nonnull shared;
        [Static]
        [Export("shared", ArgumentSemantic.Strong)]
        SFMCSdkLogger Shared { get; }

        // @property (readonly, copy, nonatomic) NSArray<NSString *> * _Nonnull redactedValues;
        [Export("redactedValues", ArgumentSemantic.Copy)]
        string[] RedactedValues { get; }

        // -(enum SFMCSdkLogLevel)getLogLevel __attribute__((warn_unused_result("")));
        [Export("getLogLevel")]
        // [Verify(MethodToProperty)]
        SFMCSdkLogLevel LogLevel { get; }

        // -(void)debugWithCategory:(enum SFMCSdkLoggerCategory)category message:(NSString * _Nonnull)message;
        [Export("debugWithCategory:message:")]
        void DebugWithCategory(SFMCSdkLoggerCategory category, string message);

        // -(void)warningWithCategory:(enum SFMCSdkLoggerCategory)category message:(NSString * _Nonnull)message;
        [Export("warningWithCategory:message:")]
        void WarningWithCategory(SFMCSdkLoggerCategory category, string message);

        // -(void)errorWithCategory:(enum SFMCSdkLoggerCategory)category message:(NSString * _Nonnull)message;
        [Export("errorWithCategory:message:")]
        void ErrorWithCategory(SFMCSdkLoggerCategory category, string message);

        // -(void)faultWithCategory:(enum SFMCSdkLoggerCategory)category message:(NSString * _Nonnull)message;
        [Export("faultWithCategory:message:")]
        void FaultWithCategory(SFMCSdkLoggerCategory category, string message);
    }

    // @interface SFMCSdkScreenEntry : SFMCSdkBehavior
    [BaseType(typeof(SFMCSdkBehavior))]
    public interface SFMCSdkScreenEntry
    {
    }

    // @interface SFMCSdkSecurePrefs : NSObject
    [BaseType(typeof(NSObject))]
    [DisableDefaultCtor]
    public interface SFMCSdkSecurePrefs
    {
        // -(void)setString:(NSString * _Nonnull)value for:(NSString * _Nonnull)key;
        [Export("setString:for:")]
        void SetString(string value, string key);

        // -(void)setInt:(NSInteger)value for:(NSString * _Nonnull)key;
        [Export("setInt:for:")]
        void SetInt(nint value, string key);

        // -(void)setBool:(BOOL)value for:(NSString * _Nonnull)key;
        [Export("setBool:for:")]
        void SetBool(bool value, string key);

        // -(void)setFloat:(float)value for:(NSString * _Nonnull)key;
        [Export("setFloat:for:")]
        void SetFloat(float value, string key);

        // -(void)setDouble:(double)value for:(NSString * _Nonnull)key;
        [Export("setDouble:for:")]
        void SetDouble(double value, string key);

        // -(NSString * _Nullable)stringForKey:(NSString * _Nonnull)key __attribute__((warn_unused_result("")));
        [Export("stringForKey:")]
        [return: NullAllowed]
        string StringForKey(string key);

        // -(void)removeWithKey:(NSString * _Nonnull)key;
        [Export("removeWithKey:")]
        void RemoveWithKey(string key);

        // -(void)clearAll;
        [Export("clearAll")]
        void ClearAll();
    }

    // @interface SFMCSdkShareCatalogObjectEvent : SFMCSdkCatalogObjectEvent
    [BaseType(typeof(SFMCSdkCatalogObjectEvent))]
    interface SFMCSdkShareCatalogObjectEvent
    {
        // -(instancetype _Nonnull)initWithCatalogObject:(SFMCSdkCatalogObject * _Nonnull)catalogObject __attribute__((objc_designated_initializer));
        [Export("initWithCatalogObject:")]
        [DesignatedInitializer]
        NativeHandle Constructor(SFMCSdkCatalogObject catalogObject);
    }

    // @interface SFMCSdkShipOrderEvent : SFMCSdkOrderEvent
    [BaseType(typeof(SFMCSdkOrderEvent))]
    interface SFMCSdkShipOrderEvent
    {
        // -(instancetype _Nonnull)initWithOrder:(SFMCSdkOrder * _Nonnull)order __attribute__((objc_designated_initializer));
        [Export("initWithOrder:")]
        [DesignatedInitializer]
        NativeHandle Constructor(SFMCSdkOrder order);
    }

    // @interface SFMCSdkStorageManager : NSObject
    [BaseType(typeof(NSObject))]
    [DisableDefaultCtor]
    public interface SFMCSdkStorageManager
    {
        // -(NSString * _Nonnull)getRegistrationId __attribute__((warn_unused_result("")));
        [Export("getRegistrationId")]
        // [Verify(MethodToProperty)]
        string RegistrationId { get; }

        // -(SFMCSdkSecurePrefs * _Nonnull)getOrCreateSecurePrefsWithName:(NSString * _Nonnull)name __attribute__((warn_unused_result("")));
        [Export("getOrCreateSecurePrefsWithName:")]
        SFMCSdkSecurePrefs GetOrCreateSecurePrefsWithName(string name);

        // -(NSString * _Nonnull)getFilenameForModuleInstallationWithFileName:(NSString * _Nonnull)fileName __attribute__((warn_unused_result("")));
        [Export("getFilenameForModuleInstallationWithFileName:")]
        string GetFilenameForModuleInstallationWithFileName(string fileName);

        // TODO: Binding errors
        // +(void)setKeychainAccessibilityAttributeWithAccessibleAttribute:(CFTypeRef _Nullable)accessibleAttribute;
        //[Static]
        //[Export("setKeychainAccessibilityAttributeWithAccessibleAttribute:")]
        //unsafe void SetKeychainAccessibilityAttributeWithAccessibleAttribute([NullAllowed] void* accessibleAttribute);

        // TODO: Binding errors
        // +(CFTypeRef _Nullable)keychainAccessibilityAttribute __attribute__((warn_unused_result("")));
        //[Static]        
        //[NullAllowed, Export("keychainAccessibilityAttribute")]
        //// [Verify(MethodToProperty)]
        //unsafe void* KeychainAccessibilityAttribute { get; }

        // +(void)setKeychainAccessErrorsAreFatalWithErrorsAreFatal:(BOOL)errorsAreFatal;
        [Static]
        [Export("setKeychainAccessErrorsAreFatalWithErrorsAreFatal:")]
        void SetKeychainAccessErrorsAreFatalWithErrorsAreFatal(bool errorsAreFatal);

        // +(BOOL)keychainAccessErrorsAreFatal __attribute__((warn_unused_result("")));
        [Static]
        [Export("keychainAccessErrorsAreFatal")]
        // [Verify(MethodToProperty)]
        bool KeychainAccessErrorsAreFatal { get; }

        // +(void)setFileSystemProtectionTypeWithFileProtectionType:(NSFileProtectionType _Nullable)fileProtectionType;
        [Static]
        [Export("setFileSystemProtectionTypeWithFileProtectionType:")]
        void SetFileSystemProtectionTypeWithFileProtectionType([NullAllowed] string fileProtectionType);

        // +(NSFileProtectionType _Nullable)fileSystemProtectionType __attribute__((warn_unused_result("")));
        [Static]
        [NullAllowed, Export("fileSystemProtectionType")]
        // [Verify(MethodToProperty)]
        string FileSystemProtectionType { get; }
    }

    // @protocol Subscriber
    /*
      Check whether adding [Model] to this declaration is appropriate.
      [Model] is used to generate a C# class that implements this protocol,
      and might be useful for protocols that consumers are supposed to implement,
      since consumers can subclass the generated class instead of implementing
      the generated interface. If consumers are not supposed to implement this
      protocol, then [Model] is redundant and will generate code that will never
      be used.
    */
    [Protocol(Name = "_TtP7SFMCSDK10Subscriber_")]
    public interface Subscriber
    {
        // @required @property (readonly, nonatomic) enum SFMCSdkModuleName name;
        [Abstract]
        [Export("name")]
        SFMCSdkModuleName Name { get; }

        // @required -(void)receiveWithMessage:(SFMCSdkMessage * _Nonnull)message;
        [Abstract]
        [Export("receiveWithMessage:")]
        void ReceiveWithMessage(SFMCSdkMessage message);
    }

    // @interface SFMCSdkSystemEvent : NSObject <SFMCSdkEvent>
    [BaseType(typeof(NSObject))]
    [DisableDefaultCtor]
    interface SFMCSdkSystemEvent : SFMCSdkEvent
    {
        // @property (readonly, copy, nonatomic) NSString * _Nonnull id;
        [Export("id")]
        string Id { get; }

        // @property (readonly, copy, nonatomic) NSString * _Nonnull name;
        [Export("name")]
        string Name { get; }

        // @property (readonly, nonatomic) enum SFMCSdkEventCategory category;
        [Export("category")]
        SFMCSdkEventCategory Category { get; }

        // @property (readonly, copy, nonatomic) NSDictionary<NSString *,id> * _Nullable attributes;
        [NullAllowed, Export("attributes", ArgumentSemantic.Copy)]
        NSDictionary<NSString, NSObject> Attributes { get; }

        // -(instancetype _Nonnull)initWithName:(NSString * _Nonnull)name attributes:(NSDictionary<NSString *,id> * _Nullable)attributes __attribute__((objc_designated_initializer));
        [Export("initWithName:attributes:")]
        [DesignatedInitializer]
        NativeHandle Constructor(string name, [NullAllowed] NSDictionary<NSString, NSObject> attributes);
    }

    // @protocol SFMCSdkURLHandlingDelegate
    [Protocol, Model(AutoGeneratedName = true)]
    public interface SFMCSdkURLHandlingDelegate
    {
        // @required -(void)sfmc_handleURL:(NSURL * _Nonnull)url type:(NSString * _Nonnull)type;
        [Abstract]
        [Export("sfmc_handleURL:type:")]
        void Type(NSUrl url, string type);
    }

    // @interface SFMCSdkViewCatalogObjectDetailEvent : SFMCSdkCatalogObjectEvent
    [BaseType(typeof(SFMCSdkCatalogObjectEvent))]
    public interface SFMCSdkViewCatalogObjectDetailEvent
    {
        // -(instancetype _Nonnull)initWithCatalogObject:(SFMCSdkCatalogObject * _Nonnull)catalogObject __attribute__((objc_designated_initializer));
        [Export("initWithCatalogObject:")]
        [DesignatedInitializer]
        NativeHandle Constructor(SFMCSdkCatalogObject catalogObject);
    }

    // @interface SFMCSdkViewCatalogObjectEvent : SFMCSdkCatalogObjectEvent
    [BaseType(typeof(SFMCSdkCatalogObjectEvent))]
    public interface SFMCSdkViewCatalogObjectEvent
    {
        // -(instancetype _Nonnull)initWithCatalogObject:(SFMCSdkCatalogObject * _Nonnull)catalogObject __attribute__((objc_designated_initializer));
        [Export("initWithCatalogObject:")]
        [DesignatedInitializer]
        NativeHandle Constructor(SFMCSdkCatalogObject catalogObject);
    }

    // @interface SFMCSdkWrappedRequest : NSObject
    [BaseType(typeof(NSObject))]
    [DisableDefaultCtor]
    public interface SFMCSdkWrappedRequest
    {
        // @property (copy, nonatomic) NSURLRequest * _Nonnull request;
        [Export("request", ArgumentSemantic.Copy)]
        NSUrlRequest Request { get; set; }

        // @property (readonly, copy, nonatomic) NSString * _Nonnull name;
        [Export("name")]
        string Name { get; }

        // @property (readonly, nonatomic) NSTimeInterval rateLimit;
        [Export("rateLimit")]
        double RateLimit { get; }

        // @property (readonly, copy, nonatomic) NSString * _Nullable tag;
        [NullAllowed, Export("tag")]
        string Tag { get; }
    }

    // @interface SFMCSdkWrappedRequestBuilder : NSObject
    [BaseType(typeof(NSObject))]
    public interface SFMCSdkWrappedRequestBuilder
    {
        // -(SFMCSdkWrappedRequestBuilder * _Nonnull)method:(NSString * _Nonnull)method __attribute__((warn_unused_result("")));
        [Export("method:")]
        SFMCSdkWrappedRequestBuilder Method(string method);

        // -(SFMCSdkWrappedRequestBuilder * _Nonnull)url:(NSString * _Nonnull)url __attribute__((warn_unused_result("")));
        [Export("url:")]
        SFMCSdkWrappedRequestBuilder Url(string url);

        // -(SFMCSdkWrappedRequestBuilder * _Nonnull)urlWithBase:(NSString * _Nonnull)base path:(NSString * _Nonnull)path __attribute__((warn_unused_result("")));
        [Export("urlWithBase:path:")]
        SFMCSdkWrappedRequestBuilder UrlWithBase(string @base, string path);

        // -(SFMCSdkWrappedRequestBuilder * _Nonnull)addOrReplaceHeaderWithKey:(NSString * _Nonnull)key value:(NSString * _Nonnull)value __attribute__((warn_unused_result("")));
        [Export("addOrReplaceHeaderWithKey:value:")]
        SFMCSdkWrappedRequestBuilder AddOrReplaceHeaderWithKey(string key, string value);

        // -(SFMCSdkWrappedRequestBuilder * _Nonnull)body:(NSData * _Nonnull)body __attribute__((warn_unused_result("")));
        [Export("body:")]
        SFMCSdkWrappedRequestBuilder Body(NSData body);

        // -(SFMCSdkWrappedRequestBuilder * _Nonnull)timeout:(NSTimeInterval)seconds __attribute__((warn_unused_result("")));
        [Export("timeout:")]
        SFMCSdkWrappedRequestBuilder Timeout(double seconds);

        // -(SFMCSdkWrappedRequestBuilder * _Nonnull)rateLimit:(NSTimeInterval)seconds __attribute__((warn_unused_result("")));
        [Export("rateLimit:")]
        SFMCSdkWrappedRequestBuilder RateLimit(double seconds);

        // -(SFMCSdkWrappedRequestBuilder * _Nonnull)name:(NSString * _Nonnull)name __attribute__((warn_unused_result("")));
        [Export("name:")]
        SFMCSdkWrappedRequestBuilder Name(string name);

        // -(SFMCSdkWrappedRequestBuilder * _Nonnull)tag:(NSString * _Nonnull)tag __attribute__((warn_unused_result("")));
        [Export("tag:")]
        SFMCSdkWrappedRequestBuilder Tag(string tag);

        // -(SFMCSdkWrappedRequest * _Nullable)build __attribute__((warn_unused_result("")));
        [NullAllowed, Export("build")]
        //// [Verify(MethodToProperty)]
        SFMCSdkWrappedRequest Build { get; }
    }

    // @interface SFMCSdkWrappedResponse : NSObject
    [BaseType(typeof(NSObject))]
    [DisableDefaultCtor]
    public interface SFMCSdkWrappedResponse
    {
        // @property (readonly, copy, nonatomic) NSData * _Nullable data;
        [NullAllowed, Export("data", ArgumentSemantic.Copy)]
        NSData Data { get; }

        // @property (readonly, nonatomic, strong) NSHTTPURLResponse * _Nullable response;
        [NullAllowed, Export("response", ArgumentSemantic.Strong)]
        NSHttpUrlResponse Response { get; }

        // @property (readonly, nonatomic) NSError * _Nullable error;
        [NullAllowed, Export("error")]
        NSError Error { get; }

        // @property (readonly, nonatomic) BOOL isSuccess;
        [Export("isSuccess")]
        bool IsSuccess { get; }

        // @property (readonly, nonatomic) BOOL isUnauthorized;
        [Export("isUnauthorized")]
        bool IsUnauthorized { get; }

        // @property (readonly, nonatomic) int64_t timeToExecute;
        [Export("timeToExecute")]
        long TimeToExecute { get; }

        // -(instancetype _Nonnull)initWithData:(NSData * _Nullable)data response:(NSURLResponse * _Nullable)response error:(NSError * _Nullable)error startTimeMillis:(int64_t)startTimeMillis endTimeMillis:(int64_t)endTimeMillis __attribute__((objc_designated_initializer));
        [Export("initWithData:response:error:startTimeMillis:endTimeMillis:")]
        [DesignatedInitializer]
        NativeHandle Constructor([NullAllowed] NSData data, [NullAllowed] NSUrlResponse response, [NullAllowed] NSError error, long startTimeMillis, long endTimeMillis);
    }
}