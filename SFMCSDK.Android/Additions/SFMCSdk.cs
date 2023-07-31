using Android.Content;
using Java.Lang;
using Kotlin.Jvm.Functions;

namespace Com.Salesforce.Marketingcloud.Sfmcsdk
{
	public partial class SFMCSdk
    {
		public static void Configure(Context context, SFMCSdkModuleConfig config, InitializationListener listener)
		{
            Configure(context, config, listener);
		}
	}

    public class InitializationListener : Java.Lang.Object, IFunction1
    {
        private readonly System.Action<InitializationStatus> OnInvoked;

        public InitializationListener(System.Action<InitializationStatus> onInvoke)
        {
            OnInvoked = onInvoke;
        }

        public Java.Lang.Object Invoke(Java.Lang.Object objParameter)
        {
            try
            {
                InitializationStatus parameter = (InitializationStatus)objParameter;
                OnInvoked?.Invoke(parameter);
            }
            catch (Exception ex)
            {
                // Exception handling, if needed
            }

            return null;
        }
    }
}
