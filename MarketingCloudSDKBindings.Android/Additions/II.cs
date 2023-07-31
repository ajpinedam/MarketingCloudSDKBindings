using System.Collections.Generic;
using Java.Lang;
using Org.Json;

namespace Com.Salesforce.Marketingcloud
{
    public partial class II : global::Com.Salesforce.Marketingcloud.Sfmcsdk.Components.Identity.ModuleIdentity
    {
        public override JSONObject CustomPropertiesToJson(IDictionary<string, Object> customProperties)
        {
            return customPropertiesToJsonLocal(customProperties);
        }
    }
}
